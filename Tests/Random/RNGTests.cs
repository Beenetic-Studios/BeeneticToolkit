using BeeneticToolkit.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeeneticToolkit.Tests.Random {

    // A fixed seed keeps these statistical tests deterministic (and therefore non-flaky in CI)
    // while still exercising a full pseudo-random sequence.
    [TestClass]
    public class XorshiftTests : RNGTestsBase {

        protected override RandomGenerator InitRngBase() {
            return RngFactory.GetGenerator(RngAlgorithm.Xorshift, FixedSeed);
        }
    }

    [TestClass]
    public class CombinedLCGTests : RNGTestsBase {

        protected override RandomGenerator InitRngBase() {
            return RngFactory.GetGenerator(RngAlgorithm.CombinedLCG, FixedSeed);
        }
    }

    [TestClass]
    public class MiddleSquareTests : RNGTestsBase {

        protected override RandomGenerator InitRngBase() {
            return RngFactory.GetGenerator(RngAlgorithm.MiddleSquare, FixedSeed);
        }
    }
}