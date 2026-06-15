using System;

namespace BeeneticToolkit.Random.Generators {

    /// <summary>
    /// A pseudorandom number generator using the xoshiro256** algorithm by Blackman and Vigna.
    /// It is fast, has a 2^256 - 1 period, and excellent statistical quality, making it a strong
    /// general-purpose default. It is not cryptographically secure.
    /// </summary>
    /// <exclude></exclude>
    internal class Xoshiro256 : RandomGenerator {

        #region Fields

        private ulong _s0;
        private ulong _s1;
        private ulong _s2;
        private ulong _s3;

        #endregion Fields

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Xoshiro256"/> class with the specified seed.
        /// </summary>
        /// <param name="seed">The seed value used to initialize the random number generator.</param>
        /// <exclude></exclude>
        public Xoshiro256(long seed) : base(seed) {
        }

        /// <summary>
        /// Expands the seed into the 256-bit state using the SplitMix64 mixer, as recommended by the
        /// xoshiro authors, guaranteeing a well-distributed, non-zero state.
        /// </summary>
        /// <exclude></exclude>
        protected override void InitializeRng() {
            ulong x = (ulong)Seed;
            _s0 = SplitMix64(ref x);
            _s1 = SplitMix64(ref x);
            _s2 = SplitMix64(ref x);
            _s3 = SplitMix64(ref x);

            // The all-zero state is the single forbidden state for xoshiro; SplitMix64 from a non-zero
            // seed will not produce it, but guard defensively.
            if ((_s0 | _s1 | _s2 | _s3) == 0UL)
                _s0 = 1UL;
        }

        #endregion Initialization

        #region RNG

        /// <summary>
        /// Generates the next pseudorandom value using the xoshiro256** scrambler.
        /// </summary>
        /// <returns>A pseudorandomly generated long integer.</returns>
        /// <exclude></exclude>
        protected override long Next() {
            ulong result = Rotl(_s1 * 5UL, 7) * 9UL;

            ulong t = _s1 << 17;
            _s2 ^= _s0;
            _s3 ^= _s1;
            _s1 ^= _s2;
            _s0 ^= _s3;
            _s2 ^= t;
            _s3 = Rotl(_s3, 45);

            return (long)(result & long.MaxValue);
        }

        private static ulong Rotl(ulong x, int k) => (x << k) | (x >> (64 - k));

        private static ulong SplitMix64(ref ulong x) {
            ulong z = x += 0x9E3779B97F4A7C15UL;
            z = (z ^ (z >> 30)) * 0xBF58476D1CE4E5B9UL;
            z = (z ^ (z >> 27)) * 0x94D049BB133111EBUL;
            return z ^ (z >> 31);
        }

        #endregion RNG
    }
}
