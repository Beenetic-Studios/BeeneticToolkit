using BeeneticToolkit.Collections.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Tests.Collections.Utilities {

    [TestClass]
    public class CollectionUtilsTests {

        [TestMethod]
        public void IsNullOrEmpty_WithNullCollection_ReturnsTrue() {
            IEnumerable<int> collection = null;
            bool result = collection.IsNullOrEmpty();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNullOrEmpty_WithEmptyCollection_ReturnsTrue() {
            IEnumerable<int> collection = new List<int>();
            bool result = collection.IsNullOrEmpty();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNullOrEmpty_WithNonEmptyCollection_ReturnsFalse() {
            IEnumerable<int> collection = new List<int> { 1, 2, 3 };
            bool result = collection.IsNullOrEmpty();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InitializeArray_PositiveSizeWithDefaultValue_ReturnsInitializedArray() {
            var result = CollectionUtils.InitializeArray<int>(3);
            Assert.AreEqual(3, result.Length);
            Assert.IsTrue(result.All(item => item.Equals(default)));
        }

        [TestMethod]
        public void InitializeArray_PositiveSizeWithSpecificValue_ReturnsInitializedArray() {
            var result = CollectionUtils.InitializeArray(3, 42);
            Assert.AreEqual(3, result.Length);
            Assert.IsTrue(result.All(item => item == 42));
        }

        [TestMethod]
        public void InitializeArray_SizeLessThanOrEqualToZero_ThrowsArgumentOutOfRangeException() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => CollectionUtils.InitializeArray<int>(0));
        }
    }
}