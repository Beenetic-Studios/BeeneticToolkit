using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeeneticToolkit.MathUtils {

    [TestClass]
    public class NormalizeTests {

        #region Normalize

        [TestMethod]
        public void NormalizeFloat_RegularCase() {
            float value = 5f;
            float min = 0f;
            float max = 10f;
            float expected = 0.5f;
            float result = MathUtils.Normalize(value, min, max);
            Assert.AreEqual(expected, result, MathUtilsHelpers.FLOAT_TOLERANCE, "Normalize should correctly normalize a value within a regular range.");
        }

        [TestMethod]
        public void NormalizeFloat_AtMinimum() {
            float value = 0f;
            float min = 0f;
            float max = 10f;
            float expected = 0f;
            float result = MathUtils.Normalize(value, min, max);
            Assert.AreEqual(expected, result, MathUtilsHelpers.FLOAT_TOLERANCE, "Normalize should return 0 when the value is at the minimum of the range.");
        }

        [TestMethod]
        public void NormalizeFloat_AtMaximum() {
            float value = 10f;
            float min = 0f;
            float max = 10f;
            float expected = 1f;
            float result = MathUtils.Normalize(value, min, max);
            Assert.AreEqual(expected, result, MathUtilsHelpers.FLOAT_TOLERANCE, "Normalize should return 1 when the value is at the maximum of the range.");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void NormalizeFloat_ZeroRange() {
            float value = 5f;
            float min = 5f;
            float max = 5f;
            MathUtils.Normalize(value, min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NormalizeFloat_InvalidRange() {
            float value = 5f;
            float min = 10f;
            float max = 0f;
            MathUtils.Normalize(value, min, max);
        }

        [TestMethod]
        public void NormalizeDouble_RegularCase() {
            double value = 5d;
            double min = 0d;
            double max = 10d;
            double expected = 0.5d;
            double result = MathUtils.Normalize(value, min, max);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DOUBLE_TOLERANCE, "Normalize should correctly normalize a value within a regular range.");
        }

        [TestMethod]
        public void NormalizeDouble_AtMinimum() {
            double value = 0d;
            double min = 0d;
            double max = 10d;
            double expected = 0d;
            double result = MathUtils.Normalize(value, min, max);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DOUBLE_TOLERANCE, "Normalize should return 0 when the value is at the minimum of the range.");
        }

        [TestMethod]
        public void NormalizeDouble_AtMaximum() {
            double value = 10d;
            double min = 0d;
            double max = 10d;
            double expected = 1d;
            double result = MathUtils.Normalize(value, min, max);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DOUBLE_TOLERANCE, "Normalize should return 1 when the value is at the maximum of the range.");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void NormalizeDouble_ZeroRange() {
            double value = 5d;
            double min = 5d;
            double max = 5d;
            MathUtils.Normalize(value, min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NormalizeDouble_InvalidRange() {
            double value = 5d;
            double min = 10d;
            double max = 0d;
            MathUtils.Normalize(value, min, max);
        }

        [TestMethod]
        public void NormalizeDecimal_RegularCase() {
            decimal value = 5m;
            decimal min = 0m;
            decimal max = 10m;
            decimal expected = 0.5m;
            decimal result = MathUtils.Normalize(value, min, max);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DECIMAL_TOLERANCE, "Normalize should correctly normalize a value within a regular range.");
        }

        [TestMethod]
        public void NormalizeDecimal_AtMinimum() {
            decimal value = 0m;
            decimal min = 0m;
            decimal max = 10m;
            decimal expected = 0m;
            decimal result = MathUtils.Normalize(value, min, max);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DECIMAL_TOLERANCE, "Normalize should return 0 when the value is at the minimum of the range.");
        }

        [TestMethod]
        public void NormalizeDecimal_AtMaximum() {
            decimal value = 10m;
            decimal min = 0m;
            decimal max = 10m;
            decimal expected = 1m;
            decimal result = MathUtils.Normalize(value, min, max);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DECIMAL_TOLERANCE, "Normalize should return 1 when the value is at the maximum of the range.");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void NormalizeDecimal_ZeroRange() {
            decimal value = 5m;
            decimal min = 5m;
            decimal max = 5m;
            MathUtils.Normalize(value, min, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NormalizeDecimal_InvalidRange() {
            decimal value = 5m;
            decimal min = 10m;
            decimal max = 0m;
            MathUtils.Normalize(value, min, max);
        }

        #endregion Normalize
    }
}