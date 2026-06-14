using BeeneticToolkit.Logging.Enums;
using System.Reflection;

namespace BeeneticToolkit.Logging {

    /// <summary>
    /// Defines a general interface for loggers, allowing messages to be logged with varying levels of severity.
    /// </summary>
    /// <remarks>
    /// Named to avoid collision with <c>Microsoft.Extensions.Logging.ILogger</c>, which consumers
    /// frequently import in the same scope.
    /// </remarks>
    public interface IBeeneticLogger {

        /// <summary>
        /// Logs a message with the specified severity.
        /// </summary>
        /// <param name="severity">The severity level of the log message.</param>
        /// <param name="message">The message to be logged.</param>
        /// <param name="prepend">String value to prepend to the message string.</param>
        /// <param name="append">String value to append to the message string.</param>
        void Log(LogSeverity severity, string message, string prepend = " ", string append = "\n");

        /// <summary>
        /// Logs a message with additional context from an object and a method, and with the specified severity.
        /// </summary>
        /// <param name="severity">The severity level of the log message.</param>
        /// <param name="obj">The object context of the log message.</param>
        /// <param name="method">The method context of the log message.</param>
        /// <param name="message">The message to be logged.</param>
        /// <param name="prepend">String value to prepend to the message string.</param>
        /// <param name="append">String value to append to the message string.</param>
        void Log(LogSeverity severity, object obj, MethodBase method, string message, string prepend = " ", string append = "\n");
    }
}