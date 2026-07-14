using System;
using BeeneticToolkit.BigMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeeneticToolkit.Tests.BigMath {

    [TestClass]
    public class BigDoubleInterpolationTests {

        [TestMethod]
        public void Lerp_Endpoints_AreExact() {
            BigDouble a = BigDouble.Pow10(100);
            BigDouble b = BigDouble.Pow10(200);
            Assert.IsTrue(BigDouble.Lerp(a, b, 0.0).Equals(a));
            Assert.IsTrue(BigDouble.Lerp(a, b, 1.0).Equals(b));
        }

        [TestMethod]
        public void Lerp_Midpoint_IsBetween() {
            BigDouble a = (BigDouble)0;
            BigDouble b = (BigDouble)1000;
            Assert.IsTrue(BigDouble.Lerp(a, b, 0.5).EqualsApproximately((BigDouble)500));
        }

        [TestMethod]
        public void Lerp_ClampsFactorOutsideUnitRange() {
            BigDouble a = (BigDouble)10;
            BigDouble b = (BigDouble)20;
            Assert.IsTrue(BigDouble.Lerp(a, b, -5.0).Equals(a));
            Assert.IsTrue(BigDouble.Lerp(a, b, 5.0).Equals(b));
        }

        [TestMethod]
        public void LerpUnclamped_Extrapolates() {
            BigDouble a = (BigDouble)0;
            BigDouble b = (BigDouble)100;
            Assert.IsTrue(BigDouble.LerpUnclamped(a, b, 2.0).EqualsApproximately((BigDouble)200));
        }

        [TestMethod]
        public void InverseLerp_ReturnsFactor() {
            double factor = BigDouble.InverseLerp((BigDouble)500, (BigDouble)0, (BigDouble)1000);
            Assert.AreEqual(0.5, factor, 1e-9);
        }

        [TestMethod]
        public void InverseLerp_ZeroRange_Throws() {
            Assert.ThrowsException<DivideByZeroException>(
                () => BigDouble.InverseLerp((BigDouble)5, (BigDouble)10, (BigDouble)10));
        }
    }
}
