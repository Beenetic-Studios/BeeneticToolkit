using BeeneticToolkit.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Tests.Collections {

    [TestClass]
    public class RingBufferTests {

        [TestMethod]
        public void Constructor_RejectsNonPositiveCapacity() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new RingBuffer<int>(0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new RingBuffer<int>(-1));
        }

        [TestMethod]
        public void Add_BelowCapacity_KeepsEverything() {
            var buffer = new RingBuffer<int>(3);
            buffer.Add(1);
            buffer.Add(2);

            Assert.AreEqual(2, buffer.Count);
            Assert.IsFalse(buffer.IsFull);
            CollectionAssert.AreEqual(new[] { 1, 2 }, buffer.ToArray());
        }

        [TestMethod]
        public void Add_WhenFull_OverwritesOldest() {
            var buffer = new RingBuffer<int>(3);
            buffer.Add(1);
            buffer.Add(2);
            buffer.Add(3);
            Assert.IsTrue(buffer.IsFull);

            buffer.Add(4); // drops 1
            buffer.Add(5); // drops 2

            Assert.AreEqual(3, buffer.Count);
            CollectionAssert.AreEqual(new[] { 3, 4, 5 }, buffer.ToArray());
            Assert.AreEqual(3, buffer.PeekOldest());
            Assert.AreEqual(5, buffer.PeekNewest());
        }

        [TestMethod]
        public void TryAdd_RejectsWhenFull() {
            var buffer = new RingBuffer<int>(2);
            Assert.IsTrue(buffer.TryAdd(1));
            Assert.IsTrue(buffer.TryAdd(2));
            Assert.IsFalse(buffer.TryAdd(3));               // full: rejected, not overwritten

            CollectionAssert.AreEqual(new[] { 1, 2 }, buffer.ToArray());
        }

        [TestMethod]
        public void RemoveOldest_IsFifo() {
            var buffer = new RingBuffer<int>(3);
            buffer.Add(1);
            buffer.Add(2);
            buffer.Add(3);

            Assert.AreEqual(1, buffer.RemoveOldest());
            Assert.AreEqual(2, buffer.RemoveOldest());
            Assert.AreEqual(1, buffer.Count);
            Assert.AreEqual(3, buffer.PeekOldest());
        }

        [TestMethod]
        public void RemoveOldest_OnEmpty_Throws() {
            var buffer = new RingBuffer<int>(2);
            Assert.ThrowsException<InvalidOperationException>(() => buffer.RemoveOldest());
            Assert.IsFalse(buffer.TryRemoveOldest(out _));
        }

        [TestMethod]
        public void Indexer_IsOldestToNewest_AndBoundsChecked() {
            var buffer = new RingBuffer<string>(3);
            buffer.Add("a");
            buffer.Add("b");
            buffer.Add("c");
            buffer.Add("d"); // wraps; now c, d... wait: drops a -> b, c, d

            Assert.AreEqual("b", buffer[0]);
            Assert.AreEqual("c", buffer[1]);
            Assert.AreEqual("d", buffer[2]);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = buffer[3]);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = buffer[-1]);
        }

        [TestMethod]
        public void Enumeration_IsOldestToNewest_AfterWrap() {
            var buffer = new RingBuffer<int>(3);
            for (int i = 1; i <= 5; i++)
                buffer.Add(i); // ends holding 3,4,5

            CollectionAssert.AreEqual(new[] { 3, 4, 5 }, buffer.ToList());
        }

        [TestMethod]
        public void Enumeration_IsAllocationFreeStructEnumerator() {
            var buffer = new RingBuffer<int>(2);
            buffer.Add(1);
            buffer.Add(2);

            // The public GetEnumerator returns a value type (struct), so foreach does not box.
            Assert.IsTrue(typeof(RingBuffer<int>.Enumerator).IsValueType);

            int sum = 0;
            foreach (int v in buffer)
                sum += v;
            Assert.AreEqual(3, sum);
        }

        [TestMethod]
        public void Enumeration_AfterModification_Throws() {
            var buffer = new RingBuffer<int>(3);
            buffer.Add(1);
            buffer.Add(2);

            Assert.ThrowsException<InvalidOperationException>(() => {
                foreach (int _ in buffer)
                    buffer.Add(3); // mutates mid-enumeration
            });
        }

        [TestMethod]
        public void Clear_ResetsBuffer() {
            var buffer = new RingBuffer<int>(3);
            buffer.Add(1);
            buffer.Add(2);
            buffer.Clear();

            Assert.AreEqual(0, buffer.Count);
            Assert.IsTrue(buffer.IsEmpty);
            Assert.IsFalse(buffer.TryPeekOldest(out _));
        }

        [TestMethod]
        public void Peek_DoesNotRemove() {
            var buffer = new RingBuffer<int>(2);
            buffer.Add(7);

            Assert.IsTrue(buffer.TryPeekOldest(out int oldest));
            Assert.IsTrue(buffer.TryPeekNewest(out int newest));
            Assert.AreEqual(7, oldest);
            Assert.AreEqual(7, newest);
            Assert.AreEqual(1, buffer.Count);
        }
    }
}
