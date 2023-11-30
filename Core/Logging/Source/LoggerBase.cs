using System;
using System.Reflection;

namespace BeeneticToolkit.Logging {

    /// <summary>
    /// Provides a base implementation for loggers with common functionalities.
    /// </summary>
    public abstract class LoggerBase : ILogger {

        #region Properties

        /// <summary>
        /// Gets the unique identifier for the logger.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets or sets the name of the logger.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the logger is enabled.
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the timestamp format, which is used in <see cref="BaseMessage(LogSeverity, object, MethodBase)"/>.
        /// </summary>
        /// <remarks>Default value: "yyyy-MM-dd HH:mm:ss"</remarks>
        public string TimestampFormat { get; set; } = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// Gets or sets the logging threshold level.
        /// </summary>
        protected LogThreshold Threshold { get; set; }

        #endregion Properties

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerBase"/> class.
        /// </summary>
        public LoggerBase(string? name = null, LogThreshold threshold = LogThreshold.All) {
            Id = Guid.NewGuid().ToString();
            Name = name ?? "";
            Threshold = threshold;
        }

        #endregion Initialization

        #region Logging

        /// <summary>
        /// Logs a message with the specified severity.
        /// </summary>
        /// <param name="severity">The severity level of the log message.</param>
        /// <param name="message">The message to log.</param>
        public abstract void Log(LogSeverity severity, string message);

        /// <summary>
        /// Logs a message with additional context and the specified severity.
        /// </summary>
        /// <param name="severity">The severity level of the log message.</param>
        /// <param name="obj">The object context for the log message.</param>
        /// <param name="method">The method context for the log message.</param>
        /// <param name="message">The message to log.</param>
        public abstract void Log(LogSeverity severity, object? obj, MethodBase? method, string message);

        /// <summary>
        /// Generates a base message string including the current time, log level, and optionally the object and method context.
        /// </summary>
        /// <param name="level">The severity level of the log message.</param>
        /// <param name="obj">The object context for the log message, optional. If null, 'UnknownObject' is used.</param>
        /// <param name="method">The method context for the log message, optional. If null, 'UnknownMethod' is used.</param>
        /// <returns>The formatted base message string.</returns>
        /// <remarks>
        /// The method context information will be included only if both <paramref name="obj"/>
        /// and <paramref name="method"/> are provided.
        /// </remarks>
        protected string BaseMessage(LogSeverity level, object? obj = null, MethodBase? method = null) {
            var timeComponent = $"[{DateTime.Now.ToString(TimestampFormat)}]";
            var levelComponent = $"[{level}]";

            var objectComponent = obj?.GetType().Name ?? "UnknownObject";
            var methodComponent = method?.Name ?? "UnknownMethod";
            var contextComponent = (obj != null && method != null) ? $"[{objectComponent}].[{methodComponent}]" : "";

            return $"{timeComponent} {levelComponent} {contextComponent}".Trim();
        }

        /// <summary>
        /// Evaluates if a log message meets the required severity threshold and checks if the logger is currently enabled.
        /// </summary>
        /// <param name="severity">The severity of the message.</param>
        /// <returns>True if the message should be logged, false otherwise.</returns>
        protected bool AllowLogMessage(LogSeverity severity) {
            return Enabled && (int)severity >= (int)Threshold;
        }

        #endregion Logging
    }
}