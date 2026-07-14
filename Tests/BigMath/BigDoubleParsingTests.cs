using BeeneticToolkit.BigMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeeneticToolkit.Tests.BigMath {

    [TestClass]
    public class BigDoubleParsingTests {

        #region Parse forms

        [TestMethod]
        public void Parse_ScientificForm() {
            BigDouble value = BigDouble.Parse("1.5e12");
            Assert.AreEqual(1.5, value.Mantissa, 1e-12);
            Assert.AreEqual(12.0, value.Exponent);
        }

        [TestMethod]
        public void Parse_NegativeAndPlain() {
            Assert.AreEqual(-1.5, BigDouble.Parse("-1.5e12").Mantissa, 1e-12);
            Assert.IsTrue(BigDouble.Parse("12345").EqualsApproximately((BigDouble)12345, 1e-12));
            Assert.IsTrue(BigDouble.Parse("-0.001").EqualsApproximately((BigDouble)(-0.001), 1e-12));
        }

        [TestMethod]
        public void Parse_StandardShortSuffixes() {
            Assert.IsTrue(BigDouble.Parse("1.50M").EqualsApproximately(new BigDouble(1.5, 6.0)));
            Assert.IsTrue(BigDouble.Parse("1.50K").EqualsApproximately(new BigDouble(1.5, 3.0)));
            Assert.IsTrue(BigDouble.Parse("15.00T").EqualsApproximately(new BigDouble(1.5, 13.0)));
        }

        [TestMethod]
        public void Parse_StandardLetterSuffixes() {
            Assert.IsTrue(BigDouble.Parse("1.00aa").EqualsApproximately(new BigDouble(1.0, 15.0)));
            Assert.IsTrue(BigDouble.Parse("1.00ab").EqualsApproximately(new BigDouble(1.0, 18.0)));
            Assert.IsTrue(BigDouble.Parse("1.00zz").EqualsApproximately(new BigDouble(1.0, 2040.0)));
            Assert.IsTrue(BigDouble.Parse("1.00aaa").EqualsApproximately(new BigDouble(1.0, 2043.0)));
        }

        [TestMethod]
        public void Parse_SpecialWords() {
            Assert.IsTrue(BigDouble.Parse("NaN").IsNaN);
            Assert.IsTrue(BigDouble.Parse("Infinity").Equals(BigDouble.PositiveInfinity));
            Assert.IsTrue(BigDouble.Parse("-Infinity").Equals(BigDouble.NegativeInfinity));
        }

        [TestMethod]
        public void TryParse_Garbage_ReturnsFalse() {
            Assert.IsFalse(BigDouble.TryParse("not a number", out _));
            Assert.IsFalse(BigDouble.TryParse("", out _));
            Assert.IsFalse(BigDouble.TryParse(null, out _));
            Assert.IsFalse(BigDouble.TryParse("1.2.3", out _));
        }

        #endregion

        #region Round-trip guarantee

        [TestMethod]
        public void RoundTrip_ParseOfToStringR_EqualsOriginal() {
            BigDouble[] samples = {
                BigDouble.Zero,
                BigDouble.One,
                new BigDouble(1.0, 15.0),
                new BigDouble(3.7, 250.0),
                new BigDouble(-3.7, 250.0),
                new BigDouble(9.999999999999998, 12.0),
                new BigDouble(1.234567890123456, -300.0),
                new BigDouble(5.5, 9_000_000_000_000_000.0), // near the exponent ceiling
                (BigDouble)42,
                (BigDouble)(-0.00073),
            };

            foreach (BigDouble original in samples) {
                string text = original.ToString("R", null);
                BigDouble parsed = BigDouble.Parse(text);
                Assert.IsTrue(parsed == original,
                    $"Round-trip failed for {text}: got m={parsed.Mantissa}, e={parsed.Exponent}.");
            }
        }

        [TestMethod]
        public void RoundTrip_NonFinite_PreservesValue() {
            Assert.IsTrue(BigDouble.Parse(BigDouble.PositiveInfinity.ToString("R", null)).Equals(BigDouble.PositiveInfinity));
            Assert.IsTrue(BigDouble.Parse(BigDouble.NegativeInfinity.ToString("R", null)).Equals(BigDouble.NegativeInfinity));
            Assert.IsTrue(BigDouble.Parse(BigDouble.NaN.ToString("R", null)).IsNaN);
        }

        #endregion
    }
}
