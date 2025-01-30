using BeeneticToolkit.Logging.Enums;
using System.IO;
using System.Reflection;

namespace BeeneticToolkit.Logging.Loggers {
    /// <summary>
    /// A logger that writes log messages to a file.
    /// </summary>

    public class FileLogger : LoggerBase {

        #region Fields

        private readonly string _fileName;

        #endregion Fields

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLogger"/> class.
        /// </summary>
        /// <param name="fileName">The file name where logs will be written.</param>
        /// <param name="loggerName">Optional name for the logger.</param>
        /// <param name="threshold">The threshold level for logging messages. Defaults to LogThreshold.All.</param>
        public FileLogger(string fileName, string? loggerName = null, LogThreshold threshold = LogThreshold.All) : base(loggerName, threshold) {
            _fileName = fileName;
        }

        #endregion Initialization

        #region Logging

        /// <summary>
        /// Logs a message with the specified severity to the file.
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

            File.AppendAllText(_fileName, $"{BaseMessage(severity)}{prepend}{message}{append}");
        }

        /// <summary>
        /// Logs a message with additional context from an object and a method, and with the specified severity to the file.
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

            File.AppendAllText(_fileName, $"{BaseMessage(severity, obj, method)}{prepend}{message}{append}");
        }

        #endregion Logging
    }
}