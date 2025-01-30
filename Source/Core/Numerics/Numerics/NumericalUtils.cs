using System;

namespace BeeneticToolkit.Numerics {

    /// <summary>
    /// Provides utility methods for common numerical operations, including clamping, normalization, and approximate comparisons.
    /// </summary>
    public static class NumericalUtils {

        #region Clamp

        /// <summary>
        /// Clamps a float value to ensure it falls within the range of 0 to 1.
        /// </summary>
        /// <example>
        /// <code>
        /// float normalizedValue = Clamp01(1.5f); // returns 1.0f
        /// float lowerBoundValue = Clamp01(-0.3f); // returns 0.0f
        /// </code>
        /// </example>
        /// <param name="value">The float value to be clamped.</param>
        /// <returns>The clamped float value.</returns>
        public static float Clamp01(float value) {
            return Math.Clamp(value, 0.0f, 1.0f);
        }

        /// <summary>
        /// Clamps a double value to ensure it falls within the range of 0 to 1.
        /// </summary>
        /// <example>
        /// <code>
        /// double normalizedValue = Clamp01(2.5); // returns 1.0
        /// double lowerBoundValue = Clamp01(-1.0); // returns 0.0
        /// </code>
        /// </example>
        /// <param name="value">The double value to be clamped.</param>
        /// <returns>The clamped double value.</returns>
        public static double Clamp01(double value) {
            return Math.Clamp(value, 0.0d, 1.0d);
        }

        /// <summary>
        /// Clamps a decimal value to ensure it falls within the range of 0 to 1.
        /// </summary>
        /// <example>
        /// <code>
        /// decimal normalizedValue = Clamp01(1.2m); // returns 1.0m
        /// decimal lowerBoundValue = Clamp01(-0.5m); // returns 0.0m
        /// </code>
        /// </example>
        /// <param name="value">The decimal value to be clamped.</param>
        /// <returns>The clamped decimal value.</returns>
        public static decimal Clamp01(decimal value) {
            return Math.Clamp(value, 0.0m, 1.0m);
        }

        #endregion Clamp

        #region Normalize

        /// <summary>
        /// Normalizes a float value to a range defined by a minimum and maximum.
        /// </summary>
        /// <example>
        /// <code>
        /// float normalized = Normalize(15f, 10f, 20f); // returns 0.5f
        /// </code>
        /// </example>
        /// <param name="value">The value to normalize.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns>The normalized value, scaled to the range 0 to 1.</returns>
        /// <exception cref="DivideByZeroException">Thrown when the min and max values are equal.</exception>
        /// <exception cref="ArgumentException">Thrown when min is greater than max.</exception>
        public static float Normalize(float value, float min, float max) {
            if (min == max)
                throw new DivideByZeroException("Normalization range cannot be zero (min and max are equal).");
            if (min > max)
                throw new ArgumentException("Min value cannot be greater than max value.");

            return (value - min) / (max - min);
        }

        /// <summary>
        /// Normalizes a double value to a range defined by a minimum and maximum.
        /// </summary>
        /// <example>
        /// <code>
        /// double normalized = Normalize(50.0, 0.0, 100.0); // returns 0.5
        /// </code>
        /// </example>
        /// <param name="value">The value to normalize.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns>The normalized value, scaled to the range 0 to 1.</returns>
        /// <exception cref="DivideByZeroException">Thrown when the min and max values are equal.</exception>
        /// <exception cref="ArgumentException">Thrown when min is greater than max.</exception>
        public static double Normalize(double value, double min, double max) {
            if (min == max)
                throw new DivideByZeroException("Normalization range cannot be zero (min and max are equal).");
            if (min > max)
                throw new ArgumentException("Min value cannot be greater than max value.");

            return (value - min) / (max - min);
        }

        /// <summary>
        /// Normalizes a decimal value to a range defined by a minimum and maximum.
        /// </summary>
        /// <example>
        /// <code>
        /// decimal normalized = Normalize(300m, 200m, 400m); // returns 0.5m
        /// </code>
        /// </example>
        /// <param name="value">The value to normalize.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns>The normalized value, scaled to the range 0 to 1.</returns>
        /// <exception cref="DivideByZeroException">Thrown when the min and max values are equal.</exception>
        /// <exception cref="ArgumentException">Thrown when min is greater than max.</exception>
        public static decimal Normalize(decimal value, decimal min, decimal max) {
            if (min == max)
                throw new DivideByZeroException("Normalization range cannot be zero (min and max are equal).");
            if (min > max)
                throw new ArgumentException("Min value cannot be greater than max value.");

            return (value - min) / (max - min);
        }

        #endregion Normalize

        #region Is Approximately

        /// <summary>
        /// Determines if two float values are approximately equal within a tolerance.
        /// </summary>
        /// <param name="value">The first value to compare.</param>
        /// <param name="other">The second value to compare.</param>
        /// <param name="tolerance">The tolerance for comparison.</param>
        /// <returns>True if the values are approximately equal; otherwise, false.</returns>
        public static bool IsApproximately(float value, float other, float tolerance = 0.0001f) {
            return Math.Abs(value - other) < tolerance;
        }

        /// <summary>
        /// Determines if two double values are approximately equal within a tolerance.
        /// </summary>
        /// <param name="value">The first value to compare.</param>
        /// <param name="other">The second value to compare.</param>
        /// <param name="tolerance">The tolerance for comparison.</param>
        /// <returns>True if the values are approximately equal; otherwise, false.</returns>
        public static bool IsApproximately(double value, double other, double tolerance = 0.0001) {
            return Math.Abs(value - other) < tolerance;
        }

        /// <summary>
        /// Determines if two decimal values are approximately equal within a tolerance.
        /// </summary>
        /// <param name="value">The first value to compare.</param>
        /// <param name="other">The second value to compare.</param>
        /// <param name="tolerance">The tolerance for comparison.</param>
        /// <returns>True if the values are approximately equal; otherwise, false.</returns>
        public static bool IsApproximately(decimal value, decimal other, decimal tolerance = 0.0001m) {
            return Math.Abs(value - other) < tolerance;
        }

        #endregion Is Approximately
    }
}