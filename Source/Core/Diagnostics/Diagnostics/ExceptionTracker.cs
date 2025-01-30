using System;
using System.Runtime.CompilerServices;

namespace BeeneticToolkit.Diagnostics {

    /// <summary>
    /// Provides utilities for detailed exception tracking and reporting.
    /// </summary>
    public static class ExceptionTracker {

        /// <summary>
        /// Tracks an exception with detailed method context and an optional category.
        /// </summary>
        /// <param name="exception">The exception to track.</param>
        /// <param name="context">Additional context information (optional).</param>
        /// <param name="category">The category of the exception (optional).</param>
        /// <param name="methodName">The name of the method where the exception occurred (auto-filled).</param>
        /// <param name="filePath">The file path of the method (auto-filled).</param>
        /// <param name="lineNumber">The line number of the method (auto-filled).</param>
        /// <returns>A detailed exception report as a string.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the provided exception is null.</exception>
        public static string Track(
            Exception exception,
            string context = "",
            ExceptionCategory? category = null,
            [CallerMemberName] string methodName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0) {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            string categoryLabel = category.HasValue ? $"Category: {category.Value}\n" : string.Empty;

            return $@"
                {categoryLabel}Exception Report:
                    Context: {context}
                    Message: {exception.Message}
                    Stack Trace: {exception.StackTrace}
                    Method: {methodName}
                    File: {filePath}
                    Line: {lineNumber}";
        }

        /// <summary>
        /// Tracks an exception with detailed method context, using a specified category.
        /// </summary>
        /// <param name="exception">The exception to track.</param>
        /// <param name="category">The category of the exception.</param>
        /// <param name="context">Additional context information (optional).</param>
        /// <param name="methodName">The name of the method where the exception occurred (auto-filled).</param>
        /// <param name="filePath">The file path of the method (auto-filled).</param>
        /// <param name="lineNumber">The line number of the method (auto-filled).</param>
        /// <returns>A detailed exception report as a string.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the provided exception is null.</exception>
        public static string TrackWithCategory(
            Exception exception,
            ExceptionCategory category,
            string context = "",
            [CallerMemberName] string methodName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0) {
            return Track(exception, context, category, methodName, filePath, lineNumber);
        }
    }

    /// <summary>
    /// Represents the category of an exception for tracking and reporting purposes.
    /// </summary>
    public enum ExceptionCategory {

        /// <summary>
        /// Indicates a critical exception that requires immediate attention.
        /// </summary>
        Critical,

        /// <summary>
        /// Indicates a warning exception that may not be critical but should be reviewed.
        /// </summary>
        Warning,

        /// <summary>
        /// Indicates an informational exception that does not require immediate action.
        /// </summary>
        Info
    }
}