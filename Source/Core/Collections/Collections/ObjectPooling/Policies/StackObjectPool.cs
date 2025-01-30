using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Collections.ObjectPooling.Policies {

    /// <summary>
    /// Stack-based implementation of <see cref="ObjectPool{T}"/>, using a last-in-first-out (LIFO) approach for object storage.
    /// </summary>
    /// <typeparam name="T">The type of object managed by the pool.</typeparam>
    public class StackObjectPool<T> : ObjectPool<T> where T : class {

        #region Fields

        private readonly Stack<T> _stack;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the current number of objects in the pool.
        /// </summary>
        public override int Count => _stack.Count;

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="StackObjectPool{T}"/> class.
        /// </summary>
        /// <param name="policy">The policy used for creating, resetting, and validating pooled objects.</param>
        /// <param name="isDynamic">Indicates whether the pool can dynamically grow when empty.</param>
        /// <param name="maxSize">The maximum number of objects allowed in the pool. Set to 0 for no limit.</param>
        /// <param name="initialCapacity">The initial number of objects to preload into the pool.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="policy"/> is null.</exception>
        public StackObjectPool(PooledObjectPolicy<T> policy, bool isDynamic = true, int maxSize = 0, int initialCapacity = 0)
            : base(policy, isDynamic, maxSize) {
            _stack = new Stack<T>(initialCapacity);

            for (int i = 0; i < initialCapacity; i++) {
                _stack.Push(_policy.Create());
            }
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Retrieves an object from the pool.
        /// </summary>
        /// <returns>An instance of <typeparamref name="T"/> from the pool.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the pool is empty and cannot grow dynamically.</exception>
        public override T Get() {
            T obj;

            if (_stack.Count > 0) {
                obj = _stack.Pop();
            } else if (_isDynamic || _maxSize == 0 || _stack.Count < _maxSize) {
                obj = _policy.Create();
            } else {
                throw new InvalidOperationException("Pool is empty and not dynamic.");
            }

            return _policy.Validate(obj) ? obj : _policy.Create();
        }

        /// <summary>
        /// Returns an object to the pool.
        /// </summary>
        /// <param name="obj">The object to return to the pool.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="obj"/> is null.</exception>
        public override void Return(T obj) {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            if (_maxSize > 0 && _stack.Count >= _maxSize) {
                if (obj is IDisposable disposableObj) {
                    disposableObj.Dispose();
                }

                return;
            }

            _policy.Reset(obj);
            _stack.Push(obj);
        }

        /// <summary>
        /// Clears all objects from the pool.
        /// </summary>
        /// <remarks>
        /// Objects implementing <see cref="IDisposable"/> are disposed during the clearing process.
        /// </remarks>
        public override void Clear() {
            while (_stack.Count > 0) {
                T obj = _stack.Pop();

                if (obj is IDisposable disposableObj) {
                    disposableObj.Dispose();
                }
            }
        }

        #endregion Methods
    }
}