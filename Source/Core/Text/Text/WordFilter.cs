using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BeeneticToolkit.Text {

    /// <summary>
    /// A bad-word filter for player-entered text (display names, statuses, chat lines) that sees through the usual
    /// disguises: case, accents, Cyrillic and Greek lookalikes, styled and enclosed Unicode letters, fullwidth forms,
    /// leet (<c>sh1t</c>, <c>a$$</c>), stretched letters (<c>baaad</c>), and separators (<c>b.a.d</c>). Pure .NET with
    /// no engine or I/O; hand it a <see cref="WordList"/> and check text against <see cref="WordFilterRules"/>.
    /// Immutable and thread-safe; build one per list and share it.
    /// </summary>
    /// <remarks>
    /// <para>The rules, in order, with the first failure returned as the verdict:</para>
    /// <list type="number">
    /// <item>Trim U+0020 spaces from both ends (only those). A non-empty text made only of blank characters (Unicode
    /// spaces, zero-width spaces and joiners) is <see cref="WordFilterVerdict.Characters"/>.</item>
    /// <item>The trimmed length, in UTF-16 code units, must be within the rules' bounds, else
    /// <see cref="WordFilterVerdict.Length"/>.</item>
    /// <item>Control, zero-width, invisible-operator, direction, and blank filler characters are refused
    /// (<see cref="WordFilterVerdict.Characters"/>). U+200C and U+200D, which emoji sequences use, are allowed.</item>
    /// <item>Each character is spelled as lowercase ASCII (styled ranges by arithmetic, then a fold table; never
    /// culture-dependent lowering) in three leet passes: <c>1</c> and <c>|</c> read as i, then as l, then as i again
    /// with every lowercase l read as i too. Anything that spells as nothing (punctuation, emoji, unpaired surrogates)
    /// splits tokens.</item>
    /// <item>A token found in <see cref="WordList.Allow"/> on any pass is dropped from every pass.</item>
    /// <item>A <see cref="WordList.Word"/> entry matching a whole token, or an <see cref="WordList.Anywhere"/> entry
    /// inside the tokens joined, on any pass, is <see cref="WordFilterVerdict.Word"/>. Each run of a repeated letter in
    /// an entry matches one or more of that letter, so "ass" also matches "aasss".</item>
    /// <item>With <see cref="WordFilterRules.CheckReserved"/>, the joined tokens containing a
    /// <see cref="WordList.Reserved"/> entry on any pass is <see cref="WordFilterVerdict.Reserved"/>. A word hit
    /// always wins over a reserved hit.</item>
    /// </list>
    /// <para>Treat a client-side check as advice to the player; anything that matters should be checked again where
    /// the text is stored.</para>
    /// </remarks>
    public sealed partial class WordFilter {

        // The lookups derived from the tables (s_fold, s_rangeFirst, ...) are declared in WordFilter.Tables.cs, after
        // the tables: static initializers only run in textual order within one file, never across partial files.

        private readonly Regex? _word;
        private readonly Regex? _anywhere;
        private readonly HashSet<string> _allow;
        private readonly string[] _reserved;

        /// <summary>The list this filter matches against.</summary>
        public WordList List { get; }

        /// <summary>Builds a filter over <paramref name="list"/>, compiling each tier once.</summary>
        public WordFilter(WordList list) {
            List = list;
            _word = Compile(list.Word, wholeToken: true);
            _anywhere = Compile(list.Anywhere, wholeToken: false);
            _allow = new HashSet<string>(list.Allow, StringComparer.Ordinal);
            _reserved = list.Reserved.ToArray();
        }

        /// <summary>Checks <paramref name="text"/> under <paramref name="rules"/>; null reads as empty.</summary>
        /// <returns>The first rule the text fails, or <see cref="WordFilterVerdict.Ok"/>.</returns>
        public WordFilterVerdict Check(string? text, WordFilterRules rules) {
            string s = TrimSpaces(text ?? string.Empty);
            if (s.Length > 0 && IsAllBlank(s))
                return WordFilterVerdict.Characters;
            if (s.Length < rules.MinLength || s.Length > rules.MaxLength)
                return WordFilterVerdict.Length;
            foreach (char c in s) {
                if (IsRefusedChar(c))
                    return WordFilterVerdict.Characters;
            }

            List<string>[] spelled = new List<string>[OneReads.Length];
            for (int p = 0; p < spelled.Length; p++)
                spelled[p] = Tokens(s, p);

            List<string>[] passes = DropAllowed(spelled);
            foreach (List<string> pass in passes) {
                if (HitsWord(pass))
                    return WordFilterVerdict.Word;
            }
            if (rules.CheckReserved) {
                foreach (List<string> pass in passes) {
                    if (HitsReserved(string.Concat(pass)))
                        return WordFilterVerdict.Reserved;
                }
            }
            return WordFilterVerdict.Ok;
        }

        /// <summary>Shorthand for <c>Check(text, rules) == WordFilterVerdict.Ok</c>.</summary>
        public bool IsAllowed(string? text, WordFilterRules rules) => Check(text, rules) == WordFilterVerdict.Ok;

        #region Rules

        // Only U+0020, from both ends.
        private static string TrimSpaces(string s) {
            int start = 0;
            int end = s.Length;
            while (start < end && s[start] == ' ')
                start++;
            while (end > start && s[end - 1] == ' ')
                end--;
            return s.Substring(start, end - start);
        }

        // Every character a Unicode space separator, a zero-width space, or a joiner: the text would show as nothing.
        private static bool IsAllBlank(string s) {
            foreach (char c in s) {
                bool blank = c == ' ' || c == ' ' || c == ' ' || (c >= ' ' && c <= '‍')
                    || c == ' ' || c == ' ' || c == '　';
                if (!blank)
                    return false;
            }
            return true;
        }

        // C0 and C1 controls, DEL, the zero-width, invisible-operator, direction-mark and direction-override
        // characters, and the fillers that render blank (Hangul, Mongolian vowel separator, the empty Braille pattern).
        private static bool IsRefusedChar(char c) {
            return c <= '\u001F' || (c >= '\u007F' && c <= '\u009F') || c == '​' || c == '‎' || c == '‏'
                || (c >= '‪' && c <= '‮') || (c >= '⁠' && c <= '⁤') || (c >= '⁦' && c <= '⁩')
                || c == '﻿' || c == 'ᅟ' || c == 'ᅠ' || c == 'ㅤ' || c == 'ﾠ' || c == '᠎'
                || c == '⠀';
        }

        // The passes' tokens line up (every pass spells the same characters as letters; only which letters differs),
        // so a token allowed on ANY pass is dropped from every pass: an allowed word containing an l stays allowed on
        // the pass that reads that l as i.
        private List<string>[] DropAllowed(List<string>[] spelled) {
            List<string>[] passes = new List<string>[spelled.Length];
            for (int p = 0; p < spelled.Length; p++)
                passes[p] = new List<string>();

            for (int k = 0; k < spelled[0].Count; k++) {
                bool allowed = false;
                for (int p = 0; p < spelled.Length && !allowed; p++)
                    allowed = _allow.Contains(spelled[p][k]);
                if (allowed)
                    continue;
                for (int p = 0; p < spelled.Length; p++)
                    passes[p].Add(spelled[p][k]);
            }
            return passes;
        }

        private bool HitsWord(List<string> tokens) {
            if (_word != null) {
                foreach (string token in tokens) {
                    if (_word.IsMatch(token))
                        return true;
                }
            }
            return _anywhere != null && _anywhere.IsMatch(string.Concat(tokens));
        }

        private bool HitsReserved(string joined) {
            foreach (string reserved in _reserved) {
                if (joined.IndexOf(reserved, StringComparison.Ordinal) >= 0)
                    return true;
            }
            return false;
        }

        // One alternation per tier (any entry matching is the same as the alternation matching); null for an empty tier.
        private static Regex? Compile(IReadOnlyList<string> entries, bool wholeToken) {
            if (entries.Count == 0)
                return null;
            string alternation = string.Join("|", entries.Select(Pattern));
            string pattern = wholeToken ? "^(?:" + alternation + ")$" : alternation;
            return new Regex(pattern, RegexOptions.CultureInvariant);
        }

        // Each run of one letter becomes that run then `+`: "bad" is b+a+d+, "ass" is a+ss+.
        private static string Pattern(string entry) {
            StringBuilder pattern = new StringBuilder();
            int i = 0;
            while (i < entry.Length) {
                int j = i;
                while (j < entry.Length && entry[j] == entry[i])
                    j++;
                pattern.Append(entry, i, j - i).Append('+');
                i = j;
            }
            return pattern.ToString();
        }

        #endregion Rules

        #region Spelling

        // The text as lowercase a to z tokens for one leet pass. A surrogate pair is one code point; an unpaired
        // surrogate is a separator.
        private static List<string> Tokens(string s, int pass) {
            List<string> tokens = new List<string>();
            StringBuilder token = new StringBuilder();
            for (int i = 0; i < s.Length; i++) {
                int cp = s[i];
                if (char.IsHighSurrogate(s[i]) && i + 1 < s.Length && char.IsLowSurrogate(s[i + 1])) {
                    cp = char.ConvertToUtf32(s[i], s[i + 1]);
                    i++;
                }
                string spelled = Spell(cp, pass);
                if (spelled.Length > 0) {
                    token.Append(spelled);
                    continue;
                }
                PushToken(tokens, token);
            }
            PushToken(tokens, token);
            return tokens;
        }

        private static void PushToken(List<string> tokens, StringBuilder token) {
            if (token.Length == 0)
                return;
            tokens.Add(token.ToString());
            token.Clear();
        }

        // One code point as lowercase ASCII letters, or "" for a separator.
        private static string Spell(int cp, int pass) {
            const int FullwidthFirst = 0xFF01;
            const int FullwidthLast = 0xFF5E;
            const int FullwidthOffset = 0xFEE0;
            const int AsciiEnd = 0x80;

            cp = cp >= FullwidthFirst && cp <= FullwidthLast ? cp - FullwidthOffset : RangeFold(cp);
            if (cp < AsciiEnd) {
                char c = (char)cp;
                if (c == 'l')
                    return LReads[pass].ToString();
                if (c >= 'A' && c <= 'Z')
                    return ((char)(c + ('a' - 'A'))).ToString();
                if (c >= 'a' && c <= 'z')
                    return c.ToString();
                int leet = LeetFrom.IndexOf(c);
                if (leet >= 0)
                    return LeetTo[leet].ToString();
                if (c == '1' || c == '|')
                    return OneReads[pass].ToString();
                return string.Empty;
            }
            if (cp > char.MaxValue)
                return string.Empty;
            return s_fold.TryGetValue((char)cp, out string? folded) ? folded : string.Empty;
        }

        // The ASCII code a styled or enclosed character reads as, or the code point unchanged.
        private static int RangeFold(int cp) {
            for (int i = 0; i < s_rangeFirst.Length; i++) {
                if (cp >= s_rangeFirst[i] && cp <= s_rangeLast[i]) {
                    string alphabet = s_rangeAlphabet[i];
                    return alphabet[(cp - s_rangeFirst[i]) % alphabet.Length];
                }
            }
            return cp;
        }

        // Throws on a character folded twice (Dictionary.Add), so a broken table fails loudly at type load.
        private static Dictionary<char, string> BuildFold() {
            Dictionary<char, string> fold = new Dictionary<char, string>();
            for (int f = 0; f < FoldPairs.Length; f += 2) {
                foreach (char c in FoldPairs[f + 1])
                    fold.Add(c, FoldPairs[f]);
            }
            return fold;
        }

        private static IEnumerable<string> RangeColumn(int column) => RangeRows.Select(row => row.Split(' ')[column]);

        #endregion Spelling
    }
}
