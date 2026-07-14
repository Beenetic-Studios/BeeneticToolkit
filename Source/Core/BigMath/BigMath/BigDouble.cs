using System;

namespace BeeneticToolkit.BigMath {

    /// <summary>
    /// A large-magnitude floating-point value stored as a normalized mantissa multiplied by a power of ten
    /// (<c>Mantissa &#215; 10^Exponent</c>). Reaches far beyond <see cref="double"/>'s ~1.8e308 ceiling, which
    /// makes it a natural fit for incremental/idle games and long-running simulations that display values like
    /// <c>1.50M</c>, <c>3.24B</c>, or <c>9.99e1234</c>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The exponent is a <see cref="double"/> capped at <see cref="ExponentLimit"/> (just under 2^53) so it always
    /// holds an <em>exact</em> integer, matching the representation popularized by <c>break_infinity.js</c>. This
    /// trades an astronomically high ceiling for exactness and lets exponent arithmetic saturate to infinity via
    /// IEEE rules instead of silently wrapping. Tetration-scale magnitudes (10&#8593;&#8593;n) are out of scope.
    /// </para>
    /// <para>
    /// The type is a normalized, immutable value: every operation re-establishes the invariant that either the
    /// value is canonical zero (<c>Mantissa == 0 &amp;&amp; Exponent == 0</c>) or <c>1 &lt;= |Mantissa| &lt; 10</c>
    /// with an integer-valued <see cref="Exponent"/>. The sign is carried on <see cref="Mantissa"/>.
    /// Implementation is split across several files (arithmetic, comparison, math) but is a single struct.
    /// </para>
    /// </remarks>
    public readonly partial struct BigDouble : IEquatable<BigDouble>, IComparable<BigDouble>, IComparable {

        /// <summary>
        /// Largest permitted magnitude of <see cref="Exponent"/>. Chosen just below 2^53 so the exponent, though
        /// stored as a <see cref="double"/>, is always an exact integer. Exponents beyond this saturate to
        /// infinity (positive) or zero (negative).
        /// </summary>
        public const double ExponentLimit = 9e15;

        /// <summary>
        /// Number of significant decimal digits a <see cref="double"/> mantissa can carry. Used as the addition
        /// short-circuit threshold: operands whose exponents differ by more than this cannot affect each other.
        /// </summary>
        internal const double MaxSignificantDigits = 17.0;

        /// <summary>The normalized mantissa: <c>0</c> for zero, otherwise <c>1 &lt;= |Mantissa| &lt; 10</c>. Sign lives here.</summary>
        public double Mantissa { get; }

        /// <summary>The base-10 exponent: an integer-valued <see cref="double"/> with <c>|Exponent| &lt;= </c><see cref="ExponentLimit"/>.</summary>
        public double Exponent { get; }

        /// <summary>Internal constructor for values already known to satisfy the representation invariant.</summary>
        private BigDouble(double mantissa, double exponent, bool alreadyNormalized) {
            Mantissa = mantissa;
            Exponent = exponent;
        }

        /// <summary>
        /// Constructs a value equal to <paramref name="mantissa"/> &#215; 10^<paramref name="exponent"/>,
        /// normalizing the result. Any fractional part of <paramref name="exponent"/> is folded into the mantissa,
        /// and the exponent is clamped to <see cref="ExponentLimit"/> (saturating to infinity or zero).
        /// </summary>
        public BigDouble(double mantissa, double exponent) {
            BigDouble n = Normalize(mantissa, exponent);
            Mantissa = n.Mantissa;
            Exponent = n.Exponent;
        }

        #region Constants

        /// <summary>The value zero, in canonical form <c>(0, 0)</c>.</summary>
        public static readonly BigDouble Zero = new BigDouble(0.0, 0.0, true);

        /// <summary>The value one.</summary>
        public static readonly BigDouble One = new BigDouble(1.0, 0.0, true);

        /// <summary>The value ten.</summary>
        public static readonly BigDouble Ten = new BigDouble(1.0, 1.0, true);

        /// <summary>Not-a-number, arising from indeterminate forms such as <c>0/0</c> or <c>&#8734; - &#8734;</c>.</summary>
        public static readonly BigDouble NaN = new BigDouble(double.NaN, 0.0, true);

        /// <summary>Positive infinity (overflow past <see cref="MaxValue"/>, or division of a positive by zero).</summary>
        public static readonly BigDouble PositiveInfinity = new BigDouble(double.PositiveInfinity, 0.0, true);

        /// <summary>Negative infinity.</summary>
        public static readonly BigDouble NegativeInfinity = new BigDouble(double.NegativeInfinity, 0.0, true);

        /// <summary>The largest finite representable value, at the exponent ceiling.</summary>
        public static readonly BigDouble MaxValue = new BigDouble(9.999999999999998, ExponentLimit, true);

        /// <summary>The most negative finite representable value.</summary>
        public static readonly BigDouble MinValue = new BigDouble(-9.999999999999998, ExponentLimit, true);

        /// <summary>The smallest positive representable value, at the negative exponent floor.</summary>
        public static readonly BigDouble Epsilon = new BigDouble(1.0, -ExponentLimit, true);

        #endregion

        #region State properties

        /// <summary>The sign of the value: <c>-1</c>, <c>0</c>, or <c>1</c> (and <c>0</c> for <see cref="NaN"/>).</summary>
        public int Sign => IsNaN || IsZero ? 0 : Math.Sign(Mantissa);

        /// <summary><c>true</c> if this value is exactly zero.</summary>
        public bool IsZero => Mantissa == 0.0 && !IsNaN;

        /// <summary><c>true</c> if this value is Not-a-Number.</summary>
        public bool IsNaN => double.IsNaN(Mantissa);

        /// <summary><c>true</c> if this value is positive or negative infinity.</summary>
        public bool IsInfinity => double.IsInfinity(Mantissa);

        /// <summary><c>true</c> if this value is neither infinite nor NaN.</summary>
        public bool IsFinite => !IsNaN && !IsInfinity;

        #endregion

        #region Construction &amp; conversion

        /// <summary>Creates a <see cref="BigDouble"/> from a <see cref="double"/>, handling zero, negatives, NaN, and infinities.</summary>
        public static BigDouble FromDouble(double value) {
            if (double.IsNaN(value)) return NaN;
            if (double.IsPositiveInfinity(value)) return PositiveInfinity;
            if (double.IsNegativeInfinity(value)) return NegativeInfinity;
            if (value == 0.0) return Zero;
            return Normalize(value, 0.0);
        }

        /// <summary>Converts this value to the nearest <see cref="double"/>, returning &#177;<see cref="double.PositiveInfinity"/> if it is out of range.</summary>
        public double ToDouble() {
            if (IsNaN) return double.NaN;
            if (IsInfinity) return Mantissa;
            if (IsZero) return 0.0;
            return Mantissa * Math.Pow(10.0, Exponent);
        }

        /// <summary>Widening conversion from <see cref="double"/> (lossless within range).</summary>
        public static implicit operator BigDouble(double value) => FromDouble(value);

        /// <summary>Widening conversion from <see cref="long"/>.</summary>
        public static implicit operator BigDouble(long value) => value == 0L ? Zero : Normalize(value, 0.0);

        /// <summary>Widening conversion from <see cref="int"/>.</summary>
        public static implicit operator BigDouble(int value) => value == 0 ? Zero : Normalize(value, 0.0);

        /// <summary>Narrowing conversion to <see cref="double"/>; may return &#177;infinity if out of range.</summary>
        public static explicit operator double(BigDouble value) => value.ToDouble();

        #endregion

        /// <summary>
        /// Re-establishes the representation invariant for an arbitrary (mantissa, exponent) pair: folds any
        /// fractional exponent into the mantissa, brings <c>|mantissa|</c> into <c>[1, 10)</c>, forces the
        /// exponent to an exact integer, and saturates past <see cref="ExponentLimit"/>.
        /// </summary>
        private static BigDouble Normalize(double mantissa, double exponent) {
            if (double.IsNaN(mantissa) || double.IsNaN(exponent)) return NaN;
            if (mantissa == 0.0) return Zero;
            if (double.IsInfinity(mantissa)) return mantissa > 0.0 ? PositiveInfinity : NegativeInfinity;
            if (double.IsInfinity(exponent)) {
                if (exponent > 0.0) return mantissa < 0.0 ? NegativeInfinity : PositiveInfinity;
                return Zero; // 10^(-inf) collapses to zero
            }

            // Fold any fractional part of the exponent into the mantissa so Exponent stays an exact integer.
            double intExponent = Math.Floor(exponent);
            double fraction = exponent - intExponent;
            if (fraction != 0.0) {
                mantissa *= Math.Pow(10.0, fraction);
            }
            exponent = intExponent;

            // Bring |mantissa| into [1, 10), moving the shift onto the exponent.
            double abs = Math.Abs(mantissa);
            if (abs < 1.0 || abs >= 10.0) {
                double shift = Math.Floor(Math.Log10(abs));
                mantissa /= Math.Pow(10.0, shift);
                exponent += shift;

                // Correct any residual left by floating-point error in the log/pow round-trip.
                abs = Math.Abs(mantissa);
                while (abs >= 10.0) { mantissa /= 10.0; exponent += 1.0; abs = Math.Abs(mantissa); }
                while (abs < 1.0) { mantissa *= 10.0; exponent -= 1.0; abs = Math.Abs(mantissa); }
            }

            if (exponent > ExponentLimit) return mantissa < 0.0 ? NegativeInfinity : PositiveInfinity;
            if (exponent < -ExponentLimit) return Zero;

            return new BigDouble(mantissa, exponent, true);
        }
    }
}
