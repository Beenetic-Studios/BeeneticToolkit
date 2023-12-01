using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeeneticToolkit.Random.Tests {

    [TestClass]
    public class XorshiftTests : RNGTestsBase {

        protected override RandomGeneratorBase InitRngBase() {
            return RandomGeneratorFactory.GetGenerator(RngAlgorithm.Xorshift);
        }
    }

    [TestClass]
    public class CombinedLCGTests : RNGTestsBase {

        protected override RandomGeneratorBase InitRngBase() {
            return RandomGeneratorFactory.GetGenerator(RngAlgorithm.CombinedLCG);
        }
    }

    [TestClass]
    public class MiddleSquareTests : RNGTestsBase {

        protected override RandomGeneratorBase InitRngBase() {
            return RandomGeneratorFactory.GetGenerator(RngAlgorithm.MiddleSquare);
        }
    }
}