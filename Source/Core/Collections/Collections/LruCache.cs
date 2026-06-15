using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Collections {

    /// <summary>
    /// A fixed-capacity cache that evicts the least-recently-used entry when full. Reading or writing a key marks
    /// it as most-recently-used; once the cache is at capacity, adding a new key drops the entry that has gone
    /// longest without use. Ideal for bounding memory on asset, result, or path caches.
    /// </summary>
    /// <remarks>
    /// Backed by a dictionary plus a recency linked list, so lookups, inserts, and eviction are all O(1). Not
    /// thread-safe. Subscribe to <see cref="Evicted"/> to dispose or pool values as they fall out.
    /// </remarks>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The cached value type.</typeparam>
    public sealed class LruCache<TKey, TValue> where TKey : notnull {

        private readonly int _capacity;
        private readonly Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>> _map;
        private readonly LinkedList<KeyValuePair<TKey, TValue>> _recency; // First = most-recently-used, Last = least

        /// <summary>Creates a cache that holds at most <paramref name="capacity"/> entries.</summary>
        /// <param name="capacity">The maximum number of entries. Must be greater than zero.</param>
        /// <param name="comparer">An optional key comparer (e.g. for case-insensitive string keys).</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="capacity"/> is not greater than zero.</exception>
        public LruCache(int capacity, IEqualityComparer<TKey>? comparer = null) {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than zero.");

            _capacity = capacity;
            _map = new Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>>(comparer);
            _recency = new LinkedList<KeyValuePair<TKey, TValue>>();
        }

        /// <summary>Gets the maximum number of entries the cache holds.</summary>
        public int Capacity => _capacity;

        /// <summary>Gets the number of entries currently cached.</summary>
        public int Count => _map.Count;

        /// <summary>
        /// Raised when an entry is dropped to make room for a new one. Not raised by <see cref="Remove"/> or
        /// <see cref="Clear"/>, nor when an existing key's value is overwritten.
        /// </summary>
        public event Action<TKey, TValue>? Evicted;

        /// <summary>Gets or sets the value for a key. Getting and setting both mark the key most-recently-used.</summary>
        /// <exception cref="KeyNotFoundException">Thrown by the getter when the key is not cached.</exception>
        public TValue this[TKey key] {
            get => TryGet(key, out TValue value)
                ? value
                : throw new KeyNotFoundException($"The key '{key}' was not found in the cache.");
            set => Set(key, value);
        }

        /// <summary>Adds or updates an entry and marks it most-recently-used, evicting the LRU entry if needed.</summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> is null.</exception>
        public void Set(TKey key, TValue value) {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (_map.TryGetValue(key, out LinkedListNode<KeyValuePair<TKey, TValue>>? node)) {
                node.Value = new KeyValuePair<TKey, TValue>(key, value);
                _recency.Remove(node);
                _recency.AddFirst(node);
                return;
            }

            var newNode = new LinkedListNode<KeyValuePair<TKey, TValue>>(new KeyValuePair<TKey, TValue>(key, value));
            _recency.AddFirst(newNode);
            _map[key] = newNode;

            if (_map.Count > _capacity)
                EvictLeastRecentlyUsed();
        }

        /// <summary>Gets the value for a key, marking it most-recently-used on a hit.</summary>
        /// <returns><c>true</c> if the key was cached; otherwise <c>false</c>.</returns>
        public bool TryGet(TKey key, out TValue value) {
            if (key != null && _map.TryGetValue(key, out LinkedListNode<KeyValuePair<TKey, TValue>>? node)) {
                _recency.Remove(node);
                _recency.AddFirst(node);
                value = node.Value.Value;
                return true;
            }

            value = default!;
            return false;
        }

        /// <summary>Gets the value for a key <i>without</i> changing its recency.</summary>
        /// <returns><c>true</c> if the key was cached; otherwise <c>false</c>.</returns>
        public bool TryPeek(TKey key, out TValue value) {
            if (key != null && _map.TryGetValue(key, out LinkedListNode<KeyValuePair<TKey, TValue>>? node)) {
                value = node.Value.Value;
                return true;
            }

            value = default!;
            return false;
        }

        /// <summary>Determines whether a key is cached, without changing its recency.</summary>
        public bool ContainsKey(TKey key) => key != null && _map.ContainsKey(key);

        /// <summary>
        /// Returns the cached value for a key, or creates it with <paramref name="factory"/>, caches it (evicting
        /// the LRU entry if needed), and returns it. Either way the key becomes most-recently-used.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> or <paramref name="factory"/> is null.</exception>
        public TValue GetOrAdd(TKey key, Func<TKey, TValue> factory) {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            if (TryGet(key, out TValue existing))
                return existing;

            TValue value = factory(key);
            Set(key, value);
            return value;
        }

        /// <summary>Removes a key from the cache. Does not raise <see cref="Evicted"/>.</summary>
        /// <returns><c>true</c> if the key was present and removed; otherwise <c>false</c>.</returns>
        public bool Remove(TKey key) {
            if (key != null && _map.TryGetValue(key, out LinkedListNode<KeyValuePair<TKey, TValue>>? node)) {
                _map.Remove(key);
                _recency.Remove(node);
                return true;
            }

            return false;
        }

        /// <summary>Removes every entry. Does not raise <see cref="Evicted"/>.</summary>
        public void Clear() {
            _map.Clear();
            _recency.Clear();
        }

        /// <summary>Gets the cached keys, ordered most-recently-used to least. Does not change recency.</summary>
        public IEnumerable<TKey> Keys {
            get {
                for (LinkedListNode<KeyValuePair<TKey, TValue>>? node = _recency.First; node != null; node = node.Next)
                    yield return node.Value.Key;
            }
        }

        private void EvictLeastRecentlyUsed() {
            LinkedListNode<KeyValuePair<TKey, TValue>>? lru = _recency.Last;
            if (lru == null)
                return;

            _recency.RemoveLast();
            _map.Remove(lru.Value.Key);
            Evicted?.Invoke(lru.Value.Key, lru.Value.Value);
        }
    }
}
