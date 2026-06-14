using BeeneticToolkit.Collections.ObjectPooling.Policies;
using System;

namespace BeeneticToolkit.Collections.ObjectPooling {

    /// <summary>
    /// Abstract base class for object pools, providing core operations for retrieving, returning, and clearing pooled objects.
    /// </summary>
    /// <typeparam name="T">The type of object managed by the pool.</typeparam>
    public abstract class ObjectPool<T> where T : class {

        #region Fields

        /// <summary>
        /// Defines the policy used for creating, resetting, and validating pooled objects.
        /// </summary>
        protected readonly PooledObjectPolicy<T> _policy;

        /// <summary>
        /// Indicates whether the pool can dynamically grow when it runs out of objects.
        /// </summary>
        protected readonly bool _isDynamic;

        /// <summary>
        /// Specifies the maximum number of objects allowed in the pool. A value of 0 indicates no limit.
        /// </summary>
        protected readonly int _maxSize;

        /// <summary>
        /// Synchronization root used by derived pools to guard concurrent access to their backing store.
        /// </summary>
        protected readonly object _syncRoot = new object();

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the current number of objects in the pool.
        /// </summary>
        public abstract int Count { get; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectPool{T}"/> class.
        /// </summary>
        /// <param name="policy">The policy used for creating, resetting, and validating pooled objects.</param>
        /// <param name="isDynamic">Indicates whether the pool can dynamically grow when empty.</param>
        /// <param name="maxSize">The maximum number of objects allowed in the pool. Set to 0 for no limit.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="policy"/> is null.</exception>
        protected ObjectPool(PooledObjectPolicy<T> policy, bool isDynamic = true, int maxSize = 0) {
            _policy = policy ?? throw new ArgumentNullException(nameof(policy));
            _isDynamic = isDynamic;
            _maxSize = maxSize;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Retrieves an object from the pool.
        /// </summary>
        /// <returns>An instance of <typeparamref name="T"/> from the pool.</returns>
        public abstract T Get();

        /// <summary>
        /// Rents an object from the pool and returns a scope that returns it when disposed.
        /// </summary>
        /// <param name="obj">The rented object.</param>
        /// <returns>A disposable scope; disposing it returns <paramref name="obj"/> to the pool.</returns>
        /// <example>
        /// <code>
        /// using (pool.Rent(out var buffer)) {
        ///     // use buffer ...
        /// } // buffer is automatically returned here
        /// </code>
        /// </example>
        public PooledObjectScope<T> Rent(out T obj) {
            obj = Get();
            return new PooledObjectScope<T>(this, obj);
        }

        /// <summary>
        /// Returns an object to the pool.
        /// </summary>
        /// <param name="obj">The object to return to the pool.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="obj"/> is null.</exception>
        public abstract void Return(T obj);

        /// <summary>
        /// Clears all objects from the pool.
        /// </summary>
        public abstract void Clear();

        #endregion Methods
    }
}