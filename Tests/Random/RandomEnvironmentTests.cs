using BeeneticToolkit.Random;
using BeeneticToolkit.Random.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BeeneticToolkit.Tests.Random {

    [TestClass]
    public class RandomEnvironmentTests {

        /// <summary>A trivial custom generator used to exercise the <see cref="RandomEnvironment.Register(string, RandomGenerator)"/> extensibility path.</summary>
        private sealed class ConstantGenerator : RandomGenerator {
            private readonly long _value;
            public ConstantGenerator(long value) : base(1) { _value = value; }
            protected override void InitializeRng() { }
            protected override long Next() => _value;
        }

        #region RandomKey overloads

        [TestMethod]
        public void CreateAndRegister_RandomKey_RetrievableByKeyAndEquivalentString() {
            var env = new RandomEnvironment("keys", rootSeed: 1);
            var key = new RandomKey("loot");

            var gen = env.CreateAndRegister(key);

            Assert.AreSame(gen, env.Get(key));
            Assert.AreSame(gen, env.Get("loot"), "A RandomKey and its string value must address the same slot.");
            Assert.IsTrue(env.TryGet(key, out var viaKey));
            Assert.AreSame(gen, viaKey);
        }

        [TestMethod]
        public void Register_RandomKey_RetrievableByEquivalentString() {
            var env = new RandomEnvironment("keys", rootSeed: 1);
            var custom = new ConstantGenerator(42);

            env.Register(new RandomKey("custom"), custom);

            Assert.AreSame(custom, env.Get("custom"));
        }

        [TestMethod]
        public void StringRegistration_RetrievableByRandomKey() {
            var env = new RandomEnvironment("keys", rootSeed: 1);
            var gen = env.CreateAndRegister("terrain");

            Assert.AreSame(gen, env.Get(new RandomKey("terrain")));
        }

        #endregion RandomKey overloads

        #region Register (custom generator)

        [TestMethod]
        public void Register_CustomGenerator_IsRetrievableAndUsable() {
            var env = new RandomEnvironment("custom", rootSeed: 1);
            var custom = new ConstantGenerator(777);

            env.Register("fixed", custom);
            var retrieved = env.Get("fixed");

            Assert.AreSame(custom, retrieved);
            Assert.AreEqual(777L, retrieved.NextLong(), "The custom generator's own behavior must be preserved.");
        }

        #endregion Register (custom generator)

        #region DefaultAlgorithm

        [TestMethod]
        public void DefaultAlgorithm_DefaultsToXoshiro() {
            Assert.AreEqual(RandomAlgorithm.Xoshiro256, new RandomEnvironment("e").DefaultAlgorithm);
        }

        [TestMethod]
        public void DefaultAlgorithm_AppliesToCreateAndRegister() {
            var env = new RandomEnvironment("e", rootSeed: 1, algorithm: RandomAlgorithm.Xorshift);

            Assert.AreEqual(RandomAlgorithm.Xorshift, env.DefaultAlgorithm);
            Assert.IsInstanceOfType(env.CreateAndRegister("g"), typeof(Xorshift));
        }

        [TestMethod]
        public void DefaultAlgorithm_PerGeneratorOverrideWins() {
            var env = new RandomEnvironment("e", rootSeed: 1, algorithm: RandomAlgorithm.Xorshift);

            var defaulted = env.CreateAndRegister("default");
            var overridden = env.CreateAndRegister("override", algorithm: RandomAlgorithm.MiddleSquare);

            Assert.IsInstanceOfType(defaulted, typeof(Xorshift));
            Assert.IsInstanceOfType(overridden, typeof(MiddleSquare));
        }

        #endregion DefaultAlgorithm

        #region Reproducibility breadth (#8)

        /// <summary>Draws a deterministic mix of value types so reproducibility is verified across the API, not just NextInt.</summary>
        private static List<double> DrawMixedSequence(RandomGenerator g, int rounds) {
            var seq = new List<double>(rounds * 6);
            for (int i = 0; i < rounds; i++) {
                seq.Add(g.NextInt(1_000));
                seq.Add(g.NextInt(-50, 50));
                seq.Add(g.NextLong(1_000_000));
                seq.Add(g.NextDouble());
                seq.Add(g.NextFloat());
                seq.Add(g.NextBool() ? 1 : 0);
            }
            return seq;
        }

        [TestMethod]
        public void RecreatedEnvironment_SameRoot_ReplaysAcrossAllValueTypes() {
            var first = new RandomEnvironment("run", rootSeed: 2024).CreateAndRegister("player");
            var seqA = DrawMixedSequence(first, 200);

            // A brand-new environment built from the same root must reproduce the run exactly.
            var second = new RandomEnvironment("run", rootSeed: 2024).CreateAndRegister("player");
            var seqB = DrawMixedSequence(second, 200);

            CollectionAssert.AreEqual(seqA, seqB);
        }

        [TestMethod]
        public void RecreatedEnvironment_MultipleKeys_EachReplaysIndependently() {
            var envA = new RandomEnvironment("world", rootSeed: 99);
            var terrainA = DrawMixedSequence(envA.CreateAndRegister("terrain"), 50);
            var lootA = DrawMixedSequence(envA.CreateAndRegister("loot"), 50);

            var envB = new RandomEnvironment("world", rootSeed: 99);
            var terrainB = DrawMixedSequence(envB.CreateAndRegister("terrain"), 50);
            var lootB = DrawMixedSequence(envB.CreateAndRegister("loot"), 50);

            CollectionAssert.AreEqual(terrainA, terrainB);
            CollectionAssert.AreEqual(lootA, lootB);
            CollectionAssert.AreNotEqual(terrainA, lootA, "Different keys must produce independent streams.");
        }

        #endregion Reproducibility breadth
    }
}
