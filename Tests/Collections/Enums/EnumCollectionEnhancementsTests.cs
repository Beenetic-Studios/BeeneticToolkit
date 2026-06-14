using BeeneticToolkit.Collections.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Tests.Collections.Enums {

    [TestClass]
    public class EnumCollectionEnhancementsTests {

        private class Item : EnumItem<string, TestEnumGroup> {
            public Item(string key, string name, string shortName) : base(key, name, shortName) { }
        }

        private class ItemCollection : EnumCollection<Item, string, TestEnumGroup> { }

        private static ItemCollection Make() {
            var c = new ItemCollection();
            c.Add(new Item("k1", "Alpha", "A"));
            c.Add(new Item("k2", "Bravo", "B"));
            return c;
        }

        #region TryFrom*

        [TestMethod]
        public void TryFromKey_Existing_ReturnsTrueAndItem() {
            var c = Make();
            Assert.IsTrue(c.TryFromKey("k2", out var item));
            Assert.AreEqual("Bravo", item.Name);
        }

        [TestMethod]
        public void TryFromKey_Missing_ReturnsFalseAndNull() {
            var c = Make();
            Assert.IsFalse(c.TryFromKey("nope", out var item));
            Assert.IsNull(item);
        }

        [TestMethod]
        public void TryFromName_Existing_ReturnsTrueAndItem() {
            var c = Make();
            Assert.IsTrue(c.TryFromName("Alpha", out var item));
            Assert.AreEqual("k1", item.Key);
        }

        [TestMethod]
        public void TryFromName_Missing_ReturnsFalse() {
            Assert.IsFalse(Make().TryFromName("nope", out _));
        }

        [TestMethod]
        public void TryFromShortName_ExistingAndMissing() {
            var c = Make();
            Assert.IsTrue(c.TryFromShortName("B", out var item));
            Assert.AreEqual("k2", item.Key);
            Assert.IsFalse(c.TryFromShortName("Z", out _));
        }

        [TestMethod]
        public void FromKey_AfterRemove_ReflectsUpdatedIndex() {
            var c = Make();
            var item = c.FromKey("k1");

            c.Remove(item);

            Assert.IsFalse(c.TryFromKey("k1", out _));
            Assert.ThrowsException<InvalidOperationException>(() => c.FromKey("k1"));
        }

        [TestMethod]
        public void Add_AfterRemove_AllowsReusingKey() {
            var c = Make();
            c.Remove(c.FromKey("k1"));
            c.Add(new Item("k1", "Replacement", "R")); // must not throw duplicate now
            Assert.AreEqual("Replacement", c.FromKey("k1").Name);
        }

        #endregion TryFrom*

        #region EnumItem generic IEquatable / IComparable

        [TestMethod]
        public void GenericEquals_SameKey_True_DifferentKey_False() {
            var a = new Item("k", "N1", "S1");
            var b = new Item("k", "N2", "S2");
            var c = new Item("other", "N3", "S3");

            Assert.IsTrue(a.Equals(b));
            Assert.IsFalse(a.Equals(c));
        }

        [TestMethod]
        public void GenericCompareTo_OrdersByKey() {
            EnumItem<string, TestEnumGroup> a = new Item("a", "N", "S");
            EnumItem<string, TestEnumGroup> b = new Item("b", "N", "S");

            Assert.IsTrue(a.CompareTo(b) < 0);
            Assert.IsTrue(b.CompareTo(a) > 0);
            Assert.AreEqual(0, a.CompareTo(new Item("a", "X", "Y")));
        }

        [TestMethod]
        public void CompareTo_Null_ReturnsPositive() {
            var a = new Item("a", "N", "S");
            Assert.IsTrue(a.CompareTo((EnumItem<string, TestEnumGroup>)null) > 0);
            Assert.IsTrue(a.CompareTo((object)null) > 0);
        }

        [TestMethod]
        public void Sort_OrdersByKeyViaComparable() {
            var list = new List<Item> {
                new Item("c", "N", "S"),
                new Item("a", "N", "S"),
                new Item("b", "N", "S"),
            };

            list.Sort();

            CollectionAssert.AreEqual(new[] { "a", "b", "c" }, list.Select(i => i.Key).ToArray());
        }

        #endregion EnumItem generic IEquatable / IComparable

        #region Snapshot results

        [TestMethod]
        public void GetByGroup_ReturnsSnapshot_SafeToEnumerateAfterModification() {
            var c = Make();
            var result = c.GetByGroup(null);

            c.Add(new Item("k3", "Charlie", "C")); // modify after obtaining the result

            // Materialized snapshot: enumeration must not throw "collection modified" and reflects pre-add state.
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void Search_ReturnsSnapshot_SafeToEnumerateAfterModification() {
            var c = Make();
            var result = c.Search(i => i.Name, "a"); // matches Alpha and Bravo (case-insensitive)

            c.Add(new Item("k3", "Charlie", "C"));

            Assert.AreEqual(2, result.Count());
        }

        #endregion Snapshot results
    }
}
