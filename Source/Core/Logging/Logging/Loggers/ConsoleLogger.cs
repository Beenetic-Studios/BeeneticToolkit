using BeeneticToolkit.Logging.Enums;
using System;

namespace BeeneticToolkit.Logging.Loggers {

    /// <summary>
    /// A logger that writes log messages to the console.
    /// </summary>
    public class ConsoleLogger : LoggerBase {

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleLogger"/> class.
        /// </summary>
        /// <param name="loggerName">Optional name for the logger.</param>
        /// <param name="threshold">The threshold level for logging messages. Defaults to LogThreshold.All.</param>
        public ConsoleLogger(string? loggerName = null, LogThreshold threshold = LogThreshold.All) : base(loggerName, threshold) {
        }

        /// <inheritdoc/>
        protected override void WriteEntry(LogSeverity severity, string entry) => Console.WriteLine(entry);
    }
}
