using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

#nullable enable

namespace BeeneticToolkit.Collections.Enums.Tests {

    public enum TestEnumGroup { Group1, Group2, Group3 }

    [TestClass]
    public class EnumItemTests {

        private class TestEnumItem : EnumItem<TestEnumGroup> {

            public TestEnumItem(string key, string name, string shortName, string? description = null, int? displayOrder = null, bool? isActive = null, TestEnumGroup? group = null)
                : base(key, name, shortName, description, displayOrder, isActive, group) { }
        }

        [TestMethod]
        public void Constructor_WithValidArguments_SetsPropertiesCorrectly() {
            var item = new TestEnumItem("key1", "Name1", "ShortName1", "Description1", 1, true, TestEnumGroup.Group1);

            Assert.AreEqual("key1", item.Key);
            Assert.AreEqual("Name1", item.Name);
            Assert.AreEqual("ShortName1", item.ShortName);
            Assert.AreEqual("Description1", item.Description);
            Assert.AreEqual(1, item.DisplayOrder);
            Assert.IsTrue(item.IsActive!.Value);
            Assert.AreEqual(TestEnumGroup.Group1, item.Group);
        }

        [TestMethod]
        public void Constructor_WithNullKey_ThrowsException() {
            Assert.ThrowsException<ArgumentException>(() => new TestEnumItem(null!, "Name", "ShortName"));
        }

        [TestMethod]
        public void Constructor_WithEmptyKey_ThrowsException() {
            Assert.ThrowsException<ArgumentException>(() => new TestEnumItem(string.Empty, "Name", "ShortName"));
        }

        [TestMethod]
        public void Constructor_WithNullName_ThrowsException() {
            Assert.ThrowsException<ArgumentException>(() => new TestEnumItem("key", null!, "ShortName"));
        }

        [TestMethod]
        public void Constructor_WithEmptyName_ThrowsException() {
            Assert.ThrowsException<ArgumentException>(() => new TestEnumItem("key", string.Empty, "ShortName"));
        }

        [TestMethod]
        public void Equals_SameKey_ReturnsTrue() {
            var item1 = new TestEnumItem("key", "Name1", "ShortName1");
            var item2 = new TestEnumItem("key", "Name2", "ShortName2");

            Assert.IsTrue(item1.Equals(item2));
        }

        [TestMethod]
        public void Equals_DifferentKey_ReturnsFalse() {
            var item1 = new TestEnumItem("key1", "Name1", "ShortName1");
            var item2 = new TestEnumItem("key2", "Name2", "ShortName2");

            Assert.IsFalse(item1.Equals(item2));
        }

        [TestMethod]
        public void GetHashCode_SameKey_ReturnsSameHashCode() {
            var item1 = new TestEnumItem("key", "Name1", "ShortName1");
            var item2 = new TestEnumItem("key", "Name2", "ShortName2");

            Assert.AreEqual(item1.GetHashCode(), item2.GetHashCode());
        }

        [TestMethod]
        public void CompareTo_SameKey_ReturnsZero() {
            var item1 = new TestEnumItem("key", "Name1", "ShortName1");
            var item2 = new TestEnumItem("key", "Name2", "ShortName2");

            Assert.AreEqual(0, item1.CompareTo(item2));
        }

        [TestMethod]
        public void CompareTo_DifferentKeys_ReturnsNegativeForAlphabeticalOrder() {
            var item1 = new TestEnumItem("keyA", "Name1", "ShortName1");
            var item2 = new TestEnumItem("keyB", "Name2", "ShortName2");

            Assert.IsTrue(item1.CompareTo(item2) < 0);
        }

        [TestMethod]
        public void CompareTo_DifferentKeys_ReturnsPositiveForReverseAlphabeticalOrder() {
            var item1 = new TestEnumItem("keyB", "Name1", "ShortName1");
            var item2 = new TestEnumItem("keyA", "Name2", "ShortName2");

            Assert.IsTrue(item1.CompareTo(item2) > 0);
        }

        [TestMethod]
        public void ToString_ReturnsName() {
            var item = new TestEnumItem("key1", "Name1", "ShortName1");

            Assert.AreEqual("Name1", item.ToString());
        }
    }
}