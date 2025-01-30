namespace BeeneticToolkit.Collections.Enums.Metadata {

    /// <summary>Defines an interface for types that can be associated with metadata, supporting readonly behavior.</summary>
    /// <typeparam name="T">The type of the metadata.</typeparam>
    public interface IHasMetadata<T> {

        /// <summary>Gets a value indicating whether the metadata is readonly.</summary>
        bool IsReadOnly { get; }

        /// <summary>Marks the metadata as readonly, preventing further modifications.</summary>
        void MarkAsReadOnly();

        /// <summary>Ensures that the metadata can be modified.</summary>
        void EnsureNotReadOnly();

        /// <summary>Attempts to update the metadata, enforcing readonly behavior and validation.</summary>
        /// <param name="metadata">The new metadata instance to associate.</param>
        /// <returns><c>true</c> if the metadata was successfully updated; otherwise, <c>false</c>.</returns>
        bool UpdateMetadata(T metadata);
    }
}