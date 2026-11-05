using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Text {

    /// <summary>
    /// The tiered word list a <see cref="WordFilter"/> matches against, as data. Every entry is lowercase <c>a</c> to
    /// <c>z</c> only; the filter folds lookalikes, leet, and repeated letters onto that spelling itself.
    /// </summary>
    /// <remarks>
    /// The toolkit ships no list. Load yours from wherever it lives (a resource, a file, a server) and build one of
    /// these; a public list such as LDNOOBW carries its own licence and attribution terms.
    /// </remarks>
    public sealed class WordList {

        /// <summary>A list with every tier empty: only the length and character rules apply.</summary>
        public static WordList Empty { get; } = new WordList(
            Array.Empty<string>(), Array.Empty<string>(), Array.Empty<string>(), Array.Empty<string>());

        /// <summary>Entries matched anywhere in the text, across word breaks ("xxbadxx", "b a d").</summary>
        public IReadOnlyList<string> Anywhere { get; }

        /// <summary>Entries matched only as a whole word, so a short entry does not catch longer innocent words.</summary>
        public IReadOnlyList<string> Word { get; }

        /// <summary>Whole words that are always fine, even when they contain an entry ("Scunthorpe" cases).</summary>
        public IReadOnlyList<string> Allow { get; }

        /// <summary>
        /// Entries a reserved-checked text must not contain anywhere (staff titles, the game's own name). Checked only
        /// when <see cref="WordFilterRules.CheckReserved"/> is on, and only after the text passes the word tiers.
        /// </summary>
        public IReadOnlyList<string> Reserved { get; }

        /// <summary>Creates a list from its four tiers. The tiers are copied.</summary>
        /// <exception cref="ArgumentException">An entry is null, empty, or not lowercase a to z.</exception>
        public WordList(IEnumerable<string> anywhere, IEnumerable<string> word, IEnumerable<string> allow, IEnumerable<string> reserved) {
            Anywhere = Checked(anywhere, nameof(anywhere));
            Word = Checked(word, nameof(word));
            Allow = Checked(allow, nameof(allow));
            Reserved = Checked(reserved, nameof(reserved));
        }

        private static string[] Checked(IEnumerable<string> entries, string tier) {
            string[] copy = entries.ToArray();
            for (int i = 0; i < copy.Length; i++) {
                if (!IsEntry(copy[i]))
                    throw new ArgumentException($"{tier} entry {i} (\"{copy[i]}\") is not lowercase a to z.", tier);
            }
            return copy;
        }

        private static bool IsEntry(string? entry) {
            if (string.IsNullOrEmpty(entry))
                return false;
            foreach (char c in entry) {
                if (c < 'a' || c > 'z')
                    return false;
            }
            return true;
        }
    }
}
