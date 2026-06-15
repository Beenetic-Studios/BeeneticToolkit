using BeeneticToolkit.Random.Noise;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeeneticToolkit.Tests.Random {

    [TestClass]
    public class NoiseTests {

        private const long Seed = 1337L;

        [DataTestMethod]
        [DataRow(NoiseAlgorithm.Value)]
        [DataRow(NoiseAlgorithm.Perlin)]
        public void Sample_IsDeterministicForSameSeed(NoiseAlgorithm algorithm) {
            var a = NoiseFactory.Create(algorithm, Seed);
            var b = NoiseFactory.Create(algorithm, Seed);

            for (float t = 0f; t < 5f; t += 0.37f) {
                Assert.AreEqual(a.Sample(t, t * 1.3f), b.Sample(t, t * 1.3f));
                Assert.AreEqual(a.Sample(t, t * 1.3f, t * 0.7f), b.Sample(t, t * 1.3f, t * 0.7f));
            }
        }

        [DataTestMethod]
        [DataRow(NoiseAlgorithm.Value)]
        [DataRow(NoiseAlgorithm.Perlin)]
        public void Sample_StaysInRangeAndVaries(NoiseAlgorithm algorithm) {
            var noise = NoiseFactory.Create(algorithm, Seed);
            float min2 = float.MaxValue, max2 = float.MinValue;
            float min3 = float.MaxValue, max3 = float.MinValue;

            for (float x = -8f; x <= 8f; x += 0.13f) {
                for (float y = -8f; y <= 8f; y += 0.13f) {
                    float v2 = noise.Sample(x, y);
                    Assert.IsFalse(float.IsNaN(v2));
                    Assert.IsTrue(v2 >= -1.001f && v2 <= 1.001f, $"2D out of range: {v2}");
                    min2 = Math.Min(min2, v2); max2 = Math.Max(max2, v2);

                    float v3 = noise.Sample(x, y, x * 0.5f);
                    Assert.IsTrue(v3 >= -1.001f && v3 <= 1.001f, $"3D out of range: {v3}");
                    min3 = Math.Min(min3, v3); max3 = Math.Max(max3, v3);
                }
            }

            // Confirm it actually exercises a meaningful span of the range (not flat / not clipped to a corner).
            Assert.IsTrue(max2 > 0.3f && min2 < -0.3f, $"2D span too small: [{min2}, {max2}]");
            Assert.IsTrue(max3 > 0.3f && min3 < -0.3f, $"3D span too small: [{min3}, {max3}]");
        }

        [TestMethod]
        public void Perlin_IsZeroAtIntegerLattice() {
            var perlin = NoiseFactory.Create(NoiseAlgorithm.Perlin, Seed);

            for (int x = -3; x <= 3; x++) {
                for (int y = -3; y <= 3; y++) {
                    Assert.AreEqual(0f, perlin.Sample(x, y), 1e-5f);
                    Assert.AreEqual(0f, perlin.Sample(x, y, 1), 1e-5f);
                }
            }
        }

        [TestMethod]
        public void DifferentSeeds_ProduceDifferentFields() {
            var a = NoiseFactory.Create(NoiseAlgorithm.Perlin, 1L);
            var b = NoiseFactory.Create(NoiseAlgorithm.Perlin, 2L);

            bool differs = false;
            for (float t = 0.5f; t < 20f && !differs; t += 0.5f)
                differs = a.Sample(t, t * 1.1f) != b.Sample(t, t * 1.1f);

            Assert.IsTrue(differs, "Different seeds should produce different output.");
        }

        [TestMethod]
        public void Sample_IsContinuous() {
            var perlin = NoiseFactory.Create(NoiseAlgorithm.Perlin, Seed);
            float prev = perlin.Sample(0f, 1.5f);

            for (float x = 0.01f; x < 4f; x += 0.01f) {
                float cur = perlin.Sample(x, 1.5f);
                Assert.IsTrue(Math.Abs(cur - prev) < 0.2f, $"Discontinuity near x={x}");
                prev = cur;
            }
        }

        [TestMethod]
        public void Sample01_RemapsToZeroOne() {
            var noise = NoiseFactory.Create(NoiseAlgorithm.Value, Seed);

            for (float t = -5f; t <= 5f; t += 0.21f) {
                float u = noise.Sample01(t, t * 1.7f);
                Assert.IsTrue(u >= -0.001f && u <= 1.001f, $"Sample01 out of range: {u}");
                Assert.AreEqual(noise.Sample(t, t * 1.7f) * 0.5f + 0.5f, u, 1e-6f);
            }
        }

        [TestMethod]
        public void Factory_InvalidAlgorithm_Throws() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => NoiseFactory.Create((NoiseAlgorithm)999, Seed));
        }

        #region FractalNoise

        [TestMethod]
        public void Fractal_StaysInRangeAndIsDeterministic() {
            var a = new FractalNoise(NoiseFactory.Create(NoiseAlgorithm.Perlin, Seed), octaves: 5, frequency: 0.05f);
            var b = new FractalNoise(NoiseFactory.Create(NoiseAlgorithm.Perlin, Seed), octaves: 5, frequency: 0.05f);

            for (float x = -50f; x <= 50f; x += 1.3f) {
                float va = a.Sample(x, x * 0.9f);
                Assert.IsTrue(va >= -1.001f && va <= 1.001f, $"fBm out of range: {va}");
                Assert.AreEqual(va, b.Sample(x, x * 0.9f)); // deterministic
                float v3 = a.Sample(x, x * 0.9f, x * 0.3f);
                Assert.IsTrue(v3 >= -1.001f && v3 <= 1.001f, $"fBm 3D out of range: {v3}");
            }
        }

        [TestMethod]
        public void Fractal_ValidatesArguments() {
            var src = NoiseFactory.Create(NoiseAlgorithm.Perlin, Seed);
            Assert.ThrowsException<ArgumentNullException>(() => new FractalNoise(null));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new FractalNoise(src, octaves: 0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new FractalNoise(src, frequency: 0f));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new FractalNoise(src, lacunarity: 0f));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new FractalNoise(src, gain: 0f));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new FractalNoise(src, gain: 1.5f));
        }

        #endregion FractalNoise
    }
}
