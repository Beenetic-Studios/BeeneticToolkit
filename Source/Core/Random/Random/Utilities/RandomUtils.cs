using System;
using System.Security.Cryptography;
using System.Text;

namespace BeeneticToolkit.Random.Utilities {

    /// <summary>
    /// Provides utility methods for the RandomGenerator class.
    /// </summary>
    public static class RandomUtils {

        /// <summary>
        /// Derives a deterministic seed from a root seed and a system key.
        /// Ensures same root+key combo always yields the same result.
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
    }
}