using System.Collections.Generic;
using System;

namespace BeeneticToolkit.Collections.Enums.Comparators {

    /// <summary>Provides easy access to predefined comparators for sorting <see cref="EnumItem{TKey, TGroup}"/> instances.</summary>
    public static class EnumItemComparators {

        /// <summary>
        /// Creates a comparator that sorts <see cref="EnumItem{TKey, TGroup}"/> instances by their <see cref="EnumItem{TKey, TGroup}.Key"/> property.
        /// </summary>
        /// <typeparam name="TKey">The type of the key associated with the enumeration item.</typeparam>
        /// <typeparam name="TGroup">The type of the group associated with the enumeration item. Must be an enumeration.</typeparam>
        /// <param name="ascending">Indicates whether the sorting should be in ascending order. Defaults to <c>true</c>.</param>
        /// <returns>An <see cref="IComparer{T}"/> that sorts by <see cref="EnumItem{TKey, TGroup}.Key"/> in the specified order.</returns>
        public static IComparer<EnumItem<TKey, TGroup>> ByKey<TKey, TGroup>(bool ascending = true)
            where TKey : notnull
            where TGroup : struct, Enum {
            return new EnumItemKeyComparator<TKey, TGroup>(ascending);
        }

        /// <summary>
        /// Creates a comparator that sorts <see cref="EnumItem{TKey, TGroup}"/> instances by their <see cref="EnumItem{TKey, TGroup}.Name"/> property.
        /// </summary>
        /// <typeparam name="TKey">The type of the key associated with the enumeration item.</typeparam>
        /// <typeparam name="TGroup">The type of the group associated with the enumeration item. Must be an enumeration.</typeparam>
        /// <param name="ascending">Indicates whether the sorting should be in ascending order. Defaults to <c>true</c>.</param>
        /// <returns>An <see cref="IComparer{T}"/> that sorts by <see cref="EnumItem{TKey, TGroup}.Name"/> in the specified order.</returns>
        public static IComparer<EnumItem<TKey, TGroup>> ByName<TKey, TGroup>(bool ascending = true)
            where TKey : notnull
            where TGroup : struct, Enum {
            return new EnumItemNameComparator<TKey, TGroup>(ascending);
        }

        /// <summary>
        /// Creates a comparator that sorts <see cref="EnumItem{TKey, TGroup}"/> instances by their <see cref="EnumItem{TKey, TGroup}.ShortName"/> property.
        /// </summary>
        /// <typeparam name="TKey">The type of the key associated with the enumeration item.</typeparam>
        /// <typeparam name="TGroup">The type of the group associated with the enumeration item. Must be an enumeration.</typeparam>
        /// <param name="ascending">Indicates whether the sorting should be in ascending order. Defaults to <c>true</c>.</param>
        /// <returns>An <see cref="IComparer{T}"/> that sorts by <see cref="EnumItem{TKey, TGroup}.ShortName"/> in the specified order.</returns>
        public static IComparer<EnumItem<TKey, TGroup>> ByShortName<TKey, TGroup>(bool ascending = true)
            where TKey : notnull
            where TGroup : struct, Enum {
            return new EnumItemShortNameComparator<TKey, TGroup>(ascending);
        }

        /// <summary>
        /// Creates a comparator that sorts <see cref="EnumItem{TKey, TGroup}"/> instances by their <see cref="EnumItem{TKey, TGroup}.DisplayOrder"/> property.
        /// </summary>
        /// <typeparam name="TKey">The type of the key associated with the enumeration item.</typeparam>
        /// <typeparam name="TGroup">The type of the group associated with the enumeration item. Must be an enumeration.</typeparam>
        /// <param name="ascending">Indicates whether the sorting should be in ascending order. Defaults to <c>true</c>.</param>
        /// <returns>An <see cref="IComparer{T}"/> that sorts by <see cref="EnumItem{TKey, TGroup}.DisplayOrder"/> in the specified order.</returns>
        public static IComparer<EnumItem<TKey, TGroup>> ByDisplayOrder<TKey, TGroup>(bool ascending = true)
            where TKey : notnull
            where TGroup : struct, Enum {
            return new EnumItemDisplayOrderComparator<TKey, TGroup>(ascending);
        }

        /// <summary>
        /// Creates a comparator that sorts <see cref="EnumItem{TKey, TGroup}"/> instances by their <see cref="EnumItem{TKey, TGroup}.IsActive"/> property.
        /// </summary>
        /// <typeparam name="TKey">The type of the key associated with the enumeration item.</typeparam>
        /// <typeparam name="TGroup">The type of the group associated with the enumeration item. Must be an enumeration.</typeparam>
        /// <param name="ascending">Indicates whether the sorting should be in ascending order. Defaults to <c>true</c>.</param>
        /// <returns>An <see cref="IComparer{T}"/> that sorts by <see cref="EnumItem{TKey, TGroup}.IsActive"/> in the specified order.</returns>
        public static IComparer<EnumItem<TKey, TGroup>> ByActiveState<TKey, TGroup>(bool ascending = true)
            where TKey : notnull
            where TGroup : struct, Enum {
            return new EnumItemIsActiveComparator<TKey, TGroup>(ascending);
        }

        /// <summary>
        /// Creates a comparator that sorts <see cref="EnumItem{TKey, TGroup}"/> instances by their <see cref="EnumItem{TKey, TGroup}.Group"/> property.
        /// </summary>
        /// <typeparam name="TKey">The type of the key associated with the enumeration item.</typeparam>
        /// <typeparam name="TGroup">The type of the group associated with the enumeration item. Must be an enumeration.</typeparam>
        /// <param name="ascending">Indicates whether the sorting should be in ascending order. Defaults to <c>true</c>.</param>
        /// <returns>An <see cref="IComparer{T}"/> that sorts by <see cref="EnumItem{TKey, TGroup}.Group"/> in the specified order.</returns>
        public static IComparer<EnumItem<TKey, TGroup>> ByGroup<TKey, TGroup>(bool ascending = true)
            where TKey : notnull
            where TGroup : struct, Enum {
            return new EnumItemGroupComparator<TKey, TGroup>(ascending);
        }
    }

    /// <summary>
    /// A comparator for sorting <see cref="EnumItem{TKey, TGroup}"/> instances by their <see cref="EnumItem{TKey, TGroup}.Key"/> property.
    /// </summary>
    /// <typeparam name="TKey">The type of the key associated with the enumeration item.</typeparam>
    /// <typeparam name="TGroup">The type of the group associated with the enumeration item. Must be an enumeration.</typeparam>
    public class EnumItemKeyComparator<TKey, TGroup> : PropertyComparator<TKey, TGroup>
        where TKey : notnull
        where TGroup : struct, Enum {

        /// <summary>Initializes a new instance of the <see cref="EnumItemKeyComparator{TKey, TGroup}"/> class.</summary>
        /// <param name="ascending">Indicates whether the comparison should be in ascending order. Defaults to <c>true</c>.</param>
        public EnumItemKeyComparator(bool ascending = true) : base(ascending) { }

        /// <summary>
        /// Compares two <see cref="EnumItem{TKey, TGroup}"/> instances by their <see cref="EnumItem{TKey, TGroup}.Key"/> property.
        /// </summary>
        /// <param name="x">The first enumeration item to compare.</param>
        /// <param name="y">The second enumeration item to compare.</param>
        /// <returns>
        /// A negative value if <paramref name="x"/> precedes <paramref name="y"/>, zero if they are equal,
        /// or a positive value if <paramref name="x"/> follows <paramref name="y"/>.
        /// </returns>
        protected override int PerformComparison(EnumItem<TKey, TGroup> x, EnumItem<TKey, TGroup> y) {
            return Comparer<TKey>.Default.Compare(x.Key, y.Key);
        }
    }

    /// <summary>
    /// A comparator for sorting <see cref="EnumItem{TKey, TGroup}"/> instances by their <see cref="EnumItem{TKey, TGroup}.Name"/> property.
    /// </summary>
    /// <typeparam name="TKey">The type of the key associated with the enumeration item.</typeparam>
    /// <typeparam name="TGroup">The type of the group associated with the enumeration item. Must be an enumeration.</typeparam>
    public class EnumItemNameComparator<TKey, TGroup> : PropertyComparator<TKey, TGroup>
        where TKey : notnull
        where TGroup : struct, Enum {

        /// <summary>Initializes a new instance of the <see cref="EnumItemNameComparator{TKey, TGroup}"/> class.</summary>
        /// <param name="ascending">Indicates whether the comparison should be in ascending order. Defaults to <c>true</c>.</param>
        public EnumItemNameComparator(bool ascending = true) : base(ascending) { }

        /// <summary>
        /// Compares two <see cref="EnumItem{TKey, TGroup}"/> instances by their <see cref="EnumItem{TKey, TGroup}.Name"/> property.
        /// </summary>
        /// <param name="x">The first enumeration item to compare.</param>
        /// <param name="y">The second enumeration item to compare.</param>
        /// <returns>
        /// A negative value if <paramref name="x"/> precedes <paramref name="y"/>, zero if they are equal,
        /// or a positive value if <paramref name="x"/> follows <paramref name="y"/>.
        /// </returns>
        protected override int PerformComparison(EnumItem<TKey, TGroup> x, EnumItem<TKey, TGroup> y) {
            return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }

    /// <summary>
    /// A comparator for sorting <see cref="EnumItem{TKey, TGroup}"/> instances by their <see cref="EnumItem{TKey, TGroup}.ShortName"/> property.
    /// </summary>
    /// <typeparam name="TKey">The type of the key associated with the enumeration item.</typeparam>
    /// <typeparam name="TGroup">The type of the group associated with the enumeration item. Must be an enumeration.</typeparam>
    public class EnumItemShortNameComparator<TKey, TGroup> : PropertyComparator<TKey, TGroup>
        where TKey : notnull
        where TGroup : struct, Enum {

        /// <summary>Initializes a new instance of the <see cref="EnumItemShortNameComparator{TKey, TGroup}"/> class.</summary>
        /// <param name="ascending">Indicates whether the comparison should be in ascending order. Defaults to <c>true</c>.</param>
        public EnumItemShortNameComparator(bool ascending = true) : base(ascending) { }

        /// <summary>
        /// Compares two <see cref="EnumItem{TKey, TGroup}"/> instances by their <see cref="EnumItem{TKey, TGroup}.ShortName"/> property.
        /// </summary>
        /// <param name="x">The first enumeration item to compare.</param>
        /// <param name="y">The second enumeration item to compare.</param>
        /// <returns>
        /// A negative value if <paramref name="x"/> precedes <paramref name="y"/>, zero if they are equal,
        /// or a positive value if <paramref name="x"/> follows <paramref name="y"/>.
        /// </returns>
        protected override int PerformComparison(EnumItem<TKey, TGroup> x, EnumItem<TKey, TGroup> y) {
            return string.Compare(x.ShortName, y.ShortName, StringComparison.Ordinal);
        }
    }

    /// <summary>
    /// A comparator for sorting <see cref="EnumItem{TKey, TGroup}"/> instances by their <see cref="EnumItem{TKey, TGroup}.DisplayOrder"/> property.
    /// </summary>
    /// <typeparam name="TKey">The type of the key associated with the enumeration item.</typeparam>
    /// <typeparam name="TGroup">The type of the group associated with the enumeration item. Must be an enumeration.</typeparam>
    public class EnumItemDisplayOrderComparator<TKey, TGroup> : PropertyComparator<TKey, TGroup>
        where TKey : notnull
        where TGroup : struct, Enum {

        /// <summary>Initializes a new instance of the <see cref="EnumItemDisplayOrderComparator{TKey, TGroup}"/> class.</summary>
        /// <param name="ascending">Indicates whether the comparison should be in ascending order. Defaults to <c>true</c>.</param>
        public EnumItemDisplayOrderComparator(bool ascending = true) : base(ascending) { }

        /// <summary>
        /// Compares two <see cref="EnumItem{TKey, TGroup}"/> instances by their <see cref="EnumItem{TKey, TGroup}.DisplayOrder"/> property.
        /// </summary>
        protected override int PerformComparison(EnumItem<TKey, TGroup> x, EnumItem<TKey, TGroup> y) {
            return Nullable.Compare(x.DisplayOrder, y.DisplayOrder);
        }
    }

    /// <summary>
    /// A comparator for sorting <see cref="EnumItem{TKey, TGroup}"/> instances by their <see cref="EnumItem{TKey, TGroup}.IsActive"/> property.
    /// </summary>
    public class EnumItemIsActiveComparator<TKey, TGroup> : PropertyComparator<TKey, TGroup>
        where TKey : notnull
        where TGroup : struct, Enum {

        /// <summary>Initializes a new instance of the <see cref="EnumItemIsActiveComparator{TKey, TGroup}"/> class.</summary>
        public EnumItemIsActiveComparator(bool ascending = true) : base(ascending) { }

        /// <summary>
        /// Compares two <see cref="EnumItem{TKey, TGroup}"/> instances by their <see cref="EnumItem{TKey, TGroup}.IsActive"/> property.
        /// </summary>
        protected override int PerformComparison(EnumItem<TKey, TGroup> x, EnumItem<TKey, TGroup> y) {
            return Nullable.Compare(x.IsActive, y.IsActive);
        }
    }

    /// <summary>
    /// A comparator for sorting <see cref="EnumItem{TKey, TGroup}"/> instances by their <see cref="EnumItem{TKey, TGroup}.Group"/> property.
    /// </summary>
    public class EnumItemGroupComparator<TKey, TGroup> : PropertyComparator<TKey, TGroup>
        where TKey : notnull
        where TGroup : struct, Enum {

        /// <summary>Initializes a new instance of the <see cref="EnumItemGroupComparator{TKey, TGroup}"/> class.</summary>
        public EnumItemGroupComparator(bool ascending = true) : base(ascending) { }

        /// <summary>
        /// Compares two <see cref="EnumItem{TKey, TGroup}"/> instances by their <see cref="EnumItem{TKey, TGroup}.Group"/> property.
        /// </summary>
        protected override int PerformComparison(EnumItem<TKey, TGroup> x, EnumItem<TKey, TGroup> y) {
            return Comparer<TGroup?>.Default.Compare(x.Group, y.Group);
        }
    }
}