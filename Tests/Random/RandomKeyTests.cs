using BeeneticToolkit.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeeneticToolkit.Tests.Random {

    [TestClass]
    public class RandomKeyTests {

        #region Construction

        [TestMethod]
        public void Ctor_StoresValue() {
            Assert.AreEqual("loot", new RandomKey("loot").Value);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("   ")]
        public void Ctor_NullOrWhitespace_Throws(string value) {
            Assert.ThrowsException<ArgumentException>(() => new RandomKey(value));
        }

        #endregion Construction

        #region IsEmpty

        [TestMethod]
        public void IsEmpty_DefaultStruct_True() {
            RandomKey key = default;
            Assert.IsTrue(key.IsEmpty);
        }

        [TestMethod]
        public void IsEmpty_WithValue_False() {
            Assert.IsFalse(new RandomKey("loot").IsEmpty);
        }

        #endregion IsEmpty

        #region Equality

        [TestMethod]
        public void Equality_SameValue_AreEqualAndShareHashCode() {
            var a = new RandomKey("loot");
            var b = new RandomKey("loot");

            Assert.IsTrue(a == b);
            Assert.IsFalse(a != b);
            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(a.Equals((object)b));
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [TestMethod]
        public void Equality_IsOrdinalAndCaseSensitive() {
            Assert.AreNotEqual(new RandomKey("Loot"), new RandomKey("loot"));
            Assert.IsTrue(new RandomKey("Loot") != new RandomKey("loot"));
        }

        [TestMethod]
        public void Equality_DifferentValue_NotEqual() {
            Assert.IsFalse(new RandomKey("a") == new RandomKey("b"));
            Assert.IsTrue(new RandomKey("a") != new RandomKey("b"));
        }

        [TestMethod]
        public void Equals_Object_NonRandomKey_False() {
            Assert.IsFalse(new RandomKey("loot").Equals("loot"));
            Assert.IsFalse(new RandomKey("loot").Equals(null));
        }

        #endregion Equality

        #region Conversions

        [TestMethod]
        public void ImplicitToString_ReturnsValue() {
            string value = new RandomKey("loot");
            Assert.AreEqual("loot", value);
        }

        [TestMethod]
        public void ExplicitFromString_CreatesKey() {
            var key = (RandomKey)"loot";
            Assert.AreEqual("loot", key.Value);
        }

        [TestMethod]
        public void ExplicitFromString_Invalid_Throws() {
            Assert.ThrowsException<ArgumentException>(() => _ = (RandomKey)"   ");
        }

        [TestMethod]
        public void ToString_DefaultStruct_ReturnsEmptyString() {
            RandomKey key = default;
            Assert.AreEqual(string.Empty, key.ToString());
        }

        [TestMethod]
        public void ToString_WithValue_ReturnsValue() {
            Assert.AreEqual("loot", new RandomKey("loot").ToString());
        }

        #endregion Conversions
    }
}
