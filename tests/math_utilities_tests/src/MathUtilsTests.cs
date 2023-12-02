using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeeneticToolkit.MathUtils {

    [TestClass]
    public class MathUtilsTests {

        #region Clamp

        [TestMethod]
        public void Clamp01_WithValueWithinRange_ReturnsSameValue() {
            float value = 0.5f;
            float result = MathUtils.Clamp01(value);
            Assert.AreEqual(value, result, "Clamp01 should return the same value when it's within the range.");
        }

        [TestMethod]
        public void Clamp01_WithValueBelowRange_ReturnsZero() {
            float value = -0.1f;
            float result = MathUtils.Clamp01(value);
            Assert.AreEqual(0.0f, result, "Clamp01 should return 0 for values below the range.");
        }

        [TestMethod]
        public void Clamp01_WithValueAboveRange_ReturnsOne() {
            float value = 1.1f;
            float result = MathUtils.Clamp01(value);
            Assert.AreEqual(1.0f, result, "Clamp01 should return 1 for values above the range.");
        }

        [TestMethod]
        public void Clamp01_WithBoundaryValueZero_ReturnsZero() {
            float value = 0.0f;
            float result = MathUtils.Clamp01(value);
            Assert.AreEqual(0.0f, result, "Clamp01 should return 0 for the boundary value of 0.");
        }

        [TestMethod]
        public void Clamp01_WithBoundaryValueOne_ReturnsOne() {
            float value = 1.0f;
            float result = MathUtils.Clamp01(value);
            Assert.AreEqual(1.0f, result, "Clamp01 should return 1 for the boundary value of 1.");
        }
    }

    #endregion Clamp
}