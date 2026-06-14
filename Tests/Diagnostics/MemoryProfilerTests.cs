using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeeneticToolkit.Diagnostics;
using System;

namespace BeeneticToolkit.Tests.Diagnostics {

    /// <summary>
    /// Unit tests for the <see cref="MemoryProfiler"/> class.
    /// </summary>
    /// <remarks>
    /// Marked <see cref="DoNotParallelizeAttribute"/> because <see cref="MemoryProfiler"/> reads
    /// process-wide GC totals; concurrent tests allocating/collecting would otherwise pollute the
    /// measured deltas and make these tests flaky.
    /// </remarks>
    [TestClass]
    [DoNotParallelize]
    public class MemoryProfilerTests {

        /// <summary>
        /// Tests that <see cref="MemoryProfiler.MeasureMemoryUsage{T}"/> correctly measures memory usage for a function that returns a value.
        /// </summary>
        [TestMethod]
        public void MeasureMemoryUsage_ReturnsCorrectMemoryChangeAndResult() {
            // Arrange
            static int[] testMethod() => new int[100_000]; // Allocate ~400 KB

            // Act
            var (memoryChange, result) = MemoryProfiler.MeasureMemoryUsage(testMethod);

            // Assert
            Assert.IsNotNull(result, "The method should return a valid object.");
            Assert.IsTrue(memoryChange > 0, "Memory change should reflect the allocation.");
        }

        /// <summary>
        /// Tests that <see cref="MemoryProfiler.MeasureMemoryUsage"/> correctly measures memory usage for a void method.
        /// </summary>
        [TestMethod]
        public void MeasureMemoryUsage_VoidMethod_ReturnsMemoryChange() {
            // Arrange — keep the allocation rooted so the forced GC in the profiler cannot reclaim it
            // before the post-execution measurement (otherwise the measured delta is ~0).
            byte[]? held = null;
            void testMethod() => held = new byte[200_000]; // Allocate ~200 KB

            // Act
            long memoryChange = MemoryProfiler.MeasureMemoryUsage(testMethod);

            // Assert
            Assert.IsTrue(memoryChange > 0, "Memory change should reflect the allocation.");
            GC.KeepAlive(held);
        }

        /// <summary>
        /// Tests that <see cref="MemoryProfiler.MeasureMemoryUsage{T}"/> throws an exception when passed a null function.
        /// </summary>
        [TestMethod]
        public void MeasureMemoryUsage_NullFunction_ThrowsArgumentNullException() {
            Assert.ThrowsException<ArgumentNullException>(() => MemoryProfiler.MeasureMemoryUsage<int>(null));
        }

        /// <summary>
        /// Tests that <see cref="MemoryProfiler.MeasureMemoryUsage"/> throws an exception when passed a null void method.
        /// </summary>
        [TestMethod]
        public void MeasureMemoryUsage_NullVoidMethod_ThrowsArgumentNullException() {
            Assert.ThrowsException<ArgumentNullException>(() => MemoryProfiler.MeasureMemoryUsage(null));
        }

        /// <summary>
        /// Tests that <see cref="MemoryProfiler.MeasureMemoryUsage{T}"/> accurately measures memory with and without garbage collection.
        /// </summary>
        [TestMethod]
        public void MeasureMemoryUsage_ForceGC_Vs_NoGC() {
            // Arrange
            static byte[] allocateMemory() => new byte[500_000]; // Allocate ~500 KB

            // Act
            var (memoryChangeWithGC, _) = MemoryProfiler.MeasureMemoryUsage(allocateMemory, forceGC: true);
            var (memoryChangeWithoutGC, _) = MemoryProfiler.MeasureMemoryUsage(allocateMemory, forceGC: false);

            // Assert
            Assert.IsTrue(memoryChangeWithGC > 0, "Memory change should be measured with GC.");
            Assert.IsTrue(memoryChangeWithoutGC > 0, "Memory change should be measured without GC.");
        }
    }
}