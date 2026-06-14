using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BeeneticToolkit.Tests.Random")]

namespace BeeneticToolkit.Random {

    /// <summary>
    /// Serves as the base class for random number generators, providing common functionality for seed management.
    /// This abstract class defines the basic structure and seeding mechanism that derived random number generators will use.
    /// </summary>
    /// <remarks>
    /// Instances are <b>not</b> thread-safe: each call advances mutable internal state. Use a separate
    /// generator per thread, or a per-scope <see cref="RngEnvironment"/> registration, rather than sharing
    /// a single instance across threads. The registry types (<see cref="RngEnvironment"/>, <see cref="RngManager"/>)
    /// are themselves safe for concurrent registration and lookup.
    /// </remarks>
    public abstract class RandomGenerator : IRandomGenerator {

        /// <summary>
        /// Gets the seed value used for random number generation.
        /// </summary>
        /// <value>
        /// The seed as a long integer. This seed is used to initialize the state of the random number generator
        /// to ensure consistent random sequences for the same seed.
        /// </value>
        protected internal long Seed { get; private set; }

        /// <summary>
        /// Gets the inclusive maximum value that <see cref="Next"/> can return.
        /// </summary>
        /// <remarks>
        /// This is used to derive unbiased bounded values and to scale the <c>[0, 1)</c> float/double
        /// helpers. The base implementation assumes <see cref="Next"/> yields a uniform value in
        /// <c>[0, long.MaxValue]</c> (i.e. a full 63-bit result). Generators whose <see cref="Next"/>
        /// produces a narrower range (for example a modulus-bounded LCG) must override this so the
        /// derived values stay correct.
        /// </remarks>
        /// <value>The inclusive upper bound of <see cref="Next"/>.</value>
        protected virtual long NextMaxInclusive => long.MaxValue;

        /// <summary>
        /// Gets a calculated random float value, uniformly distributed in the half-open range <c>[0, 1)</c>.
        /// </summary>
        /// <value>A calculated random float in <c>[0, 1)</c>.</value>
        protected virtual float CalculatedNextFloat => (Next() >> 39) * (1.0f / (1 << 24));

        /// <summary>
        /// Gets a calculated random double value, uniformly distributed in the half-open range <c>[0, 1)</c>.
        /// </summary>
        /// <value>A calculated random double in <c>[0, 1)</c>.</value>
        protected virtual double CalculatedNextDouble => (Next() >> 10) * (1.0 / (1L << 53));

        /// <summary>
        /// Initializes a new instance of the random number generator with the specified seed.
        /// </summary>
        /// <param name="seed">The seed to use in random number generation.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when<paramref name="seed"/> is less than or equal to 0.</exception>
        protected RandomGenerator(long seed) {
            if (seed <= 0)
                throw new ArgumentOutOfRangeException(nameof(seed), "Seed must be greater than 0.");

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
        /// Produces a uniformly distributed integer in the half-open range
        /// <c>[<paramref name="minInclusive"/>, <paramref name="maxExclusive"/>)</c> without modulo bias.
        /// </summary>
        /// <param name="minInclusive">The inclusive lower bound. Must be less than <paramref name="maxExclusive"/>.</param>
        /// <param name="maxExclusive">The exclusive upper bound.</param>
        /// <returns>An unbiased random value in the requested range.</returns>
        private long NextBounded(long minInclusive, long maxExclusive) {
            ulong range = unchecked((ulong)maxExclusive - (ulong)minInclusive);
            return unchecked((long)((ulong)minInclusive + NextUIntBelow(range)));
        }

        /// <summary>
        /// Produces a uniformly distributed value in <c>[0, <paramref name="range"/>)</c> using rejection
        /// sampling, composing multiple draws when a single draw cannot represent the whole range.
        /// </summary>
        /// <param name="range">The exclusive upper bound. Must be greater than 0.</param>
        /// <returns>An unbiased random value in <c>[0, <paramref name="range"/>)</c>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="range"/> is larger than this generator can represent without bias.
        /// </exception>
        private ulong NextUIntBelow(ulong range) {
            // Number of distinct values a single Next() call can produce.
            ulong source = unchecked((ulong)NextMaxInclusive + 1UL);

            while (true) {
                ulong accumulated = (ulong)Next();
                ulong span = source;

                // Draw additional digits until the accumulated span can represent the whole range.
                while (span < range) {
                    if (span > ulong.MaxValue / source)
                        throw new ArgumentOutOfRangeException(nameof(range),
                            "The requested range is too large for this generator to sample without bias.");

                    accumulated = accumulated * source + (ulong)Next();
                    span *= source;
                }

                // Reject the non-uniform tail so every value in [0, range) is equally likely.
                ulong limit = span - span % range;
                if (accumulated < limit)
                    return accumulated % range;
            }
        }

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
            NextBytes(bytes.AsSpan());
            return bytes;
        }

        /// <summary>
        /// Fills the provided buffer with random bytes, without allocating.
        /// </summary>
        /// <param name="buffer">The buffer to fill with random bytes.</param>
        public virtual void NextBytes(Span<byte> buffer) {
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = (byte)NextInt(256);
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
                throw new ArgumentOutOfRangeException(nameof(minInclusive), $"{nameof(minInclusive)} must be less than {nameof(maxExclusive)}.");

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
        public virtual int NextInt() => (int)NextBounded(0, (long)int.MaxValue + 1L);

        /// <summary>
        /// Generates a pseudo-random integer between 0 (inclusive) and the specified maximum (exclusive).
        /// It throws an <see cref="ArgumentException"/> if <paramref name="maxExclusive"/> is less than or equal to 0.
        /// </summary>
        /// <param name="maxExclusive">The upper bound (exclusive) of the random number to be generated. Must be greater than 0.</param>
        /// <returns>A random integer in the range [0, <paramref name="maxExclusive"/>).</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when<paramref name="maxExclusive"/> is less than or equal to 0.</exception>
        public virtual int NextInt(int maxExclusive) {
            if (maxExclusive <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxExclusive), $"{nameof(maxExclusive)} must be greater than 0.");

            return NextInt(0, maxExclusive);
        }

        /// <summary>
        /// Generates a pseudo-random integer between the specified minimum (inclusive) and maximum (exclusive).
        /// It throws an <see cref="ArgumentException"/> if <paramref name="minInclusive"/> is greater than or equal to <paramref name="maxExclusive"/>.
        /// </summary>
        /// <param name="minInclusive">The lower bound (inclusive) of the random number to be generated.</param>
        /// <param name="maxExclusive">The upper bound (exclusive) of the random number to be generated. Must be greater than <paramref name="minInclusive"/>.</param>
        /// <returns>A random integer in the range [<paramref name="minInclusive"/>, <paramref name="maxExclusive"/>).</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when<paramref name="minInclusive"/> is greater than or equal to <paramref name="maxExclusive"/>.</exception>
        public virtual int NextInt(int minInclusive, int maxExclusive) {
            if (minInclusive >= maxExclusive)
                throw new ArgumentOutOfRangeException(nameof(minInclusive), $"{nameof(minInclusive)} must be less than {nameof(maxExclusive)}.");

            return (int)NextBounded(minInclusive, maxExclusive);
        }

        /// <summary>
        /// Generates a non-negative random long integer.
        /// </summary>
        /// <returns>A non-negative random long integer.</returns>
        public virtual long NextLong() => Next();

        /// <summary>
        /// Generates a pseudo-random long integer between 0 (inclusive) and the specified maximum (exclusive).
        /// It throws an <see cref="ArgumentException"/> if <paramref name="maxExclusive"/> is less than or equal to 0.
        /// </summary>
        /// <param name="maxExclusive">The upper bound (exclusive) of the random long number to be generated. Must be greater than 0.</param>
        /// <returns>A random long integer in the range [0, <paramref name="maxExclusive"/>).</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when<paramref name="maxExclusive"/> is less than or equal to 0.</exception>
        public virtual long NextLong(long maxExclusive) {
            if (maxExclusive <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxExclusive), $"{nameof(maxExclusive)} must be greater than 0.");

            return NextLong(0, maxExclusive);
        }

        /// <summary>
        /// Generates a pseudo-random long integer between the specified minimum (inclusive) and maximum (exclusive).
        /// It throws an <see cref="ArgumentException"/> if <paramref name="minInclusive"/> is greater than or equal to <paramref name="maxExclusive"/>.
        /// </summary>
        /// <param name="minInclusive">The lower bound (inclusive) of the random long number to be generated.</param>
        /// <param name="maxExclusive">The upper bound (exclusive) of the random long number to be generated. Must be greater than <paramref name="minInclusive"/>.</param>
        /// <returns>A random long integer in the range [<paramref name="minInclusive"/>, <paramref name="maxExclusive"/>).</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when<paramref name="minInclusive"/> is greater than or equal to <paramref name="maxExclusive"/>.</exception>
        public virtual long NextLong(long minInclusive, long maxExclusive) {
            if (minInclusive >= maxExclusive)
                throw new ArgumentOutOfRangeException(nameof(minInclusive), $"{nameof(minInclusive)} must be less than {nameof(maxExclusive)}.");

            return NextBounded(minInclusive, maxExclusive);
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
        /// <exception cref="ArgumentOutOfRangeException">Thrown when<paramref name="maxInclusive"/> is less than or equal to 0.</exception>
        public virtual float NextFloat(float maxInclusive) {
            if (maxInclusive <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxInclusive), $"{nameof(maxInclusive)} must be greater than 0.");

            return NextFloat(0, maxInclusive);
        }

        /// <summary>
        /// Generates a pseudo-random float between the specified minimum (inclusive) and maximum (inclusive).
        /// It throws an <see cref="ArgumentException"/> if <paramref name="minInclusive"/> is greater than or equal to <paramref name="maxInclusive"/>.
        /// </summary>
        /// <param name="minInclusive">The lower bound (inclusive) of the random float number to be generated.</param>
        /// <param name="maxInclusive">The upper bound (inclusive) of the random float number to be generated. Must be greater than <paramref name="minInclusive"/>.</param>
        /// <returns>A random float in the range [<paramref name="minInclusive"/>, <paramref name="maxInclusive"/>].</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when<paramref name="minInclusive"/> is greater than or equal to <paramref name="maxInclusive"/>.</exception>

        public virtual float NextFloat(float minInclusive, float maxInclusive) {
            if (minInclusive >= maxInclusive)
                throw new ArgumentOutOfRangeException(nameof(minInclusive), $"{nameof(minInclusive)} must be less than {nameof(maxInclusive)}.");

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
        /// <exception cref="ArgumentOutOfRangeException">Thrown when<paramref name="maxInclusive"/> is less than or equal to 0.</exception>

        public virtual double NextDouble(double maxInclusive) {
            if (maxInclusive <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxInclusive), "The maximum (inclusive) must be greater than 0.");

            return NextDouble(0, maxInclusive);
        }

        /// <summary>
        /// Generates a pseudo-random double between the specified minimum (inclusive) and maximum (inclusive).
        /// It throws an <see cref="ArgumentException"/> if <paramref name="minInclusive"/> is greater than or equal to <paramref name="maxInclusive"/>.
        /// </summary>
        /// <param name="minInclusive">The lower bound (inclusive) of the random double number to be generated.</param>
        /// <param name="maxInclusive">The upper bound (inclusive) of the random double number to be generated. Must be greater than <paramref name="minInclusive"/>.</param>
        /// <returns>A random double in the range [<paramref name="minInclusive"/>, <paramref name="maxInclusive"/>].</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when<paramref name="minInclusive"/> is greater than or equal to <paramref name="maxInclusive"/>.</exception>

        public virtual double NextDouble(double minInclusive, double maxInclusive) {
            if (minInclusive >= maxInclusive)
                throw new ArgumentOutOfRangeException(nameof(minInclusive), $"{nameof(minInclusive)} must be less than {nameof(maxInclusive)}.");

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
        /// <exception cref="ArgumentOutOfRangeException">Thrown when<paramref name="stDev"/> is negative.</exception>
        public virtual double NextNormal(double mean, double stDev) {
            if (stDev < 0)
                throw new ArgumentOutOfRangeException(nameof(stDev), "Standard deviation cannot be negative.");

            double standardNormal;
            if (_hasSpareNormal) {
                standardNormal = _spareNormal;
                _hasSpareNormal = false;
            } else {
                // The Box-Muller transform yields two independent standard-normal variates per pair of
                // draws; return one now and cache the other so the next call needs no new draws.
                double u1 = 1.0 - NextDouble();
                double u2 = 1.0 - NextDouble();
                double magnitude = Math.Sqrt(-2.0 * Math.Log(u1));
                standardNormal = magnitude * Math.Cos(2.0 * Math.PI * u2);
                _spareNormal = magnitude * Math.Sin(2.0 * Math.PI * u2);
                _hasSpareNormal = true;
            }

            return mean + stDev * standardNormal;
        }

        private double _spareNormal;
        private bool _hasSpareNormal;

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

        /// <summary>
        /// Returns a uniformly random value of the enum type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">An enumeration type.</typeparam>
        /// <returns>A randomly selected value defined by <typeparamref name="T"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when <typeparamref name="T"/> defines no values.</exception>
        public virtual T NextEnum<T>() where T : struct, Enum {
            T[] values = EnumValuesCache<T>.Values;
            if (values.Length == 0)
                throw new InvalidOperationException($"Enum type '{typeof(T)}' has no defined values to choose from.");

            return values[NextInt(values.Length)];
        }

        /// <summary>
        /// Returns either -1 or +1 with equal probability.
        /// </summary>
        /// <returns>-1 or +1.</returns>
        public virtual int NextSign() => NextBool() ? 1 : -1;

        /// <summary>
        /// Generates a <see cref="Guid"/> populated with random bytes.
        /// </summary>
        /// <remarks>
        /// The bytes come from this (non-cryptographic) generator, so the result is not an RFC 4122
        /// version-4 UUID; do not use it where a secure or standards-compliant identifier is required.
        /// </remarks>
        /// <returns>A <see cref="Guid"/> composed of random bytes.</returns>
        public virtual Guid NextGuid() {
            Span<byte> bytes = stackalloc byte[16];
            NextBytes(bytes);
            return new Guid(bytes);
        }

        /// <summary>Per-type cache of an enum's declared values, populated once per <typeparamref name="T"/>.</summary>
        private static class EnumValuesCache<T> where T : struct, Enum {
            public static readonly T[] Values = (T[])Enum.GetValues(typeof(T));
        }
    }
}