using BeeneticToolkit.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeeneticToolkit.Tests.Diagnostics {

    /// <summary>
    /// Unit tests for the <see cref="CallFrequencyTracker"/> class.
    /// </summary>
    [TestClass]
    public class CallFrequencyTrackerTests {

        /// <summary>
        /// Tests that calling <see cref="CallFrequencyTracker.Increment"/> increases the count.
        /// </summary>
        [TestMethod]
        public void Increment_IncreasesCallCount() {
            // Arrange
            string methodName = "TestMethod";
            int initialCount = CallFrequencyTracker.GetCallCount(methodName);

            // Act
            CallFrequencyTracker.Increment(methodName);
            int updatedCount = CallFrequencyTracker.GetCallCount(methodName);

            // Assert
            Assert.AreEqual(initialCount + 1, updatedCount, "Increment should increase the count by 1.");
        }

        /// <summary>
        /// Tests that retrieving the call count for an untracked method returns zero.
        /// </summary>
        [TestMethod]
        public void GetCallCount_UntrackedMethod_ReturnsZero() {
            // Arrange
            string methodName = "UntrackedMethod";

            // Act
            int count = CallFrequencyTracker.GetCallCount(methodName);

            // Assert
            Assert.AreEqual(0, count, "Untracked methods should have a call count of zero.");
        }

        /// <summary>
        /// Tests that calling <see cref="CallFrequencyTracker.Increment"/> multiple times accumulates properly.
        /// </summary>
        [TestMethod]
        public void Increment_MultipleTimes_AccumulatesCorrectly() {
            // Arrange
            string methodName = "RepeatedMethod";
            int initialCount = CallFrequencyTracker.GetCallCount(methodName);

            // Act
            CallFrequencyTracker.Increment(methodName);
            CallFrequencyTracker.Increment(methodName);
            CallFrequencyTracker.Increment(methodName);
            int updatedCount = CallFrequencyTracker.GetCallCount(methodName);

            // Assert
            Assert.AreEqual(initialCount + 3, updatedCount, "Call count should increase by the number of increments.");
        }

        /// <summary>
        /// Tests that <see cref="CallFrequencyTracker.GetReport"/> returns a formatted string with method call counts.
        /// </summary>
        [TestMethod]
        public void GetReport_FormatsOutputCorrectly() {
            // Arrange
            string method1 = "MethodA";
            string method2 = "MethodB";

            CallFrequencyTracker.Increment(method1);
            CallFrequencyTracker.Increment(method2);
            CallFrequencyTracker.Increment(method2);

            // Act
            string report = CallFrequencyTracker.GetReport();

            // Assert
            Assert.IsTrue(report.Contains("MethodA: 1 calls"), "Report should include correct count for MethodA.");
            Assert.IsTrue(report.Contains("MethodB: 2 calls"), "Report should include correct count for MethodB.");
        }

        /// <summary>
        /// Tests that passing null or empty method names throws an exception in <see cref="CallFrequencyTracker.Increment"/>.
        /// </summary>
        [TestMethod]
        public void Increment_NullOrEmptyMethodName_ThrowsException() {
            Assert.ThrowsException<ArgumentNullException>(() => CallFrequencyTracker.Increment(null));
        }

        /// <summary>
        /// Tests that passing null or empty method names throws an exception in <see cref="CallFrequencyTracker.GetCallCount"/>.
        /// </summary>
        [TestMethod]
        public void GetCallCount_NullOrEmptyMethodName_ThrowsException() {
            Assert.ThrowsException<ArgumentNullException>(() => CallFrequencyTracker.GetCallCount(null));
        }
    }
}