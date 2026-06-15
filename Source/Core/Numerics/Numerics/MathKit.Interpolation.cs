using System;

namespace BeeneticToolkit.Numerics {

    // Interpolation, remapping, smoothing, movement, and splines. See MathKit.cs for the type summary.
    public static partial class MathKit {

        #region Interpolation

        /// <summary>
        /// Performs linear interpolation between two float values based on a given interpolation factor.
        /// </summary>
        /// <param name="start">The start value.</param>
        /// <param name="end">The end value.</param>
        /// <param name="factor">The interpolation factor, typically between 0 and 1. Values outside this range are clamped to the range [0, 1].</param>
        /// <returns>The interpolated float value between the start and end values.</returns>
        public static float Lerp(float start, float end, float factor) {
            return start + (end - start) * Clamp01(factor);
        }

        /// <summary>
        /// Performs linear interpolation between two double values based on a given interpolation factor.
        /// </summary>
        /// <param name="start">The start value.</param>
        /// <param name="end">The end value.</param>
        /// <param name="factor">The interpolation factor, typically between 0 and 1. Values outside this range are clamped to the range [0, 1].</param>
        /// <returns>The interpolated double value between the start and end values.</returns>
        public static double Lerp(double start, double end, double factor) {
            return start + (end - start) * Clamp01(factor);
        }

        /// <summary>
        /// Performs linear interpolation between two decimal values based on a given interpolation factor.
        /// </summary>
        /// <param name="start">The start value.</param>
        /// <param name="end">The end value.</param>
        /// <param name="factor">The interpolation factor, typically between 0 and 1. Values outside this range are clamped to the range [0, 1].</param>
        /// <returns>The interpolated decimal value between the start and end values.</returns>
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

            float t = Clamp01((value - fromMin) / (fromMax - fromMin));
            return toMin + (toMax - toMin) * t;
        }

        /// <inheritdoc cref="RemapClamped(float, float, float, float, float)"/>
        public static double RemapClamped(double value, double fromMin, double fromMax, double toMin, double toMax) {
            if (fromMin == fromMax)
                throw new DivideByZeroException("Source range cannot be zero (fromMin and fromMax are equal).");

            double t = Clamp01((value - fromMin) / (fromMax - fromMin));
            return toMin + (toMax - toMin) * t;
        }

        /// <inheritdoc cref="RemapClamped(float, float, float, float, float)"/>
        public static decimal RemapClamped(decimal value, decimal fromMin, decimal fromMax, decimal toMin, decimal toMax) {
            if (fromMin == fromMax)
                throw new DivideByZeroException("Source range cannot be zero (fromMin and fromMax are equal).");

            decimal t = Clamp01((value - fromMin) / (fromMax - fromMin));
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
            t = Clamp01(t);
            t = t * t * (3f - 2f * t);
            return from + (to - from) * t;
        }

        /// <inheritdoc cref="SmoothStep(float, float, float)"/>
        public static double SmoothStep(double from, double to, double t) {
            t = Clamp01(t);
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

        #region Splines

        /// <summary>
        /// Evaluates a cubic Bézier curve at <paramref name="factor"/> — the four-point sibling of
        /// <see cref="Qerp(float, float, float, float)"/>. The curve starts at <paramref name="p0"/>, ends at
        /// <paramref name="p3"/>, and is pulled toward the interior control points <paramref name="p1"/> and
        /// <paramref name="p2"/> (which it does not pass through).
        /// </summary>
        /// <param name="p0">The start point.</param>
        /// <param name="p1">The first control point.</param>
        /// <param name="p2">The second control point.</param>
        /// <param name="p3">The end point.</param>
        /// <param name="factor">The curve parameter, typically in [0, 1]. Not clamped.</param>
        /// <returns>The point on the curve at <paramref name="factor"/>.</returns>
        public static float Cerp(float p0, float p1, float p2, float p3, float factor) {
            float u = 1f - factor;
            float uu = u * u;
            float tt = factor * factor;
            return uu * u * p0 + 3f * uu * factor * p1 + 3f * u * tt * p2 + tt * factor * p3;
        }

        /// <inheritdoc cref="Cerp(float, float, float, float, float)"/>
        public static double Cerp(double p0, double p1, double p2, double p3, double factor) {
            double u = 1d - factor;
            double uu = u * u;
            double tt = factor * factor;
            return uu * u * p0 + 3d * uu * factor * p1 + 3d * u * tt * p2 + tt * factor * p3;
        }

        /// <inheritdoc cref="Cerp(float, float, float, float, float)"/>
        public static decimal Cerp(decimal p0, decimal p1, decimal p2, decimal p3, decimal factor) {
            decimal u = 1m - factor;
            decimal uu = u * u;
            decimal tt = factor * factor;
            return uu * u * p0 + 3m * uu * factor * p1 + 3m * u * tt * p2 + tt * factor * p3;
        }

        /// <summary>
        /// Evaluates a Catmull-Rom spline segment, interpolating from <paramref name="p1"/> (at
        /// <paramref name="t"/> = 0) to <paramref name="p2"/> (at <paramref name="t"/> = 1) using
        /// <paramref name="p0"/> and <paramref name="p3"/> as the neighbouring points that shape the tangents.
        /// Unlike a Bézier curve, the spline passes <i>through</i> <paramref name="p1"/> and <paramref name="p2"/>,
        /// which makes it ideal for smoothly following a series of keyframes or waypoints.
        /// </summary>
        /// <param name="p0">The point before the segment (shapes the entry tangent).</param>
        /// <param name="p1">The segment start (returned at <paramref name="t"/> = 0).</param>
        /// <param name="p2">The segment end (returned at <paramref name="t"/> = 1).</param>
        /// <param name="p3">The point after the segment (shapes the exit tangent).</param>
        /// <param name="t">The segment parameter, typically in [0, 1]. Not clamped.</param>
        /// <returns>The point on the spline between <paramref name="p1"/> and <paramref name="p2"/>.</returns>
        public static float CatmullRom(float p0, float p1, float p2, float p3, float t) {
            float t2 = t * t;
            float t3 = t2 * t;
            return 0.5f * (2f * p1
                + (-p0 + p2) * t
                + (2f * p0 - 5f * p1 + 4f * p2 - p3) * t2
                + (-p0 + 3f * p1 - 3f * p2 + p3) * t3);
        }

        /// <inheritdoc cref="CatmullRom(float, float, float, float, float)"/>
        public static double CatmullRom(double p0, double p1, double p2, double p3, double t) {
            double t2 = t * t;
            double t3 = t2 * t;
            return 0.5d * (2d * p1
                + (-p0 + p2) * t
                + (2d * p0 - 5d * p1 + 4d * p2 - p3) * t2
                + (-p0 + 3d * p1 - 3d * p2 + p3) * t3);
        }

        /// <inheritdoc cref="CatmullRom(float, float, float, float, float)"/>
        public static decimal CatmullRom(decimal p0, decimal p1, decimal p2, decimal p3, decimal t) {
            decimal t2 = t * t;
            decimal t3 = t2 * t;
            return 0.5m * (2m * p1
                + (-p0 + p2) * t
                + (2m * p0 - 5m * p1 + 4m * p2 - p3) * t2
                + (-p0 + 3m * p1 - 3m * p2 + p3) * t3);
        }

        #endregion Splines

        #region SmootherStep

        /// <summary>
        /// Like <see cref="SmoothStep(float, float, float)"/> but using Ken Perlin's smoother curve
        /// (6t⁵ − 15t⁴ + 10t³), which has zero first <i>and</i> second derivatives at both ends for an even
        /// gentler start and stop. Clamps the factor to [0, 1].
        /// </summary>
        /// <param name="from">The start value (returned when <paramref name="t"/> is 0 or less).</param>
        /// <param name="to">The end value (returned when <paramref name="t"/> is 1 or more).</param>
        /// <param name="t">The interpolation factor. Clamped to [0, 1] before easing.</param>
        /// <returns>The eased value between <paramref name="from"/> and <paramref name="to"/>.</returns>
        public static float SmootherStep(float from, float to, float t) {
            t = Clamp01(t);
            t = t * t * t * (t * (t * 6f - 15f) + 10f);
            return from + (to - from) * t;
        }

        /// <inheritdoc cref="SmootherStep(float, float, float)"/>
        public static double SmootherStep(double from, double to, double t) {
            t = Clamp01(t);
            t = t * t * t * (t * (t * 6d - 15d) + 10d);
            return from + (to - from) * t;
        }

        #endregion SmootherStep

        #region Step

        /// <summary>Returns 0 when <paramref name="x"/> is below <paramref name="edge"/>, otherwise 1 — a hard threshold, the GLSL-style companion to <see cref="SmoothStep(float, float, float)"/>.</summary>
        /// <param name="edge">The threshold.</param>
        /// <param name="x">The value to test.</param>
        public static float Step(float edge, float x) => x < edge ? 0f : 1f;

        /// <inheritdoc cref="Step(float, float)"/>
        public static double Step(double edge, double x) => x < edge ? 0d : 1d;

        /// <inheritdoc cref="Step(float, float)"/>
        public static decimal Step(decimal edge, decimal x) => x < edge ? 0m : 1m;

        #endregion Step

        #region SmoothDamp

        /// <summary>
        /// Gradually moves <paramref name="current"/> toward <paramref name="target"/> like a critically-damped
        /// spring — smooth acceleration and deceleration with no overshoot. Ideal for camera and UI follow.
        /// Call every frame, threading the same <paramref name="currentVelocity"/> through.
        /// </summary>
        /// <param name="current">The current value.</param>
        /// <param name="target">The value being chased.</param>
        /// <param name="currentVelocity">The caller-owned velocity state; pass the same variable each call.</param>
        /// <param name="smoothTime">Approximate time (seconds) to reach the target; larger is slower.</param>
        /// <param name="deltaTime">Time since the last call (seconds). Must be positive.</param>
        /// <param name="maxSpeed">Optional cap on how fast the value may move.</param>
        /// <returns>The new value, one step closer to <paramref name="target"/>.</returns>
        public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float deltaTime, float maxSpeed = float.PositiveInfinity) {
            // Critically-damped spring (the formulation popularized by Game Programming Gems 4 / Unity).
            smoothTime = Math.Max(0.0001f, smoothTime);
            float omega = 2f / smoothTime;
            float x = omega * deltaTime;
            float exp = 1f / (1f + x + 0.48f * x * x + 0.235f * x * x * x);

            float change = current - target;
            float originalTarget = target;

            float maxChange = maxSpeed * smoothTime;
            change = Math.Clamp(change, -maxChange, maxChange);
            target = current - change;

            float temp = (currentVelocity + omega * change) * deltaTime;
            currentVelocity = (currentVelocity - omega * temp) * exp;
            float output = target + (change + temp) * exp;

            // Prevent overshooting past the target.
            if (originalTarget - current > 0f == output > originalTarget) {
                output = originalTarget;
                currentVelocity = (output - originalTarget) / deltaTime;
            }

            return output;
        }

        /// <inheritdoc cref="SmoothDamp(float, float, ref float, float, float, float)"/>
        public static double SmoothDamp(double current, double target, ref double currentVelocity, double smoothTime, double deltaTime, double maxSpeed = double.PositiveInfinity) {
            smoothTime = Math.Max(0.0001d, smoothTime);
            double omega = 2d / smoothTime;
            double x = omega * deltaTime;
            double exp = 1d / (1d + x + 0.48d * x * x + 0.235d * x * x * x);

            double change = current - target;
            double originalTarget = target;

            double maxChange = maxSpeed * smoothTime;
            change = Math.Clamp(change, -maxChange, maxChange);
            target = current - change;

            double temp = (currentVelocity + omega * change) * deltaTime;
            currentVelocity = (currentVelocity - omega * temp) * exp;
            double output = target + (change + temp) * exp;

            if (originalTarget - current > 0d == output > originalTarget) {
                output = originalTarget;
                currentVelocity = (output - originalTarget) / deltaTime;
            }

            return output;
        }

        #endregion SmoothDamp
    }
}