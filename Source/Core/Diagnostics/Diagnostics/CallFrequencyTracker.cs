using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Diagnostics {

    /// <summary>
    /// Tracks the frequency of method calls.
    /// </summary>
    public static class CallFrequencyTracker {
        private static readonly Dictionary<string, int> _callCounts = new Dictionary<string, int>();

        /// <summary>
        /// Increments the call count for a specified method.
        /// </summary>
        /// <param name="methodName">The name of the method being tracked.</param>
        public static void Increment(string methodName) {
            if (string.IsNullOrEmpty(methodName))
                throw new ArgumentNullException(nameof(methodName));

            if (!_callCounts.ContainsKey(methodName)) {
                _callCounts[methodName] = 0;
            }
            _callCounts[methodName]++;
        }

        /// <summary>
        /// Gets the call count for a specified method.
        /// </summary>
        /// <param name="methodName">The name of the method.</param>
        /// <returns>The number of times the method has been called.</returns>
        public static int GetCallCount(string methodName) {
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