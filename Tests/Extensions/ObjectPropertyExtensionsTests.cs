using BeeneticToolkit.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Tests.Extensions {

    [TestClass]
    public class ObjectPropertyExtensionsTests {

        #region Test Classes

        private class TestClass {
            public int IntProperty { get; set; }
            public double DoubleProperty { get; set; }
            public string StringProperty { get; set; } = "Test";
            public List<string> ListProperty { get; set; } = new() { "One", "Two" };

            public Dictionary<string, object> DictionaryProperty { get; set; } = new() {
                { "Key1", 1 },
                { "Key2", 2 }
            };
        }

        private class TestClassWithIgnoredProperties {

            [Obsolete]
            public int IgnoredProperty { get; set; }

            public int IncludedProperty { get; set; }
        }

        #endregion Test Classes

        #region Numeric Property Tests

        [TestMethod]
        public void SumNumericProperties_WithValidNumericProperties_ReturnsCorrectSum() {
            var obj = new TestClass { IntProperty = 10, DoubleProperty = 20.5 };
            var result = obj.SumNumericProperties();
            Assert.AreEqual(30.5, result);
        }

        [TestMethod]
        public void SumNumericProperties_WithNullObject_ThrowsArgumentNullException() {
            object obj = null!;
            Assert.ThrowsException<ArgumentNullException>(() => obj.SumNumericProperties());
        }

        [TestMethod]
        public void CountNumericProperties_WithValidNumericProperties_ReturnsCorrectCount() {
            var obj = new TestClass { IntProperty = 10, DoubleProperty = 20.5 };
            var result = obj.CountNumericProperties();
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void CountNonZeroNumericProperties_WithZeroAndNonZeroProperties_ReturnsCorrectCount() {
            var obj = new TestClass { IntProperty = 0, DoubleProperty = 20.5 };
            var result = obj.CountNonZeroNumericProperties();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CountNumericProperties_WithCustomFilter_ReturnsFilteredCount() {
            var obj = new TestClass { IntProperty = 10, DoubleProperty = 20.5 };
            var result = obj.CountNumericProperties(p => p.Name == nameof(TestClass.IntProperty));
            Assert.AreEqual(1, result);
        }

        #endregion Numeric Property Tests

        #region String Conversion Tests

        [TestMethod]
        public void ToPropertiesString_WithSimpleObject_ReturnsExpectedString() {
            var obj = new TestClass { IntProperty = 10, DoubleProperty = 20.5 };
            var result = obj.ToPropertiesString();
            var expected = "IntProperty: 10\nDoubleProperty: 20.5\nStringProperty: Test\nListProperty:\n  Item: One\n  Item: Two\nDictionaryProperty:\n  Key1: 1\n  Key2: 2";
            Assert.AreEqual(expected, result.Trim());
        }

        [TestMethod]
        public void ToPropertiesString_WithNullProperties_HandlesGracefully() {
            var obj = new TestClass { IntProperty = 10, DoubleProperty = 20.5, StringProperty = null! };
            var result = obj.ToPropertiesString();
            Assert.IsTrue(result.Contains("StringProperty:"));
        }

        [TestMethod]
        public void ToPropertiesString_WithNullValuesInDictionary_HandlesGracefully() {
            var obj = new {
                Dictionary = new Dictionary<string, object> {
                    { "Key1", "Value1" },
                    { "Key2", null }
                }
            };

            var result = obj.ToPropertiesString();
            Assert.IsTrue(result.Contains("Key1: Value1"));
            Assert.IsTrue(result.Contains("Key2: null"));
        }

        [TestMethod]
        public void ToPropertiesString_WithNullItemsInCollection_HandlesGracefully() {
            var obj = new {
                List = new List<object> { "Item1", null }
            };

            var result = obj.ToPropertiesString();
            Assert.IsTrue(result.Contains("Item: Item1"));
            Assert.IsTrue(result.Contains("Item: null"));
        }

#pragma warning disable CS0612 // Type or member is obsolete

        [TestMethod]
        public void ToPropertiesString_WithIgnoredProperties_ExcludesIgnoredProperties() {
            var obj = new TestClassWithIgnoredProperties { IgnoredProperty = 10, IncludedProperty = 20 };
            var result = obj.ToPropertiesString();
            Assert.IsFalse(result.Contains(nameof(TestClassWithIgnoredProperties.IgnoredProperty)));
            Assert.IsTrue(result.Contains(nameof(TestClassWithIgnoredProperties.IncludedProperty)));
        }

#pragma warning restore CS0612 // Type or member is obsolete

        [TestMethod]
        public void ToPropertiesString_WithNullObject_ThrowsArgumentNullException() {
            object obj = null!;
            Assert.ThrowsException<ArgumentNullException>(() => obj.ToPropertiesString());
        }

        [TestMethod]
        public void ToPropertiesString_WithNestedDictionaryValues_ReturnsFormattedString() {
            var obj = new TestClass {
                IntProperty = 0,
                DoubleProperty = 0,
                StringProperty = "Test",
                ListProperty = new List<string> { "One", "Two" },
                DictionaryProperty = new Dictionary<string, object> {
                    { "Key1", 1 },
                    { "Key2", new { NestedKey = "NestedValue" } },
                    { "Key3", null }
                }
            };

            var result = obj.ToPropertiesString();

            var expected = "IntProperty: 0\n" +
                           "DoubleProperty: 0\n" +
                           "StringProperty: Test\n" +
                           "ListProperty:\n" +
                           "  Item: One\n" +
                           "  Item: Two\n" +
                           "DictionaryProperty:\n" +
                           "  Key1: 1\n" +
                           "  Key2:\n" +
                           "    NestedKey: NestedValue\n" +
                           "  Key3: null";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToPropertiesString_WithMixedCollectionItems_ReturnsFormattedString() {
            var obj = new {
                Collection = new List<object> {
                    "SimpleItem",
                    new { ComplexKey = "ComplexValue" },
                    null
                }
            };

            var result = obj.ToPropertiesString();
            var expected = "Collection:\n" +
                           "  Item: SimpleItem\n" +
                           "  Item:\n" +
                           "    ComplexKey: ComplexValue\n" +
                           "  Item: null";

            Assert.AreEqual(expected, result);
        }

        #endregion String Conversion Tests
    }
}