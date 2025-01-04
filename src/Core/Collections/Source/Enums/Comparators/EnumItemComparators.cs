using System.Collections.Generic;
using System;

namespace BeeneticToolkit.Collections.Enums.Comparators {

    /// <summary>
    /// Provides easy access to predefined comparators for sorting <see cref="EnumItem{TGroup}"/> instances.
    /// </summary>
    public static class EnumItemComparators {

        /// <summary>
        /// Creates a comparator that sorts <see cref="EnumItem{TGroup}"/> instances by their <see cref="EnumItem{TGroup}.Key"/> property.
        /// </summary>
        /// <typeparam name="TGroup">The type of the group associated with the enumeration item, which must be an enumeration.</typeparam>
        /// <param name="ascending">A value indicating whether the sorting should be in ascending order. Defaults to <c>true</c>.</param>
        /// <returns>An <see cref="IComparer{T}"/> that sorts by <see cref="EnumItem{TGroup}.Key"/> in the specified order.</returns>
        public static IComparer<EnumItem<TGroup>> ByKey<TGroup>(bool ascending = true) where TGroup : struct, Enum {
            return new EnumItemKeyComparator<TGroup>(ascending);
        }

        /// <summary>
        /// Creates a comparator that sorts <see cref="EnumItem{TGroup}"/> instances by their <see cref="EnumItem{TGroup}.Name"/> property.
        /// </summary>
        /// <typeparam name="TGroup">The type of the group associated with the enumeration item, which must be an enumeration.</typeparam>
        /// <param name="ascending">A value indicating whether the sorting should be in ascending order. Defaults to <c>true</c>.</param>
        /// <returns>An <see cref="IComparer{T}"/> that sorts by <see cref="EnumItem{TGroup}.Name"/> in the specified order.</returns>
        public static IComparer<EnumItem<TGroup>> ByName<TGroup>(bool ascending = true) where TGroup : struct, Enum {
            return new EnumItemNameComparator<TGroup>(ascending);
        }

        /// <summary>
        /// Creates a comparator that sorts <see cref="EnumItem{TGroup}"/> instances by their <see cref="EnumItem{TGroup}.ShortName"/> property.
        /// </summary>
        /// <typeparam name="TGroup">The type of the group associated with the enumeration item, which must be an enumeration.</typeparam>
        /// <param name="ascending">A value indicating whether the sorting should be in ascending order. Defaults to <c>true</c>.</param>
        /// <returns>An <see cref="IComparer{T}"/> that sorts by <see cref="EnumItem{TGroup}.ShortName"/> in the specified order.</returns>
        public static IComparer<EnumItem<TGroup>> ByShortName<TGroup>(bool ascending = true) where TGroup : struct, Enum {
            return new EnumItemShortNameComparator<TGroup>(ascending);
        }

        /// <summary>
        /// Creates a comparator that sorts <see cref="EnumItem{TGroup}"/> instances by their <see cref="EnumItem{TGroup}.DisplayOrder"/> property.
        /// </summary>
        /// <typeparam name="TGroup">The type of the group associated with the enumeration item, which must be an enumeration.</typeparam>
        /// <param name="ascending">A value indicating whether the sorting should be in ascending order. Defaults to <c>true</c>.</param>
        /// <returns>An <see cref="IComparer{T}"/> that sorts by <see cref="EnumItem{TGroup}.DisplayOrder"/> in the specified order.</returns>
        public static IComparer<EnumItem<TGroup>> ByDisplayOrder<TGroup>(bool ascending = true) where TGroup : struct, Enum {
            return new EnumItemDisplayOrderComparator<TGroup>(ascending);
        }

        /// <summary>
        /// Creates a comparator that sorts <see cref="EnumItem{TGroup}"/> instances by their <see cref="EnumItem{TGroup}.IsActive"/> property.
        /// </summary>
        /// <typeparam name="TGroup">The type of the group associated with the enumeration item, which must be an enumeration.</typeparam>
        /// <param name="ascending">A value indicating whether the sorting should be in ascending order. Defaults to <c>true</c>.</param>
        /// <returns>
        /// An <see cref="IComparer{T}"/> that sorts by <see cref="EnumItem{TGroup}.IsActive"/> in the specified order.
        /// Active items (<c>true</c>) are considered greater than inactive items (<c>false</c>), and both are considered
        /// greater than items with an undefined active state (<c>null</c>).
        /// </returns>
        public static IComparer<EnumItem<TGroup>> ByActiveState<TGroup>(bool ascending = true) where TGroup : struct, Enum {
            return new EnumItemIsActiveComparator<TGroup>(ascending);
        }

        /// <summary>
        /// Creates a comparator that sorts <see cref="EnumItem{TGroup}"/> instances by their <see cref="EnumItem{TGroup}.Group"/> property.
        /// </summary>
        /// <typeparam name="TGroup">The type of the group associated with the enumeration item, which must be an enumeration.</typeparam>
        /// <param name="ascending">A value indicating whether the sorting should be in ascending order. Defaults to <c>true</c>.</param>
        /// <returns>
        /// An <see cref="IComparer{T}"/> that sorts by <see cref="EnumItem{TGroup}.Group"/> in the specified order.
        /// Items with a <c>null</c> group are considered less than items with a defined group.
        /// </returns>
        public static IComparer<EnumItem<TGroup>> ByGroup<TGroup>(bool ascending = true) where TGroup : struct, Enum {
            return new EnumItemGroupComparator<TGroup>(ascending);
        }
    }

    /// <summary>
    /// A comparator for sorting <see cref="EnumItem{TGroup}"/> instances by their <see cref="EnumItem{TGroup}.Key"/> property.
    /// </summary>
    /// <typeparam name="TGroup">The type of the group associated with the enumeration item, which must be an enumeration.</typeparam>
    public class EnumItemKeyComparator<TGroup> : PropertyComparator<TGroup> where TGroup : struct, Enum {

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumItemKeyComparator{TGroup}"/> class.
        /// </summary>
        /// <param name="ascending">
        /// A value indicating whether the comparison should be in ascending order. If <c>false</c>,
        /// the comparison will be in descending order.
        /// </param>
        public EnumItemKeyComparator(bool ascending = true)
            : base(ascending) { }

        /// <summary>
        /// Compares two <see cref="EnumItem{TGroup}"/> instances by their <see cref="EnumItem{TGroup}.Key"/> property.
        /// </summary>
        /// <param name="x">The first enumeration item to compare.</param>
        /// <param name="y">The second enumeration item to compare.</param>
        /// <returns>
        /// A negative value if <paramref name="x"/> precedes <paramref name="y"/> by key, zero if they are equal,
        /// or a positive value if <paramref name="x"/> follows <paramref name="y"/>.
        /// </returns>
        protected override int PerformComparison(EnumItem<TGroup> x, EnumItem<TGroup> y) {
            return string.Compare(x.Key, y.Key, StringComparison.Ordinal);
        }
    }

    /// <summary>
    /// A comparator for sorting <see cref="EnumItem{TGroup}"/> instances by their <see cref="EnumItem{TGroup}.Name"/> property.
    /// </summary>
    /// <typeparam name="TGroup">The type of the group associated with the enumeration item, which must be an enumeration.</typeparam>
    public class EnumItemNameComparator<TGroup> : PropertyComparator<TGroup> where TGroup : struct, Enum {

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumItemNameComparator{TGroup}"/> class.
        /// </summary>
        /// <param name="ascending">
        /// A value indicating whether the comparison should be in ascending order. If <c>false</c>,
        /// the comparison will be in descending order.
        /// </param>
        public EnumItemNameComparator(bool ascending = true)
            : base(ascending) { }

        /// <summary>
        /// Compares two <see cref="EnumItem{TGroup}"/> instances by their <see cref="EnumItem{TGroup}.Name"/> property.
        /// </summary>
        /// <param name="x">The first enumeration item to compare.</param>
        /// <param name="y">The second enumeration item to compare.</param>
        /// <returns>
        /// A negative value if <paramref name="x"/> precedes <paramref name="y"/> by name, zero if they are equal,
        /// or a positive value if <paramref name="x"/> follows <paramref name="y"/>.
        /// </returns>
        protected override int PerformComparison(EnumItem<TGroup> x, EnumItem<TGroup> y) {
            return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }

    /// <summary>
    /// A comparator for sorting <see cref="EnumItem{TGroup}"/> instances by their <see cref="EnumItem{TGroup}.ShortName"/> property.
    /// </summary>
    /// <typeparam name="TGroup">The type of the group associated with the enumeration item, which must be an enumeration.</typeparam>
    public class EnumItemShortNameComparator<TGroup> : PropertyComparator<TGroup> where TGroup : struct, Enum {

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumItemShortNameComparator{TGroup}"/> class.
        /// </summary>
        /// <param name="ascending">
        /// A value indicating whether the comparison should be in ascending order. If <c>false</c>,
        /// the comparison will be in descending order.
        /// </param>
        public EnumItemShortNameComparator(bool ascending = true)
            : base(ascending) { }

        /// <summary>
        /// Compares two <see cref="EnumItem{TGroup}"/> instances by their <see cref="EnumItem{TGroup}.ShortName"/> property.
        /// </summary>
        /// <param name="x">The first enumeration item to compare.</param>
        /// <param name="y">The second enumeration item to compare.</param>
        /// <returns>
        /// A negative value if <paramref name="x"/> precedes <paramref name="y"/> by short name, zero if they are equal,
        /// or a positive value if <paramref name="x"/> follows <paramref name="y"/>.
        /// </returns>
        protected override int PerformComparison(EnumItem<TGroup> x, EnumItem<TGroup> y) {
            return string.Compare(x.ShortName, y.ShortName, StringComparison.Ordinal);
        }
    }

    /// <summary>
    /// A comparator for sorting <see cref="EnumItem{TGroup}"/> instances by their <see cref="EnumItem{TGroup}.DisplayOrder"/> property.
    /// </summary>
    /// <typeparam name="TGroup">The type of the group associated with the enumeration item, which must be an enumeration.</typeparam>
    public class EnumItemDisplayOrderComparator<TGroup> : PropertyComparator<TGroup> where TGroup : struct, Enum {

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumItemDisplayOrderComparator{TGroup}"/> class.
        /// </summary>
        /// <param name="ascending">
        /// A value indicating whether the comparison should be in ascending order. If <c>false</c>,
        /// the comparison will be in descending order.
        /// </param>
        public EnumItemDisplayOrderComparator(bool ascending = true)
            : base(ascending) { }

        /// <summary>
        /// Compares two <see cref="EnumItem{TGroup}"/> instances by their <see cref="EnumItem{TGroup}.DisplayOrder"/> property.
        /// </summary>
        /// <param name="x">The first enumeration item to compare.</param>
        /// <param name="y">The second enumeration item to compare.</param>
        /// <returns>
        /// A negative value if <paramref name="x"/> precedes <paramref name="y"/> by display order, zero if they are equal,
        /// or a positive value if <paramref name="x"/> follows <paramref name="y"/>.
        /// </returns>
        /// <remarks>
        /// This comparison uses <see cref="Nullable.Compare{T}"/> to handle the nullable <see cref="bool"/> values.
        /// </remarks>
        protected override int PerformComparison(EnumItem<TGroup> x, EnumItem<TGroup> y) {
            return Nullable.Compare(x.DisplayOrder, y.DisplayOrder);
        }
    }

    /// <summary>
    /// A comparator for sorting <see cref="EnumItem{TGroup}"/> instances by their <see cref="EnumItem{TGroup}.IsActive"/> property.
    /// </summary>
    /// <typeparam name="TGroup">The type of the group associated with the enumeration item, which must be an enumeration.</typeparam>
    public class EnumItemIsActiveComparator<TGroup> : PropertyComparator<TGroup> where TGroup : struct, Enum {

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumItemIsActiveComparator{TGroup}"/> class.
        /// </summary>
        /// <param name="ascending">
        /// A value indicating whether the comparison should be in ascending order. If <c>false</c>,
        /// the comparison will be in descending order.
        /// </param>
        public EnumItemIsActiveComparator(bool ascending = true)
            : base(ascending) { }

        /// <summary>
        /// Compares two <see cref="EnumItem{TGroup}"/> instances by their <see cref="EnumItem{TGroup}.IsActive"/> property.
        /// </summary>
        /// <param name="x">The first enumeration item to compare.</param>
        /// <param name="y">The second enumeration item to compare.</param>
        /// <returns>
        /// A negative value if <paramref name="x"/> precedes <paramref name="y"/> by active state, zero if they are equal,
        /// or a positive value if <paramref name="x"/> follows <paramref name="y"/>.
        /// Active items (<c>true</c>) are considered greater than inactive items (<c>false</c>),
        /// and both are considered greater than items with an undefined active state (<c>null</c>).
        /// </returns>
        /// <remarks>
        /// This comparison uses <see cref="Nullable.Compare{T}"/> to handle the nullable <see cref="bool"/> values.
        /// </remarks>
        protected override int PerformComparison(EnumItem<TGroup> x, EnumItem<TGroup> y) {
            return Nullable.Compare(x.IsActive, y.IsActive);
        }
    }

    /// <summary>
    /// A comparator for sorting <see cref="EnumItem{TGroup}"/> instances by their <see cref="EnumItem{TGroup}.Group"/> property.
    /// </summary>
    /// <typeparam name="TGroup">The type of the group associated with the enumeration item, which must be an enumeration.</typeparam>
    public class EnumItemGroupComparator<TGroup> : PropertyComparator<TGroup> where TGroup : struct, Enum {

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumItemGroupComparator{TGroup}"/> class.
        /// </summary>
        /// <param name="ascending">
        /// A value indicating whether the comparison should be in ascending order. If <c>false</c>,
        /// the comparison will be in descending order.
        /// </param>
        public EnumItemGroupComparator(bool ascending = true)
            : base(ascending) { }

        /// <summary>
        /// Compares two <see cref="EnumItem{TGroup}"/> instances by their <see cref="EnumItem{TGroup}.Group"/> property.
        /// </summary>
        /// <param name="x">The first enumeration item to compare.</param>
        /// <param name="y">The second enumeration item to compare.</param>
        /// <returns>
        /// A negative value if <paramref name="x"/> precedes <paramref name="y"/> by group, zero if they are equal,
        /// or a positive value if <paramref name="x"/> follows <paramref name="y"/>.
        /// Items with a <c>null</c> group are considered less than items with a defined group.
        /// </returns>
        /// <remarks>
        /// This comparison uses <see cref="Comparer{T}.Default"/> for the <typeparamref name="TGroup"/> type,
        /// and treats <c>null</c> as less than any defined group.
        /// </remarks>
        protected override int PerformComparison(EnumItem<TGroup> x, EnumItem<TGroup> y) {
            return Comparer<TGroup?>.Default.Compare(x.Group, y.Group);
        }
    }
}