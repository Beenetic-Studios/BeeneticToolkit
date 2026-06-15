using System;

namespace BeeneticToolkit.Numerics {

    /// <summary>
    /// Provides methods for angle conversions between degrees and radians.
    /// </summary>
    public static class AngleUtils {

        #region Constants

        /// <summary>Multiplier that converts degrees to radians (π / 180).</summary>
        public const float Deg2Rad = MathF.PI / 180f;

        /// <summary>Multiplier that converts radians to degrees (180 / π).</summary>
        public const float Rad2Deg = 180f / MathF.PI;

        #endregion Constants

        #region Angle

        /// <summary>
        /// Converts degrees to radians.
        /// </summary>
        /// <param name="degrees">The angle in degrees.</param>
        /// <returns>The angle in radians.</returns>
        public static float ToRadians(float degrees) {
            return degrees * Deg2Rad;
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
            return radians * Rad2Deg;
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

        #region Wrapping

        /// <summary>Wraps an angle in degrees to the half-open range [-180, 180).</summary>
        /// <param name="degrees">The angle in degrees.</param>
        /// <returns>The equivalent angle in the range [-180, 180).</returns>
        public static float WrapDegrees(float degrees) => RoundingUtils.Wrap(degrees, -180f, 180f);

        /// <inheritdoc cref="WrapDegrees(float)"/>
        public static double WrapDegrees(double degrees) => RoundingUtils.Wrap(degrees, -180d, 180d);

        /// <summary>Wraps an angle in radians to the half-open range [-π, π).</summary>
        /// <param name="radians">The angle in radians.</param>
        /// <returns>The equivalent angle in the range [-π, π).</returns>
        public static float WrapRadians(float radians) => RoundingUtils.Wrap(radians, -MathF.PI, MathF.PI);

        /// <inheritdoc cref="WrapRadians(float)"/>
        public static double WrapRadians(double radians) => RoundingUtils.Wrap(radians, -Math.PI, Math.PI);

        #endregion Wrapping

        #region Delta

        /// <summary>
        /// Returns the shortest signed difference between two angles in degrees, accounting for wraparound — i.e.
        /// how far (and which way) to turn from <paramref name="current"/> to reach <paramref name="target"/>.
        /// </summary>
        /// <param name="current">The starting angle, in degrees.</param>
        /// <param name="target">The target angle, in degrees.</param>
        /// <returns>The signed delta in degrees, in the range [-180, 180).</returns>
        public static float DeltaAngleDegrees(float current, float target) => RoundingUtils.Wrap(target - current, -180f, 180f);

        /// <inheritdoc cref="DeltaAngleDegrees(float, float)"/>
        public static double DeltaAngleDegrees(double current, double target) => RoundingUtils.Wrap(target - current, -180d, 180d);

        /// <summary>
        /// Returns the shortest signed difference between two angles in radians, accounting for wraparound.
        /// </summary>
        /// <param name="current">The starting angle, in radians.</param>
        /// <param name="target">The target angle, in radians.</param>
        /// <returns>The signed delta in radians, in the range [-π, π).</returns>
        public static float DeltaAngleRadians(float current, float target) => RoundingUtils.Wrap(target - current, -MathF.PI, MathF.PI);

        /// <inheritdoc cref="DeltaAngleRadians(float, float)"/>
        public static double DeltaAngleRadians(double current, double target) => RoundingUtils.Wrap(target - current, -Math.PI, Math.PI);

        #endregion Delta

        #region Lerp

        /// <summary>
        /// Interpolates between two angles in degrees along the shortest path, so it crosses the 0/360 seam
        /// correctly (e.g. 350° → 10° goes forward through 0, not backward).
        /// </summary>
        /// <param name="current">The start angle, in degrees.</param>
        /// <param name="target">The end angle, in degrees.</param>
        /// <param name="t">The interpolation factor, clamped to [0, 1].</param>
        /// <returns>The interpolated angle in degrees (not wrapped).</returns>
        public static float LerpAngleDegrees(float current, float target, float t) =>
            current + DeltaAngleDegrees(current, target) * NumericalUtils.Clamp01(t);

        /// <inheritdoc cref="LerpAngleDegrees(float, float, float)"/>
        public static double LerpAngleDegrees(double current, double target, double t) =>
            current + DeltaAngleDegrees(current, target) * NumericalUtils.Clamp01(t);

        /// <summary>Interpolates between two angles in radians along the shortest path.</summary>
        /// <param name="current">The start angle, in radians.</param>
        /// <param name="target">The end angle, in radians.</param>
        /// <param name="t">The interpolation factor, clamped to [0, 1].</param>
        /// <returns>The interpolated angle in radians (not wrapped).</returns>
        public static float LerpAngleRadians(float current, float target, float t) =>
            current + DeltaAngleRadians(current, target) * NumericalUtils.Clamp01(t);

        /// <inheritdoc cref="LerpAngleRadians(float, float, float)"/>
        public static double LerpAngleRadians(double current, double target, double t) =>
            current + DeltaAngleRadians(current, target) * NumericalUtils.Clamp01(t);

        #endregion Lerp

        #region MoveTowards

        /// <summary>
        /// Moves an angle (degrees) toward a target by at most <paramref name="maxDelta"/> degrees, taking the
        /// shortest path around the circle and without overshooting.
        /// </summary>
        /// <param name="current">The current angle, in degrees.</param>
        /// <param name="target">The target angle, in degrees.</param>
        /// <param name="maxDelta">The maximum degrees to turn.</param>
        /// <returns>The new angle in degrees.</returns>
        public static float MoveTowardsAngleDegrees(float current, float target, float maxDelta) {
            float delta = DeltaAngleDegrees(current, target);
            if (-maxDelta < delta && delta < maxDelta)
                return target;

            return InterpolationUtils.MoveTowards(current, current + delta, maxDelta);
        }

        /// <inheritdoc cref="MoveTowardsAngleDegrees(float, float, float)"/>
        public static double MoveTowardsAngleDegrees(double current, double target, double maxDelta) {
            double delta = DeltaAngleDegrees(current, target);
            if (-maxDelta < delta && delta < maxDelta)
                return target;

            return InterpolationUtils.MoveTowards(current, current + delta, maxDelta);
        }

        /// <summary>
        /// Moves an angle (radians) toward a target by at most <paramref name="maxDelta"/> radians, taking the
        /// shortest path around the circle and without overshooting.
        /// </summary>
        /// <param name="current">The current angle, in radians.</param>
        /// <param name="target">The target angle, in radians.</param>
        /// <param name="maxDelta">The maximum radians to turn.</param>
        /// <returns>The new angle in radians.</returns>
        public static float MoveTowardsAngleRadians(float current, float target, float maxDelta) {
            float delta = DeltaAngleRadians(current, target);
            if (-maxDelta < delta && delta < maxDelta)
                return target;

            return InterpolationUtils.MoveTowards(current, current + delta, maxDelta);
        }

        /// <inheritdoc cref="MoveTowardsAngleRadians(float, float, float)"/>
        public static double MoveTowardsAngleRadians(double current, double target, double maxDelta) {
            double delta = DeltaAngleRadians(current, target);
            if (-maxDelta < delta && delta < maxDelta)
                return target;

            return InterpolationUtils.MoveTowards(current, current + delta, maxDelta);
        }

        #endregion MoveTowards
    }
}