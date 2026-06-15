using BeeneticToolkit.Random.Noise.Internal;
using System;

namespace BeeneticToolkit.Random.Noise {

    /// <summary>
    /// Layers a base <see cref="INoise"/> into fractal Brownian motion (fBm): several octaves of the source
    /// at increasing frequency and decreasing amplitude, summed and normalized back into <c>[-1, 1]</c>.
    /// This is what turns a single noise field into natural-looking terrain and textures.
    /// </summary>
    public sealed class FractalNoise : INoise {

        private readonly INoise m_Source;
        private readonly int m_Octaves;
        private readonly float m_Frequency;
        private readonly float m_Lacunarity;
        private readonly float m_Gain;
        private readonly float m_Normalization;

        /// <summary>
        /// Initializes a new fractal noise over the given source.
        /// </summary>
        /// <param name="source">The base noise to layer.</param>
        /// <param name="octaves">The number of layers. Must be at least 1.</param>
        /// <param name="frequency">The frequency of the first octave (coordinate scale). Must be greater than 0.</param>
        /// <param name="lacunarity">The per-octave frequency multiplier (typically 2). Must be greater than 0.</param>
        /// <param name="gain">The per-octave amplitude multiplier (typically 0.5). Must be in (0, 1].</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when a numeric argument is out of range.</exception>
        public FractalNoise(INoise source, int octaves = 4, float frequency = 1f, float lacunarity = 2f, float gain = 0.5f) {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (octaves < 1)
                throw new ArgumentOutOfRangeException(nameof(octaves), "Octaves must be at least 1.");
            if (frequency <= 0f)
                throw new ArgumentOutOfRangeException(nameof(frequency), "Frequency must be greater than 0.");
            if (lacunarity <= 0f)
                throw new ArgumentOutOfRangeException(nameof(lacunarity), "Lacunarity must be greater than 0.");
            if (gain <= 0f || gain > 1f)
                throw new ArgumentOutOfRangeException(nameof(gain), "Gain must be in the range (0, 1].");

            m_Source = source;
            m_Octaves = octaves;
            m_Frequency = frequency;
            m_Lacunarity = lacunarity;
            m_Gain = gain;

            // Normalize by the total amplitude so the summed octaves stay within the source's [-1, 1] range.
            float amplitude = 1f;
            float total = 0f;
            for (int i = 0; i < octaves; i++) {
                total += amplitude;
                amplitude *= gain;
            }
            m_Normalization = total > 0f ? 1f / total : 1f;
        }

        /// <inheritdoc/>
        public float Sample(float x, float y) {
            float frequency = m_Frequency;
            float amplitude = 1f;
            float sum = 0f;

            for (int i = 0; i < m_Octaves; i++) {
                sum += m_Source.Sample(x * frequency, y * frequency) * amplitude;
                frequency *= m_Lacunarity;
                amplitude *= m_Gain;
            }

            return sum * m_Normalization;
        }

        /// <inheritdoc/>
        public float Sample(float x, float y, float z) {
            float frequency = m_Frequency;
            float amplitude = 1f;
            float sum = 0f;

            for (int i = 0; i < m_Octaves; i++) {
                sum += m_Source.Sample(x * frequency, y * frequency, z * frequency) * amplitude;
                frequency *= m_Lacunarity;
                amplitude *= m_Gain;
            }

            return sum * m_Normalization;
        }
    }
}
