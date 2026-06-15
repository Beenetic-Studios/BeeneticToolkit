using BeeneticToolkit.Random;
using BeeneticToolkit.Random.Generators;
using BeeneticToolkit.Random.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeeneticToolkit.Tests.Random {

    /// <summary>
    /// Tests for the internal <see cref="RandomFactory"/> (accessible via InternalsVisibleTo). The factory is
    /// an implementation detail of the environment system: it maps an algorithm and a concrete seed to a generator.
    /// </summary>
    [TestClass]
    public class RandomFactoryTests {

        private const long Seed = 12345L;

        [TestMethod]
        public void GetGenerator_Xoshiro_ReturnsCorrectTypeAndSeed() {
            var generator = RandomFactory.GetGenerator(RandomAlgorithm.Xoshiro256, Seed);

            Assert.IsNotNull(generator);
            Assert.IsInstanceOfType(generator, typeof(Xoshiro256));
            Assert.AreEqual(Seed, generator.Seed);
        }

        [TestMethod]
        public void GetGenerator_SpecificAlgorithm_ReturnsCorrectType() {
            var generator = RandomFactory.GetGenerator(RandomAlgorithm.CombinedLCG, Seed);

            Assert.IsNotNull(generator);
            Assert.IsInstanceOfType(generator, typeof(CombinedLCG));
        }

        [TestMethod]
        public void GetGenerator_WithSeedAndAlgorithm_ReturnsCorrectTypeAndSeed() {
            var generator = RandomFactory.GetGenerator(RandomAlgorithm.MiddleSquare, Seed);

            Assert.IsNotNull(generator);
            Assert.IsInstanceOfType(generator, typeof(MiddleSquare));
            Assert.AreEqual(Seed, generator.Seed);
        }

        [TestMethod]
        public void GetGenerator_InvalidAlgorithm_ShouldThrowArgumentException() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = RandomFactory.GetGenerator((RandomAlgorithm)(-1), Seed));
        }

        [TestMethod]
        public void RngsWithSameSeed_ShouldProduceIdenticalSequences() {
            var rng1 = RandomFactory.GetGenerator(RandomAlgorithm.Xorshift, Seed);
            var rng2 = RandomFactory.GetGenerator(RandomAlgorithm.Xorshift, Seed);

            for (int i = 0; i < 100; i++) {
                var value1 = rng1.NextNormal();
                var value2 = rng2.NextNormal();
                Assert.AreEqual(value1, value2, $"The RNG sequences diverged at iteration {i}. RNG1: {value1}, RNG2: {value2}");
            }
        }
    }
}
