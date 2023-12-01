using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeeneticToolkit.Random.Tests {

    [TestClass]
    public class RngFactoryTests {

        [TestMethod]
        public void GetGenerator_NoParams_ShouldReturnDefaultGenerator() {
            var generator = RandomGeneratorFactory.GetGenerator();

            Assert.IsNotNull(generator);
            Assert.IsInstanceOfType(generator, typeof(Xorshift));
        }

        [TestMethod]
        public void GetGenerator_WithSeed_ShouldReturnGeneratorWithSeed() {
            long seed = 12345;
            var generator = RandomGeneratorFactory.GetGenerator(seed);

            Assert.IsNotNull(generator);
            Assert.AreEqual(seed, generator.Seed);
        }

        [TestMethod]
        public void GetGenerator_SpecificAlgorithm_ShouldReturnCorrectType() {
            var generator = RandomGeneratorFactory.GetGenerator(RngAlgorithm.CombinedLCG);

            Assert.IsNotNull(generator);
            Assert.IsInstanceOfType(generator, typeof(CombinedLCG));
        }

        [TestMethod]
        public void GetGenerator_WithSeedAndAlgorithm_ShouldReturnCorrectTypeAndSeed() {
            long seed = 12345;
            var generator = RandomGeneratorFactory.GetGenerator(RngAlgorithm.MiddleSquare, seed);

            Assert.IsNotNull(generator);
            Assert.IsInstanceOfType(generator, typeof(MiddleSquare));
            Assert.AreEqual(seed, generator.Seed);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetGenerator_InvalidAlgorithm_ShouldThrowArgumentException() {
            _ = RandomGeneratorFactory.GetGenerator((RngAlgorithm)(-1));
        }

        [TestMethod]
        public void RngsWithSameSeed_ShouldProduceIdenticalSequences() {
            long seed = 12345;
            var rng1 = RandomGeneratorFactory.GetGenerator(RngAlgorithm.Xorshift, seed);
            var rng2 = RandomGeneratorFactory.GetGenerator(RngAlgorithm.Xorshift, seed);
            int numberOfValuesToTest = 100;

            for (int i = 0; i < numberOfValuesToTest; i++) {
                var value1 = rng1.NextNormal();
                var value2 = rng2.NextNormal();
                var s = $"The RNG sequences diverged at iteration {i}. RNG1: {value1}, RNG2: {value2}";
                Assert.AreEqual(value1, value2, s);
            }
        }
    }
}