using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Random {

    /// <summary>
    /// Extension methods on <see cref="RandomGenerator"/> for selecting random elements from collections:
    /// choice, exclusion, subset, and weighted choice. Each operates on the generator it is called on, so
    /// the source of randomness is always explicit.
    /// </summary>
    public static partial class RandomSelectors {

        #region Random Choice

        /// <summary>
        /// Selects a random element from a list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="random">The random number generator to use.</param>
        /// <param name="list">The list from which to select a random element.</param>
        /// <returns>A randomly selected element from the list.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> or <paramref name="list"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="list"/> is empty.</exception>
        public static T RandomChoice<T>(this RandomGenerator random, IList<T> list) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));
            if (list == null)
                throw new ArgumentNullException(nameof(list));
            if (list.Count == 0)
                throw new ArgumentException("List cannot be empty.", nameof(list));

            return list[random.NextInt(list.Count)];
        }

        /// <summary>
        /// Selects a random element from an IEnumerable sequence.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="random">The random number generator to use.</param>
        /// <param name="sequence">The sequence from which to select a random element.</param>
        /// <returns>A randomly selected element from the sequence.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> or <paramref name="sequence"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the converted list is empty.</exception>
        public static T RandomChoice<T>(this RandomGenerator random, IEnumerable<T> sequence) {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence));

            var list = sequence as IList<T> ?? sequence.ToList();
            return random.RandomChoice(list);
        }

        /// <summary>
        /// Selects a random element from a span, without allocating.
        /// </summary>
        /// <typeparam name="T">The type of elements in the span.</typeparam>
        /// <param name="random">The random number generator to use.</param>
        /// <param name="span">The span from which to select a random element.</param>
        /// <returns>A randomly selected element from the span.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="span"/> is empty.</exception>
        public static T RandomChoice<T>(this RandomGenerator random, ReadOnlySpan<T> span) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));
            if (span.IsEmpty)
                throw new ArgumentException("Span cannot be empty.", nameof(span));

            return span[random.NextInt(span.Length)];
        }

        #endregion Random Choice

        #region Random Choice With Exclusion

        /// <summary>
        /// Selects a random element from a list, excluding elements that match a specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="random">The random number generator to use.</param>
        /// <param name="list">The list from which to select a random element.</param>
        /// <param name="exclusionPredicate">A predicate to exclude elements from being selected.</param>
        /// <returns>A randomly selected element from the list that does not match the exclusion predicate.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/>, <paramref name="list"/>, or <paramref name="exclusionPredicate"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when no elements remain after applying the exclusion filter.</exception>
        public static T RandomChoiceWithExclusion<T>(this RandomGenerator random, IList<T> list, Func<T, bool> exclusionPredicate) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));
            if (list == null)
                throw new ArgumentNullException(nameof(list));
            if (exclusionPredicate == null)
                throw new ArgumentNullException(nameof(exclusionPredicate));

            List<T> filteredList = list.Where(item => !exclusionPredicate(item)).ToList();

            if (filteredList.Count == 0)
                throw new InvalidOperationException("No elements available after applying the exclusion filter.");

            return filteredList[random.NextInt(filteredList.Count)];
        }

        /// <summary>
        /// Selects a random element from an IEnumerable sequence, excluding elements that match a specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="random">The random number generator to use.</param>
        /// <param name="sequence">The sequence from which to select a random element.</param>
        /// <param name="exclusionPredicate">A predicate to exclude elements from being selected.</param>
        /// <returns>A randomly selected element from the sequence that does not match the exclusion predicate.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> or <paramref name="sequence"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when no elements remain after applying the exclusion filter.</exception>
        public static T RandomChoiceWithExclusion<T>(this RandomGenerator random, IEnumerable<T> sequence, Func<T, bool> exclusionPredicate) {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence));

            var list = sequence as IList<T> ?? sequence.ToList();
            return random.RandomChoiceWithExclusion(list, exclusionPredicate);
        }

        #endregion Random Choice With Exclusion

        #region Random Subset

        /// <summary>
        /// Selects a random subset of a specified size from a list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="random">The random number generator to use.</param>
        /// <param name="list">The list from which to select a random subset.</param>
        /// <param name="subsetSize">The size of the subset to select.</param>
        /// <returns>A list containing a random subset of the specified size.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> or <paramref name="list"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="list"/> is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="subsetSize"/> is less than or equal to 0, or greater than the list size.</exception>
        public static List<T> RandomSubset<T>(this RandomGenerator random, IList<T> list, int subsetSize) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));
            if (list == null)
                throw new ArgumentNullException(nameof(list));
            if (list.Count == 0)
                throw new ArgumentException("List cannot be empty.", nameof(list));

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
        /// <param name="random">The random number generator to use.</param>
        /// <param name="sequence">The sequence from which to select a random subset.</param>
        /// <param name="subsetSize">The size of the subset to select.</param>
        /// <returns>A list containing a random subset of the specified size.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> or <paramref name="sequence"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="subsetSize"/> is invalid for the list size.</exception>
        /// <remarks>Converts the sequence to a list before selecting the subset.</remarks>
        public static List<T> RandomSubset<T>(this RandomGenerator random, IEnumerable<T> sequence, int subsetSize) {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence));

            var list = sequence as IList<T> ?? sequence.ToList();
            return random.RandomSubset(list, subsetSize);
        }

        #endregion Random Subset

        #region Random Weighted Choice

        /// <summary>
        /// Selects a random element from a list, with each element's likelihood of being chosen
        /// determined by its corresponding weight in a separate weight list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="random">The random number generator to use.</param>
        /// <param name="list">The list from which to select a random weighted element.</param>
        /// <param name="weights">A list of weights corresponding to each element in the list.</param>
        /// <returns>A randomly selected element from the list, weighted by the corresponding weights.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/>, <paramref name="list"/>, or <paramref name="weights"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="list"/> is empty or the lengths of <paramref name="list"/> and <paramref name="weights"/> do not match.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the total weight is zero or no valid item can be selected.</exception>
        public static T RandomWeightedChoice<T>(this RandomGenerator random, IList<T> list, IList<double> weights) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));
            if (list == null || weights == null)
                throw new ArgumentNullException(list == null ? nameof(list) : nameof(weights));
            if (list.Count == 0)
                throw new ArgumentException("List cannot be empty.", nameof(list));
            if (list.Count != weights.Count)
                throw new ArgumentException("The lengths of the list and weights do not match.");

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
        /// <param name="random">The random number generator to use.</param>
        /// <param name="sequence">The sequence from which to select a random weighted element.</param>
        /// <param name="weights">A list of weights corresponding to each element in the sequence.</param>
        /// <returns>A randomly selected element from the sequence, weighted by the corresponding weights.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> or <paramref name="sequence"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the sequence is empty or lengths do not match.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the total weight is zero or no valid item can be selected.</exception>
        public static T RandomWeightedChoice<T>(this RandomGenerator random, IEnumerable<T> sequence, IList<double> weights) {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence));

            var list = sequence as IList<T> ?? sequence.ToList();
            return random.RandomWeightedChoice(list, weights);
        }

        /// <summary>
        /// Selects a random element from a dictionary, with each element's likelihood of being chosen
        /// determined by its associated weight.
        /// </summary>
        /// <typeparam name="T">The type of elements used as the dictionary's keys.</typeparam>
        /// <param name="random">The random number generator to use.</param>
        /// <param name="typeWeightDict">The dictionary containing items as keys and their associated weights as values.</param>
        /// <returns>A randomly selected key from the dictionary, weighted by the corresponding values.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> or <paramref name="typeWeightDict"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="typeWeightDict"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the total weight is zero or no valid item can be selected.</exception>
        public static T RandomWeightedChoice<T>(this RandomGenerator random, Dictionary<T, double> typeWeightDict) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));
            if (typeWeightDict == null)
                throw new ArgumentNullException(nameof(typeWeightDict), "Dictionary cannot be null.");
            if (typeWeightDict.Count == 0)
                throw new ArgumentException("Dictionary cannot be empty.", nameof(typeWeightDict));

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

        /// <summary>
        /// Selects a random element from a sequence of (item, weight) pairs, with each item's likelihood
        /// proportional to its weight.
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="random">The random number generator to use.</param>
        /// <param name="weightedItems">The items paired with their weights.</param>
        /// <returns>A randomly selected item, weighted by the paired weights.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> or <paramref name="weightedItems"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="weightedItems"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the total weight is not greater than zero.</exception>
        public static T RandomWeightedChoice<T>(this RandomGenerator random, IEnumerable<(T item, double weight)> weightedItems) {
            if (weightedItems == null)
                throw new ArgumentNullException(nameof(weightedItems));

            var items = new List<T>();
            var weights = new List<double>();
            foreach (var (item, weight) in weightedItems) {
                items.Add(item);
                weights.Add(weight);
            }

            return random.RandomWeightedChoice(items, weights);
        }

        /// <summary>
        /// Selects a random element from a sequence, with each item's likelihood proportional to the
        /// weight returned by <paramref name="weightSelector"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="random">The random number generator to use.</param>
        /// <param name="items">The items to choose from.</param>
        /// <param name="weightSelector">A function returning the weight for a given item.</param>
        /// <returns>A randomly selected item, weighted by <paramref name="weightSelector"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/>, <paramref name="items"/>, or <paramref name="weightSelector"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="items"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the total weight is not greater than zero.</exception>
        public static T RandomWeightedChoice<T>(this RandomGenerator random, IEnumerable<T> items, Func<T, double> weightSelector) {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            if (weightSelector == null)
                throw new ArgumentNullException(nameof(weightSelector));

            var itemList = items as IList<T> ?? items.ToList();
            var weights = new double[itemList.Count];
            for (int i = 0; i < itemList.Count; i++)
                weights[i] = weightSelector(itemList[i]);

            return random.RandomWeightedChoice(itemList, weights);
        }

        #endregion Random Weighted Choice
    }
}
