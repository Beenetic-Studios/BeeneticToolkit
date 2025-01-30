namespace BeeneticToolkit.Collections.ObjectPooling.Policies {

    /// <summary>
    /// Defines the policy for managing pooled objects, including creation, resetting, and validation.
    /// </summary>
    /// <typeparam name="T">The type of object managed by the policy.</typeparam>
    public abstract class PooledObjectPolicy<T> {

        /// <summary>
        /// Creates a new instance of the object.
        /// </summary>
        /// <returns>A new instance of <typeparamref name="T"/>.</returns>
        public abstract T Create();

        /// <summary>
        /// Resets the object before it is returned to the pool.
        /// </summary>
        /// <param name="obj">The object to reset.</param>
        public abstract void Reset(T obj);

        /// <summary>
        /// Validates whether the object is still suitable for reuse.
        /// </summary>
        /// <param name="obj">The object to validate.</param>
        /// <returns><c>true</c> if the object is valid for reuse; otherwise, <c>false</c>.</returns>
        public virtual bool Validate(T obj) => true;
    }
}