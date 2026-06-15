using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Collections.Enums {

    /// <summary>
    /// An ordered, fixed "domain" of items that <see cref="EnumSet{T}"/> instances are drawn from — the complete
    /// pool of valid items. The domain assigns each item a stable bit position (its order in the domain), which is
    /// what lets a set be stored as a compact bitmask and combined with fast bitwise operations.
    /// </summary>
    /// <remarks>
    /// You rarely construct this directly. For a smart enum, use the item type's static factories
    /// (<c>MyEnum.SetOf(...)</c>, <c>MyEnum.EmptySet()</c>, <c>MyEnum.FullSet()</c>, <c>MyEnum.Domain</c>); for a
    /// runtime-built <see cref="EnumCollection{T, TKey, TGroup}"/>, call its <c>ToDomain()</c>. All sets created
    /// from the same domain instance can be combined together; sets from different domains cannot.
    /// </remarks>
    /// <typeparam name="T">The item type. Items must be distinct (by their <see cref="object.Equals(object)"/>).</typeparam>
    public sealed class EnumDomain<T> where T : class {

        private readonly T[] _items;
        private readonly Dictionary<T, int> _indexByItem;

        /// <summary>Creates a domain from an ordered sequence of distinct, non-null items.</summary>
        /// <param name="items">The items, in the order their bit positions should be assigned.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="items"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when an item is null or appears more than once.</exception>
        public EnumDomain(IEnumerable<T> items) {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            _items = items.ToArray();
            _indexByItem = new Dictionary<T, int>(_items.Length);
            for (int i = 0; i < _items.Length; i++) {
                T item = _items[i];
                if (item == null)
                    throw new ArgumentException("A domain cannot contain null items.", nameof(items));
                if (_indexByItem.ContainsKey(item))
                    throw new ArgumentException($"A domain cannot contain duplicate items ('{item}').", nameof(items));

                _indexByItem[item] = i;
            }
        }

        /// <summary>Gets the number of items in the domain.</summary>
        public int Count => _items.Length;

        /// <summary>Gets the items in the domain, in bit-position order.</summary>
        public IReadOnlyList<T> Items => _items;

        /// <summary>Creates an empty set over this domain.</summary>
        public EnumSet<T> Empty() => new EnumSet<T>(this);

        /// <summary>Creates a set containing every item in this domain.</summary>
        public EnumSet<T> All() {
            var set = new EnumSet<T>(this);
            set.SetAll();
            return set;
        }

        /// <summary>Creates a set containing the given items.</summary>
        /// <param name="items">The items to include. Each must belong to this domain.</param>
        /// <exception cref="ArgumentException">Thrown when an item does not belong to this domain.</exception>
        public EnumSet<T> Of(params T[] items) => From(items);

        /// <summary>Creates a set containing the given items.</summary>
        /// <param name="items">The items to include. Each must belong to this domain.</param>
        /// <exception cref="ArgumentException">Thrown when an item does not belong to this domain.</exception>
        public EnumSet<T> From(IEnumerable<T> items) {
            var set = new EnumSet<T>(this);
            if (items != null) {
                foreach (T item in items)
                    set.Add(item);
            }

            return set;
        }

        /// <summary>Gets the number of 64-bit words needed to store one bit per item.</summary>
        internal int WordCount => (_items.Length + 63) >> 6;

        /// <summary>Looks up an item's bit position.</summary>
        internal bool TryIndexOf(T item, out int index) => _indexByItem.TryGetValue(item, out index);

        /// <summary>Gets the item at a given bit position.</summary>
        internal T ItemAt(int index) => _items[index];
    }
}
