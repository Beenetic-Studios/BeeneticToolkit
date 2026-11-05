using BeeneticToolkit.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeeneticToolkit.Tests.Numerics {

    [TestClass]
    public class ColorContrastTests {

        // Published WCAG ratios are quoted to two decimals.
        private const float RatioTolerance = 0.005f;

        // An ink theme bar and a glyph bar taken from a shipping game's theme (text on a card at 4:1, a white mark
        // on a badge fill at 3:1), with its seven fixed status fills.
        private const float GameInkRatio = 4f;
        private const float GameInkCeiling = 4.05f;

        private static readonly RgbColor[] GameFills = {
            new RgbColor(0.55f, 0.45f, 0.95f),
            new RgbColor(0.20f, 0.48f, 0.80f),
            new RgbColor(0.00f, 0.62f, 0.60f),
            new RgbColor(0.20f, 0.62f, 0.36f),
            new RgbColor(0.90f, 0.62f, 0.15f),
            new RgbColor(0.8706f, 0.4604f, 0.1878f),
            new RgbColor(0.83f, 0.24f, 0.24f),
        };

        #region RgbColor

        [TestMethod]
        public void FromRgb24_UnpacksChannels() {
            RgbColor c = RgbColor.FromRgb24(0xFF8000);
            Assert.AreEqual(1f, c.R);
            Assert.AreEqual(128f / 255f, c.G, NumericsHelpers.FLOAT_TOLERANCE);
            Assert.AreEqual(0f, c.B);
            Assert.AreEqual(1f, c.A);
        }

        [TestMethod]
        public void SrgbToLinear_RoundTripsThroughLinearToSrgb() {
            for (int i = 0; i <= 255; i++) {
                float channel = i / 255f;
                Assert.AreEqual(channel, RgbColor.LinearToSrgb(RgbColor.SrgbToLinear(channel)), 1e-5f, $"channel {i}");
            }
        }

        [TestMethod]
        public void SrgbToLinear_UsesLinearSegmentNearBlack() {
            Assert.AreEqual(0.04f / 12.92f, RgbColor.SrgbToLinear(0.04f), NumericsHelpers.FLOAT_TOLERANCE);
            Assert.AreEqual(0.21586f, RgbColor.SrgbToLinear(128f / 255f), 1e-5f);
        }

        [TestMethod]
        public void Lerp_ClampsFactorAndBlendsAlpha() {
            RgbColor mid = RgbColor.Lerp(RgbColor.Black.WithAlpha(0f), RgbColor.White, 0.5f);
            Assert.AreEqual(new RgbColor(0.5f, 0.5f, 0.5f, 0.5f), mid);
            Assert.AreEqual(RgbColor.White, RgbColor.Lerp(RgbColor.Black, RgbColor.White, 2f));
        }

        #endregion RgbColor

        #region Luminance And Ratio

        [TestMethod]
        public void RelativeLuminance_EndpointsAndMidGrey() {
            Assert.AreEqual(0f, ColorContrast.RelativeLuminance(RgbColor.Black));
            Assert.AreEqual(1f, ColorContrast.RelativeLuminance(RgbColor.White), NumericsHelpers.FLOAT_TOLERANCE);
            Assert.AreEqual(0.21586f, ColorContrast.RelativeLuminance(RgbColor.FromRgb24(0x808080)), 1e-5f);
        }

        // Reference pairs as published by WCAG checkers (WebAIM and the W3C understanding docs).
        [DataTestMethod]
        [DataRow(0x000000, 0xFFFFFF, 21f, DisplayName = "black on white")]
        [DataRow(0xFFFFFF, 0xFFFFFF, 1f, DisplayName = "white on white")]
        [DataRow(0x767676, 0xFFFFFF, 4.54f, DisplayName = "lightest AA grey on white")]
        [DataRow(0x777777, 0xFFFFFF, 4.48f, DisplayName = "first failing grey on white")]
        [DataRow(0x595959, 0xFFFFFF, 7.00f, DisplayName = "AAA grey on white")]
        [DataRow(0x949494, 0xFFFFFF, 3.03f, DisplayName = "lightest 3:1 grey on white")]
        [DataRow(0xFF0000, 0xFFFFFF, 4.00f, DisplayName = "red on white")]
        [DataRow(0x0000FF, 0xFFFFFF, 8.59f, DisplayName = "blue on white")]
        [DataRow(0x00FF00, 0xFFFFFF, 1.37f, DisplayName = "lime on white")]
        public void ContrastRatio_MatchesPublishedReferencePairs(int foreground, int background, float expected) {
            float ratio = ColorContrast.ContrastRatio(RgbColor.FromRgb24(foreground), RgbColor.FromRgb24(background));
            Assert.AreEqual(expected, ratio, RatioTolerance);
        }

        [TestMethod]
        public void ContrastRatio_IsSymmetricAndIgnoresAlpha() {
            RgbColor a = RgbColor.FromRgb24(0x337ACC);
            RgbColor b = RgbColor.FromRgb24(0xF5F0E6);
            Assert.AreEqual(ColorContrast.ContrastRatio(a, b), ColorContrast.ContrastRatio(b, a));
            Assert.AreEqual(ColorContrast.ContrastRatio(a, b), ColorContrast.ContrastRatio(a.WithAlpha(0.2f), b));
        }

        [TestMethod]
        public void ContrastRatio_AaBoundaryFallsBetween767676And777777() {
            RgbColor white = RgbColor.White;
            Assert.IsTrue(ColorContrast.ContrastRatio(RgbColor.FromRgb24(0x767676), white) >= ColorContrast.TextRatio);
            Assert.IsTrue(ColorContrast.ContrastRatio(RgbColor.FromRgb24(0x777777), white) < ColorContrast.TextRatio);
        }

        #endregion Luminance And Ratio

        #region InkOn

        [TestMethod]
        public void InkOn_AlreadyLegible_ReturnsInkUnchanged() {
            RgbColor ink = RgbColor.FromRgb24(0x1A1A1A);
            Assert.AreEqual(ink, ColorContrast.InkOn(ink, RgbColor.White, ColorContrast.TextRatio));
        }

        [TestMethod]
        public void InkOn_GameFillsOnWhite_ClearTheBarWithLeastAdjustment() {
            int adjusted = 0;
            foreach (RgbColor fill in GameFills) {
                RgbColor ink = ColorContrast.InkOn(fill.WithAlpha(0.8f), RgbColor.White, GameInkRatio);
                float ratio = ColorContrast.ContrastRatio(ink, RgbColor.White);
                Assert.IsTrue(ratio >= GameInkRatio, $"{fill} -> {ink} at {ratio}");
                if (ColorContrast.ContrastRatio(fill, RgbColor.White) >= GameInkRatio) {
                    Assert.AreEqual(fill.WithAlpha(0.8f), ink, $"{fill} already clears the bar and must come back untouched");
                    continue;
                }
                adjusted++;
                Assert.IsTrue(ratio < GameInkCeiling, $"{fill} -> {ink} overshot to {ratio}");
                Assert.IsTrue(ColorContrast.RelativeLuminance(ink) < ColorContrast.RelativeLuminance(fill), $"{fill} should darken");
                Assert.AreEqual(0.8f, ink.A, "alpha is kept");
            }
            Assert.IsTrue(adjusted >= 5, $"most of the ramp fails 4:1 on white as a fill; only {adjusted} were adjusted");
        }

        [TestMethod]
        public void InkOn_DarkInkOnDarkSurface_LightensTowardWhite() {
            RgbColor surface = RgbColor.FromRgb24(0x121212);
            RgbColor ink = ColorContrast.InkOn(RgbColor.FromRgb24(0x3D2B99), surface, ColorContrast.TextRatio);
            Assert.IsTrue(ColorContrast.ContrastRatio(ink, surface) >= ColorContrast.TextRatio);
            Assert.IsTrue(ColorContrast.RelativeLuminance(ink) > ColorContrast.RelativeLuminance(surface));
        }

        [TestMethod]
        public void InkOn_MidLuminanceSurface_PushesTowardWhicheverExtremeCanReachTheBar() {
            // Luminance ~0.30: white tops out near 3:1 here, black reaches ~7:1. A "darken only above 0.5" rule
            // would push toward white and could never reach 4:1.
            RgbColor surface = RgbColor.FromRgb24(0x959595);
            RgbColor ink = ColorContrast.InkOn(RgbColor.FromRgb24(0x8899AA), surface, GameInkRatio);
            Assert.IsTrue(ColorContrast.ContrastRatio(ink, surface) >= GameInkRatio);
        }

        [TestMethod]
        public void InkOn_InkOnFarSideOfBackground_StillFindsTheCrossing() {
            // A light ink on a slightly darker light surface must pass through the surface's luminance on its way to black.
            RgbColor surface = RgbColor.FromRgb24(0xE0E0E0);
            RgbColor ink = ColorContrast.InkOn(RgbColor.FromRgb24(0xFFF4C0), surface, ColorContrast.TextRatio);
            Assert.IsTrue(ColorContrast.ContrastRatio(ink, surface) >= ColorContrast.TextRatio);
            Assert.IsTrue(ColorContrast.RelativeLuminance(ink) < ColorContrast.RelativeLuminance(surface));
        }

        [TestMethod]
        public void InkOn_UnreachableTarget_ReturnsBestExtremeWithInkAlpha() {
            RgbColor surface = RgbColor.FromRgb24(0x808080);
            RgbColor ink = ColorContrast.InkOn(RgbColor.FromRgb24(0x7F7F7F).WithAlpha(0.5f), surface, ColorContrast.EnhancedTextRatio);
            Assert.AreEqual(RgbColor.Black.WithAlpha(0.5f), ink);
        }

        #endregion InkOn

        #region MarkOn

        [TestMethod]
        public void MarkOn_DarkFill_KeepsWhite() {
            Assert.AreEqual(RgbColor.White, ColorContrast.MarkOn(RgbColor.FromRgb24(0x1F4E8C)));
        }

        [TestMethod]
        public void MarkOn_BrightFillWhereWhiteVanishes_SwitchesToDarkMark() {
            // A bright success green that a white check sinks into (well under 3:1).
            RgbColor fill = RgbColor.FromRgb24(0x5CE68A);
            Assert.IsTrue(ColorContrast.ContrastRatio(RgbColor.White, fill) < ColorContrast.GraphicRatio);
            Assert.AreEqual(ColorContrast.DarkMark, ColorContrast.MarkOn(fill));
        }

        [TestMethod]
        public void MarkOn_NeitherClears_PicksTheHigherContrast() {
            RgbColor fill = RgbColor.FromRgb24(0x808080);
            RgbColor light = RgbColor.FromRgb24(0xEEEEEE);
            RgbColor dark = RgbColor.FromRgb24(0x202020);
            RgbColor mark = ColorContrast.MarkOn(fill, light, dark, ColorContrast.EnhancedTextRatio);
            Assert.AreEqual(dark, mark);
        }

        #endregion MarkOn
    }
}
