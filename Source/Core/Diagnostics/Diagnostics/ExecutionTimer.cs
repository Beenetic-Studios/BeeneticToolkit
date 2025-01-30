using System;
using System.Diagnostics;

namespace BeeneticToolkit.Diagnostics {

    /// <summary>
    /// Provides utilities for measuring the execution time of methods.
    /// </summary>
    public static class ExecutionTimer {

        /// <summary>
        /// Measures the execution time of a method that returns a result.
        /// </summary>
        /// <typeparam name="T">The return type of the method.</typeparam>
        /// <param name="method">The method to measure.</param>
        /// <returns>A tuple containing the method's result and the elapsed time.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the provided method is null.</exception>
        public static (T Result, TimeSpan ElapsedTime) MeasureExecutionTime<T>(Func<T> method) {
            if (method == null)
                throw new ArgumentNullException(nameof(method));

            Stopwatch stopwatch = Stopwatch.StartNew();
            T result = method();
            stopwatch.Stop();

            return (result, stopwatch.Elapsed);
        }

        /// <summary>
        /// Measures the execution time of a method that does not return a result.
        /// </summary>
        /// <param name="method">The method to measure.</param>
        /// <returns>The elapsed time of the method's execution.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the provided method is null.</exception>
        public static TimeSpan MeasureExecutionTime(Action method) {
            if (method == null)
                throw new ArgumentNullException(nameof(method));

            Stopwatch stopwatch = Stopwatch.StartNew();
            method();
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
    }
}