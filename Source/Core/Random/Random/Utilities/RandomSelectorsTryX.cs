using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Random.Utilities {

    public static partial class RandomSelectors {

        #region Try Random Choice

        /// <summary>
        /// Attempts to select a random element from a list without throwing exceptions.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list from which to select a random element. May be null or empty.</param>
        /// <param name="result">When this method returns, contains the randomly selected element if the operation succeeded; otherwise, the default value for <typeparamref name="T"/>.</param>
        /// <param name="random">The random number generator to use, or null to use the default generator.</param>
        /// <returns><c>true</c> if a random element was successfully selected; otherwise <c>false</c>.</returns>
        public static bool TryRandomChoice<T>(IList<T>? list, out T result, RandomGenerator? random = null) {
            if (list == null || list.Count == 0) {
                result = default!;
                return false;
            }

            random ??= RandomManager.Current;
            result = list[random.NextInt(list.Count)];
            return true;
        }

        /// <summary>
        /// Attempts to select a random element from an <see cref="IEnumerable{T}"/> sequence without throwing exceptions.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence from which to select a random element. May be null or empty.</param>
        /// <param name="result">When this method returns, contains the randomly selected element if the operation succeeded; otherwise, the default value for <typeparamref name="T"/>.</param>
        /// <param name="random">The random number generator to use, or null to use the default generator.</param>
        /// <returns><c>true</c> if a random element was successfully selected; otherwise <c>false</c>.</returns>
        public static bool TryRandomChoice<T>(IEnumerable<T>? sequence, out T result, RandomGenerator? random = null) {
            if (sequence == null) {
                result = default!;
                return false;
            }

            var list = sequence as IList<T> ?? sequence.ToList();
            return TryRandomChoice(list, out result, random);
        }

        #endregion Try Random Choice

        #region Try Random Choice With Exclusion

        /// <summary>
        /// Attempts to select a random element from a list, excluding elements that match a specified predicate, without throwing exceptions.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list from which to select a random element. May be null or empty.</param>
        /// <param name="exclusionPredicate">A predicate to exclude elements from being selected. May be null.</param>
        /// <param name="result">When this method returns, contains the randomly selected element if the operation succeeded; otherwise, the default value for <typeparamref name="T"/>.</param>
        /// <param name="random">The random number generator to use, or null to use the default generator.</param>
        /// <returns><c>true</c> if a valid random element was successfully selected; otherwise <c>false</c>.</returns>
        public static bool TryRandomChoiceWithExclusion<T>(IList<T>? list, Func<T, bool>? exclusionPredicate, out T result, RandomGenerator? random = null) {
            if (list == null || exclusionPredicate == null) {
                result = default!;
                return false;
            }

            random ??= RandomManager.Current;
            var filteredList = list.Where(item => !exclusionPredicate(item)).ToList();

            if (filteredList.Count == 0) {
                result = default!;
                return false;
            }

            result = filteredList[random.NextInt(filteredList.Count)];
            return true;
        }

        /// <summary>
        /// Attempts to select a random element from an <see cref="IEnumerable{T}"/> sequence, excluding elements that match a specified predicate, without throwing exceptions.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence from which to select a random element. May be null or empty.</param>
        /// <param name="exclusionPredicate">A predicate to exclude elements from being selected. May be null.</param>
        /// <param name="result">When this method returns, contains the randomly selected element if the operation succeeded; otherwise, the default value for <typeparamref name="T"/>.</param>
        /// <param name="random">The random number generator to use, or null to use the default generator.</param>
        /// <returns><c>true</c> if a valid random element was successfully selected; otherwise <c>false</c>.</returns>
        public static bool TryRandomChoiceWithExclusion<T>(IEnumerable<T>? sequence, Func<T, bool>? exclusionPredicate, out T result, RandomGenerator? random = null) {
            if (sequence == null) {
                result = default!;
                return false;
            }

            var list = sequence as IList<T> ?? sequence.ToList();
            return TryRandomChoiceWithExclusion(list, exclusionPredicate, out result, random);
        }

        #endregion Try Random Choice With Exclusion

        #region Try Random Subset

        /// <summary>
        /// Attempts to select a random subset of a specified size from a list without throwing exceptions.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list from which to select a random subset. May be null or empty.</param>
        /// <param name="subsetSize">The desired size of the subset. Must be greater than 0 and less than or equal to the list size.</param>
        /// <param name="result">When this method returns, contains the random subset if the operation succeeded; otherwise, null.</param>
        /// <param name="random">The random number generator to use, or null to use the default generator.</param>
        /// <returns><c>true</c> if a valid subset was successfully selected; otherwise <c>false</c>.</returns>
        public static bool TryRandomSubset<T>(IList<T>? list, int subsetSize, out List<T>? result, RandomGenerator? random = null) {
            if (list == null || list.Count == 0 || subsetSize <= 0 || subsetSize > list.Count) {
                result = null;
                return false;
            }

            random ??= RandomManager.Current;

            List<T> shuffledList = new List<T>(list);
            for (int i = 0; i < subsetSize; i++) {
                int j = random.NextInt(i, list.Count);
                (shuffledList[i], shuffledList[j]) = (shuffledList[j], shuffledList[i]);
            }

            result = shuffledList.GetRange(0, subsetSize);
            return true;
        }

        /// <summary>
        /// Attempts to select a random subset of a specified size from an <see cref="IEnumerable{T}"/> sequence without throwing exceptions.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence from which to select a random subset. May be null or empty.</param>
        /// <param name="subsetSize">The desired size of the subset. Must be greater than 0 and less than or equal to the sequence size.</param>
        /// <param name="result">When this method returns, contains the random subset if the operation succeeded; otherwise, null.</param>
        /// <param name="random">The random number generator to use, or null to use the default generator.</param>
        /// <returns><c>true</c> if a valid subset was successfully selected; otherwise <c>false</c>.</returns>
        public static bool TryRandomSubset<T>(IEnumerable<T>? sequence, int subsetSize, out List<T>? result, RandomGenerator? random = null) {
            if (sequence == null) {
                result = null;
                return false;
            }

            var list = sequence as IList<T> ?? sequence.ToList();
            return TryRandomSubset(list, subsetSize, out result, random);
        }

        #endregion Try Random Subset

        #region Try Random Weighted Choice

        /// <summary>
        /// Attempts to select a random element from a list, with each element's likelihood determined by a corresponding weight, without throwing exceptions.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list from which to select a random element. May be null or empty.</param>
        /// <param name="weights">A list of weights corresponding to each element in the list. May be null.</param>
        /// <param name="result">When this method returns, contains the randomly selected element if the operation succeeded; otherwise, the default value for <typeparamref name="T"/>.</param>
        /// <param name="random">The random number generator to use, or null to use the default generator.</param>
        /// <returns><c>true</c> if a weighted random element was successfully selected; otherwise <c>false</c>.</returns>
        public static bool TryRandomWeightedChoice<T>(IList<T>? list, IList<double>? weights, out T result, RandomGenerator? random = null) {
            if (list == null || weights == null || list.Count == 0 || list.Count != weights.Count) {
                result = default!;
                return false;
            }

            double totalWeight = weights.Sum();
            if (totalWeight <= 0) {
                result = default!;
                return false;
            }

            random ??= RandomManager.Current;
            double itemWeightIndex = random.NextDouble() * totalWeight;
            double currentWeightIndex = 0;

            for (int i = 0; i < list.Count; ++i) {
                currentWeightIndex += weights[i];
                if (currentWeightIndex >= itemWeightIndex) {
                    result = list[i];
                    return true;
                }
            }

            result = default;
            return false;
        }

        /// <summary>
        /// Attempts to select a random element from an <see cref="IEnumerable{T}"/> sequence, with each element's likelihood determined by a corresponding weight, without throwing exceptions.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence from which to select a random element. May be null or empty.</param>
        /// <param name="weights">A list of weights corresponding to each element in the sequence. May be null.</param>
        /// <param name="result">When this method returns, contains the randomly selected element if the operation succeeded; otherwise, the default value for <typeparamref name="T"/>.</param>
        /// <param name="random">The random number generator to use, or null to use the default generator.</param>
        /// <returns><c>true</c> if a weighted random element was successfully selected; otherwise <c>false</c>.</returns>
        public static bool TryRandomWeightedChoice<T>(IEnumerable<T>? sequence, IList<double>? weights, out T result, RandomGenerator? random = null) {
            if (sequence == null) {
                result = default!;
                return false;
            }

            var list = sequence as IList<T> ?? sequence.ToList();
            return TryRandomWeightedChoice(list, weights, out result, random);
        }

        /// <summary>
        /// Attempts to select a random element from a dictionary, with each element's likelihood determined by its associated weight, without throwing exceptions.
        /// </summary>
        /// <typeparam name="T">The type of keys in the dictionary.</typeparam>
        /// <param name="typeWeightDict">The dictionary containing items as keys and their associated weights as values. May be null or empty.</param>
        /// <param name="result">When this method returns, contains the randomly selected key if the operation succeeded; otherwise, the default value for <typeparamref name="T"/>.</param>
        /// <param name="random">The random number generator to use, or null to use the default generator.</param>
        /// <returns><c>true</c> if a weighted random key was successfully selected; otherwise <c>false</c>.</returns>
        public static bool TryRandomWeightedChoice<T>(Dictionary<T, double>? typeWeightDict, out T result, RandomGenerator? random = null) {
            if (typeWeightDict == null || typeWeightDict.Count == 0) {
                result = default!;
                return false;
            }

            double totalWeight = typeWeightDict.Values.Sum();
            if (totalWeight <= 0) {
                result = default!;
                return false;
            }

            random ??= RandomManager.Current;
            double itemWeightIndex = random.NextDouble() * totalWeight;
            double currentWeightIndex = 0;

            foreach (var kvp in typeWeightDict) {
                currentWeightIndex += kvp.Value;
                if (currentWeightIndex >= itemWeightIndex) {
                    result = kvp.Key;
                    return true;
                }
            }

            result = default!;
            return false;
        }

        #endregion Try Random Weighted Choice
    }
}