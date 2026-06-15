using BeeneticToolkit.Logging.Enums;
using System.Diagnostics;

namespace BeeneticToolkit.Logging.Loggers {

    /// <summary>
    /// A logger that writes log messages to the debug output.
    /// </summary>
    public class DebugLogger : LoggerBase {

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugLogger"/> class.
        /// </summary>
        /// <param name="loggerName">Optional name for the logger.</param>
        /// <param name="threshold">The threshold level for logging messages. Defaults to LogThreshold.All.</param>
        public DebugLogger(string? loggerName = null, LogThreshold threshold = LogThreshold.All) : base(loggerName, threshold) {
        }

        /// <inheritdoc/>
        protected override void WriteEntry(LogSeverity severity, string entry) => Debug.WriteLine(entry);
    }
}
