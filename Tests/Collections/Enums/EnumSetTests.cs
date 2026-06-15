using BeeneticToolkit.Collections.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BeeneticToolkit.Tests.Collections.Enums {

    // Reuses the Element auto-enum declared in AutoEnumItemTests (Hydrogen, Iron, Gold).

    // A manual item type + collection for exercising the EnumCollection.ToDomain() path and the
    // multi-word (>64 item) bitmask paths.
    public sealed class Tag : EnumItem<int, NoGroup> {
        public Tag(int key, string name, string shortName) : base(key, name, shortName) { }
    }

    public sealed class TagCatalog : EnumCollection<Tag, int, NoGroup> { }

    [TestClass]
    public class EnumSetTests {

        [TestMethod]
        public void SetOf_ContainsOnlyGivenItems() {
            var metals = Element.SetOf(Element.Iron, Element.Gold);

            Assert.AreEqual(2, metals.Count);
            Assert.IsTrue(metals.Contains(Element.Iron));
            Assert.IsTrue(metals.Contains(Element.Gold));
            Assert.IsFalse(metals.Contains(Element.Hydrogen));
        }

        [TestMethod]
        public void EmptyAndFull_HaveExpectedCounts() {
            Assert.AreEqual(0, Element.EmptySet().Count);
            Assert.IsTrue(Element.EmptySet().IsEmpty);

            var full = Element.FullSet();
            Assert.AreEqual(Element.Count, full.Count);
            Assert.IsTrue(Element.All.All(full.Contains));
        }

        [TestMethod]
        public void Enumeration_IsInDomainOrder() {
            var set = Element.SetOf(Element.Gold, Element.Hydrogen); // added out of order
            CollectionAssert.AreEqual(
                new[] { Element.Hydrogen, Element.Gold },           // yielded in declaration order
                set.ToArray());
        }

        [TestMethod]
        public void Operators_ProduceCorrectSets() {
            var a = Element.SetOf(Element.Hydrogen, Element.Iron);
            var b = Element.SetOf(Element.Iron, Element.Gold);

            CollectionAssert.AreEquivalent(new[] { Element.Hydrogen, Element.Iron, Element.Gold }, (a | b).ToArray());
            CollectionAssert.AreEquivalent(new[] { Element.Iron }, (a & b).ToArray());
            CollectionAssert.AreEquivalent(new[] { Element.Hydrogen }, (a - b).ToArray());
            CollectionAssert.AreEquivalent(new[] { Element.Hydrogen, Element.Gold }, (a ^ b).ToArray());
        }

        [TestMethod]
        public void Operators_DoNotMutateOperands() {
            var a = Element.SetOf(Element.Hydrogen);
            var b = Element.SetOf(Element.Gold);
            _ = a | b;

            Assert.AreEqual(1, a.Count);
            Assert.AreEqual(1, b.Count);
        }

        [TestMethod]
        public void InPlaceOps_MutateInPlace() {
            var set = Element.SetOf(Element.Hydrogen, Element.Iron);
            set.IntersectWith(Element.SetOf(Element.Iron, Element.Gold));
            CollectionAssert.AreEqual(new[] { Element.Iron }, set.ToArray());

            set.UnionWith(Element.SetOf(Element.Hydrogen));
            CollectionAssert.AreEquivalent(new[] { Element.Hydrogen, Element.Iron }, set.ToArray());

            set.ExceptWith(Element.SetOf(Element.Iron));
            CollectionAssert.AreEqual(new[] { Element.Hydrogen }, set.ToArray());
        }

        [TestMethod]
        public void Complement_IsRelativeToDomain() {
            var set = Element.SetOf(Element.Iron);
            var comp = ~set;

            CollectionAssert.AreEquivalent(new[] { Element.Hydrogen, Element.Gold }, comp.ToArray());
            Assert.IsTrue((set | comp).SetEquals(Element.FullSet()));
            Assert.IsTrue((set & comp).IsEmpty);
        }

        [TestMethod]
        public void SubsetSupersetOverlaps_Work() {
            var all = Element.FullSet();
            var metals = Element.SetOf(Element.Iron, Element.Gold);

            Assert.IsTrue(metals.IsSubsetOf(all));
            Assert.IsTrue(all.IsSupersetOf(metals));
            Assert.IsTrue(metals.Overlaps(Element.SetOf(Element.Gold)));
            Assert.IsFalse(metals.Overlaps(Element.SetOf(Element.Hydrogen)));
        }

        [TestMethod]
        public void Equality_RequiresSameItems() {
            Assert.AreEqual(Element.SetOf(Element.Iron, Element.Gold), Element.SetOf(Element.Gold, Element.Iron));
            Assert.AreEqual(
                Element.SetOf(Element.Iron).GetHashCode(),
                Element.SetOf(Element.Iron).GetHashCode());
            Assert.AreNotEqual(Element.SetOf(Element.Iron), Element.SetOf(Element.Gold));
        }

        [TestMethod]
        public void AddRemove_Work() {
            var set = Element.EmptySet();
            set.Add(Element.Iron);
            Assert.IsTrue(set.Contains(Element.Iron));
            Assert.IsTrue(set.Remove(Element.Iron));
            Assert.IsFalse(set.Remove(Element.Iron));
            Assert.IsTrue(set.IsEmpty);
        }

        [TestMethod]
        public void DifferentDomains_CannotCombine() {
            var catalog = new TagCatalog();
            catalog.Add(new Tag(1, "Fire", "F"));

            // Two distinct domain instances over the same items: sets from them must not interoperate.
            var domainA = new EnumDomain<Tag>(catalog.GetAll());
            var domainB = new EnumDomain<Tag>(catalog.GetAll());

            Assert.ThrowsException<ArgumentException>(() => domainA.Empty().UnionWith(domainB.Empty()));
            Assert.ThrowsException<ArgumentException>(() => domainA.Empty().IsSubsetOf(domainB.Empty()));
        }

        [TestMethod]
        public void Add_ItemOutsideDomain_Throws() {
            var catalog = new TagCatalog();
            catalog.Add(new Tag(1, "Fire", "F"));
            var domain = catalog.ToDomain();              // snapshot: only Fire
            var set = domain.Empty();

            var notInDomain = new Tag(2, "Ice", "I");
            Assert.ThrowsException<ArgumentException>(() => set.Add(notInDomain));
        }

        [TestMethod]
        public void MultiWord_HandlesMoreThan64Items() {
            // 70 items forces a 2-word bitmask, exercising cross-word operations.
            var catalog = new TagCatalog();
            for (int i = 0; i < 70; i++)
                catalog.Add(new Tag(i, $"Tag{i}", $"T{i}"));
            var domain = catalog.ToDomain();

            // Pick items in both words (index 5 and index 65).
            var set = domain.Of(catalog.FromKey(5), catalog.FromKey(65));
            Assert.AreEqual(2, set.Count);
            Assert.IsTrue(set.Contains(catalog.FromKey(5)));
            Assert.IsTrue(set.Contains(catalog.FromKey(65)));

            // Complement must cover the other 68 and exclude the high unused bits of the second word.
            var comp = set.Complement();
            Assert.AreEqual(68, comp.Count);
            Assert.IsFalse(comp.Contains(catalog.FromKey(5)));
            Assert.IsTrue((set | comp).SetEquals(domain.All()));
        }

        [TestMethod]
        public void ToString_ListsItemsInOrder() {
            Assert.AreEqual("{Hydrogen, Gold}", Element.SetOf(Element.Gold, Element.Hydrogen).ToString());
            Assert.AreEqual("{}", Element.EmptySet().ToString());
        }

        [TestMethod]
        public void Domain_RejectsDuplicates() {
            var fire = new Tag(1, "Fire", "F");
            Assert.ThrowsException<ArgumentException>(() => new EnumDomain<Tag>(new[] { fire, fire }));
        }
    }
}
