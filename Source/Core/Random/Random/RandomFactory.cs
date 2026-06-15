using BeeneticToolkit.Random.Generators;
using System;

namespace BeeneticToolkit.Random.Internal {

    /// <summary>
    /// Internal factory that maps a <see cref="RandomAlgorithm"/> and a concrete seed to a generator
    /// instance. This is an implementation detail of the environment system: generators are obtained
    /// through <see cref="RandomEnvironment"/> (or <see cref="RandomManager.Scratch"/>), never directly,
    /// so every generator's seed is governed.
    /// </summary>
    internal static class RandomFactory {

        /// <summary>
        /// Creates a generator using the specified algorithm and seed.
        /// </summary>
        /// <param name="algorithm">The algorithm to use for random number generation.</param>
        /// <param name="seed">The seed for the generator. Must be greater than 0.</param>
        /// <returns>A new <see cref="RandomGenerator"/> instance.</returns>
        public static RandomGenerator GetGenerator(RandomAlgorithm algorithm, long seed) {
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
