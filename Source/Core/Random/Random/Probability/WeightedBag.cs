using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Random.Probability {

    /// <summary>
    /// A mutable collection of weighted items that can be drawn from at random — either <i>with</i> replacement
    /// (the item stays in the bag) or <i>without</i> replacement (the item is removed, so the bag depletes).
    /// </summary>
    /// <remarks>
    /// The bag holds no randomness of its own: a <see cref="RandomGenerator"/> is supplied at draw time, so the
    /// same bag drawn from the same seeded generator always produces the same sequence. The bag itself is not
    /// thread-safe; give each thread its own bag and generator.
    /// </remarks>
    /// <typeparam name="T">The type of item held in the bag.</typeparam>
    public sealed class WeightedBag<T> {

        private readonly List<T> _items;
        private readonly List<double> _weights;
        private double _totalWeight;

        /// <summary>Creates an empty bag.</summary>
        public WeightedBag() {
            _items = new List<T>();
            _weights = new List<double>();
        }

        /// <summary>Creates a bag pre-populated from a sequence of (item, weight) pairs.</summary>
        /// <param name="items">The items and their weights. Each weight must be greater than zero.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="items"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when any weight is not greater than zero.</exception>
        public WeightedBag(IEnumerable<(T item, double weight)> items) : this() {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            foreach (var (item, weight) in items)
                Add(item, weight);
        }

        /// <summary>Gets the number of items currently in the bag.</summary>
        public int Count => _items.Count;

        /// <summary>Gets the sum of the weights of every item currently in the bag.</summary>
        public double TotalWeight => _totalWeight;

        /// <summary>Adds an item with the given weight. Returns the bag so calls can be chained.</summary>
        /// <param name="item">The item to add.</param>
        /// <param name="weight">The relative likelihood of drawing this item. Must be greater than zero.</param>
        /// <returns>This bag, for fluent chaining.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="weight"/> is not greater than zero.</exception>
        public WeightedBag<T> Add(T item, double weight) {
            if (weight <= 0 || double.IsNaN(weight))
                throw new ArgumentOutOfRangeException(nameof(weight), "Weight must be greater than zero.");

            _items.Add(item);
            _weights.Add(weight);
            _totalWeight += weight;
            return this;
        }

        /// <summary>Draws a random item weighted by its weight, leaving the bag unchanged.</summary>
        /// <param name="random">The generator to draw from.</param>
        /// <returns>A randomly selected item.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the bag is empty.</exception>
        public T Draw(RandomGenerator random) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));
            if (_items.Count == 0)
                throw new InvalidOperationException("Cannot draw from an empty bag.");

            return _items[PickIndex(random)];
        }

        /// <summary>Draws a random item weighted by its weight and removes it from the bag.</summary>
        /// <param name="random">The generator to draw from.</param>
        /// <returns>The drawn item, now removed from the bag.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the bag is empty.</exception>
        public T DrawWithoutReplacement(RandomGenerator random) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));
            if (_items.Count == 0)
                throw new InvalidOperationException("Cannot draw from an empty bag.");

            int index = PickIndex(random);
            T item = _items[index];
            RemoveAt(index);
            return item;
        }

        /// <summary>Attempts to draw a random item weighted by its weight, leaving the bag unchanged.</summary>
        /// <param name="random">The generator to draw from.</param>
        /// <param name="item">When this method returns true, the drawn item; otherwise the default value.</param>
        /// <returns><c>true</c> if an item was drawn; <c>false</c> when the bag is empty.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> is null.</exception>
        public bool TryDraw(RandomGenerator random, out T item) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));
            if (_items.Count == 0) {
                item = default!;
                return false;
            }

            item = _items[PickIndex(random)];
            return true;
        }

        /// <summary>Attempts to draw a random item weighted by its weight and remove it from the bag.</summary>
        /// <param name="random">The generator to draw from.</param>
        /// <param name="item">When this method returns true, the drawn item; otherwise the default value.</param>
        /// <returns><c>true</c> if an item was drawn; <c>false</c> when the bag is empty.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> is null.</exception>
        public bool TryDrawWithoutReplacement(RandomGenerator random, out T item) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));
            if (_items.Count == 0) {
                item = default!;
                return false;
            }

            int index = PickIndex(random);
            item = _items[index];
            RemoveAt(index);
            return true;
        }

        /// <summary>Removes every item from the bag.</summary>
        public void Clear() {
            _items.Clear();
            _weights.Clear();
            _totalWeight = 0;
        }

        /// <summary>Selects an index in <c>[0, Count)</c> with probability proportional to its weight.</summary>
        private int PickIndex(RandomGenerator random) {
            double target = random.NextDouble() * _totalWeight;
            double cumulative = 0;
            for (int i = 0; i < _weights.Count; i++) {
                cumulative += _weights[i];
                if (target < cumulative)
                    return i;
            }

            // Floating-point round-off can leave target at the very top of the range; fall back to the last item.
            return _weights.Count - 1;
        }

        private void RemoveAt(int index) {
            _totalWeight -= _weights[index];
            _items.RemoveAt(index);
            _weights.RemoveAt(index);
            if (_items.Count == 0)
                _totalWeight = 0; // clear accumulated round-off once the bag empties
        }
    }
}
