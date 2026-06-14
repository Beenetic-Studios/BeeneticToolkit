using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Tests")]

namespace BeeneticToolkit.Random.Generators {

    /// <summary>
    /// A Combined Linear Congruential Generator (CLCG) class for generating pseudorandom numbers.
    /// This class inherits from RandomNumberGeneratorBase, which implements IRandomNumberGenerator.
    /// </summary>
    /// <exclude></exclude>
    internal class CombinedLCG : RandomGenerator {

        #region Fields

        // Parameters of the L'Ecuyer (1988) combined linear congruential generator.
        // Each multiplier is far smaller than its modulus, so a * state never overflows a long.
        private const long MOD_A = 2147483563;
        private const long MOD_B = 2147483399;
        private const long MULT_A = 40014;
        private const long MULT_B = 40692;

        private long _previousA;
        private long _previousB;

        /// <summary>
        /// Generates the next float value, uniformly distributed in <c>[0, 1)</c>.
        /// </summary>
        /// <returns>A pseudorandomly generated float in <c>[0, 1)</c>.</returns>
        /// <exclude></exclude>
        // Scale by 2^31, which is strictly greater than any value Next() can return (MOD_A < 2^31),
        // so the result stays below 1.0 even after rounding to float precision.
        protected override float CalculatedNextFloat => (float)Next() * (1.0f / 2147483648f);

        /// <summary>
        /// Generates the next double value, uniformly distributed in <c>[0, 1)</c>.
        /// </summary>
        /// <returns>A pseudorandomly generated double in <c>[0, 1)</c>.</returns>
        /// <exclude></exclude>
        protected override double CalculatedNextDouble => Next() / (double)(MOD_A - 1);

        /// <summary>
        /// Gets the inclusive maximum value <see cref="Next"/> can return for this generator.
        /// </summary>
        /// <exclude></exclude>
        protected override long NextMaxInclusive => MOD_A - 2;

        #endregion Fields

        #region Initialization

        /// <summary>
        /// Constructs a new CombinedLCG instance with a specified seed. Use this constructor to initialize the generator with a deterministic starting point.
        /// </summary>
        /// <param name="seed">The initial seed value for the LCG algorithm.</param>
        /// <exclude></exclude>

        public CombinedLCG(long? seed = null) : base(seed ?? DateTime.UtcNow.Ticks) {
        }

        /// <summary>
        /// Initializes the random number generator state using the current seed value. This method configures the initial states of the linear congruential generators based on the seed.
        /// It ensures that the initial states are non-zero and distinct to maintain the effectiveness of the CLCG algorithm.
        /// </summary>
        /// <exclude></exclude>
        protected override void InitializeRng() {
            // Each sub-generator state must be a non-zero residue: A in [1, MOD_A - 1], B in [1, MOD_B - 1].
            // Because the moduli are prime and the increments are zero, a non-zero state can never become zero.
            _previousA = Seed % (MOD_A - 1) + 1;
            _previousB = Seed % (MOD_B - 1) + 1;
        }

        /// <summary>
        /// Generates the next pseudorandom number in the sequence using the combined linear congruential algorithm.
        /// This method calculates the next values based on the current states of two separate linear congruential generators and combines them to produce a single long integer.
        /// The result is a more uniformly distributed sequence of pseudorandom numbers.
        /// </summary>
        /// <returns>A pseudorandomly generated long integer.</returns>
        /// <exclude></exclude>
        protected override long Next() {
            // a * state stays well within long range: 40692 * (MOD_B - 1) < 9.0e13.
            _previousA = MULT_A * _previousA % MOD_A;
            _previousB = MULT_B * _previousB % MOD_B;

            long combined = (_previousA - _previousB) % (MOD_A - 1);
            if (combined < 0)
                combined += MOD_A - 1;

            return combined; // uniform in [0, MOD_A - 2]
        }

        #endregion Initialization
    }
}