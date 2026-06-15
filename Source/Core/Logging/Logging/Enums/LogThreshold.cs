namespace BeeneticToolkit.Logging.Enums {

    /// <summary>
    /// Defines the threshold levels for logging: a message is emitted when its <see cref="LogSeverity"/> is at or
    /// above the threshold. Values align with <see cref="LogSeverity"/> (plus <see cref="All"/> and
    /// <see cref="Off"/> at the ends).
    /// </summary>
    public enum LogThreshold {

        /// <summary>Everything is logged, including <see cref="LogSeverity.Trace"/>.</summary>
        All = 0,

        /// <summary>Debug and above: Debug, Info, Warn, Error, Fatal (excludes Trace).</summary>
        Debug = 1,

        /// <summary>Info and above: Info, Warn, Error, Fatal (excludes Trace and Debug).</summary>
        Info = 2,

        /// <summary>Warn and above: Warn, Error, Fatal.</summary>
        Warn = 3,

        /// <summary>Error and above: Error, Fatal.</summary>
        Error = 4,

        /// <summary>Only Fatal.</summary>
        Fatal = 5,

        /// <summary>Logging is disabled; nothing is recorded.</summary>
        Off = 6
    }
}
