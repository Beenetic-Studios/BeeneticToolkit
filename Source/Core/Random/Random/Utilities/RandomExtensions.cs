using BeeneticToolkit.Collections.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Random.Utilities {

    /// <summary>
    /// Provides extension methods for randomizing collections, enhancing the standard RandomGenerator class functionality.
    /// </summary>
    public static class RandomExtensions {

        /// <summary>
        /// Shuffles elements in a collection using a specified or default random number generator.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="source">The collection to shuffle.</param>
        /// <param name="random">The random number generator to use, or null to use the default generator.</param>
        /// <returns>A shuffled version of the source collection.</returns>
        /// <exception cref="ArgumentException">Thrown when the source collection is null or empty.</exception>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, RandomGenerator? random = null) {
            random ??= RngManager.Current;

            if (source.IsNullOrEmpty())
                throw new ArgumentException(nameof(source), "Source cannot be null or empty.");

            var list = source as IList<T> ?? source.ToList();
            for (int i = list.Count - 1; i > 0; i--) {
                int swapIndex = random.NextInt(i + 1);
                (list[swapIndex], list[i]) = (list[i], list[swapIndex]);
            }

            return list;
        }
    }
}