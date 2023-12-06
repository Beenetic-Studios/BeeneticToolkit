using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Random.Utility {

    /// <summary>
    /// Provides utility methods for random operations, such as selecting random elements from collections.
    /// </summary>
    public static partial class RandomUtils {

        #region Random Choice

        /// <summary>
        /// Selects a random element from a list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list from which to select a random element.</param>
        /// <param name="random">The random number generator to use, or null to use the default generator.</param>
        /// <returns>A randomly selected element from the list.</returns>
        public static T RandomChoice<T>(IList<T> list, RandomGenerator? random = null) {
            random ??= RngManager.Current;

            return list[random.NextInt(list.Count)];
        }

        /// <summary>
        /// Selects a random element from an IEnumerable sequence.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence from which to select a random element.</param>
        /// <param name="random">The random number generator to use, or null to use the default generator.</param>
        /// <returns>A randomly selected element from the sequence.</returns>
        public static T RandomChoice<T>(IEnumerable<T> sequence, RandomGenerator? random = null) {
            var list = sequence as IList<T> ?? sequence.ToList();

            return RandomChoice(list, random);
        }

        #endregion Random Choice

        #region Random Choice With Exclusion

        /// <summary>
        /// Selects a random element from a list, excluding elements that match a specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list from which to select a random element.</param>
        /// <param name="exclusionPredicate">A predicate to exclude elements from being selected.</param>
        /// <param name="random">The random number generator to use, or null to use the default generator.</param>
        /// <returns>A randomly selected element from the list that does not match the exclusion predicate.</returns>
        /// <exception cref="InvalidOperationException">Thrown when no elements are available after applying the exclusion filter.</exception>
        public static T RandomChoiceWithExclusion<T>(IList<T> list, Func<T, bool> exclusionPredicate, RandomGenerator? random = null) {
            random ??= RngManager.Current;

            List<T> filteredList = list.Where(item => !exclusionPredicate(item)).ToList();

            if (!filteredList.Any()) {
                throw new InvalidOperationException("No elements available after applying the exclusion filter.");
            }

            return filteredList[random.NextInt(filteredList.Count)];
        }

        /// <summary>
        /// Selects a random element from an IEnumerable sequence, excluding elements that match a specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence from which to select a random element.</param>
        /// <param name="exclusionPredicate">A predicate to exclude elements from being selected.</param>
        /// <param name="random">The random number generator to use, or null to use the default generator.</param>
        /// <returns>A randomly selected element from the sequence that does not match the exclusion predicate.</returns>
        /// <exception cref="InvalidOperationException">Thrown when no elements are available after applying the exclusion filter.</exception>
        public static T RandomChoiceWithExclusion<T>(IEnumerable<T> sequence, Func<T, bool> exclusionPredicate, RandomGenerator? random = null) {
            var list = sequence as IList<T> ?? sequence.ToList();

            return RandomChoiceWithExclusion(list, exclusionPredicate, random);
        }

        #endregion Random Choice With Exclusion

        #region Random Subset

        /// <summary>
        /// Selects a random subset of a specified size from a list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list from which to select a random subset.</param>
        /// <param name="subsetSize">The size of the subset to select.</param>
        /// <param name="random">The random number generator to use, or null to use the default generator.</param>
        /// <returns>A list containing a random subset of the specified size.</returns>
        /// <exception cref="ArgumentException">Thrown when the input list is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the subset size is not within the valid range.</exception>
        public static List<T> RandomSubset<T>(IList<T> list, int subsetSize, RandomGenerator? random = null) {
            random ??= RngManager.Current;

            if (list.Count == 0)
                throw new ArgumentException(nameof(list), "List cannot be empty.");

            if (subsetSize <= 0 || subsetSize > list.Count)
                throw new ArgumentOutOfRangeException(nameof(subsetSize), subsetSize,
                    "Subset size must be larger than 0 and less than or equal to the list size.");

            List<T> shuffledList = new List<T>(list);
            for (int i = 0; i < subsetSize; i++) {
                int j = random.NextInt(i, list.Count);
                (shuffledList[i], shuffledList[j]) = (shuffledList[j], shuffledList[i]);
            }

            return shuffledList.GetRange(0, subsetSize);
        }

        /// <summary>
        /// Selects a random subset of a specified size from an IEnumerable sequence.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence from which to select a random subset.</param>
        /// <param name="subsetSize">The size of the subset to select.</param>
        /// <param name="random">The random number generator to use, or null to use the default generator.</param>
        /// <returns>A list containing a random subset of the specified size.</returns>
        /// <remarks>Converts the sequence to a list before selecting the subset.</remarks>
        public static List<T> RandomSubset<T>(IEnumerable<T> sequence, int subsetSize, RandomGenerator? random = null) {
            var list = sequence as IList<T> ?? sequence.ToList();

            return RandomSubset(list, subsetSize, random);
        }

        #endregion Random Subset

        #region Random Weighted Choice

        /// <summary>
        /// Selects a random element from a list, with each element's likelihood of being chosen
        /// determined by its corresponding weight in a separate weight list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list from which to select a random weighted element.</param>
        /// <param name="weights">A list of weights corresponding to each element in the list.</param>
        /// <param name="random">The random number generator to use, or null to use the default generator.</param>
        /// <returns>A randomly selected element, weighted by the corresponding weights list.</returns>
        /// <exception cref="ArgumentException">Thrown when the input list is empty or the lengths of the list and weights do not match.</exception>
        public static T RandomWeightedChoice<T>(IList<T> list, IList<double> weights, RandomGenerator? random = null) {
            random ??= RngManager.Current;

            if (list.Count == 0)
                throw new ArgumentException(nameof(list), "List cannot be empty.");

            if (list.Count != weights.Count) {
                throw new ArgumentException("The lengths of the list and weights do not match.");
            }

            T selected = default;
            double totalWeight = weights.Sum();
            double itemWeightIndex = random.NextDouble() * totalWeight;
            double currentWeightIndex = 0;

            for (int i = 0; i < list.Count; ++i) {
                currentWeightIndex += weights[i];
                if (currentWeightIndex >= itemWeightIndex) {
                    selected = list[i];
                    break;
                }
            }
#pragma warning disable CS8603 // Possible null reference return.
            return selected;
#pragma warning restore CS8603 // Possible null reference return.
        }

        /// <summary>
        /// Selects a random element from an IEnumerable sequence, with each element's likelihood of being chosen
        /// determined by its corresponding weight in a separate weight list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence from which to select a random weighted element.</param>
        /// <param name="weights">A list of weights corresponding to each element in the sequence.</param>
        /// <param name="random">The random number generator to use, or null to use the default generator.</param>
        /// <returns>A randomly selected element, weighted by the corresponding weights list.</returns>
        public static T RandomWeightedChoice<T>(IEnumerable<T> sequence, IList<double> weights, RandomGenerator? random = null) {
            var list = sequence as IList<T> ?? sequence.ToList();

            return RandomWeightedChoice(list, weights, random);
        }

        #endregion Random Weighted Choice
    }
}