using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace BeeneticToolkit.Collections.Enums {

    /// <summary>Represents a collection of strongly-typed enumeration items with utility methods for managing, retrieving, and searching items based on their properties.</summary>
    /// <typeparam name="T">The type of the enumeration items, which must inherit from <see cref="EnumItem{TKey, TGroup}"/>.</typeparam>
    /// <typeparam name="TKey">The type of the key for the enumeration items.</typeparam>
    /// <typeparam name="TGroup">The type of the group associated with the enumeration items. Must be an enumeration. Use <see cref="NoGroup"/> if grouping is not required.</typeparam>
    /// <example>
    /// <code>
    /// public class PositionCollection : EnumCollection&lt;Position, PositionKey, NoGroup&gt; { }
    ///
    /// var positionCollection = new PositionCollection();
    /// positionCollection.Add(new Position("P001", "Manager", "Mgr"));
    ///
    /// var allPositions = positionCollection.GetAll();
    /// foreach (var position in allPositions) {
    ///     Console.WriteLine(position.Name);
    /// }
    /// </code>
    /// </example>
    /// <remarks>This class supports both grouped and non-grouped enumeration items. When grouping is not relevant, use <see cref="NoGroup"/> as the <typeparamref name="TGroup"/> parameter. Methods like <see cref="GetByGroup"/> return all items when the <c>group</c> parameter is <see langword="null"/>.</remarks>
    public abstract class EnumCollection<T, TKey, TGroup>
           where T : EnumItem<TKey, TGroup>
           where TKey : notnull
           where TGroup : struct, Enum {

        #region Fields

        private readonly List<T> _items = new List<T>();
        private readonly Dictionary<TKey, T> _byKey = new Dictionary<TKey, T>();
        private IReadOnlyList<T>? _defaultCachedItems;

        // Lazily built name/short-name indexes for O(1) lookups; invalidated on Add/Remove. First-match wins,
        // mirroring the original linear-scan semantics.
        private Dictionary<string, T>? _byName;
        private Dictionary<string, T>? _byShortName;

        #endregion Fields

        #region Collection Management

        /// <summary>Adds an enumeration item to the collection if it does not already exist.</summary>
        /// <param name="item">The enumeration item to add.</param>
        /// <exception cref="InvalidOperationException">Thrown when an item with the same key as the specified item already exists in the collection.</exception>
        public virtual void Add(T item) {
            if (_byKey.ContainsKey(item.Key))
                throw new InvalidOperationException($"Duplicate Key '{item.Key}' in {typeof(T).Name}.");

            _items.Add(item);
            _byKey[item.Key] = item;
            InvalidateCaches();
        }

        /// <summary>Adds multiple enumeration items to the collection.</summary>
        /// <param name="items">The collection of enumeration items to add.</param>
        /// <remarks>This method calls <see cref="Add"/> for each item in the provided collection.</remarks>
        public virtual void AddRange(IEnumerable<T> items) {
            foreach (T item in items) {
                Add(item);
            }
        }

        /// <summary>Removes an enumeration item from the collection by its reference.</summary>
        /// <param name="item">The enumeration item to remove.</param>
        /// <exception cref="InvalidOperationException">Thrown when the specified item does not exist in the collection.</exception>
        public virtual void Remove(T item) {
            if (!_items.Remove(item))
                throw new InvalidOperationException($"Item '{item.Key}' does not exist in {typeof(T).Name}.");

            _byKey.Remove(item.Key);
            InvalidateCaches();
        }

        /// <summary>Removes multiple enumeration items from the collection by their references.</summary>
        /// <param name="items">The collection of enumeration items to remove.</param>
        /// <remarks>This method calls <see cref="Remove"/> for each item in the provided collection.</remarks>
        public virtual void RemoveRange(IEnumerable<T> items) {
            foreach (T item in items) {
                Remove(item);
            }
        }

        /// <summary>Retrieves all items in the collection as an <see cref="IEnumerable{T}"/>, optionally filtered by active state and sorted using a specified comparer.</summary>
        /// <param name="comparer">An optional comparer to determine the sort order of the items. If no comparer is provided, the items are returned in their natural order.</param>
        /// <param name="isActive">An optional filter to include only active or inactive items. If <see langword="null"/>, both active and inactive items are included.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> containing the items in the collection, optionally filtered and sorted.</returns>
        /// <remarks>
        /// This method leverages caching for optimized repeated retrievals. When no filters or comparers are provided, a cached list of items is returned to minimize overhead.
        /// Predefined comparators include <see cref="Comparators.EnumItemComparators.ByKey{TKey, TGroup}"/>, <see cref="Comparators.EnumItemComparators.ByName{TKey, TGroup}"/>, and others.
        /// </remarks>
        /// <example>
        /// <code>
        /// var collection = new MyEnumCollection();
        /// // Add items to the collection...
        ///
        /// // Retrieve all active items in their natural order
        /// var activeItems = collection.GetAll(isActive: true);
        /// foreach (var item in activeItems) {
        ///     Console.WriteLine(item.Name);
        /// }
        ///
        /// // Retrieve all items sorted using a predefined comparator by name
        /// var sortedByName = collection.GetAll(EnumItemComparators.ByName&lt;MyGroup&gt;());
        /// foreach (var item in sortedByName) {
        ///     Console.WriteLine(item.Name);
        /// }
        /// </code>
        /// </example>
        public IEnumerable<T> GetAll(IComparer<T>? comparer = null, bool? isActive = null) {
            // If no isActive filter is specified and no comparer is provided, return the default cached list
            if (isActive == null && comparer == null) {
                return _defaultCachedItems ??= _items.AsReadOnly();
            }

            // Filter the items based on the isActive parameter
            IEnumerable<T> filteredItems = _items;
            if (isActive.HasValue) {
                filteredItems = filteredItems.Where(item => item.IsActive == isActive.Value);
            }

            // If no comparer is specified, return the filtered list
            if (comparer == null) {
                return filteredItems.ToList().AsReadOnly();
            }

            // Sort the filtered items
            var sortedList = filteredItems.ToList();
            sortedList.Sort(comparer);

            return sortedList.AsReadOnly();
        }

        /// <summary>Retrieves items in the collection that belong to the specified group, optionally filtered by active state.</summary>
        /// <param name="group">The group to filter items by. If <paramref name="group"/> is <see langword="null"/>, all items are included regardless of their group.</param>
        /// <param name="isActive">An optional filter to include only active or inactive items. If <see langword="null"/>, both active and inactive items are included.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> containing the items in the specified group, optionally filtered by active state.</returns>
        /// <remarks>Group filtering and active state filtering are combined to provide flexible queries for retrieving desired subsets of items.</remarks>
        /// <example>
        /// <code>
        /// var collection = new MyEnumCollection();
        /// // Add items to the collection...
        ///
        /// // Retrieve all items in Group1
        /// var groupItems = collection.GetByGroup(MyEnumGroup.Group1);
        /// foreach (var item in groupItems) {
        ///     Console.WriteLine(item.Name);
        /// }
        ///
        /// // Retrieve only active items in Group1
        /// var activeGroupItems = collection.GetByGroup(MyEnumGroup.Group1, isActive: true);
        /// foreach (var item in activeGroupItems) {
        ///     Console.WriteLine(item.Name);
        /// }
        /// </code>
        /// </example>
        public IEnumerable<T> GetByGroup(TGroup? group = null, bool? isActive = null) {
            IEnumerable<T> result = group == null
                ? _items
                : _items.Where(item => item.Group != null && item.Group.Equals(group));

            if (isActive.HasValue) {
                result = result.Where(item => item.IsActive == isActive.Value);
            }

            return result.ToList();
        }

        /// <summary>Searches the collection for items whose selected property matches the specified search term, optionally filtered by active state.</summary>
        /// <param name="selector">A function that selects the property of each item to search.</param>
        /// <param name="searchTerm">The term to search for within the selected property.</param>
        /// <param name="caseSensitive">Indicates whether the search should be case-sensitive. Defaults to <c>false</c>.</param>
        /// <param name="isActive">An optional filter to include only active or inactive items. If <see langword="null"/>, both active and inactive items are included.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> containing the items that match the search term, optionally filtered by active state.</returns>
        /// <remarks>Combines search term matching and active state filtering to provide precise results. Case sensitivity is controlled by the <paramref name="caseSensitive"/> parameter.</remarks>
        /// <example>
        /// <code>
        /// var collection = new MyEnumCollection();
        /// // Add items to the collection...
        ///
        /// // Search for items with "term" in their name, ignoring case
        /// var searchResults = collection.Search(item => item.Name, "term");
        /// foreach (var item in searchResults) {
        ///     Console.WriteLine(item.Name);
        /// }
        ///
        /// // Search for active items with "term" in their name, ignoring case
        /// var activeSearchResults = collection.Search(item => item.Name, "term", isActive: true);
        /// foreach (var item in activeSearchResults) {
        ///     Console.WriteLine(item.Name);
        /// }
        /// </code>
        /// </example>
        public IEnumerable<T> Search(Func<T, string> selector, string searchTerm, bool caseSensitive = false, bool? isActive = null) {
            IEnumerable<T> result = _items.Where(item =>
                caseSensitive
                    ? selector(item).Contains(searchTerm)
                    : selector(item).Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

            if (isActive.HasValue) {
                result = result.Where(item => item.IsActive == isActive.Value);
            }

            return result.ToList();
        }

        #endregion Collection Management

        #region Lookup

        /// <summary>Retrieves an item from the collection by its unique key.</summary>
        /// <param name="key">The unique key of the item to retrieve.</param>
        /// <returns>The item corresponding to the specified key.</returns>
        /// <exception cref="InvalidOperationException">Thrown when no item with the specified key exists in the collection.</exception>
        public T FromKey(TKey key) {
            return TryFromKey(key, out var item)
                ? item
                : throw new InvalidOperationException($"'{key}' is not a valid Key in {typeof(T).Name}.");
        }

        /// <summary>Attempts to retrieve an item by its unique key, without throwing.</summary>
        /// <param name="key">The unique key of the item to retrieve.</param>
        /// <param name="item">When this method returns <c>true</c>, the matching item; otherwise <c>null</c>.</param>
        /// <returns><c>true</c> if an item with the specified key exists; otherwise <c>false</c>.</returns>
        public bool TryFromKey(TKey key, [MaybeNullWhen(false)] out T item) => _byKey.TryGetValue(key, out item);

        /// <summary>Retrieves an item from the collection by its name.</summary>
        /// <param name="name">The name of the item to retrieve.</param>
        /// <returns>The item corresponding to the specified name.</returns>
        /// <exception cref="InvalidOperationException">Thrown when no item with the specified name exists in the collection.</exception>
        public T FromName(string name) {
            return TryFromName(name, out var item)
                ? item
                : throw new InvalidOperationException($"'{name}' is not a valid Name in {typeof(T).Name}.");
        }

        /// <summary>Attempts to retrieve an item by its name, without throwing.</summary>
        /// <param name="name">The name of the item to retrieve.</param>
        /// <param name="item">When this method returns <c>true</c>, the first item with the given name; otherwise <c>null</c>.</param>
        /// <returns><c>true</c> if an item with the specified name exists; otherwise <c>false</c>.</returns>
        public bool TryFromName(string name, [MaybeNullWhen(false)] out T item) {
            if (name == null) {
                item = default!;
                return false;
            }

            _byName ??= BuildIndex(i => i.Name);
            return _byName.TryGetValue(name, out item!);
        }

        /// <summary>Retrieves an item from the collection by its short name.</summary>
        /// <param name="shortName">The short name of the item to retrieve.</param>
        /// <returns>The item corresponding to the specified short name.</returns>
        /// <exception cref="InvalidOperationException">Thrown when no item with the specified short name exists in the collection.</exception>
        public T FromShortName(string shortName) {
            return TryFromShortName(shortName, out var item)
                ? item
                : throw new InvalidOperationException($"'{shortName}' is not a valid ShortName in {typeof(T).Name}.");
        }

        /// <summary>Attempts to retrieve an item by its short name, without throwing.</summary>
        /// <param name="shortName">The short name of the item to retrieve.</param>
        /// <param name="item">When this method returns <c>true</c>, the first item with the given short name; otherwise <c>null</c>.</param>
        /// <returns><c>true</c> if an item with the specified short name exists; otherwise <c>false</c>.</returns>
        public bool TryFromShortName(string shortName, [MaybeNullWhen(false)] out T item) {
            if (shortName == null) {
                item = default!;
                return false;
            }

            _byShortName ??= BuildIndex(i => i.ShortName);
            return _byShortName.TryGetValue(shortName, out item!);
        }

        /// <summary>Builds a first-match-wins lookup index over the current items, keyed by the selected string.</summary>
        private Dictionary<string, T> BuildIndex(Func<T, string> selector) {
            var index = new Dictionary<string, T>(_items.Count);
            foreach (T item in _items) {
                string key = selector(item);
                if (!index.ContainsKey(key))
                    index[key] = item; // keep the first, matching the original FirstOrDefault behavior
            }

            return index;
        }

        /// <summary>Drops the cached views and indexes after the item set changes.</summary>
        private void InvalidateCaches() {
            _defaultCachedItems = null;
            _byName = null;
            _byShortName = null;
        }

        #endregion Lookup

        #region Flag Sets

        /// <summary>
        /// Creates a fixed <see cref="EnumDomain{T}"/> snapshot of the items currently in this collection, for
        /// building <see cref="EnumSet{T}"/> flag sets.
        /// </summary>
        /// <remarks>
        /// The domain is a <b>snapshot</b>: items added to or removed from this collection afterward are not
        /// reflected. Call this again after mutating the collection if you need an up-to-date domain.
        /// </remarks>
        /// <returns>A domain over the collection's current items, in their current order.</returns>
        public EnumDomain<T> ToDomain() => new EnumDomain<T>(_items);

        #endregion Flag Sets
    }
}