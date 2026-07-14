using System;
using BeeneticToolkit.BigMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeeneticToolkit.Tests.BigMath {

    // Direct coverage for the math/utility members exercised only indirectly elsewhere:
    // Floor/Ceiling/Round, Root, Exp, Ln/Log, Reciprocal, and Min/Max/Clamp.
    [TestClass]
    public class BigDoubleMathExtraTests {

        private static void AssertClose(BigDouble expected, BigDouble actual, double relTol = 1e-9) {
            Assert.IsTrue(expected.EqualsApproximately(actual, relTol),
                $"Expected ~{expected.ToString("R", null)} but got {actual.ToString("R", null)}.");
        }

        #region Floor / Ceiling / Round

        [TestMethod]
        public void Floor_RoundsTowardNegativeInfinity() {
            Assert.IsTrue(((BigDouble)3.7).Floor().Equals((BigDouble)3));
            Assert.IsTrue(((BigDouble)(-3.2)).Floor().Equals((BigDouble)(-4)));
            Assert.IsTrue(((BigDouble)5).Floor().Equals((BigDouble)5));
        }

        [TestMethod]
        public void Ceiling_RoundsTowardPositiveInfinity() {
            Assert.IsTrue(((BigDouble)3.2).Ceiling().Equals((BigDouble)4));
            Assert.IsTrue(((BigDouble)(-3.7)).Ceiling().Equals((BigDouble)(-3)));
        }

        [TestMethod]
        public void Round_UsesBankersRoundingAndDigits() {
            Assert.IsTrue(((BigDouble)2.5).Round().Equals((BigDouble)2)); // to even
            Assert.IsTrue(((BigDouble)3.5).Round().Equals((BigDouble)4)); // to even
            AssertClose((BigDouble)3.14, ((BigDouble)3.14159).Round(2), 1e-12);
        }

        [TestMethod]
        public void FloorCeilingRound_HugeValues_HaveNoFractionalPart() {
            BigDouble huge = BigDouble.Pow10(100);
            Assert.IsTrue(huge.Floor().Equals(huge));
            Assert.IsTrue(huge.Ceiling().Equals(huge));
            Assert.IsTrue(huge.Round(3).Equals(huge));
        }

        #endregion

        #region Root / Exp / Ln / Log / Reciprocal

        [TestMethod]
        public void Root_ComputesNthRoot() {
            AssertClose((BigDouble)2, ((BigDouble)8).Root(3), 1e-9);       // cube root of 8
            AssertClose((BigDouble)3, ((BigDouble)9).Root(2), 1e-9);       // Root(2) delegates to Sqrt
            AssertClose(BigDouble.Pow10(10), BigDouble.Pow10(30).Root(3), 1e-9);
        }

        [TestMethod]
        public void Exp_And_Ln_RoundTrip() {
            AssertClose((BigDouble)Math.E, BigDouble.Exp(1.0), 1e-9);
            Assert.AreEqual(0.0, BigDouble.One.Ln(), 1e-12);
            Assert.AreEqual(50.0, BigDouble.Exp(50.0).Ln(), 1e-6);         // Ln(e^50) == 50
        }

        [TestMethod]
        public void Log_InArbitraryBase() {
            Assert.AreEqual(3.0, ((BigDouble)8).Log(2.0), 1e-9);           // log2(8) == 3
            Assert.AreEqual(100.0, BigDouble.Pow10(100).Log(10.0), 1e-9);
            Assert.AreEqual(100.0 * Math.Log(10.0), BigDouble.Pow10(100).Ln(), 1e-6);
        }

        [TestMethod]
        public void Reciprocal_InvertsMagnitude() {
            Assert.IsTrue(BigDouble.Pow10(50).Reciprocal().Equals(BigDouble.Pow10(-50)));
            AssertClose((BigDouble)0.25, ((BigDouble)4).Reciprocal(), 1e-12);
            Assert.IsTrue(BigDouble.Zero.Reciprocal().Equals(BigDouble.PositiveInfinity));
        }

        #endregion

        #region Min / Max / Clamp

        [TestMethod]
        public void MinMax_SelectByValue() {
            Assert.IsTrue(BigDouble.Min(BigDouble.Pow10(50), BigDouble.Pow10(100)).Equals(BigDouble.Pow10(50)));
            Assert.IsTrue(BigDouble.Max(BigDouble.Pow10(50), BigDouble.Pow10(100)).Equals(BigDouble.Pow10(100)));
            Assert.IsTrue(BigDouble.Min((BigDouble)(-10), (BigDouble)5).Equals((BigDouble)(-10)));
        }

        [TestMethod]
        public void MinMax_WithNaN_AreNaN() {
            Assert.IsTrue(BigDouble.Min(BigDouble.NaN, BigDouble.One).IsNaN);
            Assert.IsTrue(BigDouble.Max(BigDouble.NaN, BigDouble.One).IsNaN);
        }

        [TestMethod]
        public void Clamp_BoundsValueToRange() {
            BigDouble lo = BigDouble.Pow10(10);
            BigDouble hi = BigDouble.Pow10(100);
            Assert.IsTrue(BigDouble.Clamp(BigDouble.Pow10(200), lo, hi).Equals(hi));
            Assert.IsTrue(BigDouble.Clamp(BigDouble.Pow10(5), lo, hi).Equals(lo));
            Assert.IsTrue(BigDouble.Clamp(BigDouble.Pow10(50), lo, hi).Equals(BigDouble.Pow10(50)));
        }

        #endregion
    }
}
