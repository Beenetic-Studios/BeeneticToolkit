using BeeneticToolkit.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeeneticToolkit.Tests.Random {

    [TestClass]
    public class XorshiftTests : RNGTestsBase {

        protected override RandomGenerator InitRngBase() {
            return RngFactory.GetGenerator(RngAlgorithm.Xorshift);
        }
    }

    [TestClass]
    public class CombinedLCGTests : RNGTestsBase {

        protected override RandomGenerator InitRngBase() {
            return RngFactory.GetGenerator(RngAlgorithm.CombinedLCG);
        }
    }

    [TestClass]
    public class MiddleSquareTests : RNGTestsBase {

        protected override RandomGenerator InitRngBase() {
            return RngFactory.GetGenerator(RngAlgorithm.MiddleSquare);
        }
    }
}