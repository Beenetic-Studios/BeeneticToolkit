using System;
using System.IO;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Random.Tests")]

namespace BeeneticToolkit.Random {

    /// <summary>
    /// Represents a pseudorandom number generator using the Xorshift algorithm.
    /// Xorshift is known for its speed and simplicity while providing a high-quality sequence of random numbers.
    /// This class inherits from RandomNumberGeneratorBase, which implements IRandomNumberGenerator.
    /// </summary>
    /// <exclude></exclude>
    internal class Xorshift : RandomGenerator {

        #region Fields

        private ulong _previous;

        #endregion Fields

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the Xorshift class with the specified seed.
        /// </summary>
        /// <param name="seed">The seed value used to initialize the random number generator.</param>
        /// <exclude></exclude>

        public Xorshift(long? seed = null) : base(seed ?? DateTime.UtcNow.Ticks) {
        }

        /// <summary>
        /// Sets up the initial state of the Xorshift algorithm using the current seed value.
        /// This method initializes the internal state required for generating random numbers.
        /// </summary>
        /// <exclude></exclude>
        protected override void InitializeRng() {
            _previous = (ulong)Seed + 0x9E3779B97f4A7C15;
            _previous = (_previous ^ (_previous >> 30)) * 0xBF58476D1CE4E5B9;
            _previous = (_previous ^ (_previous >> 27)) * 0x94D049BB133111EB;
            _previous ^= (_previous >> 31);
        }

        /// <summary>
        /// Generates the next pseudorandom long integer using the Xorshift algorithm.
        /// </summary>
        /// <returns>A pseudorandomly generated long integer.</returns>
        /// <exclude></exclude>
        protected override long Next() {
            _previous ^= _previous << 13;
            _previous ^= _previous >> 7;
            _previous ^= _previous << 17;

            return (long)(_previous & long.MaxValue);
        }

        #endregion Initialization
    }
}