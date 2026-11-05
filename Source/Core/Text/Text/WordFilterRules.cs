using System;

namespace BeeneticToolkit.Text {

    /// <summary>
    /// The per-field rules a text is checked under: its length bounds and whether reserved entries apply. A display
    /// name and a free-text status usually differ (a name is short and must not impersonate staff; a status is longer
    /// and may mention anything that is not a bad word), so build one of these per kind of text.
    /// </summary>
    public sealed class WordFilterRules {

        /// <summary>No length limits and no reserved check: the character and word tiers only.</summary>
        public static WordFilterRules WordsOnly { get; } = new WordFilterRules(0, int.MaxValue, false);

        /// <summary>The shortest allowed text, in UTF-16 code units after trimming spaces.</summary>
        public int MinLength { get; }

        /// <summary>The longest allowed text, in UTF-16 code units after trimming spaces.</summary>
        public int MaxLength { get; }

        /// <summary>Whether the text must also avoid every <see cref="WordList.Reserved"/> entry.</summary>
        public bool CheckReserved { get; }

        /// <summary>Creates a rule set.</summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="minLength"/> is negative or above <paramref name="maxLength"/>.</exception>
        public WordFilterRules(int minLength, int maxLength, bool checkReserved) {
            if (minLength < 0)
                throw new ArgumentOutOfRangeException(nameof(minLength), minLength, "Minimum length cannot be negative.");
            if (maxLength < minLength)
                throw new ArgumentOutOfRangeException(nameof(maxLength), maxLength, "Maximum length cannot be below the minimum.");

            MinLength = minLength;
            MaxLength = maxLength;
            CheckReserved = checkReserved;
        }
    }

    /// <summary>The first rule a text fails, in the order <see cref="WordFilter.Check"/> applies them, or <see cref="Ok"/>.</summary>
    public enum WordFilterVerdict {

        /// <summary>The text passes every rule.</summary>
        Ok,

        /// <summary>The trimmed text is shorter or longer than the rules allow.</summary>
        Length,

        /// <summary>The text is blank, or holds a control, zero-width, filler, or direction character.</summary>
        Characters,

        /// <summary>The text matches an anywhere or word entry.</summary>
        Word,

        /// <summary>The text contains a reserved entry (only when <see cref="WordFilterRules.CheckReserved"/> is on).</summary>
        Reserved,
    }
}
