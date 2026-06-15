using BeeneticToolkit.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeeneticToolkit.Tests.Numerics {

    [TestClass]
    public class SplineInterpolationTests {

        // --- Cerp (cubic Bezier) ---

        [TestMethod]
        public void Cerp_HitsEndpoints() {
            Assert.AreEqual(0f, InterpolationUtils.Cerp(0f, 1f, 2f, 10f, 0f), 1e-5f);
            Assert.AreEqual(10f, InterpolationUtils.Cerp(0f, 1f, 2f, 10f, 1f), 1e-5f);
        }

        [TestMethod]
        public void Cerp_CollinearControlPoints_AreLinear() {
            // Evenly spaced, collinear control points → the curve is a straight line.
            Assert.AreEqual(1.5f, InterpolationUtils.Cerp(0f, 1f, 2f, 3f, 0.5f), 1e-5f);
            Assert.AreEqual(0.75, InterpolationUtils.Cerp(0d, 1d, 2d, 3d, 0.25d), 1e-12);
        }

        [TestMethod]
        public void Cerp_Decimal_Works() {
            Assert.AreEqual(1.5m, InterpolationUtils.Cerp(0m, 1m, 2m, 3m, 0.5m));
        }

        // --- CatmullRom ---

        [TestMethod]
        public void CatmullRom_PassesThroughMiddleControlPoints() {
            // At t=0 it returns p1; at t=1 it returns p2.
            Assert.AreEqual(5f, InterpolationUtils.CatmullRom(2f, 5f, 8f, 12f, 0f), 1e-5f);
            Assert.AreEqual(8f, InterpolationUtils.CatmullRom(2f, 5f, 8f, 12f, 1f), 1e-5f);
        }

        [TestMethod]
        public void CatmullRom_CollinearPoints_AreLinear() {
            // Equally spaced collinear points → linear interpolation between p1 and p2.
            Assert.AreEqual(1.5f, InterpolationUtils.CatmullRom(0f, 1f, 2f, 3f, 0.5f), 1e-5f);
            Assert.AreEqual(1.25, InterpolationUtils.CatmullRom(0d, 1d, 2d, 3d, 0.25d), 1e-12);
        }

        [TestMethod]
        public void CatmullRom_Decimal_PassesThroughControlPoints() {
            Assert.AreEqual(5m, InterpolationUtils.CatmullRom(2m, 5m, 8m, 12m, 0m));
            Assert.AreEqual(8m, InterpolationUtils.CatmullRom(2m, 5m, 8m, 12m, 1m));
        }
    }
}
