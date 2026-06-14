using BeeneticToolkit.Random;
using BeeneticToolkit.Random.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeeneticToolkit.Tests.Random {

    [TestClass]
    public class RngFactoryTests {

        [TestMethod]
        public void GetGenerator_NoParams_ShouldReturnDefaultGenerator() {
            var generator = RngFactory.GetGenerator();

            Assert.IsNotNull(generator);
            Assert.IsInstanceOfType(generator, typeof(Xoshiro256));
        }

        [TestMethod]
        public void GetGenerator_WithSeed_ShouldReturnGeneratorWithSeed() {
            long seed = 12345;
            var generator = RngFactory.GetGenerator(seed);

            Assert.IsNotNull(generator);
            Assert.AreEqual(seed, generator.Seed);
        }

        [TestMethod]
        public void GetGenerator_SpecificAlgorithm_ShouldReturnCorrectType() {
            var generator = RngFactory.GetGenerator(RngAlgorithm.CombinedLCG);

            Assert.IsNotNull(generator);
            Assert.IsInstanceOfType(generator, typeof(CombinedLCG));
        }

        [TestMethod]
        public void GetGenerator_WithSeedAndAlgorithm_ShouldReturnCorrectTypeAndSeed() {
            long seed = 12345;
            var generator = RngFactory.GetGenerator(RngAlgorithm.MiddleSquare, seed);

            Assert.IsNotNull(generator);
            Assert.IsInstanceOfType(generator, typeof(MiddleSquare));
            Assert.AreEqual(seed, generator.Seed);
        }

        [TestMethod]
        public void GetGenerator_InvalidAlgorithm_ShouldThrowArgumentException() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = RngFactory.GetGenerator((RngAlgorithm)(-1)));
        }

        [TestMethod]
        public void RngsWithSameSeed_ShouldProduceIdenticalSequences() {
            long seed = 12345;
            var rng1 = RngFactory.GetGenerator(RngAlgorithm.Xorshift, seed);
            var rng2 = RngFactory.GetGenerator(RngAlgorithm.Xorshift, seed);
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