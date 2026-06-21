using BeeneticToolkit.Logging.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace BeeneticToolkit.Logging {

    /// <summary>
    /// Manages logging operations by maintaining a collection of loggers and delegating log messages to them.
    /// </summary>
    public class LogManager {

        #region Fields

        private readonly List<LoggerBase> _loggers = new List<LoggerBase>();
        private readonly object _sync = new object();

        #endregion Fields

        #region Initialization

        /// <summary>
        /// Adds a logger to the LogManager and enables fluent configuration.
        /// </summary>
        /// <param name="logger">The logger to be added. Must not be null.</param>
        /// <returns>The <see cref="LogManager"/> instance to allow for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the provided logger is null.</exception>
        /// <exception cref="ArgumentException">Thrown when a logger with the same name already exists.</exception>

        public LogManager AddLogger(LoggerBase logger) {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            lock (_sync) {
                if (!string.IsNullOrEmpty(logger.Name) && _loggers.Any(l => l.Name == logger.Name))
                    throw new ArgumentException($"A logger with the name '{logger.Name}' already exists.");

                _loggers.Add(logger);
            }

            return this;
        }

        /// <summary>
        /// Returns a point-in-time snapshot of the registered loggers, safe to enumerate without locking.
        /// </summary>
        private LoggerBase[] Snapshot() {
            lock (_sync)
                return _loggers.ToArray();
        }

        #endregion Initialization

        #region Logging

        /// <summary>
        /// Logs a message with the specified severity.
        /// </summary>
        /// <param name="severity">The severity of the log message.</param>
        /// <param name="message">The message to be logged.</param>
        public void LogMessage(LogSeverity severity, string message) {
            foreach (LoggerBase logger in Snapshot())
                logger.Log(severity, message);
        }

        /// <summary>
        /// Logs a message with additional context from an object and a method, using the specified severity.
        /// </summary>
        /// <param name="severity">The severity of the log message.</param>
        /// <param name="obj">The object context of the log message.</param>
        /// <param name="method">The method context of the log message.</param>
        /// <param name="message">The message to be logged.</param>
        public void LogMessage(LogSeverity severity, object? obj, MethodBase? method, string message) {
            foreach (LoggerBase logger in Snapshot())
                logger.Log(severity, obj, method, message);
        }

        /// <summary>
        /// Logs a message with additional context from an object and a method name, using the specified severity.
        /// </summary>
        /// <param name="severity">The severity of the log message.</param>
        /// <param name="obj">The object context of the log message.</param>
        /// <param name="methodName">The name of the method associated with the log message.</param>
        /// <param name="message">The message to be logged.</param>
        public void LogMessage(LogSeverity severity, object? obj, string methodName, string message) {
            foreach (LoggerBase logger in Snapshot())
                logger.Log(severity, obj, methodName, message);
        }

        #endregion Logging

        #region Convenience

        /// <summary>Logs a <see cref="LogSeverity.Trace"/> message, capturing the calling member automatically.</summary>
        /// <param name="message">The message to log.</param>
        /// <param name="context">Optional object context (typically <c>this</c>).</param>
        /// <param name="member">The calling member; supplied automatically by the compiler.</param>
        public void Trace(string message, object? context = null, [CallerMemberName] string member = "") =>
            LogMessage(LogSeverity.Trace, context, member, message);

        /// <summary>Logs an <see cref="LogSeverity.Info"/> message, capturing the calling member automatically.</summary>
        /// <param name="message">The message to log.</param>
        /// <param name="context">Optional object context (typically <c>this</c>).</param>
        /// <param name="member">The calling member; supplied automatically by the compiler.</param>
        public void Info(string message, object? context = null, [CallerMemberName] string member = "") =>
            LogMessage(LogSeverity.Info, context, member, message);

        /// <summary>Logs a <see cref="LogSeverity.Debug"/> message, capturing the calling member automatically.</summary>
        /// <param name="message">The message to log.</param>
        /// <param name="context">Optional object context (typically <c>this</c>).</param>
        /// <param name="member">The calling member; supplied automatically by the compiler.</param>
        public void Debug(string message, object? context = null, [CallerMemberName] string member = "") =>
            LogMessage(LogSeverity.Debug, context, member, message);

        /// <summary>Logs a <see cref="LogSeverity.Warn"/> message, capturing the calling member automatically.</summary>
        /// <param name="message">The message to log.</param>
        /// <param name="context">Optional object context (typically <c>this</c>).</param>
        /// <param name="member">The calling member; supplied automatically by the compiler.</param>
        public void Warn(string message, object? context = null, [CallerMemberName] string member = "") =>
            LogMessage(LogSeverity.Warn, context, member, message);

        /// <summary>Logs an <see cref="LogSeverity.Error"/> message, capturing the calling member automatically.</summary>
        /// <param name="message">The message to log.</param>
        /// <param name="context">Optional object context (typically <c>this</c>).</param>
        /// <param name="member">The calling member; supplied automatically by the compiler.</param>
        public void Error(string message, object? context = null, [CallerMemberName] string member = "") =>
            LogMessage(LogSeverity.Error, context, member, message);

        /// <summary>Logs a <see cref="LogSeverity.Fatal"/> message, capturing the calling member automatically.</summary>
        /// <param name="message">The message to log.</param>
        /// <param name="context">Optional object context (typically <c>this</c>).</param>
        /// <param name="member">The calling member; supplied automatically by the compiler.</param>
        public void Fatal(string message, object? context = null, [CallerMemberName] string member = "") =>
            LogMessage(LogSeverity.Fatal, context, member, message);

        #endregion Convenience

        #region Deferred

        /// <summary>
        /// Determines whether any registered logger would currently emit a message of the given severity. Use to
        /// guard expensive message construction before calling one of the <c>Log*</c> methods.
        /// </summary>
        /// <param name="severity">The severity to test.</param>
        /// <returns><c>true</c> if at least one logger would log this severity; otherwise <c>false</c>.</returns>
        public bool IsEnabled(LogSeverity severity) {
            foreach (LoggerBase logger in Snapshot())
                if (logger.IsEnabled(severity))
                    return true;
            return false;
        }

        /// <summary>Logs a <see cref="LogSeverity.Trace"/> message, building it only if a logger will emit it.</summary>
        public void Trace(Func<string> messageFactory, object? context = null, [CallerMemberName] string member = "") =>
            LogDeferred(LogSeverity.Trace, messageFactory, context, member);

        /// <summary>Logs an <see cref="LogSeverity.Info"/> message, building it only if a logger will emit it.</summary>
        public void Info(Func<string> messageFactory, object? context = null, [CallerMemberName] string member = "") =>
            LogDeferred(LogSeverity.Info, messageFactory, context, member);

        /// <summary>Logs a <see cref="LogSeverity.Debug"/> message, building it only if a logger will emit it.</summary>
        public void Debug(Func<string> messageFactory, object? context = null, [CallerMemberName] string member = "") =>
            LogDeferred(LogSeverity.Debug, messageFactory, context, member);

        /// <summary>Logs a <see cref="LogSeverity.Warn"/> message, building it only if a logger will emit it.</summary>
        public void Warn(Func<string> messageFactory, object? context = null, [CallerMemberName] string member = "") =>
            LogDeferred(LogSeverity.Warn, messageFactory, context, member);

        /// <summary>Logs an <see cref="LogSeverity.Error"/> message, building it only if a logger will emit it.</summary>
        public void Error(Func<string> messageFactory, object? context = null, [CallerMemberName] string member = "") =>
            LogDeferred(LogSeverity.Error, messageFactory, context, member);

        /// <summary>Logs a <see cref="LogSeverity.Fatal"/> message, building it only if a logger will emit it.</summary>
        public void Fatal(Func<string> messageFactory, object? context = null, [CallerMemberName] string member = "") =>
            LogDeferred(LogSeverity.Fatal, messageFactory, context, member);

        private void LogDeferred(LogSeverity severity, Func<string> messageFactory, object? context, string member) {
            if (messageFactory == null)
                throw new ArgumentNullException(nameof(messageFactory));
            if (!IsEnabled(severity))
                return;

            LogMessage(severity, context, member, messageFactory());
        }

        #endregion Deferred

        #region Helpers

        /// <summary>
        /// Gets a specified logger.
        /// </summary>
        /// <param name="identifier">The identifier (ID or Name) of the logger to be enabled.</param>
        /// <returns>LoggerBase with the specified identifier; otherwise, null.</returns>
        public LoggerBase? GetLogger(string identifier) {
            return FindLoggerByIdentifier(identifier);
        }

        /// <summary>
        /// Enables a logger with the specified identifier.
        /// </summary>
        /// <param name="identifier">The identifier (ID or Name) of the logger to be enabled.</param>
        /// <returns>True if the logger is found and enabled; otherwise, false.</returns>
        public bool EnableLogger(string identifier) {
            var logger = FindLoggerByIdentifier(identifier);
            if (logger != null) {
                logger.Enabled = true;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Disables a logger with the specified identifier.
        /// </summary>
        /// <param name="identifier">The identifier (ID or Name) of the logger to be disabled.</param>
        /// <returns>True if the logger is found and disabled; otherwise, false.</returns>
        public bool DisableLogger(string identifier) {
            var logger = FindLoggerByIdentifier(identifier);
            if (logger != null) {
                logger.Enabled = false;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Finds a logger by its identifier (ID or Name).
        /// </summary>
        /// <param name="identifier">The identifier (ID or Name) of the logger.</param>
        /// <returns>The found logger, or null if no logger matches the identifier.</returns>
        private LoggerBase? FindLoggerByIdentifier(string identifier) {
            lock (_sync)
                return _loggers.FirstOrDefault(l => l.Id == identifier || l.Name == identifier);
        }

        #endregion Helpers
    }
}