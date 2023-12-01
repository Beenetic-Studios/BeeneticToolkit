using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Random.Tests")]

namespace BeeneticToolkit.Random {

    /// <summary>
    /// A Combined Linear Congruential Generator (CLCG) class for generating pseudorandom numbers.
    /// This class inherits from RandomNumberGeneratorBase, which implements IRandomNumberGenerator.
    /// </summary>
    /// <exclude></exclude>
    internal class CombinedLCG : RandomGeneratorBase {

        #region Fields

        private const long MOD_A = 32416187567;
        private const long MOD_B = 32416190071;
        private const long MULT_A = 2862933555777941757;
        private const long MULT_B = 3202034522624059733;
        private const long INCREMENT_A = 0;
        private const long INCREMENT_B = 1;

        private long _previousA;
        private long _previousB;

        /// <summary>
        /// Generates the next float value in the sequence.
        /// </summary>
        /// <returns>A pseudorandomly generated float.</returns>
        /// <exclude></exclude>
        protected override float CalculatedNextFloat => Next() / (float)(MOD_A - 1);

        /// <summary>
        /// Generates the next double value in the sequence.
        /// </summary>
        /// <returns>A pseudorandomly generated double.</returns>
        /// <exclude></exclude>
        protected override double CalculatedNextDouble => Next() / (double)(MOD_A - 1);

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
            var a = (Seed ^ MULT_A) % MOD_A;
            var b = (Seed ^ MULT_B) % MOD_B;

            if (a == 0)
                a = (a + 17) * MULT_A % MOD_A;
            if (b == 0 || b == a)
                b = (b + 31) * MULT_B % MOD_B;

            _previousA = a;
            _previousB = b;
        }

        /// <summary>
        /// Generates the next pseudorandom number in the sequence using the combined linear congruential algorithm.
        /// This method calculates the next values based on the current states of two separate linear congruential generators and combines them to produce a single long integer.
        /// The result is a more uniformly distributed sequence of pseudorandom numbers.
        /// </summary>
        /// <returns>A pseudorandomly generated long integer.</returns>
        /// <exclude></exclude>
        protected override long Next() {
            long a = (_previousA * MULT_A + INCREMENT_A) % MOD_A;
            long b = (_previousB * MULT_B + INCREMENT_B) % MOD_B;
            _previousA = a;
            _previousB = b;

            long combined = (a - b) % MOD_A;
            if (combined < 0)
                combined += MOD_A;

            return combined;
        }

        #endregion Initialization
    }
}