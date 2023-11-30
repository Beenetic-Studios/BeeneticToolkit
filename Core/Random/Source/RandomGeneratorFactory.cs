namespace BeeneticToolkit.Random {

    /// <summary>
    /// Defines the algorithms available for random number generation.
    /// </summary>
    public enum RngAlgorithm {

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
    public static class RandomGeneratorFactory {

        /// <summary>
        /// Creates a random number generator using the default algorithm (Xorshift) without a specific seed.
        /// </summary>
        /// <returns>An instance of a random number generator.</returns>
        public static RandomGeneratorBase GetGenerator() {
            return GetGenerator(RngAlgorithm.Xorshift, null);
        }

        /// <summary>
        /// Creates a random number generator using the default algorithm (Xorshift) with a specified seed.
        /// </summary>
        /// <param name="seed">The seed for the random number generator.</param>
        /// <returns>An instance of a random number generator.</returns>
        public static RandomGeneratorBase GetGenerator(long seed) {
            return GetGenerator(RngAlgorithm.Xorshift, seed);
        }

        /// <summary>
        /// Creates a random number generator using a specified algorithm without a specific seed.
        /// </summary>
        /// <param name="algorithm">The algorithm to be used for random number generation.</param>
        /// <returns>An instance of a random number generator.</returns>
        public static RandomGeneratorBase GetGenerator(RngAlgorithm algorithm) {
            return GetGenerator(algorithm, null);
        }

        /// <summary>
        /// Creates a random number generator using a specified algorithm and seed.
        /// </summary>
        /// <param name="seed">The seed for the random number generator.</param>
        /// <param name="algorithm">The algorithm to be used for random number generation.</param>
        /// <returns>An instance of a random number generator.</returns>
        public static RandomGeneratorBase GetGenerator(long seed, RngAlgorithm algorithm) {
            return GetGenerator(algorithm, seed);
        }

        /// <summary>
        /// Private method to handle the creation of random number generators based on the specified algorithm and seed.
        /// </summary>
        /// <param name="algorithm">The algorithm to be used for random number generation.</param>
        /// <param name="seed">Optional seed for the random number generator. Can be null.</param>
        /// <returns>An instance of a random number generator.</returns>
        private static RandomGeneratorBase GetGenerator(RngAlgorithm algorithm, long? seed) {
            return algorithm switch {
                RngAlgorithm.Xorshift => new Xorshift(seed),
                RngAlgorithm.CombinedLCG => new CombinedLCG(seed),
                RngAlgorithm.MiddleSquare => new MiddleSquare(seed),
                _ => new Xorshift(seed),
            };
        }
    }
}