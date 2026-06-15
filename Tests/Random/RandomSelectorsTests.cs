using BeeneticToolkit.Random;
using BeeneticToolkit.Random.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Tests.Random {

    /// <summary>
    /// Covers the selection extension methods on <see cref="RandomGenerator"/> — the throwing helpers
    /// (happy paths, argument validation) and the complete non-throwing <c>Try*</c> family.
    /// </summary>
    [TestClass]
    public class RandomSelectorsTests {

        private const long Seed = 20240614L;

        private static RandomGenerator NewGen() => RandomFactory.GetGenerator(RandomAlgorithm.Xoshiro256, Seed);

        #region RandomChoice

        [TestMethod]
        public void RandomChoice_IList_ReturnsElementFromList() {
            var list = new[] { 1, 2, 3, 4, 5 };
            var gen = NewGen();

            for (int i = 0; i < 1_000; i++)
                Assert.IsTrue(list.Contains(gen.RandomChoice(list)));
        }

        [TestMethod]
        public void RandomChoice_IEnumerable_ReturnsElement() {
            IEnumerable<int> sequence = Enumerable.Range(1, 5).Where(x => x > 0); // not an IList
            var gen = NewGen();

            Assert.IsTrue(sequence.Contains(gen.RandomChoice(sequence)));
        }

        [TestMethod]
        public void RandomChoice_EmptyList_Throws() {
            Assert.ThrowsException<ArgumentException>(() => NewGen().RandomChoice(new List<int>()));
        }

        [TestMethod]
        public void RandomChoice_NullList_Throws() {
            Assert.ThrowsException<ArgumentNullException>(() => NewGen().RandomChoice((IList<int>)null));
        }

        [TestMethod]
        public void RandomChoice_NullRandom_Throws() {
            RandomGenerator gen = null;
            Assert.ThrowsException<ArgumentNullException>(() => gen.RandomChoice(new[] { 1, 2, 3 }));
        }

        #endregion RandomChoice

        #region RandomChoiceWithExclusion

        [TestMethod]
        public void RandomChoiceWithExclusion_NeverReturnsExcludedElement() {
            var list = Enumerable.Range(0, 10).ToList();
            var gen = NewGen();

            for (int i = 0; i < 1_000; i++) {
                int chosen = gen.RandomChoiceWithExclusion(list, x => x % 2 == 0);
                Assert.IsTrue(chosen % 2 != 0, "Excluded (even) values must never be chosen.");
            }
        }

        [TestMethod]
        public void RandomChoiceWithExclusion_AllExcluded_Throws() {
            var list = new[] { 2, 4, 6 };
            Assert.ThrowsException<InvalidOperationException>(
                () => NewGen().RandomChoiceWithExclusion(list, _ => true));
        }

        [TestMethod]
        public void RandomChoiceWithExclusion_NullPredicate_Throws() {
            Assert.ThrowsException<ArgumentNullException>(
                () => NewGen().RandomChoiceWithExclusion(new[] { 1, 2, 3 }, (Func<int, bool>)null));
        }

        #endregion RandomChoiceWithExclusion

        #region RandomSubset

        [TestMethod]
        public void RandomSubset_ReturnsRequestedCountOfDistinctSourceElements() {
            var list = Enumerable.Range(0, 20).ToList();
            var gen = NewGen();

            var subset = gen.RandomSubset(list, 5);

            Assert.AreEqual(5, subset.Count);
            Assert.AreEqual(5, subset.Distinct().Count(), "Subset elements must be distinct.");
            Assert.IsTrue(subset.All(list.Contains), "Subset elements must come from the source.");
        }

        [TestMethod]
        public void RandomSubset_FullSize_IsAPermutation() {
            var list = Enumerable.Range(0, 8).ToList();
            var subset = NewGen().RandomSubset(list, list.Count);
            CollectionAssert.AreEquivalent(list, subset);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(6)]
        public void RandomSubset_InvalidSize_Throws(int subsetSize) {
            var list = new[] { 1, 2, 3, 4, 5 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => NewGen().RandomSubset(list, subsetSize));
        }

        [TestMethod]
        public void RandomSubset_EmptyList_Throws() {
            Assert.ThrowsException<ArgumentException>(() => NewGen().RandomSubset(new List<int>(), 1));
        }

        #endregion RandomSubset

        #region RandomWeightedChoice

        [TestMethod]
        public void RandomWeightedChoice_IList_NeverPicksZeroWeight() {
            var items = new[] { "a", "b", "c" };
            var weights = new[] { 0.0, 1.0, 0.0 };
            var gen = NewGen();

            for (int i = 0; i < 1_000; i++)
                Assert.AreEqual("b", gen.RandomWeightedChoice(items, weights));
        }

        [TestMethod]
        public void RandomWeightedChoice_IList_LengthMismatch_Throws() {
            Assert.ThrowsException<ArgumentException>(
                () => NewGen().RandomWeightedChoice(new[] { "a", "b" }, new[] { 1.0 }));
        }

        [TestMethod]
        public void RandomWeightedChoice_IList_ZeroTotalWeight_Throws() {
            Assert.ThrowsException<InvalidOperationException>(
                () => NewGen().RandomWeightedChoice(new[] { "a", "b" }, new[] { 0.0, 0.0 }));
        }

        [TestMethod]
        public void RandomWeightedChoice_Dictionary_NeverPicksZeroWeight() {
            var dict = new Dictionary<string, double> { ["a"] = 0.0, ["b"] = 1.0, ["c"] = 0.0 };
            var gen = NewGen();

            for (int i = 0; i < 1_000; i++)
                Assert.AreEqual("b", gen.RandomWeightedChoice(dict));
        }

        [TestMethod]
        public void RandomWeightedChoice_Dictionary_Empty_Throws() {
            Assert.ThrowsException<ArgumentException>(
                () => NewGen().RandomWeightedChoice(new Dictionary<string, double>()));
        }

        [TestMethod]
        public void RandomWeightedChoice_Dictionary_Null_Throws() {
            Assert.ThrowsException<ArgumentNullException>(
                () => NewGen().RandomWeightedChoice((Dictionary<string, double>)null));
        }

        #endregion RandomWeightedChoice

        #region TryRandomChoice

        [TestMethod]
        public void TryRandomChoice_Success_ReturnsTrueAndElement() {
            var list = new[] { 1, 2, 3 };
            Assert.IsTrue(NewGen().TryRandomChoice(list, out int result));
            Assert.IsTrue(list.Contains(result));
        }

        [TestMethod]
        public void TryRandomChoice_IEnumerable_Success() {
            IEnumerable<int> sequence = Enumerable.Range(1, 3).Where(x => x > 0);
            Assert.IsTrue(NewGen().TryRandomChoice(sequence, out int result));
            Assert.IsTrue(sequence.Contains(result));
        }

        [TestMethod]
        public void TryRandomChoice_NullList_False() {
            Assert.IsFalse(NewGen().TryRandomChoice((IList<int>)null, out int result));
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TryRandomChoice_EmptyList_False() {
            Assert.IsFalse(NewGen().TryRandomChoice(new List<int>(), out _));
        }

        #endregion TryRandomChoice

        #region TryRandomChoiceWithExclusion

        [TestMethod]
        public void TryRandomChoiceWithExclusion_Success_ReturnsNonExcluded() {
            var list = Enumerable.Range(0, 10).ToList();
            Assert.IsTrue(NewGen().TryRandomChoiceWithExclusion(list, x => x % 2 == 0, out int result));
            Assert.IsTrue(result % 2 != 0);
        }

        [TestMethod]
        public void TryRandomChoiceWithExclusion_AllExcluded_False() {
            Assert.IsFalse(NewGen().TryRandomChoiceWithExclusion(new[] { 2, 4 }, _ => true, out _));
        }

        [TestMethod]
        public void TryRandomChoiceWithExclusion_NullPredicate_False() {
            Assert.IsFalse(NewGen().TryRandomChoiceWithExclusion(new[] { 1 }, null, out _));
        }

        [TestMethod]
        public void TryRandomChoiceWithExclusion_NullList_False() {
            Assert.IsFalse(NewGen().TryRandomChoiceWithExclusion((IList<int>)null, _ => false, out _));
        }

        #endregion TryRandomChoiceWithExclusion

        #region TryRandomSubset

        [TestMethod]
        public void TryRandomSubset_Success_ReturnsDistinctSubset() {
            var list = Enumerable.Range(0, 20).ToList();
            Assert.IsTrue(NewGen().TryRandomSubset(list, 5, out var result));
            Assert.AreEqual(5, result.Count);
            Assert.AreEqual(5, result.Distinct().Count());
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(99)]
        public void TryRandomSubset_InvalidSize_False(int subsetSize) {
            Assert.IsFalse(NewGen().TryRandomSubset(new[] { 1, 2, 3 }, subsetSize, out var result));
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TryRandomSubset_NullList_False() {
            Assert.IsFalse(NewGen().TryRandomSubset((IList<int>)null, 1, out var result));
            Assert.IsNull(result);
        }

        #endregion TryRandomSubset

        #region TryRandomWeightedChoice

        [TestMethod]
        public void TryRandomWeightedChoice_IList_Success() {
            var items = new[] { "a", "b", "c" };
            var weights = new[] { 0.0, 1.0, 0.0 };
            Assert.IsTrue(NewGen().TryRandomWeightedChoice(items, weights, out string result));
            Assert.AreEqual("b", result);
        }

        [TestMethod]
        public void TryRandomWeightedChoice_IList_LengthMismatch_False() {
            Assert.IsFalse(NewGen().TryRandomWeightedChoice(new[] { "a", "b" }, new[] { 1.0 }, out _));
        }

        [TestMethod]
        public void TryRandomWeightedChoice_IList_ZeroTotalWeight_False() {
            Assert.IsFalse(NewGen().TryRandomWeightedChoice(new[] { "a", "b" }, new[] { 0.0, 0.0 }, out _));
        }

        [TestMethod]
        public void TryRandomWeightedChoice_IEnumerable_Success() {
            IEnumerable<string> seq = new[] { "a", "b" }.Where(x => x != null);
            Assert.IsTrue(NewGen().TryRandomWeightedChoice(seq, new[] { 0.0, 1.0 }, out string result));
            Assert.AreEqual("b", result);
        }

        [TestMethod]
        public void TryRandomWeightedChoice_Dictionary_Success() {
            var dict = new Dictionary<string, double> { ["a"] = 0.0, ["b"] = 1.0 };
            Assert.IsTrue(NewGen().TryRandomWeightedChoice(dict, out string result));
            Assert.AreEqual("b", result);
        }

        [TestMethod]
        public void TryRandomWeightedChoice_Dictionary_Empty_False() {
            Assert.IsFalse(NewGen().TryRandomWeightedChoice(new Dictionary<string, double>(), out _));
        }

        #endregion TryRandomWeightedChoice
    }
}
