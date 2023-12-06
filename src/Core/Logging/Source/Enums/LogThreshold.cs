namespace BeeneticToolkit.Logging {

    /// <summary>
    /// Defines the threshold levels for logging, determining which messages should be logged based on their severity.
    /// </summary>
    public enum LogThreshold {

        /// <summary>
        /// All logging levels are enabled. Every log message regardless of severity will be logged.
        /// </summary>
        All = 0,

        /// <summary>
        /// Informational and higher severity levels are enabled. This includes Info, Debug, Warn, Error, and Fatal.
        /// </summary>
        Info,

        /// <summary>
        /// Debug and higher severity levels are enabled. This includes Debug, Warn, Error, and Fatal.
        /// </summary>
        Debug,

        /// <summary>
        /// Warning and higher severity levels are enabled. This includes Warn, Error, and Fatal.
        /// </summary>
        Warn,

        /// <summary>
        /// Error and Fatal severity levels are enabled.
        /// </summary>
        Error,

        /// <summary>
        /// Only Fatal severity level is enabled.
        /// </summary>
        Fatal,

        /// <summary>
        /// Logging is disabled. No log messages will be recorded.
        /// </summary>
        Off
    }
}