//using System;
//using System.Collections.Generic;

//namespace BeeneticToolkit.Collections.Enums.Comparators {
//    /// <summary>Serves as a base class for comparators that sort <see cref="EnumItem{TGroup}"/> instances by a specific property, with a fallback to the <see cref="EnumItem{TGroup}.Key"/> property for deterministic ordering.</summary>
//    /// <typeparam name="TGroup">The type of the group associated with the enumeration item. Must be an enumeration.</typeparam>
//    /// <remarks>This class provides common logic for handling null values, sorting order (ascending or descending), and fallback to the <see cref="EnumItem{TGroup}.Key"/> property.</remarks>
//    public abstract class PropertyComparator<TGroup> : IComparer<EnumItem<TGroup>> where TGroup : struct, Enum {
//        private readonly bool _ascending;

//        /// <summary>Initializes a new instance of the <see cref="PropertyComparator{TGroup}"/> class.</summary>
//        /// <param name="ascending">Indicates whether the comparison should be in ascending order. If <c>false</c>, the comparison will be in descending order.</param>
//        /// <remarks>The default sorting order is ascending if the <paramref name="ascending"/> parameter is not provided.</remarks>
//        protected PropertyComparator(bool ascending = true) {
//            _ascending = ascending;
//        }

//        /// <summary>Compares two <see cref="EnumItem{TGroup}"/> instances by the property defined in <see cref="PerformComparison(EnumItem{TGroup}, EnumItem{TGroup})"/>, with a fallback to the <see cref="EnumItem{TGroup}.Key"/> property.</summary>
//        /// <param name="x">The first enumeration item to compare.</param>
//        /// <param name="y">The second enumeration item to compare.</param>
//        /// <returns>A negative value if <paramref name="x"/> precedes <paramref name="y"/>, zero if they are equal, or a positive value if <paramref name="x"/> follows <paramref name="y"/>.</returns>
//        /// <remarks>If either <paramref name="x"/> or <paramref name="y"/> is <c>null</c>, the non-null item precedes the <c>null</c> item. Both <c>null</c> values are considered equal.</remarks>
//        public int Compare(EnumItem<TGroup>? x, EnumItem<TGroup>? y) {
//            if (x == null && y == null)
//                return 0;
//            if (x == null)
//                return -1;
//            if (y == null)
//                return 1;

//            // Primary comparison based on overridden logic
//            int comparison = PerformComparison(x, y);

//            // Use Key as the secondary criterion if primary comparison results in equality
//            if (comparison == 0) {
//                comparison = string.Compare(x.Key, y.Key, StringComparison.Ordinal);
//            }

//            return _ascending ? comparison : -comparison;
//        }

//        /// <summary>Performs the primary comparison for the specific property this comparator is designed to sort by.</summary>
//        /// <param name="x">The first enumeration item to compare.</param>
//        /// <param name="y">The second enumeration item to compare.</param>
//        /// <returns>A negative value if <paramref name="x"/> precedes <paramref name="y"/>, zero if they are equal, or a positive value if <paramref name="x"/> follows <paramref name="y"/>.</returns>
//        /// <remarks>Subclasses must override this method to define the primary comparison logic for the desired property.</remarks>
//        /// <exception cref="NotImplementedException">Thrown if this method is called without being overridden in a subclass.</exception>
//        protected abstract int PerformComparison(EnumItem<TGroup> x, EnumItem<TGroup> y);
//    }
//}

using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Collections.Enums.Comparators {

    /// <summary>
    /// Serves as a base class for comparators that sort <see cref="EnumItem{TKey, TGroup}"/> instances by a specific property,
    /// with a fallback to the <see cref="EnumItem{TKey, TGroup}.Key"/> property for deterministic ordering.
    /// </summary>
    /// <typeparam name="TKey">The type of the key associated with the enumeration item.</typeparam>
    /// <typeparam name="TGroup">The type of the group associated with the enumeration item. Must be an enumeration.</typeparam>
    /// <remarks>
    /// This class provides common logic for handling null values, sorting order (ascending or descending),
    /// and fallback to the <see cref="EnumItem{TKey, TGroup}.Key"/> property.
    /// </remarks>
    public abstract class PropertyComparator<TKey, TGroup> : IComparer<EnumItem<TKey, TGroup>>
        where TKey : notnull
        where TGroup : struct, Enum {
        private readonly bool _ascending;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyComparator{TKey, TGroup}"/> class.
        /// </summary>
        /// <param name="ascending">Indicates whether the comparison should be in ascending order. If <c>false</c>, the comparison will be in descending order.</param>
        /// <remarks>The default sorting order is ascending if the <paramref name="ascending"/> parameter is not provided.</remarks>
        protected PropertyComparator(bool ascending = true) {
            _ascending = ascending;
        }

        /// <summary>
        /// Compares two <see cref="EnumItem{TKey, TGroup}"/> instances by the property defined in <see cref="PerformComparison(EnumItem{TKey, TGroup}, EnumItem{TKey, TGroup})"/>,
        /// with a fallback to the <see cref="EnumItem{TKey, TGroup}.Key"/> property.
        /// </summary>
        /// <param name="x">The first enumeration item to compare.</param>
        /// <param name="y">The second enumeration item to compare.</param>
        /// <returns>
        /// A negative value if <paramref name="x"/> precedes <paramref name="y"/>, zero if they are equal, or a positive value if <paramref name="x"/> follows <paramref name="y"/>.
        /// </returns>
        /// <remarks>
        /// If either <paramref name="x"/> or <paramref name="y"/> is <c>null</c>, the non-null item precedes the <c>null</c> item. Both <c>null</c> values are considered equal.
        /// </remarks>
        public int Compare(EnumItem<TKey, TGroup>? x, EnumItem<TKey, TGroup>? y) {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;

            // Primary comparison based on overridden logic
            int comparison = PerformComparison(x, y);

            // Use Key as the secondary criterion if primary comparison results in equality
            if (comparison == 0) {
                comparison = Comparer<TKey>.Default.Compare(x.Key, y.Key);
            }

            return _ascending ? comparison : -comparison;
        }

        /// <summary>
        /// Performs the primary comparison for the specific property this comparator is designed to sort by.
        /// </summary>
        /// <param name="x">The first enumeration item to compare.</param>
        /// <param name="y">The second enumeration item to compare.</param>
        /// <returns>
        /// A negative value if <paramref name="x"/> precedes <paramref name="y"/>, zero if they are equal, or a positive value if <paramref name="x"/> follows <paramref name="y"/>.
        /// </returns>
        /// <remarks>Subclasses must override this method to define the primary comparison logic for the desired property.</remarks>
        /// <exception cref="NotImplementedException">Thrown if this method is called without being overridden in a subclass.</exception>
        protected abstract int PerformComparison(EnumItem<TKey, TGroup> x, EnumItem<TKey, TGroup> y);
    }
}