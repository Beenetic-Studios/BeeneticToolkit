namespace BeeneticToolkit.Random {

    internal class LCG : RandomNumberGeneratorBase {

        #region Fields

        private readonly long _modulus;
        private readonly long _multiplier;
        private readonly long _increment;
        private long _previous;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Generates the next float value in the sequence.
        /// </summary>
        /// <returns>A pseudorandomly generated float.</returns>
        /// <exclude></exclude>
        protected override float CalculatedNextFloat => Next() / (float)(_modulus - 1);

        /// <summary>
        /// Generates the next double value in the sequence.
        /// </summary>
        /// <returns>A pseudorandomly generated double.</returns>
        /// <exclude></exclude>
        protected override double CalculatedNextDouble => Next() / (double)(_modulus - 1);

        #endregion Properties

        #region Initialization

        public LCG(long modulus, long multiplier, long increment) : base() {
            _modulus = modulus;
            _multiplier = multiplier;
            _increment = increment;

            InitializeRng();
        }

        public LCG(long modulus, long multiplier, long increment, long seed) : base(seed) {
            _modulus = modulus;
            _multiplier = multiplier;
            _increment = increment;

            InitializeRng();
        }

        protected override void InitializeRng() {
            if (Seed <= 0 || _modulus == 0 || _multiplier == 0)
                return;

            var seed = (Seed ^ _multiplier + _increment) % _modulus;

            if (seed == 0)
                seed = ((seed + 17) * _multiplier + _increment) % _modulus;

            _previous = seed;
        }

        #endregion Initialization

        #region RNG

        protected override long Next() {
            _previous = (_previous * _multiplier + _increment) % _modulus;
            return _previous;
        }

        public long NextLCG() {
            return Next();
        }

        #endregion RNG
    }
}