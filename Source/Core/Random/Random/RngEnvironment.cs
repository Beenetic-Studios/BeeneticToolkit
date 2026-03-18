using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BeeneticToolkit.Tests")]

namespace BeeneticToolkit.Random {

    /// <summary>
    /// Represents an isolated collection of random number generators grouped under a single environment.
    /// <para>
    /// <see cref="RngEnvironment"/> allows related RNG instances to be registered and retrieved
    /// by string key while keeping them scoped to a specific environment.
    /// </para>
    /// <para>
    /// Each environment also exposes a convenience <see cref="Current"/> generator,
    /// which remains <see langword="null"/> until the first generator is registered
    /// unless explicitly assigned later through <see cref="SetCurrent(string)"/>.
    /// </para>
    /// </summary>
    public sealed class RngEnvironment {
        private readonly Dictionary<string, RandomGenerator> m_Generators = new Dictionary<string, RandomGenerator>();

        /// <summary>
        /// Gets the name of the environment.
        /// </summary>
        /// <value>
        /// A descriptive name used to identify the environment.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets the current random number generator for this environment.
        /// <para>
        /// This property is assigned to the first generator registered in the environment,
        /// but may be reassigned through <see cref="SetCurrent(string)"/>.
        /// </para>
        /// </summary>
        /// <value>
        /// The current random number generator for the environment,
        /// or <see langword="null"/> if no generator has been registered yet.
        /// </value>
        public RandomGenerator? Current { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RngEnvironment"/> class.
        /// </summary>
        /// <param name="name">The name of the environment.</param>
        public RngEnvironment(string name) {
            Name = name;
        }

        /// <summary>
        /// Registers a random number generator under a specific string key.
        /// If a generator was previously registered with the same key, it will be replaced.
        /// </summary>
        /// <param name="key">The key to associate with the generator.</param>
        /// <param name="generator">The generator instance to register.</param>
        /// <remarks>
        /// If <see cref="Current"/> has not yet been assigned, it will be set to the newly registered generator.
        /// </remarks>
        public void Register(string key, RandomGenerator generator) {
            m_Generators[key] = generator;
            Current ??= generator;
        }

        /// <summary>
        /// Creates a new random number generator, registers it under the specified key,
        /// and returns the created instance.
        /// If a generator was previously registered with the same key, it will be replaced.
        /// </summary>
        /// <param name="key">The key to register the generator under.</param>
        /// <param name="seed">Optional seed value.</param>
        /// <param name="algorithm">Optional algorithm to use. Defaults to <see cref="RngAlgorithm.Xorshift"/>.</param>
        /// <returns>The created and registered <see cref="RandomGenerator"/> instance.</returns>
        public RandomGenerator CreateAndRegister(string key, long? seed = null, RngAlgorithm algorithm = RngAlgorithm.Xorshift) {
            var generator = RngFactory.GetGenerator(algorithm, seed);
            Register(key, generator);
            return generator;
        }

        /// <summary>
        /// Retrieves a random number generator previously registered under the specified key.
        /// </summary>
        /// <param name="key">The key of the generator to retrieve.</param>
        /// <returns>The generator associated with the specified key.</returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">
        /// Thrown if no generator has been registered with the given key.
        /// </exception>
        public RandomGenerator Get(string key) => m_Generators[key];

        /// <summary>
        /// Sets the <see cref="Current"/> random number generator to the one
        /// associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the generator to make current.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">
        /// Thrown if no generator has been registered with the given key.
        /// </exception>
        public void SetCurrent(string key) => Current = Get(key);
    }
}