using BeeneticToolkit.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Tests.Collections {

    [TestClass]
    public class LruCacheTests {

        [TestMethod]
        public void Constructor_RejectsNonPositiveCapacity() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new LruCache<string, int>(0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new LruCache<string, int>(-1));
        }

        [TestMethod]
        public void SetAndGet_RoundTrips() {
            var cache = new LruCache<string, int>(3);
            cache.Set("a", 1);
            cache["b"] = 2;

            Assert.AreEqual(1, cache["a"]);
            Assert.IsTrue(cache.TryGet("b", out int b));
            Assert.AreEqual(2, b);
            Assert.AreEqual(2, cache.Count);
        }

        [TestMethod]
        public void Indexer_Get_MissingKey_Throws() {
            var cache = new LruCache<string, int>(2);
            Assert.ThrowsException<KeyNotFoundException>(() => _ = cache["missing"]);
        }

        [TestMethod]
        public void EvictsLeastRecentlyUsed_WhenOverCapacity() {
            var cache = new LruCache<string, int>(2);
            cache.Set("a", 1);
            cache.Set("b", 2);
            cache.Set("c", 3); // a is the LRU → evicted

            Assert.IsFalse(cache.ContainsKey("a"));
            Assert.IsTrue(cache.ContainsKey("b"));
            Assert.IsTrue(cache.ContainsKey("c"));
            Assert.AreEqual(2, cache.Count);
        }

        [TestMethod]
        public void Get_BumpsRecency_ChangingEvictionVictim() {
            var cache = new LruCache<string, int>(2);
            cache.Set("a", 1);
            cache.Set("b", 2);

            cache.TryGet("a", out _);   // a becomes most-recently-used
            cache.Set("c", 3);          // now b is the LRU → evicted

            Assert.IsTrue(cache.ContainsKey("a"));
            Assert.IsFalse(cache.ContainsKey("b"));
            Assert.IsTrue(cache.ContainsKey("c"));
        }

        [TestMethod]
        public void Peek_DoesNotBumpRecency() {
            var cache = new LruCache<string, int>(2);
            cache.Set("a", 1);
            cache.Set("b", 2);

            Assert.IsTrue(cache.TryPeek("a", out int va));   // peek does NOT bump
            Assert.AreEqual(1, va);
            cache.Set("c", 3);                               // a still LRU → evicted

            Assert.IsFalse(cache.ContainsKey("a"));
            Assert.IsTrue(cache.ContainsKey("b"));
        }

        [TestMethod]
        public void ContainsKey_DoesNotBumpRecency() {
            var cache = new LruCache<string, int>(2);
            cache.Set("a", 1);
            cache.Set("b", 2);

            Assert.IsTrue(cache.ContainsKey("a"));           // must not bump
            cache.Set("c", 3);

            Assert.IsFalse(cache.ContainsKey("a"));          // a was still LRU
        }

        [TestMethod]
        public void Set_ExistingKey_UpdatesAndBumps_NoEviction() {
            var cache = new LruCache<string, int>(2);
            cache.Set("a", 1);
            cache.Set("b", 2);

            cache.Set("a", 11);          // update existing → a becomes MRU, no eviction
            Assert.AreEqual(11, cache["a"]);
            Assert.AreEqual(2, cache.Count);

            cache.Set("c", 3);           // b is LRU now → evicted
            Assert.IsFalse(cache.ContainsKey("b"));
            Assert.IsTrue(cache.ContainsKey("a"));
        }

        [TestMethod]
        public void GetOrAdd_InvokesFactoryOnlyOnMiss() {
            var cache = new LruCache<string, int>(2);
            int calls = 0;
            int Factory(string k) { calls++; return k.Length; }

            Assert.AreEqual(5, cache.GetOrAdd("apple", Factory));
            Assert.AreEqual(5, cache.GetOrAdd("apple", Factory)); // hit → no factory call
            Assert.AreEqual(1, calls);
        }

        [TestMethod]
        public void Evicted_EventFires_OnEvictionOnly() {
            var cache = new LruCache<string, int>(2);
            var evicted = new List<KeyValuePair<string, int>>();
            cache.Evicted += (k, v) => evicted.Add(new KeyValuePair<string, int>(k, v));

            cache.Set("a", 1);
            cache.Set("b", 2);
            cache.Set("c", 3);    // evicts a
            cache.Remove("b");    // must NOT raise Evicted
            cache.Clear();        // must NOT raise Evicted

            Assert.AreEqual(1, evicted.Count);
            Assert.AreEqual("a", evicted[0].Key);
            Assert.AreEqual(1, evicted[0].Value);
        }

        [TestMethod]
        public void Remove_And_Clear_Work() {
            var cache = new LruCache<string, int>(3);
            cache.Set("a", 1);
            cache.Set("b", 2);

            Assert.IsTrue(cache.Remove("a"));
            Assert.IsFalse(cache.Remove("a"));
            Assert.AreEqual(1, cache.Count);

            cache.Clear();
            Assert.AreEqual(0, cache.Count);
        }

        [TestMethod]
        public void Keys_AreOrderedMostToLeastRecentlyUsed() {
            var cache = new LruCache<string, int>(3);
            cache.Set("a", 1);
            cache.Set("b", 2);
            cache.Set("c", 3);
            cache.TryGet("a", out _);   // a → MRU

            CollectionAssert.AreEqual(new[] { "a", "c", "b" }, cache.Keys.ToArray());
        }

        [TestMethod]
        public void CustomComparer_IsHonored() {
            var cache = new LruCache<string, int>(2, StringComparer.OrdinalIgnoreCase);
            cache.Set("Key", 1);

            Assert.IsTrue(cache.TryGet("KEY", out int v));
            Assert.AreEqual(1, v);
        }

        [TestMethod]
        public void Set_NullKey_Throws() {
            var cache = new LruCache<string, int>(2);
            Assert.ThrowsException<ArgumentNullException>(() => cache.Set(null!, 1));
        }
    }
}
