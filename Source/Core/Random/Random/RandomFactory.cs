using BeeneticToolkit.Random.Generators;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BeeneticToolkit.Tests")]

namespace BeeneticToolkit.Random {

    /// <summary>
    /// Defines the algorithms available for random number generation.
    /// </summary>
    public enum RandomAlgorithm {

        /// <summary>
        /// The xoshiro256** algorithm: fast, high-quality, 2^256-1 period. The default.
        /// </summary>
        Xoshiro256,

        /// <summary>
        /// Represents the Xorshift algorithm.
        /// </summary>
        Xorshift,

        /// <summary>
        /// Represents the Combined Linear Congruential Generator algorithm.
        /// </summary>
        CombinedLCG,

        /// <summary>
        /// Represents the Middle Square Weyl algorithm.
        /// </summary>
        MiddleSquare
    }

    /// <summary>
    /// Provides factory methods for creating random number generators based on different algorithms.
    /// </summary>
    public static class RandomFactory {

        /// <summary>
        /// Creates a random number generator using the default algorithm (xoshiro256**) without a specific seed.
        /// </summary>
        /// <returns>An instance of a random number generator.</returns>
        public static RandomGenerator GetGenerator() {
            return GetNewGenerator(RandomAlgorithm.Xoshiro256, null);
        }

        /// <summary>
        /// Creates a random number generator using the default algorithm (xoshiro256**) with a specified seed.
        /// </summary>
        /// <param name="seed">The seed for the random number generator.</param>
        /// <returns>An instance of a random number generator.</returns>
        public static RandomGenerator GetGenerator(long? seed) {
            return GetNewGenerator(RandomAlgorithm.Xoshiro256, seed);
        }

        /// <summary>
        /// Creates a random number generator using a specified algorithm without a specific seed.
        /// </summary>
        /// <param name="algorithm">The algorithm to be used for random number generation.</param>
        /// <returns>An instance of a random number generator.</returns>
        public static RandomGenerator GetGenerator(RandomAlgorithm algorithm) {
            return GetNewGenerator(algorithm, null);
        }

        /// <summary>
        /// Creates a random number generator using the specified algorithm and optional seed.
        /// </summary>
        /// <param name="algorithm">The algorithm to use for random number generation.</param>
        /// <param name="seed">The optional seed for the random number generator.</param>
        /// <returns>An instance of a random number generator.</returns>
        public static RandomGenerator GetGenerator(RandomAlgorithm algorithm, long? seed) {
            return GetNewGenerator(algorithm, seed);
        }

        /// <summary>
        /// Private method to handle the creation of random number generators based on the specified algorithm and seed.
        /// </summary>
        /// <param name="algorithm">The algorithm to be used for random number generation.</param>
        /// <param name="seed">Optional seed for the random number generator. Can be null.</param>
        /// <returns>An instance of a random number generator.</returns>
        private static RandomGenerator GetNewGenerator(RandomAlgorithm algorithm, long? seed) {
            return algorithm switch {
                RandomAlgorithm.Xoshiro256 => new Xoshiro256(seed),
                RandomAlgorithm.Xorshift => new Xorshift(seed),
                RandomAlgorithm.CombinedLCG => new CombinedLCG(seed),
                RandomAlgorithm.MiddleSquare => new MiddleSquare(seed),
                _ => throw new ArgumentOutOfRangeException(nameof(algorithm), $"The RNG algorithm '{algorithm}' is not supported.")
            };
        }
    }
}