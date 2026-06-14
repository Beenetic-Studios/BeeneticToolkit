using BeeneticToolkit.Random;
using BeeneticToolkit.Random.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Tests.Random {

    [TestClass]
    public class RandomEnhancementsTests {

        private const long Seed = 20240614L;

        private enum Direction { North, East, South, West }

        private static RandomGenerator NewGen(long seed = Seed) =>
            RngFactory.GetGenerator(RngAlgorithm.Xorshift, seed);

        #region NextEnum

        [TestMethod]
        public void NextEnum_OnlyReturnsDefinedValues() {
            var gen = NewGen();
            var defined = new HashSet<Direction>((Direction[])Enum.GetValues(typeof(Direction)));

            for (int i = 0; i < 10_000; i++)
                Assert.IsTrue(defined.Contains(gen.NextEnum<Direction>()));
        }

        [TestMethod]
        public void NextEnum_EventuallyProducesEveryValue() {
            var gen = NewGen();
            var seen = new HashSet<Direction>();

            for (int i = 0; i < 10_000; i++)
                seen.Add(gen.NextEnum<Direction>());

            CollectionAssert.AreEquivalent((Direction[])Enum.GetValues(typeof(Direction)), seen.ToArray());
        }

        [TestMethod]
        public void NextEnum_IsDeterministicForSameSeed() {
            var a = NewGen();
            var b = NewGen();

            for (int i = 0; i < 100; i++)
                Assert.AreEqual(a.NextEnum<Direction>(), b.NextEnum<Direction>());
        }

        #endregion NextEnum

        #region NextSign

        [TestMethod]
        public void NextSign_OnlyReturnsPlusOrMinusOne() {
            var gen = NewGen();
            for (int i = 0; i < 10_000; i++) {
                int s = gen.NextSign();
                Assert.IsTrue(s == 1 || s == -1);
            }
        }

        [TestMethod]
        public void NextSign_ProducesBothSigns() {
            var gen = NewGen();
            bool sawPos = false, sawNeg = false;

            for (int i = 0; i < 1_000 && !(sawPos && sawNeg); i++) {
                int s = gen.NextSign();
                sawPos |= s == 1;
                sawNeg |= s == -1;
            }

            Assert.IsTrue(sawPos && sawNeg);
        }

        #endregion NextSign

        #region NextGuid

        [TestMethod]
        public void NextGuid_IsNotEmptyAndVaries() {
            var gen = NewGen();
            var first = gen.NextGuid();
            var second = gen.NextGuid();

            Assert.AreNotEqual(Guid.Empty, first);
            Assert.AreNotEqual(first, second);
        }

        [TestMethod]
        public void NextGuid_IsDeterministicForSameSeed() {
            Assert.AreEqual(NewGen().NextGuid(), NewGen().NextGuid());
        }

        #endregion NextGuid

        #region NextBytes(Span)

        [TestMethod]
        public void NextBytes_Span_FillsBufferDeterministically() {
            Span<byte> a = stackalloc byte[32];
            Span<byte> b = stackalloc byte[32];
            NewGen().NextBytes(a);
            NewGen().NextBytes(b);

            Assert.IsTrue(a.SequenceEqual(b));
            Assert.IsTrue(a.ToArray().Distinct().Count() > 1, "Buffer should not be all the same byte.");
        }

        [TestMethod]
        public void NextBytes_Span_AndArray_AgreeForSameSeed() {
            byte[] fromArray = NewGen().NextBytes(16);
            Span<byte> fromSpan = stackalloc byte[16];
            NewGen().NextBytes(fromSpan);

            Assert.IsTrue(fromSpan.SequenceEqual(fromArray));
        }

        #endregion NextBytes(Span)

        #region NextNormal (Box-Muller spare caching)

        [TestMethod]
        public void NextNormal_ApproximatesMeanAndStdDev() {
            var gen = NewGen();
            const int n = 200_000;
            double sum = 0, sumSq = 0;

            for (int i = 0; i < n; i++) {
                double x = gen.NextNormal(0.0, 1.0);
                sum += x;
                sumSq += x * x;
            }

            double mean = sum / n;
            double variance = sumSq / n - mean * mean;

            Assert.AreEqual(0.0, mean, 0.02, "Mean should be near 0.");
            Assert.AreEqual(1.0, Math.Sqrt(variance), 0.02, "Std dev should be near 1.");
        }

        [TestMethod]
        public void NextNormal_IsDeterministicForSameSeed() {
            var a = NewGen();
            var b = NewGen();
            for (int i = 0; i < 100; i++)
                Assert.AreEqual(a.NextNormal(), b.NextNormal());
        }

        #endregion NextNormal

        #region RandomChoice(ReadOnlySpan) and overload resolution

        [TestMethod]
        public void RandomChoice_Span_ReturnsElementFromSpan() {
            var gen = NewGen();
            ReadOnlySpan<int> span = stackalloc int[] { 10, 20, 30, 40 };
            var pool = new[] { 10, 20, 30, 40 };

            for (int i = 0; i < 1_000; i++)
                Assert.IsTrue(pool.Contains(RandomSelectors.RandomChoice(span, gen)));
        }

        [TestMethod]
        public void RandomChoice_Span_EmptyThrows() {
            Assert.ThrowsException<ArgumentException>(() => RandomSelectors.RandomChoice(ReadOnlySpan<int>.Empty, NewGen()));
        }

        [TestMethod]
        public void RandomChoice_ArrayArgument_StillResolves() {
            // Guards against ambiguity introduced by the ReadOnlySpan<T> overload.
            int[] array = { 1, 2, 3 };
            int chosen = RandomSelectors.RandomChoice(array, NewGen());
            Assert.IsTrue(array.Contains(chosen));
        }

        #endregion RandomChoice(ReadOnlySpan)

        #region RandomWeightedChoice (single-source overloads)

        [TestMethod]
        public void RandomWeightedChoice_Tuples_NeverPicksZeroWeight() {
            var gen = NewGen();
            var weighted = new[] { ("a", 0.0), ("b", 1.0), ("c", 0.0) };

            for (int i = 0; i < 1_000; i++)
                Assert.AreEqual("b", RandomSelectors.RandomWeightedChoice(weighted, gen));
        }

        [TestMethod]
        public void RandomWeightedChoice_Selector_NeverPicksZeroWeight() {
            var gen = NewGen();
            var items = new[] { "a", "b", "c" };

            for (int i = 0; i < 1_000; i++)
                Assert.AreEqual("b", RandomSelectors.RandomWeightedChoice(items, s => s == "b" ? 1.0 : 0.0, gen));
        }

        [TestMethod]
        public void RandomWeightedChoice_Selector_NullSelectorThrows() {
            Assert.ThrowsException<ArgumentNullException>(
                () => RandomSelectors.RandomWeightedChoice(new[] { "a" }, (Func<string, double>)null, NewGen()));
        }

        [TestMethod]
        public void RandomWeightedChoice_Tuples_RoughlyMatchesWeights() {
            var gen = NewGen();
            var weighted = new[] { ("rare", 1.0), ("common", 9.0) };
            int common = 0;
            const int n = 100_000;

            for (int i = 0; i < n; i++)
                if (RandomSelectors.RandomWeightedChoice(weighted, gen) == "common")
                    common++;

            Assert.AreEqual(0.9, common / (double)n, 0.02, "'common' should be chosen ~90% of the time.");
        }

        #endregion RandomWeightedChoice

        #region Shuffle / ShuffleInPlace

        [TestMethod]
        public void Shuffle_ReturnsNewListAndLeavesSourceUntouched() {
            var source = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            var snapshot = source.ToList();

            var shuffled = source.Shuffle(NewGen());

            CollectionAssert.AreEqual(snapshot, source, "Source must not be mutated.");
            CollectionAssert.AreEquivalent(snapshot, shuffled, "Shuffle must preserve elements.");
            Assert.AreNotSame(source, shuffled);
        }

        [TestMethod]
        public void Shuffle_EmptySourceReturnsEmpty() {
            var shuffled = Array.Empty<int>().Shuffle(NewGen());
            Assert.AreEqual(0, shuffled.Count);
        }

        [TestMethod]
        public void Shuffle_NullSourceThrows() {
            List<int> source = null;
            Assert.ThrowsException<ArgumentNullException>(() => source.Shuffle(NewGen()));
        }

        [TestMethod]
        public void ShuffleInPlace_MutatesAndPreservesElements() {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            var snapshot = list.ToList();

            list.ShuffleInPlace(NewGen());

            CollectionAssert.AreEquivalent(snapshot, list);
        }

        [TestMethod]
        public void ShuffleInPlace_NullThrows() {
            IList<int> list = null;
            Assert.ThrowsException<ArgumentNullException>(() => list.ShuffleInPlace(NewGen()));
        }

        #endregion Shuffle

        #region TryGet

        [TestMethod]
        public void RngEnvironment_TryGet_ReturnsRegisteredGenerator() {
            var env = new RngEnvironment("test");
            var gen = env.CreateAndRegister("primary");

            Assert.IsTrue(env.TryGet("primary", out var found));
            Assert.AreSame(gen, found);
        }

        [TestMethod]
        public void RngEnvironment_TryGet_ReturnsFalseForMissingKey() {
            var env = new RngEnvironment("test");

            Assert.IsFalse(env.TryGet("missing", out var found));
            Assert.IsNull(found);
        }

        #endregion TryGet

        #region Environment root seed

        [TestMethod]
        public void RootSeed_SameRootAndKey_ProducesIdenticalSequences() {
            var a = new RngEnvironment("a", rootSeed: 12345);
            var b = new RngEnvironment("b", rootSeed: 12345);

            var genA = a.CreateAndRegister("player");
            var genB = b.CreateAndRegister("player");

            for (int i = 0; i < 50; i++)
                Assert.AreEqual(genA.NextInt(), genB.NextInt());
        }

        [TestMethod]
        public void RootSeed_DifferentKeys_ProduceDifferentSequences() {
            var env = new RngEnvironment("env", rootSeed: 12345);

            var player = env.CreateAndRegister("player");
            var enemy = env.CreateAndRegister("enemy");

            bool diverged = false;
            for (int i = 0; i < 50 && !diverged; i++)
                diverged = player.NextInt() != enemy.NextInt();

            Assert.IsTrue(diverged, "Generators keyed differently from the same root should differ.");
        }

        [TestMethod]
        public void RootSeed_ExplicitSeedOverridesDerivation() {
            var env = new RngEnvironment("env", rootSeed: 12345);
            var explicitly = env.CreateAndRegister("x", seed: 999);
            var reference = RngFactory.GetGenerator(RngAlgorithm.Xoshiro256, 999);

            for (int i = 0; i < 20; i++)
                Assert.AreEqual(reference.NextInt(), explicitly.NextInt());
        }

        [TestMethod]
        public void RootSeed_NullByDefault() {
            Assert.IsNull(new RngEnvironment("env").RootSeed);
            Assert.AreEqual(7L, new RngEnvironment("env", 7).RootSeed);
        }

        #endregion Environment root seed
    }
}
