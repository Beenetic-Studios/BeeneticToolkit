using System;

namespace BeeneticToolkit.Collections.Enums.Metadata {

    /// <summary>Represents an exception that is thrown when metadata validation fails.</summary>
    public class MetadataValidationException : Exception {

        /// <summary>Initializes a new instance of the <see cref="MetadataValidationException"/> class with a default message.</summary>
        public MetadataValidationException() : base("Metadata validation failed.") { }

        /// <summary>Initializes a new instance of the <see cref="MetadataValidationException"/> class with a specified error message.</summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public MetadataValidationException(string message) : base(message) { }

        /// <summary>Initializes a new instance of the <see cref="MetadataValidationException"/> class with a specified error message and a reference to the inner exception that caused this exception.</summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that caused the current exception.</param>
        public MetadataValidationException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>Initializes a new instance of the <see cref="MetadataValidationException"/> class with serialized data.</summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        protected MetadataValidationException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context
        ) : base(info, context) { }

        /// <summary>Gets or sets additional information about the validation failure.</summary>
        public string? ValidationDetails { get; set; }
    }
}