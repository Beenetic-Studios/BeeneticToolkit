using System.Globalization;
using System.Numerics;
using BeeneticToolkit.BigMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeeneticToolkit.Tests.BigMath {

    [TestClass]
    public class BigDoubleTests {

        // Relative-closeness helper for values whose magnitude spans many orders of magnitude.
        private static void AssertClose(BigDouble expected, BigDouble actual, double relTol = 1e-9, string message = null) {
            Assert.IsTrue(expected.EqualsApproximately(actual, relTol),
                message ?? $"Expected ~{expected.ToDouble()} (m={expected.Mantissa}, e={expected.Exponent}) " +
                           $"but got {actual.ToDouble()} (m={actual.Mantissa}, e={actual.Exponent}).");
        }

        #region Normalization &amp; construction

        [TestMethod]
        public void Constructor_UnnormalizedMantissa_NormalizesIntoRange() {
            BigDouble value = new BigDouble(12345.0, 3.0); // 12345 * 10^3 = 1.2345e7
            Assert.AreEqual(1.2345, value.Mantissa, 1e-12);
            Assert.AreEqual(7.0, value.Exponent);
        }

        [TestMethod]
        public void Constructor_FractionalExponent_FoldsIntoMantissa() {
            BigDouble value = new BigDouble(1.0, 2.5); // 10^2.5 = 316.227...
            Assert.AreEqual(2.0, value.Exponent);
            Assert.AreEqual(3.16227766, value.Mantissa, 1e-6);
        }

        [TestMethod]
        public void Constructor_Zero_IsCanonical() {
            BigDouble value = new BigDouble(0.0, 500.0);
            Assert.AreEqual(0.0, value.Mantissa);
            Assert.AreEqual(0.0, value.Exponent);
            Assert.IsTrue(value.IsZero);
        }

        [TestMethod]
        public void Constructor_NegativeMantissa_KeepsSign() {
            BigDouble value = new BigDouble(-5.0, 10.0);
            Assert.AreEqual(-5.0, value.Mantissa, 1e-12);
            Assert.AreEqual(10.0, value.Exponent);
            Assert.AreEqual(-1, value.Sign);
        }

        #endregion

        #region Conversions

        [TestMethod]
        public void ImplicitConversions_FromPrimitives_RoundTripThroughToDouble() {
            BigDouble fromInt = 1000;
            BigDouble fromLong = 1_000_000_000_000L;
            BigDouble fromDouble = 1.5e40;

            Assert.AreEqual(1000.0, fromInt.ToDouble(), 1e-6);
            Assert.AreEqual(1e12, fromLong.ToDouble(), 1.0);
            Assert.AreEqual(1.5e40, fromDouble.ToDouble(), 1e30);
        }

        [TestMethod]
        public void ToDouble_OutOfRange_SaturatesToInfinity() {
            BigDouble huge = BigDouble.Pow10(400);
            Assert.IsTrue(double.IsPositiveInfinity(huge.ToDouble()));
        }

        #endregion

        #region Arithmetic

        [TestMethod]
        public void Multiply_AddsExponents() {
            BigDouble result = BigDouble.Pow10(100) * BigDouble.Pow10(100);
            Assert.AreEqual(200.0, result.Exponent);
            Assert.AreEqual(1.0, result.Mantissa, 1e-12);
        }

        [TestMethod]
        public void Divide_SubtractsExponents() {
            BigDouble result = BigDouble.Pow10(200) / BigDouble.Pow10(50);
            Assert.AreEqual(150.0, result.Exponent);
        }

        [TestMethod]
        public void Add_SimilarMagnitudes_SumsCorrectly() {
            BigDouble result = (BigDouble)1.5e10 + (BigDouble)2.5e10;
            AssertClose(4.0e10, result);
        }

        [TestMethod]
        public void Add_HugeExponentGap_ShortCircuitsToLarger() {
            BigDouble big = BigDouble.Pow10(300);
            BigDouble tiny = BigDouble.One;
            Assert.IsTrue((big + tiny).Equals(big), "Adding a negligible operand should return the larger unchanged.");
        }

        [TestMethod]
        public void Subtract_EqualValues_IsZero() {
            BigDouble a = new BigDouble(7.0, 123.0);
            Assert.IsTrue((a - a).IsZero);
        }

        [TestMethod]
        public void Negate_FlipsSign() {
            BigDouble a = new BigDouble(3.0, 50.0);
            Assert.AreEqual(-3.0, a.Negate().Mantissa, 1e-12);
            Assert.IsTrue(BigDouble.Zero.Negate().IsZero);
        }

        #endregion

        #region Comparison &amp; equality

        [TestMethod]
        public void Comparison_OrdersByMagnitudeAndSign() {
            Assert.IsTrue(BigDouble.Pow10(100) > BigDouble.Pow10(99));
            Assert.IsTrue(BigDouble.Pow10(100).Negate() < BigDouble.Pow10(99).Negate());
            Assert.IsTrue((BigDouble)5 < (BigDouble)10);
            Assert.IsTrue((BigDouble)(-10) < (BigDouble)(-5));
        }

        [TestMethod]
        public void CompareTo_Transitivity_Holds() {
            BigDouble a = (BigDouble)1, b = BigDouble.Pow10(50), c = BigDouble.Pow10(100);
            Assert.IsTrue(a < b && b < c && a < c);
        }

        [TestMethod]
        public void Equality_ExactOnNormalizedForm() {
            Assert.IsTrue(new BigDouble(1.0, 100.0) == BigDouble.Pow10(100));
            Assert.IsTrue(new BigDouble(1.0, 100.0).Equals(BigDouble.Pow10(100)));
            Assert.AreEqual(new BigDouble(1.0, 100.0).GetHashCode(), BigDouble.Pow10(100).GetHashCode());
        }

        [TestMethod]
        public void EqualsApproximately_ToleratesMantissaDrift() {
            BigDouble a = new BigDouble(1.0000000001, 500.0);
            BigDouble b = new BigDouble(1.0, 500.0);
            Assert.IsTrue(a.EqualsApproximately(b, 1e-6));
            Assert.IsFalse(a.EqualsApproximately(b, 1e-12));
        }

        #endregion

        #region Powers, roots, logs

        [TestMethod]
        public void Log10_And_Pow10_RoundTrip() {
            BigDouble value = new BigDouble(3.7, 250.0);
            AssertClose(value, BigDouble.Pow10(value.Log10()), 1e-9);
        }

        [TestMethod]
        public void Pow_GeometricCostCurve_Matches() {
            // 1.15^100 is about 1.174313e6 (verified against the log/pow identity).
            BigDouble result = ((BigDouble)1.15).Pow(100);
            AssertClose((BigDouble)1174313.4507, result, 1e-6);
        }

        [TestMethod]
        public void Sqrt_OfEvenAndOddExponents_IsAccurate() {
            AssertClose(BigDouble.Pow10(50), BigDouble.Pow10(100).Sqrt(), 1e-9);
            AssertClose(new BigDouble(3.16227766, 50.0), BigDouble.Pow10(101).Sqrt(), 1e-6);
        }

        [TestMethod]
        public void Sqrt_OfNegative_IsNaN() {
            Assert.IsTrue(new BigDouble(-4.0, 0.0).Sqrt().IsNaN);
        }

        [TestMethod]
        public void MultiplyRepeatedly_MatchesBigIntegerOracle() {
            // Independent oracle: compute 2^1000 exactly with BigInteger and compare leading digits + magnitude.
            BigInteger expected = BigInteger.Pow(2, 1000);
            string digits = expected.ToString(CultureInfo.InvariantCulture);
            double expectedExponent = digits.Length - 1;
            double expectedMantissa = double.Parse(
                digits.Substring(0, 1) + "." + digits.Substring(1, 15), CultureInfo.InvariantCulture);

            BigDouble actual = BigDouble.One;
            BigDouble two = (BigDouble)2;
            for (int i = 0; i < 1000; i++) actual *= two;

            Assert.AreEqual(expectedExponent, actual.Exponent, "2^1000 should have exponent 301.");
            Assert.AreEqual(expectedMantissa, actual.Mantissa, 1e-9, "Leading digits of 2^1000 should match BigInteger.");
        }

        #endregion

        #region Edge cases

        [TestMethod]
        public void DivideByZero_SaturatesToSignedInfinity() {
            Assert.IsTrue(((BigDouble)1 / BigDouble.Zero).Equals(BigDouble.PositiveInfinity));
            Assert.IsTrue(((BigDouble)(-1) / BigDouble.Zero).Equals(BigDouble.NegativeInfinity));
            Assert.IsTrue((BigDouble.Zero / BigDouble.Zero).IsNaN);
        }

        [TestMethod]
        public void Overflow_PastExponentLimit_SaturatesToInfinity() {
            BigDouble nearMax = BigDouble.Pow10(BigDouble.ExponentLimit);
            Assert.IsTrue((nearMax * nearMax).IsInfinity, "Exponent overflow must saturate, not wrap.");
        }

        [TestMethod]
        public void Log10_OfZero_IsNegativeInfinity() {
            Assert.IsTrue(double.IsNegativeInfinity(BigDouble.Zero.Log10()));
        }

        [TestMethod]
        public void NaN_PropagatesAndIsNeverEqual() {
            BigDouble nan = BigDouble.NaN;
            BigDouble alsoNan = BigDouble.Zero / BigDouble.Zero;
            Assert.IsTrue((BigDouble.NaN + BigDouble.One).IsNaN);
            Assert.IsFalse(nan == alsoNan);
            Assert.IsTrue(nan != alsoNan);
            Assert.IsTrue(nan.Equals(alsoNan), "Equals treats NaN as equal to NaN, matching double.Equals.");
        }

        [TestMethod]
        public void Infinity_ArithmeticFollowsIeee() {
            Assert.IsTrue((BigDouble.PositiveInfinity + BigDouble.NegativeInfinity).IsNaN);
            Assert.IsTrue((BigDouble.PositiveInfinity * BigDouble.Zero).IsNaN);
            Assert.IsTrue((BigDouble.PositiveInfinity + BigDouble.One).Equals(BigDouble.PositiveInfinity));
        }

        #endregion
    }
}
