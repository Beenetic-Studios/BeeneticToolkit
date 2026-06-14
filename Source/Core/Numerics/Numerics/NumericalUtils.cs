using System;

namespace BeeneticToolkit.Numerics {

    /// <summary>
    /// Provides utility methods for common numerical operations, including clamping, normalization, and approximate comparisons.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <see cref="IsApproximately(float, float, float)"/> uses an <em>absolute</em> tolerance, which is only
    /// appropriate when the compared magnitudes are known and small. For values that vary in scale, prefer
    /// <see cref="IsApproximatelyRelative(float, float, float)"/>, whose tolerance scales with magnitude.
    /// </para>
    /// <para>
    /// Except where documented, non-finite inputs (<see cref="float.NaN"/>, infinities) are not specially
    /// handled by the clamp/normalize methods and propagate through the result.
    /// </para>
    /// </remarks>
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

        /// <summary>
        /// Converts a normalized float value (0 to 1) back to its original range.
        /// </summary>
        /// <example>
        /// <code>
        /// float value = Denormalize(0.5f, 10f, 20f); // returns 15f
        /// </code>
        /// </example>
        /// <param name="normalizedValue">The normalized value (0 to 1).</param>
        /// <param name="min">The minimum value of the original range.</param>
        /// <param name="max">The maximum value of the original range.</param>
        /// <returns>The original value within the specified range.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the normalized value is outside the range 0 to 1.</exception>
        public static float Denormalize(float normalizedValue, float min, float max) {
            if (normalizedValue < 0 || normalizedValue > 1)
                throw new ArgumentOutOfRangeException(nameof(normalizedValue), "Normalized value must be between 0 and 1.");

            return normalizedValue * (max - min) + min;
        }

        /// <summary>
        /// Converts a normalized double value (0 to 1) back to its original range.
        /// </summary>
        /// <example>
        /// <code>
        /// float value = Denormalize(0.5, 10.0, 20.0); // returns 15.0
        /// </code>
        /// </example>
        /// <param name="normalizedValue">The normalized value (0 to 1).</param>
        /// <param name="min">The minimum value of the original range.</param>
        /// <param name="max">The maximum value of the original range.</param>
        /// <returns>The original value within the specified range.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the normalized value is outside the range 0 to 1.</exception>
        public static double Denormalize(double normalizedValue, double min, double max) {
            if (normalizedValue < 0 || normalizedValue > 1)
                throw new ArgumentOutOfRangeException(nameof(normalizedValue), "Normalized value must be between 0 and 1.");

            return normalizedValue * (max - min) + min;
        }

        /// <summary>
        /// Converts a normalized decimal value (0 to 1) back to its original range.
        /// </summary>
        /// <example>
        /// <code>
        /// float value = Denormalize(0.5m, 10m, 20m); // returns 15m
        /// </code>
        /// </example>
        /// <param name="normalizedValue">The normalized value (0 to 1).</param>
        /// <param name="min">The minimum value of the original range.</param>
        /// <param name="max">The maximum value of the original range.</param>
        /// <returns>The original value within the specified range.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the normalized value is outside the range 0 to 1.</exception>
        public static decimal Denormalize(decimal normalizedValue, decimal min, decimal max) {
            if (normalizedValue < 0 || normalizedValue > 1)
                throw new ArgumentOutOfRangeException(nameof(normalizedValue), "Normalized value must be between 0 and 1.");

            return normalizedValue * (max - min) + min;
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

        /// <summary>
        /// Determines whether two float values are approximately equal using a tolerance scaled to their magnitude.
        /// </summary>
        /// <param name="value">The first value to compare.</param>
        /// <param name="other">The second value to compare.</param>
        /// <param name="relativeTolerance">The relative tolerance (fraction of the larger magnitude).</param>
        /// <returns>
        /// <c>true</c> if the values are approximately equal; otherwise <c>false</c>. Equal infinities return
        /// <c>true</c>; <see cref="float.NaN"/> and mismatched non-finite values return <c>false</c>.
        /// </returns>
        public static bool IsApproximatelyRelative(float value, float other, float relativeTolerance = 1e-6f) {
            if (value == other)
                return true;
            if (float.IsNaN(value) || float.IsNaN(other) || float.IsInfinity(value) || float.IsInfinity(other))
                return false;

            float scale = Math.Max(Math.Abs(value), Math.Abs(other));
            return Math.Abs(value - other) <= relativeTolerance * scale;
        }

        /// <summary>
        /// Determines whether two double values are approximately equal using a tolerance scaled to their magnitude.
        /// </summary>
        /// <param name="value">The first value to compare.</param>
        /// <param name="other">The second value to compare.</param>
        /// <param name="relativeTolerance">The relative tolerance (fraction of the larger magnitude).</param>
        /// <returns>
        /// <c>true</c> if the values are approximately equal; otherwise <c>false</c>. Equal infinities return
        /// <c>true</c>; <see cref="double.NaN"/> and mismatched non-finite values return <c>false</c>.
        /// </returns>
        public static bool IsApproximatelyRelative(double value, double other, double relativeTolerance = 1e-12) {
            if (value == other)
                return true;
            if (double.IsNaN(value) || double.IsNaN(other) || double.IsInfinity(value) || double.IsInfinity(other))
                return false;

            double scale = Math.Max(Math.Abs(value), Math.Abs(other));
            return Math.Abs(value - other) <= relativeTolerance * scale;
        }

        /// <summary>
        /// Determines whether two decimal values are approximately equal using a tolerance scaled to their magnitude.
        /// </summary>
        /// <param name="value">The first value to compare.</param>
        /// <param name="other">The second value to compare.</param>
        /// <param name="relativeTolerance">The relative tolerance (fraction of the larger magnitude).</param>
        /// <returns><c>true</c> if the values are approximately equal; otherwise <c>false</c>.</returns>
        public static bool IsApproximatelyRelative(decimal value, decimal other, decimal relativeTolerance = 0.000001m) {
            if (value == other)
                return true;

            decimal scale = Math.Max(Math.Abs(value), Math.Abs(other));
            return Math.Abs(value - other) <= relativeTolerance * scale;
        }

        #endregion Is Approximately
    }
}