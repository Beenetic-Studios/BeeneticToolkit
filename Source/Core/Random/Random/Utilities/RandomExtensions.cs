using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Random {

    /// <summary>
    /// Shuffle extension methods on <see cref="RandomGenerator"/>, operating on the generator they are
    /// called on so the source of randomness is always explicit.
    /// </summary>
    public static class RandomExtensions {

        /// <summary>
        /// Returns a new, shuffled copy of the source collection, leaving the source untouched.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="random">The random number generator to use.</param>
        /// <param name="source">The collection to shuffle. It is not modified.</param>
        /// <returns>A new <see cref="List{T}"/> containing the source elements in random order.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> or <paramref name="source"/> is null.</exception>
        public static List<T> Shuffle<T>(this RandomGenerator random, IEnumerable<T> source) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var result = new List<T>(source);
            random.ShuffleInPlace(result);
            return result;
        }

        /// <summary>
        /// Shuffles the elements of a list in place using a Fisher-Yates shuffle, without allocating.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="random">The random number generator to use.</param>
        /// <param name="list">The list to shuffle in place.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> or <paramref name="list"/> is null.</exception>
        public static void ShuffleInPlace<T>(this RandomGenerator random, IList<T> list) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            for (int i = list.Count - 1; i > 0; i--) {
                int swapIndex = random.NextInt(i + 1);
                (list[swapIndex], list[i]) = (list[i], list[swapIndex]);
            }
        }
    }
}
