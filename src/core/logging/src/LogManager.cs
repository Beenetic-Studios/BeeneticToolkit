using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BeeneticToolkit.Logging {

    /// <summary>
    /// Manages logging operations by maintaining a collection of loggers and delegating log messages to them.
    /// </summary>
    public class LogManager {

        #region Fields

        private readonly List<LoggerBase> _loggers = new List<LoggerBase>();

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

            if (!string.IsNullOrEmpty(logger.Name) && _loggers.Any(l => l.Name == logger.Name))
                throw new ArgumentException($"A logger with the name '{logger.Name}' already exists.");

            _loggers.Add(logger);

            return this;
        }

        #endregion Initialization

        #region Logging

        /// <summary>
        /// Logs a message with the specified severity.
        /// </summary>
        /// <param name="severity">The severity of the log message.</param>
        /// <param name="message">The message to be logged.</param>
        public void LogMessage(LogSeverity severity, string message) {
            foreach (LoggerBase logger in _loggers) {
                logger.Log(severity, message);
            }
        }

        /// <summary>
        /// Logs a message with additional context from an object and a method, using the specified severity.
        /// </summary>
        /// <param name="severity">The severity of the log message.</param>
        /// <param name="obj">The object context of the log message.</param>
        /// <param name="method">The method context of the log message.</param>
        /// <param name="message">The message to be logged.</param>
        public void LogMessage(LogSeverity severity, object? obj, MethodBase? method, string message) {
            foreach (LoggerBase logger in _loggers) {
                logger.Log(severity, obj, method, message);
            }
        }

        #endregion Logging

        #region Helpers

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

        private LoggerBase FindLoggerByIdentifier(string identifier) {
            return _loggers.FirstOrDefault(l => l.Id == identifier || l.Name == identifier);
        }

        #endregion Helpers
    }
}