using BeeneticToolkit.Random;
using BeeneticToolkit.Random.Probability;
using BeeneticToolkit.Random.Sampling;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BeeneticToolkit.Tests.Random {

    /// <summary>
    /// Locks in that every consumer helper/extension in the Random module is usable through an
    /// <see cref="IRandomGenerator"/>-typed reference (not just the concrete <see cref="RandomGenerator"/>),
    /// so the interface remains a real DI/mocking seam. These tests exist mainly to fail at <i>compile</i>
    /// time if a helper ever narrows back to the concrete type; the runtime asserts guard determinism.
    /// </summary>
    [TestClass]
    public class InterfaceSeamTests {

        private const long Seed = 20240614L;

        private static IRandomGenerator NewGen() =>
            new RandomEnvironment("seam", Seed).CreateAndRegister("seam");

        [TestMethod]
        public void Helpers_AreCallable_ThroughInterfaceReference() {
            IRandomGenerator rng = NewGen();
            var items = new[] { 1, 2, 3, 4, 5 };

            // Probability
            _ = rng.Roll("2d6+1");                          // DiceExtensions
            _ = rng.Roll(new DiceRoll(2, 6, 1));
            _ = new WeightedBag<string>()
                    .Add("a", 1.0).Add("b", 1.0).Draw(rng);  // WeightedBag
            _ = new LootTable<string>().Add("x").Roll(rng);  // LootTable
            _ = new PityCounter(0.1, 10).Roll(rng);          // PityCounter

            // Selectors / shuffle
            _ = rng.RandomChoice(items);
            _ = rng.RandomWeightedChoice(items, new[] { 1.0, 1, 1, 1, 1 });
            _ = rng.RandomSubset(items, 2);
            _ = rng.Shuffle(items);
            var copy = new List<int>(items);
            rng.ShuffleInPlace(copy);
            _ = rng.TryRandomChoice(items, out _);

            // Spatial sampling
            _ = rng.NextAngle();
            _ = rng.NextUnitVector2();
            _ = rng.NextUnitVector3();
            _ = rng.NextPointInCircle();
            _ = rng.NextPointInSphere();
            _ = PoissonDisk.Sample(rng, 10f, 10f, 1f);

            Assert.IsTrue(true, "All helpers compiled and ran against an IRandomGenerator reference.");
        }

        [TestMethod]
        public void Helpers_StayDeterministic_ThroughInterfaceReference() {
            // Determinism is a property of the seeded instance, not the reference type: two generators
            // seeded identically must produce identical results even when only the interface is in view.
            IRandomGenerator a = NewGen();
            IRandomGenerator b = NewGen();

            Assert.AreEqual(a.Roll("3d8+2"), b.Roll("3d8+2"));
            Assert.AreEqual(a.RandomChoice(new[] { 10, 20, 30, 40 }),
                            b.RandomChoice(new[] { 10, 20, 30, 40 }));

            var bagA = new WeightedBag<int>().Add(1, 1).Add(2, 2).Add(3, 3);
            var bagB = new WeightedBag<int>().Add(1, 1).Add(2, 2).Add(3, 3);
            Assert.AreEqual(bagA.Draw(a), bagB.Draw(b));
        }
    }
}
