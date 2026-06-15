using BeeneticToolkit.Logging.Enums;
using System;
using System.Runtime.CompilerServices;

namespace BeeneticToolkit.Logging {

    /// <summary>
    /// Severity-named convenience methods on a single <see cref="LoggerBase"/>, capturing the calling member
    /// automatically. Use these when logging directly to one logger rather than through a <see cref="LogManager"/>.
    /// </summary>
    public static class LoggerExtensions {

        /// <summary>Logs a <see cref="LogSeverity.Trace"/> message, capturing the calling member automatically.</summary>
        public static void Trace(this LoggerBase logger, string message, object? context = null, [CallerMemberName] string member = "") =>
            Log(logger, LogSeverity.Trace, message, context, member);

        /// <summary>Logs an <see cref="LogSeverity.Info"/> message, capturing the calling member automatically.</summary>
        public static void Info(this LoggerBase logger, string message, object? context = null, [CallerMemberName] string member = "") =>
            Log(logger, LogSeverity.Info, message, context, member);

        /// <summary>Logs a <see cref="LogSeverity.Debug"/> message, capturing the calling member automatically.</summary>
        public static void Debug(this LoggerBase logger, string message, object? context = null, [CallerMemberName] string member = "") =>
            Log(logger, LogSeverity.Debug, message, context, member);

        /// <summary>Logs a <see cref="LogSeverity.Warn"/> message, capturing the calling member automatically.</summary>
        public static void Warn(this LoggerBase logger, string message, object? context = null, [CallerMemberName] string member = "") =>
            Log(logger, LogSeverity.Warn, message, context, member);

        /// <summary>Logs an <see cref="LogSeverity.Error"/> message, capturing the calling member automatically.</summary>
        public static void Error(this LoggerBase logger, string message, object? context = null, [CallerMemberName] string member = "") =>
            Log(logger, LogSeverity.Error, message, context, member);

        /// <summary>Logs a <see cref="LogSeverity.Fatal"/> message, capturing the calling member automatically.</summary>
        public static void Fatal(this LoggerBase logger, string message, object? context = null, [CallerMemberName] string member = "") =>
            Log(logger, LogSeverity.Fatal, message, context, member);

        private static void Log(LoggerBase logger, LogSeverity severity, string message, object? context, string member) {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            logger.Log(severity, context, member, message);
        }
    }
}
