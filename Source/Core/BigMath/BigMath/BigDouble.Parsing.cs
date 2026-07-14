using System;
using System.Globalization;

namespace BeeneticToolkit.BigMath {

    // Parsing. Accepts scientific/plain forms ("1.5e12", "-0.001", "12345"), the special words
    // ("NaN", "Infinity", "-Infinity"), and the built-in standard-abbreviated suffixes ("1.50M", "1.00aa").
    // A trailing letter marks the standard form; a trailing digit marks scientific/plain. All invariant-culture.
    public readonly partial struct BigDouble {

        private const NumberStyles NumberStyle = NumberStyles.Float;

        /// <summary>
        /// Parses a <see cref="BigDouble"/> from its string form. Accepts scientific/plain numbers, the words
        /// <c>NaN</c>/<c>Infinity</c>/<c>-Infinity</c>, and the built-in standard-abbreviated notation
        /// (<c>K/M/B/T</c> and the letter suffixes). Custom suffix providers are not parsed here.
        /// </summary>
        /// <exception cref="FormatException"><paramref name="s"/> is not a recognized <see cref="BigDouble"/>.</exception>
        public static BigDouble Parse(string s) {
            if (!TryParse(s, out BigDouble result)) {
                throw new FormatException($"'{s}' is not a valid {nameof(BigDouble)}.");
            }
            return result;
        }

        /// <summary>Attempts to parse a <see cref="BigDouble"/>; returns <c>false</c> instead of throwing on failure.</summary>
        public static bool TryParse(string? s, out BigDouble result) {
            result = Zero;
            if (string.IsNullOrWhiteSpace(s)) return false;
            s = s!.Trim();

            switch (s) {
                case "NaN": result = NaN; return true;
                case "Infinity":
                case "+Infinity": result = PositiveInfinity; return true;
                case "-Infinity": result = NegativeInfinity; return true;
            }

            // A trailing letter means a standard-abbreviated suffix; anything else is scientific or plain.
            return char.IsLetter(s[s.Length - 1])
                ? TryParseStandard(s, out result)
                : TryParseScientific(s, out result);
        }

        private static bool TryParseScientific(string s, out BigDouble result) {
            result = Zero;
            int eIndex = s.IndexOfAny(new[] { 'e', 'E' });
            if (eIndex < 0) {
                if (double.TryParse(s, NumberStyle, CultureInfo.InvariantCulture, out double plain)) {
                    result = FromDouble(plain);
                    return true;
                }
                return false;
            }

            string mantissaPart = s.Substring(0, eIndex);
            string exponentPart = s.Substring(eIndex + 1);
            if (double.TryParse(mantissaPart, NumberStyle, CultureInfo.InvariantCulture, out double mantissa)
                && double.TryParse(exponentPart, NumberStyle, CultureInfo.InvariantCulture, out double exponent)) {
                result = new BigDouble(mantissa, exponent);
                return true;
            }
            return false;
        }

        private static bool TryParseStandard(string s, out BigDouble result) {
            result = Zero;

            int split = s.Length;
            while (split > 0 && char.IsLetter(s[split - 1])) split--;
            string numberPart = s.Substring(0, split);
            string suffix = s.Substring(split);

            if (!double.TryParse(numberPart, NumberStyle, CultureInfo.InvariantCulture, out double number)) return false;
            if (!TryGetTierForSuffix(suffix, out long tier)) return false;

            result = new BigDouble(number, tier * 3.0);
            return true;
        }

        /// <summary>Inverse of <see cref="DefaultSuffixProvider"/>: maps a built-in suffix back to its magnitude tier.</summary>
        private static bool TryGetTierForSuffix(string suffix, out long tier) {
            tier = 0;
            switch (suffix) {
                case "K": tier = 1; return true;
                case "M": tier = 2; return true;
                case "B": tier = 3; return true;
                case "T": tier = 4; return true;
            }

            // Letter sequence: two or more lowercase letters, base-26 with 'a' == 0.
            if (suffix.Length < 2) return false;
            long index = 0;
            foreach (char c in suffix) {
                if (c < 'a' || c > 'z') return false;
                index = index * 26 + (c - 'a');
            }

            // Offset past every shorter letter block (26^2 two-letter combos, 26^3 three-letter, ...).
            long offset = 0;
            long block = 26L * 26L;
            for (int length = 2; length < suffix.Length; length++) {
                offset += block;
                block *= 26L;
            }

            tier = 5 + offset + index;
            return true;
        }
    }
}
