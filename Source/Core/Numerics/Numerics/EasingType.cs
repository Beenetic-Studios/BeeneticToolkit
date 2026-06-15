namespace BeeneticToolkit.Numerics {

    /// <summary>
    /// Identifies an easing curve, for selecting one at runtime via <see cref="EasingUtils.Ease(EasingType, float)"/>
    /// (e.g. storing the curve choice in data or an inspector field).
    /// </summary>
    public enum EasingType {

        /// <summary>No easing — the value changes at a constant rate.</summary>
        Linear,

        /// <summary>Sinusoidal ease in.</summary>
        InSine,
        /// <summary>Sinusoidal ease out.</summary>
        OutSine,
        /// <summary>Sinusoidal ease in and out.</summary>
        InOutSine,

        /// <summary>Quadratic (t²) ease in.</summary>
        InQuad,
        /// <summary>Quadratic (t²) ease out.</summary>
        OutQuad,
        /// <summary>Quadratic (t²) ease in and out.</summary>
        InOutQuad,

        /// <summary>Cubic (t³) ease in.</summary>
        InCubic,
        /// <summary>Cubic (t³) ease out.</summary>
        OutCubic,
        /// <summary>Cubic (t³) ease in and out.</summary>
        InOutCubic,

        /// <summary>Quartic (t⁴) ease in.</summary>
        InQuart,
        /// <summary>Quartic (t⁴) ease out.</summary>
        OutQuart,
        /// <summary>Quartic (t⁴) ease in and out.</summary>
        InOutQuart,

        /// <summary>Quintic (t⁵) ease in.</summary>
        InQuint,
        /// <summary>Quintic (t⁵) ease out.</summary>
        OutQuint,
        /// <summary>Quintic (t⁵) ease in and out.</summary>
        InOutQuint,

        /// <summary>Exponential ease in.</summary>
        InExpo,
        /// <summary>Exponential ease out.</summary>
        OutExpo,
        /// <summary>Exponential ease in and out.</summary>
        InOutExpo,

        /// <summary>Circular ease in.</summary>
        InCirc,
        /// <summary>Circular ease out.</summary>
        OutCirc,
        /// <summary>Circular ease in and out.</summary>
        InOutCirc,

        /// <summary>Back ease in (overshoots slightly before starting).</summary>
        InBack,
        /// <summary>Back ease out (overshoots slightly past the end).</summary>
        OutBack,
        /// <summary>Back ease in and out (overshoots at both ends).</summary>
        InOutBack,

        /// <summary>Elastic ease in (springy overshoot at the start).</summary>
        InElastic,
        /// <summary>Elastic ease out (springy overshoot at the end).</summary>
        OutElastic,
        /// <summary>Elastic ease in and out (springy overshoot at both ends).</summary>
        InOutElastic,

        /// <summary>Bounce ease in.</summary>
        InBounce,
        /// <summary>Bounce ease out.</summary>
        OutBounce,
        /// <summary>Bounce ease in and out.</summary>
        InOutBounce,
    }
}
