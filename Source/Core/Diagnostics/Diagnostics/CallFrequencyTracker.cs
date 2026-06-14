using System;
using System.Collections.Concurrent;
using System.Linq;

namespace BeeneticToolkit.Diagnostics {

    /// <summary>
    /// Tracks the frequency of method calls. All members are safe for concurrent use.
    /// </summary>
    public static class CallFrequencyTracker {
        private static readonly ConcurrentDictionary<string, long> _callCounts = new ConcurrentDictionary<string, long>();

        /// <summary>
        /// Increments the call count for a specified method.
        /// </summary>
        /// <param name="methodName">The name of the method being tracked.</param>
        public static void Increment(string methodName) {
            if (string.IsNullOrEmpty(methodName))
                throw new ArgumentNullException(nameof(methodName));

            _callCounts.AddOrUpdate(methodName, 1, (_, current) => current + 1);
        }

        /// <summary>
        /// Gets the call count for a specified method.
        /// </summary>
        /// <param name="methodName">The name of the method.</param>
        /// <returns>The number of times the method has been called.</returns>
        public static long GetCallCount(string methodName) {
            if (string.IsNullOrEmpty(methodName))
                throw new ArgumentNullException(nameof(methodName));

            return _callCounts.TryGetValue(methodName, out var count) ? count : 0;
        }

        /// <summary>
        /// Gets a formatted report of all tracked call counts.
        /// </summary>
        /// <returns>A string report of all tracked methods and their call counts.</returns>
        public static string GetReport() {
            return string.Join("\n", _callCounts.Select(kvp => $"{kvp.Key}: {kvp.Value} calls"));
        }
    }
}