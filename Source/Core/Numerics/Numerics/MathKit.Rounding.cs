using System;

namespace BeeneticToolkit.Numerics {

    // Rounding to an interval and floored range wrapping. See MathKit.cs for the type summary.
    public static partial class MathKit {

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
        /// <returns>The wrapped value, in the half-open range <c>[<paramref name="min"/>, <paramref name="max"/>)</c>.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="max"/> is not greater than <paramref name="min"/>.</exception>
        public static float Wrap(float value, float min, float max) {
            if (max <= min)
                throw new ArgumentException($"{nameof(max)} must be greater than {nameof(min)}.");

            float range = max - min;
            float wrapped = (value - min) % range;
            if (wrapped < 0f)
                wrapped += range;

            return wrapped + min;
        }

        /// <summary>
        /// Wraps a value within a specified range.
        /// </summary>
        /// <param name="value">The value to wrap.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns>The wrapped value, in the half-open range <c>[<paramref name="min"/>, <paramref name="max"/>)</c>.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="max"/> is not greater than <paramref name="min"/>.</exception>
        public static double Wrap(double value, double min, double max) {
            if (max <= min)
                throw new ArgumentException($"{nameof(max)} must be greater than {nameof(min)}.");

            double range = max - min;
            double wrapped = (value - min) % range;
            if (wrapped < 0d)
                wrapped += range;

            return wrapped + min;
        }

        /// <summary>
        /// Wraps a value within a specified range.
        /// </summary>
        /// <param name="value">The value to wrap.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns>The wrapped value, in the half-open range <c>[<paramref name="min"/>, <paramref name="max"/>)</c>.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="max"/> is not greater than <paramref name="min"/>.</exception>
        public static decimal Wrap(decimal value, decimal min, decimal max) {
            if (max <= min)
                throw new ArgumentException($"{nameof(max)} must be greater than {nameof(min)}.");

            decimal range = max - min;
            decimal wrapped = (value - min) % range;
            if (wrapped < 0m)
                wrapped += range;

            return wrapped + min;
        }

        #endregion Wrap

        #region PingPong

        /// <summary>
        /// Oscillates between 0 and <paramref name="length"/> as <paramref name="t"/> increases — ramping up to
        /// <paramref name="length"/>, back down to 0, and repeating. Handy for back-and-forth animation without
        /// tracking direction.
        /// </summary>
        /// <param name="t">The (typically increasing) input value.</param>
        /// <param name="length">The peak of the oscillation. Must be greater than zero.</param>
        /// <returns>A value in [0, <paramref name="length"/>].</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="length"/> is not greater than zero.</exception>
        public static float PingPong(float t, float length) {
            if (length <= 0f)
                throw new ArgumentException("Length must be greater than zero.", nameof(length));

            float wrapped = Wrap(t, 0f, 2f * length);
            return length - Math.Abs(wrapped - length);
        }

        /// <inheritdoc cref="PingPong(float, float)"/>
        public static double PingPong(double t, double length) {
            if (length <= 0d)
                throw new ArgumentException("Length must be greater than zero.", nameof(length));

            double wrapped = Wrap(t, 0d, 2d * length);
            return length - Math.Abs(wrapped - length);
        }

        #endregion PingPong
    }
}