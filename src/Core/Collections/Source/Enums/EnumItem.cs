//using System;
//using System.Collections.Generic;

//namespace BeeneticToolkit.Collections.Enums {
///// <summary>Represents a placeholder type for grouping in <see cref="EnumItem{TGroup}"/> and <see cref="EnumCollection{T, TGroup}"/> when grouping is not required.</summary>
///// <remarks>Use this enumeration as the group type parameter for <see cref="EnumItem{TGroup}"/> or <see cref="EnumCollection{T, TGroup}"/> to manage items without assigning them to a specific group.</remarks>
//public enum NoGroup { }

//    /// <summary>Represents a base class for strongly-typed enumeration items with properties for identification, grouping, and display purposes.</summary>
//    /// <typeparam name="TGroup">The type of the group associated with the enumeration item. Must be an enumeration. Use <see cref="NoGroup"/> if grouping is not required.</typeparam>
//    public abstract class EnumItem<TGroup> : IComparable where TGroup : struct, Enum {
//        #region Properties

//        /// <summary>Gets the unique key identifying this enumeration item.</summary>
//        /// <remarks>The key must not be <c>null</c> or empty.</remarks>
//        public string Key { get; private set; }

//        /// <summary>Gets the display name of this enumeration item.</summary>
//        /// <remarks>The name must not be <c>null</c> or empty.</remarks>
//        public string Name { get; private set; }

//        /// <summary>Gets the short name of this enumeration item.</summary>
//        /// <remarks>The short name must not be <c>null</c> or empty.</remarks>
//        public string ShortName { get; private set; }

//        /// <summary>Gets the optional description of this enumeration item.</summary>
//        /// <remarks>A value of <c>null</c> indicates that no description is provided.</remarks>
//        public string? Description { get; set; }

//        /// <summary>Gets the optional display order of this enumeration item.</summary>
//        /// <remarks>A value of <c>null</c> indicates no specific display order is set.</remarks>
//        public int? DisplayOrder { get; set; }

//        /// <summary>Gets the optional active state of this enumeration item.</summary>
//        /// <remarks>A value of <c>null</c> indicates that the active state is not explicitly defined.</remarks>
//        public bool? IsActive { get; set; }

//        /// <summary>Gets the optional group associated with this enumeration item.</summary>
//        /// <remarks>A value of <c>null</c> indicates that the item does not belong to a specific group.</remarks>
//        public TGroup? Group { get; set; }

//        #endregion Properties

//        #region Constructor

//        /// <summary>Initializes a new instance of the <see cref="EnumItem{TGroup}"/> class.</summary>
//        /// <param name="key">The unique key identifying the enumeration item. Must not be <c>null</c>, empty, or whitespace.</param>
//        /// <param name="name">The display name of the enumeration item. Must not be <c>null</c>, empty, or whitespace.</param>
//        /// <param name="shortName">The short name of the enumeration item. Must not be <c>null</c>, empty, or whitespace.</param>
//        /// <param name="description">An optional description of the enumeration item. Defaults to <c>null</c>.</param>
//        /// <param name="displayOrder">An optional display order for the enumeration item. Defaults to <c>null</c>.</param>
//        /// <param name="isActive">An optional flag indicating whether the enumeration item is active. Defaults to <c>null</c>.</param>
//        /// <param name="group">An optional group associated with the enumeration item. Defaults to <c>null</c>. Use <see cref="NoGroup"/> as the <typeparamref name="TGroup"/> if grouping is not required.</param>
//        /// <exception cref="ArgumentException">Thrown when any required parameter is <c>null</c>, empty, or whitespace.</exception>
//        protected EnumItem(string key, string name, string shortName, string? description = null, int? displayOrder = null, bool? isActive = null, TGroup? group = null) {
//            if (string.IsNullOrWhiteSpace(key))
//                throw new ArgumentException("Key cannot be null or empty.", nameof(key));
//            if (string.IsNullOrWhiteSpace(name))
//                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
//            if (string.IsNullOrWhiteSpace(shortName))
//                throw new ArgumentException("ShortName cannot be null or empty.", nameof(shortName));

//            Key = key;
//            Name = name;
//            ShortName = shortName;
//            Description = description;
//            DisplayOrder = displayOrder;
//            IsActive = isActive;
//            Group = group;
//        }

//        #endregion Constructor

//        #region Equality and Comparison

//        /// <summary>Determines whether the specified object is equal to the current enumeration item, based on its key and type.</summary>
//        /// <param name="obj">The object to compare with the current enumeration item.</param>
//        /// <returns><c>true</c> if the specified object is an <see cref="EnumItem{TGroup}"/> with the same key and type; otherwise, <c>false</c>.</returns>
//        public override bool Equals(object obj) {
//            return obj is EnumItem<TGroup> other && GetType() == other.GetType() && Key == other.Key;
//        }

//        /// <summary>Returns a hash code for this enumeration item.</summary>
//        /// <returns>A hash code based on the item's key.</returns>
//        public override int GetHashCode() {
//            return Key.GetHashCode();
//        }

//        /// <summary>Compares the current enumeration item to another based on their keys.</summary>
//        /// <param name="other">The other enumeration item to compare to.</param>
//        /// <returns>A value indicating the relative order of the items being compared. Less than zero if this instance precedes <paramref name="other"/>, zero if they are equal, and greater than zero if this instance follows <paramref name="other"/>.</returns>
//        /// <exception cref="ArgumentException">Thrown when <paramref name="other"/> is not an <see cref="EnumItem{TGroup}"/>.</exception>
//        public int CompareTo(object other) {
//            if (!(other is EnumItem<TGroup> otherEnum))
//                throw new ArgumentException($"Object must be of type {GetType().Name}");

//            return Key.CompareTo(otherEnum.Key);
//        }

//        #endregion Equality and Comparison

//        #region Helpers

//        /// <summary>Returns a string representation of the enumeration item.</summary>
//        /// <returns>The display name of the enumeration item.</returns>
//        public override string ToString() => Name;

//        #endregion Helpers
//    }
//}

using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Collections.Enums {

    /// <summary>Represents a placeholder type for grouping in <see cref="EnumItem{TKey, TGroup}"/> and <see cref="EnumCollection{T, TKey, TGroup}"/> when grouping is not required.</summary>
    /// <remarks>Use this enumeration as the group type parameter for <see cref="EnumItem{TKey, TGroup}"/> or <see cref="EnumCollection{T, TKey, TGroup}"/> to manage items without assigning them to a specific group.</remarks>
    public enum NoGroup { }

    /// <summary>Represents a base class for strongly-typed enumeration items with properties for identification, grouping, and display purposes.</summary>
    /// <typeparam name="TKey">The type of the key identifying this enumeration item. Must be a non-nullable type.</typeparam>
    /// <typeparam name="TGroup">The type of the group associated with the enumeration item. Must be an enumeration. Use <see cref="NoGroup"/> if grouping is not required.</typeparam>
    public abstract class EnumItem<TKey, TGroup> : IComparable where TKey : notnull where TGroup : struct, Enum {

        #region Properties

        /// <summary>Gets the unique key identifying this enumeration item.</summary>
        /// <remarks>The key must not be <c>null</c>.</remarks>
        public TKey Key { get; private set; }

        /// <summary>Gets the display name of this enumeration item.</summary>
        /// <remarks>The name must not be <c>null</c> or empty.</remarks>
        public string Name { get; private set; }

        /// <summary>Gets the short name of this enumeration item.</summary>
        /// <remarks>The short name must not be <c>null</c> or empty.</remarks>
        public string ShortName { get; private set; }

        /// <summary>Gets the optional description of this enumeration item.</summary>
        /// <remarks>A value of <c>null</c> indicates that no description is provided.</remarks>
        public string? Description { get; set; }

        /// <summary>Gets the optional display order of this enumeration item.</summary>
        /// <remarks>A value of <c>null</c> indicates no specific display order is set.</remarks>
        public int? DisplayOrder { get; set; }

        /// <summary>Gets the optional active state of this enumeration item.</summary>
        /// <remarks>A value of <c>null</c> indicates that the active state is not explicitly defined.</remarks>
        public bool? IsActive { get; set; }

        /// <summary>Gets the optional group associated with this enumeration item.</summary>
        /// <remarks>A value of <c>null</c> indicates that the item does not belong to a specific group.</remarks>
        public TGroup? Group { get; set; }

        #endregion Properties

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="EnumItem{TKey, TGroup}"/> class.</summary>
        /// <param name="key">The unique key identifying the enumeration item. Must not be <c>null</c>.</param>
        /// <param name="name">The display name of the enumeration item. Must not be <c>null</c>, empty, or whitespace.</param>
        /// <param name="shortName">The short name of the enumeration item. Must not be <c>null</c>, empty, or whitespace.</param>
        /// <param name="description">An optional description of the enumeration item. Defaults to <c>null</c>.</param>
        /// <param name="displayOrder">An optional display order for the enumeration item. Defaults to <c>null</c>.</param>
        /// <param name="isActive">An optional flag indicating whether the enumeration item is active. Defaults to <c>null</c>.</param>
        /// <param name="group">An optional group associated with the enumeration item. Defaults to <c>null</c>. Use <see cref="NoGroup"/> as the <typeparamref name="TGroup"/> if grouping is not required.</param>
        /// <exception cref="ArgumentException">Thrown when any required parameter is <c>null</c>, empty, or whitespace.</exception>
        protected EnumItem(
            TKey key,
            string name,
            string shortName,
            string? description = null,
            int? displayOrder = null,
            bool? isActive = null,
            TGroup? group = null) {
            if (key is null || (key is string && key.Equals(string.Empty)))
                throw new ArgumentException("Key cannot be null.", nameof(key));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            if (string.IsNullOrWhiteSpace(shortName))
                throw new ArgumentException("ShortName cannot be null or empty.", nameof(shortName));

            Key = key;
            Name = name;
            ShortName = shortName;
            Description = description;
            DisplayOrder = displayOrder;
            IsActive = isActive;
            Group = group;
        }

        #endregion Constructor

        #region Equality and Comparison

        /// <summary>Determines whether the specified object is equal to the current enumeration item, based on its key and type.</summary>
        /// <param name="obj">The object to compare with the current enumeration item.</param>
        /// <returns><c>true</c> if the specified object is an <see cref="EnumItem{TKey, TGroup}"/> with the same key and type; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) {
            return obj is EnumItem<TKey, TGroup> other && GetType() == other.GetType() && EqualityComparer<TKey>.Default.Equals(Key, other.Key);
        }

        /// <summary>Returns a hash code for this enumeration item.</summary>
        /// <returns>A hash code based on the item's key.</returns>
        public override int GetHashCode() {
            return Key.GetHashCode();
        }

        /// <summary>Compares the current enumeration item to another based on their keys.</summary>
        /// <param name="other">The other enumeration item to compare to.</param>
        /// <returns>A value indicating the relative order of the items being compared. Less than zero if this instance precedes <paramref name="other"/>, zero if they are equal, and greater than zero if this instance follows <paramref name="other"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="other"/> is not an <see cref="EnumItem{TKey, TGroup}"/>.</exception>
        public int CompareTo(object other) {
            if (!(other is EnumItem<TKey, TGroup> otherEnum))
                throw new ArgumentException($"Object must be of type {GetType().Name}");

            return Comparer<TKey>.Default.Compare(Key, otherEnum.Key);
        }

        #endregion Equality and Comparison

        #region Helpers

        /// <summary>Returns a string representation of the enumeration item.</summary>
        /// <returns>The display name of the enumeration item.</returns>
        public override string ToString() => Name;

        #endregion Helpers
    }
}