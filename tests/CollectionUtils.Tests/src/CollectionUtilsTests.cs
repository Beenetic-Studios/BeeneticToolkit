using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.CollectionUtils.Tests {

    [TestClass]
    public class CollectionUtilsTests {

        [TestMethod]
        public void IsNullOrEmpty_WithNullCollection_ReturnsTrue() {
            IEnumerable<int> collection = null;
            bool result = CollectionUtils.IsNullOrEmpty(collection);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNullOrEmpty_WithEmptyCollection_ReturnsTrue() {
            IEnumerable<int> collection = new List<int>();
            bool result = CollectionUtils.IsNullOrEmpty(collection);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNullOrEmpty_WithNonEmptyCollection_ReturnsFalse() {
            IEnumerable<int> collection = new List<int> { 1, 2, 3 };
            bool result = CollectionUtils.IsNullOrEmpty(collection);
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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InitializeArray_SizeLessThanOrEqualToZero_ThrowsArgumentOutOfRangeException() {
            CollectionUtils.InitializeArray<int>(0);
        }
    }
}