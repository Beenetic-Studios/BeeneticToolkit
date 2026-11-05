namespace BeeneticToolkit.Numerics {

    /// <summary>
    /// WCAG 2 color contrast: relative luminance, contrast ratio, and two derivations built on them. <see cref="InkOn"/>
    /// pushes a color used as text away from its background until it clears a ratio; <see cref="MarkOn(RgbColor)"/>
    /// picks a legible glyph color (a check mark, an icon) to draw on a filled shape.
    /// </summary>
    /// <remarks>
    /// Typical use is a theme: author each status or accent color once as a fill, and derive the text version per
    /// surface with <see cref="InkOn"/> instead of hand-picking (and later re-auditing) one per theme.
    /// </remarks>
    public static class ColorContrast {

        /// <summary>WCAG AA minimum for normal text (success criterion 1.4.3).</summary>
        public const float TextRatio = 4.5f;

        /// <summary>WCAG AA minimum for large text (18pt, or 14pt bold).</summary>
        public const float LargeTextRatio = 3f;

        /// <summary>WCAG AAA minimum for normal text (success criterion 1.4.6).</summary>
        public const float EnhancedTextRatio = 7f;

        /// <summary>WCAG minimum for graphical objects and UI component boundaries (success criterion 1.4.11).</summary>
        public const float GraphicRatio = 3f;

        private const float RedWeight = 0.2126f;
        private const float GreenWeight = 0.7152f;
        private const float BlueWeight = 0.0722f;
        private const float FlareOffset = 0.05f;
        private const float DarkMarkLevel = 0.1f;

        // Bisection steps for InkOn: 12 halvings put the blend within 1/4096 of the least adjustment that clears
        // the target, finer than an 8-bit channel can show.
        private const int InkSearchSteps = 12;

        /// <summary>The near-black glyph <see cref="MarkOn(RgbColor)"/> falls back to when white fails on a light fill.</summary>
        public static RgbColor DarkMark => new RgbColor(DarkMarkLevel, DarkMarkLevel, DarkMarkLevel);

        /// <summary>
        /// The WCAG relative luminance of a color: its sRGB channels decoded to linear light and weighted
        /// 0.2126 R + 0.7152 G + 0.0722 B. 0 for black, 1 for white.
        /// </summary>
        /// <remarks>
        /// Not the same number as the plain weighted sum of the encoded channels (which skips the decode). Contrast
        /// ratios need this gamma-correct version.
        /// </remarks>
        public static float RelativeLuminance(RgbColor color) {
            return RedWeight * RgbColor.SrgbToLinear(color.R)
                + GreenWeight * RgbColor.SrgbToLinear(color.G)
                + BlueWeight * RgbColor.SrgbToLinear(color.B);
        }

        /// <summary>
        /// The WCAG 2 contrast ratio between two colors, from 1 (identical luminance) to 21 (black on white).
        /// Symmetric in its arguments; alpha is ignored.
        /// </summary>
        public static float ContrastRatio(RgbColor a, RgbColor b) {
            float la = RelativeLuminance(a);
            float lb = RelativeLuminance(b);
            return la > lb ? (la + FlareOffset) / (lb + FlareOffset) : (lb + FlareOffset) / (la + FlareOffset);
        }

        /// <summary>
        /// Adjusts <paramref name="ink"/> so it reads as text on <paramref name="background"/> at
        /// <paramref name="targetRatio"/> or better, changing it as little as possible.
        /// </summary>
        /// <remarks>
        /// Returns <paramref name="ink"/> untouched when it already clears the target. Otherwise it blends the ink
        /// toward black or white (whichever contrasts more with the background) and binary-searches for the
        /// smallest blend that clears the target, so as much of the original hue survives as the target allows. If
        /// even pure black or white falls short (a mid-grey background with a high target), that extreme is
        /// returned as the best available. The ink's alpha is kept.
        /// </remarks>
        public static RgbColor InkOn(RgbColor ink, RgbColor background, float targetRatio) {
            if (ContrastRatio(ink, background) >= targetRatio) {
                return ink;
            }

            RgbColor extreme = ContrastRatio(RgbColor.Black, background) >= ContrastRatio(RgbColor.White, background)
                ? RgbColor.Black
                : RgbColor.White;
            RgbColor away = extreme.WithAlpha(ink.A);

            // Blending toward the extreme first closes on the background's luminance (if the ink starts on the far
            // side of it) and then only moves away, so "clears the target" flips from false to true exactly once
            // along the blend. That makes a bisection on the blend factor sound.
            float lo = 0f;
            float hi = 1f;
            for (int i = 0; i < InkSearchSteps; i++) {
                float mid = 0.5f * (lo + hi);
                if (ContrastRatio(RgbColor.Lerp(ink, away, mid), background) >= targetRatio) {
                    hi = mid;
                } else {
                    lo = mid;
                }
            }
            return RgbColor.Lerp(ink, away, hi);
        }

        /// <summary>
        /// The glyph color to draw on <paramref name="fill"/>: white while it clears <see cref="GraphicRatio"/>
        /// against the fill, otherwise <see cref="DarkMark"/> (or white again if neither clears and white contrasts more).
        /// </summary>
        public static RgbColor MarkOn(RgbColor fill) {
            return MarkOn(fill, RgbColor.White, DarkMark, GraphicRatio);
        }

        /// <summary>
        /// The glyph color to draw on <paramref name="fill"/>: <paramref name="preferred"/> while it clears
        /// <paramref name="minimumRatio"/>, otherwise whichever of <paramref name="preferred"/> and
        /// <paramref name="fallback"/> contrasts more with the fill.
        /// </summary>
        public static RgbColor MarkOn(RgbColor fill, RgbColor preferred, RgbColor fallback, float minimumRatio) {
            float preferredRatio = ContrastRatio(preferred, fill);
            if (preferredRatio >= minimumRatio) {
                return preferred;
            }
            return ContrastRatio(fallback, fill) > preferredRatio ? fallback : preferred;
        }
    }
}
