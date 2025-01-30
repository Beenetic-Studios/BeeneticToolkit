using System;

namespace BeeneticToolkit.Numerics {

    /// <summary>
    /// Provides methods for rounding values, including rounding to the nearest interval and wrapping values within a range.
    /// </summary>
    public static class RoundingUtils {

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
    }
}