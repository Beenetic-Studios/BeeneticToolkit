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
    }
}