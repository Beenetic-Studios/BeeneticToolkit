using BeeneticToolkit.Collections.Enums.Comparators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BeeneticToolkit.Collections.Enums.Tests {

    [TestClass]
    public class EnumItemComparatorsTests {

        private class TestEnumItem : EnumItem<TestEnumGroup> {

            public TestEnumItem(string key, string name, string shortName, int? displayOrder = null, bool? isActive = null, TestEnumGroup? group = null)
                : base(key, name, shortName, null, displayOrder, isActive, group) { }
        }

        private class NoGroupEnumItem : EnumItem<NoGroup> {

            public NoGroupEnumItem(string key, string name, string shortName)
                : base(key, name, shortName) { }
        }

        [TestMethod]
        public void ByKey_SortsAscending_CorrectOrder() {
            var item1 = new TestEnumItem("b", "NameB", "ShortNameB");
            var item2 = new TestEnumItem("a", "NameA", "ShortNameA");
            var items = new List<TestEnumItem> { item1, item2 };

            var comparator = EnumItemComparators.ByKey<TestEnumGroup>();
            items.Sort(comparator);

            Assert.AreEqual("a", items[0].Key);
            Assert.AreEqual("b", items[1].Key);
        }

        [TestMethod]
        public void ByKey_SortsDescending_CorrectOrder() {
            var item1 = new TestEnumItem("b", "NameB", "ShortNameB");
            var item2 = new TestEnumItem("a", "NameA", "ShortNameA");
            var items = new List<TestEnumItem> { item1, item2 };

            var comparator = EnumItemComparators.ByKey<TestEnumGroup>(false);
            items.Sort(comparator);

            Assert.AreEqual("b", items[0].Key);
            Assert.AreEqual("a", items[1].Key);
        }

        [TestMethod]
        public void ByName_SortsAscending_CorrectOrder() {
            var item1 = new TestEnumItem("1", "B", "ShortNameB");
            var item2 = new TestEnumItem("2", "A", "ShortNameA");
            var items = new List<TestEnumItem> { item1, item2 };

            var comparator = EnumItemComparators.ByName<TestEnumGroup>();
            items.Sort(comparator);

            Assert.AreEqual("A", items[0].Name);
            Assert.AreEqual("B", items[1].Name);
        }

        [TestMethod]
        public void ByName_SortsDescending_CorrectOrder() {
            var item1 = new TestEnumItem("1", "B", "ShortNameB");
            var item2 = new TestEnumItem("2", "A", "ShortNameA");
            var items = new List<TestEnumItem> { item1, item2 };

            var comparator = EnumItemComparators.ByName<TestEnumGroup>(false);
            items.Sort(comparator);

            Assert.AreEqual("B", items[0].Name);
            Assert.AreEqual("A", items[1].Name);
        }

        [TestMethod]
        public void ByShortName_SortsAscending_CorrectOrder() {
            var item1 = new TestEnumItem("1", "Name1", "B");
            var item2 = new TestEnumItem("2", "Name2", "A");
            var items = new List<TestEnumItem> { item1, item2 };

            var comparator = EnumItemComparators.ByShortName<TestEnumGroup>();
            items.Sort(comparator);

            Assert.AreEqual("A", items[0].ShortName);
            Assert.AreEqual("B", items[1].ShortName);
        }

        [TestMethod]
        public void ByDisplayOrder_SortsAscending_CorrectOrder() {
            var item1 = new TestEnumItem("1", "Name1", "ShortName1", 2);
            var item2 = new TestEnumItem("2", "Name2", "ShortName2", 1);
            var items = new List<TestEnumItem> { item1, item2 };

            var comparator = EnumItemComparators.ByDisplayOrder<TestEnumGroup>();
            items.Sort(comparator);

            Assert.AreEqual(1, items[0].DisplayOrder);
            Assert.AreEqual(2, items[1].DisplayOrder);
        }

        [TestMethod]
        public void ByActiveState_SortsDescending_CorrectOrder() {
            var item1 = new TestEnumItem("1", "Name1", "ShortName1", isActive: false);
            var item2 = new TestEnumItem("2", "Name2", "ShortName2", isActive: true);
            var items = new List<TestEnumItem> { item1, item2 };

            var comparator = EnumItemComparators.ByActiveState<TestEnumGroup>(false);
            items.Sort(comparator);

            Assert.IsTrue(items[0].IsActive);
            Assert.IsFalse(items[1].IsActive);
        }

        [TestMethod]
        public void ByGroup_SortsAscending_CorrectOrder() {
            var item1 = new TestEnumItem("1", "Name1", "ShortName1", group: TestEnumGroup.Group2);
            var item2 = new TestEnumItem("2", "Name2", "ShortName2", group: TestEnumGroup.Group1);
            var items = new List<TestEnumItem> { item1, item2 };

            var comparator = EnumItemComparators.ByGroup<TestEnumGroup>();
            items.Sort(comparator);

            Assert.AreEqual(TestEnumGroup.Group1, items[0].Group);
            Assert.AreEqual(TestEnumGroup.Group2, items[1].Group);
        }

        [TestMethod]
        public void ByGroup_SortsNullGroupFirst() {
            var item1 = new TestEnumItem("1", "Name1", "ShortName1", group: null);
            var item2 = new TestEnumItem("2", "Name2", "ShortName2", group: TestEnumGroup.Group1);
            var items = new List<TestEnumItem> { item1, item2 };

            var comparator = EnumItemComparators.ByGroup<TestEnumGroup>();
            items.Sort(comparator);

            Assert.IsNull(items[0].Group);
            Assert.AreEqual(TestEnumGroup.Group1, items[1].Group);
        }

        [TestMethod]
        public void ByKey_WithNoGroup_SortsCorrectly() {
            var item1 = new NoGroupEnumItem("b", "NameB", "ShortNameB");
            var item2 = new NoGroupEnumItem("a", "NameA", "ShortNameA");
            var items = new List<EnumItem<NoGroup>> { item1, item2 };

            var comparator = EnumItemComparators.ByKey<NoGroup>();
            items.Sort(comparator);

            Assert.AreEqual("a", items[0].Key);
            Assert.AreEqual("b", items[1].Key);
        }

        [TestMethod]
        public void ByName_WithNoGroup_SortsCorrectly() {
            var item1 = new NoGroupEnumItem("1", "B", "ShortNameB");
            var item2 = new NoGroupEnumItem("2", "A", "ShortNameA");
            var items = new List<EnumItem<NoGroup>> { item1, item2 };

            var comparator = EnumItemComparators.ByName<NoGroup>();
            items.Sort(comparator);

            Assert.AreEqual("A", items[0].Name);
            Assert.AreEqual("B", items[1].Name);
        }
    }
}