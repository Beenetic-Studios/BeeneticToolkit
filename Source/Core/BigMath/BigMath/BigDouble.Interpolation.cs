using System;

namespace BeeneticToolkit.BigMath {

    // Interpolation helpers, mirroring MathKit's Lerp/LerpUnclamped/InverseLerp conventions but for BigDouble.
    // These live here (rather than as MathKit overloads) so BigMath and Numerics stay independent packages.
    // The factor is a plain double, so 0..1 easing outputs from EasingUtils feed straight in.
    public readonly partial struct BigDouble {

        /// <summary>
        /// Linearly interpolates from <paramref name="start"/> to <paramref name="end"/> by
        /// <paramref name="factor"/>, clamping the factor to the range [0, 1].
        /// </summary>
        public static BigDouble Lerp(BigDouble start, BigDouble end, double factor) {
            factor = factor < 0.0 ? 0.0 : factor > 1.0 ? 1.0 : factor;
            return LerpUnclamped(start, end, factor);
        }

        /// <summary>
        /// Linearly interpolates from <paramref name="start"/> to <paramref name="end"/> without clamping the
        /// factor, allowing extrapolation beyond the endpoints.
        /// </summary>
        public static BigDouble LerpUnclamped(BigDouble start, BigDouble end, double factor) {
            return start + (end - start) * factor;
        }

        /// <summary>
        /// Calculates the interpolation factor of <paramref name="value"/> within the range
        /// [<paramref name="min"/>, <paramref name="max"/>], returned as a <see cref="double"/>.
        /// </summary>
        /// <exception cref="DivideByZeroException"><paramref name="min"/> equals <paramref name="max"/>.</exception>
        public static double InverseLerp(BigDouble value, BigDouble min, BigDouble max) {
            if (min == max) {
                throw new DivideByZeroException("Lerp range cannot be zero (min and max are equal).");
            }
            return ((value - min) / (max - min)).ToDouble();
        }
    }
}
