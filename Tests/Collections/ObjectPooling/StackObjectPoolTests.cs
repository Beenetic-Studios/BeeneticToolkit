using BeeneticToolkit.Collections.ObjectPooling;
using BeeneticToolkit.Collections.ObjectPooling.Policies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace BeeneticToolkit.Tests.Collections.ObjectPooling {

    [TestClass]
    public class StackObjectPoolTests {

        private class StringBuilderPolicy : PooledObjectPolicy<StringBuilder> {

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
        public void GetObjectFromPoolTest() {
            var pool = new StackObjectPool<StringBuilder>(new StringBuilderPolicy(), initialCapacity: 1);
            var sb = pool.Get();

            Assert.IsNotNull(sb, "Retrieved object should not be null.");
            Assert.AreEqual(0, pool.Count, "Pool count should decrease after retrieving an object.");
        }

        [TestMethod]
        public void ReturnObjectToPoolTest() {
            var pool = new StackObjectPool<StringBuilder>(new StringBuilderPolicy(), initialCapacity: 0);
            var sb = new StringBuilder("Test");

            pool.Return(sb);

            Assert.AreEqual(1, pool.Count, "Pool count should increase after returning an object.");
            Assert.AreEqual(0, sb.Length, "Returned object should be reset.");
        }

        [TestMethod]
        public void ClearPoolTest() {
            var pool = new StackObjectPool<StringBuilder>(new StringBuilderPolicy(), initialCapacity: 3);
            pool.Clear();

            Assert.AreEqual(0, pool.Count, "Pool should be empty after clearing.");
        }

        [TestMethod]
        public void RentReturnsObjectToPoolOnDispose() {
            var pool = new StackObjectPool<StringBuilder>(new StringBuilderPolicy(), initialCapacity: 1);

            Assert.AreEqual(1, pool.Count);
            using (var scope = pool.Rent(out var rented)) {
                Assert.IsNotNull(rented);
                Assert.AreSame(rented, scope.Value);
                Assert.AreEqual(0, pool.Count, "Rented object should be taken out of the pool.");
            }

            Assert.AreEqual(1, pool.Count, "Disposing the scope should return the object to the pool.");
        }

        [TestMethod]
        public void RespectMaxSizeTest() {
            var pool = new StackObjectPool<StringBuilder>(new StringBuilderPolicy(), maxSize: 1);
            var sb1 = new StringBuilder("One");
            var sb2 = new StringBuilder("Two");

            pool.Return(sb1);
            pool.Return(sb2);

            Assert.AreEqual(1, pool.Count, "Pool count should not exceed max size.");
        }

        [TestMethod]
        public void DynamicGrowthEnabledTest() {
            var pool = new StackObjectPool<StringBuilder>(new StringBuilderPolicy(), isDynamic: true);

            var sb1 = pool.Get();
            var sb2 = pool.Get();

            Assert.AreNotSame(sb1, sb2, "Dynamic growth should create new objects when the pool is empty.");
        }

        [TestMethod]
        public void DisposeObjectsOnClearTest() {
            var pool = new StackObjectPool<DisposableObject>(new DisposableObjectPolicy(), initialCapacity: 2);

            pool.Clear();

            Assert.AreEqual(0, pool.Count, "Pool should be empty after clearing.");
        }

        private class DisposableObject : IDisposable {
            public bool IsDisposed { get; set; }

            public void Dispose() {
                IsDisposed = true;
            }
        }

        private class DisposableObjectPolicy : PooledObjectPolicy<DisposableObject> {

            public override DisposableObject Create() {
                return new DisposableObject();
            }

            public override void Reset(DisposableObject obj) {
                obj.IsDisposed = false; // Reset disposed state.
            }

            public override bool Validate(DisposableObject obj) {
                return !obj.IsDisposed; // Valid if not disposed.
            }
        }
    }
}