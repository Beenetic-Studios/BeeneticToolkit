using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Random.Probability {

    /// <summary>
    /// A weighted drop table that yields one outcome per roll, with each entry's likelihood proportional to its
    /// weight. Entries can be concrete items or <i>nested tables</i>, so tiered loot ("80% common pool, 20% rare
    /// pool, and the rare pool itself splits further") composes naturally.
    /// </summary>
    /// <remarks>
    /// Unlike a <see cref="WeightedBag{T}"/>, rolling a loot table never removes anything — every roll sees the
    /// full table. Randomness is supplied at roll time, so a table rolled from the same seeded generator always
    /// produces the same results. Not thread-safe while being mutated.
    /// </remarks>
    /// <typeparam name="T">The type of item the table drops.</typeparam>
    public sealed class LootTable<T> {

        private readonly List<Entry> _entries = new List<Entry>();
        private double _totalWeight;

        /// <summary>Gets the number of top-level entries in this table.</summary>
        public int Count => _entries.Count;

        /// <summary>Gets the sum of the weights of every top-level entry.</summary>
        public double TotalWeight => _totalWeight;

        /// <summary>Adds an item entry. Returns the table so calls can be chained.</summary>
        /// <param name="item">The item this entry drops.</param>
        /// <param name="weight">The relative likelihood of this entry. Must be greater than zero.</param>
        /// <returns>This table, for fluent chaining.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="weight"/> is not greater than zero.</exception>
        public LootTable<T> Add(T item, double weight = 1.0) {
            ValidateWeight(weight);
            _entries.Add(Entry.ForItem(item, weight));
            _totalWeight += weight;
            return this;
        }

        /// <summary>Adds a nested table entry. Rolling this entry rolls <paramref name="table"/> in turn.</summary>
        /// <param name="table">The nested table to roll into.</param>
        /// <param name="weight">The relative likelihood of descending into this table. Must be greater than zero.</param>
        /// <returns>This table, for fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="table"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="weight"/> is not greater than zero.</exception>
        public LootTable<T> AddTable(LootTable<T> table, double weight = 1.0) {
            if (table == null)
                throw new ArgumentNullException(nameof(table));
            ValidateWeight(weight);

            _entries.Add(Entry.ForTable(table, weight));
            _totalWeight += weight;
            return this;
        }

        /// <summary>Rolls the table once, descending into nested tables, and returns the resulting item.</summary>
        /// <param name="random">The generator to roll with.</param>
        /// <returns>The dropped item.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when this table (or a nested table reached during the roll) is empty.</exception>
        public T Roll(RandomGenerator random) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));

            return RollInternal(random);
        }

        /// <summary>Rolls the table <paramref name="rolls"/> times independently, returning every dropped item.</summary>
        /// <param name="random">The generator to roll with.</param>
        /// <param name="rolls">The number of independent rolls. Must be non-negative.</param>
        /// <returns>A list of the dropped items, one per roll.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="rolls"/> is negative.</exception>
        /// <exception cref="InvalidOperationException">Thrown when this table (or a nested table reached during a roll) is empty.</exception>
        public List<T> Roll(RandomGenerator random, int rolls) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));
            if (rolls < 0)
                throw new ArgumentOutOfRangeException(nameof(rolls), "The number of rolls must be non-negative.");

            var results = new List<T>(rolls);
            for (int i = 0; i < rolls; i++)
                results.Add(RollInternal(random));

            return results;
        }

        /// <summary>Attempts to roll the table once, returning false instead of throwing when the table is empty.</summary>
        /// <param name="random">The generator to roll with.</param>
        /// <param name="item">When this method returns true, the dropped item; otherwise the default value.</param>
        /// <returns><c>true</c> if an item was rolled; <c>false</c> when the table is empty.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when a non-empty nested table reached during the roll is itself empty.</exception>
        public bool TryRoll(RandomGenerator random, out T item) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));
            if (_entries.Count == 0) {
                item = default!;
                return false;
            }

            item = RollInternal(random);
            return true;
        }

        private T RollInternal(RandomGenerator random) {
            if (_entries.Count == 0)
                throw new InvalidOperationException("Cannot roll an empty loot table.");

            double target = random.NextDouble() * _totalWeight;
            double cumulative = 0;
            Entry chosen = _entries[_entries.Count - 1]; // floating-point fallback
            for (int i = 0; i < _entries.Count; i++) {
                cumulative += _entries[i].Weight;
                if (target < cumulative) {
                    chosen = _entries[i];
                    break;
                }
            }

            return chosen.IsTable ? chosen.Table.RollInternal(random) : chosen.Item;
        }

        private static void ValidateWeight(double weight) {
            if (weight <= 0 || double.IsNaN(weight))
                throw new ArgumentOutOfRangeException(nameof(weight), "Weight must be greater than zero.");
        }

        private readonly struct Entry {
            public readonly double Weight;
            public readonly T Item;
            public readonly LootTable<T> Table;
            public readonly bool IsTable;

            private Entry(double weight, T item, LootTable<T> table, bool isTable) {
                Weight = weight;
                Item = item;
                Table = table;
                IsTable = isTable;
            }

            public static Entry ForItem(T item, double weight) => new Entry(weight, item, null!, false);
            public static Entry ForTable(LootTable<T> table, double weight) => new Entry(weight, default!, table, true);
        }
    }
}
