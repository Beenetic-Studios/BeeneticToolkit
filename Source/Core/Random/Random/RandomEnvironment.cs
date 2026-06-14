using BeeneticToolkit.Random.Utilities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BeeneticToolkit.Tests")]

namespace BeeneticToolkit.Random {

    /// <summary>
    /// Represents an isolated collection of random number generators grouped under a single environment.
    /// <para>
    /// <see cref="RandomEnvironment"/> allows related RNG instances to be registered and retrieved
    /// by either string key or <see cref="RandomKey"/> while keeping them scoped to a specific environment.
    /// </para>
    /// <para>
    /// Each environment also exposes a convenience <see cref="Current"/> generator,
    /// which remains <see langword="null"/> until the first generator is registered
    /// unless explicitly assigned later through <see cref="SetCurrent(string)"/> or
    /// <see cref="SetCurrent(RandomKey)"/>.
    /// </para>
    /// </summary>
    public sealed class RandomEnvironment {
        private readonly Dictionary<string, RandomGenerator> m_Generators = new Dictionary<string, RandomGenerator>();
        private readonly object m_Sync = new object();
        private readonly long? m_RootSeed;
        private RandomGenerator? m_Current;

        /// <summary>
        /// Gets the name of the environment.
        /// </summary>
        /// <value>
        /// A descriptive name used to identify the environment.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets the root seed of the environment, or <see langword="null"/> if none was supplied.
        /// </summary>
        /// <remarks>
        /// When a root seed is present, <see cref="CreateAndRegister(string, long?, RandomAlgorithm)"/> derives each
        /// generator's seed deterministically from the root seed and the registration key, so the whole
        /// environment is reproducible from this single value.
        /// </remarks>
        public long? RootSeed => m_RootSeed;

        /// <summary>
        /// Gets the current random number generator for this environment.
        /// <para>
        /// This property is assigned to the first generator registered in the environment,
        /// but may be reassigned through <see cref="SetCurrent(string)"/> or <see cref="SetCurrent(RandomKey)"/>.
        /// </para>
        /// </summary>
        /// <value>
        /// The current random number generator for the environment,
        /// or <see langword="null"/> if no generator has been registered yet.
        /// </value>
        public RandomGenerator? Current {
            get { lock (m_Sync) return m_Current; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomEnvironment"/> class.
        /// </summary>
        /// <param name="name">The name of the environment.</param>
        /// <param name="rootSeed">
        /// An optional root seed. When supplied, generators created via
        /// <see cref="CreateAndRegister(string, long?, RandomAlgorithm)"/> without an explicit seed derive a
        /// deterministic per-key seed from it, making the entire environment reproducible.
        /// </param>
        public RandomEnvironment(string name, long? rootSeed = null) {
            Name = name;
            m_RootSeed = rootSeed;
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
            lock (m_Sync) {
                m_Generators[key] = generator;
                m_Current ??= generator;
            }
        }

        /// <summary>
        /// Registers a random number generator under a specific <see cref="RandomKey"/>.
        /// If a generator was previously registered with the same key, it will be replaced.
        /// </summary>
        /// <param name="key">The strongly typed key to associate with the generator.</param>
        /// <param name="generator">The generator instance to register.</param>
        /// <remarks>
        /// If <see cref="Current"/> has not yet been assigned, it will be set to the newly registered generator.
        /// </remarks>
        public void Register(RandomKey key, RandomGenerator generator) =>
            Register(key.Value, generator);

        /// <summary>
        /// Creates a new random number generator, registers it under the specified key,
        /// and returns the created instance.
        /// If a generator was previously registered with the same key, it will be replaced.
        /// </summary>
        /// <param name="key">The key to register the generator under.</param>
        /// <param name="seed">
        /// Optional explicit seed. If omitted and the environment has a <see cref="RootSeed"/>, the seed is
        /// derived deterministically from the root seed and <paramref name="key"/>; otherwise it is time-based.
        /// </param>
        /// <param name="algorithm">Optional algorithm to use. Defaults to xoshiro256**.</param>
        /// <returns>The created and registered <see cref="RandomGenerator"/> instance.</returns>
        public RandomGenerator CreateAndRegister(string key, long? seed = null, RandomAlgorithm algorithm = RandomAlgorithm.Xoshiro256) {
            long? effectiveSeed = seed ?? (m_RootSeed.HasValue ? RandomUtils.DeriveSeed(m_RootSeed.Value, key) : (long?)null);
            var generator = RandomFactory.GetGenerator(algorithm, effectiveSeed);
            Register(key, generator);
            return generator;
        }

        /// <summary>
        /// Creates a new random number generator, registers it under the specified <see cref="RandomKey"/>,
        /// and returns the created instance.
        /// If a generator was previously registered with the same key, it will be replaced.
        /// </summary>
        /// <param name="key">The strongly typed key to register the generator under.</param>
        /// <param name="seed">Optional seed value.</param>
        /// <param name="algorithm">Optional algorithm to use. Defaults to xoshiro256**.</param>
        /// <returns>The created and registered <see cref="RandomGenerator"/> instance.</returns>
        public RandomGenerator CreateAndRegister(RandomKey key, long? seed = null, RandomAlgorithm algorithm = RandomAlgorithm.Xoshiro256) =>
            CreateAndRegister(key.Value, seed, algorithm);

        /// <summary>
        /// Retrieves a random number generator previously registered under the specified key.
        /// </summary>
        /// <param name="key">The key of the generator to retrieve.</param>
        /// <returns>The generator associated with the specified key.</returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">
        /// Thrown if no generator has been registered with the given key.
        /// </exception>
        public RandomGenerator Get(string key) {
            lock (m_Sync)
                return m_Generators[key];
        }

        /// <summary>
        /// Retrieves a random number generator previously registered under the specified <see cref="RandomKey"/>.
        /// </summary>
        /// <param name="key">The strongly typed key of the generator to retrieve.</param>
        /// <returns>The generator associated with the specified key.</returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">
        /// Thrown if no generator has been registered with the given key.
        /// </exception>
        public RandomGenerator Get(RandomKey key) => Get(key.Value);

        /// <summary>
        /// Attempts to retrieve a generator registered under the specified key, without throwing.
        /// </summary>
        /// <param name="key">The key of the generator to retrieve.</param>
        /// <param name="generator">When this method returns <c>true</c>, the registered generator; otherwise <c>null</c>.</param>
        /// <returns><c>true</c> if a generator was registered under <paramref name="key"/>; otherwise <c>false</c>.</returns>
        public bool TryGet(string key, [MaybeNullWhen(false)] out RandomGenerator generator) {
            lock (m_Sync)
                return m_Generators.TryGetValue(key, out generator);
        }

        /// <summary>
        /// Attempts to retrieve a generator registered under the specified <see cref="RandomKey"/>, without throwing.
        /// </summary>
        /// <param name="key">The strongly typed key of the generator to retrieve.</param>
        /// <param name="generator">When this method returns <c>true</c>, the registered generator; otherwise <c>null</c>.</param>
        /// <returns><c>true</c> if a generator was registered under <paramref name="key"/>; otherwise <c>false</c>.</returns>
        public bool TryGet(RandomKey key, [MaybeNullWhen(false)] out RandomGenerator generator) => TryGet(key.Value, out generator);

        /// <summary>
        /// Sets the <see cref="Current"/> random number generator to the one
        /// associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the generator to make current.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">
        /// Thrown if no generator has been registered with the given key.
        /// </exception>
        public void SetCurrent(string key) {
            lock (m_Sync)
                m_Current = m_Generators[key];
        }

        /// <summary>
        /// Sets the <see cref="Current"/> random number generator to the one
        /// associated with the specified <see cref="RandomKey"/>.
        /// </summary>
        /// <param name="key">The strongly typed key of the generator to make current.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">
        /// Thrown if no generator has been registered with the given key.
        /// </exception>
        public void SetCurrent(RandomKey key) => SetCurrent(key.Value);
    }
}