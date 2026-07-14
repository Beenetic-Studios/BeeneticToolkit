using System;

namespace BeeneticToolkit.BigMath {

    // Comparison, equality, and the ordering/relational operators. Equality is exact on the normalized form;
    // NaN follows IEEE rules for operators (never equal) but the double-style Equals treats NaN as equal to NaN.
    public readonly partial struct BigDouble {

        /// <summary>Compares this value to another. NaN sorts below every other value and equal to itself.</summary>
        public int CompareTo(BigDouble other) {
            if (IsNaN) return other.IsNaN ? 0 : -1;
            if (other.IsNaN) return 1;

            int signA = Sign, signB = other.Sign;
            if (signA != signB) return signA.CompareTo(signB);
            if (signA == 0) return 0; // both zero

            if (IsInfinity && other.IsInfinity) return 0;
            if (IsInfinity) return signA;   // this is +/-inf, larger magnitude than any finite value
            if (other.IsInfinity) return -signB;

            // Both finite and non-zero with the same sign: order by magnitude, then flip for negatives.
            int magnitude;
            if (Exponent != other.Exponent) {
                magnitude = Exponent < other.Exponent ? -1 : 1;
            } else {
                magnitude = Math.Abs(Mantissa).CompareTo(Math.Abs(other.Mantissa));
            }
            return signA > 0 ? magnitude : -magnitude;
        }

        /// <inheritdoc/>
        public int CompareTo(object? obj) {
            if (obj is null) return 1;
            if (obj is BigDouble other) return CompareTo(other);
            throw new ArgumentException($"Object must be of type {nameof(BigDouble)}.", nameof(obj));
        }

        /// <summary>Determines exact equality on the normalized form. Two NaNs are considered equal (matching <see cref="double.Equals(double)"/>).</summary>
        public bool Equals(BigDouble other) {
            if (IsNaN) return other.IsNaN;
            if (other.IsNaN) return false;
            return Mantissa == other.Mantissa && Exponent == other.Exponent;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is BigDouble other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() {
            if (IsNaN) return 0;
            return HashCode.Combine(Mantissa, Exponent);
        }

        /// <summary>
        /// Determines whether this value is within <paramref name="relativeTolerance"/> (relative) of
        /// <paramref name="other"/>. Useful for game logic and tests where exact <see cref="Equals(BigDouble)"/>
        /// is too strict because of floating-point drift in the mantissa.
        /// </summary>
        public bool EqualsApproximately(BigDouble other, double relativeTolerance = 1e-9) {
            if (IsNaN || other.IsNaN) return false;
            if (IsInfinity || other.IsInfinity) return Equals(other);
            if (Equals(other)) return true;

            BigDouble difference = (this - other).Abs();
            BigDouble scale = Max(Abs(), other.Abs());
            if (scale.IsZero) return true; // both zero
            return (difference / scale) <= FromDouble(relativeTolerance);
        }

        /// <summary>Returns the smaller of two values (or <see cref="NaN"/> if either is NaN).</summary>
        public static BigDouble Min(BigDouble a, BigDouble b) => a.IsNaN || b.IsNaN ? NaN : (a <= b ? a : b);

        /// <summary>Returns the larger of two values (or <see cref="NaN"/> if either is NaN).</summary>
        public static BigDouble Max(BigDouble a, BigDouble b) => a.IsNaN || b.IsNaN ? NaN : (a >= b ? a : b);

        /// <summary>Clamps <paramref name="value"/> to the inclusive range [<paramref name="min"/>, <paramref name="max"/>].</summary>
        public static BigDouble Clamp(BigDouble value, BigDouble min, BigDouble max) => Max(min, Min(value, max));

        /// <summary>Equality operator (IEEE semantics: NaN is not equal to anything, including itself).</summary>
        public static bool operator ==(BigDouble a, BigDouble b) {
            if (a.IsNaN || b.IsNaN) return false;
            return a.Mantissa == b.Mantissa && a.Exponent == b.Exponent;
        }

        /// <summary>Inequality operator.</summary>
        public static bool operator !=(BigDouble a, BigDouble b) => !(a == b);

        /// <summary>Less-than operator (false if either operand is NaN).</summary>
        public static bool operator <(BigDouble a, BigDouble b) => !a.IsNaN && !b.IsNaN && a.CompareTo(b) < 0;

        /// <summary>Greater-than operator (false if either operand is NaN).</summary>
        public static bool operator >(BigDouble a, BigDouble b) => !a.IsNaN && !b.IsNaN && a.CompareTo(b) > 0;

        /// <summary>Less-than-or-equal operator (false if either operand is NaN).</summary>
        public static bool operator <=(BigDouble a, BigDouble b) => !a.IsNaN && !b.IsNaN && a.CompareTo(b) <= 0;

        /// <summary>Greater-than-or-equal operator (false if either operand is NaN).</summary>
        public static bool operator >=(BigDouble a, BigDouble b) => !a.IsNaN && !b.IsNaN && a.CompareTo(b) >= 0;
    }
}
