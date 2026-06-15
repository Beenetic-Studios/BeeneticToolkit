namespace BeeneticToolkit.Random.Noise.Internal {

    /// <summary>
    /// Improved Perlin (gradient) noise. With unit-length gradients the raw output is bounded by
    /// <c>sqrt(N)/2</c> in N dimensions, so it is scaled by <c>2/sqrt(N)</c> to fill <c>[-1, 1]</c>.
    /// Returns 0 exactly at integer lattice points (a defining property of gradient noise).
    /// </summary>
    internal sealed class PerlinNoise : INoise {

        // 2/sqrt(N): normalizes the sqrt(N)/2 gradient-noise bound to [-1, 1].
        private const float Scale2D = 1.41421356f; // 2 / sqrt(2)
        private const float Scale3D = 1.15470054f; // 2 / sqrt(3)

        private readonly int m_Seed;

        internal PerlinNoise(long seed) => m_Seed = unchecked((int)(seed ^ (seed >> 32)));

        public float Sample(float x, float y) {
            int x0 = NoiseHash.FastFloor(x);
            int y0 = NoiseHash.FastFloor(y);
            int x1 = x0 + 1;
            int y1 = y0 + 1;

            float dx0 = x - x0;
            float dy0 = y - y0;
            float dx1 = dx0 - 1f;
            float dy1 = dy0 - 1f;

            float u = NoiseHash.Fade(dx0);
            float v = NoiseHash.Fade(dy0);

            float n00 = NoiseHash.GradDot(m_Seed, x0, y0, dx0, dy0);
            float n10 = NoiseHash.GradDot(m_Seed, x1, y0, dx1, dy0);
            float n01 = NoiseHash.GradDot(m_Seed, x0, y1, dx0, dy1);
            float n11 = NoiseHash.GradDot(m_Seed, x1, y1, dx1, dy1);

            float nx0 = NoiseHash.Lerp(n00, n10, u);
            float nx1 = NoiseHash.Lerp(n01, n11, u);

            return NoiseHash.Lerp(nx0, nx1, v) * Scale2D;
        }

        public float Sample(float x, float y, float z) {
            int x0 = NoiseHash.FastFloor(x);
            int y0 = NoiseHash.FastFloor(y);
            int z0 = NoiseHash.FastFloor(z);
            int x1 = x0 + 1;
            int y1 = y0 + 1;
            int z1 = z0 + 1;

            float dx0 = x - x0;
            float dy0 = y - y0;
            float dz0 = z - z0;
            float dx1 = dx0 - 1f;
            float dy1 = dy0 - 1f;
            float dz1 = dz0 - 1f;

            float u = NoiseHash.Fade(dx0);
            float v = NoiseHash.Fade(dy0);
            float w = NoiseHash.Fade(dz0);

            float n000 = NoiseHash.GradDot(m_Seed, x0, y0, z0, dx0, dy0, dz0);
            float n100 = NoiseHash.GradDot(m_Seed, x1, y0, z0, dx1, dy0, dz0);
            float n010 = NoiseHash.GradDot(m_Seed, x0, y1, z0, dx0, dy1, dz0);
            float n110 = NoiseHash.GradDot(m_Seed, x1, y1, z0, dx1, dy1, dz0);
            float n001 = NoiseHash.GradDot(m_Seed, x0, y0, z1, dx0, dy0, dz1);
            float n101 = NoiseHash.GradDot(m_Seed, x1, y0, z1, dx1, dy0, dz1);
            float n011 = NoiseHash.GradDot(m_Seed, x0, y1, z1, dx0, dy1, dz1);
            float n111 = NoiseHash.GradDot(m_Seed, x1, y1, z1, dx1, dy1, dz1);

            float nx00 = NoiseHash.Lerp(n000, n100, u);
            float nx10 = NoiseHash.Lerp(n010, n110, u);
            float nx01 = NoiseHash.Lerp(n001, n101, u);
            float nx11 = NoiseHash.Lerp(n011, n111, u);

            float nxy0 = NoiseHash.Lerp(nx00, nx10, v);
            float nxy1 = NoiseHash.Lerp(nx01, nx11, v);

            return NoiseHash.Lerp(nxy0, nxy1, w) * Scale3D;
        }
    }
}
