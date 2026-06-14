using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Random.Utilities {

    /// <summary>
    /// Provides extension methods for randomizing collections, enhancing the standard RandomGenerator class functionality.
    /// </summary>
    public static class RandomExtensions {

        /// <summary>
        /// Returns a new, shuffled copy of the source collection, leaving the source untouched.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="source">The collection to shuffle. It is not modified.</param>
        /// <param name="random">The random number generator to use, or null to use the default generator.</param>
        /// <returns>A new <see cref="List{T}"/> containing the source elements in random order.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
        public static List<T> Shuffle<T>(this IEnumerable<T> source, RandomGenerator? random = null) {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var result = new List<T>(source);
            result.ShuffleInPlace(random);
            return result;
        }

        /// <summary>
        /// Shuffles the elements of a list in place using a Fisher-Yates shuffle, without allocating.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to shuffle in place.</param>
        /// <param name="random">The random number generator to use, or null to use the default generator.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="list"/> is null.</exception>
        public static void ShuffleInPlace<T>(this IList<T> list, RandomGenerator? random = null) {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            random ??= RngManager.Current;

            for (int i = list.Count - 1; i > 0; i--) {
                int swapIndex = random.NextInt(i + 1);
                (list[swapIndex], list[i]) = (list[i], list[swapIndex]);
            }
        }
    }
}