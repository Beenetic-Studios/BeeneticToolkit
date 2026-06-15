namespace BeeneticToolkit.Logging.Enums {

    /// <summary>
    /// Defines the severity levels for logging messages, in ascending order of importance. The numeric values
    /// align with <see cref="LogThreshold"/> so a message is emitted when its severity is at or above a logger's
    /// threshold.
    /// </summary>
    public enum LogSeverity {

        /// <summary>Most verbose: detailed, fine-grained tracing.</summary>
        Trace = 0,

        /// <summary>Debugging detail, used during development.</summary>
        Debug = 1,

        /// <summary>General informational messages.</summary>
        Info = 2,

        /// <summary>Potentially harmful situations worth attention.</summary>
        Warn = 3,

        /// <summary>Errors that might still allow the application to continue running.</summary>
        Error = 4,

        /// <summary>Very severe errors that will presumably lead the application to abort.</summary>
        Fatal = 5
    }
}
