using BeeneticToolkit.Logging.Enums;
using System.Collections.Concurrent;
using System.IO;

namespace BeeneticToolkit.Logging.Loggers {

    /// <summary>
    /// A logger that writes log messages to a file. Writes to the same file are serialized,
    /// so multiple <see cref="FileLogger"/> instances (and threads) can safely target one path.
    /// </summary>
    public class FileLogger : LoggerBase {

        // One lock object per target file, shared across all FileLogger instances, so concurrent
        // appends to the same file never collide (File.AppendAllText opens the file exclusively).
        private static readonly ConcurrentDictionary<string, object> s_fileLocks = new ConcurrentDictionary<string, object>();

        private readonly string _fileName;
        private readonly object _fileLock;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLogger"/> class.
        /// </summary>
        /// <param name="fileName">The file name where logs will be written.</param>
        /// <param name="loggerName">Optional name for the logger.</param>
        /// <param name="threshold">The threshold level for logging messages. Defaults to LogThreshold.All.</param>
        public FileLogger(string fileName, string? loggerName = null, LogThreshold threshold = LogThreshold.All) : base(loggerName, threshold) {
            _fileName = fileName;

            // Normalize so loggers created with equivalent paths share the same lock.
            string lockKey = Path.GetFullPath(fileName);
            _fileLock = s_fileLocks.GetOrAdd(lockKey, _ => new object());
        }

        /// <inheritdoc/>
        protected override void WriteEntry(LogSeverity severity, string entry) {
            lock (_fileLock)
                File.AppendAllText(_fileName, entry);
        }
    }
}
