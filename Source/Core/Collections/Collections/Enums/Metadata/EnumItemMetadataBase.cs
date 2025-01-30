using System;

namespace BeeneticToolkit.Collections.Enums.Metadata {

    /// <summary>Represents the base class for metadata that can be associated with <see cref="EnumItem{TKey, TGroup}"/> instances.</summary>
    /// <remarks>This class provides a unique identifier (GUID) to distinguish metadata instances, supports readonly behavior, and can be extended to include additional properties as needed.</remarks>
    public abstract class EnumItemMetadataBase : IHasMetadata<EnumItemMetadataBase> {

        #region Fields

        private bool _isReadOnly = false;

        #endregion Fields

        #region Properties

        /// <inheritdoc/>
        public bool IsReadOnly => _isReadOnly;

        /// <summary>Gets the globally unique identifier (GUID) for this metadata instance.</summary>
        public Guid Guid { get; private set; }

        /// <summary>Gets the timestamp indicating when this metadata instance was created.</summary>
        public DateTime CreatedOn { get; private set; }

        /// <summary>Gets or sets the timestamp indicating when this metadata instance was last modified.</summary>
        public DateTime ModifiedOn { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="EnumItemMetadataBase"/> class with a unique GUID and timestamps.</summary>
        /// <remarks>The constructor ensures that the metadata is validated during creation. If validation fails, the object will not be created.</remarks>
        /// <exception cref="MetadataValidationException">Thrown if the metadata fails validation during creation.</exception>
        public EnumItemMetadataBase() {
            Guid = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            ModifiedOn = CreatedOn;

            Validate();
        }

        #endregion Constructor

        #region Equality and Comparison

        /// <summary>Determines whether the specified object is equal to the current metadata instance, based on the GUID.</summary>
        /// <param name="obj">The object to compare with the current metadata instance.</param>
        /// <returns><c>true</c> if the objects are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj) {
            return obj is EnumItemMetadataBase other && Guid == other.Guid;
        }

        /// <summary>Returns a hash code for the current metadata instance, based on its GUID.</summary>
        /// <returns>A hash code for the metadata instance.</returns>
        public override int GetHashCode() {
            return Guid.GetHashCode();
        }

        #endregion Equality and Comparison

        #region Class Behaviour

        /// <summary>Validates the metadata instance to ensure all required properties are set.</summary>
        /// <exception cref="MetadataValidationException">Thrown if the metadata is in an invalid state.</exception>
        public virtual void Validate() {
            if (string.IsNullOrWhiteSpace(Guid.ToString())) {
                throw new MetadataValidationException("GUID must be set.");
            }
        }

        /// <inheritdoc/>
        public void MarkAsReadOnly() {
            Validate();
            _isReadOnly = true;
        }

        /// <inheritdoc/>
        public void EnsureNotReadOnly() {
            if (_isReadOnly) {
                throw new InvalidOperationException("Metadata is marked as readonly and cannot be modified.");
            }
        }

        /// <inheritdoc/>
        public bool UpdateMetadata(EnumItemMetadataBase metadata) {
            EnsureNotReadOnly();

            if (metadata == null) {
                throw new ArgumentNullException(nameof(metadata), "New metadata cannot be null.");
            }

            metadata.Validate();
            CopyFrom(metadata);
            UpdateModifiedOn();

            return true;
        }

        /// <summary>Copies shared properties from the provided metadata instance into the current instance.</summary>
        /// <param name="source">The metadata instance to copy from.</param>
        protected abstract void CopyFrom(EnumItemMetadataBase source);

        /// <summary>Updates the last modified timestamp to the current time.</summary>
        private void UpdateModifiedOn() {
            ModifiedOn = DateTime.UtcNow;
        }

        #endregion Class Behaviour
    }
}