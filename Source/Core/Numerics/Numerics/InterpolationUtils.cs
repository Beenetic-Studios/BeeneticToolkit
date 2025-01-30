using System;

namespace BeeneticToolkit.Numerics {

    /// <summary>
    /// Provides methods for interpolation, including linear interpolation (Lerp) and quadratic Bezier interpolation (Qerp).
    /// </summary>
    public static class InterpolationUtils {

        #region Interpolation

        /// <summary>
        /// Performs linear interpolation between two float values based on a given interpolation factor.
        /// </summary>
        /// <param name="start">The start value.</param>
        /// <param name="end">The end value.</param>
        /// <param name="factor">The interpolation factor, typically between 0 and 1. Values outside this range are clamped to the range [0, 1].</param>
        /// <returns>The interpolated float value between the start and end values.</returns>
        public static float Lerp(float start, float end, float factor) {
            return start + (end - start) * NumericalUtils.Clamp01(factor);
        }

        /// <summary>
        /// Performs linear interpolation between two double values based on a given interpolation factor.
        /// </summary>
        /// <param name="start">The start value.</param>
        /// <param name="end">The end value.</param>
        /// <param name="factor">The interpolation factor, typically between 0 and 1. Values outside this range are clamped to the range [0, 1].</param>
        /// <returns>The interpolated double value between the start and end values.</returns>
        public static double Lerp(double start, double end, double factor) {
            return start + (end - start) * NumericalUtils.Clamp01(factor);
        }

        /// <summary>
        /// Performs linear interpolation between two decimal values based on a given interpolation factor.
        /// </summary>
        /// <param name="start">The start value.</param>
        /// <param name="end">The end value.</param>
        /// <param name="factor">The interpolation factor, typically between 0 and 1. Values outside this range are clamped to the range [0, 1].</param>
        /// <returns>The interpolated decimal value between the start and end values.</returns>
        public static decimal Lerp(decimal start, decimal end, decimal factor) {
            return start + (end - start) * NumericalUtils.Clamp01(factor);
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

        #endregion Interpolation
    }
}