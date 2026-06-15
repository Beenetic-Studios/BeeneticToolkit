using BeeneticToolkit.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SCG = System.Collections.Generic;

namespace BeeneticToolkit.Tests.Collections {

    // System.Collections.Generic is aliased (SCG) so the unqualified PriorityQueue resolves to ours, not the
    // BCL one that exists on the net8 test runtime.
    [TestClass]
    public class PriorityQueueTests {

        [TestMethod]
        public void Dequeue_ReturnsElementsInPriorityOrder() {
            var pq = new PriorityQueue<string, int>();
            pq.Enqueue("medium", 5);
            pq.Enqueue("low", 1);
            pq.Enqueue("high", 9);
            pq.Enqueue("lowest", 0);

            Assert.AreEqual("lowest", pq.Dequeue());
            Assert.AreEqual("low", pq.Dequeue());
            Assert.AreEqual("medium", pq.Dequeue());
            Assert.AreEqual("high", pq.Dequeue());
            Assert.AreEqual(0, pq.Count);
        }

        [TestMethod]
        public void Heap_StaysOrdered_OverManyItems() {
            var pq = new PriorityQueue<int, int>();
            // Insert 0..99 in a scrambled order.
            int p = 0;
            for (int i = 0; i < 100; i++) {
                p = (p + 37) % 100; // deterministic pseudo-shuffle over distinct values
                pq.Enqueue(p, p);
            }

            int previous = int.MinValue;
            int drained = 0;
            while (pq.TryDequeue(out _, out int priority)) {
                Assert.IsTrue(priority >= previous, $"Out of order: {priority} after {previous}");
                previous = priority;
                drained++;
            }
            Assert.AreEqual(100, drained);
        }

        [TestMethod]
        public void Peek_ReturnsMinWithoutRemoving() {
            var pq = new PriorityQueue<string, int>();
            pq.Enqueue("a", 3);
            pq.Enqueue("b", 1);

            Assert.AreEqual("b", pq.Peek());
            Assert.IsTrue(pq.TryPeek(out string e, out int pr));
            Assert.AreEqual("b", e);
            Assert.AreEqual(1, pr);
            Assert.AreEqual(2, pq.Count); // unchanged
        }

        [TestMethod]
        public void Empty_PeekAndDequeue_Behave() {
            var pq = new PriorityQueue<string, int>();
            Assert.ThrowsException<InvalidOperationException>(() => pq.Peek());
            Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
            Assert.IsFalse(pq.TryDequeue(out _, out _));
            Assert.IsFalse(pq.TryPeek(out _, out _));
        }

        [TestMethod]
        public void EnqueueDequeue_ReturnsNewElement_WhenItIsTheSmallest() {
            var pq = new PriorityQueue<string, int>();
            pq.Enqueue("existing", 5);

            string result = pq.EnqueueDequeue("smaller", 3); // 3 < 5 → returned immediately, heap untouched

            Assert.AreEqual("smaller", result);
            Assert.AreEqual(1, pq.Count);
            Assert.AreEqual("existing", pq.Peek());
        }

        [TestMethod]
        public void EnqueueDequeue_ReturnsOldMin_WhenNewIsLarger() {
            var pq = new PriorityQueue<string, int>();
            pq.Enqueue("existing", 5);

            string result = pq.EnqueueDequeue("larger", 10); // 10 > 5 → pops 5, inserts larger

            Assert.AreEqual("existing", result);
            Assert.AreEqual(1, pq.Count);
            Assert.AreEqual("larger", pq.Peek());
        }

        [TestMethod]
        public void EnqueueDequeue_OnEmpty_ReturnsArgument() {
            var pq = new PriorityQueue<string, int>();
            Assert.AreEqual("x", pq.EnqueueDequeue("x", 1));
            Assert.AreEqual(0, pq.Count);
        }

        [TestMethod]
        public void CustomComparer_GivesMaxHeapBehavior() {
            // Reverse comparer → highest priority dequeued first.
            var pq = new PriorityQueue<string, int>(SCG.Comparer<int>.Create((a, b) => b.CompareTo(a)));
            pq.Enqueue("low", 1);
            pq.Enqueue("high", 9);
            pq.Enqueue("mid", 5);

            Assert.AreEqual("high", pq.Dequeue());
            Assert.AreEqual("mid", pq.Dequeue());
            Assert.AreEqual("low", pq.Dequeue());
        }

        [TestMethod]
        public void Comparer_DefaultsWhenNotProvided() {
            var pq = new PriorityQueue<int, int>();
            Assert.AreSame(SCG.Comparer<int>.Default, pq.Comparer);
        }

        [TestMethod]
        public void Clear_EmptiesQueue() {
            var pq = new PriorityQueue<int, int>(8);
            pq.Enqueue(1, 1);
            pq.Enqueue(2, 2);
            pq.Clear();

            Assert.AreEqual(0, pq.Count);
            Assert.IsFalse(pq.TryPeek(out _, out _));
        }

        [TestMethod]
        public void Constructor_RejectsNegativeCapacity() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new PriorityQueue<int, int>(-1));
        }
    }
}
