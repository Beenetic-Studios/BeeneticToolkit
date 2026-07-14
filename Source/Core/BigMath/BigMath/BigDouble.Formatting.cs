using System;
using System.Globalization;

namespace BeeneticToolkit.BigMath {

    // Formatting: ToString overloads plus IFormattable. Display uses the pluggable notation system; the "R"
    // format is the round-trippable canonical form consumed by Parse. All formatting is invariant-culture.
    public readonly partial struct BigDouble : IFormattable {

        /// <summary>Default number of fractional digits used by <see cref="ToString()"/>.</summary>
        public const int DefaultDecimals = 2;

        /// <summary>Formats using <see cref="Notation.Default"/> and <see cref="DefaultDecimals"/>.</summary>
        public override string ToString() => Notation.Default.Format(this, DefaultDecimals);

        /// <summary>Formats using the given notation and number of decimals.</summary>
        public string ToString(INotation notation, int decimals = DefaultDecimals) {
            if (notation is null) throw new ArgumentNullException(nameof(notation));
            return notation.Format(this, decimals);
        }

        /// <summary>
        /// Implements <see cref="IFormattable"/>. Recognized formats (each optionally followed by a digit count,
        /// e.g. <c>"S3"</c>): <c>"S"</c> scientific, <c>"G"</c> engineering, <c>"A"</c>/<c>"D"</c> standard
        /// abbreviated, <c>"R"</c> round-trippable. A null/empty format uses <see cref="Notation.Default"/>.
        /// </summary>
        /// <exception cref="FormatException">The format specifier is not recognized.</exception>
        public string ToString(string? format, IFormatProvider? formatProvider) {
            if (string.IsNullOrEmpty(format)) {
                return Notation.Default.Format(this, DefaultDecimals);
            }

            char specifier = char.ToUpperInvariant(format![0]);
            int decimals = DefaultDecimals;
            if (format.Length > 1 && int.TryParse(format.Substring(1), NumberStyles.Integer, CultureInfo.InvariantCulture, out int parsed)) {
                decimals = parsed;
            }

            switch (specifier) {
                case 'S': return Notation.Scientific.Format(this, decimals);
                case 'G': return Notation.Engineering.Format(this, decimals);
                case 'A':
                case 'D': return Notation.Standard.Format(this, decimals);
                case 'R': return ToRoundTripString();
                default:
                    throw new FormatException($"The '{format}' format specifier is not supported for {nameof(BigDouble)}.");
            }
        }

        /// <summary>
        /// The round-trippable canonical form: full-precision mantissa, an <c>e</c>, and the exponent, all in
        /// invariant culture. Guarantees <c>Parse(x.ToString("R")) == x</c> for finite values.
        /// </summary>
        private string ToRoundTripString() {
            if (IsNaN) return "NaN";
            if (IsInfinity) return Sign < 0 ? "-Infinity" : "Infinity";
            return Mantissa.ToString("R", CultureInfo.InvariantCulture)
                + "e" + Exponent.ToString("R", CultureInfo.InvariantCulture);
        }
    }
}
