using System.Reflection;

namespace BeeneticToolkit.Logging.Tests {

    public class MockLoggerBase : LoggerBase {
        public string LastLoggedMessage { get; private set; }

        public MockLoggerBase(string loggerName = null, LogThreshold threshold = LogThreshold.All) : base() {
            Name = loggerName;
            Threshold = threshold;
        }

        public override void Log(LogSeverity severity, string message, string prepend = " ", string append = "\n") {
            if (!AllowLogMessage(severity))
                return;

            LastLoggedMessage = $"{BaseMessage(severity)}: {message}";
        }

        public override void Log(LogSeverity severity, object obj, MethodBase method, string message, string prepend = " ", string append = "\n") {
            if (!AllowLogMessage(severity))
                return;

            LastLoggedMessage = $"{BaseMessage(severity, obj, method)}: {message}";
        }

        // Public wrapper methods for testing protected members
        public bool AllowLogMessagePublic(LogSeverity severity) => AllowLogMessage(severity);

        public string BaseMessagePublic(LogSeverity level) => BaseMessage(level);
    }
}