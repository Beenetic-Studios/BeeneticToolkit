namespace BeeneticToolkit.Random {

    public enum RNGAlgorithm {
        LCG,
        CombinedLCG,
        Xorshift,
        MiddleSquare
    }

    public static class RNGService {

        #region Fields

        private static RandomNumberGeneratorBase _generator = new CombinedLCG();

        #endregion Fields

        #region Configuration

        public static void SetRandomNumberAlgorithm(RNGAlgorithm algorithm, long? seed = null) {
            switch (algorithm) {
                case RNGAlgorithm.Xorshift:
                    //_generator = new Xorshift();
                    break;

                case RNGAlgorithm.LCG:
                    _generator = new CombinedLCG();
                    break;

                case RNGAlgorithm.MiddleSquare:
                    //_generator = new MiddleSquareWeyl();
                    break;

                default:
                    //_generator = new Xorshift();
                    break;
            }
        }

        #endregion Configuration

        #region Generation

        public static byte[] NextBytes() {
            return _generator.NextBytes();
        }

        public static byte[] NextBytes(int length) {
            return ((IRandomNumberGenerator)_generator).NextBytes(length);
        }

        public static byte[] NextBytes(int length, byte min, byte max) {
            return ((IRandomNumberGenerator)_generator).NextBytes(length, min, max);
        }

        public static int NextInt() {
            return ((IRandomNumberGenerator)_generator).NextInt();
        }

        public static int NextInt(int maxExclusive) {
            return ((IRandomNumberGenerator)_generator).NextInt(maxExclusive);
        }

        public static int NextInt(int minInclusive, int maxExclusive) {
            return ((IRandomNumberGenerator)_generator).NextInt(minInclusive, maxExclusive);
        }

        public static long NextLong() {
            return _generator.NextLong();
        }

        public static long NextLong(long maxExclusive) {
            return ((IRandomNumberGenerator)_generator).NextLong(maxExclusive);
        }

        public static long NextLong(long minInclusive, long maxExclusive) {
            return ((IRandomNumberGenerator)_generator).NextLong(minInclusive, maxExclusive);
        }

        public static float NextFloat() {
            return ((IRandomNumberGenerator)_generator).NextFloat();
        }

        public static float NextFloat(float maxExclusive) {
            return ((IRandomNumberGenerator)_generator).NextFloat(maxExclusive);
        }

        public static float NextFloat(float minInclusive, float maxExclusive) {
            return ((IRandomNumberGenerator)_generator).NextFloat(minInclusive, maxExclusive);
        }

        public static double NextDouble() {
            return ((IRandomNumberGenerator)_generator).NextDouble();
        }

        public static double NextDouble(double maxExclusive) {
            return ((IRandomNumberGenerator)_generator).NextDouble(maxExclusive);
        }

        public static double NextDouble(double minInclusive, double maxExclusive) {
            return ((IRandomNumberGenerator)_generator).NextDouble(minInclusive, maxExclusive);
        }

        public static double NextNormal() {
            return ((IRandomNumberGenerator)_generator).NextNormal();
        }

        public static double NextNormal(double mean, double stdDev) {
            return ((IRandomNumberGenerator)_generator).NextNormal(mean, stdDev);
        }

        public static bool NextBool() {
            return ((IRandomNumberGenerator)_generator).NextBool();
        }

        public static bool NextBool(float probability) {
            return ((IRandomNumberGenerator)_generator).NextBool(probability);
        }

        #endregion Generation
    }
}