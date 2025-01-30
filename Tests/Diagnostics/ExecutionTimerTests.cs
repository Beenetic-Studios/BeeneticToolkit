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

        /// <summary>
        /// Tests that <see cref="ExecutionTimer.MeasureExecutionTime{T}"/> correctly measures the execution time of a function that returns a value.
        /// </summary>
        [TestMethod]
        public void MeasureExecutionTime_ReturnsCorrectResultAndTime() {
            // Arrange
            static int testMethod() {
                Task.Delay(50).Wait(); // Simulate work
                return 42;
            }

            // Act
            var (result, elapsedTime) = ExecutionTimer.MeasureExecutionTime(testMethod);

            // Assert
            Assert.AreEqual(42, result, "Method result should be returned correctly.");
            Assert.IsTrue(elapsedTime.TotalMilliseconds >= 50, "Elapsed time should be at least the simulated delay.");
        }

        /// <summary>
        /// Tests that <see cref="ExecutionTimer.MeasureExecutionTime"/> correctly measures the execution time of a void method.
        /// </summary>
        [TestMethod]
        public void MeasureExecutionTime_VoidMethod_ReturnsElapsedTime() {
            // Arrange
            static void testMethod() => Task.Delay(100).Wait();

            // Act
            TimeSpan elapsedTime = ExecutionTimer.MeasureExecutionTime(testMethod);

            // Assert
            Assert.IsTrue(elapsedTime.TotalMilliseconds >= 100, "Elapsed time should be at least the simulated delay.");
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