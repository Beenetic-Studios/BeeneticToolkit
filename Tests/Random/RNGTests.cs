using BeeneticToolkit.Random;
using BeeneticToolkit.Random.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeeneticToolkit.Tests.Random {

    // A fixed seed keeps these statistical tests deterministic (and therefore non-flaky in CI)
    // while still exercising a full pseudo-random sequence.
    [TestClass]
    public class Xoshiro256Tests : RNGTestsBase {

        protected override RandomGenerator InitRngBase() {
            return RandomFactory.GetGenerator(RandomAlgorithm.Xoshiro256, FixedSeed);
        }
    }

    [TestClass]
    public class XorshiftTests : RNGTestsBase {

        protected override RandomGenerator InitRngBase() {
            return RandomFactory.GetGenerator(RandomAlgorithm.Xorshift, FixedSeed);
        }
    }

    [TestClass]
    public class CombinedLCGTests : RNGTestsBase {

        protected override RandomGenerator InitRngBase() {
            return RandomFactory.GetGenerator(RandomAlgorithm.CombinedLCG, FixedSeed);
        }
    }

    [TestClass]
    public class MiddleSquareTests : RNGTestsBase {

        protected override RandomGenerator InitRngBase() {
            return RandomFactory.GetGenerator(RandomAlgorithm.MiddleSquare, FixedSeed);
        }
    }
}