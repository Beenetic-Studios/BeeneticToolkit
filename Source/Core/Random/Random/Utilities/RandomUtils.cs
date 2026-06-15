using System;
using System.Security.Cryptography;
using System.Text;

namespace BeeneticToolkit.Random.Internal {

    /// <summary>
    /// Internal helpers for seed acquisition and derivation used by the environment system.
    /// </summary>
    internal static class RandomUtils {

        /// <summary>
        /// Derives a deterministic, positive seed from a root seed and a key.
        /// The same root+key always yields the same value, giving each key an independent,
        /// reproducible stream beneath a shared root seed.
        /// </summary>
        public static long DeriveSeed(long rootSeed, string key) {
            var input = $"{rootSeed}_{key}";
            var bytes = Encoding.UTF8.GetBytes(input);

            using var sha = SHA256.Create();
            var hash = sha.ComputeHash(bytes);

            ulong raw = BitConverter.ToUInt64(hash, 0);
            long derived = (long)(raw % long.MaxValue);

            return derived == 0 ? 1 : derived;
        }

        /// <summary>
        /// Generates a positive, high-entropy seed from a cryptographic source. Used once per
        /// environment (or scratch generator) when no explicit seed is supplied, so two instances
        /// created in quick succession still receive well-separated seeds — unlike a clock-based seed,
        /// which could collide within the same tick.
        /// </summary>
        public static long GenerateEntropySeed() {
            var bytes = new byte[8];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(bytes);

            // Clear the sign bit so the result is non-negative, then coerce 0 to satisfy the
            // generator contract (seed must be greater than 0).
            long value = BitConverter.ToInt64(bytes, 0) & long.MaxValue;
            return value == 0 ? 1 : value;
        }
    }
}
