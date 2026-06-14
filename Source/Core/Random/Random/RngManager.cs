using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BeeneticToolkit.Random {

    /// <summary>
    /// Provides global, process-wide access to the <see cref="RngEnvironment"/> system.
    /// <para>
    /// <see cref="RngManager"/> owns a default environment (used by the convenience selection helpers via
    /// <see cref="Current"/>) and a registry of additional named environments. Register and retrieve
    /// generators through <see cref="Default"/> (or another environment); the manager itself is only the
    /// global entry point, not a parallel API.
    /// </para>
    /// </summary>
    public static class RngManager {

        /// <summary>The name of the default global environment.</summary>
        public const string DefaultEnvironmentName = "Global";

        private static readonly object s_Sync = new object();
        private static readonly Dictionary<string, RngEnvironment> s_Environments = new Dictionary<string, RngEnvironment>();
        private static RngEnvironment s_Default;

        static RngManager() {
            s_Default = new RngEnvironment(DefaultEnvironmentName);
            s_Environments[DefaultEnvironmentName] = s_Default;

            // Register an initial generator so Current is non-null out of the box.
            s_Default.CreateAndRegister("Default");
        }

        /// <summary>
        /// Gets the default global <see cref="RngEnvironment"/>. Use it to register and retrieve generators,
        /// e.g. <c>RngManager.Default.CreateAndRegister("enemies")</c>.
        /// </summary>
        public static RngEnvironment Default {
            get { lock (s_Sync) return s_Default; }
        }

        /// <summary>
        /// Gets the current generator of the <see cref="Default"/> environment. This is the generator used by
        /// the selection helpers when no explicit generator is supplied.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown only if the default environment has no current generator, which cannot happen through the public API.
        /// </exception>
        public static RandomGenerator Current =>
            Default.Current ?? throw new InvalidOperationException("The default environment has no current generator.");

        /// <summary>
        /// Creates a named environment and registers it with the manager, replacing any existing environment
        /// with the same name.
        /// </summary>
        /// <param name="name">The name to register the environment under.</param>
        /// <param name="rootSeed">An optional root seed making the environment reproducible (see <see cref="RngEnvironment"/>).</param>
        /// <returns>The created environment.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="name"/> is null.</exception>
        public static RngEnvironment CreateEnvironment(string name, long? rootSeed = null) {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var environment = new RngEnvironment(name, rootSeed);
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
        public static RngEnvironment GetEnvironment(string name) {
            lock (s_Sync)
                return s_Environments[name];
        }

        /// <summary>
        /// Attempts to get a previously registered environment by name, without throwing.
        /// </summary>
        /// <param name="name">The name of the environment.</param>
        /// <param name="environment">When this method returns <c>true</c>, the matching environment; otherwise <c>null</c>.</param>
        /// <returns><c>true</c> if an environment with the specified name exists; otherwise <c>false</c>.</returns>
        public static bool TryGetEnvironment(string name, [MaybeNullWhen(false)] out RngEnvironment environment) {
            lock (s_Sync)
                return s_Environments.TryGetValue(name, out environment);
        }

        /// <summary>
        /// Makes a previously registered environment the <see cref="Default"/>.
        /// </summary>
        /// <param name="name">The name of the environment to make default.</param>
        /// <exception cref="KeyNotFoundException">Thrown when no environment is registered with the given name.</exception>
        public static void SetDefault(string name) {
            lock (s_Sync)
                s_Default = s_Environments[name];
        }
    }
}
