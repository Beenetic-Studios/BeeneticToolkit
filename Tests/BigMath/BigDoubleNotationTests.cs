using BeeneticToolkit.BigMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeeneticToolkit.Tests.BigMath {

    [TestClass]
    public class BigDoubleNotationTests {

        #region Scientific

        [TestMethod]
        public void Scientific_FormatsMantissaAndExponent() {
            Assert.AreEqual("1.50e12", Notation.Scientific.Format(new BigDouble(1.5, 12.0), 2));
            Assert.AreEqual("9.99e1234", Notation.Scientific.Format(new BigDouble(9.99, 1234.0), 2));
            Assert.AreEqual("-1.50e12", Notation.Scientific.Format(new BigDouble(-1.5, 12.0), 2));
        }

        [TestMethod]
        public void Scientific_Zero_IsPlainZero() {
            Assert.AreEqual("0.00", Notation.Scientific.Format(BigDouble.Zero, 2));
        }

        #endregion

        #region Engineering

        [TestMethod]
        public void Engineering_KeepsExponentAMultipleOfThree() {
            Assert.AreEqual("1.50e12", Notation.Engineering.Format(new BigDouble(1.5, 12.0), 2));
            Assert.AreEqual("15.00e12", Notation.Engineering.Format(new BigDouble(1.5, 13.0), 2));
            Assert.AreEqual("150.00e12", Notation.Engineering.Format(new BigDouble(1.5, 14.0), 2));
        }

        #endregion

        #region Standard abbreviated

        [TestMethod]
        public void Standard_ShortSuffixes_KMBT() {
            Assert.AreEqual("1.50K", Notation.Standard.Format(new BigDouble(1.5, 3.0), 2));
            Assert.AreEqual("1.50M", Notation.Standard.Format(new BigDouble(1.5, 6.0), 2));
            Assert.AreEqual("1.50B", Notation.Standard.Format(new BigDouble(1.5, 9.0), 2));
            Assert.AreEqual("1.50T", Notation.Standard.Format(new BigDouble(1.5, 12.0), 2));
        }

        [TestMethod]
        public void Standard_BelowThousand_HasNoSuffix() {
            Assert.AreEqual("500.00", Notation.Standard.Format(new BigDouble(5.0, 2.0), 2));
            Assert.AreEqual("1.00", Notation.Standard.Format(BigDouble.One, 2));
        }

        [TestMethod]
        public void Standard_LetterSuffixes_FollowBijectiveSequence() {
            Assert.AreEqual("1.00aa", Notation.Standard.Format(new BigDouble(1.0, 15.0), 2)); // tier 5
            Assert.AreEqual("1.23aa", Notation.Standard.Format(new BigDouble(1.23, 15.0), 2));
            Assert.AreEqual("15.00aa", Notation.Standard.Format(new BigDouble(1.5, 16.0), 2)); // 15 * 10^15
            Assert.AreEqual("1.00ab", Notation.Standard.Format(new BigDouble(1.0, 18.0), 2)); // tier 6
            Assert.AreEqual("1.00zz", Notation.Standard.Format(new BigDouble(1.0, 2040.0), 2)); // tier 680
            Assert.AreEqual("1.00aaa", Notation.Standard.Format(new BigDouble(1.0, 2043.0), 2)); // tier 681
        }

        [TestMethod]
        public void Standard_CustomSuffixProvider_IsUsed() {
            var notation = new StandardNotation(new UnitSuffixProvider());
            Assert.AreEqual("1.50 gold", notation.Format(new BigDouble(1.5, 3.0), 2));
        }

        private sealed class UnitSuffixProvider : ISuffixProvider {
            public string GetSuffix(long tier) => tier == 1 ? " gold" : $" x10^{tier * 3}";
        }

        #endregion

        #region Short-scale named suffixes

        [TestMethod]
        public void ShortScale_NamesQuadrillionThroughDecillion() {
            Assert.AreEqual("1.50T", Notation.ShortScale.Format(new BigDouble(1.5, 12.0), 2));  // tier 4
            Assert.AreEqual("1.00Qa", Notation.ShortScale.Format(new BigDouble(1.0, 15.0), 2)); // tier 5
            Assert.AreEqual("1.00Qi", Notation.ShortScale.Format(new BigDouble(1.0, 18.0), 2)); // tier 6
            Assert.AreEqual("1.00Sx", Notation.ShortScale.Format(new BigDouble(1.0, 21.0), 2)); // tier 7
            Assert.AreEqual("1.00Sp", Notation.ShortScale.Format(new BigDouble(1.0, 24.0), 2)); // tier 8
            Assert.AreEqual("1.00Oc", Notation.ShortScale.Format(new BigDouble(1.0, 27.0), 2)); // tier 9
            Assert.AreEqual("1.00No", Notation.ShortScale.Format(new BigDouble(1.0, 30.0), 2)); // tier 10
            Assert.AreEqual("1.00Dc", Notation.ShortScale.Format(new BigDouble(1.0, 33.0), 2)); // tier 11
        }

        [TestMethod]
        public void ShortScale_ComposesTiersBeyondDecillion() {
            var provider = ShortScaleSuffixProvider.Instance;
            Assert.AreEqual("UDc", provider.GetSuffix(12)); // undecillion, illion 11
            Assert.AreEqual("Vg", provider.GetSuffix(21));  // vigintillion, illion 20
            Assert.AreEqual("UVg", provider.GetSuffix(22)); // unvigintillion, illion 21
            Assert.AreEqual("Ce", provider.GetSuffix(101)); // centillion, illion 100
        }

        [TestMethod]
        public void ShortScale_CapDefersLargerTiersToFallback() {
            // Named through decillion (tier 11); tier 12 falls back to the alphabetic default.
            var capped = new ShortScaleSuffixProvider(maxNamedTier: 11);
            Assert.AreEqual("Dc", capped.GetSuffix(11));
            Assert.AreEqual(DefaultSuffixProvider.Instance.GetSuffix(12), capped.GetSuffix(12));
        }

        #endregion

        #region Mixed scientific

        [TestMethod]
        public void MixedScientific_UsesStandardBelowThresholdAndScientificAbove() {
            var mixed = new MixedScientificNotation(switchExponent: 33.0);
            Assert.AreEqual("1.00af", mixed.Format(new BigDouble(1.0, 30.0), 2)); // below 33 -> standard
            Assert.AreEqual("1.00e33", mixed.Format(new BigDouble(1.0, 33.0), 2)); // at/above -> scientific
        }

        #endregion

        #region ToString &amp; IFormattable

        [TestMethod]
        public void ToString_Default_UsesStandardNotation() {
            Assert.AreEqual("1.50M", new BigDouble(1.5, 6.0).ToString());
        }

        [TestMethod]
        public void ToString_FormatSpecifiers_SelectNotation() {
            BigDouble value = new BigDouble(1.5, 13.0);
            Assert.AreEqual("1.50e13", value.ToString("S", null));
            Assert.AreEqual("15.00e12", value.ToString("G", null));
            Assert.AreEqual("15.00T", value.ToString("A", null)); // 1.5e13 = 15 * 10^12, tier 4 (T)
            Assert.AreEqual("15.00T", value.ToString("D", null));
        }

        [TestMethod]
        public void ToString_FormatSpecifierWithDigitCount_SetsDecimals() {
            Assert.AreEqual("1.500e12", new BigDouble(1.5, 12.0).ToString("S3", null));
        }

        [TestMethod]
        public void ToString_UnknownSpecifier_Throws() {
            Assert.ThrowsException<System.FormatException>(() => new BigDouble(1.0, 5.0).ToString("Q", null));
        }

        [TestMethod]
        public void ToString_RoundTripFormat_IsScientificFullPrecision() {
            Assert.AreEqual("3.7e250", new BigDouble(3.7, 250.0).ToString("R", null));
            Assert.AreEqual("NaN", BigDouble.NaN.ToString("R", null));
            Assert.AreEqual("Infinity", BigDouble.PositiveInfinity.ToString("R", null));
            Assert.AreEqual("-Infinity", BigDouble.NegativeInfinity.ToString("R", null));
        }

        #endregion
    }
}
