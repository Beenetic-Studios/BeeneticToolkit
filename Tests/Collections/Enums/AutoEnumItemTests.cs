using BeeneticToolkit.Collections.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BeeneticToolkit.Tests.Collections.Enums {

    // --- Sample auto-enums declared exactly as a consumer would: static readonly fields, private ctor,
    //     NO Add(this), NO singleton collection class, NO hand-written lookup facades. ---

    public enum ElementGroup { None = 0, Metal, Gas }

    public sealed class Element : AutoEnumItem<Element, string, ElementGroup> {
        public static readonly Element Hydrogen = new("H", "Hydrogen", "H", 1.008, ElementGroup.Gas);
        public static readonly Element Iron = new("Fe", "Iron", "Fe", 55.845, ElementGroup.Metal);
        public static readonly Element Gold = new("Au", "Gold", "Au", 196.97, ElementGroup.Metal);

        public double AtomicWeight { get; }

        private Element(string key, string name, string shortName, double atomicWeight, ElementGroup group)
            : base(key, name, shortName, group: group) {
            AtomicWeight = atomicWeight;
        }
    }

    // A separate type whose VERY FIRST touch in its test is the static registry (not field construction),
    // to prove the registration is order-independent.
    public sealed class Coin : AutoEnumItem<Coin, int, NoGroup> {
        public static readonly Coin Penny = new(1, "Penny", "1c");
        public static readonly Coin Dime = new(10, "Dime", "10c");
        public static readonly Coin Quarter = new(25, "Quarter", "25c");

        private Coin(int key, string name, string shortName) : base(key, name, shortName) { }
    }

    [TestClass]
    public class AutoEnumItemTests {

        [TestMethod]
        public void All_DiscoversEveryStaticItem_InDeclarationOrder() {
            CollectionAssert.AreEqual(
                new[] { Element.Hydrogen, Element.Iron, Element.Gold },
                Element.All.ToArray());
        }

        [TestMethod]
        public void FromKey_ResolvesAutoRegisteredItems() {
            Assert.AreSame(Element.Gold, Element.FromKey("Au"));
            Assert.IsTrue(Element.TryFromKey("Fe", out var iron));
            Assert.AreSame(Element.Iron, iron);
            Assert.IsFalse(Element.TryFromKey("Xx", out _));
        }

        [TestMethod]
        public void FromName_AndShortName_Work() {
            Assert.AreSame(Element.Hydrogen, Element.FromName("Hydrogen"));
            Assert.AreSame(Element.Iron, Element.FromShortName("Fe"));
        }

        [TestMethod]
        public void GetByGroup_FiltersByGroup() {
            var metals = Element.GetByGroup(ElementGroup.Metal).ToList();
            CollectionAssert.AreEquivalent(new[] { Element.Iron, Element.Gold }, metals);
        }

        [TestMethod]
        public void CustomProperties_AreCarried() {
            Assert.AreEqual(196.97, Element.FromKey("Au").AtomicWeight);
        }

        [TestMethod]
        public void Registry_IsPopulated_EvenWhenAccessedBeforeAnyFieldReference() {
            // The first thing this test touches on Coin is the static registry — no manual `new Coin` or field
            // access first. With constructor-self-registration this is exactly the case that yields an empty
            // collection; auto-registration forces the class constructor, so it is fully populated.
            Assert.AreEqual(3, Coin.Count);
            Assert.AreSame(Coin.Quarter, Coin.FromKey(25));
        }
    }
}
