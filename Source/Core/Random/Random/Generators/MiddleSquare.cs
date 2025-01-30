using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Tests")]

namespace BeeneticToolkit.Random.Generators {

    /// <summary>
    /// Represents a pseudorandom number generator using the Middle-Square Weyl Sequence algorithm.
    /// This algorithm is known for its simplicity and relatively good distribution of random numbers.
    /// The class inherits from RandomNumberGeneratorBase, implementing the IRandomNumberGenerator interface.
    /// </summary>
    /// <exclude></exclude>
    internal class MiddleSquare : RandomGenerator {

        #region Fields

        private const ulong WEYL_SEQUENCE_A = 0xb5ad4eceda1ce2a9;
        private const ulong WEYL_SEQUENCE_B = 0x278c5a4d8419fe6b;

        private ulong _previousA;
        private ulong _previousB;
        private ulong _incrementA;
        private ulong _incrementB;

        #endregion Fields

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the MiddleSquareWeylSequence class with the specified seed.
        /// </summary>
        /// <param name="seed">The seed value used to initialize the random number generator.</param>
        /// <exclude></exclude>
        public MiddleSquare(long? seed = null) : base(seed ?? DateTime.UtcNow.Ticks) {
        }

        /// <summary>
        /// Sets up the initial state of the Middle-Square Weyl Sequence algorithm using the current seed value.
        /// The initialization involves setting the state values and Weyl sequence increments.
        /// </summary>
        /// <exclude></exclude>
        protected override void InitializeRng() {
            _incrementA = 0;
            _incrementB = 0;
            _previousA = (ulong)Seed;
            _previousB = (ulong)Seed;

            for (int i = 0; i < 32; i++)
                Next();
        }

        /// <summary>
        /// Generates the next pseudorandom long integer using the Middle-Square Weyl Sequence algorithm.
        /// The method involves squaring and manipulating the internal state with Weyl sequences.
        /// </summary>
        /// <returns>A pseudorandomly generated long integer.</returns>
        /// <exclude></exclude>
        protected override long Next() {
            ulong temp;
            _previousA *= _previousA;
            _incrementA += WEYL_SEQUENCE_A;
            _previousA += _incrementA;
            temp = _previousA;
            _previousA = _previousA >> 32 | _previousA << 32;

            _previousB *= _previousB;
            _incrementB += WEYL_SEQUENCE_B;
            _previousB += _incrementB;
            _previousB = _previousB >> 32 | _previousB << 32;

            temp ^= _previousB;

            return (long)(temp & long.MaxValue);
        }

        #endregion Initialization
    }
}