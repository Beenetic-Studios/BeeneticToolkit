namespace BeeneticToolkit.Numerics {

    /// <summary>
    /// A single entry point for the toolkit's scalar math helpers — a <c>Mathf</c>-style companion for plain
    /// .NET and Unity. Groups interpolation, remapping, clamping/normalization, angle math, rounding, and
    /// spline helpers under one discoverable type. Most methods are overloaded for <see cref="float"/>,
    /// <see cref="double"/>, and (where it makes sense) <see cref="decimal"/>.
    /// </summary>
    /// <remarks>
    /// The implementation is split across several files by topic (<c>MathKit.Interpolation.cs</c>,
    /// <c>MathKit.Angles.cs</c>, etc.) but is a single class. Easing curves live in <see cref="EasingUtils"/>
    /// (surfaced here via <see cref="Ease(EasingType, float)"/>); integral mapping lives in
    /// <see cref="IntegralMappingExtensions"/>. Unless a method documents otherwise, non-finite inputs
    /// (<see cref="float.NaN"/>, infinities) are not specially handled and propagate through the result.
    /// </remarks>
    public static partial class MathKit {
    }
}
