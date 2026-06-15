using BeeneticToolkit.Random.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BeeneticToolkit.Random {

    /// <summary>
    /// Provides global, process-wide access to the <see cref="RandomEnvironment"/> system.
    /// <para>
    /// <see cref="RandomManager"/> is a registry of named environments plus a single convenience
    /// <see cref="Scratch"/> generator. Environments are the seedable, reproducible unit: create one
    /// (here or via <c>new RandomEnvironment(...)</c>), register generators on it, and retrieve them by key.
    /// The manager is the global entry point, not a parallel API.
    /// </para>
    /// </summary>
    public static class RandomManager {

        private static readonly object s_Sync = new object();
        private static readonly Dictionary<string, RandomEnvironment> s_Environments = new Dictionary<string, RandomEnvironment>();
        private static RandomGenerator? s_Scratch;

        /// <summary>
        /// Gets the process-wide "I just need a random number" generator. It is seeded from a high-entropy
        /// source on first use and is intentionally <b>not</b> reproducible — use a seeded
        /// <see cref="RandomEnvironment"/> when you need determinism.
        /// </summary>
        /// <remarks>
        /// Like every generator, this instance is <b>not</b> thread-safe. For concurrent use, give each
        /// thread its own generator from an environment (which is also the reproducible path).
        /// </remarks>
        public static RandomGenerator Scratch {
            get {
                lock (s_Sync)
                    return s_Scratch ??= RandomFactory.GetGenerator(RandomAlgorithm.Xoshiro256, RandomUtils.GenerateEntropySeed());
            }
        }

        /// <summary>
        /// Creates a named environment and registers it with the manager, replacing any existing environment
        /// with the same name.
        /// </summary>
        /// <param name="name">The name to register the environment under.</param>
        /// <param name="rootSeed">An optional root seed; when omitted, one is generated and recorded (see <see cref="RandomEnvironment"/>).</param>
        /// <param name="algorithm">The environment's default algorithm. Defaults to xoshiro256**.</param>
        /// <returns>The created environment.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="name"/> is null.</exception>
        public static RandomEnvironment CreateEnvironment(string name, long? rootSeed = null, RandomAlgorithm? algorithm = null) {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var environment = new RandomEnvironment(name, rootSeed, algorithm);
            lock (s_Sync)
                s_Environments[name] = environment;

            return environment;
        }

        /// <summary>
        /// Gets a previously registered environment by name.
        /// </summary>
        /// <param name="name">The name of the environment.</param>
        /// <returns>The environment registered under <paramref name="name"/>.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when no environment is registered with the given name.</exception>
        public static RandomEnvironment GetEnvironment(string name) {
            lock (s_Sync)
                return s_Environments[name];
        }

        /// <summary>
        /// Attempts to get a previously registered environment by name, without throwing.
        /// </summary>
        /// <param name="name">The name of the environment.</param>
        /// <param name="environment">When this method returns <c>true</c>, the matching environment; otherwise <c>null</c>.</param>
        /// <returns><c>true</c> if an environment with the specified name exists; otherwise <c>false</c>.</returns>
        public static bool TryGetEnvironment(string name, [MaybeNullWhen(false)] out RandomEnvironment environment) {
            lock (s_Sync)
                return s_Environments.TryGetValue(name, out environment);
        }
    }
}
