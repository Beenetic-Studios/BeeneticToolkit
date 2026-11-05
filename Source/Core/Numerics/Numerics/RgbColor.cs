using System;

namespace BeeneticToolkit.Numerics {

    /// <summary>
    /// An immutable color with sRGB-encoded (gamma-corrected) float channels, nominally in [0, 1], plus alpha. An
    /// engine-free stand-in for Unity's <c>Color</c> so color math such as <see cref="ColorContrast"/> stays
    /// headless; convert to and from your engine's color type at the boundary.
    /// </summary>
    /// <remarks>
    /// Channels are not clamped. The contrast functions assume [0, 1]; out-of-range (HDR) values pass through.
    /// </remarks>
    public readonly struct RgbColor : IEquatable<RgbColor> {

        private const float SrgbLinearThreshold = 0.04045f;
        private const float LinearSrgbThreshold = 0.0031308f;
        private const float LinearSlope = 12.92f;
        private const float Gamma = 2.4f;
        private const float GammaOffset = 0.055f;
        private const float GammaScale = 1.055f;
        private const float ByteMax = 255f;

        /// <summary>The red channel (sRGB-encoded).</summary>
        public float R { get; }

        /// <summary>The green channel (sRGB-encoded).</summary>
        public float G { get; }

        /// <summary>The blue channel (sRGB-encoded).</summary>
        public float B { get; }

        /// <summary>The alpha channel. Contrast math ignores it.</summary>
        public float A { get; }

        /// <summary>Creates a color from sRGB-encoded channels.</summary>
        public RgbColor(float r, float g, float b, float a = 1f) {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        /// <summary>Opaque black.</summary>
        public static RgbColor Black => new RgbColor(0f, 0f, 0f);

        /// <summary>Opaque white.</summary>
        public static RgbColor White => new RgbColor(1f, 1f, 1f);

        /// <summary>Creates an opaque color from a packed 24-bit <c>0xRRGGBB</c> value, as written in CSS hex.</summary>
        public static RgbColor FromRgb24(int rgb) {
            return new RgbColor(((rgb >> 16) & 0xFF) / ByteMax, ((rgb >> 8) & 0xFF) / ByteMax, (rgb & 0xFF) / ByteMax);
        }

        /// <summary>Returns this color with a different alpha.</summary>
        public RgbColor WithAlpha(float a) => new RgbColor(R, G, B, a);

        /// <summary>Interpolates all four channels in sRGB space, with <paramref name="t"/> clamped to [0, 1].</summary>
        public static RgbColor Lerp(RgbColor a, RgbColor b, float t) {
            float k = MathKit.Clamp01(t);
            return new RgbColor(a.R + (b.R - a.R) * k, a.G + (b.G - a.G) * k, a.B + (b.B - a.B) * k, a.A + (b.A - a.A) * k);
        }

        /// <summary>Decodes one sRGB channel to linear light (IEC 61966-2-1, the curve WCAG 2 uses).</summary>
        public static float SrgbToLinear(float channel) {
            return channel <= SrgbLinearThreshold
                ? channel / LinearSlope
                : MathF.Pow((channel + GammaOffset) / GammaScale, Gamma);
        }

        /// <summary>Encodes one linear-light channel back to sRGB; the inverse of <see cref="SrgbToLinear"/>.</summary>
        public static float LinearToSrgb(float channel) {
            return channel <= LinearSrgbThreshold
                ? channel * LinearSlope
                : GammaScale * MathF.Pow(channel, 1f / Gamma) - GammaOffset;
        }

        #region Equality

        /// <inheritdoc/>
        public bool Equals(RgbColor other) => R.Equals(other.R) && G.Equals(other.G) && B.Equals(other.B) && A.Equals(other.A);

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is RgbColor other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(R, G, B, A);

        /// <summary>Exact channel-wise equality.</summary>
        public static bool operator ==(RgbColor left, RgbColor right) => left.Equals(right);

        /// <summary>Exact channel-wise inequality.</summary>
        public static bool operator !=(RgbColor left, RgbColor right) => !left.Equals(right);

        #endregion Equality

        /// <inheritdoc/>
        public override string ToString() => $"RgbColor({R:0.###}, {G:0.###}, {B:0.###}, {A:0.###})";
    }
}
