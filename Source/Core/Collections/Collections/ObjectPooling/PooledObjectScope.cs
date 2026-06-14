using System;

namespace BeeneticToolkit.Collections.ObjectPooling {

    /// <summary>
    /// A disposable scope, returned by <see cref="ObjectPool{T}.Rent(out T)"/>, that returns a rented
    /// object to its pool when disposed. Being a <see langword="struct"/>, it does not allocate.
    /// </summary>
    /// <typeparam name="T">The type of object managed by the pool.</typeparam>
    public readonly struct PooledObjectScope<T> : IDisposable where T : class {

        private readonly ObjectPool<T> _pool;
        private readonly T _obj;

        /// <summary>Initializes a new scope for the given pool and rented object.</summary>
        /// <param name="pool">The pool the object was rented from.</param>
        /// <param name="obj">The rented object.</param>
        internal PooledObjectScope(ObjectPool<T> pool, T obj) {
            _pool = pool;
            _obj = obj;
        }

        /// <summary>Gets the rented object.</summary>
        public T Value => _obj;

        /// <summary>Returns the rented object to its pool.</summary>
        public void Dispose() => _pool.Return(_obj);
    }
}
