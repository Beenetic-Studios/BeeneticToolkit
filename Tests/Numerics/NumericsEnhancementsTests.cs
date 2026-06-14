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
            Assert.AreEqual(20.0, InterpolationUtils.LerpUnclamped(0.0, 10.0, 2.0), Tol);
            Assert.AreEqual(-10.0, InterpolationUtils.LerpUnclamped(0.0, 10.0, -1.0), Tol);
            Assert.AreEqual(5.0, InterpolationUtils.LerpUnclamped(0.0, 10.0, 0.5), Tol);
        }

        #endregion LerpUnclamped

        #region Remap

        [TestMethod]
        public void Remap_MapsBetweenRanges() {
            Assert.AreEqual(50.0, InterpolationUtils.Remap(0.5, 0.0, 1.0, 0.0, 100.0), Tol);
            Assert.AreEqual(0.0, InterpolationUtils.Remap(10.0, 10.0, 20.0, 0.0, 1.0), Tol);
            Assert.AreEqual(1.0, InterpolationUtils.Remap(20.0, 10.0, 20.0, 0.0, 1.0), Tol);
        }

        [TestMethod]
        public void Remap_Unclamped_Extrapolates() {
            Assert.AreEqual(2.0, InterpolationUtils.Remap(30.0, 10.0, 20.0, 0.0, 1.0), Tol);
        }

        [TestMethod]
        public void Remap_ZeroSourceRange_Throws() {
            Assert.ThrowsException<DivideByZeroException>(() => InterpolationUtils.Remap(5.0, 10.0, 10.0, 0.0, 1.0));
        }

        [TestMethod]
        public void RemapClamped_ClampsToDestinationRange() {
            Assert.AreEqual(1.0, InterpolationUtils.RemapClamped(30.0, 10.0, 20.0, 0.0, 1.0), Tol);
            Assert.AreEqual(0.0, InterpolationUtils.RemapClamped(5.0, 10.0, 20.0, 0.0, 1.0), Tol);
            Assert.AreEqual(0.5, InterpolationUtils.RemapClamped(15.0, 10.0, 20.0, 0.0, 1.0), Tol);
        }

        #endregion Remap

        #region SmoothStep

        [TestMethod]
        public void SmoothStep_ClampsAndEases() {
            Assert.AreEqual(0.0, InterpolationUtils.SmoothStep(0.0, 10.0, -1.0), Tol);
            Assert.AreEqual(10.0, InterpolationUtils.SmoothStep(0.0, 10.0, 2.0), Tol);
            Assert.AreEqual(5.0, InterpolationUtils.SmoothStep(0.0, 10.0, 0.5), Tol); // symmetric midpoint
            // Eased value at t=0.25 is below the linear value (2.5)
            Assert.IsTrue(InterpolationUtils.SmoothStep(0.0, 10.0, 0.25) < 2.5);
        }

        #endregion SmoothStep

        #region AngleUtils

        [TestMethod]
        public void Deg2Rad_Rad2Deg_Constants() {
            Assert.AreEqual(MathF.PI / 180f, AngleUtils.Deg2Rad);
            Assert.AreEqual(180f / MathF.PI, AngleUtils.Rad2Deg);
        }

        [TestMethod]
        public void ToRadians_ToDegrees_RoundTrip() {
            Assert.AreEqual(MathF.PI, AngleUtils.ToRadians(180f), 1e-5f);
            Assert.AreEqual(90f, AngleUtils.ToDegrees(AngleUtils.ToRadians(90f)), 1e-3f);
        }

        [TestMethod]
        public void WrapDegrees_WrapsToSignedRange() {
            Assert.AreEqual(-170.0, AngleUtils.WrapDegrees(190.0), Tol);
            Assert.AreEqual(170.0, AngleUtils.WrapDegrees(-190.0), Tol);
            Assert.AreEqual(-180.0, AngleUtils.WrapDegrees(180.0), Tol);
            Assert.AreEqual(0.0, AngleUtils.WrapDegrees(360.0), Tol);
            Assert.AreEqual(10.0, AngleUtils.WrapDegrees(730.0), Tol); // 730 = 2*360 + 10
        }

        [TestMethod]
        public void WrapRadians_WrapsToSignedRange() {
            double wrapped = AngleUtils.WrapRadians(3 * Math.PI); // equivalent to PI -> wraps to -PI
            Assert.IsTrue(wrapped >= -Math.PI && wrapped < Math.PI);
            Assert.AreEqual(-Math.PI, wrapped, 1e-9);
        }

        #endregion AngleUtils

        #region IsApproximatelyRelative

        [TestMethod]
        public void IsApproximatelyRelative_HandlesLargeMagnitudes() {
            // Absolute comparison fails here, relative succeeds.
            Assert.IsFalse(NumericalUtils.IsApproximately(1e9, 1e9 + 50));
            Assert.IsTrue(NumericalUtils.IsApproximatelyRelative(1e9, 1e9 + 50, 1e-6));
        }

        [TestMethod]
        public void IsApproximatelyRelative_ExactlyEqual_True() {
            Assert.IsTrue(NumericalUtils.IsApproximatelyRelative(42.0, 42.0));
        }

        [TestMethod]
        public void IsApproximatelyRelative_NaN_False() {
            Assert.IsFalse(NumericalUtils.IsApproximatelyRelative(double.NaN, double.NaN));
            Assert.IsFalse(NumericalUtils.IsApproximatelyRelative(double.NaN, 1.0));
        }

        [TestMethod]
        public void IsApproximatelyRelative_Infinities() {
            Assert.IsTrue(NumericalUtils.IsApproximatelyRelative(double.PositiveInfinity, double.PositiveInfinity));
            Assert.IsFalse(NumericalUtils.IsApproximatelyRelative(double.PositiveInfinity, 5.0));
            Assert.IsFalse(NumericalUtils.IsApproximatelyRelative(double.PositiveInfinity, double.NegativeInfinity));
        }

        #endregion IsApproximatelyRelative
    }
}
