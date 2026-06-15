using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeeneticToolkit.Diagnostics;
using System;
using System.Threading.Tasks;

namespace BeeneticToolkit.Tests.Diagnostics {

    /// <summary>
    /// Unit tests for the <see cref="ExecutionTimer"/> class.
    /// </summary>
    [TestClass]
    public class ExecutionTimerTests {

        // Timer granularity and the difference between the Task.Delay timer clock and Stopwatch mean a
        // measured duration can land a few milliseconds under the requested delay. Allow a small tolerance
        // so these tests verify the timer is in the right ballpark without flaking on loaded CI runners.
        private const double ToleranceMs = 15.0;

        /// <summary>
        /// Tests that <see cref="ExecutionTimer.MeasureExecutionTime{T}"/> correctly measures the execution time of a function that returns a value.
        /// </summary>
        [TestMethod]
        public void MeasureExecutionTime_ReturnsCorrectResultAndTime() {
            // Arrange
            const int delayMs = 50;
            static int testMethod() {
                Task.Delay(delayMs).Wait(); // Simulate work
                return 42;
            }

            // Act
            var (result, elapsedTime) = ExecutionTimer.MeasureExecutionTime(testMethod);

            // Assert
            Assert.AreEqual(42, result, "Method result should be returned correctly.");
            Assert.IsTrue(elapsedTime.TotalMilliseconds >= delayMs - ToleranceMs,
                $"Elapsed time ({elapsedTime.TotalMilliseconds:F1} ms) should be at least the simulated delay within tolerance.");
        }

        /// <summary>
        /// Tests that <see cref="ExecutionTimer.MeasureExecutionTime"/> correctly measures the execution time of a void method.
        /// </summary>
        [TestMethod]
        public void MeasureExecutionTime_VoidMethod_ReturnsElapsedTime() {
            // Arrange
            const int delayMs = 100;
            static void testMethod() => Task.Delay(delayMs).Wait();

            // Act
            TimeSpan elapsedTime = ExecutionTimer.MeasureExecutionTime(testMethod);

            // Assert
            Assert.IsTrue(elapsedTime.TotalMilliseconds >= delayMs - ToleranceMs,
                $"Elapsed time ({elapsedTime.TotalMilliseconds:F1} ms) should be at least the simulated delay within tolerance.");
        }

        /// <summary>
        /// Tests that <see cref="ExecutionTimer.MeasureExecutionTime{T}"/> throws an exception when passed a null function.
        /// </summary>
        [TestMethod]
        public void MeasureExecutionTime_NullFunction_ThrowsArgumentNullException() {
            Assert.ThrowsException<ArgumentNullException>(() => ExecutionTimer.MeasureExecutionTime<int>(null));
        }

        /// <summary>
        /// Tests that <see cref="ExecutionTimer.MeasureExecutionTime"/> throws an exception when passed a null void method.
        /// </summary>
        [TestMethod]
        public void MeasureExecutionTime_NullVoidMethod_ThrowsArgumentNullException() {
            Assert.ThrowsException<ArgumentNullException>(() => ExecutionTimer.MeasureExecutionTime(null));
        }
    }
}