using BeeneticToolkit.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeeneticToolkit.Tests.Numerics {

    [TestClass]
    public class NumericsEnhancementsTests {

        private const double Tol = 1e-6;

        #region LerpUnclamped

        [TestMethod]
        public void LerpUnclamped_Extrapolates() {
            Assert.AreEqual(20.0, MathKit.LerpUnclamped(0.0, 10.0, 2.0), Tol);
            Assert.AreEqual(-10.0, MathKit.LerpUnclamped(0.0, 10.0, -1.0), Tol);
            Assert.AreEqual(5.0, MathKit.LerpUnclamped(0.0, 10.0, 0.5), Tol);
        }

        #endregion LerpUnclamped

        #region Remap

        [TestMethod]
        public void Remap_MapsBetweenRanges() {
            Assert.AreEqual(50.0, MathKit.Remap(0.5, 0.0, 1.0, 0.0, 100.0), Tol);
            Assert.AreEqual(0.0, MathKit.Remap(10.0, 10.0, 20.0, 0.0, 1.0), Tol);
            Assert.AreEqual(1.0, MathKit.Remap(20.0, 10.0, 20.0, 0.0, 1.0), Tol);
        }

        [TestMethod]
        public void Remap_Unclamped_Extrapolates() {
            Assert.AreEqual(2.0, MathKit.Remap(30.0, 10.0, 20.0, 0.0, 1.0), Tol);
        }

        [TestMethod]
        public void Remap_ZeroSourceRange_Throws() {
            Assert.ThrowsException<DivideByZeroException>(() => MathKit.Remap(5.0, 10.0, 10.0, 0.0, 1.0));
        }

        [TestMethod]
        public void RemapClamped_ClampsToDestinationRange() {
            Assert.AreEqual(1.0, MathKit.RemapClamped(30.0, 10.0, 20.0, 0.0, 1.0), Tol);
            Assert.AreEqual(0.0, MathKit.RemapClamped(5.0, 10.0, 20.0, 0.0, 1.0), Tol);
            Assert.AreEqual(0.5, MathKit.RemapClamped(15.0, 10.0, 20.0, 0.0, 1.0), Tol);
        }

        #endregion Remap

        #region SmoothStep

        [TestMethod]
        public void SmoothStep_ClampsAndEases() {
            Assert.AreEqual(0.0, MathKit.SmoothStep(0.0, 10.0, -1.0), Tol);
            Assert.AreEqual(10.0, MathKit.SmoothStep(0.0, 10.0, 2.0), Tol);
            Assert.AreEqual(5.0, MathKit.SmoothStep(0.0, 10.0, 0.5), Tol); // symmetric midpoint
            // Eased value at t=0.25 is below the linear value (2.5)
            Assert.IsTrue(MathKit.SmoothStep(0.0, 10.0, 0.25) < 2.5);
        }

        #endregion SmoothStep

        #region Angles

        [TestMethod]
        public void Deg2Rad_Rad2Deg_Constants() {
            Assert.AreEqual(MathF.PI / 180f, MathKit.Deg2Rad);
            Assert.AreEqual(180f / MathF.PI, MathKit.Rad2Deg);
        }

        [TestMethod]
        public void ToRadians_ToDegrees_RoundTrip() {
            Assert.AreEqual(MathF.PI, MathKit.ToRadians(180f), 1e-5f);
            Assert.AreEqual(90f, MathKit.ToDegrees(MathKit.ToRadians(90f)), 1e-3f);
        }

        [TestMethod]
        public void WrapDegrees_WrapsToSignedRange() {
            Assert.AreEqual(-170.0, MathKit.WrapDegrees(190.0), Tol);
            Assert.AreEqual(170.0, MathKit.WrapDegrees(-190.0), Tol);
            Assert.AreEqual(-180.0, MathKit.WrapDegrees(180.0), Tol);
            Assert.AreEqual(0.0, MathKit.WrapDegrees(360.0), Tol);
            Assert.AreEqual(10.0, MathKit.WrapDegrees(730.0), Tol); // 730 = 2*360 + 10
        }

        [TestMethod]
        public void WrapRadians_WrapsToSignedRange() {
            double wrapped = MathKit.WrapRadians(3 * Math.PI); // equivalent to PI -> wraps to -PI
            Assert.IsTrue(wrapped >= -Math.PI && wrapped < Math.PI);
            Assert.AreEqual(-Math.PI, wrapped, 1e-9);
        }

        #endregion Angles

        #region IsApproximatelyRelative

        [TestMethod]
        public void IsApproximatelyRelative_HandlesLargeMagnitudes() {
            // Absolute comparison fails here, relative succeeds.
            Assert.IsFalse(MathKit.IsApproximately(1e9, 1e9 + 50));
            Assert.IsTrue(MathKit.IsApproximatelyRelative(1e9, 1e9 + 50, 1e-6));
        }

        [TestMethod]
        public void IsApproximatelyRelative_ExactlyEqual_True() {
            Assert.IsTrue(MathKit.IsApproximatelyRelative(42.0, 42.0));
        }

        [TestMethod]
        public void IsApproximatelyRelative_NaN_False() {
            Assert.IsFalse(MathKit.IsApproximatelyRelative(double.NaN, double.NaN));
            Assert.IsFalse(MathKit.IsApproximatelyRelative(double.NaN, 1.0));
        }

        [TestMethod]
        public void IsApproximatelyRelative_Infinities() {
            Assert.IsTrue(MathKit.IsApproximatelyRelative(double.PositiveInfinity, double.PositiveInfinity));
            Assert.IsFalse(MathKit.IsApproximatelyRelative(double.PositiveInfinity, 5.0));
            Assert.IsFalse(MathKit.IsApproximatelyRelative(double.PositiveInfinity, double.NegativeInfinity));
        }

        #endregion IsApproximatelyRelative
    }
}
