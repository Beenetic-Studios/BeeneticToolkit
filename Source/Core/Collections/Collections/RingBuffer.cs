using System;
using System.Collections;
using System.Collections.Generic;

namespace BeeneticToolkit.Collections {

    /// <summary>
    /// A fixed-capacity circular FIFO buffer. Once full, adding a new item overwrites and drops the oldest one,
    /// making it ideal for rolling windows — input/command history, recent telemetry or frame-time samples,
    /// netcode snapshots, "last N events" logs, and similar.
    /// </summary>
    /// <remarks>
    /// Backed by a single array sized at construction, so it allocates nothing while in use (enumeration via
    /// <c>foreach</c> is allocation-free thanks to the struct enumerator). Not thread-safe.
    /// </remarks>
    /// <typeparam name="T">The element type.</typeparam>
    public sealed class RingBuffer<T> : IReadOnlyCollection<T> {

        private readonly T[] _buffer;
        private int _head;   // index of the oldest element
        private int _count;
        private int _version;

        /// <summary>Creates a ring buffer with the given fixed capacity.</summary>
        /// <param name="capacity">The maximum number of elements. Must be greater than zero.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="capacity"/> is not greater than zero.</exception>
        public RingBuffer(int capacity) {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than zero.");

            _buffer = new T[capacity];
        }

        /// <summary>Gets the maximum number of elements the buffer can hold.</summary>
        public int Capacity => _buffer.Length;

        /// <summary>Gets the number of elements currently in the buffer.</summary>
        public int Count => _count;

        /// <summary>Gets a value indicating whether the buffer is empty.</summary>
        public bool IsEmpty => _count == 0;

        /// <summary>Gets a value indicating whether the buffer is at capacity.</summary>
        public bool IsFull => _count == _buffer.Length;

        /// <summary>Gets the element at the given index, where <c>0</c> is the oldest and <c>Count - 1</c> is the newest.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="index"/> is outside <c>[0, Count)</c>.</exception>
        public T this[int index] {
            get {
                if ((uint)index >= (uint)_count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                return _buffer[(_head + index) % _buffer.Length];
            }
        }

        /// <summary>
        /// Adds an item to the buffer. If the buffer is full, the oldest item is overwritten and dropped.
        /// </summary>
        /// <param name="item">The item to add (becomes the newest element).</param>
        public void Add(T item) {
            int index = (_head + _count) % _buffer.Length;
            _buffer[index] = item;

            if (_count == _buffer.Length)
                _head = (_head + 1) % _buffer.Length; // was full: we just overwrote the oldest
            else
                _count++;

            _version++;
        }

        /// <summary>
        /// Adds an item only if the buffer is not full, leaving existing items untouched when it is.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <returns><c>true</c> if the item was added; <c>false</c> if the buffer was full.</returns>
        public bool TryAdd(T item) {
            if (_count == _buffer.Length)
                return false;

            _buffer[(_head + _count) % _buffer.Length] = item;
            _count++;
            _version++;
            return true;
        }

        /// <summary>Removes and returns the oldest item.</summary>
        /// <exception cref="InvalidOperationException">Thrown when the buffer is empty.</exception>
        public T RemoveOldest() {
            if (!TryRemoveOldest(out T item))
                throw new InvalidOperationException("The ring buffer is empty.");

            return item;
        }

        /// <summary>Removes the oldest item, if any.</summary>
        /// <param name="item">When this method returns <c>true</c>, the removed item; otherwise the default value.</param>
        /// <returns><c>true</c> if an item was removed; <c>false</c> when the buffer is empty.</returns>
        public bool TryRemoveOldest(out T item) {
            if (_count == 0) {
                item = default!;
                return false;
            }

            item = _buffer[_head];
            _buffer[_head] = default!; // release the reference
            _head = (_head + 1) % _buffer.Length;
            _count--;
            _version++;
            return true;
        }

        /// <summary>Returns the oldest item without removing it.</summary>
        /// <exception cref="InvalidOperationException">Thrown when the buffer is empty.</exception>
        public T PeekOldest() =>
            _count == 0 ? throw new InvalidOperationException("The ring buffer is empty.") : _buffer[_head];

        /// <summary>Returns the newest item without removing it.</summary>
        /// <exception cref="InvalidOperationException">Thrown when the buffer is empty.</exception>
        public T PeekNewest() =>
            _count == 0 ? throw new InvalidOperationException("The ring buffer is empty.") : _buffer[(_head + _count - 1) % _buffer.Length];

        /// <summary>Returns the oldest item without removing it, if any.</summary>
        public bool TryPeekOldest(out T item) {
            if (_count == 0) {
                item = default!;
                return false;
            }

            item = _buffer[_head];
            return true;
        }

        /// <summary>Returns the newest item without removing it, if any.</summary>
        public bool TryPeekNewest(out T item) {
            if (_count == 0) {
                item = default!;
                return false;
            }

            item = _buffer[(_head + _count - 1) % _buffer.Length];
            return true;
        }

        /// <summary>Removes every element from the buffer.</summary>
        public void Clear() {
            Array.Clear(_buffer, 0, _buffer.Length);
            _head = 0;
            _count = 0;
            _version++;
        }

        /// <summary>Copies the elements to a new array, ordered oldest to newest.</summary>
        public T[] ToArray() {
            var array = new T[_count];
            for (int i = 0; i < _count; i++)
                array[i] = _buffer[(_head + i) % _buffer.Length];

            return array;
        }

        /// <summary>Returns an allocation-free enumerator over the elements, ordered oldest to newest.</summary>
        public Enumerator GetEnumerator() => new Enumerator(this);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>A struct enumerator over the buffer, ordered oldest to newest.</summary>
        public struct Enumerator : IEnumerator<T> {

            private readonly RingBuffer<T> _ring;
            private readonly int _version;
            private int _index;
            private T _current;

            internal Enumerator(RingBuffer<T> ring) {
                _ring = ring;
                _version = ring._version;
                _index = -1;
                _current = default!;
            }

            /// <inheritdoc/>
            public T Current => _current;

            object? IEnumerator.Current => _current;

            /// <inheritdoc/>
            public bool MoveNext() {
                if (_version != _ring._version)
                    throw new InvalidOperationException("The ring buffer was modified during enumeration.");
                if (_index + 1 >= _ring._count)
                    return false;

                _index++;
                _current = _ring._buffer[(_ring._head + _index) % _ring._buffer.Length];
                return true;
            }

            /// <inheritdoc/>
            public void Reset() {
                _index = -1;
                _current = default!;
            }

            /// <inheritdoc/>
            public void Dispose() { }
        }
    }
}
