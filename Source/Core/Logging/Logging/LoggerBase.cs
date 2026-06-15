using BeeneticToolkit.Logging.Enums;
using System;
using System.Reflection;

namespace BeeneticToolkit.Logging {

    /// <summary>
    /// Provides a base implementation for loggers with common functionalities.
    /// </summary>
    public abstract class LoggerBase : IBeeneticLogger {

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
        public LogThreshold Threshold { get; set; }

        /// <summary>
        /// Struct that contains flags for the individual components of <see cref="BaseMessage(LogSeverity, object, MethodBase)"/>
        /// </summary>
        public BaseMessageIncludes Includes { get; set; }

        #endregion Properties

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerBase"/> class.
        /// </summary>
        public LoggerBase(string? name = null, LogThreshold threshold = LogThreshold.All) {
            Id = Guid.NewGuid().ToString();
            Name = name ?? string.Empty;
            Threshold = threshold;
            Includes = new BaseMessageIncludes(
                timestamp: true,
                logSeverity: true,
                typeName: true,
                objectName: true,
                methodName: true
            );
        }

        #endregion Initialization

        #region Logging

        /// <summary>
        /// Writes a fully-formatted, already-filtered log entry to this logger's destination. This is the single
        /// method a concrete logger must implement; all formatting and threshold filtering is handled by the base.
        /// </summary>
        /// <param name="severity">The severity of the entry, so sinks can route by level (e.g. error vs. info).</param>
        /// <param name="entry">The complete, formatted log line (including any prepend/append).</param>
        protected abstract void WriteEntry(LogSeverity severity, string entry);

        /// <summary>
        /// Logs a message with the specified severity.
        /// </summary>
        /// <param name="severity">The severity level of the log message.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="prepend">String value to prepend to the message string.</param>
        /// <param name="append">String value to append to the message string.</param>
        public void Log(LogSeverity severity, string message, string prepend = " ", string append = "\n") {
            if (!AllowLogMessage(severity))
                return;

            WriteEntry(severity, $"{BaseMessage(severity)}{prepend}{message}{append}");
        }

        /// <summary>
        /// Logs a message with additional context and the specified severity.
        /// </summary>
        /// <param name="severity">The severity level of the log message.</param>
        /// <param name="obj">The object context for the log message.</param>
        /// <param name="method">The method context for the log message.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="prepend">String value to prepend to the message string.</param>
        /// <param name="append">String value to append to the message string.</param>
        public void Log(LogSeverity severity, object? obj, MethodBase? method, string message, string prepend = " ", string append = "\n") {
            if (!AllowLogMessage(severity))
                return;

            WriteEntry(severity, $"{BaseMessage(severity, obj, method)}{prepend}{message}{append}");
        }

        /// <summary>
        /// Logs a message with additional context from an object and a method name, using the specified severity.
        /// </summary>
        /// <param name="severity">The severity level of the log message.</param>
        /// <param name="obj">The object context for the log message.</param>
        /// <param name="methodName">The name of the method associated with the log message.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="prepend">String value to prepend to the message string.</param>
        /// <param name="append">String value to append to the message string.</param>
        public void Log(LogSeverity severity, object? obj, string? methodName, string message, string prepend = " ", string append = "\n") {
            if (!AllowLogMessage(severity))
                return;

            WriteEntry(severity, $"{BaseMessage(severity, obj, methodName)}{prepend}{message}{append}");
        }

        /// <summary>
        /// Generates a base message string including the current time, log level, and optionally the object and method context.
        /// </summary>
        /// <param name="severity">The severity level of the log message.</param>
        /// <param name="obj">The object context for the log message, optional. If null, 'UnknownObject' is used.</param>
        /// <param name="method">The method context for the log message, optional. If null, 'UnknownMethod' is used.</param>
        /// <returns>The formatted base message string.</returns>
        /// <remarks>
        /// The method context information will be included only if both <paramref name="obj"/>
        /// and <paramref name="method"/> are provided.
        /// </remarks>
        protected string BaseMessage(LogSeverity severity, object? obj = null, MethodBase? method = null) {
            var timeComponent = Includes.Timestamp ? $"[{DateTime.Now.ToString(TimestampFormat)}]" : string.Empty;
            var severityComponent = Includes.LogSeverity ? $"[{severity}]" : string.Empty;

            var typeComponent = Includes.TypeName ? obj?.GetType().Name ?? "UnknownObjectType" : string.Empty;
            var objectComponent = Includes.ObjectName ? obj?.ToString() ?? "UnknownObject" : string.Empty;
            var methodComponent = Includes.MethodName ? method?.Name ?? "UnknownMethod" : string.Empty;
            var contextComponent = string.Empty;

            if (obj != null) {
                if (Includes.TypeName) {
                    contextComponent += $"[{typeComponent}]";
                }
                if (Includes.ObjectName) {
                    if (!contextComponent.Equals(string.Empty)) {
                        contextComponent += ".";
                    }
                    contextComponent += $"[{objectComponent}]";
                }
            }

            if (method != null && Includes.MethodName) {
                if (!contextComponent.Equals(string.Empty)) {
                    contextComponent += ".";
                }
                contextComponent += $"[{methodComponent}]";
            }

            string message = string.Empty;
            if (timeComponent != string.Empty)
                message += timeComponent;

            if (severityComponent != string.Empty)
                message += $" {severityComponent}";

            if (contextComponent != string.Empty)
                message += $" {contextComponent}";

            return message.Trim();
        }

        /// <summary>
        /// Generates a base message string including the current time, log level, and optionally the object and method-name context.
        /// </summary>
        /// <param name="severity">The severity level of the log message.</param>
        /// <param name="obj">The object context for the log message, optional. If null, object-related context is omitted.</param>
        /// <param name="methodName">The name of the method context for the log message, optional. If null, method-related context is omitted.</param>
        /// <returns>The formatted base message string.</returns>
        /// <remarks>
        /// This overload is intended for scenarios where only a method name string is available rather than a <see cref="MethodBase"/> instance.
        /// Included components are controlled by <see cref="Includes"/>.
        /// </remarks>
        protected string BaseMessage(LogSeverity severity, object? obj, string? methodName = "") {
            var timeComponent = Includes.Timestamp ? $"[{DateTime.Now.ToString(TimestampFormat)}]" : string.Empty;
            var severityComponent = Includes.LogSeverity ? $"[{severity}]" : string.Empty;

            var typeComponent = Includes.TypeName ? obj?.GetType().Name ?? "UnknownObjectType" : string.Empty;
            var objectComponent = Includes.ObjectName ? obj?.ToString() ?? "UnknownObject" : string.Empty;
            var methodComponent = Includes.MethodName ? methodName ?? "UnknownMethod" : string.Empty;
            var contextComponent = string.Empty;

            if (obj != null) {
                if (Includes.TypeName)
                    contextComponent += $"[{typeComponent}]";
                if (Includes.ObjectName) {
                    if (!contextComponent.Equals(string.Empty))
                        contextComponent += ".";
                    contextComponent += $"[{objectComponent}]";
                }
            }

            if (methodName != null && Includes.MethodName) {
                if (!contextComponent.Equals(string.Empty))
                    contextComponent += ".";
                contextComponent += $"[{methodComponent}]";
            }

            string message = string.Empty;
            if (timeComponent != string.Empty)
                message += timeComponent;
            if (severityComponent != string.Empty)
                message += $" {severityComponent}";
            if (contextComponent != string.Empty)
                message += $" {contextComponent}";

            return message.Trim();
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

    /// <summary>
    /// Represents a configuration of flags that specify which components are included in a log entry.
    /// </summary>
    public struct BaseMessageIncludes {

        /// <summary>
        /// Gets a value indicating whether the timestamp is included in the log entry.
        /// </summary>
        public bool Timestamp { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the log severity is included in the log entry.
        /// </summary>
        public bool LogSeverity { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the type name is included in the log entry.
        /// </summary>
        public bool TypeName { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the object name is included in the log entry.
        /// </summary>
        public bool ObjectName { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the method name is included in the log entry.
        /// </summary>
        public bool MethodName { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMessageIncludes"/> struct with the specified component inclusion settings.
        /// </summary>
        /// <param name="timestamp">Specifies whether the timestamp is included. The default value is <c>true</c>.</param>
        /// <param name="logSeverity">Specifies whether the log severity is included. The default value is <c>true</c>.</param>
        /// <param name="typeName">Specifies whether the type name is included. The default value is <c>true</c>.</param>
        /// <param name="objectName">Specifies whether the object name is included. The default value is <c>true</c>.</param>
        /// <param name="methodName">Specifies whether the method name is included. The default value is <c>true</c>.</param>
        public BaseMessageIncludes(bool timestamp = true, bool logSeverity = true, bool typeName = true, bool objectName = true, bool methodName = true) {
            Timestamp = timestamp;
            LogSeverity = logSeverity;
            TypeName = typeName;
            ObjectName = objectName;
            MethodName = methodName;
        }
    }
}