using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeeneticToolkit.MathUtils {

    [TestClass]
    public class InterpolationTests {

        #region Interpolation

        [TestMethod]
        public void LerpFloat_StandardInterpolation() {
            float start = 0f;
            float end = 10f;
            float factor = 0.5f;
            float expected = 5f;
            float result = MathUtils.Lerp(start, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.FLOAT_TOLERANCE, "Lerp should correctly interpolate between start and end values.");
        }

        [TestMethod]
        public void LerpFloat_FactorAtZero() {
            float start = 0f;
            float end = 10f;
            float factor = 0f;
            float expected = start;
            float result = MathUtils.Lerp(start, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.FLOAT_TOLERANCE, "Lerp should return start value when factor is 0.");
        }

        [TestMethod]
        public void LerpFloat_FactorAtOne() {
            float start = 0f;
            float end = 10f;
            float factor = 1f;
            float expected = end;
            float result = MathUtils.Lerp(start, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.FLOAT_TOLERANCE, "Lerp should return end value when factor is 1.");
        }

        [TestMethod]
        public void LerpFloat_FactorBelowZero() {
            float start = 0f;
            float end = 10f;
            float factor = -0.5f;
            float expected = start; // Since factor is clamped to 0
            float result = MathUtils.Lerp(start, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.FLOAT_TOLERANCE, "Lerp should return start value when factor is below 0.");
        }

        [TestMethod]
        public void LerpFloat_FactorAboveOne() {
            float start = 0f;
            float end = 10f;
            float factor = 1.5f;
            float expected = end; // Since factor is clamped to 1
            float result = MathUtils.Lerp(start, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.FLOAT_TOLERANCE, "Lerp should return end value when factor is above 1.");
        }

        [TestMethod]
        public void LerpFloat_SameStartAndEnd() {
            float start = 5f;
            float end = 5f;
            float factor = 0.5f;
            float expected = 5f;
            float result = MathUtils.Lerp(start, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.FLOAT_TOLERANCE, "Lerp should return the same value when start and end are the same.");
        }

        [TestMethod]
        public void LerpDouble_StandardInterpolation() {
            double start = 0d;
            double end = 10d;
            double factor = 0.5d;
            double expected = 5d;
            double result = MathUtils.Lerp(start, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DOUBLE_TOLERANCE, "Lerp should correctly interpolate between start and end values.");
        }

        [TestMethod]
        public void LerpDouble_FactorAtZero() {
            double start = 0d;
            double end = 10d;
            double factor = 0d;
            double expected = start;
            double result = MathUtils.Lerp(start, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DOUBLE_TOLERANCE, "Lerp should return start value when factor is 0.");
        }

        [TestMethod]
        public void LerpDouble_FactorAtOne() {
            double start = 0d;
            double end = 10d;
            double factor = 1d;
            double expected = end;
            double result = MathUtils.Lerp(start, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DOUBLE_TOLERANCE, "Lerp should return end value when factor is 1.");
        }

        [TestMethod]
        public void LerpDouble_FactorBelowZero() {
            double start = 0d;
            double end = 10d;
            double factor = -0.5d;
            double expected = start; // Since factor is clamped to 0
            double result = MathUtils.Lerp(start, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DOUBLE_TOLERANCE, "Lerp should return start value when factor is below 0.");
        }

        [TestMethod]
        public void LerpDouble_FactorAboveOne() {
            double start = 0d;
            double end = 10d;
            double factor = 1.5d;
            double expected = end; // Since factor is clamped to 1
            double result = MathUtils.Lerp(start, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DOUBLE_TOLERANCE, "Lerp should return end value when factor is above 1.");
        }

        [TestMethod]
        public void LerpDouble_SameStartAndEnd() {
            double start = 5d;
            double end = 5d;
            double factor = 0.5d;
            double expected = 5d;
            double result = MathUtils.Lerp(start, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DOUBLE_TOLERANCE, "Lerp should return the same value when start and end are the same.");
        }

        [TestMethod]
        public void LerpDecimal_StandardInterpolation() {
            decimal start = 0m;
            decimal end = 10m;
            decimal factor = 0.5m;
            decimal expected = 5m;
            decimal result = MathUtils.Lerp(start, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DECIMAL_TOLERANCE, "Lerp should correctly interpolate between start and end values.");
        }

        [TestMethod]
        public void LerpDecimal_FactorAtZero() {
            decimal start = 0m;
            decimal end = 10m;
            decimal factor = 0m;
            decimal expected = start;
            decimal result = MathUtils.Lerp(start, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DECIMAL_TOLERANCE, "Lerp should return start value when factor is 0.");
        }

        [TestMethod]
        public void LerpDecimal_FactorAtOne() {
            decimal start = 0m;
            decimal end = 10m;
            decimal factor = 1m;
            decimal expected = end;
            decimal result = MathUtils.Lerp(start, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DECIMAL_TOLERANCE, "Lerp should return end value when factor is 1.");
        }

        [TestMethod]
        public void LerpDecimal_FactorBelowZero() {
            decimal start = 0m;
            decimal end = 10m;
            decimal factor = -0.5m;
            decimal expected = start; // Since factor is clamped to 0
            decimal result = MathUtils.Lerp(start, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DECIMAL_TOLERANCE, "Lerp should return start value when factor is below 0.");
        }

        [TestMethod]
        public void LerpDecimal_FactorAboveOne() {
            decimal start = 0m;
            decimal end = 10m;
            decimal factor = 1.5m;
            decimal expected = end; // Since factor is clamped to 1
            decimal result = MathUtils.Lerp(start, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DECIMAL_TOLERANCE, "Lerp should return end value when factor is above 1.");
        }

        [TestMethod]
        public void LerpDecimal_SameStartAndEnd() {
            decimal start = 5m;
            decimal end = 5m;
            decimal factor = 0.5m;
            decimal expected = 5m;
            decimal result = MathUtils.Lerp(start, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DECIMAL_TOLERANCE, "Lerp should return the same value when start and end are the same.");
        }

        [TestMethod]
        public void QerpFloat_FactorAtZero() {
            float start = 0f;
            float control = 5f;
            float end = 10f;
            float factor = 0f;
            float expected = start;
            float result = MathUtils.Qerp(start, control, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.FLOAT_TOLERANCE, "Qerp should return the start value when the factor is 0.");
        }

        [TestMethod]
        public void QerpFloat_FactorAtOne() {
            float start = 0f;
            float control = 5f;
            float end = 10f;
            float factor = 1f;
            float expected = end;
            float result = MathUtils.Qerp(start, control, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.FLOAT_TOLERANCE, "Qerp should return the end value when the factor is 1.");
        }

        [TestMethod]
        public void QerpFloat_StandardInterpolation() {
            float start = 0f;
            float control = 5f;
            float end = 10f;
            float factor = 0.5f;
            // Calculate expected value for quadratic interpolation
            float expected = ((1 - factor) * (1 - factor) * start) +
                             (2 * (1 - factor) * factor * control) +
                             (factor * factor * end);
            float result = MathUtils.Qerp(start, control, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.FLOAT_TOLERANCE, "Qerp should correctly interpolate for a factor of 0.5.");
        }

        [TestMethod]
        public void QerpFloat_SameStartAndEnd() {
            float start = 5f;
            float control = 10f;
            float end = 5f;
            float factor = 0.5f;
            float expected = ((1 - factor) * (1 - factor) * start) +
                             (2 * (1 - factor) * factor * control) +
                             (factor * factor * end);
            float result = MathUtils.Qerp(start, control, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.FLOAT_TOLERANCE, "Qerp should return a value influenced by the control point when start and end are the same.");
        }

        [TestMethod]
        public void QerpDouble_FactorAtZero() {
            double start = 0d;
            double control = 5d;
            double end = 10d;
            double factor = 0d;
            double expected = start;
            double result = MathUtils.Qerp(start, control, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DOUBLE_TOLERANCE, "Qerp should return the start value when the factor is 0.");
        }

        [TestMethod]
        public void QerpDouble_FactorAtOne() {
            double start = 0d;
            double control = 5d;
            double end = 10d;
            double factor = 1d;
            double expected = end;
            double result = MathUtils.Qerp(start, control, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DOUBLE_TOLERANCE, "Qerp should return the end value when the factor is 1.");
        }

        [TestMethod]
        public void QerpDouble_StandardInterpolation() {
            double start = 0d;
            double control = 5d;
            double end = 10d;
            double factor = 0.5d;
            // Calculate expected value for quadratic interpolation
            double expected = ((1 - factor) * (1 - factor) * start) +
                             (2 * (1 - factor) * factor * control) +
                             (factor * factor * end);
            double result = MathUtils.Qerp(start, control, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DOUBLE_TOLERANCE, "Qerp should correctly interpolate for a factor of 0.5.");
        }

        [TestMethod]
        public void QerpDouble_SameStartAndEnd() {
            double start = 5d;
            double control = 10d;
            double end = 5d;
            double factor = 0.5d;
            double expected = ((1 - factor) * (1 - factor) * start) +
                             (2 * (1 - factor) * factor * control) +
                             (factor * factor * end);
            double result = MathUtils.Qerp(start, control, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DOUBLE_TOLERANCE, "Qerp should return a value influenced by the control point when start and end are the same.");
        }

        [TestMethod]
        public void QerpDecimal_FactorAtZero() {
            decimal start = 0m;
            decimal control = 5m;
            decimal end = 10m;
            decimal factor = 0m;
            decimal expected = start;
            decimal result = MathUtils.Qerp(start, control, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DECIMAL_TOLERANCE, "Qerp should return the start value when the factor is 0.");
        }

        [TestMethod]
        public void QerpDecimal_FactorAtOne() {
            decimal start = 0m;
            decimal control = 5m;
            decimal end = 10m;
            decimal factor = 1m;
            decimal expected = end;
            decimal result = MathUtils.Qerp(start, control, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DECIMAL_TOLERANCE, "Qerp should return the end value when the factor is 1.");
        }

        [TestMethod]
        public void QerpDecimal_StandardInterpolation() {
            decimal start = 0m;
            decimal control = 5m;
            decimal end = 10m;
            decimal factor = 0.5m;
            // Calculate expected value for quadratic interpolation
            decimal expected = ((1 - factor) * (1 - factor) * start) +
                             (2 * (1 - factor) * factor * control) +
                             (factor * factor * end);
            decimal result = MathUtils.Qerp(start, control, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DECIMAL_TOLERANCE, "Qerp should correctly interpolate for a factor of 0.5.");
        }

        [TestMethod]
        public void QerpDecimal_SameStartAndEnd() {
            decimal start = 5m;
            decimal control = 10m;
            decimal end = 5m;
            decimal factor = 0.5m;
            decimal expected = ((1 - factor) * (1 - factor) * start) +
                             (2 * (1 - factor) * factor * control) +
                             (factor * factor * end);
            decimal result = MathUtils.Qerp(start, control, end, factor);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DECIMAL_TOLERANCE, "Qerp should return a value influenced by the control point when start and end are the same.");
        }

        [TestMethod]
        public void InverseLerpFloat_MidRangeValue() {
            float value = 5f;
            float min = 0f;
            float max = 10f;
            float expected = 0.5f; // Mid-range value
            float result = MathUtils.InverseLerp(value, min, max);
            Assert.AreEqual(expected, result, MathUtilsHelpers.FLOAT_TOLERANCE, "InverseLerp should return 0.5 for a mid-range value.");
        }

        [TestMethod]
        public void InverseLerpFloat_ValueAtMin() {
            float value = 0f;
            float min = 0f;
            float max = 10f;
            float expected = 0f; // Value at min
            float result = MathUtils.InverseLerp(value, min, max);
            Assert.AreEqual(expected, result, MathUtilsHelpers.FLOAT_TOLERANCE, "InverseLerp should return 0 when the value is at the minimum.");
        }

        [TestMethod]
        public void InverseLerpFloat_ValueAtMax() {
            float value = 10f;
            float min = 0f;
            float max = 10f;
            float expected = 1f; // Value at max
            float result = MathUtils.InverseLerp(value, min, max);
            Assert.AreEqual(expected, result, MathUtilsHelpers.FLOAT_TOLERANCE, "InverseLerp should return 1 when the value is at the maximum.");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void InverseLerpFloat_ZeroRange() {
            float value = 5f;
            float min = 5f;
            float max = 5f;
            MathUtils.InverseLerp(value, min, max); // This should throw a DivideByZeroException
        }

        [TestMethod]
        public void InverseLerpDouble_MidRangeValue() {
            double value = 5d;
            double min = 0d;
            double max = 10d;
            double expected = 0.5d; // Mid-range value
            double result = MathUtils.InverseLerp(value, min, max);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DOUBLE_TOLERANCE, "InverseLerp should return 0.5 for a mid-range value.");
        }

        [TestMethod]
        public void InverseLerpDouble_ValueAtMin() {
            double value = 0d;
            double min = 0d;
            double max = 10d;
            double expected = 0d; // Value at min
            double result = MathUtils.InverseLerp(value, min, max);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DOUBLE_TOLERANCE, "InverseLerp should return 0 when the value is at the minimum.");
        }

        [TestMethod]
        public void InverseLerpDouble_ValueAtMax() {
            double value = 10d;
            double min = 0d;
            double max = 10d;
            double expected = 1d; // Value at max
            double result = MathUtils.InverseLerp(value, min, max);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DOUBLE_TOLERANCE, "InverseLerp should return 1 when the value is at the maximum.");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void InverseLerpDouble_ZeroRange() {
            double value = 5d;
            double min = 5d;
            double max = 5d;
            MathUtils.InverseLerp(value, min, max); // This should throw a DivideByZeroException
        }

        [TestMethod]
        public void InverseLerpDecimal_MidRangeValue() {
            decimal value = 5m;
            decimal min = 0m;
            decimal max = 10m;
            decimal expected = 0.5m; // Mid-range value
            decimal result = MathUtils.InverseLerp(value, min, max);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DECIMAL_TOLERANCE, "InverseLerp should return 0.5 for a mid-range value.");
        }

        [TestMethod]
        public void InverseLerpDecimal_ValueAtMin() {
            decimal value = 0m;
            decimal min = 0m;
            decimal max = 10m;
            decimal expected = 0m; // Value at min
            decimal result = MathUtils.InverseLerp(value, min, max);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DECIMAL_TOLERANCE, "InverseLerp should return 0 when the value is at the minimum.");
        }

        [TestMethod]
        public void InverseLerpDecimal_ValueAtMax() {
            decimal value = 10m;
            decimal min = 0m;
            decimal max = 10m;
            decimal expected = 1m; // Value at max
            decimal result = MathUtils.InverseLerp(value, min, max);
            Assert.AreEqual(expected, result, MathUtilsHelpers.DECIMAL_TOLERANCE, "InverseLerp should return 1 when the value is at the maximum.");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void InverseLerpDecimal_ZeroRange() {
            decimal value = 5m;
            decimal min = 5m;
            decimal max = 5m;
            MathUtils.InverseLerp(value, min, max); // This should throw a DivideByZeroException
        }

        #endregion Interpolation
    }
}