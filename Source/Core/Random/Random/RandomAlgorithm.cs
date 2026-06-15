namespace BeeneticToolkit.Random {

    /// <summary>
    /// Defines the pseudo-random algorithms available for generator creation.
    /// </summary>
    public enum RandomAlgorithm {

        /// <summary>
        /// The xoshiro256** algorithm: fast, high-quality, 2^256-1 period. The default.
        /// </summary>
        Xoshiro256,

        /// <summary>
        /// Represents the Xorshift algorithm.
        /// </summary>
        Xorshift,

        /// <summary>
        /// Represents the Combined Linear Congruential Generator algorithm.
        /// </summary>
        CombinedLCG,

        /// <summary>
        /// Represents the Middle Square Weyl algorithm.
        /// </summary>
        MiddleSquare
    }
}
