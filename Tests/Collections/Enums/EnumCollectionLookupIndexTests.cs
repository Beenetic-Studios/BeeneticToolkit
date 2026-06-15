using BeeneticToolkit.Collections.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeeneticToolkit.Tests.Collections.Enums {

    [TestClass]
    public class EnumCollectionLookupIndexTests {

        private sealed class Item : EnumItem<string, NoGroup> {
            public Item(string key, string name, string shortName) : base(key, name, shortName) { }
        }

        private sealed class Items : EnumCollection<Item, string, NoGroup> { }

        private static Items NewCollection() {
            var c = new Items();
            c.Add(new Item("k1", "Alpha", "A"));
            c.Add(new Item("k2", "Beta", "B"));
            return c;
        }

        [TestMethod]
        public void FromName_ResolvesViaIndex() {
            var c = NewCollection();
            Assert.AreEqual("k2", c.FromName("Beta").Key);
            Assert.IsTrue(c.TryFromName("Alpha", out var a));
            Assert.AreEqual("k1", a.Key);
        }

        [TestMethod]
        public void FromShortName_ResolvesViaIndex() {
            var c = NewCollection();
            Assert.AreEqual("k1", c.FromShortName("A").Key);
            Assert.IsTrue(c.TryFromShortName("B", out var b));
            Assert.AreEqual("k2", b.Key);
        }

        [TestMethod]
        public void DuplicateName_KeepsFirstMatch() {
            var c = new Items();
            c.Add(new Item("first", "Same", "F"));
            c.Add(new Item("second", "Same", "S"));

            // Mirrors the original FirstOrDefault behavior: the first inserted wins.
            Assert.AreEqual("first", c.FromName("Same").Key);
        }

        [TestMethod]
        public void NameLookup_IsCaseSensitive() {
            var c = NewCollection();
            Assert.IsFalse(c.TryFromName("alpha", out _));   // wrong case
            Assert.IsTrue(c.TryFromName("Alpha", out _));
        }

        [TestMethod]
        public void Index_IsRebuiltAfterAdd() {
            var c = NewCollection();
            Assert.IsFalse(c.TryFromName("Gamma", out _));   // builds + caches the index

            c.Add(new Item("k3", "Gamma", "G"));             // must invalidate the cache
            Assert.IsTrue(c.TryFromName("Gamma", out var g));
            Assert.AreEqual("k3", g.Key);
        }

        [TestMethod]
        public void Index_IsRebuiltAfterRemove() {
            var c = NewCollection();
            var beta = c.FromKey("k2");
            Assert.IsTrue(c.TryFromName("Beta", out _));      // builds + caches the index

            c.Remove(beta);
            Assert.IsFalse(c.TryFromName("Beta", out _));     // gone after invalidation
        }

        [TestMethod]
        public void MissingOrNull_ReturnsFalseWithoutThrowing() {
            var c = NewCollection();
            Assert.IsFalse(c.TryFromName("nope", out _));
            Assert.IsFalse(c.TryFromName(null!, out _));
            Assert.IsFalse(c.TryFromShortName(null!, out _));
        }
    }
}
