using System;

namespace BeeneticToolkit.Numerics {

    /// <summary>
    /// Provides methods for interpolation, including linear interpolation (Lerp), quadratic Bezier
    /// interpolation (Qerp), range remapping, and smooth (Hermite) easing.
    /// </summary>
    /// <remarks>
    /// Unless a method documents otherwise, non-finite inputs (<see cref="float.NaN"/>,
    /// <see cref="float.PositiveInfinity"/>, etc.) are not specially handled and propagate through the result.
    /// </remarks>
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

        #region Unclamped Interpolation

        /// <summary>Performs linear interpolation between two values without clamping the factor, allowing extrapolation.</summary>
        /// <param name="start">The start value.</param>
        /// <param name="end">The end value.</param>
        /// <param name="factor">The interpolation factor. Values outside [0, 1] extrapolate beyond the endpoints.</param>
        /// <returns>The (possibly extrapolated) interpolated value.</returns>
        public static float LerpUnclamped(float start, float end, float factor) => start + (end - start) * factor;

        /// <inheritdoc cref="LerpUnclamped(float, float, float)"/>
        public static double LerpUnclamped(double start, double end, double factor) => start + (end - start) * factor;

        /// <inheritdoc cref="LerpUnclamped(float, float, float)"/>
        public static decimal LerpUnclamped(decimal start, decimal end, decimal factor) => start + (end - start) * factor;

        #endregion Unclamped Interpolation

        #region Remap

        /// <summary>Remaps a value from one range to another (linear, unclamped).</summary>
        /// <param name="value">The value to remap.</param>
        /// <param name="fromMin">The lower bound of the source range.</param>
        /// <param name="fromMax">The upper bound of the source range.</param>
        /// <param name="toMin">The lower bound of the destination range.</param>
        /// <param name="toMax">The upper bound of the destination range.</param>
        /// <returns>The value mapped into the destination range. Inputs outside the source range extrapolate.</returns>
        /// <exception cref="DivideByZeroException">Thrown when <paramref name="fromMin"/> equals <paramref name="fromMax"/>.</exception>
        public static float Remap(float value, float fromMin, float fromMax, float toMin, float toMax) {
            if (fromMin == fromMax)
                throw new DivideByZeroException("Source range cannot be zero (fromMin and fromMax are equal).");

            return toMin + (value - fromMin) * (toMax - toMin) / (fromMax - fromMin);
        }

        /// <inheritdoc cref="Remap(float, float, float, float, float)"/>
        public static double Remap(double value, double fromMin, double fromMax, double toMin, double toMax) {
            if (fromMin == fromMax)
                throw new DivideByZeroException("Source range cannot be zero (fromMin and fromMax are equal).");

            return toMin + (value - fromMin) * (toMax - toMin) / (fromMax - fromMin);
        }

        /// <inheritdoc cref="Remap(float, float, float, float, float)"/>
        public static decimal Remap(decimal value, decimal fromMin, decimal fromMax, decimal toMin, decimal toMax) {
            if (fromMin == fromMax)
                throw new DivideByZeroException("Source range cannot be zero (fromMin and fromMax are equal).");

            return toMin + (value - fromMin) * (toMax - toMin) / (fromMax - fromMin);
        }

        /// <summary>Remaps a value from one range to another, clamping the result to the destination range.</summary>
        /// <param name="value">The value to remap.</param>
        /// <param name="fromMin">The lower bound of the source range.</param>
        /// <param name="fromMax">The upper bound of the source range.</param>
        /// <param name="toMin">The lower bound of the destination range.</param>
        /// <param name="toMax">The upper bound of the destination range.</param>
        /// <returns>The value mapped into the destination range, clamped so it never leaves [<paramref name="toMin"/>, <paramref name="toMax"/>].</returns>
        /// <exception cref="DivideByZeroException">Thrown when <paramref name="fromMin"/> equals <paramref name="fromMax"/>.</exception>
        public static float RemapClamped(float value, float fromMin, float fromMax, float toMin, float toMax) {
            if (fromMin == fromMax)
                throw new DivideByZeroException("Source range cannot be zero (fromMin and fromMax are equal).");

            float t = NumericalUtils.Clamp01((value - fromMin) / (fromMax - fromMin));
            return toMin + (toMax - toMin) * t;
        }

        /// <inheritdoc cref="RemapClamped(float, float, float, float, float)"/>
        public static double RemapClamped(double value, double fromMin, double fromMax, double toMin, double toMax) {
            if (fromMin == fromMax)
                throw new DivideByZeroException("Source range cannot be zero (fromMin and fromMax are equal).");

            double t = NumericalUtils.Clamp01((value - fromMin) / (fromMax - fromMin));
            return toMin + (toMax - toMin) * t;
        }

        /// <inheritdoc cref="RemapClamped(float, float, float, float, float)"/>
        public static decimal RemapClamped(decimal value, decimal fromMin, decimal fromMax, decimal toMin, decimal toMax) {
            if (fromMin == fromMax)
                throw new DivideByZeroException("Source range cannot be zero (fromMin and fromMax are equal).");

            decimal t = NumericalUtils.Clamp01((value - fromMin) / (fromMax - fromMin));
            return toMin + (toMax - toMin) * t;
        }

        #endregion Remap

        #region SmoothStep

        /// <summary>Interpolates between two values with smooth (Hermite) easing, clamping the factor to [0, 1].</summary>
        /// <param name="from">The start value (returned when <paramref name="t"/> is 0 or less).</param>
        /// <param name="to">The end value (returned when <paramref name="t"/> is 1 or more).</param>
        /// <param name="t">The interpolation factor. Clamped to [0, 1] before easing.</param>
        /// <returns>The eased value between <paramref name="from"/> and <paramref name="to"/>.</returns>
        public static float SmoothStep(float from, float to, float t) {
            t = NumericalUtils.Clamp01(t);
            t = t * t * (3f - 2f * t);
            return from + (to - from) * t;
        }

        /// <inheritdoc cref="SmoothStep(float, float, float)"/>
        public static double SmoothStep(double from, double to, double t) {
            t = NumericalUtils.Clamp01(t);
            t = t * t * (3d - 2d * t);
            return from + (to - from) * t;
        }

        #endregion SmoothStep

        #region MoveTowards

        /// <summary>
        /// Moves <paramref name="current"/> toward <paramref name="target"/> by at most <paramref name="maxDelta"/>,
        /// without overshooting. Unlike <see cref="Lerp(float, float, float)"/>, this moves a fixed amount rather
        /// than a fraction — handy for constant-speed movement of meters, cooldowns, and UI values.
        /// </summary>
        /// <param name="current">The current value.</param>
        /// <param name="target">The value to move toward.</param>
        /// <param name="maxDelta">The maximum distance to move. Negative values move away from the target.</param>
        /// <returns>The new value, never past <paramref name="target"/> (for non-negative <paramref name="maxDelta"/>).</returns>
        public static float MoveTowards(float current, float target, float maxDelta) {
            float diff = target - current;
            if (Math.Abs(diff) <= maxDelta)
                return target;

            return current + Math.Sign(diff) * maxDelta;
        }

        /// <inheritdoc cref="MoveTowards(float, float, float)"/>
        public static double MoveTowards(double current, double target, double maxDelta) {
            double diff = target - current;
            if (Math.Abs(diff) <= maxDelta)
                return target;

            return current + Math.Sign(diff) * maxDelta;
        }

        /// <inheritdoc cref="MoveTowards(float, float, float)"/>
        public static decimal MoveTowards(decimal current, decimal target, decimal maxDelta) {
            decimal diff = target - current;
            if (Math.Abs(diff) <= maxDelta)
                return target;

            return current + Math.Sign(diff) * maxDelta;
        }

        #endregion MoveTowards
    }
}