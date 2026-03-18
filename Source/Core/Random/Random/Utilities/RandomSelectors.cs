using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Random.Utilities {

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
        /// <exception cref="ArgumentException">Thrown when <paramref name="list"/> is null or empty.</exception>
        public static T RandomChoice<T>(IList<T> list, RandomGenerator? random = null) {
            if (list == null || list.Count == 0)
                throw new ArgumentException("List cannot be null or empty.", nameof(list));

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
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="sequence"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the converted list is empty.</exception>
        public static T RandomChoice<T>(IEnumerable<T> sequence, RandomGenerator? random = null) {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence));

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
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="list"/> or <paramref name="exclusionPredicate"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when no elements remain after applying the exclusion filter.</exception>
        public static T RandomChoiceWithExclusion<T>(IList<T> list, Func<T, bool> exclusionPredicate, RandomGenerator? random = null) {
            if (list == null)
                throw new ArgumentNullException(nameof(list));
            if (exclusionPredicate == null)
                throw new ArgumentNullException(nameof(exclusionPredicate));

            random ??= RngManager.Current;
            List<T> filteredList = list.Where(item => !exclusionPredicate(item)).ToList();

            if (filteredList.Count == 0)
                throw new InvalidOperationException("No elements available after applying the exclusion filter.");

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
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="sequence"/> or <paramref name="exclusionPredicate"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when no elements remain after applying the exclusion filter.</exception>
        public static T RandomChoiceWithExclusion<T>(IEnumerable<T> sequence, Func<T, bool> exclusionPredicate, RandomGenerator? random = null) {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence));

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
        /// <exception cref="ArgumentException">Thrown when <paramref name="list"/> is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="subsetSize"/> is less than or equal to 0, or greater than the list size.</exception>
        public static List<T> RandomSubset<T>(IList<T> list, int subsetSize, RandomGenerator? random = null) {
            if (list == null || list.Count == 0)
                throw new ArgumentException("List cannot be null or empty.", nameof(list));

            if (subsetSize <= 0 || subsetSize > list.Count)
                throw new ArgumentOutOfRangeException(nameof(subsetSize), subsetSize,
                    "Subset size must be larger than 0 and less than or equal to the list size.");

            random ??= RngManager.Current;

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
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="sequence"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="subsetSize"/> is invalid for the list size.</exception>
        /// <remarks>Converts the sequence to a list before selecting the subset.</remarks>
        public static List<T> RandomSubset<T>(IEnumerable<T> sequence, int subsetSize, RandomGenerator? random = null) {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence));

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
        /// <returns>A randomly selected element from the list, weighted by the corresponding weights.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="list"/> or <paramref name="weights"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="list"/> is empty or the lengths of <paramref name="list"/> and <paramref name="weights"/> do not match.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the total weight is zero or no valid item can be selected.</exception>
        public static T RandomWeightedChoice<T>(IList<T> list, IList<double> weights, RandomGenerator? random = null) {
            if (list == null || weights == null)
                throw new ArgumentNullException(list == null ? nameof(list) : nameof(weights));
            if (list.Count == 0)
                throw new ArgumentException("List cannot be empty.", nameof(list));
            if (list.Count != weights.Count)
                throw new ArgumentException("The lengths of the list and weights do not match.");

            random ??= RngManager.Current;

            double totalWeight = weights.Sum();
            if (totalWeight <= 0)
                throw new InvalidOperationException("Total weight must be greater than zero.");

            double itemWeightIndex = random.NextDouble() * totalWeight;
            double currentWeightIndex = 0;

            for (int i = 0; i < list.Count; ++i) {
                currentWeightIndex += weights[i];
                if (currentWeightIndex >= itemWeightIndex)
                    return list[i];
            }

            throw new InvalidOperationException("No valid item was selected. Ensure the weights are properly configured.");
        }

        /// <summary>
        /// Selects a random element from an <see cref="IEnumerable{T}"/> sequence, with each element's likelihood of being chosen
        /// determined by its corresponding weight in a separate weight list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence from which to select a random weighted element.</param>
        /// <param name="weights">A list of weights corresponding to each element in the sequence.</param>
        /// <param name="random">The random number generator to use, or <c>null</c> to use the default generator.</param>
        /// <returns>A randomly selected element from the sequence, weighted by the corresponding weights.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="sequence"/> or <paramref name="weights"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the sequence is empty or lengths do not match.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the total weight is zero or no valid item can be selected.</exception>
        public static T RandomWeightedChoice<T>(IEnumerable<T> sequence, IList<double> weights, RandomGenerator? random = null) {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence));

            var list = sequence as IList<T> ?? sequence.ToList();
            return RandomWeightedChoice(list, weights, random);
        }

        /// <summary>
        /// Selects a random element from a dictionary, with each element's likelihood of being chosen
        /// determined by its associated weight.
        /// </summary>
        /// <typeparam name="T">The type of elements used as the dictionary's keys.</typeparam>
        /// <param name="typeWeightDict">The dictionary containing items as keys and their associated weights as values.</param>
        /// <param name="random">The random number generator to use, or <c>null</c> to use the default generator.</param>
        /// <returns>A randomly selected key from the dictionary, weighted by the corresponding values.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="typeWeightDict"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="typeWeightDict"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the total weight is zero or no valid item can be selected.</exception>
        public static T RandomWeightedChoice<T>(Dictionary<T, double> typeWeightDict, RandomGenerator? random = null) {
            if (typeWeightDict == null)
                throw new ArgumentNullException(nameof(typeWeightDict), "Dictionary cannot be null.");
            if (typeWeightDict.Count == 0)
                throw new ArgumentException("Dictionary cannot be empty.", nameof(typeWeightDict));

            random ??= RngManager.Current;

            double totalWeight = typeWeightDict.Values.Sum();
            if (totalWeight <= 0)
                throw new InvalidOperationException("Total weight must be greater than zero.");

            double itemWeightIndex = random.NextDouble() * totalWeight;
            double currentWeightIndex = 0;

            foreach (var kvp in typeWeightDict) {
                currentWeightIndex += kvp.Value;
                if (currentWeightIndex >= itemWeightIndex)
                    return kvp.Key;
            }

            throw new InvalidOperationException("No valid item was selected. Ensure the weights are properly configured.");
        }

        #endregion Random Weighted Choice
    }
}