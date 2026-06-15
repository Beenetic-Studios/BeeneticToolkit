namespace BeeneticToolkit.Random.Noise.Internal {

    /// <summary>
    /// Shared, deterministic noise math: integer lattice hashing, the quintic fade/interpolation
    /// helpers, and unit-length gradient tables. All hashing uses integer operations only, so output
    /// is bit-identical across platforms for a given seed (unlike float-accumulation schemes).
    /// </summary>
    internal static class NoiseHash {

        // Odd 32-bit primes used to decorrelate the coordinate axes before mixing.
        private const int PrimeX = 501125321;
        private const int PrimeY = 1136930381;
        private const int PrimeZ = 1720413743;

        // sqrt(2)/2 — magnitude that turns the (±1,±1,0)-style gradients into unit vectors.
        private const float G3 = 0.70710678f;

        /// <summary>Eight unit gradients at 45° increments, as flat (x, y) pairs.</summary>
        private static readonly float[] Grad2 = {
             1f, 0f,    G3,  G3,   0f,  1f,  -G3,  G3,
            -1f, 0f,   -G3, -G3,   0f, -1f,   G3, -G3,
        };

        /// <summary>Twelve unit gradients (cube-edge directions, normalized), as flat (x, y, z) triples.</summary>
        private static readonly float[] Grad3 = {
             G3,  G3, 0f,   -G3,  G3, 0f,    G3, -G3, 0f,   -G3, -G3, 0f,
             G3, 0f,  G3,   -G3, 0f,  G3,    G3, 0f, -G3,   -G3, 0f, -G3,
            0f,  G3,  G3,   0f, -G3,  G3,   0f,  G3, -G3,   0f, -G3, -G3,
        };

        /// <summary>Floors toward negative infinity (unlike a plain cast, which truncates toward zero).</summary>
        internal static int FastFloor(float value) {
            int i = (int)value;
            return value < i ? i - 1 : i;
        }

        /// <summary>Quintic smoothstep 6t^5 - 15t^4 + 10t^3 (C2-continuous), used to ease lattice interpolation.</summary>
        internal static float Fade(float t) => t * t * t * (t * (t * 6f - 15f) + 10f);

        /// <summary>Linear interpolation from <paramref name="a"/> to <paramref name="b"/> by <paramref name="t"/>.</summary>
        internal static float Lerp(float a, float b, float t) => a + t * (b - a);

        private static int Hash(int seed, int x, int y) {
            unchecked {
                int h = seed ^ (x * PrimeX) ^ (y * PrimeY);
                h *= 0x27d4eb2d;
                return h ^ (h >> 15);
            }
        }

        private static int Hash(int seed, int x, int y, int z) {
            unchecked {
                int h = seed ^ (x * PrimeX) ^ (y * PrimeY) ^ (z * PrimeZ);
                h *= 0x27d4eb2d;
                return h ^ (h >> 15);
            }
        }

        /// <summary>Pseudo-random lattice value in <c>[-1, 1]</c> for value noise.</summary>
        internal static float Lattice(int seed, int x, int y) =>
            (Hash(seed, x, y) & 0xFFFF) * (2f / 65535f) - 1f;

        /// <summary>Pseudo-random lattice value in <c>[-1, 1]</c> for value noise.</summary>
        internal static float Lattice(int seed, int x, int y, int z) =>
            (Hash(seed, x, y, z) & 0xFFFF) * (2f / 65535f) - 1f;

        /// <summary>Dot product of the lattice point's unit gradient with the distance vector (2D Perlin).</summary>
        internal static float GradDot(int seed, int x, int y, float dx, float dy) {
            int gi = (Hash(seed, x, y) & 7) << 1;
            return Grad2[gi] * dx + Grad2[gi + 1] * dy;
        }

        /// <summary>Dot product of the lattice point's unit gradient with the distance vector (3D Perlin).</summary>
        internal static float GradDot(int seed, int x, int y, int z, float dx, float dy, float dz) {
            int gi = ((Hash(seed, x, y, z) & 0x7FFFFFFF) % 12) * 3;
            return Grad3[gi] * dx + Grad3[gi + 1] * dy + Grad3[gi + 2] * dz;
        }
    }
}
