using System;

namespace BeeneticToolkit.Random.Noise {

    /// <summary>
    /// Convenience extensions over <see cref="INoise"/>.
    /// </summary>
    public static class NoiseExtensions {

        /// <summary>Samples the noise and remaps the result from <c>[-1, 1]</c> to <c>[0, 1]</c>.</summary>
        /// <param name="noise">The noise source.</param>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>A noise value in <c>[0, 1]</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="noise"/> is null.</exception>
        public static float Sample01(this INoise noise, float x, float y) {
            if (noise == null)
                throw new ArgumentNullException(nameof(noise));

            return noise.Sample(x, y) * 0.5f + 0.5f;
        }

        /// <summary>Samples the noise and remaps the result from <c>[-1, 1]</c> to <c>[0, 1]</c>.</summary>
        /// <param name="noise">The noise source.</param>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="z">The z coordinate.</param>
        /// <returns>A noise value in <c>[0, 1]</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="noise"/> is null.</exception>
        public static float Sample01(this INoise noise, float x, float y, float z) {
            if (noise == null)
                throw new ArgumentNullException(nameof(noise));

            return noise.Sample(x, y, z) * 0.5f + 0.5f;
        }
    }
}
