using BeeneticToolkit.Logging.Enums;
using System.Diagnostics;
using System.Reflection;

namespace BeeneticToolkit.Logging.Loggers {

    /// <summary>
    /// A logger that writes log messages to the debug output.
    /// </summary>
    public class DebugLogger : LoggerBase {

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugLogger"/> class.
        /// </summary>
        /// <param name="loggerName">Optional name for the logger.</param>
        /// <param name="threshold">The threshold level for logging messages. Defaults to LogThreshold.All.</param>
        public DebugLogger(string? loggerName = null, LogThreshold threshold = LogThreshold.All) : base(loggerName, threshold) {
        }

        #endregion Initialization

        #region Logging

        /// <summary>
        /// Logs a message with the specified severity to the debug output.
        /// </summary>
        /// <param name="severity">The severity level of the log message.</param>
        /// <param name="message">The message to be logged.</param>
        /// <param name="prepend">String value to prepend to the message string.</param>
        /// <param name="append">String value to append to the message string.</param>
        /// <remarks>
        /// This method will log the message only if the logger is enabled and the message severity meets or exceeds the logger's threshold level.
        /// </remarks>

        public override void Log(LogSeverity severity, string message, string prepend = " ", string append = "\n") {
            if (!AllowLogMessage(severity))
                return;

            Debug.WriteLine($"{BaseMessage(severity)}{prepend}{message}{append}");
        }

        /// <summary>
        /// Logs a message with additional context from an object and a method, and with the specified severity to the debug output.
        /// </summary>
        /// <param name="severity">The severity level of the log message.</param>
        /// <param name="obj">The object context of the log message.</param>
        /// <param name="method">The method context of the log message.</param>
        /// <param name="message">The message to be logged.</param>
        /// <param name="prepend">String value to prepend to the message string.</param>
        /// <param name="append">String value to append to the message string.</param>
        /// <remarks>
        /// This method will log the message only if the logger is enabled and the message severity meets or exceeds the logger's threshold level.
        /// If either <paramref name="obj"/> or <paramref name="method"/> is null, 'UnknownObject' or 'UnknownMethod' will be used respectively.
        /// </remarks>

        public override void Log(LogSeverity severity, object? obj, MethodBase? method, string message, string prepend = " ", string append = "\n") {
            if (!AllowLogMessage(severity))
                return;

            Debug.WriteLine($"{BaseMessage(severity, obj, method)}{prepend}{message}{append}");
        }

        #endregion Logging
    }
}