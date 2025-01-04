using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Collections.Enums {

    /// <summary>
    /// Represents a collection of strongly-typed enumeration items with utility methods for managing,
    /// retrieving, and searching items based on their properties.
    /// </summary>
    /// <typeparam name="T">The type of the enumeration items, which must inherit from <see cref="EnumItem{TGroup}"/>.</typeparam>
    /// <typeparam name="TGroup">The type of the group associated with the enumeration items, which must be an enumeration.</typeparam>
    public abstract class EnumCollection<T, TGroup> where T : EnumItem<TGroup> where TGroup : struct, Enum {

        #region Fields

        private readonly List<T> _items = new List<T>();
        private IReadOnlyList<T>? _defaultCachedItems;
        private readonly Dictionary<IComparer<T>, IReadOnlyList<T>> _comparerCache = new Dictionary<IComparer<T>, IReadOnlyList<T>>();

        #endregion Fields

        #region Collection Management

        /// <summary>
        /// Adds an enumeration item to the collection if it does not already exist.
        /// </summary>
        /// <param name="item">The enumeration item to add.</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown when an item with the same key as the specified item already exists in the collection.
        /// </exception>
        public void Add(T item) {
            if (_items.Any(existing => existing.Key == item.Key))
                throw new InvalidOperationException($"Duplicate Key '{item.Key}' in {typeof(T).Name}.");

            _items.Add(item);
            _defaultCachedItems = null; // Invalidate default cache
            _comparerCache.Clear();    // Invalidate comparer-specific caches
        }

        /// <summary>
        /// Adds multiple enumeration items to the collection.
        /// </summary>
        /// <param name="items">The collection of enumeration items to add.</param>
        /// <remarks>
        /// This method calls <see cref="Add"/> for each item in the provided collection.
        /// </remarks>
        public void AddRange(IEnumerable<T> items) {
            foreach (T item in items) {
                Add(item);
            }
        }

        /// <summary>
        /// Retrieves all items in the collection as a read-only list, optionally sorted using a specified comparer.
        /// </summary>
        /// <param name="comparer">An optional comparer to determine the sort order of the items.</param>
        /// <returns>A read-only list of all items in the collection.</returns>
        /// <example>
        /// The following example demonstrates how to retrieve all items from the collection
        /// and sort them using a custom comparer:
        /// <code>
        /// var collection = new MyEnumCollection();
        /// // Add items to the collection...
        ///
        /// var sortedItems = collection.GetAll(new MyCustomComparer());
        /// foreach (var item in sortedItems) {
        ///     Console.WriteLine(item.Name);
        /// }
        /// </code>
        /// </example>

        public IReadOnlyList<T> GetAll(IComparer<T>? comparer = null) {
            if (comparer == null)
                return _defaultCachedItems ??= _items.AsReadOnly();

            if (_comparerCache.TryGetValue(comparer, out var cachedList))
                return cachedList;

            var sortedList = new List<T>(_items);
            sortedList.Sort(comparer);

            var readOnlyList = sortedList.AsReadOnly();
            _comparerCache[comparer] = readOnlyList;

            return readOnlyList;
        }

        /// <summary>
        /// Retrieves all items in the collection that belong to the specified group.
        /// </summary>
        /// <param name="group">
        /// The group to filter items by. If <paramref name="group"/> is <see langword="null"/>, all items in the collection are returned.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing the items that belong to the specified group.
        /// If <paramref name="group"/> is <see langword="null"/>, all items are returned.
        /// </returns>
        /// <example>
        /// The following example demonstrates how to retrieve items from the collection
        /// that belong to a specific group:
        /// <code>
        /// var collection = new MyEnumCollection();
        /// // Add items to the collection...
        ///
        /// var groupItems = collection.GetByGroup(MyEnumGroup.Category1);
        /// foreach (var item in groupItems) {
        ///     Console.WriteLine(item.Name);
        /// }
        /// </code>
        /// </example>
        public IEnumerable<T> GetByGroup(TGroup? group = null) {
            if (group == null)
                return _items;

            return _items.Where(item => item.Group != null && item.Group.Equals(group));
        }

        /// <summary>
        /// Searches the collection for items whose selected property matches the search term.
        /// </summary>
        /// <param name="selector">A function that selects the property of each item to search.</param>
        /// <param name="searchTerm">The term to search for within the selected property.</param>
        /// <param name="caseSensitive">Whether the search should be case-sensitive. Defaults to <c>false</c>.</param>
        /// <returns>A collection of items that match the search term.</returns>
        /// <example>
        /// The following example demonstrates how to search the collection for items
        /// where the `Name` property contains a specific term, ignoring case:
        /// <code>
        /// var collection = new MyEnumCollection();
        /// // Add items to the collection...
        ///
        /// var searchResults = collection.Search(item => item.Name, "searchTerm", caseSensitive: false);
        /// foreach (var item in searchResults) {
        ///     Console.WriteLine(item.Name);
        /// }
        /// </code>
        /// </example>
        public IEnumerable<T> Search(Func<T, string> selector, string searchTerm, bool caseSensitive = false) {
            if (caseSensitive)
                return _items.Where(item => selector(item).Contains(searchTerm));

            return _items.Where(item => selector(item).Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        #endregion Collection Management

        #region Lookup

        /// <summary>
        /// Retrieves an item from the collection by its unique key.
        /// </summary>
        /// <param name="key">The unique key of the item to retrieve.</param>
        /// <returns>The item corresponding to the specified key.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when no item with the specified key exists in the collection.
        /// </exception>
        public T FromKey(string key) {
            var item = _items.FirstOrDefault(i => i.Key == key);
            return item ?? throw new InvalidOperationException($"'{key}' is not a valid Key in {typeof(T).Name}.");
        }

        /// <summary>
        /// Retrieves an item from the collection by its name.
        /// </summary>
        /// <param name="name">The name of the item to retrieve.</param>
        /// <returns>The item corresponding to the specified name.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when no item with the specified name exists in the collection.
        /// </exception>
        public T FromName(string name) {
            var item = _items.FirstOrDefault(i => i.Name == name);
            return item ?? throw new InvalidOperationException($"'{name}' is not a valid Name in {typeof(T).Name}.");
        }

        /// <summary>
        /// Retrieves an item from the collection by its short name.
        /// </summary>
        /// <param name="shortName">The short name of the item to retrieve.</param>
        /// <returns>The item corresponding to the specified short name.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when no item with the specified short name exists in the collection.
        /// </exception>
        public T FromShortName(string shortName) {
            var item = _items.FirstOrDefault(i => i.ShortName == shortName);
            return item ?? throw new InvalidOperationException($"'{shortName}' is not a valid ShortName in {typeof(T).Name}.");
        }

        #endregion Lookup
    }
}