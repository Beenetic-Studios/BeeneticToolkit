using BeeneticToolkit.Random;
using BeeneticToolkit.Random.Sampling;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeeneticToolkit.Tests.Random {

    [TestClass]
    public class SpatialSamplingTests {

        private const long Seed = 20240614L;
        private const int Samples = 2000;
        private const float Tolerance = 1e-3f;

        private static RandomGenerator NewGen() =>
            new RandomEnvironment("test", Seed).CreateAndRegister("spatial");

        // --- NextAngle ---

        [TestMethod]
        public void NextAngle_StaysWithinRange() {
            var gen = NewGen();
            for (int i = 0; i < Samples; i++) {
                float angle = gen.NextAngle();
                Assert.IsTrue(angle >= 0f && angle < MathF.PI * 2f, $"Angle out of range: {angle}");
            }
        }

        // --- NextUnitVector2 ---

        [TestMethod]
        public void NextUnitVector2_HasUnitMagnitude() {
            var gen = NewGen();
            for (int i = 0; i < Samples; i++) {
                var (x, y) = gen.NextUnitVector2();
                float mag = MathF.Sqrt(x * x + y * y);
                Assert.AreEqual(1f, mag, Tolerance, $"Magnitude not 1: {mag}");
            }
        }

        // --- NextUnitVector3 ---

        [TestMethod]
        public void NextUnitVector3_HasUnitMagnitude() {
            var gen = NewGen();
            for (int i = 0; i < Samples; i++) {
                var (x, y, z) = gen.NextUnitVector3();
                float mag = MathF.Sqrt(x * x + y * y + z * z);
                Assert.AreEqual(1f, mag, Tolerance, $"Magnitude not 1: {mag}");
            }
        }

        // --- NextPointInCircle ---

        [TestMethod]
        public void NextPointInCircle_StaysWithinRadius() {
            const float radius = 3.5f;
            var gen = NewGen();
            for (int i = 0; i < Samples; i++) {
                var (x, y) = gen.NextPointInCircle(radius);
                float dist = MathF.Sqrt(x * x + y * y);
                Assert.IsTrue(dist <= radius + Tolerance, $"Point outside radius: {dist}");
            }
        }

        [TestMethod]
        public void NextPointInCircle_DefaultRadiusIsOne() {
            var gen = NewGen();
            for (int i = 0; i < Samples; i++) {
                var (x, y) = gen.NextPointInCircle();
                float dist = MathF.Sqrt(x * x + y * y);
                Assert.IsTrue(dist <= 1f + Tolerance, $"Point outside unit circle: {dist}");
            }
        }

        // --- NextPointInAnnulus ---

        [TestMethod]
        public void NextPointInAnnulus_StaysWithinRing() {
            const float inner = 2f, outer = 5f;
            var gen = NewGen();
            for (int i = 0; i < Samples; i++) {
                var (x, y) = gen.NextPointInAnnulus(inner, outer);
                float dist = MathF.Sqrt(x * x + y * y);
                Assert.IsTrue(dist >= inner - Tolerance && dist <= outer + Tolerance,
                    $"Point outside ring [{inner}, {outer}]: {dist}");
            }
        }

        // --- NextPointInSphere ---

        [TestMethod]
        public void NextPointInSphere_StaysWithinRadius() {
            const float radius = 4f;
            var gen = NewGen();
            for (int i = 0; i < Samples; i++) {
                var (x, y, z) = gen.NextPointInSphere(radius);
                float dist = MathF.Sqrt(x * x + y * y + z * z);
                Assert.IsTrue(dist <= radius + Tolerance, $"Point outside sphere: {dist}");
            }
        }

        // --- Determinism ---

        [TestMethod]
        public void Sampling_IsDeterministicForSameSeed() {
            var a = NewGen();
            var b = NewGen();
            for (int i = 0; i < 100; i++) {
                Assert.AreEqual(a.NextAngle(), b.NextAngle());

                var ua = a.NextUnitVector2();
                var ub = b.NextUnitVector2();
                Assert.AreEqual(ua, ub);

                var ca = a.NextPointInCircle(2f);
                var cb = b.NextPointInCircle(2f);
                Assert.AreEqual(ca, cb);

                var sa = a.NextPointInSphere(3f);
                var sb = b.NextPointInSphere(3f);
                Assert.AreEqual(sa, sb);
            }
        }

        // --- Distribution sanity ---

        [TestMethod]
        public void NextPointInCircle_IsAreaUniform() {
            // For an area-uniform disk, half the points lie inside radius/sqrt(2).
            const float radius = 1f;
            float halfAreaRadius = radius / MathF.Sqrt(2f);
            var gen = NewGen();
            int inner = 0;
            for (int i = 0; i < Samples; i++) {
                var (x, y) = gen.NextPointInCircle(radius);
                if (MathF.Sqrt(x * x + y * y) <= halfAreaRadius)
                    inner++;
            }
            float fraction = (float)inner / Samples;
            Assert.AreEqual(0.5f, fraction, 0.05f, $"Disk not area-uniform: {fraction} inside half-area radius.");
        }

        // --- Validation ---

        [TestMethod]
        public void Methods_ValidateNullGenerator() {
            RandomGenerator gen = null;
            Assert.ThrowsException<ArgumentNullException>(() => gen.NextAngle());
            Assert.ThrowsException<ArgumentNullException>(() => gen.NextUnitVector2());
            Assert.ThrowsException<ArgumentNullException>(() => gen.NextUnitVector3());
            Assert.ThrowsException<ArgumentNullException>(() => gen.NextPointInCircle());
            Assert.ThrowsException<ArgumentNullException>(() => gen.NextPointInAnnulus(1f, 2f));
            Assert.ThrowsException<ArgumentNullException>(() => gen.NextPointInSphere());
        }

        [TestMethod]
        public void Methods_ValidateRadius() {
            var gen = NewGen();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => gen.NextPointInCircle(-1f));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => gen.NextPointInSphere(-1f));
        }

        [TestMethod]
        public void NextPointInAnnulus_ValidatesRadii() {
            var gen = NewGen();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => gen.NextPointInAnnulus(-1f, 2f));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => gen.NextPointInAnnulus(3f, 2f));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => gen.NextPointInAnnulus(2f, 2f));
        }
    }
}
