using BeeneticToolkit.Logging;
using BeeneticToolkit.Logging.Enums;

namespace BeeneticToolkit.Tests.Logging {

    public class MockLoggerBase : LoggerBase {

        /// <summary>The most recent fully-formatted entry handed to the sink, or null if nothing was written.</summary>
        public string LastLoggedMessage { get; private set; }

        /// <summary>The severity of the most recent written entry.</summary>
        public LogSeverity LastSeverity { get; private set; }

        /// <summary>How many entries have been written (i.e. passed the threshold).</summary>
        public int WriteCount { get; private set; }

        public MockLoggerBase(string loggerName = null, LogThreshold threshold = LogThreshold.All) : base() {
            Name = loggerName;
            Threshold = threshold;
        }

        protected override void WriteEntry(LogSeverity severity, string entry) {
            LastSeverity = severity;
            LastLoggedMessage = entry;
            WriteCount++;
        }

        // Public wrappers for testing protected members.
        public bool AllowLogMessagePublic(LogSeverity severity) => AllowLogMessage(severity);

        public string BaseMessagePublic(LogSeverity level) => BaseMessage(level);

        public string BaseMessagePublic(LogSeverity level, object obj, string methodName) => BaseMessage(level, obj, methodName);
    }
}
