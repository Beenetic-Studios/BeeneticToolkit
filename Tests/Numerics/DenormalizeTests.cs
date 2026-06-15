using BeeneticToolkit.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeeneticToolkit.Tests.Numerics {

    [TestClass]
    public class DenormalizeTests {

        #region Denormalize

        [TestMethod]
        public void DenormalizeFloat_RegularCase() {
            float normalizedValue = 0.5f;
            float min = 10f;
            float max = 20f;
            float expected = 15f;
            float result = MathKit.Denormalize(normalizedValue, min, max);
            Assert.AreEqual(expected, result, NumericsHelpers.FLOAT_TOLERANCE, "Denormalize should correctly rescale a normalized value to its original range.");
        }

        [TestMethod]
        public void DenormalizeFloat_AtZero() {
            float normalizedValue = 0f;
            float min = 10f;
            float max = 20f;
            float expected = 10f;
            float result = MathKit.Denormalize(normalizedValue, min, max);
            Assert.AreEqual(expected, result, NumericsHelpers.FLOAT_TOLERANCE, "Denormalize should return min when normalized value is 0.");
        }

        [TestMethod]
        public void DenormalizeFloat_AtOne() {
            float normalizedValue = 1f;
            float min = 10f;
            float max = 20f;
            float expected = 20f;
            float result = MathKit.Denormalize(normalizedValue, min, max);
            Assert.AreEqual(expected, result, NumericsHelpers.FLOAT_TOLERANCE, "Denormalize should return max when normalized value is 1.");
        }

        [TestMethod]
        public void DenormalizeFloat_OutOfRange_Low() {
            float normalizedValue = -0.1f;
            float min = 10f;
            float max = 20f;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => MathKit.Denormalize(normalizedValue, min, max));
        }

        [TestMethod]
        public void DenormalizeFloat_OutOfRange_High() {
            float normalizedValue = 1.1f;
            float min = 10f;
            float max = 20f;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => MathKit.Denormalize(normalizedValue, min, max));
        }

        [TestMethod]
        public void DenormalizeDouble_RegularCase() {
            double normalizedValue = 0.5d;
            double min = 100d;
            double max = 200d;
            double expected = 150d;
            double result = MathKit.Denormalize(normalizedValue, min, max);
            Assert.AreEqual(expected, result, NumericsHelpers.DOUBLE_TOLERANCE, "Denormalize should correctly rescale a normalized value to its original range.");
        }

        [TestMethod]
        public void DenormalizeDouble_AtZero() {
            double normalizedValue = 0d;
            double min = 100d;
            double max = 200d;
            double expected = 100d;
            double result = MathKit.Denormalize(normalizedValue, min, max);
            Assert.AreEqual(expected, result, NumericsHelpers.DOUBLE_TOLERANCE, "Denormalize should return min when normalized value is 0.");
        }

        [TestMethod]
        public void DenormalizeDouble_AtOne() {
            double normalizedValue = 1d;
            double min = 100d;
            double max = 200d;
            double expected = 200d;
            double result = MathKit.Denormalize(normalizedValue, min, max);
            Assert.AreEqual(expected, result, NumericsHelpers.DOUBLE_TOLERANCE, "Denormalize should return max when normalized value is 1.");
        }

        [TestMethod]
        public void DenormalizeDouble_OutOfRange_Low() {
            double normalizedValue = -0.5d;
            double min = 100d;
            double max = 200d;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => MathKit.Denormalize(normalizedValue, min, max));
        }

        [TestMethod]
        public void DenormalizeDouble_OutOfRange_High() {
            double normalizedValue = 1.5d;
            double min = 100d;
            double max = 200d;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => MathKit.Denormalize(normalizedValue, min, max));
        }

        [TestMethod]
        public void DenormalizeDecimal_RegularCase() {
            decimal normalizedValue = 0.5m;
            decimal min = 500m;
            decimal max = 1000m;
            decimal expected = 750m;
            decimal result = MathKit.Denormalize(normalizedValue, min, max);
            Assert.AreEqual(expected, result, NumericsHelpers.DECIMAL_TOLERANCE, "Denormalize should correctly rescale a normalized value to its original range.");
        }

        [TestMethod]
        public void DenormalizeDecimal_AtZero() {
            decimal normalizedValue = 0m;
            decimal min = 500m;
            decimal max = 1000m;
            decimal expected = 500m;
            decimal result = MathKit.Denormalize(normalizedValue, min, max);
            Assert.AreEqual(expected, result, NumericsHelpers.DECIMAL_TOLERANCE, "Denormalize should return min when normalized value is 0.");
        }

        [TestMethod]
        public void DenormalizeDecimal_AtOne() {
            decimal normalizedValue = 1m;
            decimal min = 500m;
            decimal max = 1000m;
            decimal expected = 1000m;
            decimal result = MathKit.Denormalize(normalizedValue, min, max);
            Assert.AreEqual(expected, result, NumericsHelpers.DECIMAL_TOLERANCE, "Denormalize should return max when normalized value is 1.");
        }

        [TestMethod]
        public void DenormalizeDecimal_OutOfRange_Low() {
            decimal normalizedValue = -0.25m;
            decimal min = 500m;
            decimal max = 1000m;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => MathKit.Denormalize(normalizedValue, min, max));
        }

        [TestMethod]
        public void DenormalizeDecimal_OutOfRange_High() {
            decimal normalizedValue = 1.25m;
            decimal min = 500m;
            decimal max = 1000m;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => MathKit.Denormalize(normalizedValue, min, max));
        }

        #endregion Denormalize
    }
}