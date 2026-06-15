namespace BeeneticToolkit.Numerics {

    // Discoverable hook for the easing curves; the full catalog lives in EasingUtils.
    public static partial class MathKit {

        /// <summary>
        /// Evaluates the easing curve identified by <paramref name="type"/> at <paramref name="t"/>. The full set
        /// of named curves (e.g. <c>EasingUtils.OutBack</c>) lives in <see cref="EasingUtils"/>.
        /// </summary>
        /// <param name="type">The easing curve to apply.</param>
        /// <param name="t">The progress, expected in <c>[0, 1]</c>.</param>
        /// <returns>The eased value.</returns>
        public static double Ease(EasingType type, double t) => EasingUtils.Ease(type, t);

        /// <inheritdoc cref="Ease(EasingType, double)"/>
        public static float Ease(EasingType type, float t) => EasingUtils.Ease(type, t);

        /// <summary>Eases between two values: returns <paramref name="from"/> at <c>t = 0</c> and <paramref name="to"/> at <c>t = 1</c>.</summary>
        /// <param name="type">The easing curve to apply.</param>
        /// <param name="from">The start value.</param>
        /// <param name="to">The end value.</param>
        /// <param name="t">The progress, expected in <c>[0, 1]</c>. Not clamped, so overshooting curves overshoot the endpoints.</param>
        /// <returns>The eased interpolation between <paramref name="from"/> and <paramref name="to"/>.</returns>
        public static double Ease(EasingType type, double from, double to, double t) => EasingUtils.Ease(type, from, to, t);

        /// <inheritdoc cref="Ease(EasingType, double, double, double)"/>
        public static float Ease(EasingType type, float from, float to, float t) => EasingUtils.Ease(type, from, to, t);
    }
}
