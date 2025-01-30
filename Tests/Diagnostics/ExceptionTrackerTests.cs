using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeeneticToolkit.Diagnostics;
using System;

namespace BeeneticToolkit.Tests.Diagnostics {

    /// <summary>
    /// Unit tests for the <see cref="ExceptionTracker"/> class.
    /// </summary>
    [TestClass]
    public class ExceptionTrackerTests {

        /// <summary>
        /// Tests that <see cref="ExceptionTracker.Track"/> correctly formats an exception report.
        /// </summary>
        [TestMethod]
        public void Track_GeneratesDetailedExceptionReport() {
            // Arrange
            Exception testException = new("Test exception message");

            // Act
            string report = ExceptionTracker.Track(testException, "Unit test scenario");

            // Assert
            Assert.IsTrue(report.Contains("Exception Report"), "Report should contain exception header.");
            Assert.IsTrue(report.Contains("Test exception message"), "Report should include exception message.");
            Assert.IsTrue(report.Contains("Unit test scenario"), "Report should include provided context.");
            Assert.IsTrue(report.Contains("Method: Track_GeneratesDetailedExceptionReport"),
                "Report should include the caller method name.");
        }

        /// <summary>
        /// Tests that <see cref="ExceptionTracker.Track"/> throws an exception when passed a null exception.
        /// </summary>
        [TestMethod]
        public void Track_NullException_ThrowsArgumentNullException() {
            Assert.ThrowsException<ArgumentNullException>(() => ExceptionTracker.Track(null));
        }

        /// <summary>
        /// Tests that <see cref="ExceptionTracker.TrackWithCategory"/> correctly formats an exception report with a category.
        /// </summary>
        [TestMethod]
        public void TrackWithCategory_IncludesCategoryInReport() {
            // Arrange
            Exception testException = new("Critical error occurred");

            // Act
            string report = ExceptionTracker.TrackWithCategory(testException, ExceptionCategory.Critical, "During system failure");

            // Assert
            Assert.IsTrue(report.Contains("Category: Critical"), "Report should include the correct exception category.");
            Assert.IsTrue(report.Contains("Critical error occurred"), "Report should include the correct exception message.");
            Assert.IsTrue(report.Contains("During system failure"), "Report should include the provided context.");
        }

        /// <summary>
        /// Tests that <see cref="ExceptionTracker.TrackWithCategory"/> throws an exception when passed a null exception.
        /// </summary>
        [TestMethod]
        public void TrackWithCategory_NullException_ThrowsArgumentNullException() {
            Assert.ThrowsException<ArgumentNullException>(() => ExceptionTracker.TrackWithCategory(null, ExceptionCategory.Warning));
        }

        /// <summary>
        /// Tests that method tracking correctly captures method name, file path, and line number.
        /// </summary>
        [TestMethod]
        public void Track_CapturesMethodAndFileInfo() {
            // Arrange
            Exception testException = new("Testing method context");

            // Act
            string report = ExceptionTracker.Track(testException);

            // Assert
            Assert.IsTrue(report.Contains("Method: Track_CapturesMethodAndFileInfo"),
                "Report should contain the correct calling method name.");
            Assert.IsTrue(report.Contains("File:"), "Report should contain the file path.");
            Assert.IsTrue(report.Contains("Line:"), "Report should contain the line number.");
        }
    }
}