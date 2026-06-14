using System;

namespace BeeneticToolkit.Random {

    /// <summary>
    /// Represents a strongly typed key used to identify a random number generator
    /// within an <see cref="RandomEnvironment"/>.
    /// </summary>
    /// <remarks>
    /// <see cref="RandomKey"/> provides a readable and reusable alternative to raw string keys
    /// while still allowing interoperability with APIs that accept string values.
    /// </remarks>
    public readonly struct RandomKey : IEquatable<RandomKey> {

        /// <summary>
        /// Gets the underlying string value of the key.
        /// </summary>
        /// <value>
        /// The string value used to identify a generator.
        /// </value>
        public string Value { get; }

        /// <summary>
        /// Gets a value indicating whether this key is uninitialized or empty.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if the key has no usable value; otherwise, <see langword="false"/>.
        /// </value>
        /// <remarks>
        /// Because <see cref="RandomKey"/> is a struct, a default instance can exist with a null value.
        /// </remarks>
        public bool IsEmpty => string.IsNullOrWhiteSpace(Value);

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomKey"/> struct.
        /// </summary>
        /// <param name="value">The string value for the key.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="value"/> is null, empty, or whitespace.
        /// </exception>
        public RandomKey(string value) {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("RandomKey value cannot be null or whitespace.", nameof(value));

            Value = value;
        }

        /// <summary>
        /// Returns the string representation of the key.
        /// </summary>
        /// <returns>The underlying key value, or an empty string for an uninitialized key.</returns>
        public override string ToString() =>
            Value ?? string.Empty;

        /// <summary>
        /// Determines whether the current key is equal to another <see cref="RandomKey"/>.
        /// </summary>
        /// <param name="other">The key to compare with the current key.</param>
        /// <returns>
        /// <see langword="true"/> if the keys have the same value using ordinal comparison;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public bool Equals(RandomKey other) =>
            string.Equals(Value, other.Value, StringComparison.Ordinal);

        /// <summary>
        /// Determines whether the current key is equal to the specified object.
        /// </summary>
        /// <param name="obj">The object to compare with the current key.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="obj"/> is an <see cref="RandomKey"/>
        /// with the same value; otherwise, <see langword="false"/>.
        /// </returns>
        public override bool Equals(object obj) =>
            obj is RandomKey other && Equals(other);

        /// <summary>
        /// Returns the hash code for this key.
        /// </summary>
        /// <returns>An ordinal string-based hash code for the key.</returns>
        public override int GetHashCode() =>
            Value == null ? 0 : StringComparer.Ordinal.GetHashCode(Value);

        /// <summary>
        /// Determines whether two <see cref="RandomKey"/> values are equal.
        /// </summary>
        /// <param name="left">The first key to compare.</param>
        /// <param name="right">The second key to compare.</param>
        /// <returns>
        /// <see langword="true"/> if both keys are equal; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator ==(RandomKey left, RandomKey right) => left.Equals(right);

        /// <summary>
        /// Determines whether two <see cref="RandomKey"/> values are not equal.
        /// </summary>
        /// <param name="left">The first key to compare.</param>
        /// <param name="right">The second key to compare.</param>
        /// <returns>
        /// <see langword="true"/> if the keys are not equal; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator !=(RandomKey left, RandomKey right) => !left.Equals(right);

        /// <summary>
        /// Converts an <see cref="RandomKey"/> to its underlying string value.
        /// </summary>
        /// <param name="key">The key to convert.</param>
        public static implicit operator string(RandomKey key) => key.Value;

        /// <summary>
        /// Converts a string value to an <see cref="RandomKey"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="value"/> is null, empty, or whitespace.
        /// </exception>
        public static explicit operator RandomKey(string value) => new RandomKey(value);
    }
}