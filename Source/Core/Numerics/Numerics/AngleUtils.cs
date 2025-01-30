using System;

namespace BeeneticToolkit.Numerics {

    /// <summary>
    /// Provides methods for angle conversions between degrees and radians.
    /// </summary>
    public static class AngleUtils {

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
    }
}