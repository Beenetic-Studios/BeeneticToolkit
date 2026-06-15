using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Collections {

    /// <summary>
    /// A min-heap priority queue: each element is enqueued with a priority, and the element with the
    /// <i>lowest</i> priority (by the comparer) is always dequeued first. Mirrors the API of .NET 6+'s
    /// <c>System.Collections.Generic.PriorityQueue&lt;TElement, TPriority&gt;</c>, which is absent on
    /// <c>netstandard2.1</c> / Unity — useful for event scheduling, cooldown/turn ordering, and pathfinding.
    /// </summary>
    /// <remarks>
    /// Backed by a growable array heap. Not thread-safe. Elements with equal priority are not dequeued in any
    /// guaranteed order (the heap is not stable).
    /// <para>
    /// On .NET 6+ the BCL also defines <c>PriorityQueue</c>; if you import both namespaces, alias this one
    /// (<c>using BPQ = BeeneticToolkit.Collections.PriorityQueue&lt;,&gt;</c>) or fully qualify to disambiguate.
    /// </para>
    /// </remarks>
    /// <typeparam name="TElement">The type of the stored elements.</typeparam>
    /// <typeparam name="TPriority">The type used to prioritize elements.</typeparam>
    public sealed class PriorityQueue<TElement, TPriority> {

        private (TElement Element, TPriority Priority)[] _nodes;
        private int _size;
        private readonly IComparer<TPriority> _comparer;

        /// <summary>Creates an empty priority queue using the default comparer for <typeparamref name="TPriority"/>.</summary>
        public PriorityQueue() : this(0, null) { }

        /// <summary>Creates an empty priority queue using the given comparer (or the default if null).</summary>
        /// <param name="comparer">The comparer that orders priorities, or null for the default.</param>
        public PriorityQueue(IComparer<TPriority>? comparer) : this(0, comparer) { }

        /// <summary>Creates an empty priority queue with the given initial capacity and comparer.</summary>
        /// <param name="initialCapacity">The initial backing-array capacity. Must be non-negative.</param>
        /// <param name="comparer">The comparer that orders priorities, or null for the default.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="initialCapacity"/> is negative.</exception>
        public PriorityQueue(int initialCapacity, IComparer<TPriority>? comparer = null) {
            if (initialCapacity < 0)
                throw new ArgumentOutOfRangeException(nameof(initialCapacity), "Initial capacity must be non-negative.");

            _nodes = initialCapacity == 0
                ? Array.Empty<(TElement, TPriority)>()
                : new (TElement, TPriority)[initialCapacity];
            _comparer = comparer ?? Comparer<TPriority>.Default;
        }

        /// <summary>Gets the number of elements in the queue.</summary>
        public int Count => _size;

        /// <summary>Gets the comparer used to order priorities.</summary>
        public IComparer<TPriority> Comparer => _comparer;

        /// <summary>Adds an element with the given priority.</summary>
        /// <param name="element">The element to add.</param>
        /// <param name="priority">The priority that orders it (lower is dequeued first).</param>
        public void Enqueue(TElement element, TPriority priority) {
            if (_size == _nodes.Length)
                Grow(_size + 1);

            SiftUp(_size, (element, priority));
            _size++;
        }

        /// <summary>Returns the lowest-priority element without removing it.</summary>
        /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
        public TElement Peek() =>
            _size == 0 ? throw new InvalidOperationException("The priority queue is empty.") : _nodes[0].Element;

        /// <summary>Returns the lowest-priority element and its priority without removing it.</summary>
        /// <returns><c>true</c> if an element was available; otherwise <c>false</c>.</returns>
        public bool TryPeek(out TElement element, out TPriority priority) {
            if (_size == 0) {
                element = default!;
                priority = default!;
                return false;
            }

            (element, priority) = _nodes[0];
            return true;
        }

        /// <summary>Removes and returns the lowest-priority element.</summary>
        /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
        public TElement Dequeue() {
            if (_size == 0)
                throw new InvalidOperationException("The priority queue is empty.");

            TElement element = _nodes[0].Element;
            RemoveRoot();
            return element;
        }

        /// <summary>Removes the lowest-priority element and reports it with its priority.</summary>
        /// <returns><c>true</c> if an element was removed; otherwise <c>false</c>.</returns>
        public bool TryDequeue(out TElement element, out TPriority priority) {
            if (_size == 0) {
                element = default!;
                priority = default!;
                return false;
            }

            (element, priority) = _nodes[0];
            RemoveRoot();
            return true;
        }

        /// <summary>
        /// Adds an element, then immediately removes and returns the lowest-priority element — more efficient than
        /// an <see cref="Enqueue"/> followed by a <see cref="Dequeue"/>. If the new element has the lowest
        /// priority (or the queue is empty), it is returned without touching the heap.
        /// </summary>
        public TElement EnqueueDequeue(TElement element, TPriority priority) {
            if (_size != 0) {
                (TElement Element, TPriority Priority) root = _nodes[0];
                if (_comparer.Compare(priority, root.Priority) > 0) {
                    SiftDown(0, (element, priority)); // new element outranks the current min; replace the root
                    return root.Element;
                }
            }

            return element;
        }

        /// <summary>Removes every element from the queue.</summary>
        public void Clear() {
            if (_size != 0)
                Array.Clear(_nodes, 0, _size); // release references

            _size = 0;
        }

        private void RemoveRoot() {
            int lastIndex = --_size;
            if (lastIndex > 0) {
                (TElement, TPriority) last = _nodes[lastIndex];
                SiftDown(0, last);
            }

            _nodes[lastIndex] = default; // release references
        }

        private void Grow(int minCapacity) {
            int newCapacity = _nodes.Length == 0 ? 4 : _nodes.Length * 2;
            if (newCapacity < minCapacity)
                newCapacity = minCapacity;

            Array.Resize(ref _nodes, newCapacity);
        }

        private void SiftUp(int index, (TElement Element, TPriority Priority) node) {
            while (index > 0) {
                int parent = (index - 1) >> 1;
                if (_comparer.Compare(node.Priority, _nodes[parent].Priority) >= 0)
                    break;

                _nodes[index] = _nodes[parent];
                index = parent;
            }

            _nodes[index] = node;
        }

        private void SiftDown(int index, (TElement Element, TPriority Priority) node) {
            int half = _size >> 1;
            while (index < half) {
                int child = (index << 1) + 1;
                int right = child + 1;
                if (right < _size && _comparer.Compare(_nodes[right].Priority, _nodes[child].Priority) < 0)
                    child = right;

                if (_comparer.Compare(_nodes[child].Priority, node.Priority) >= 0)
                    break;

                _nodes[index] = _nodes[child];
                index = child;
            }

            _nodes[index] = node;
        }
    }
}
