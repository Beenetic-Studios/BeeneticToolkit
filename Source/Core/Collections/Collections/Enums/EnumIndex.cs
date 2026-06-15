using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Collections.Enums {

    /// <summary>
    /// Internal contract letting an <see cref="EnumCollection{T, TKey, TGroup}"/> keep its registered indexes in
    /// sync as items are added and removed.
    /// </summary>
    internal interface IEnumCollectionIndex<T> where T : class {
        void OnAdded(T item);
        void OnRemoved(T item);
        void Rebuild(IEnumerable<T> items);
    }

    /// <summary>
    /// An O(1) secondary index over a smart enum / <see cref="EnumCollection{T, TKey, TGroup}"/>, keyed by an
    /// arbitrary item property. Each distinct property value maps to the items that have it, so you can look items
    /// up by something other than their key, name, or short name.
    /// </summary>
    /// <remarks>
    /// Create an index with <c>collection.AddIndex(selector)</c> (kept in sync as the collection changes) or
    /// <c>MyEnum.IndexBy(selector)</c> for a fixed smart enum (built once). Items whose indexed value is
    /// <see langword="null"/> are not included. Value equality uses the default comparer for
    /// <typeparamref name="TValue"/>.
    /// </remarks>
    /// <typeparam name="TValue">The type of the indexed property value.</typeparam>
    /// <typeparam name="T">The item type.</typeparam>
    public sealed class EnumIndex<TValue, T> : IEnumCollectionIndex<T> where T : class {

        private static readonly IReadOnlyList<T> Empty = Array.Empty<T>();

        private readonly Func<T, TValue> _selector;
        private readonly Dictionary<TValue, List<T>> _byValue = new Dictionary<TValue, List<T>>();

        internal EnumIndex(Func<T, TValue> selector) {
            _selector = selector ?? throw new ArgumentNullException(nameof(selector));
        }

        /// <summary>Gets the number of distinct indexed values.</summary>
        public int Count => _byValue.Count;

        /// <summary>Gets the distinct indexed values present in the index.</summary>
        public IEnumerable<TValue> Keys => _byValue.Keys;

        /// <summary>Gets the items whose indexed value equals <paramref name="value"/>, or an empty list.</summary>
        public IReadOnlyList<T> Get(TValue value) {
            List<T>? list = GetList(value);
            return list == null ? Empty : list.ToArray();
        }

        /// <summary>Determines whether any item has the given indexed value.</summary>
        public bool Contains(TValue value) => GetList(value) != null;

        /// <summary>Gets the single item with the given value.</summary>
        /// <exception cref="InvalidOperationException">Thrown when zero or more than one item has the value.</exception>
        public T GetSingle(TValue value) {
            List<T>? list = GetList(value);
            int count = list?.Count ?? 0;
            if (count == 1)
                return list![0];

            throw new InvalidOperationException(count == 0
                ? $"No item has the indexed value '{value}'."
                : $"{count} items share the indexed value '{value}'; expected exactly one.");
        }

        /// <summary>Attempts to get the single item with the given value, returning false for zero or multiple.</summary>
        public bool TryGetSingle(TValue value, out T item) {
            List<T>? list = GetList(value);
            if (list != null && list.Count == 1) {
                item = list[0];
                return true;
            }

            item = default!;
            return false;
        }

        void IEnumCollectionIndex<T>.OnAdded(T item) => Insert(item);

        void IEnumCollectionIndex<T>.OnRemoved(T item) => Delete(item);

        void IEnumCollectionIndex<T>.Rebuild(IEnumerable<T> items) {
            _byValue.Clear();
            foreach (T item in items)
                Insert(item);
        }

        private List<T>? GetList(TValue value) =>
            value is null ? null : (_byValue.TryGetValue(value, out List<T>? list) ? list : null);

        private void Insert(T item) {
            TValue value = _selector(item);
            if (value is null)
                return; // null-valued items are not indexed

            if (!_byValue.TryGetValue(value, out List<T>? list)) {
                list = new List<T>();
                _byValue[value] = list;
            }

            list.Add(item);
        }

        private void Delete(T item) {
            TValue value = _selector(item);
            if (value is null)
                return;

            if (_byValue.TryGetValue(value, out List<T>? list)) {
                list.Remove(item);
                if (list.Count == 0)
                    _byValue.Remove(value);
            }
        }
    }
}
