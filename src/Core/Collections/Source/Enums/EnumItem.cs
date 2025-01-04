using System;

namespace BeeneticToolkit.Collections.Enums {

    /// <summary>
    /// Represents a base class for strongly-typed enumeration items with properties for identification,
    /// grouping, and display purposes.
    /// </summary>
    /// <typeparam name="TGroup">The type of the group associated with the enumeration item, which must be an enumeration.</typeparam>
    public abstract class EnumItem<TGroup> : IComparable where TGroup : struct, Enum {

        #region Properties

        /// <summary>
        /// Gets the unique key that identifies this enumeration item.
        /// </summary>
        /// <remarks>
        /// This property is required and cannot be <c>null</c> or empty.
        /// </remarks>
        public string Key { get; private set; }

        /// <summary>
        /// Gets the display name of this enumeration item.
        /// </summary>
        /// <remarks>
        /// This property is required and cannot be <c>null</c> or empty.
        /// </remarks>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the short name of this enumeration item.
        /// </summary>
        /// <remarks>
        /// This property is required and cannot be <c>null</c> or empty.
        /// </remarks>
        public string ShortName { get; private set; }

        /// <summary>
        /// Gets the optional description of this enumeration item.
        /// </summary>
        /// <remarks>
        /// This property is nullable. A value of <c>null</c> indicates that no description is provided.
        /// </remarks>
        public string? Description { get; set; }

        /// <summary>
        /// Gets the optional display order of this enumeration item.
        /// </summary>
        /// <remarks>
        /// This property is nullable. A value of <c>null</c> indicates no specific display order is set.
        /// </remarks>
        public int? DisplayOrder { get; set; }

        /// <summary>
        /// Gets the optional active state of this enumeration item.
        /// </summary>
        /// <remarks>
        /// This property is nullable. A value of <c>null</c> indicates that the active state is not explicitly defined.
        /// </remarks>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Gets the optional group associated with this enumeration item.
        /// </summary>
        /// <remarks>
        /// This property is nullable. A value of <c>null</c> indicates that the item does not belong to a specific group.
        /// </remarks>
        public TGroup? Group { get; set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumItem{TGroup}"/> class.
        /// </summary>
        /// <param name="key">
        /// The unique key identifying the enumeration item. This parameter is required and cannot be <c>null</c>, empty, or whitespace.
        /// </param>
        /// <param name="name">
        /// The display name of the enumeration item. This parameter is required and cannot be <c>null</c>, empty, or whitespace.
        /// </param>
        /// <param name="shortName">
        /// The short name of the enumeration item. This parameter is required and cannot be <c>null</c>, empty, or whitespace.
        /// </param>
        /// <param name="description">
        /// An optional description of the enumeration item. This parameter can be <c>null</c> if no description is provided.
        /// </param>
        /// <param name="displayOrder">
        /// An optional display order for the enumeration item. This parameter can be <c>null</c> if no specific display order is needed.
        /// </param>
        /// <param name="isActive">
        /// An optional flag indicating whether the enumeration item is active. This parameter can be <c>null</c> if the active state is not explicitly defined.
        /// </param>
        /// <param name="group">
        /// An optional group associated with the enumeration item. This parameter can be <c>null</c> if the item does not belong to a specific group.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when any of the required parameters (<paramref name="key"/>, <paramref name="name"/>, or <paramref name="shortName"/>) are <c>null</c>, empty, or whitespace.
        /// </exception>
        protected EnumItem(string key, string name, string shortName, string? description = null, int? displayOrder = null, bool? isActive = null, TGroup? group = null) {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Key cannot be null or empty.", nameof(key));
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

        /// <summary>
        /// Determines whether the specified object is equal to the current enumeration item,
        /// based on its key and type.
        /// </summary>
        /// <param name="obj">The object to compare with the current enumeration item.</param>
        /// <returns>
        /// <c>true</c> if the specified object is an <see cref="EnumItem{TGroup}"/> with the same key as the current item;
        /// otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) {
            return obj is EnumItem<TGroup> other && GetType() == other.GetType() && Key == other.Key;
        }

        /// <summary>
        /// Returns a hash code for this enumeration item.
        /// </summary>
        /// <returns>A hash code for the current enumeration item.</returns>
        public override int GetHashCode() {
            return Key.GetHashCode();
        }

        /// <summary>
        /// Compares the current enumeration item to another based on their keys.
        /// </summary>
        /// <param name="other">The other enumeration item to compare to.</param>
        /// <returns>
        /// A value indicating the relative order of the items being compared.
        /// Less than zero if this instance precedes <paramref name="other"/>, zero if they are equal,
        /// and greater than zero if this instance follows <paramref name="other"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="other"/> is not an <see cref="EnumItem{TGroup}"/>.
        /// </exception>
        public int CompareTo(object other) {
            if (!(other is EnumItem<TGroup> otherEnum))
                throw new ArgumentException($"Object must be of type {GetType().Name}");

            return Key.CompareTo(otherEnum.Key);
        }

        #endregion Equality and Comparison

        #region Helpers

        /// <summary>
        /// Returns a string representation of the enumeration item.
        /// </summary>
        /// <returns>The display name of the enumeration item.</returns>
        public override string ToString() => Name;

        #endregion Helpers
    }
}