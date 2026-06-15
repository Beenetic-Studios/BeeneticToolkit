using BeeneticToolkit.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeeneticToolkit.Tests.Numerics {

    [TestClass]
    public class MathKitTier2Tests {

        private const double Tol = 1e-6;

        // --- SmootherStep ---

        [TestMethod]
        public void SmootherStep_HitsEndpointsAndMidpoint() {
            Assert.AreEqual(0.0, MathKit.SmootherStep(0.0, 10.0, 0.0), Tol);
            Assert.AreEqual(10.0, MathKit.SmootherStep(0.0, 10.0, 1.0), Tol);
            Assert.AreEqual(5.0, MathKit.SmootherStep(0.0, 10.0, 0.5), Tol); // symmetric
        }

        [TestMethod]
        public void SmootherStep_ClampsAndEasesGentlerThanSmoothStep() {
            Assert.AreEqual(0.0, MathKit.SmootherStep(0.0, 10.0, -1.0), Tol);
            Assert.AreEqual(10.0, MathKit.SmootherStep(0.0, 10.0, 2.0), Tol);
            // Near the start, smoother should be at/under smoothstep (flatter toe).
            Assert.IsTrue(MathKit.SmootherStep(0.0, 1.0, 0.25) <= MathKit.SmoothStep(0.0, 1.0, 0.25) + 1e-9);
        }

        // --- Step ---

        [TestMethod]
        public void Step_IsHardThreshold() {
            Assert.AreEqual(0f, MathKit.Step(5f, 4.99f));
            Assert.AreEqual(1f, MathKit.Step(5f, 5f));     // at edge → 1
            Assert.AreEqual(1f, MathKit.Step(5f, 6f));
            Assert.AreEqual(1m, MathKit.Step(0m, 0m));
        }

        // --- PingPong ---

        [TestMethod]
        public void PingPong_OscillatesBetweenZeroAndLength() {
            Assert.AreEqual(0.0, MathKit.PingPong(0.0, 3.0), Tol);
            Assert.AreEqual(1.5, MathKit.PingPong(1.5, 3.0), Tol);  // rising
            Assert.AreEqual(3.0, MathKit.PingPong(3.0, 3.0), Tol);  // peak
            Assert.AreEqual(1.5, MathKit.PingPong(4.5, 3.0), Tol);  // falling
            Assert.AreEqual(0.0, MathKit.PingPong(6.0, 3.0), Tol);  // back to start
            Assert.AreEqual(1.0, MathKit.PingPong(7.0, 3.0), Tol);  // next cycle rising
        }

        [TestMethod]
        public void PingPong_StaysWithinRange() {
            for (double t = 0; t < 20; t += 0.37) {
                double v = MathKit.PingPong(t, 2.0);
                Assert.IsTrue(v >= 0.0 && v <= 2.0, $"PingPong({t}) = {v} left [0,2]");
            }
        }

        [TestMethod]
        public void PingPong_ValidatesLength() {
            Assert.ThrowsException<ArgumentException>(() => MathKit.PingPong(1f, 0f));
            Assert.ThrowsException<ArgumentException>(() => MathKit.PingPong(1f, -2f));
        }

        // --- SmoothDamp ---

        [TestMethod]
        public void SmoothDamp_ConvergesToTargetWithoutOvershoot() {
            float current = 0f;
            float velocity = 0f;
            float target = 100f;
            float maxSeen = float.MinValue;

            for (int i = 0; i < 1000; i++) {
                current = MathKit.SmoothDamp(current, target, ref velocity, smoothTime: 0.3f, deltaTime: 0.016f);
                maxSeen = Math.Max(maxSeen, current);
                Assert.IsTrue(current <= target + 1e-2f, $"Overshot target: {current}");
            }

            Assert.AreEqual(target, current, 0.1f, "Should converge to the target");
            Assert.IsTrue(maxSeen <= target + 1e-2f, "Critically damped: should not overshoot");
        }

        [TestMethod]
        public void SmoothDamp_MaxSpeed_LimitsMovement() {
            float current = 0f;
            float velocity = 0f;
            // One small step toward a far target with a tight speed cap → bounded by maxSpeed*deltaTime-ish.
            float next = MathKit.SmoothDamp(current, 1000f, ref velocity, smoothTime: 0.1f, deltaTime: 0.1f, maxSpeed: 5f);
            Assert.IsTrue(next < 100f, $"maxSpeed should curb the step, got {next}");
        }

        [TestMethod]
        public void SmoothDamp_AlreadyAtTarget_Stays() {
            float velocity = 0f;
            float result = MathKit.SmoothDamp(50f, 50f, ref velocity, 0.2f, 0.016f);
            Assert.AreEqual(50f, result, 1e-4f);
        }

        // --- SmoothDampAngle ---

        [TestMethod]
        public void SmoothDampAngleDegrees_TakesShortestPath() {
            // From 350° toward 10°: should move forward through 360/0, ending near 10 (i.e. > 350 unwrapped).
            float current = 350f;
            float velocity = 0f;
            for (int i = 0; i < 1000; i++)
                current = MathKit.SmoothDampAngleDegrees(current, 10f, ref velocity, 0.2f, 0.016f);

            // Converges to 370 (== 10° mod 360), proving it crossed the seam forward rather than going back to 10.
            Assert.AreEqual(370f, current, 0.5f);
        }
    }
}
