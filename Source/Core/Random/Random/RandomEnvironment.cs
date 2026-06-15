using BeeneticToolkit.Random.Internal;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BeeneticToolkit.Random {

    /// <summary>
    /// Represents an isolated, reproducible collection of random number generators grouped under a
    /// single root seed.
    /// <para>
    /// Generators are registered and retrieved by either string key or <see cref="RandomKey"/>. Each
    /// generator created via <see cref="CreateAndRegister(string, long?, RandomAlgorithm?)"/> derives a
    /// deterministic, independent seed from the environment's <see cref="RootSeed"/> and its key, so the
    /// whole environment replays identically from that single value.
    /// </para>
    /// <para>
    /// An environment always has a <see cref="RootSeed"/>: when one is not supplied it is generated from
    /// a high-entropy source and recorded, so a run that was not explicitly seeded can still be reproduced
    /// after the fact by reading <see cref="RootSeed"/> and feeding it to a new environment.
    /// </para>
    /// </summary>
    public sealed class RandomEnvironment {
        private readonly Dictionary<string, RandomGenerator> m_Generators = new Dictionary<string, RandomGenerator>();
        private readonly object m_Sync = new object();
        private readonly RandomAlgorithm m_DefaultAlgorithm;

        /// <summary>
        /// Gets the name of the environment.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the root seed of the environment.
        /// <para>
        /// Every generator created via <see cref="CreateAndRegister(string, long?, RandomAlgorithm?)"/>
        /// without an explicit seed derives its seed deterministically from this value and the
        /// registration key, so the whole environment is reproducible from this single number.
        /// </para>
        /// </summary>
        public long RootSeed { get; }

        /// <summary>
        /// Gets the default algorithm used by <see cref="CreateAndRegister(string, long?, RandomAlgorithm?)"/>
        /// when a per-generator algorithm is not specified.
        /// </summary>
        public RandomAlgorithm DefaultAlgorithm => m_DefaultAlgorithm;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomEnvironment"/> class.
        /// </summary>
        /// <param name="name">The name of the environment.</param>
        /// <param name="rootSeed">
        /// An optional root seed. When omitted, a high-entropy seed is generated and recorded in
        /// <see cref="RootSeed"/>, keeping the environment reproducible after the fact.
        /// </param>
        /// <param name="algorithm">
        /// The default algorithm for generators registered without an explicit one. Defaults to xoshiro256**.
        /// </param>
        public RandomEnvironment(string name, long? rootSeed = null, RandomAlgorithm? algorithm = null) {
            Name = name;
            RootSeed = rootSeed ?? RandomUtils.GenerateEntropySeed();
            m_DefaultAlgorithm = algorithm ?? RandomAlgorithm.Xoshiro256;
        }

        /// <summary>
        /// Registers a generator under a string key, replacing any generator already registered with that key.
        /// </summary>
        /// <param name="key">The key to associate with the generator.</param>
        /// <param name="generator">The generator instance to register.</param>
        /// <remarks>
        /// Use this to register a <i>custom</i> <see cref="IRandomGenerator"/> implementation. Built-in
        /// generators should be created with <see cref="CreateAndRegister(string, long?, RandomAlgorithm?)"/>
        /// so their seeds are governed by the environment's <see cref="RootSeed"/>.
        /// </remarks>
        public void Register(string key, RandomGenerator generator) {
            lock (m_Sync)
                m_Generators[key] = generator;
        }

        /// <summary>
        /// Registers a generator under a <see cref="RandomKey"/>, replacing any generator already registered with that key.
        /// </summary>
        /// <param name="key">The strongly typed key to associate with the generator.</param>
        /// <param name="generator">The generator instance to register.</param>
        public void Register(RandomKey key, RandomGenerator generator) =>
            Register(key.Value, generator);

        /// <summary>
        /// Creates a built-in generator, registers it under the specified key, and returns it.
        /// Replaces any generator already registered with that key.
        /// </summary>
        /// <param name="key">The key to register the generator under.</param>
        /// <param name="seed">
        /// Optional explicit seed. Omit it for the reproducible path — the seed is derived deterministically
        /// from the environment's <see cref="RootSeed"/> and <paramref name="key"/>. Supplying a value pins
        /// this single generator to that seed, overriding the root-derived value.
        /// </param>
        /// <param name="algorithm">Optional algorithm. Defaults to the environment's <see cref="DefaultAlgorithm"/>.</param>
        /// <returns>The created and registered <see cref="RandomGenerator"/> instance.</returns>
        public RandomGenerator CreateAndRegister(string key, long? seed = null, RandomAlgorithm? algorithm = null) {
            long effectiveSeed = seed ?? RandomUtils.DeriveSeed(RootSeed, key);
            var generator = RandomFactory.GetGenerator(algorithm ?? m_DefaultAlgorithm, effectiveSeed);
            Register(key, generator);
            return generator;
        }

        /// <summary>
        /// Creates a built-in generator, registers it under the specified <see cref="RandomKey"/>, and returns it.
        /// Replaces any generator already registered with that key.
        /// </summary>
        /// <param name="key">The strongly typed key to register the generator under.</param>
        /// <param name="seed">Optional explicit seed; omit to derive from the root seed. See the string overload.</param>
        /// <param name="algorithm">Optional algorithm. Defaults to the environment's <see cref="DefaultAlgorithm"/>.</param>
        /// <returns>The created and registered <see cref="RandomGenerator"/> instance.</returns>
        public RandomGenerator CreateAndRegister(RandomKey key, long? seed = null, RandomAlgorithm? algorithm = null) =>
            CreateAndRegister(key.Value, seed, algorithm);

        /// <summary>
        /// Retrieves a generator previously registered under the specified key.
        /// </summary>
        /// <param name="key">The key of the generator to retrieve.</param>
        /// <returns>The generator associated with the specified key.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if no generator has been registered with the given key.</exception>
        public RandomGenerator Get(string key) {
            lock (m_Sync)
                return m_Generators[key];
        }

        /// <summary>
        /// Retrieves a generator previously registered under the specified <see cref="RandomKey"/>.
        /// </summary>
        /// <param name="key">The strongly typed key of the generator to retrieve.</param>
        /// <returns>The generator associated with the specified key.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if no generator has been registered with the given key.</exception>
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
    }
}
