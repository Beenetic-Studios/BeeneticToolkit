using BeeneticToolkit.Logging.Enums;
using System;
using System.Runtime.CompilerServices;

namespace BeeneticToolkit.Logging {

    /// <summary>
    /// A process-wide static entry point for logging, backed by a single <see cref="LogManager"/>. Call
    /// <see cref="Initialize"/> once at startup, then log from anywhere with <see cref="Info"/>, <see cref="Warn"/>,
    /// etc. All methods are null-safe: before initialization (or after <c>Initialize(null)</c>) they simply do
    /// nothing, so logging calls scattered through a codebase never need null checks.
    /// </summary>
    /// <remarks>
    /// This is a deliberate, opt-in convenience for the common "one global logger" setup. When you need explicit,
    /// non-global control (multiple independent managers, tests), use a <see cref="LogManager"/> directly.
    /// </remarks>
    public static class LoggerService {

        // Volatile so a manager published by Initialize on the startup thread is immediately visible to logging
        // calls on any other thread, without tearing.
        private static volatile LogManager? _instance;

        /// <summary>Gets the manager currently backing the service, or <c>null</c> if not initialized.</summary>
        public static LogManager? Instance => _instance;

        /// <summary>Sets (or clears, when <c>null</c>) the manager backing the static logging methods.</summary>
        /// <remarks>Typically called once at startup. Safe to call from any thread; the latest call wins.</remarks>
        /// <param name="logManager">The manager to route logging through, or <c>null</c> to disable logging.</param>
        public static void Initialize(LogManager? logManager) => _instance = logManager;

        /// <summary>Logs a <see cref="LogSeverity.Trace"/> message through the configured manager, if any.</summary>
        public static void Trace(string message, object? context = null, [CallerMemberName] string member = "") =>
            Instance?.LogMessage(LogSeverity.Trace, context, member, message);

        /// <summary>Logs an <see cref="LogSeverity.Info"/> message through the configured manager, if any.</summary>
        public static void Info(string message, object? context = null, [CallerMemberName] string member = "") =>
            Instance?.LogMessage(LogSeverity.Info, context, member, message);

        /// <summary>Logs a <see cref="LogSeverity.Debug"/> message through the configured manager, if any.</summary>
        public static void Debug(string message, object? context = null, [CallerMemberName] string member = "") =>
            Instance?.LogMessage(LogSeverity.Debug, context, member, message);

        /// <summary>Logs a <see cref="LogSeverity.Warn"/> message through the configured manager, if any.</summary>
        public static void Warn(string message, object? context = null, [CallerMemberName] string member = "") =>
            Instance?.LogMessage(LogSeverity.Warn, context, member, message);

        /// <summary>Logs an <see cref="LogSeverity.Error"/> message through the configured manager, if any.</summary>
        public static void Error(string message, object? context = null, [CallerMemberName] string member = "") =>
            Instance?.LogMessage(LogSeverity.Error, context, member, message);

        /// <summary>Logs a <see cref="LogSeverity.Fatal"/> message through the configured manager, if any.</summary>
        public static void Fatal(string message, object? context = null, [CallerMemberName] string member = "") =>
            Instance?.LogMessage(LogSeverity.Fatal, context, member, message);

        /// <summary>
        /// Determines whether the configured manager would currently emit a message of the given severity
        /// (always <c>false</c> when not initialized). Use to guard expensive message construction.
        /// </summary>
        public static bool IsEnabled(LogSeverity severity) => Instance?.IsEnabled(severity) ?? false;

        /// <summary>Logs a <see cref="LogSeverity.Trace"/> message, building it only if it will be emitted.</summary>
        public static void Trace(Func<string> messageFactory, object? context = null, [CallerMemberName] string member = "") =>
            LogDeferred(LogSeverity.Trace, messageFactory, context, member);

        /// <summary>Logs an <see cref="LogSeverity.Info"/> message, building it only if it will be emitted.</summary>
        public static void Info(Func<string> messageFactory, object? context = null, [CallerMemberName] string member = "") =>
            LogDeferred(LogSeverity.Info, messageFactory, context, member);

        /// <summary>Logs a <see cref="LogSeverity.Debug"/> message, building it only if it will be emitted.</summary>
        public static void Debug(Func<string> messageFactory, object? context = null, [CallerMemberName] string member = "") =>
            LogDeferred(LogSeverity.Debug, messageFactory, context, member);

        /// <summary>Logs a <see cref="LogSeverity.Warn"/> message, building it only if it will be emitted.</summary>
        public static void Warn(Func<string> messageFactory, object? context = null, [CallerMemberName] string member = "") =>
            LogDeferred(LogSeverity.Warn, messageFactory, context, member);

        /// <summary>Logs an <see cref="LogSeverity.Error"/> message, building it only if it will be emitted.</summary>
        public static void Error(Func<string> messageFactory, object? context = null, [CallerMemberName] string member = "") =>
            LogDeferred(LogSeverity.Error, messageFactory, context, member);

        /// <summary>Logs a <see cref="LogSeverity.Fatal"/> message, building it only if it will be emitted.</summary>
        public static void Fatal(Func<string> messageFactory, object? context = null, [CallerMemberName] string member = "") =>
            LogDeferred(LogSeverity.Fatal, messageFactory, context, member);

        private static void LogDeferred(LogSeverity severity, Func<string> messageFactory, object? context, string member) {
            if (messageFactory == null)
                throw new ArgumentNullException(nameof(messageFactory));

            LogManager? instance = Instance;
            if (instance == null || !instance.IsEnabled(severity))
                return;

            instance.LogMessage(severity, context, member, messageFactory());
        }
    }
}
