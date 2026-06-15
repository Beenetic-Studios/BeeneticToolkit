using BeeneticToolkit.Random.Noise.Internal;
using System;

namespace BeeneticToolkit.Random.Noise {

    /// <summary>
    /// Creates <see cref="INoise"/> instances. The concrete algorithms are an implementation detail;
    /// this is the entry point for obtaining a seeded noise source.
    /// </summary>
    public static class NoiseFactory {

        /// <summary>
        /// Creates a seeded noise source for the given algorithm.
        /// </summary>
        /// <param name="algorithm">The noise algorithm to use.</param>
        /// <param name="seed">
        /// The seed. The same seed always produces the same field; any <see cref="long"/> is valid. Pass a
        /// <see cref="RandomEnvironment"/>'s <c>RootSeed</c> (or any value you control) to keep noise
        /// reproducible alongside the rest of a run.
        /// </param>
        /// <returns>A new <see cref="INoise"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="algorithm"/> is not a defined value.</exception>
        public static INoise Create(NoiseAlgorithm algorithm, long seed) {
            return algorithm switch {
                NoiseAlgorithm.Value => new ValueNoise(seed),
                NoiseAlgorithm.Perlin => new PerlinNoise(seed),
                _ => throw new ArgumentOutOfRangeException(nameof(algorithm), $"The noise algorithm '{algorithm}' is not supported.")
            };
        }
    }
}
