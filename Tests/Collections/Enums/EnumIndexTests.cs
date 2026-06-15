using BeeneticToolkit.Collections.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BeeneticToolkit.Tests.Collections.Enums {

    [TestClass]
    public class EnumIndexTests {

        private sealed class Unit : EnumItem<string, NoGroup> {
            public Unit(string key, string name, string shortName, string faction, int cost)
                : base(key, name, shortName) {
                Faction = faction;
                Cost = cost;
            }

            public string Faction { get; }
            public int Cost { get; }
        }

        private sealed class Units : EnumCollection<Unit, string, NoGroup> { }

        private static Units NewUnits() {
            var c = new Units();
            c.Add(new Unit("knight", "Knight", "K", "Order", 3));
            c.Add(new Unit("cleric", "Cleric", "C", "Order", 2));
            c.Add(new Unit("ghoul", "Ghoul", "G", "Undead", 2));
            return c;
        }

        [TestMethod]
        public void AddIndex_GroupsItemsByValue() {
            var units = NewUnits();
            var byFaction = units.AddIndex(u => u.Faction);

            CollectionAssert.AreEquivalent(
                new[] { "knight", "cleric" },
                byFaction.Get("Order").Select(u => u.Key).ToArray());
            CollectionAssert.AreEqual(new[] { "ghoul" }, byFaction.Get("Undead").Select(u => u.Key).ToArray());
        }

        [TestMethod]
        public void Get_UnknownValue_ReturnsEmpty() {
            var byFaction = NewUnits().AddIndex(u => u.Faction);
            Assert.AreEqual(0, byFaction.Get("Elves").Count);
            Assert.IsFalse(byFaction.Contains("Elves"));
        }

        [TestMethod]
        public void KeysAndCount_ReflectDistinctValues() {
            var byCost = NewUnits().AddIndex(u => u.Cost);
            Assert.AreEqual(2, byCost.Count);                       // costs 3 and 2
            CollectionAssert.AreEquivalent(new[] { 2, 3 }, byCost.Keys.ToArray());
        }

        [TestMethod]
        public void GetSingle_Works_AndThrowsOnAmbiguity() {
            var units = NewUnits();
            var byKeyName = units.AddIndex(u => u.Name);

            Assert.AreEqual("knight", byKeyName.GetSingle("Knight").Key);
            Assert.IsTrue(byKeyName.TryGetSingle("Cleric", out var cleric));
            Assert.AreEqual("cleric", cleric.Key);

            var byFaction = units.AddIndex(u => u.Faction);
            Assert.ThrowsException<InvalidOperationException>(() => byFaction.GetSingle("Order")); // two units
            Assert.IsFalse(byFaction.TryGetSingle("Order", out _));
            Assert.IsFalse(byFaction.TryGetSingle("Nope", out _));
        }

        [TestMethod]
        public void Index_StaysInSyncWithAdds() {
            var units = NewUnits();
            var byFaction = units.AddIndex(u => u.Faction);

            units.Add(new Unit("lich", "Lich", "L", "Undead", 5));
            CollectionAssert.AreEquivalent(
                new[] { "ghoul", "lich" },
                byFaction.Get("Undead").Select(u => u.Key).ToArray());
        }

        [TestMethod]
        public void Index_StaysInSyncWithRemoves() {
            var units = NewUnits();
            var byFaction = units.AddIndex(u => u.Faction);

            units.Remove(units.FromKey("cleric"));
            CollectionAssert.AreEqual(new[] { "knight" }, byFaction.Get("Order").Select(u => u.Key).ToArray());

            units.Remove(units.FromKey("ghoul"));
            Assert.IsFalse(byFaction.Contains("Undead"));          // last item removed → value drops out
            Assert.AreEqual(1, byFaction.Count);
        }

        [TestMethod]
        public void NullValuedItems_AreNotIndexed() {
            var c = new Units();
            c.Add(new Unit("wild", "Wildcard", "W", null!, 1));    // null faction
            var byFaction = c.AddIndex(u => u.Faction);

            Assert.AreEqual(0, byFaction.Count);
            Assert.AreEqual(0, byFaction.Get("Order").Count);
        }

        [TestMethod]
        public void AddIndex_NullSelector_Throws() {
            Assert.ThrowsException<ArgumentNullException>(() => NewUnits().AddIndex<int>(null!));
        }

        // --- AutoEnumItem path ---

        [TestMethod]
        public void AutoEnumItem_IndexBy_BuildsOverFixedSet() {
            // Element (Hydrogen/Iron/Gold) is declared in AutoEnumItemTests with an ElementGroup.
            var byGroup = Element.IndexBy(e => e.Group);

            CollectionAssert.AreEquivalent(
                new[] { Element.Iron, Element.Gold },
                byGroup.Get(ElementGroup.Metal).ToArray());
            Assert.AreEqual(Element.Hydrogen, byGroup.GetSingle(ElementGroup.Gas));
        }
    }
}
