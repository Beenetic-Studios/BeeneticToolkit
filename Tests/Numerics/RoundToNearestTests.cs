using BeeneticToolkit.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeeneticToolkit.Tests.Numerics {

    [TestClass]
    public class RoundToNearestTests {

        #region Round To Nearest

        [TestMethod]
        public void RoundToNearestFloat_StandardCase() {
            float value = 5.3f;
            float interval = 1f;
            float expected = 5f;
            float result = MathKit.RoundToNearest(value, interval);
            Assert.AreEqual(expected, result, "RoundToNearest should round the value to the nearest interval.");
        }

        [TestMethod]
        public void RoundToNearestFloat_WithHalfwayValue() {
            float value = 5.5f;
            float interval = 1f;
            float expected = 6f;
            float result = MathKit.RoundToNearest(value, interval);
            Assert.AreEqual(expected, result, "RoundToNearest should correctly round halfway values.");
        }

        [TestMethod]
        public void RoundToNearestFloat_WithDifferentInterval() {
            float value = 5.25f;
            float interval = 0.5f;
            float expected = 5.5f;
            float result = MathKit.RoundToNearest(value, interval);
            Assert.AreEqual(expected, result, "RoundToNearest should work with different intervals.");
        }

        [TestMethod]
        public void RoundToNearestFloat_ZeroInterval() {
            float value = 5.5f;
            float interval = 0f;
            float expected = 6f;
            float result = MathKit.RoundToNearest(value, interval);
            Assert.AreEqual(expected, result, "RoundToNearest should correctly round to nearest integer with interval 0.");
        }

        [TestMethod]
        public void RoundToNearestFloat_NegativeValue() {
            float value = -5.3f;
            float interval = 1f;
            float expected = -5f;
            float result = MathKit.RoundToNearest(value, interval);
            Assert.AreEqual(expected, result, "RoundToNearest should correctly round negative values.");
        }

        [TestMethod]
        public void RoundToNearestFloat_NegativeInterval() {
            float value = 5.3f;
            float interval = -1f;
            float expected = 5f; // Assuming negative intervals behave like positive intervals
            float result = MathKit.RoundToNearest(value, interval);
            Assert.AreEqual(expected, result, "RoundToNearest should handle negative intervals by treating them as positive.");
        }

        [TestMethod]
        public void RoundToNearestFloat_LargeInterval() {
            float value = 1234.567f;
            float interval = 1000f;
            float expected = 1000f; // Assuming standard rounding
            float result = MathKit.RoundToNearest(value, interval);
            Assert.AreEqual(expected, result, "RoundToNearest should handle large intervals correctly.");
        }

        [TestMethod]
        public void RoundToNearestDouble_StandardCase() {
            double value = 5.3d;
            double interval = 1d;
            double expected = 5d;
            double result = MathKit.RoundToNearest(value, interval);
            Assert.AreEqual(expected, result, "RoundToNearest should round the value to the nearest interval.");
        }

        [TestMethod]
        public void RoundToNearestDouble_WithHalfwayValue() {
            double value = 5.5d;
            double interval = 1d;
            double expected = 6d;
            double result = MathKit.RoundToNearest(value, interval);
            Assert.AreEqual(expected, result, "RoundToNearest should correctly round halfway values.");
        }

        [TestMethod]
        public void RoundToNearestDouble_WithDifferentInterval() {
            double value = 5.25d;
            double interval = 0.5d;
            double expected = 5.5d;
            double result = MathKit.RoundToNearest(value, interval);
            Assert.AreEqual(expected, result, "RoundToNearest should work with different intervals.");
        }

        [TestMethod]
        public void RoundToNearestDouble_ZeroInterval() {
            double value = 5.5d;
            double interval = 0d;
            double expected = 6d;
            double result = MathKit.RoundToNearest(value, interval);
            Assert.AreEqual(expected, result, "RoundToNearest should correctly round to nearest integer with interval 0.");
        }

        [TestMethod]
        public void RoundToNearestDouble_NegativeValue() {
            double value = -5.3d;
            double interval = 1d;
            double expected = -5d;
            double result = MathKit.RoundToNearest(value, interval);
            Assert.AreEqual(expected, result, "RoundToNearest should correctly round negative values.");
        }

        [TestMethod]
        public void RoundToNearestDouble_NegativeInterval() {
            double value = 5.3d;
            double interval = -1d;
            double expected = 5d; // Assuming negative intervals behave like positive intervals
            double result = MathKit.RoundToNearest(value, interval);
            Assert.AreEqual(expected, result, "RoundToNearest should handle negative intervals by treating them as positive.");
        }

        [TestMethod]
        public void RoundToNearestDouble_LargeInterval() {
            double value = 1234.567d;
            double interval = 1000d;
            double expected = 1000d; // Assuming standard rounding
            double result = MathKit.RoundToNearest(value, interval);
            Assert.AreEqual(expected, result, "RoundToNearest should handle large intervals correctly.");
        }

        [TestMethod]
        public void RoundToNearestDecimal_StandardCase() {
            decimal value = 5.3m;
            decimal interval = 1m;
            decimal expected = 5m;
            decimal result = MathKit.RoundToNearest(value, interval);
            Assert.AreEqual(expected, result, "RoundToNearest should round the value to the nearest interval.");
        }

        [TestMethod]
        public void RoundToNearestDecimal_WithHalfwayValue() {
            decimal value = 5.5m;
            decimal interval = 1m;
            decimal expected = 6m;
            decimal result = MathKit.RoundToNearest(value, interval);
            Assert.AreEqual(expected, result, "RoundToNearest should correctly round halfway values.");
        }

        [TestMethod]
        public void RoundToNearestDecimal_WithDifferentInterval() {
            decimal value = 5.25m;
            decimal interval = 0.5m;
            decimal expected = 5.5m;
            decimal result = MathKit.RoundToNearest(value, interval);
            Assert.AreEqual(expected, result, "RoundToNearest should work with different intervals.");
        }

        [TestMethod]
        public void RoundToNearestDecimal_ZeroInterval() {
            decimal value = 5.5m;
            decimal interval = 0m;
            decimal expected = 6m;
            decimal result = MathKit.RoundToNearest(value, interval);
            Assert.AreEqual(expected, result, "RoundToNearest should correctly round to nearest integer with interval 0.");
        }

        [TestMethod]
        public void RoundToNearestDecimal_NegativeValue() {
            decimal value = -5.3m;
            decimal interval = 1m;
            decimal expected = -5m;
            decimal result = MathKit.RoundToNearest(value, interval);
            Assert.AreEqual(expected, result, "RoundToNearest should correctly round negative values.");
        }

        [TestMethod]
        public void RoundToNearestDecimal_NegativeInterval() {
            decimal value = 5.3m;
            decimal interval = -1m;
            decimal expected = 5m; // Assuming negative intervals behave like positive intervals
            decimal result = MathKit.RoundToNearest(value, interval);
            Assert.AreEqual(expected, result, "RoundToNearest should handle negative intervals by treating them as positive.");
        }

        [TestMethod]
        public void RoundToNearestDecimal_LargeInterval() {
            decimal value = 1234.567m;
            decimal interval = 1000m;
            decimal expected = 1000m; // Assuming standard rounding
            decimal result = MathKit.RoundToNearest(value, interval);
            Assert.AreEqual(expected, result, "RoundToNearest should handle large intervals correctly.");
        }

        #endregion Round To Nearest
    }
}