namespace BeeneticToolkit.Random.Noise.Internal {

    /// <summary>
    /// Value noise: pseudo-random values at integer lattice points, quintically interpolated.
    /// Output is exactly within <c>[-1, 1]</c>.
    /// </summary>
    internal sealed class ValueNoise : INoise {

        private readonly int m_Seed;

        internal ValueNoise(long seed) => m_Seed = unchecked((int)(seed ^ (seed >> 32)));

        public float Sample(float x, float y) {
            int x0 = NoiseHash.FastFloor(x);
            int y0 = NoiseHash.FastFloor(y);
            int x1 = x0 + 1;
            int y1 = y0 + 1;

            float u = NoiseHash.Fade(x - x0);
            float v = NoiseHash.Fade(y - y0);

            float nx0 = NoiseHash.Lerp(NoiseHash.Lattice(m_Seed, x0, y0), NoiseHash.Lattice(m_Seed, x1, y0), u);
            float nx1 = NoiseHash.Lerp(NoiseHash.Lattice(m_Seed, x0, y1), NoiseHash.Lattice(m_Seed, x1, y1), u);

            return NoiseHash.Lerp(nx0, nx1, v);
        }

        public float Sample(float x, float y, float z) {
            int x0 = NoiseHash.FastFloor(x);
            int y0 = NoiseHash.FastFloor(y);
            int z0 = NoiseHash.FastFloor(z);
            int x1 = x0 + 1;
            int y1 = y0 + 1;
            int z1 = z0 + 1;

            float u = NoiseHash.Fade(x - x0);
            float v = NoiseHash.Fade(y - y0);
            float w = NoiseHash.Fade(z - z0);

            float n000 = NoiseHash.Lattice(m_Seed, x0, y0, z0);
            float n100 = NoiseHash.Lattice(m_Seed, x1, y0, z0);
            float n010 = NoiseHash.Lattice(m_Seed, x0, y1, z0);
            float n110 = NoiseHash.Lattice(m_Seed, x1, y1, z0);
            float n001 = NoiseHash.Lattice(m_Seed, x0, y0, z1);
            float n101 = NoiseHash.Lattice(m_Seed, x1, y0, z1);
            float n011 = NoiseHash.Lattice(m_Seed, x0, y1, z1);
            float n111 = NoiseHash.Lattice(m_Seed, x1, y1, z1);

            float nx00 = NoiseHash.Lerp(n000, n100, u);
            float nx10 = NoiseHash.Lerp(n010, n110, u);
            float nx01 = NoiseHash.Lerp(n001, n101, u);
            float nx11 = NoiseHash.Lerp(n011, n111, u);

            float nxy0 = NoiseHash.Lerp(nx00, nx10, v);
            float nxy1 = NoiseHash.Lerp(nx01, nx11, v);

            return NoiseHash.Lerp(nxy0, nxy1, w);
        }
    }
}
