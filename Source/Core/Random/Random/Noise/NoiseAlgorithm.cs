namespace BeeneticToolkit.Random.Noise {

    /// <summary>
    /// Identifies a coherent-noise algorithm produced by <see cref="NoiseFactory"/>.
    /// </summary>
    public enum NoiseAlgorithm {

        /// <summary>Value noise: interpolated pseudo-random lattice values. Cheapest; blockier character.</summary>
        Value,

        /// <summary>Perlin (gradient) noise: smoother and more natural than value noise. A good default.</summary>
        Perlin
    }
}
