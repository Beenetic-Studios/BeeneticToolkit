using System;

namespace BeeneticToolkit.Random.Probability {

    /// <summary>
    /// Models a gacha-style "pity" pull: each attempt succeeds with a base chance, but the longer a player goes
    /// without a success the better their odds get (optional soft pity), up to a guaranteed success at a hard
    /// pity ceiling. A success resets the counter.
    /// </summary>
    /// <remarks>
    /// The counter holds the streak state; randomness is supplied per pull, so a counter driven by a seeded
    /// generator reproduces exactly. Not thread-safe — one counter per player/stream.
    /// </remarks>
    public sealed class PityCounter {

        private readonly double _baseChance;
        private readonly int _hardPity;
        private readonly int _softPityStart;
        private readonly double _softPityIncrement;

        /// <summary>Creates a pity counter.</summary>
        /// <param name="baseChance">The base success chance per pull, in <c>[0, 1]</c>.</param>
        /// <param name="hardPity">
        /// The pull number on which success is guaranteed when every prior pull failed (the ceiling). For example
        /// <c>90</c> guarantees a success no later than the 90th consecutive pull. Must be greater than zero.
        /// </param>
        /// <param name="softPityStart">
        /// The number of consecutive failures after which the chance begins ramping up. Zero (the default)
        /// disables soft pity. Must be non-negative.
        /// </param>
        /// <param name="softPityIncrement">
        /// How much the success chance increases per pull once soft pity has started. Defaults to zero. Must be non-negative.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when any argument is outside its valid range.</exception>
        public PityCounter(double baseChance, int hardPity, int softPityStart = 0, double softPityIncrement = 0) {
            if (baseChance < 0 || baseChance > 1 || double.IsNaN(baseChance))
                throw new ArgumentOutOfRangeException(nameof(baseChance), "Base chance must be between 0 and 1.");
            if (hardPity <= 0)
                throw new ArgumentOutOfRangeException(nameof(hardPity), "Hard pity must be greater than zero.");
            if (softPityStart < 0)
                throw new ArgumentOutOfRangeException(nameof(softPityStart), "Soft pity start must be non-negative.");
            if (softPityIncrement < 0 || double.IsNaN(softPityIncrement))
                throw new ArgumentOutOfRangeException(nameof(softPityIncrement), "Soft pity increment must be non-negative.");

            _baseChance = baseChance;
            _hardPity = hardPity;
            _softPityStart = softPityStart;
            _softPityIncrement = softPityIncrement;
        }

        /// <summary>Gets the number of consecutive failures since the last success (or since creation/reset).</summary>
        public int Failures { get; private set; }

        /// <summary>
        /// Gets the success chance the <i>next</i> call to <see cref="Roll"/> will use, given the current failure
        /// streak. Returns <c>1.0</c> when the next pull has reached hard pity.
        /// </summary>
        public double CurrentChance => ChanceForPull(Failures + 1);

        /// <summary>Performs one pull, advancing or resetting the streak, and reports whether it succeeded.</summary>
        /// <param name="random">The generator to roll with.</param>
        /// <returns><c>true</c> on a success (the streak resets); <c>false</c> on a failure (the streak grows).</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> is null.</exception>
        public bool Roll(RandomGenerator random) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));

            int pull = Failures + 1;
            double chance = ChanceForPull(pull);

            // A guaranteed pull (chance >= 1) succeeds without consuming a draw, keeping the stream aligned.
            bool success = chance >= 1.0 || random.NextDouble() < chance;
            Failures = success ? 0 : Failures + 1;
            return success;
        }

        /// <summary>Resets the failure streak, as if no pulls had been made.</summary>
        public void Reset() => Failures = 0;

        /// <summary>Computes the success chance for the pull at the given 1-based position in the current streak.</summary>
        private double ChanceForPull(int pull) {
            if (pull >= _hardPity)
                return 1.0;

            double chance = _baseChance;
            if (_softPityIncrement > 0 && _softPityStart > 0 && pull > _softPityStart)
                chance += (pull - _softPityStart) * _softPityIncrement;

            return chance > 1.0 ? 1.0 : chance;
        }
    }
}
