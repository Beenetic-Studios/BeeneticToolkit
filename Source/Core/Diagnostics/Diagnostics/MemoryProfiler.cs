using System;

namespace BeeneticToolkit.Diagnostics {

    /// <summary>
    /// Provides tools for profiling memory usage during method execution.
    /// </summary>
    public static class MemoryProfiler {

        /// <summary>
        /// Measures the change in memory usage before and after a method's execution.
        /// </summary>
        /// <typeparam name="T">The return type of the method.</typeparam>
        /// <param name="method">The method to profile.</param>
        /// <param name="forceGC">Indicates whether garbage collection should be forced before measurement.</param>
        /// <returns>A tuple containing the memory change in bytes and the method's execution result.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the provided method is null.</exception>
        public static (long MemoryChange, T Result) MeasureMemoryUsage<T>(Func<T> method, bool forceGC = true) {
            if (method == null)
                throw new ArgumentNullException(nameof(method));

            long memoryBefore = GC.GetTotalMemory(forceGC);
            T result = method();
            long memoryAfter = GC.GetTotalMemory(forceGC);

            return (memoryAfter - memoryBefore, result);
        }

        /// <summary>
        /// Measures the change in memory usage before and after a method's execution (void method).
        /// </summary>
        /// <param name="method">The method to profile.</param>
        /// <param name="forceGC">Indicates whether garbage collection should be forced before measurement.</param>
        /// <returns>The change in memory usage in bytes.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the provided method is null.</exception>
        public static long MeasureMemoryUsage(Action method, bool forceGC = true) {
            if (method == null)
                throw new ArgumentNullException(nameof(method));

            long memoryBefore = GC.GetTotalMemory(forceGC);
            method();
            long memoryAfter = GC.GetTotalMemory(forceGC);

            return memoryAfter - memoryBefore;
        }
    }
}