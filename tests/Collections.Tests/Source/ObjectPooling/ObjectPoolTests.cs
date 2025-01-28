using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace BeeneticToolkit.Collections.ObjectPooling.Tests {

    [TestClass]
    public class ObjectPoolTests {

        private class TestPolicy : PooledObjectPolicy<StringBuilder> {

            public override StringBuilder Create() {
                return new StringBuilder();
            }

            public override void Reset(StringBuilder obj) {
                obj.Clear();
            }

            public override bool Validate(StringBuilder obj) {
                return true; // Always valid for simplicity.
            }
        }

        [TestMethod]
        public void GetTest() {
            var pool = new StackObjectPool<StringBuilder>(new TestPolicy(), initialCapacity: 2);

            var sb1 = pool.Get();
            var sb2 = pool.Get();

            Assert.IsNotNull(sb1, "Retrieved object should not be null.");
            Assert.IsNotNull(sb2, "Retrieved object should not be null.");
            Assert.AreEqual(0, pool.Count, "Pool should be empty after retrieving all objects.");

            sb1.Append("Hello");
            Assert.AreEqual("Hello", sb1.ToString(), "StringBuilder should work as expected.");
        }

        [TestMethod]
        public void ReleaseTest() {
            var pool = new StackObjectPool<StringBuilder>(new TestPolicy(), initialCapacity: 0);

            var sb = new StringBuilder("Test");
            pool.Return(sb);

            Assert.AreEqual(1, pool.Count, "Pool should contain one object after release.");
            Assert.AreEqual(0, sb.Length, "Released StringBuilder should be reset.");
        }

        [TestMethod]
        public void ClearTest() {
            var pool = new StackObjectPool<StringBuilder>(new TestPolicy(), initialCapacity: 3);
            pool.Clear();

            Assert.AreEqual(0, pool.Count, "Pool should be empty after clearing.");
        }

        [TestMethod]
        public void MaxSizeTest() {
            var pool = new StackObjectPool<StringBuilder>(new TestPolicy(), maxSize: 1);

            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder();

            pool.Return(sb1);
            pool.Return(sb2);

            Assert.AreEqual(1, pool.Count, "Pool count should not exceed max size.");
        }

        [TestMethod]
        public void DynamicGrowthTest() {
            var pool = new StackObjectPool<StringBuilder>(new TestPolicy(), isDynamic: true, maxSize: 0);

            var sb1 = pool.Get();
            var sb2 = pool.Get();

            Assert.AreNotSame(sb1, sb2, "Dynamic growth should create new objects when pool is empty.");
        }

        [TestMethod]
        public void ValidateTest() {
            var invalidPolicy = new TestPolicy();
            var pool = new StackObjectPool<StringBuilder>(invalidPolicy);

            var sb = pool.Get();
            Assert.IsTrue(invalidPolicy.Validate(sb), "Object from the pool should always be valid.");
        }
    }
}