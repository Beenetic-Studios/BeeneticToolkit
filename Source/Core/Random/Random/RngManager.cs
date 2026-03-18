namespace BeeneticToolkit.Random {
    /// <summary>
    /// Represents the roles or contexts in which a random number generator can be used.
    /// This provides type-safe identifiers for registering and retrieving
    /// random number generators via the <see cref="RngManager"/>.
    /// </summary>
    /// <remarks>
    /// Registering a generator under a key or role will overwrite any existing generator for that identifier.
    /// This behavior is consistent across all registration methods.
    /// </remarks>

    public enum RngRole {

        /// <summary>
        /// The default global random number generator role.
        /// </summary>
        Default,

        /// <summary>
        /// A generator dedicated to AI-related randomness,
        /// such as decision-making, behavior trees, or procedural logic.
        /// </summary>
        AI,

        /// <summary>
        /// A generator dedicated to core gameplay randomness,
        /// such as combat rolls, item drops, or level generation.
        /// </summary>
        Gameplay,

        /// <summary>
        /// A generator reserved for testing or debugging scenarios,
        /// where predictable or isolated random behavior is desired.
        /// </summary>
        Testing
    }

    /// <summary>
    /// Provides centralized access to a default global <see cref="RngEnvironment"/>.
    /// <para>
    /// <see cref="RngManager"/> acts as a convenience facade for applications that want
    /// a shared global RNG context identified by either a strongly typed <see cref="RngRole"/>
    /// or a flexible string key.
    /// </para>
    /// <para>
    /// For projects that require isolated RNG scopes, use <see cref="RngEnvironment"/> directly.
    /// </para>
    /// </summary>
    public static class RngManager {
        private static readonly RngEnvironment s_DefaultEnvironment = CreateDefaultEnvironment();

        /// <summary>
        /// Gets the current global random number generator.
        /// <para>
        /// This property is initialized to <see cref="RngRole.Default"/> during startup,
        /// and is therefore guaranteed to be non-null.
        /// </para>
        /// <para>
        /// It may be reassigned to any registered generator through
        /// <see cref="SetCurrent(RngRole)"/> or <see cref="SetCurrent(string)"/>.
        /// </para>
        /// </summary>
        public static RandomGenerator? Current => s_DefaultEnvironment.Current;

        private static RngEnvironment CreateDefaultEnvironment() {
            var environment = new RngEnvironment("Global");
            environment.CreateAndRegister(RngRole.Default.ToString());
            return environment;
        }

        /// <summary>
        /// Registers a random number generator under a specific <see cref="RngRole"/>.
        /// If a generator was previously registered for the same role, it will be replaced.
        /// </summary>
        /// <param name="role">The role to associate with the generator.</param>
        /// <param name="generator">The generator instance to register.</param>
        public static void Register(RngRole role, RandomGenerator generator) =>
            s_DefaultEnvironment.Register(role.ToString(), generator);

        /// <summary>
        /// Registers a random number generator under a custom string key.
        /// This is useful for experimental, modding, or ad hoc scenarios
        /// where predefined <see cref="RngRole"/> values are insufficient.
        /// If a generator was previously registered with the same key, it will be replaced.
        /// </summary>
        /// <param name="key">The custom key to associate with the generator.</param>
        /// <param name="generator">The generator instance to register.</param>
        public static void Register(string key, RandomGenerator generator) =>
            s_DefaultEnvironment.Register(key, generator);

        /// <summary>
        /// Creates and registers a random number generator for the given role,
        /// then returns it. Overwrites any existing generator for the role.
        /// </summary>
        /// <param name="role">The role to register the generator under.</param>
        /// <param name="seed">Optional seed value.</param>
        /// <param name="algorithm">Optional algorithm to use (defaults to Xorshift).</param>
        /// <returns>The created and registered <see cref="RandomGenerator"/> instance.</returns>
        public static RandomGenerator CreateAndRegister(RngRole role, long? seed = null, RngAlgorithm algorithm = RngAlgorithm.Xorshift) =>
            s_DefaultEnvironment.CreateAndRegister(role.ToString(), seed, algorithm);

        /// <summary>
        /// Creates and registers a random number generator for the given key,
        /// then returns it. Overwrites existing entries.
        /// </summary>
        /// <param name="key">The string key to register the generator under.</param>
        /// <param name="seed">Optional seed value.</param>
        /// <param name="algorithm">Optional algorithm to use (defaults to Xorshift).</param>
        /// <returns>The created and registered <see cref="RandomGenerator"/> instance.</returns>
        public static RandomGenerator CreateAndRegister(string key, long? seed = null, RngAlgorithm algorithm = RngAlgorithm.Xorshift) =>
            s_DefaultEnvironment.CreateAndRegister(key, seed, algorithm);

        /// <summary>
        /// Retrieves a random number generator previously registered under a specific <see cref="RngRole"/>.
        /// </summary>
        /// <param name="role">The role of the generator to retrieve.</param>
        /// <returns>The generator associated with the specified role.</returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">
        /// Thrown if no generator has been registered for the given role.
        /// </exception>
        public static RandomGenerator Get(RngRole role) =>
            s_DefaultEnvironment.Get(role.ToString());

        /// <summary>
        /// Retrieves a random number generator previously registered under a custom string key.
        /// </summary>
        /// <param name="key">The key of the generator to retrieve.</param>
        /// <returns>The generator associated with the specified key.</returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">
        /// Thrown if no generator has been registered with the given key.
        /// </exception>
        public static RandomGenerator Get(string key) =>
            s_DefaultEnvironment.Get(key);

        /// <summary>
        /// Sets the <see cref="Current"/> random number generator to the one
        /// associated with the specified <see cref="RngRole"/>.
        /// </summary>
        /// <param name="role">The role of the generator to make current.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">
        /// Thrown if no generator has been registered for the given role.
        /// </exception>
        public static void SetCurrent(RngRole role) =>
            s_DefaultEnvironment.SetCurrent(role.ToString());

        /// <summary>
        /// Sets the <see cref="Current"/> random number generator to the one
        /// associated with the specified custom string key.
        /// </summary>
        /// <param name="key">The key of the generator to make current.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">
        /// Thrown if no generator has been registered with the given key.
        /// </exception>
        public static void SetCurrent(string key) =>
            s_DefaultEnvironment.SetCurrent(key);
    }
}