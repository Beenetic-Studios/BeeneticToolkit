using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BeeneticToolkit.Collections.Enums.Tests {

    [TestClass]
    public class EnumCollectionTests {

        private class TestEnumItem : EnumItem<TestEnumGroup> {

            public TestEnumItem(string key, string name, string shortName)
                : base(key, name, shortName) { }
        }

        private class TestEnumCollection : EnumCollection<TestEnumItem, TestEnumGroup> { }

        [TestMethod]
        public void Add_WithUniqueKey_AddsItem() {
            var collection = new TestEnumCollection();
            var item = new TestEnumItem("key1", "Name1", "ShortName1");

            collection.Add(item);
            var items = collection.GetAll();

            Assert.AreEqual(1, items.Count);
            Assert.AreEqual(item, items[0]);
        }

        [TestMethod]
        public void Add_WithDuplicateKey_ThrowsException() {
            var collection = new TestEnumCollection();
            var item1 = new TestEnumItem("key1", "Name1", "ShortName1");
            var item2 = new TestEnumItem("key1", "Name2", "ShortName2");

            collection.Add(item1);
            Assert.ThrowsException<InvalidOperationException>(() => collection.Add(item2));
        }

        [TestMethod]
        public void AddRange_WithUniqueKeys_AddsAllItems() {
            var collection = new TestEnumCollection();
            var items = new[] {
                new TestEnumItem("key1", "Name1", "ShortName1"),
                new TestEnumItem("key2", "Name2", "ShortName2"),
            };

            collection.AddRange(items);

            Assert.AreEqual(2, collection.GetAll().Count);
            Assert.IsTrue(collection.GetAll().SequenceEqual(items));
        }

        [TestMethod]
        public void AddRange_WithDuplicateKey_ThrowsException() {
            var collection = new TestEnumCollection();
            var items = new[] {
                new TestEnumItem("key1", "Name1", "ShortName1"),
                new TestEnumItem("key1", "Name2", "ShortName2"),
            };

            Assert.ThrowsException<InvalidOperationException>(() => collection.AddRange(items));
        }

        [TestMethod]
        public void GetAll_WithoutComparer_ReturnsAllItemsInInsertionOrder() {
            var collection = new TestEnumCollection();
            var item1 = new TestEnumItem("key1", "Name1", "ShortName1");
            var item2 = new TestEnumItem("key2", "Name2", "ShortName2");

            collection.Add(item1);
            collection.Add(item2);

            var items = collection.GetAll();
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual(item1, items[0]);
            Assert.AreEqual(item2, items[1]);
        }

        [TestMethod]
        public void GetByGroup_WithMatchingGroup_ReturnsItems() {
            var collection = new TestEnumCollection();
            var item1 = new TestEnumItem("key1", "Name1", "ShortName1") { Group = TestEnumGroup.Group1 };
            var item2 = new TestEnumItem("key2", "Name2", "ShortName2") { Group = TestEnumGroup.Group2 };

            collection.Add(item1);
            collection.Add(item2);

            var group1Items = collection.GetByGroup(TestEnumGroup.Group1);
            Assert.AreEqual(1, group1Items.Count());
            Assert.AreEqual(item1, group1Items.First());
        }

        [TestMethod]
        public void GetByGroup_WithNullGroup_ReturnsAllItems() {
            var collection = new TestEnumCollection();
            var item1 = new TestEnumItem("key1", "Name1", "ShortName1") { Group = TestEnumGroup.Group1 };
            var item2 = new TestEnumItem("key2", "Name2", "ShortName2") { Group = null }; // Include a null group.

            collection.Add(item1);
            collection.Add(item2);

            var allItems = collection.GetByGroup(null);
            Assert.AreEqual(2, allItems.Count());
            Assert.IsTrue(allItems.Contains(item1));
            Assert.IsTrue(allItems.Contains(item2));
        }

        [TestMethod]
        public void Search_ByName_CaseInsensitive_FindsMatches() {
            var collection = new TestEnumCollection();
            var item1 = new TestEnumItem("key1", "TestName", "ShortName1");
            var item2 = new TestEnumItem("key2", "AnotherTestName", "ShortName2");

            collection.Add(item1);
            collection.Add(item2);

            var results = collection.Search(i => i.Name, "testname");
            Assert.AreEqual(2, results.Count());
            Assert.IsTrue(results.Contains(item1));
            Assert.IsTrue(results.Contains(item2));
        }

        [TestMethod]
        public void FromKey_ValidKey_ReturnsCorrectItem() {
            var collection = new TestEnumCollection();
            var item = new TestEnumItem("key1", "Name1", "ShortName1");

            collection.Add(item);

            var result = collection.FromKey("key1");
            Assert.AreEqual(item, result);
        }

        [TestMethod]
        public void FromKey_InvalidKey_ThrowsException() {
            var collection = new TestEnumCollection();

            Assert.ThrowsException<InvalidOperationException>(() => collection.FromKey("nonexistent"));
        }

        [TestMethod]
        public void FromName_ValidName_ReturnsCorrectItem() {
            var collection = new TestEnumCollection();
            var item = new TestEnumItem("key1", "Name1", "ShortName1");

            collection.Add(item);

            var result = collection.FromName("Name1");
            Assert.AreEqual(item, result);
        }

        [TestMethod]
        public void FromName_InvalidName_ThrowsException() {
            var collection = new TestEnumCollection();

            Assert.ThrowsException<InvalidOperationException>(() => collection.FromName("nonexistent"));
        }
    }
}