using System;

namespace BeeneticToolkit.MathUtils {

    /// <summary>
    /// Provides a collection of mathematical utility methods for various common operations.
    /// </summary>
    public static class MathUtils {

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
        /// Normalizes a float value within a given range.
        /// </summary>
        /// <param name="value">The value to normalize.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns>The normalized float value.</returns>
        public static float Normalize(float value, float min, float max) {
            if (min == max)
                throw new DivideByZeroException("Normalization range cannot be zero (min and max are equal).");
            if (min > max)
                throw new ArgumentException("Min value cannot be greater than max value.");

            return (value - min) / (max - min);
        }

        /// <summary>
        /// Normalizes a double value within a given range.
        /// </summary>
        /// <param name="value">The value to normalize.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns>The normalized double value.</returns>
        public static double Normalize(double value, double min, double max) {
            if (min == max)
                throw new DivideByZeroException("Normalization range cannot be zero (min and max are equal).");
            if (min > max)
                throw new ArgumentException("Min value cannot be greater than max value.");

            return (value - min) / (max - min);
        }

        /// <summary>
        /// Normalizes a decimal value within a given range.
        /// </summary>
        /// <param name="value">The value to normalize.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns>The normalized decimal value.</returns>
        public static decimal Normalize(decimal value, decimal min, decimal max) {
            if (min == max)
                throw new DivideByZeroException("Normalization range cannot be zero (min and max are equal).");
            if (min > max)
                throw new ArgumentException("Min value cannot be greater than max value.");

            return (value - min) / (max - min);
        }

        #endregion Normalize

        #region Lerp

        /// <summary>
        /// Linearly interpolates between two float values.
        /// </summary>
        /// <param name="start">The start value.</param>
        /// <param name="end">The end value.</param>
        /// <param name="factor">The interpolation factor.</param>
        /// <returns>The interpolated float value.</returns>
        public static float Lerp(float start, float end, float factor) {
            return start + (end - start) * Clamp01(factor);
        }

        /// <summary>
        /// Linearly interpolates between two double values.
        /// </summary>
        /// <param name="start">The start value.</param>
        /// <param name="end">The end value.</param>
        /// <param name="factor">The interpolation factor.</param>
        /// <returns>The interpolated double value.</returns>
        public static double Lerp(double start, double end, double factor) {
            return start + (end - start) * Clamp01(factor);
        }

        /// <summary>
        /// Linearly interpolates between two decimal values.
        /// </summary>
        /// <param name="start">The start value.</param>
        /// <param name="end">The end value.</param>
        /// <param name="factor">The interpolation factor.</param>
        /// <returns>The interpolated decimal value.</returns>
        public static decimal Lerp(decimal start, decimal end, decimal factor) {
            return start + (end - start) * Clamp01(factor);
        }

        /// <summary>
        /// Performs quadratic Bezier interpolation between two values, influenced by a control point.
        /// </summary>
        /// <param name="start">The start value of the interpolation range.</param>
        /// <param name="control">The control point that influences the shape of the interpolation curve.</param>
        /// <param name="end">The end value of the interpolation range.</param>
        /// <param name="factor">The interpolation factor, typically between 0 and 1. A value of 0 returns the start value, 1 returns the end value, and values in between return a point along the quadratic curve defined by the start, control, and end values.</param>
        /// <returns>The interpolated value along the quadratic Bezier curve defined by the start, control, and end values at the specified factor.</returns>
        public static float Qerp(float start, float control, float end, float factor) {
            float inverseFactor = 1f - factor;
            float weightedStart = inverseFactor * inverseFactor * start;
            float weightedControl = 2f * inverseFactor * factor * control;
            float weightedEnd = factor * factor * end;

            return weightedStart + weightedControl + weightedEnd;
        }

        /// <summary>
        /// Performs quadratic Bezier interpolation between two values, influenced by a control point.
        /// </summary>
        /// <param name="start">The start value of the interpolation range.</param>
        /// <param name="control">The control point that influences the shape of the interpolation curve.</param>
        /// <param name="end">The end value of the interpolation range.</param>
        /// <param name="factor">The interpolation factor, typically between 0 and 1. A value of 0 returns the start value, 1 returns the end value, and values in between return a point along the quadratic curve defined by the start, control, and end values.</param>
        /// <returns>The interpolated value along the quadratic Bezier curve defined by the start, control, and end values at the specified factor.</returns>
        public static double Qerp(double start, double control, double end, double factor) {
            double inverseFactor = 1d - factor;
            double weightedStart = inverseFactor * inverseFactor * start;
            double weightedControl = 2d * inverseFactor * factor * control;
            double weightedEnd = factor * factor * end;

            return weightedStart + weightedControl + weightedEnd;
        }

        /// <summary>
        /// Performs quadratic Bezier interpolation between two values, influenced by a control point.
        /// </summary>
        /// <param name="start">The start value of the interpolation range.</param>
        /// <param name="control">The control point that influences the shape of the interpolation curve.</param>
        /// <param name="end">The end value of the interpolation range.</param>
        /// <param name="factor">The interpolation factor, typically between 0 and 1. A value of 0 returns the start value, 1 returns the end value, and values in between return a point along the quadratic curve defined by the start, control, and end values.</param>
        /// <returns>The interpolated value along the quadratic Bezier curve defined by the start, control, and end values at the specified factor.</returns>
        public static decimal Qerp(decimal start, decimal control, decimal end, decimal factor) {
            decimal inverseFactor = 1m - factor;
            decimal weightedStart = inverseFactor * inverseFactor * start;
            decimal weightedControl = 2m * inverseFactor * factor * control;
            decimal weightedEnd = factor * factor * end;

            return weightedStart + weightedControl + weightedEnd;
        }

        /// <summary>
        /// Calculates the inverse linear interpolation factor between two values.
        /// </summary>
        /// <param name="value">The current value.</param>
        /// <param name="min">The start value.</param>
        /// <param name="max">The end value.</param>
        /// <returns>The inverse interpolation factor.</returns>
        public static float InverseLerp(float value, float min, float max) {
            if (min == max)
                throw new DivideByZeroException("Lerp range cannot be zero (min and max are equal).");

            return (value - min) / (max - min);
        }

        /// <summary>
        /// Calculates the inverse linear interpolation factor between two values.
        /// </summary>
        /// <param name="value">The current value.</param>
        /// <param name="min">The start value.</param>
        /// <param name="max">The end value.</param>
        /// <returns>The inverse interpolation factor.</returns>
        public static double InverseLerp(double value, double min, double max) {
            if (min == max)
                throw new DivideByZeroException("Lerp range cannot be zero (min and max are equal).");

            return (value - min) / (max - min);
        }

        /// <summary>
        /// Calculates the inverse linear interpolation factor between two values.
        /// </summary>
        /// <param name="value">The current value.</param>
        /// <param name="min">The start value.</param>
        /// <param name="max">The end value.</param>
        /// <returns>The inverse interpolation factor.</returns>
        public static decimal InverseLerp(decimal value, decimal min, decimal max) {
            if (min == max)
                throw new DivideByZeroException("Lerp range cannot be zero (min and max are equal).");

            return (value - min) / (max - min);
        }

        #endregion Lerp

        #region Round To Nearest

        /// <summary>
        /// Rounds a value to the nearest specified interval.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <param name="interval">The interval to round to.</param>
        /// <returns>The rounded value.</returns>
        public static float RoundToNearest(float value, float interval) {
            return interval == 0f ? (float)Math.Round(value) : (float)(Math.Round(value / interval, MidpointRounding.AwayFromZero) * interval);
        }

        /// <summary>
        /// Rounds a value to the nearest specified interval.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <param name="interval">The interval to round to.</param>
        /// <returns>The rounded value.</returns>
        public static double RoundToNearest(double value, double interval) {
            return interval == 0d ? Math.Round(value) : Math.Round(value / interval, MidpointRounding.AwayFromZero) * interval;
        }

        /// <summary>
        /// Rounds a value to the nearest specified interval.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <param name="interval">The interval to round to.</param>
        /// <returns>The rounded value.</returns>
        public static decimal RoundToNearest(decimal value, decimal interval) {
            return interval == 0m ? Math.Round(value) : Math.Round(value / interval, MidpointRounding.AwayFromZero) * interval;
        }

        #endregion Round To Nearest

        #region Wrap

        /// <summary>
        /// Wraps a value within a specified range.
        /// </summary>
        /// <param name="value">The value to wrap.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns>The wrapped value.</returns>
        public static float Wrap(float value, float min, float max) {
            return (value - min) % (max - min) + min;
        }

        /// <summary>
        /// Wraps a value within a specified range.
        /// </summary>
        /// <param name="value">The value to wrap.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns>The wrapped value.</returns>
        public static double Wrap(double value, double min, double max) {
            return (value - min) % (max - min) + min;
        }

        /// <summary>
        /// Wraps a value within a specified range.
        /// </summary>
        /// <param name="value">The value to wrap.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns>The wrapped value.</returns>
        public static decimal Wrap(decimal value, decimal min, decimal max) {
            return (value - min) % (max - min) + min;
        }

        #endregion Wrap

        #region Angle

        /// <summary>
        /// Converts degrees to radians.
        /// </summary>
        /// <param name="degrees">The angle in degrees.</param>
        /// <returns>The angle in radians.</returns>
        public static float ToRadians(float degrees) {
            return degrees * (float)Math.PI / 180.0f;
        }

        /// <summary>
        /// Converts degrees to radians.
        /// </summary>
        /// <param name="degrees">The angle in degrees.</param>
        /// <returns>The angle in radians.</returns>
        public static double ToRadians(double degrees) {
            return degrees * Math.PI / 180.0;
        }

        /// <summary>
        /// Converts degrees to radians.
        /// </summary>
        /// <param name="degrees">The angle in degrees.</param>
        /// <returns>The angle in radians.</returns>
        public static decimal ToRadians(decimal degrees) {
            return degrees * (decimal)Math.PI / 180.0m;
        }

        /// <summary>
        /// Converts radians to degrees.
        /// </summary>
        /// <param name="radians">The angle in radians.</param>
        /// <returns>The angle in degrees.</returns>
        public static float ToDegrees(float radians) {
            return radians * 180.0f / (float)Math.PI;
        }

        /// <summary>
        /// Converts radians to degrees.
        /// </summary>
        /// <param name="radians">The angle in radians.</param>
        /// <returns>The angle in degrees.</returns>
        public static double ToDegrees(double radians) {
            return radians * 180.0 / Math.PI;
        }

        /// <summary>
        /// Converts radians to degrees.
        /// </summary>
        /// <param name="radians">The angle in radians.</param>
        /// <returns>The angle in degrees.</returns>
        public static decimal ToDegrees(decimal radians) {
            return radians * 180.0m / (decimal)Math.PI;
        }

        #endregion Angle

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