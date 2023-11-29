using System;

namespace BeeneticToolkit.Random {

    /// <summary>
    /// Serves as the base class for random number generators, providing common functionality for seed management.
    /// This abstract class defines the basic structure and seeding mechanism that derived random number generators will use.
    /// </summary>
    public abstract class RandomNumberGeneratorBase : IRandomNumberGenerator {

        /// <summary>
        /// Gets the seed value used for random number generation.
        /// </summary>
        /// <value>
        /// The seed as a long integer. This seed is used to initialize the state of the random number generator
        /// to ensure consistent random sequences for the same seed.
        /// </value>
        protected long Seed { get; private set; }

        /// <summary>
        /// Gets a calculated random integer value based on the next number in the random sequence.
        /// </summary>
        /// <value>A calculated random integer.</value>
        protected int CalculatedNextInt => (int)(Next() % (int.MaxValue + 1L));

        /// <summary>
        /// Gets a calculated random float value based on the next number in the random sequence.
        /// </summary>
        /// <value>A calculated random float.</value>
        protected virtual float CalculatedNextFloat => (float)Next() / (long.MaxValue - 1);

        /// <summary>
        /// Gets a calculated random double value based on the next number in the random sequence.
        /// </summary>
        /// <value>A calculated random double.</value>
        protected virtual double CalculatedNextDouble => (double)Next() / (long.MaxValue - 1);

        /// <summary>
        /// Initializes a new instance of the random number generator with an automatically generated seed.
        /// </summary>
        protected RandomNumberGeneratorBase() {
            Seed = DateTime.UtcNow.Ticks;
            InitializeRng();
        }

        ///
        /// <summary>
        /// Initializes a new instance of the random number generator with the specified seed.
        /// </summary>
        /// <param name="seed">The seed to use in random number generation.</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="seed"/> is less than or equal to 0.</exception>
        protected RandomNumberGeneratorBase(long seed) {
            if (seed <= 0)
                throw new ArgumentException("Seed must be greater than 0");

            Seed = seed;
            InitializeRng();
        }

        /// <summary>
        /// Initializes the random number generator with the given seed.
        /// Override this method in derived classes to set up the random number generator.
        /// </summary>
        protected abstract void InitializeRng();

        /// <summary>
        /// When overridden in a derived class, generates the next random number in the sequence.
        /// </summary>
        /// <returns>A randomly generated long integer.</returns>
        protected abstract long Next();

        /// <summary>
        /// Generates a random byte array with a default length.
        /// </summary>
        /// <returns>A random byte array of default length. The default length is set to 8 bytes.</returns>
        public virtual byte[] NextBytes() {
            return NextBytes(8);
        }

        /// <summary>
        /// Generates a random byte array of a specified length.
        /// </summary>
        /// <param name="length">The length of the byte array to generate.</param>
        /// <returns>A random byte array of the specified length.</returns>

        public virtual byte[] NextBytes(int length) {
            byte[] bytes = new byte[length];

            for (int i = 0; i < length; i++) {
                bytes[i] = (byte)NextInt(256);
            }

            return bytes;
        }

        /// <summary>
        /// Generates a random byte array of a specified length, with each byte within a specified range.
        /// </summary>
        /// <param name="length">The length of the byte array to generate.</param>
        /// <param name="minInclusive">The inclusive lower bound of the byte range.</param>
        /// <param name="maxExclusive">The exclusive upper bound of the byte range.</param>
        /// <returns>A random byte array of the specified length, with each byte within the specified range.</returns>
        public byte[] NextBytes(int length, byte minInclusive, byte maxExclusive) {
            if (minInclusive >= maxExclusive)
                throw new ArgumentException($"{nameof(minInclusive)} must be less than {nameof(maxExclusive)}");

            byte[] bytes = new byte[length];
            int range = maxExclusive - minInclusive;

            for (int i = 0; i < length; i++) {
                bytes[i] = (byte)(NextInt(range) + minInclusive);
            }

            return bytes;
        }

        /// <summary>
        /// Generates a non-negative random integer.
        /// </summary>
        /// <returns>A non-negative random integer.</returns>
        public virtual int NextInt() {
            return NextInt(0, int.MaxValue);
        }

        /// <summary>
        /// Generates a pseudo-random integer between 0 (inclusive) and the specified maximum (exclusive).
        /// It throws an <see cref="ArgumentException"/> if <paramref name="maxExclusive"/> is less than or equal to 0.
        /// </summary>
        /// <param name="maxExclusive">The upper bound (exclusive) of the random number to be generated. Must be greater than 0.</param>
        /// <returns>A random integer in the range [0, <paramref name="maxExclusive"/>).</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="maxExclusive"/> is less than or equal to 0.</exception>
        public virtual int NextInt(int maxExclusive) {
            if (maxExclusive <= 0)
                throw new ArgumentException($"{nameof(maxExclusive)} must be greater than 0");

            return NextInt(0, maxExclusive);
        }

        /// <summary>
        /// Generates a pseudo-random integer between the specified minimum (inclusive) and maximum (exclusive).
        /// It throws an <see cref="ArgumentException"/> if <paramref name="minInclusive"/> is greater than or equal to <paramref name="maxExclusive"/>.
        /// </summary>
        /// <param name="minInclusive">The lower bound (inclusive) of the random number to be generated.</param>
        /// <param name="maxExclusive">The upper bound (exclusive) of the random number to be generated. Must be greater than <paramref name="minInclusive"/>.</param>
        /// <returns>A random integer in the range [<paramref name="minInclusive"/>, <paramref name="maxExclusive"/>).</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="minInclusive"/> is greater than or equal to <paramref name="maxExclusive"/>.</exception>
        public virtual int NextInt(int minInclusive, int maxExclusive) {
            if (minInclusive >= maxExclusive)
                throw new ArgumentException($"{nameof(minInclusive)} must be less than {nameof(maxExclusive)}");

            return CalculatedNextInt % (maxExclusive - minInclusive) + minInclusive;
        }

        /// <summary>
        /// Generates a non-negative random long integer.
        /// </summary>
        /// <returns>A non-negative random long integer.</returns>
        public virtual long NextLong() {
            return NextLong(0, long.MaxValue);
        }

        /// <summary>
        /// Generates a pseudo-random long integer between 0 (inclusive) and the specified maximum (exclusive).
        /// It throws an <see cref="ArgumentException"/> if <paramref name="maxExclusive"/> is less than or equal to 0.
        /// </summary>
        /// <param name="maxExclusive">The upper bound (exclusive) of the random long number to be generated. Must be greater than 0.</param>
        /// <returns>A random long integer in the range [0, <paramref name="maxExclusive"/>).</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="maxExclusive"/> is less than or equal to 0.</exception>
        public virtual long NextLong(long maxExclusive) {
            if (maxExclusive <= 0)
                throw new ArgumentException($"{nameof(maxExclusive)} must be greater than 0");

            return NextLong(0, maxExclusive);
        }

        /// <summary>
        /// Generates a pseudo-random long integer between the specified minimum (inclusive) and maximum (exclusive).
        /// It throws an <see cref="ArgumentException"/> if <paramref name="minInclusive"/> is greater than or equal to <paramref name="maxExclusive"/>.
        /// </summary>
        /// <param name="minInclusive">The lower bound (inclusive) of the random long number to be generated.</param>
        /// <param name="maxExclusive">The upper bound (exclusive) of the random long number to be generated. Must be greater than <paramref name="minInclusive"/>.</param>
        /// <returns>A random long integer in the range [<paramref name="minInclusive"/>, <paramref name="maxExclusive"/>).</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="minInclusive"/> is greater than or equal to <paramref name="maxExclusive"/>.</exception>
        public virtual long NextLong(long minInclusive, long maxExclusive) {
            if (minInclusive >= maxExclusive)
                throw new ArgumentException($"{nameof(minInclusive)} must be less than {nameof(maxExclusive)}");

            return Next() % (maxExclusive - minInclusive) + minInclusive;
        }

        /// <summary>
        /// Calculates the next float value in the random sequence.
        /// </summary>
        /// <returns>A randomly generated float.</returns>
        public virtual float NextFloat() => CalculatedNextFloat;

        /// <summary>
        /// Generates a pseudo-random float between 0 (inclusive) and the specified maximum (inclusive).
        /// It throws an <see cref="ArgumentException"/> if <paramref name="maxInclusive"/> is less than or equal to 0.
        /// </summary>
        /// <param name="maxInclusive">The upper bound (inclusive) of the random float number to be generated. Must be greater than 0.</param>
        /// <returns>A random float in the range [0, <paramref name="maxInclusive"/>].</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="maxInclusive"/> is less than or equal to 0.</exception>
        public virtual float NextFloat(float maxInclusive) {
            if (maxInclusive <= 0)
                throw new ArgumentException($"{nameof(maxInclusive)} must be greater than 0");

            return NextFloat(0, maxInclusive);
        }

        /// <summary>
        /// Generates a pseudo-random float between the specified minimum (inclusive) and maximum (inclusive).
        /// It throws an <see cref="ArgumentException"/> if <paramref name="minInclusive"/> is greater than or equal to <paramref name="maxInclusive"/>.
        /// </summary>
        /// <param name="minInclusive">The lower bound (inclusive) of the random float number to be generated.</param>
        /// <param name="maxInclusive">The upper bound (inclusive) of the random float number to be generated. Must be greater than <paramref name="minInclusive"/>.</param>
        /// <returns>A random float in the range [<paramref name="minInclusive"/>, <paramref name="maxInclusive"/>].</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="minInclusive"/> is greater than or equal to <paramref name="maxInclusive"/>.</exception>

        public virtual float NextFloat(float minInclusive, float maxInclusive) {
            if (minInclusive >= maxInclusive)
                throw new ArgumentException($"{nameof(minInclusive)} must be less than {nameof(maxInclusive)}");

            return NextFloat() * (maxInclusive - minInclusive) + minInclusive;
        }

        /// <summary>
        /// Calculates the next double value in the random sequence.
        /// </summary>
        /// <returns>A randomly generated double.</returns>
        public virtual double NextDouble() => CalculatedNextDouble;

        /// <summary>
        /// Generates a pseudo-random double between 0 (inclusive) and the specified maximum (inclusive).
        /// It throws an <see cref="ArgumentException"/> if <paramref name="maxInclusive"/> is less than or equal to 0.
        /// </summary>
        /// <param name="maxInclusive">The upper bound (inclusive) of the random double number to be generated. Must be greater than 0.</param>
        /// <returns>A random double in the range [0, <paramref name="maxInclusive"/>].</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="maxInclusive"/> is less than or equal to 0.</exception>

        public virtual double NextDouble(double maxInclusive) {
            if (maxInclusive <= 0)
                throw new ArgumentException("The maximum (inclusive) must be greater than 0", nameof(maxInclusive));

            return NextDouble(0, maxInclusive);
        }

        /// <summary>
        /// Generates a pseudo-random double between the specified minimum (inclusive) and maximum (inclusive).
        /// It throws an <see cref="ArgumentException"/> if <paramref name="minInclusive"/> is greater than or equal to <paramref name="maxInclusive"/>.
        /// </summary>
        /// <param name="minInclusive">The lower bound (inclusive) of the random double number to be generated.</param>
        /// <param name="maxInclusive">The upper bound (inclusive) of the random double number to be generated. Must be greater than <paramref name="minInclusive"/>.</param>
        /// <returns>A random double in the range [<paramref name="minInclusive"/>, <paramref name="maxInclusive"/>].</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="minInclusive"/> is greater than or equal to <paramref name="maxInclusive"/>.</exception>

        public virtual double NextDouble(double minInclusive, double maxInclusive) {
            if (minInclusive >= maxInclusive)
                throw new ArgumentException($"{nameof(minInclusive)} must be less than {nameof(maxInclusive)}");

            return NextDouble() * (maxInclusive - minInclusive) + minInclusive;
        }

        /// <summary>
        /// Generates a normally distributed random number with a default mean of 0.0 and standard deviation of 1.0.
        /// This method is an overload of the NextNormal method that uses default parameters to produce a standard normal distribution.
        /// </summary>
        /// <returns>A random double number following the standard normal distribution with a mean of 0.0 and a standard deviation of 1.0.</returns>
        public virtual double NextNormal() {
            return NextNormal(0.0, 1.0);
        }

        /// <summary>
        /// Generates a normally distributed random number with a specified mean and standard deviation.
        /// This method uses the Box-Muller transform to produce a normal distribution.
        /// It throws an <see cref="ArgumentException"/> if the standard deviation is negative.
        /// </summary>
        /// <param name="mean">The mean (μ) of the normal distribution.</param>
        /// <param name="stDev">The standard deviation (σ) of the normal distribution. Must be non-negative.</param>
        /// <returns>A random double number following the normal distribution with the specified mean and standard deviation.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="stDev"/> is negative.</exception>
        public virtual double NextNormal(double mean, double stDev) {
            if (stDev < 0)
                throw new ArgumentException("Standard deviation cannot be negative", nameof(stDev));

            double u1 = 1.0 - NextDouble();
            double u2 = 1.0 - NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);

            return mean + stDev * randStdNormal;
        }

        /// <summary>
        /// Returns a random boolean value by equally considering the true and false outcomes.
        /// </summary>
        /// <returns>A random boolean value.</returns>
        public virtual bool NextBool() {
            return NextLong(2) == 0;
        }

        /// <summary>
        /// Returns a random boolean value with the probability of returning true specified by the input parameter.
        /// </summary>
        /// <param name="probability">The probability of returning true. Must be between 0.0 and 1.0.</param>
        /// <returns>A random boolean value influenced by the specified probability.</returns>
        public virtual bool NextBool(float probability) {
            if (probability < 0.0 || probability > 1.0)
                throw new ArgumentOutOfRangeException(nameof(probability), "Probability must be between 0.0 and 1.0");

            return NextFloat() < probability;
        }
    }
}