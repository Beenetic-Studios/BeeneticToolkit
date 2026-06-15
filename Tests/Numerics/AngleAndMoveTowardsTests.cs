using BeeneticToolkit.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeeneticToolkit.Tests.Numerics {

    [TestClass]
    public class AngleAndMoveTowardsTests {

        // --- MoveTowards (scalar) ---

        [TestMethod]
        public void MoveTowards_StepsTowardTarget() {
            Assert.AreEqual(3f, MathKit.MoveTowards(0f, 10f, 3f));
            Assert.AreEqual(7f, MathKit.MoveTowards(10f, 0f, 3f));
        }

        [TestMethod]
        public void MoveTowards_DoesNotOvershoot() {
            Assert.AreEqual(10f, MathKit.MoveTowards(8f, 10f, 5f));   // would overshoot → clamps to target
            Assert.AreEqual(10f, MathKit.MoveTowards(10f, 10f, 5f));  // already there
        }

        [TestMethod]
        public void MoveTowards_NegativeDelta_MovesAway() {
            Assert.AreEqual(-2f, MathKit.MoveTowards(0f, 10f, -2f));
        }

        [TestMethod]
        public void MoveTowards_DoubleAndDecimal_Work() {
            Assert.AreEqual(3.0, MathKit.MoveTowards(0.0, 10.0, 3.0), 1e-12);
            Assert.AreEqual(3m, MathKit.MoveTowards(0m, 10m, 3m));
        }

        // --- DeltaAngle ---

        [TestMethod]
        public void DeltaAngleDegrees_TakesShortestSignedPath() {
            Assert.AreEqual(20f, MathKit.DeltaAngleDegrees(350f, 10f), 1e-4f);   // forward across 0
            Assert.AreEqual(-20f, MathKit.DeltaAngleDegrees(10f, 350f), 1e-4f);  // backward across 0
            Assert.AreEqual(90f, MathKit.DeltaAngleDegrees(0f, 90f), 1e-4f);
        }

        [TestMethod]
        public void DeltaAngleRadians_TakesShortestSignedPath() {
            float twoPi = MathF.PI * 2f;
            // From 350° to 10° expressed in radians.
            float d = MathKit.DeltaAngleRadians(twoPi * (350f / 360f), twoPi * (10f / 360f));
            Assert.AreEqual(twoPi * (20f / 360f), d, 1e-4f);
        }

        // --- LerpAngle ---

        [TestMethod]
        public void LerpAngleDegrees_CrossesSeamCorrectly() {
            // Halfway from 350° to 10° (shortest path) is 360°/0° → 360 unwrapped.
            float mid = MathKit.LerpAngleDegrees(350f, 10f, 0.5f);
            Assert.AreEqual(360f, mid, 1e-3f);
            Assert.AreEqual(350f, MathKit.LerpAngleDegrees(350f, 10f, 0f), 1e-4f);
        }

        [TestMethod]
        public void LerpAngleDegrees_ClampsFactor() {
            // t clamps to 1 → 350 + delta(20) = 370, the unwrapped equivalent of the 10° target.
            Assert.AreEqual(370f, MathKit.LerpAngleDegrees(350f, 10f, 5f), 1e-3f);
        }

        // --- MoveTowardsAngle ---

        [TestMethod]
        public void MoveTowardsAngleDegrees_TurnsShortWay_NoOvershoot() {
            Assert.AreEqual(355f, MathKit.MoveTowardsAngleDegrees(350f, 10f, 5f), 1e-3f);   // step 5 toward 10 via 0
            Assert.AreEqual(10f, MathKit.MoveTowardsAngleDegrees(350f, 10f, 100f), 1e-3f);  // close enough → snaps to target
        }

        [TestMethod]
        public void MoveTowardsAngleRadians_Works() {
            float twoPi = MathF.PI * 2f;
            float start = twoPi * (350f / 360f);
            float result = MathKit.MoveTowardsAngleRadians(start, twoPi * (10f / 360f), twoPi);
            // maxDelta huge → snaps to target value.
            Assert.AreEqual(twoPi * (10f / 360f), result, 1e-3f);
        }
    }
}
