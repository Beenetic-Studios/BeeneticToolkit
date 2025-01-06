using System.Collections.Generic;
using System;
using System.Linq;

namespace BeeneticToolkit.Collections.Utility {

    /// <summary>Provides utility methods for common operations on collections, enhancing their usability and management.</summary>
    public static class CollectionUtils {

        /// <summary>Determines whether a collection is null or contains no elements.</summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to check for null or emptiness.</param>
        /// <returns><c>true</c> if the collection is null or empty; otherwise, <c>false</c>.</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection) {
            return collection == null || !collection.Any();
        }

        /// <summary>Initializes an array of a specified size with a given default value for each element.</summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="size">The size of the array to initialize.</param>
        /// <param name="defaultValue">The default value to assign to each element in the array. Defaults to the type's default value.</param>
        /// <returns>An array of the specified size initialized with the default value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the specified size is less than or equal to 0.</exception>
        public static T[] InitializeArray<T>(int size, T defaultValue = default!) {
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size), size, "Size of array must be greater than 0.");

            T[] array = new T[size];
            for (int i = 0; i < size; i++) {
                array[i] = defaultValue;
            }

            return array;
        }
    }
}