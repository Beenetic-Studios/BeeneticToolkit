namespace BeeneticToolkit.Random {

    /// <summary>
    /// Provides an interface for random number generation with a variety of methods
    /// to produce random values of different numeric types and ranges.
    /// </summary>
    public interface IRandomNumberGenerator {

        /// <summary>
        /// Generates a random byte array with a default length.
        /// </summary>
        /// <returns>A random byte array of default length.</returns>
        byte[] NextBytes();

        /// <summary>
        /// Generates a random byte array of a specified length.
        /// </summary>
        /// <param name="length">The length of the byte array to generate.</param>
        /// <returns>A random byte array of the specified length.</returns>
        byte[] NextBytes(int length);

        /// <summary>
        /// Generates a random byte array of a specified length, with each byte within a specified range.
        /// </summary>
        /// <param name="length">The length of the byte array to generate.</param>
        /// <param name="min">The inclusive lower bound of the byte range.</param>
        /// <param name="max">The exclusive upper bound of the byte range.</param>
        /// <returns>A random byte array of the specified length, with each byte within the specified range.</returns>
        byte[] NextBytes(int length, byte min, byte max);

        /// <summary>
        /// Generates a non-negative random integer.
        /// </summary>
        /// <returns>A non-negative random integer.</returns>
        int NextInt();

        /// <summary>
        /// Returns a non-negative random integer that is less than the specified maximum.
        /// </summary>
        /// <param name="maxExclusive">The exclusive upper bound of the random number to be generated. maxValue must be greater than or equal to 0.</param>
        /// <returns>A non-negative random integer that is less than maxValue.</returns>
        int NextInt(int maxExclusive);

        /// <summary>
        /// Returns a random integer within a specified range.
        /// </summary>
        /// <param name="minInclusive">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxExclusive">The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns>A random integer that is within the range of minValue and maxValue.</returns>
        int NextInt(int minInclusive, int maxExclusive);

        /// <summary>
        /// Generates a non-negative random long integer.
        /// </summary>
        /// <returns>A non-negative random long integer.</returns>
        long NextLong();

        /// <summary>
        /// Returns a non-negative random long integer that is less than the specified maximum.
        /// </summary>
        /// <param name="maxExclusive">The exclusive upper bound of the random number to be generated. maxValue must be greater than or equal to 0.</param>
        /// <returns>A non-negative random long integer that is less than maxValue.</returns>
        long NextLong(long maxExclusive);

        /// <summary>
        /// Returns a random long integer within a specified range.
        /// </summary>
        /// <param name="minInclusive">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxExclusive">The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns>A random long integer that is within the range of minValue and maxValue.</returns>
        long NextLong(long minInclusive, long maxExclusive);

        /// <summary>
        /// Returns a non-negative random float.
        /// </summary>
        /// <returns>A non-negative random float.</returns>
        float NextFloat();

        /// <summary>
        /// Returns a non-negative random float that is less than the specified maximum.
        /// </summary>
        /// <param name="maxExclusive">The exclusive upper bound of the random number to be generated. maxValue must be greater than or equal to 0.0.</param>
        /// <returns>A non-negative random float that is less than maxValue.</returns>
        float NextFloat(float maxExclusive);

        /// <summary>
        /// Returns a random float within a specified range.
        /// </summary>
        /// <param name="minInclusive">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxExclusive">The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns>A random float that is within the range of minValue and maxValue.</returns>
        float NextFloat(float minInclusive, float maxExclusive);

        /// <summary>
        /// Returns a non-negative random double.
        /// </summary>
        /// <returns>A non-negative random double.</returns>
        double NextDouble();

        /// <summary>
        /// Returns a non-negative random double that is less than the specified maximum.
        /// </summary>
        /// <param name="maxExclusive">The exclusive upper bound of the random number to be generated. maxValue must be greater than or equal to 0.0.</param>
        /// <returns>A non-negative random double that is less than maxValue.</returns>
        double NextDouble(double maxExclusive);

        /// <summary>
        /// Returns a random double within a specified range.
        /// </summary>
        /// <param name="minInclusive">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxExclusive">The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns>A random double that is within the range of minValue and maxValue.</returns>
        double NextDouble(double minInclusive, double maxExclusive);

        /// <summary>
        /// Returns a random double that follows a Normal (normal) distribution with mean 0 and standard deviation 1.
        /// </summary>
        /// <returns>A normally distributed random double.</returns>
        double NextNormal();

        /// <summary>
        /// Returns a random double that follows a Normal (normal) distribution with the specified mean and standard deviation.
        /// </summary>
        /// <param name="mean">The mean of the Normal distribution.</param>
        /// <param name="stdDev">The standard deviation of the Normal distribution. Must be non-negative.</param>
        /// <returns>A normally distributed random double with the specified mean and standard deviation.</returns>
        double NextNormal(double mean, double stdDev);

        /// <summary>
        /// Returns a random boolean value.
        /// </summary>
        /// <returns>A random boolean value.</returns>
        bool NextBool();

        /// <summary>
        /// Returns a random boolean value with the probability of returning true specified by the input parameter.
        /// </summary>
        /// <param name="probability">The probability of returning true. Must be between 0.0 and 1.0.</param>
        /// <returns>A random boolean value influenced by the specified probability.</returns>
        bool NextBool(float probability);
    }
}