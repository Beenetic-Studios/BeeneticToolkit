using System;

namespace BeeneticToolkit.Numerics {

    /// <summary>
    /// The standard (Penner) easing curves used for tweening and animation. Each function maps an input
    /// <c>t</c> in <c>[0, 1]</c> to an eased progress value — usually in <c>[0, 1]</c>, though <c>Back</c> and
    /// <c>Elastic</c> intentionally overshoot. Combine with a lerp, or use the <see cref="Ease(EasingType, float)"/>
    /// dispatcher to pick a curve at runtime.
    /// </summary>
    /// <remarks>
    /// Functions are pure and do <b>not</b> clamp <c>t</c>; pass values in <c>[0, 1]</c>. Provided for
    /// <see cref="float"/> and <see cref="double"/> (the float overloads compute in double for accuracy);
    /// <see cref="decimal"/> is omitted as these curves are inherently transcendental.
    /// </remarks>
    public static class EasingUtils {

        private const double BackC1 = 1.70158;
        private const double BackC2 = BackC1 * 1.525;
        private const double BackC3 = BackC1 + 1.0;
        private const double ElasticC4 = (2.0 * Math.PI) / 3.0;
        private const double ElasticC5 = (2.0 * Math.PI) / 4.5;
        private const double BounceN1 = 7.5625;
        private const double BounceD1 = 2.75;

        #region Linear

        /// <summary>Linear (identity) easing.</summary>
        public static double Linear(double t) => t;

        /// <inheritdoc cref="Linear(double)"/>
        public static float Linear(float t) => t;

        #endregion Linear

        #region Sine

        /// <summary>Sinusoidal ease in.</summary>
        public static double InSine(double t) => 1.0 - Math.Cos((t * Math.PI) / 2.0);

        /// <summary>Sinusoidal ease out.</summary>
        public static double OutSine(double t) => Math.Sin((t * Math.PI) / 2.0);

        /// <summary>Sinusoidal ease in and out.</summary>
        public static double InOutSine(double t) => -(Math.Cos(Math.PI * t) - 1.0) / 2.0;

        /// <inheritdoc cref="InSine(double)"/>
        public static float InSine(float t) => (float)InSine((double)t);
        /// <inheritdoc cref="OutSine(double)"/>
        public static float OutSine(float t) => (float)OutSine((double)t);
        /// <inheritdoc cref="InOutSine(double)"/>
        public static float InOutSine(float t) => (float)InOutSine((double)t);

        #endregion Sine

        #region Quad

        /// <summary>Quadratic (t²) ease in.</summary>
        public static double InQuad(double t) => t * t;

        /// <summary>Quadratic (t²) ease out.</summary>
        public static double OutQuad(double t) => 1.0 - (1.0 - t) * (1.0 - t);

        /// <summary>Quadratic (t²) ease in and out.</summary>
        public static double InOutQuad(double t) =>
            t < 0.5 ? 2.0 * t * t : 1.0 - Math.Pow(-2.0 * t + 2.0, 2.0) / 2.0;

        /// <inheritdoc cref="InQuad(double)"/>
        public static float InQuad(float t) => (float)InQuad((double)t);
        /// <inheritdoc cref="OutQuad(double)"/>
        public static float OutQuad(float t) => (float)OutQuad((double)t);
        /// <inheritdoc cref="InOutQuad(double)"/>
        public static float InOutQuad(float t) => (float)InOutQuad((double)t);

        #endregion Quad

        #region Cubic

        /// <summary>Cubic (t³) ease in.</summary>
        public static double InCubic(double t) => t * t * t;

        /// <summary>Cubic (t³) ease out.</summary>
        public static double OutCubic(double t) => 1.0 - Math.Pow(1.0 - t, 3.0);

        /// <summary>Cubic (t³) ease in and out.</summary>
        public static double InOutCubic(double t) =>
            t < 0.5 ? 4.0 * t * t * t : 1.0 - Math.Pow(-2.0 * t + 2.0, 3.0) / 2.0;

        /// <inheritdoc cref="InCubic(double)"/>
        public static float InCubic(float t) => (float)InCubic((double)t);
        /// <inheritdoc cref="OutCubic(double)"/>
        public static float OutCubic(float t) => (float)OutCubic((double)t);
        /// <inheritdoc cref="InOutCubic(double)"/>
        public static float InOutCubic(float t) => (float)InOutCubic((double)t);

        #endregion Cubic

        #region Quart

        /// <summary>Quartic (t⁴) ease in.</summary>
        public static double InQuart(double t) => t * t * t * t;

        /// <summary>Quartic (t⁴) ease out.</summary>
        public static double OutQuart(double t) => 1.0 - Math.Pow(1.0 - t, 4.0);

        /// <summary>Quartic (t⁴) ease in and out.</summary>
        public static double InOutQuart(double t) =>
            t < 0.5 ? 8.0 * t * t * t * t : 1.0 - Math.Pow(-2.0 * t + 2.0, 4.0) / 2.0;

        /// <inheritdoc cref="InQuart(double)"/>
        public static float InQuart(float t) => (float)InQuart((double)t);
        /// <inheritdoc cref="OutQuart(double)"/>
        public static float OutQuart(float t) => (float)OutQuart((double)t);
        /// <inheritdoc cref="InOutQuart(double)"/>
        public static float InOutQuart(float t) => (float)InOutQuart((double)t);

        #endregion Quart

        #region Quint

        /// <summary>Quintic (t⁵) ease in.</summary>
        public static double InQuint(double t) => t * t * t * t * t;

        /// <summary>Quintic (t⁵) ease out.</summary>
        public static double OutQuint(double t) => 1.0 - Math.Pow(1.0 - t, 5.0);

        /// <summary>Quintic (t⁵) ease in and out.</summary>
        public static double InOutQuint(double t) =>
            t < 0.5 ? 16.0 * t * t * t * t * t : 1.0 - Math.Pow(-2.0 * t + 2.0, 5.0) / 2.0;

        /// <inheritdoc cref="InQuint(double)"/>
        public static float InQuint(float t) => (float)InQuint((double)t);
        /// <inheritdoc cref="OutQuint(double)"/>
        public static float OutQuint(float t) => (float)OutQuint((double)t);
        /// <inheritdoc cref="InOutQuint(double)"/>
        public static float InOutQuint(float t) => (float)InOutQuint((double)t);

        #endregion Quint

        #region Expo

        /// <summary>Exponential ease in.</summary>
        public static double InExpo(double t) => t == 0.0 ? 0.0 : Math.Pow(2.0, 10.0 * t - 10.0);

        /// <summary>Exponential ease out.</summary>
        public static double OutExpo(double t) => t == 1.0 ? 1.0 : 1.0 - Math.Pow(2.0, -10.0 * t);

        /// <summary>Exponential ease in and out.</summary>
        public static double InOutExpo(double t) {
            if (t == 0.0) return 0.0;
            if (t == 1.0) return 1.0;
            return t < 0.5
                ? Math.Pow(2.0, 20.0 * t - 10.0) / 2.0
                : (2.0 - Math.Pow(2.0, -20.0 * t + 10.0)) / 2.0;
        }

        /// <inheritdoc cref="InExpo(double)"/>
        public static float InExpo(float t) => (float)InExpo((double)t);
        /// <inheritdoc cref="OutExpo(double)"/>
        public static float OutExpo(float t) => (float)OutExpo((double)t);
        /// <inheritdoc cref="InOutExpo(double)"/>
        public static float InOutExpo(float t) => (float)InOutExpo((double)t);

        #endregion Expo

        #region Circ

        /// <summary>Circular ease in.</summary>
        public static double InCirc(double t) => 1.0 - Math.Sqrt(1.0 - Math.Pow(t, 2.0));

        /// <summary>Circular ease out.</summary>
        public static double OutCirc(double t) => Math.Sqrt(1.0 - Math.Pow(t - 1.0, 2.0));

        /// <summary>Circular ease in and out.</summary>
        public static double InOutCirc(double t) =>
            t < 0.5
                ? (1.0 - Math.Sqrt(1.0 - Math.Pow(2.0 * t, 2.0))) / 2.0
                : (Math.Sqrt(1.0 - Math.Pow(-2.0 * t + 2.0, 2.0)) + 1.0) / 2.0;

        /// <inheritdoc cref="InCirc(double)"/>
        public static float InCirc(float t) => (float)InCirc((double)t);
        /// <inheritdoc cref="OutCirc(double)"/>
        public static float OutCirc(float t) => (float)OutCirc((double)t);
        /// <inheritdoc cref="InOutCirc(double)"/>
        public static float InOutCirc(float t) => (float)InOutCirc((double)t);

        #endregion Circ

        #region Back

        /// <summary>Back ease in — overshoots slightly below zero before starting.</summary>
        public static double InBack(double t) => BackC3 * t * t * t - BackC1 * t * t;

        /// <summary>Back ease out — overshoots slightly past one before settling.</summary>
        public static double OutBack(double t) =>
            1.0 + BackC3 * Math.Pow(t - 1.0, 3.0) + BackC1 * Math.Pow(t - 1.0, 2.0);

        /// <summary>Back ease in and out — overshoots at both ends.</summary>
        public static double InOutBack(double t) =>
            t < 0.5
                ? (Math.Pow(2.0 * t, 2.0) * ((BackC2 + 1.0) * 2.0 * t - BackC2)) / 2.0
                : (Math.Pow(2.0 * t - 2.0, 2.0) * ((BackC2 + 1.0) * (t * 2.0 - 2.0) + BackC2) + 2.0) / 2.0;

        /// <inheritdoc cref="InBack(double)"/>
        public static float InBack(float t) => (float)InBack((double)t);
        /// <inheritdoc cref="OutBack(double)"/>
        public static float OutBack(float t) => (float)OutBack((double)t);
        /// <inheritdoc cref="InOutBack(double)"/>
        public static float InOutBack(float t) => (float)InOutBack((double)t);

        #endregion Back

        #region Elastic

        /// <summary>Elastic ease in — springy overshoot near the start.</summary>
        public static double InElastic(double t) {
            if (t == 0.0) return 0.0;
            if (t == 1.0) return 1.0;
            return -Math.Pow(2.0, 10.0 * t - 10.0) * Math.Sin((t * 10.0 - 10.75) * ElasticC4);
        }

        /// <summary>Elastic ease out — springy overshoot near the end.</summary>
        public static double OutElastic(double t) {
            if (t == 0.0) return 0.0;
            if (t == 1.0) return 1.0;
            return Math.Pow(2.0, -10.0 * t) * Math.Sin((t * 10.0 - 0.75) * ElasticC4) + 1.0;
        }

        /// <summary>Elastic ease in and out — springy overshoot at both ends.</summary>
        public static double InOutElastic(double t) {
            if (t == 0.0) return 0.0;
            if (t == 1.0) return 1.0;
            return t < 0.5
                ? -(Math.Pow(2.0, 20.0 * t - 10.0) * Math.Sin((20.0 * t - 11.125) * ElasticC5)) / 2.0
                : (Math.Pow(2.0, -20.0 * t + 10.0) * Math.Sin((20.0 * t - 11.125) * ElasticC5)) / 2.0 + 1.0;
        }

        /// <inheritdoc cref="InElastic(double)"/>
        public static float InElastic(float t) => (float)InElastic((double)t);
        /// <inheritdoc cref="OutElastic(double)"/>
        public static float OutElastic(float t) => (float)OutElastic((double)t);
        /// <inheritdoc cref="InOutElastic(double)"/>
        public static float InOutElastic(float t) => (float)InOutElastic((double)t);

        #endregion Elastic

        #region Bounce

        /// <summary>Bounce ease in.</summary>
        public static double InBounce(double t) => 1.0 - OutBounce(1.0 - t);

        /// <summary>Bounce ease out.</summary>
        public static double OutBounce(double t) {
            if (t < 1.0 / BounceD1)
                return BounceN1 * t * t;
            if (t < 2.0 / BounceD1) {
                t -= 1.5 / BounceD1;
                return BounceN1 * t * t + 0.75;
            }
            if (t < 2.5 / BounceD1) {
                t -= 2.25 / BounceD1;
                return BounceN1 * t * t + 0.9375;
            }

            t -= 2.625 / BounceD1;
            return BounceN1 * t * t + 0.984375;
        }

        /// <summary>Bounce ease in and out.</summary>
        public static double InOutBounce(double t) =>
            t < 0.5
                ? (1.0 - OutBounce(1.0 - 2.0 * t)) / 2.0
                : (1.0 + OutBounce(2.0 * t - 1.0)) / 2.0;

        /// <inheritdoc cref="InBounce(double)"/>
        public static float InBounce(float t) => (float)InBounce((double)t);
        /// <inheritdoc cref="OutBounce(double)"/>
        public static float OutBounce(float t) => (float)OutBounce((double)t);
        /// <inheritdoc cref="InOutBounce(double)"/>
        public static float InOutBounce(float t) => (float)InOutBounce((double)t);

        #endregion Bounce

        #region Dispatch

        /// <summary>Evaluates the easing curve identified by <paramref name="type"/> at <paramref name="t"/>.</summary>
        /// <param name="type">The easing curve to apply.</param>
        /// <param name="t">The progress, expected in <c>[0, 1]</c>.</param>
        /// <returns>The eased value.</returns>
        public static double Ease(EasingType type, double t) {
            switch (type) {
                case EasingType.Linear: return t;
                case EasingType.InSine: return InSine(t);
                case EasingType.OutSine: return OutSine(t);
                case EasingType.InOutSine: return InOutSine(t);
                case EasingType.InQuad: return InQuad(t);
                case EasingType.OutQuad: return OutQuad(t);
                case EasingType.InOutQuad: return InOutQuad(t);
                case EasingType.InCubic: return InCubic(t);
                case EasingType.OutCubic: return OutCubic(t);
                case EasingType.InOutCubic: return InOutCubic(t);
                case EasingType.InQuart: return InQuart(t);
                case EasingType.OutQuart: return OutQuart(t);
                case EasingType.InOutQuart: return InOutQuart(t);
                case EasingType.InQuint: return InQuint(t);
                case EasingType.OutQuint: return OutQuint(t);
                case EasingType.InOutQuint: return InOutQuint(t);
                case EasingType.InExpo: return InExpo(t);
                case EasingType.OutExpo: return OutExpo(t);
                case EasingType.InOutExpo: return InOutExpo(t);
                case EasingType.InCirc: return InCirc(t);
                case EasingType.OutCirc: return OutCirc(t);
                case EasingType.InOutCirc: return InOutCirc(t);
                case EasingType.InBack: return InBack(t);
                case EasingType.OutBack: return OutBack(t);
                case EasingType.InOutBack: return InOutBack(t);
                case EasingType.InElastic: return InElastic(t);
                case EasingType.OutElastic: return OutElastic(t);
                case EasingType.InOutElastic: return InOutElastic(t);
                case EasingType.InBounce: return InBounce(t);
                case EasingType.OutBounce: return OutBounce(t);
                case EasingType.InOutBounce: return InOutBounce(t);
                default: throw new ArgumentOutOfRangeException(nameof(type), type, "Unknown easing type.");
            }
        }

        /// <inheritdoc cref="Ease(EasingType, double)"/>
        public static float Ease(EasingType type, float t) => (float)Ease(type, (double)t);

        /// <summary>Eases between two values: returns <paramref name="from"/> at <c>t = 0</c> and <paramref name="to"/> at <c>t = 1</c>.</summary>
        /// <param name="type">The easing curve to apply.</param>
        /// <param name="from">The start value.</param>
        /// <param name="to">The end value.</param>
        /// <param name="t">The progress, expected in <c>[0, 1]</c>. Not clamped, so overshooting curves overshoot the endpoints.</param>
        /// <returns>The eased interpolation between <paramref name="from"/> and <paramref name="to"/>.</returns>
        public static double Ease(EasingType type, double from, double to, double t) => from + (to - from) * Ease(type, t);

        /// <inheritdoc cref="Ease(EasingType, double, double, double)"/>
        public static float Ease(EasingType type, float from, float to, float t) => from + (to - from) * Ease(type, t);

        #endregion Dispatch
    }
}
