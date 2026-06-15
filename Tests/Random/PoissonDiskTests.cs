using BeeneticToolkit.Random;
using BeeneticToolkit.Random.Sampling;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Tests.Random {

    [TestClass]
    public class PoissonDiskTests {

        private const long Seed = 20240614L;

        private static RandomGenerator NewGen() =>
            new RandomEnvironment("test", Seed).CreateAndRegister("poisson");

        [TestMethod]
        public void Sample_RespectsMinimumDistance() {
            const float min = 5f;
            var points = PoissonDisk.Sample(NewGen(), 60f, 40f, min);

            float minSq = min * min;
            for (int i = 0; i < points.Count; i++) {
                for (int j = i + 1; j < points.Count; j++) {
                    float dx = points[i].X - points[j].X;
                    float dy = points[i].Y - points[j].Y;
                    float distSq = dx * dx + dy * dy;
                    Assert.IsTrue(distSq >= minSq - 1e-2f,
                        $"Points {i} and {j} are closer than {min}: dist^2={distSq}");
                }
            }
        }

        [TestMethod]
        public void Sample_PointsStayWithinBounds() {
            const float w = 80f, h = 50f;
            var points = PoissonDisk.Sample(NewGen(), w, h, 4f);

            foreach (var (x, y) in points) {
                Assert.IsTrue(x >= 0f && x < w, $"x out of bounds: {x}");
                Assert.IsTrue(y >= 0f && y < h, $"y out of bounds: {y}");
            }
        }

        [TestMethod]
        public void Sample_FillsRegion() {
            // A 50x50 region at min distance 5 should yield well more than a handful of points.
            var points = PoissonDisk.Sample(NewGen(), 50f, 50f, 5f);
            Assert.IsTrue(points.Count > 20, $"Expected a filled region, got {points.Count} points.");
        }

        [TestMethod]
        public void Sample_IsDeterministicForSameSeed() {
            var a = PoissonDisk.Sample(NewGen(), 40f, 40f, 3f);
            var b = PoissonDisk.Sample(NewGen(), 40f, 40f, 3f);

            CollectionAssert.AreEqual((List<(float, float)>)a, (List<(float, float)>)b);
        }

        [TestMethod]
        public void Sample_AlwaysReturnsAtLeastOnePoint() {
            // Minimum distance larger than the region: only the initial point fits.
            var points = PoissonDisk.Sample(NewGen(), 2f, 2f, 100f);
            Assert.AreEqual(1, points.Count);
        }

        [TestMethod]
        public void Sample_ValidatesArguments() {
            var gen = NewGen();
            Assert.ThrowsException<ArgumentNullException>(() => PoissonDisk.Sample(null, 10f, 10f, 1f));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => PoissonDisk.Sample(gen, 0f, 10f, 1f));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => PoissonDisk.Sample(gen, 10f, 0f, 1f));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => PoissonDisk.Sample(gen, 10f, 10f, 0f));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => PoissonDisk.Sample(gen, 10f, 10f, 1f, maxAttempts: 0));
        }
    }
}
