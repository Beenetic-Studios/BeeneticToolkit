namespace BeeneticToolkit.Logging.Enums {

    /// <summary>
    /// Defines the severity levels for logging messages.
    /// </summary>
    public enum LogSeverity {

        /// <summary>
        /// Trace severity level, used for detailed and systematic logging.
        /// </summary>
        Trace,

        /// <summary>
        /// Informational severity level, used for general informational messages.
        /// </summary>
        Info,

        /// <summary>
        /// Debug severity level, used for debugging purposes during development.
        /// </summary>
        Debug,

        /// <summary>
        /// Warning severity level, used for potentially harmful situations.
        /// </summary>
        Warn,

        /// <summary>
        /// Error severity level, used for error events that might still allow the application to continue running.
        /// </summary>
        Error,

        /// <summary>
        /// Fatal severity level, used for very severe error events that will presumably lead the application to abort.
        /// </summary>
        Fatal
    }
}