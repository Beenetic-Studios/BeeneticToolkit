namespace BeeneticToolkit.Random.Noise {

    /// <summary>
    /// A source of coherent noise sampled at scalar coordinates.
    /// </summary>
    /// <remarks>
    /// Implementations are deterministic for a given seed and produce values in the range <c>[-1, 1]</c>
    /// (value noise spans the range exactly; gradient noises such as Perlin are normalized to it).
    /// Sampling is allocation-free and instances are immutable, so they are safe to share across threads.
    /// </remarks>
    public interface INoise {

        /// <summary>Samples the noise field at the given 2D coordinate.</summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>A noise value in <c>[-1, 1]</c>.</returns>
        float Sample(float x, float y);

        /// <summary>Samples the noise field at the given 3D coordinate.</summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="z">The z coordinate.</param>
        /// <returns>A noise value in <c>[-1, 1]</c>.</returns>
        float Sample(float x, float y, float z);
    }
}
