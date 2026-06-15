using BeeneticToolkit.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeeneticToolkit.Tests.Numerics {

    [TestClass]
    public class EasingUtilsTests {

        [TestMethod]
        public void EveryCurve_PassesThroughBothEndpoints() {
            foreach (EasingType type in Enum.GetValues(typeof(EasingType))) {
                Assert.AreEqual(0.0, EasingUtils.Ease(type, 0.0), 1e-9, $"{type} should be 0 at t=0");
                Assert.AreEqual(1.0, EasingUtils.Ease(type, 1.0), 1e-9, $"{type} should be 1 at t=1");
            }
        }

        [TestMethod]
        public void KnownValues_AreCorrect() {
            Assert.AreEqual(0.25, EasingUtils.InQuad(0.5), 1e-12);
            Assert.AreEqual(0.75, EasingUtils.OutQuad(0.5), 1e-12);
            Assert.AreEqual(0.125, EasingUtils.InCubic(0.5), 1e-12);
            Assert.AreEqual(0.875, EasingUtils.OutCubic(0.5), 1e-12);
            Assert.AreEqual(0.5, EasingUtils.InOutQuad(0.5), 1e-12);
        }

        [TestMethod]
        public void OutCurve_IsMirrorOfInCurve() {
            // The standard relation: Out(t) == 1 - In(1 - t).
            for (double t = 0.0; t <= 1.0; t += 0.1) {
                Assert.AreEqual(1.0 - EasingUtils.InQuad(1.0 - t), EasingUtils.OutQuad(t), 1e-12, $"Quad at {t}");
                Assert.AreEqual(1.0 - EasingUtils.InCubic(1.0 - t), EasingUtils.OutCubic(t), 1e-12, $"Cubic at {t}");
                Assert.AreEqual(1.0 - EasingUtils.InExpo(1.0 - t), EasingUtils.OutExpo(t), 1e-12, $"Expo at {t}");
            }
        }

        [TestMethod]
        public void EaseIn_StartsSlow_EaseOut_StartsFast() {
            Assert.IsTrue(EasingUtils.InQuad(0.5) < 0.5, "ease-in should be below linear at the midpoint");
            Assert.IsTrue(EasingUtils.OutQuad(0.5) > 0.5, "ease-out should be above linear at the midpoint");
        }

        [TestMethod]
        public void Back_Overshoots() {
            Assert.IsTrue(EasingUtils.InBack(0.2) < 0.0, "InBack should dip below 0");
            Assert.IsTrue(EasingUtils.OutBack(0.8) > 1.0, "OutBack should rise above 1");
        }

        [TestMethod]
        public void Elastic_IsBoundedAtEndpointsButOscillates() {
            Assert.AreEqual(0.0, EasingUtils.InElastic(0.0), 1e-12);
            Assert.AreEqual(1.0, EasingUtils.OutElastic(1.0), 1e-12);
            // Somewhere in the middle it leaves [0,1].
            bool overshoots = false;
            for (double t = 0.0; t <= 1.0; t += 0.05) {
                double v = EasingUtils.OutElastic(t);
                if (v > 1.0 || v < 0.0) { overshoots = true; break; }
            }
            Assert.IsTrue(overshoots, "OutElastic should oscillate outside [0,1]");
        }

        [TestMethod]
        public void Bounce_StaysWithinUnitInterval() {
            for (double t = 0.0; t <= 1.0; t += 0.05) {
                double v = EasingUtils.OutBounce(t);
                Assert.IsTrue(v >= 0.0 && v <= 1.0, $"OutBounce({t}) = {v} left [0,1]");
            }
        }

        [TestMethod]
        public void Linear_IsIdentity() {
            Assert.AreEqual(0.42, EasingUtils.Linear(0.42), 1e-12);
            Assert.AreEqual(0.42, EasingUtils.Ease(EasingType.Linear, 0.42), 1e-12);
        }

        [TestMethod]
        public void Dispatch_MatchesDirectCall() {
            Assert.AreEqual(EasingUtils.OutBounce(0.3), EasingUtils.Ease(EasingType.OutBounce, 0.3), 1e-12);
            Assert.AreEqual(EasingUtils.InOutElastic(0.6), EasingUtils.Ease(EasingType.InOutElastic, 0.6), 1e-12);
        }

        [TestMethod]
        public void Ease_BetweenValues_Interpolates() {
            Assert.AreEqual(15.0, EasingUtils.Ease(EasingType.Linear, 10.0, 20.0, 0.5), 1e-12);
            Assert.AreEqual(25.0, EasingUtils.Ease(EasingType.InQuad, 0.0, 100.0, 0.5), 1e-12);
            // Overshooting curve goes past the endpoint mid-tween.
            Assert.IsTrue(EasingUtils.Ease(EasingType.OutBack, 0.0f, 100.0f, 0.8f) > 100.0f);
        }

        [TestMethod]
        public void FloatOverloads_TrackDoubleVersions() {
            foreach (EasingType type in Enum.GetValues(typeof(EasingType))) {
                float f = EasingUtils.Ease(type, 0.37f);
                double d = EasingUtils.Ease(type, 0.37);
                Assert.AreEqual(d, f, 1e-4, $"{type} float/double mismatch");
            }
        }

        [TestMethod]
        public void Dispatch_UnknownType_Throws() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => EasingUtils.Ease((EasingType)999, 0.5));
        }
    }
}
