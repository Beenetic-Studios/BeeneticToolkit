using System;

namespace BeeneticToolkit.BigMath {

    // Core arithmetic: + - * / and the unary/sign-shaping helpers. Multiply/divide add/subtract exponents;
    // addition short-circuits when one operand is negligibly small relative to the other.
    public readonly partial struct BigDouble {

        /// <summary>Returns the absolute value.</summary>
        public BigDouble Abs() {
            if (IsNaN) return NaN;
            if (IsZero) return Zero;
            return new BigDouble(Math.Abs(Mantissa), Exponent);
        }

        /// <summary>Returns the negation of this value.</summary>
        public BigDouble Negate() {
            if (IsNaN) return NaN;
            if (IsZero) return Zero;
            return new BigDouble(-Mantissa, Exponent);
        }

        /// <summary>Returns <c>1 / this</c>.</summary>
        public BigDouble Reciprocal() => One / this;

        /// <summary>Unary negation.</summary>
        public static BigDouble operator -(BigDouble value) => value.Negate();

        /// <summary>Addition.</summary>
        public static BigDouble operator +(BigDouble a, BigDouble b) {
            if (a.IsNaN || b.IsNaN) return NaN;
            if (a.IsInfinity || b.IsInfinity) {
                if (a.IsInfinity && b.IsInfinity) {
                    return (a.Mantissa > 0.0) == (b.Mantissa > 0.0) ? a : NaN; // (+inf) + (-inf) is indeterminate
                }
                return a.IsInfinity ? a : b;
            }
            if (a.IsZero) return b;
            if (b.IsZero) return a;

            // Order operands so 'big' has the larger exponent, then short-circuit if 'small' cannot register.
            BigDouble big = a.Exponent >= b.Exponent ? a : b;
            BigDouble small = a.Exponent >= b.Exponent ? b : a;
            double expDiff = big.Exponent - small.Exponent;
            if (expDiff > MaxSignificantDigits) return big;

            // Align 'small' onto 'big's exponent (a non-positive power of ten) and add the mantissas.
            double alignedSmall = small.Mantissa * Math.Pow(10.0, small.Exponent - big.Exponent);
            return new BigDouble(big.Mantissa + alignedSmall, big.Exponent);
        }

        /// <summary>Subtraction.</summary>
        public static BigDouble operator -(BigDouble a, BigDouble b) => a + b.Negate();

        /// <summary>Multiplication.</summary>
        public static BigDouble operator *(BigDouble a, BigDouble b) {
            if (a.IsNaN || b.IsNaN) return NaN;
            if (a.IsInfinity || b.IsInfinity) {
                if (a.IsZero || b.IsZero) return NaN; // 0 * inf is indeterminate
                return a.Sign * b.Sign < 0 ? NegativeInfinity : PositiveInfinity;
            }
            if (a.IsZero || b.IsZero) return Zero;
            return new BigDouble(a.Mantissa * b.Mantissa, a.Exponent + b.Exponent);
        }

        /// <summary>Division.</summary>
        public static BigDouble operator /(BigDouble a, BigDouble b) {
            if (a.IsNaN || b.IsNaN) return NaN;
            if (a.IsInfinity) {
                if (b.IsInfinity) return NaN; // inf / inf is indeterminate
                return a.Sign * b.Sign < 0 ? NegativeInfinity : PositiveInfinity;
            }
            if (b.IsInfinity) return Zero;
            if (b.IsZero) {
                if (a.IsZero) return NaN; // 0 / 0 is indeterminate
                return a.Sign < 0 ? NegativeInfinity : PositiveInfinity;
            }
            if (a.IsZero) return Zero;
            return new BigDouble(a.Mantissa / b.Mantissa, a.Exponent - b.Exponent);
        }
    }
}
