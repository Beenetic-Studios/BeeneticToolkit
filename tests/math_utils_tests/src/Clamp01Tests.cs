using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeeneticToolkit.MathUtils {

    [TestClass]
    public class Clamp01Tests {

        #region Clamp

        [TestMethod]
        public void Clamp01Float_WithValueWithinRange_ReturnsSameValue() {
            float value = 0.5f;
            float result = MathUtils.Clamp01(value);
            Assert.AreEqual(value, result, MathUtilsHelpers.FLOAT_TOLERANCE, "Clamp01 should return the same value when it's within the range.");
        }

        [TestMethod]
        public void Clamp01Float_WithValueBelowRange_ReturnsZero() {
            float value = -0.1f;
            float result = MathUtils.Clamp01(value);
            Assert.AreEqual(0.0f, result, MathUtilsHelpers.FLOAT_TOLERANCE, "Clamp01 should return 0 for values below the range.");
        }

        [TestMethod]
        public void Clamp01Float_WithValueAboveRange_ReturnsOne() {
            float value = 1.1f;
            float result = MathUtils.Clamp01(value);
            Assert.AreEqual(1.0f, result, MathUtilsHelpers.FLOAT_TOLERANCE, "Clamp01 should return 1 for values above the range.");
        }

        [TestMethod]
        public void Clamp01Float_WithBoundaryValueZero_ReturnsZero() {
            float value = 0.0f;
            float result = MathUtils.Clamp01(value);
            Assert.AreEqual(0.0f, result, MathUtilsHelpers.FLOAT_TOLERANCE, "Clamp01 should return 0 for the boundary value of 0.");
        }

        [TestMethod]
        public void Clamp01Float_WithBoundaryValueOne_ReturnsOne() {
            float value = 1.0f;
            float result = MathUtils.Clamp01(value);
            Assert.AreEqual(1.0f, result, MathUtilsHelpers.FLOAT_TOLERANCE, "Clamp01 should return 1 for the boundary value of 1.");
        }

        [TestMethod]
        public void Clamp01Double_WithValueWithinRange_ReturnsSameValue() {
            double value = 0.5d;
            double result = MathUtils.Clamp01(value);
            Assert.AreEqual(value, result, MathUtilsHelpers.DOUBLE_TOLERANCE, "Clamp01 should return the same value when it's within the range.");
        }

        [TestMethod]
        public void Clamp01Double_WithValueBelowRange_ReturnsZero() {
            double value = -0.1d;
            double result = MathUtils.Clamp01(value);
            Assert.AreEqual(0.0d, result, MathUtilsHelpers.DOUBLE_TOLERANCE, "Clamp01 should return 0 for values below the range.");
        }

        [TestMethod]
        public void Clamp01Double_WithValueAboveRange_ReturnsOne() {
            double value = 1.1d;
            double result = MathUtils.Clamp01(value);
            Assert.AreEqual(1.0d, result, MathUtilsHelpers.DOUBLE_TOLERANCE, "Clamp01 should return 1 for values above the range.");
        }

        [TestMethod]
        public void Clamp01Double_WithBoundaryValueZero_ReturnsZero() {
            double value = 0.0d;
            double result = MathUtils.Clamp01(value);
            Assert.AreEqual(0.0d, result, MathUtilsHelpers.DOUBLE_TOLERANCE, "Clamp01 should return 0 for the boundary value of 0.");
        }

        [TestMethod]
        public void Clamp01Double_WithBoundaryValueOne_ReturnsOne() {
            double value = 1.0d;
            double result = MathUtils.Clamp01(value);
            Assert.AreEqual(1.0d, result, MathUtilsHelpers.DOUBLE_TOLERANCE, "Clamp01 should return 1 for the boundary value of 1.");
        }

        [TestMethod]
        public void Clamp01Decimal_WithValueWithinRange_ReturnsSameValue() {
            decimal value = 0.5m;
            decimal result = MathUtils.Clamp01(value);
            Assert.AreEqual(value, result, MathUtilsHelpers.DECIMAL_TOLERANCE, "Clamp01 should return the same value when it's within the range.");
        }

        [TestMethod]
        public void Clamp01Decimal_WithValueBelowRange_ReturnsZero() {
            decimal value = -0.1m;
            decimal result = MathUtils.Clamp01(value);
            Assert.AreEqual(0.0m, result, MathUtilsHelpers.DECIMAL_TOLERANCE, "Clamp01 should return 0 for values below the range.");
        }

        [TestMethod]
        public void Clamp01Decimal_WithValueAboveRange_ReturnsOne() {
            decimal value = 1.1m;
            decimal result = MathUtils.Clamp01(value);
            Assert.AreEqual(1.0m, result, MathUtilsHelpers.DECIMAL_TOLERANCE, "Clamp01 should return 1 for values above the range.");
        }

        [TestMethod]
        public void Clamp01Decimal_WithBoundaryValueZero_ReturnsZero() {
            decimal value = 0.0m;
            decimal result = MathUtils.Clamp01(value);
            Assert.AreEqual(0.0m, result, MathUtilsHelpers.DECIMAL_TOLERANCE, "Clamp01 should return 0 for the boundary value of 0.");
        }

        [TestMethod]
        public void Clamp01Decimal_WithBoundaryValueOne_ReturnsOne() {
            decimal value = 1.0m;
            decimal result = MathUtils.Clamp01(value);
            Assert.AreEqual(1.0m, result, MathUtilsHelpers.DECIMAL_TOLERANCE, "Clamp01 should return 1 for the boundary value of 1.");
        }

        #endregion Clamp
    }
}