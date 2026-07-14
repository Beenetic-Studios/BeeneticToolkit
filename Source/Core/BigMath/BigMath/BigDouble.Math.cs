using System;

namespace BeeneticToolkit.BigMath {

    // Powers, roots, logarithms, and rounding. Logs return plain doubles (a base-10 log of any BigDouble fits
    // comfortably). Powers lean on the identity x^p = 10^(p * log10 x), with Pow10 folding fractional exponents.
    public readonly partial struct BigDouble {

        private const double Log10OfE = 0.4342944819032518;   // log10(e)
        private const double LnOf10 = 2.302585092994046;       // ln(10)

        /// <summary>Returns the base-10 logarithm as a <see cref="double"/>. <c>Log10(0)</c> is <see cref="double.NegativeInfinity"/>; logs of negatives are NaN.</summary>
        public double Log10() {
            if (IsNaN) return double.NaN;
            if (IsZero) return double.NegativeInfinity;
            if (Sign < 0) return double.NaN;
            if (IsInfinity) return double.PositiveInfinity;
            return Exponent + Math.Log10(Mantissa);
        }

        /// <summary>Returns the natural logarithm as a <see cref="double"/>.</summary>
        public double Ln() => Log10() * LnOf10;

        /// <summary>Returns the logarithm in the given base as a <see cref="double"/>.</summary>
        public double Log(double @base) => Log10() / Math.Log10(@base);

        /// <summary>Returns <c>10^power</c>. Fractional powers are represented exactly by folding into the mantissa.</summary>
        public static BigDouble Pow10(double power) {
            if (double.IsNaN(power)) return NaN;
            if (double.IsPositiveInfinity(power)) return PositiveInfinity;
            if (double.IsNegativeInfinity(power)) return Zero;
            return new BigDouble(1.0, power);
        }

        /// <summary>Returns <c>e^power</c>.</summary>
        public static BigDouble Exp(double power) => Pow10(power * Log10OfE);

        /// <summary>Raises this value to a <see cref="double"/> power.</summary>
        public BigDouble Pow(double power) {
            if (IsNaN || double.IsNaN(power)) return NaN;
            if (power == 0.0) return One;   // x^0 == 1, including 0^0 by convention
            if (power == 1.0) return this;

            if (Sign < 0) {
                // Negative base: only integer powers are real; the parity of the power sets the result sign.
                if (!double.IsInfinity(power) && power == Math.Floor(power)) {
                    BigDouble magnitude = Abs().Pow(power);
                    return Math.Abs(power % 2.0) == 1.0 ? magnitude.Negate() : magnitude;
                }
                return NaN;
            }
            if (IsZero) return power > 0.0 ? Zero : PositiveInfinity; // 0^negative -> +inf
            if (IsInfinity) return power > 0.0 ? PositiveInfinity : Zero;

            return Pow10(Log10() * power);
        }

        /// <summary>Raises this value to a <see cref="BigDouble"/> power (the exponent is taken through <see cref="ToDouble"/>).</summary>
        public BigDouble Pow(BigDouble power) => Pow(power.ToDouble());

        /// <summary>Returns the square root; the square root of a negative value is <see cref="NaN"/>.</summary>
        public BigDouble Sqrt() {
            if (IsNaN) return NaN;
            if (Sign < 0) return NaN;
            if (IsZero) return Zero;
            if (IsInfinity) return PositiveInfinity;

            // Keep precision by halving an even exponent directly; for an odd exponent, borrow one order of
            // magnitude into the mantissa first so the remaining exponent halves cleanly.
            if (Math.Abs(Exponent % 2.0) == 1.0) {
                return new BigDouble(Math.Sqrt(Mantissa * 10.0), (Exponent - 1.0) / 2.0);
            }
            return new BigDouble(Math.Sqrt(Mantissa), Exponent / 2.0);
        }

        /// <summary>Returns the <paramref name="degree"/>-th root.</summary>
        public BigDouble Root(double degree) => degree == 2.0 ? Sqrt() : Pow(1.0 / degree);

        /// <summary>Returns the largest integral value less than or equal to this value.</summary>
        public BigDouble Floor() {
            if (!IsFinite || IsZero) return this;
            if (Exponent >= MaxSignificantDigits) return this; // no representable fractional part
            return FromDouble(Math.Floor(ToDouble()));
        }

        /// <summary>Returns the smallest integral value greater than or equal to this value.</summary>
        public BigDouble Ceiling() {
            if (!IsFinite || IsZero) return this;
            if (Exponent >= MaxSignificantDigits) return this;
            return FromDouble(Math.Ceiling(ToDouble()));
        }

        /// <summary>Rounds to the given number of fractional decimal digits (banker's rounding).</summary>
        public BigDouble Round(int digits = 0) {
            if (!IsFinite || IsZero) return this;
            if (Exponent >= MaxSignificantDigits) return this;
            return FromDouble(Math.Round(ToDouble(), digits));
        }
    }
}
