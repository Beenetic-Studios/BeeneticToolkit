using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace BeeneticToolkit.Random.Utility {

    /// <summary>
    /// Provides utility methods for random operations, such as selecting random elements from collections.
    /// </summary>
    public static partial class RandomSelectors {

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
        /// <param name="random">The random number generator to use, or <c>null</c> to use the default generator.</param>
        /// <returns>A randomly selected element, weighted by the corresponding weights list.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the input list is empty or the lengths of the list and weights do not match.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when no valid item is selected. This could occur if the weights are improperly configured
        /// (e.g., all weights are zero or negative).
        /// </exception>
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

            if (selected == null)
                throw new InvalidOperationException("No valid item was selected. Ensure the weights are properly configured.");

            return selected;
        }

        /// <summary>
        /// Selects a random element from an IEnumerable sequence, with each element's likelihood of being chosen
        /// determined by its corresponding weight in a separate weight list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence from which to select a random weighted element.</param>
        /// <param name="weights">A list of weights corresponding to each element in the sequence.</param>
        /// <param name="random">The random number generator to use, or <c>null</c> to use the default generator.</param>
        /// <returns>A randomly selected element, weighted by the corresponding weights list.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the input sequence is empty or the lengths of the sequence and weights do not match.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when no valid item is selected. This could occur if the weights are improperly configured
        /// (e.g., all weights are zero or negative).
        /// </exception>
        public static T RandomWeightedChoice<T>(IEnumerable<T> sequence, IList<double> weights, RandomGenerator? random = null) {
            var list = sequence as IList<T> ?? sequence.ToList();

            return RandomWeightedChoice(list, weights, random);
        }

        /// <summary>
        /// Selects a random element from a dictionary, with each element's likelihood of being chosen
        /// determined by its associated weight.
        /// </summary>
        /// <typeparam name="T">The type of elements used as the dictionary's keys.</typeparam>
        /// <param name="typeWeightDict">The dictionary containing items as keys and their associated weights as values.</param>
        /// <param name="sortByAscending">
        /// A value indicating whether the dictionary should be sorted by weights in ascending order.
        /// If <c>false</c>, the dictionary will be sorted in descending order.
        /// </param>
        /// <param name="random">The random number generator to use, or <c>null</c> to use the default generator.</param>
        /// <returns>A randomly selected key from the dictionary, weighted by the corresponding values.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="typeWeightDict"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="typeWeightDict"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when no valid item is selected. This could occur if the weights are improperly configured
        /// (e.g., all weights are zero or negative).
        /// </exception>
        public static T RandomWeightedChoice<T>(Dictionary<T, double> typeWeightDict, bool sortByAscending = true, RandomGenerator? random = null) {
            random ??= RngManager.Current;

            if (typeWeightDict == null)
                throw new ArgumentNullException(nameof(typeWeightDict), "Dictionary cannot be null.");

            if (typeWeightDict.Count == 0)
                throw new ArgumentException("Dictionary cannot be empty.", nameof(typeWeightDict));

            if (sortByAscending)
                typeWeightDict = typeWeightDict.OrderBy(w => w.Value).ToDictionary(w => w.Key, w => w.Value);
            else
                typeWeightDict = typeWeightDict.OrderByDescending(w => w.Value).ToDictionary(w => w.Key, w => w.Value);

            T selected = default;
            double totalWeight = typeWeightDict.Values.Sum();
            double itemWeightIndex = random.NextDouble() * totalWeight;
            double currentWeightIndex = 0;

            foreach (var kvp in typeWeightDict) {
                currentWeightIndex += kvp.Value;
                if (currentWeightIndex >= itemWeightIndex) {
                    selected = kvp.Key;
                    break;
                }
            }

            if (selected == null)
                throw new InvalidOperationException("No valid item was selected. Ensure the weights are properly configured.");

            return selected;
        }

        #endregion Random Weighted Choice
    }
}