using BeeneticToolkit.Random;
using BeeneticToolkit.Random.Probability;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Tests.Random {

    [TestClass]
    public class ProbabilityTests {

        private const long Seed = 20240614L;

        private static RandomGenerator NewGen() =>
            new RandomEnvironment("test", Seed).CreateAndRegister("probability");

        // ---------------- WeightedBag ----------------

        [TestMethod]
        public void WeightedBag_Draw_RespectsWeightsApproximately() {
            var bag = new WeightedBag<string>()
                .Add("common", 9.0)
                .Add("rare", 1.0);
            var gen = NewGen();

            int common = 0, total = 10000;
            for (int i = 0; i < total; i++)
                if (bag.Draw(gen) == "common")
                    common++;

            double fraction = (double)common / total;
            Assert.AreEqual(0.9, fraction, 0.03, $"Expected ~90% common, got {fraction:P1}.");
        }

        [TestMethod]
        public void WeightedBag_Draw_DoesNotRemove() {
            var bag = new WeightedBag<int>().Add(1, 1.0).Add(2, 1.0);
            var gen = NewGen();

            bag.Draw(gen);
            Assert.AreEqual(2, bag.Count);
        }

        [TestMethod]
        public void WeightedBag_DrawWithoutReplacement_DepletesBag() {
            var bag = new WeightedBag<int>().Add(1, 1.0).Add(2, 2.0).Add(3, 3.0);
            var gen = NewGen();

            var drawn = new List<int> {
                bag.DrawWithoutReplacement(gen),
                bag.DrawWithoutReplacement(gen),
                bag.DrawWithoutReplacement(gen)
            };

            Assert.AreEqual(0, bag.Count);
            Assert.AreEqual(0.0, bag.TotalWeight, 1e-9);
            CollectionAssert.AreEquivalent(new[] { 1, 2, 3 }, drawn);
        }

        [TestMethod]
        public void WeightedBag_DrawWithoutReplacement_ThrowsWhenEmpty() {
            var bag = new WeightedBag<int>();
            Assert.ThrowsException<InvalidOperationException>(() => bag.DrawWithoutReplacement(NewGen()));
        }

        [TestMethod]
        public void WeightedBag_TryDraw_ReturnsFalseWhenEmpty() {
            var bag = new WeightedBag<int>();
            Assert.IsFalse(bag.TryDraw(NewGen(), out _));
        }

        [TestMethod]
        public void WeightedBag_Add_ValidatesWeight() {
            var bag = new WeightedBag<int>();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bag.Add(1, 0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bag.Add(1, -1));
        }

        [TestMethod]
        public void WeightedBag_IsDeterministic() {
            var a = new WeightedBag<int>().Add(1, 1).Add(2, 1).Add(3, 1);
            var b = new WeightedBag<int>().Add(1, 1).Add(2, 1).Add(3, 1);
            var genA = NewGen();
            var genB = NewGen();

            for (int i = 0; i < 50; i++)
                Assert.AreEqual(a.Draw(genA), b.Draw(genB));
        }

        // ---------------- LootTable ----------------

        [TestMethod]
        public void LootTable_Roll_OnlyReturnsAddedItems() {
            var table = new LootTable<string>()
                .Add("sword", 1)
                .Add("shield", 1);
            var gen = NewGen();

            for (int i = 0; i < 100; i++) {
                string drop = table.Roll(gen);
                Assert.IsTrue(drop == "sword" || drop == "shield", $"Unexpected drop: {drop}");
            }
        }

        [TestMethod]
        public void LootTable_NestedTable_ResolvesToLeafItems() {
            var rare = new LootTable<string>().Add("epic", 1).Add("legendary", 1);
            var root = new LootTable<string>()
                .Add("common", 9)
                .AddTable(rare, 1);
            var gen = NewGen();

            var seen = new HashSet<string>();
            for (int i = 0; i < 5000; i++)
                seen.Add(root.Roll(gen));

            // Over many rolls we should see the common item and both nested rares.
            Assert.IsTrue(seen.Contains("common"));
            Assert.IsTrue(seen.Contains("epic"));
            Assert.IsTrue(seen.Contains("legendary"));
            Assert.IsFalse(seen.Contains(null));
        }

        [TestMethod]
        public void LootTable_RollMany_ReturnsRequestedCount() {
            var table = new LootTable<int>().Add(1, 1).Add(2, 1);
            var drops = table.Roll(NewGen(), 20);
            Assert.AreEqual(20, drops.Count);
        }

        [TestMethod]
        public void LootTable_Roll_ThrowsWhenEmpty() {
            var table = new LootTable<int>();
            Assert.ThrowsException<InvalidOperationException>(() => table.Roll(NewGen()));
        }

        [TestMethod]
        public void LootTable_TryRoll_ReturnsFalseWhenEmpty() {
            var table = new LootTable<int>();
            Assert.IsFalse(table.TryRoll(NewGen(), out _));
        }

        [TestMethod]
        public void LootTable_Add_ValidatesArguments() {
            var table = new LootTable<int>();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => table.Add(1, 0));
            Assert.ThrowsException<ArgumentNullException>(() => table.AddTable(null, 1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => table.Roll(NewGen(), -1));
        }

        // ---------------- DiceRoll ----------------

        [TestMethod]
        public void DiceRoll_Parse_HandlesAllForms() {
            Assert.AreEqual(new DiceRoll(2, 6, 1), DiceRoll.Parse("2d6+1"));
            Assert.AreEqual(new DiceRoll(1, 20, 0), DiceRoll.Parse("d20"));
            Assert.AreEqual(new DiceRoll(4, 8, -2), DiceRoll.Parse("4d8-2"));
            Assert.AreEqual(new DiceRoll(3, 6, 0), DiceRoll.Parse(" 3 D 6 "));
        }

        [TestMethod]
        public void DiceRoll_Parse_RejectsGarbage() {
            Assert.ThrowsException<FormatException>(() => DiceRoll.Parse("hello"));
            Assert.ThrowsException<FormatException>(() => DiceRoll.Parse("2x6"));
            Assert.ThrowsException<FormatException>(() => DiceRoll.Parse("d"));
            Assert.ThrowsException<FormatException>(() => DiceRoll.Parse("0d6"));
            Assert.ThrowsException<ArgumentNullException>(() => DiceRoll.Parse(null));
        }

        [TestMethod]
        public void DiceRoll_TryParse_ReturnsFalseOnBadInput() {
            Assert.IsFalse(DiceRoll.TryParse("nonsense", out _));
            Assert.IsTrue(DiceRoll.TryParse("2d6", out var d));
            Assert.AreEqual(new DiceRoll(2, 6), d);
        }

        [TestMethod]
        public void DiceRoll_Roll_StaysWithinMinMax() {
            var dice = new DiceRoll(3, 6, 2);
            Assert.AreEqual(5, dice.Min);
            Assert.AreEqual(20, dice.Max);

            var gen = NewGen();
            for (int i = 0; i < 1000; i++) {
                int total = dice.Roll(gen);
                Assert.IsTrue(total >= dice.Min && total <= dice.Max, $"Out of range: {total}");
            }
        }

        [TestMethod]
        public void DiceRoll_RollEach_ReturnsIndividualDice() {
            var dice = new DiceRoll(5, 6);
            int[] rolls = dice.RollEach(NewGen());

            Assert.AreEqual(5, rolls.Length);
            foreach (int r in rolls)
                Assert.IsTrue(r >= 1 && r <= 6, $"Die out of range: {r}");
        }

        [TestMethod]
        public void DiceRoll_Constructor_ValidatesArguments() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new DiceRoll(0, 6));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new DiceRoll(2, 0));
        }

        [TestMethod]
        public void DiceRoll_ToString_RoundTrips() {
            Assert.AreEqual("2d6+1", new DiceRoll(2, 6, 1).ToString());
            Assert.AreEqual("1d20", new DiceRoll(1, 20).ToString());
            Assert.AreEqual("4d8-2", new DiceRoll(4, 8, -2).ToString());
        }

        [TestMethod]
        public void DiceExtensions_Roll_MatchesParsedRoll() {
            var genA = NewGen();
            var genB = NewGen();
            Assert.AreEqual(DiceRoll.Parse("2d6+1").Roll(genA), genB.Roll("2d6+1"));
        }

        // ---------------- PityCounter ----------------

        [TestMethod]
        public void PityCounter_GuaranteesSuccessByHardPity() {
            // Zero base chance: success only ever comes from hard pity.
            var pity = new PityCounter(baseChance: 0.0, hardPity: 10);
            var gen = NewGen();

            int pulls = 0;
            while (!pity.Roll(gen)) {
                pulls++;
                Assert.IsTrue(pulls < 10, "Hard pity failed to guarantee a success.");
            }

            Assert.AreEqual(9, pulls, "Success should land exactly on the 10th pull.");
            Assert.AreEqual(0, pity.Failures, "Streak should reset on success.");
        }

        [TestMethod]
        public void PityCounter_ResetsFailuresAfterSuccess() {
            var pity = new PityCounter(baseChance: 1.0, hardPity: 90);
            Assert.IsTrue(pity.Roll(NewGen()));
            Assert.AreEqual(0, pity.Failures);
        }

        [TestMethod]
        public void PityCounter_CurrentChanceRampsThenGuarantees() {
            var pity = new PityCounter(baseChance: 0.0, hardPity: 5, softPityStart: 2, softPityIncrement: 0.1);
            // Failures = 0 -> next pull #1: below soft pity -> base 0.
            Assert.AreEqual(0.0, pity.CurrentChance, 1e-9);

            var gen = NewGen();
            // Each Roll fails (chance 0 until hard pity), growing the streak.
            pity.Roll(gen); // failures -> 1, next pull #2 == softPityStart, still base
            Assert.AreEqual(0.0, pity.CurrentChance, 1e-9);
            pity.Roll(gen); // failures -> 2, next pull #3 > start -> 0.1
            Assert.AreEqual(0.1, pity.CurrentChance, 1e-9);
            pity.Roll(gen); // failures -> 3, next pull #4 -> 0.2
            Assert.AreEqual(0.2, pity.CurrentChance, 1e-9);
            pity.Roll(gen); // failures -> 4, next pull #5 == hardPity -> guaranteed
            Assert.AreEqual(1.0, pity.CurrentChance, 1e-9);
        }

        [TestMethod]
        public void PityCounter_Constructor_ValidatesArguments() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new PityCounter(-0.1, 10));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new PityCounter(1.1, 10));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new PityCounter(0.5, 0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new PityCounter(0.5, 10, -1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new PityCounter(0.5, 10, 2, -0.1));
        }

        [TestMethod]
        public void Probability_ValidatesNullGenerator() {
            var bag = new WeightedBag<int>().Add(1, 1);
            var table = new LootTable<int>().Add(1, 1);
            var pity = new PityCounter(0.5, 10);
            var dice = new DiceRoll(2, 6);

            Assert.ThrowsException<ArgumentNullException>(() => bag.Draw(null));
            Assert.ThrowsException<ArgumentNullException>(() => table.Roll(null));
            Assert.ThrowsException<ArgumentNullException>(() => pity.Roll(null));
            Assert.ThrowsException<ArgumentNullException>(() => dice.Roll(null));
        }
    }
}
