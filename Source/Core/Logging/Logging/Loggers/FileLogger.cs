using BeeneticToolkit.Logging.Enums;
using System.Collections.Concurrent;
using System.IO;

namespace BeeneticToolkit.Logging.Loggers {

    /// <summary>
    /// A logger that appends log entries to a file. A single writer is kept open per target path and shared
    /// across all <see cref="FileLogger"/> instances (and threads) pointing at it, so writes are serialized and
    /// there is no per-call open/close cost. Entries are flushed to disk immediately by default
    /// (<see cref="AutoFlush"/>); call <see cref="CloseAll"/> on shutdown to release the file handles.
    /// </summary>
    public class FileLogger : LoggerBase {

        // One shared, open writer per fully-qualified path. Keyed so loggers created with equivalent paths
        // coordinate through the same sink rather than each opening their own handle.
        private static readonly ConcurrentDictionary<string, FileSink> s_sinks = new ConcurrentDictionary<string, FileSink>();

        private readonly FileSink _sink;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLogger"/> class.
        /// </summary>
        /// <param name="fileName">The file path where logs will be appended. The containing directory must exist.</param>
        /// <param name="loggerName">Optional name for the logger.</param>
        /// <param name="threshold">The threshold level for logging messages. Defaults to LogThreshold.All.</param>
        public FileLogger(string fileName, string? loggerName = null, LogThreshold threshold = LogThreshold.All) : base(loggerName, threshold) {
            string key = Path.GetFullPath(fileName);
            _sink = s_sinks.GetOrAdd(key, k => new FileSink(k));
        }

        /// <summary>
        /// Gets or sets whether each entry is flushed to disk as it is written (default <c>true</c>). Set to
        /// <c>false</c> for higher throughput under heavy logging, calling <see cref="Flush"/> periodically.
        /// </summary>
        /// <remarks>This setting is shared by all loggers targeting the same file.</remarks>
        public bool AutoFlush {
            get => _sink.AutoFlush;
            set => _sink.AutoFlush = value;
        }

        /// <summary>Flushes any buffered entries for this logger's file to disk.</summary>
        public void Flush() => _sink.Flush();

        /// <summary>
        /// Flushes and closes every open file writer. Call once on application shutdown (e.g. Unity's
        /// <c>OnApplicationQuit</c>) to guarantee all entries are persisted and handles released. Writers reopen
        /// automatically if logging resumes afterward.
        /// </summary>
        public static void CloseAll() {
            foreach (var kvp in s_sinks)
                kvp.Value.Close();
        }

        /// <inheritdoc/>
        protected override void WriteEntry(LogSeverity severity, string entry) => _sink.Write(entry);

        /// <summary>Owns the open <see cref="StreamWriter"/> for one file path and serializes access to it.</summary>
        private sealed class FileSink {

            private readonly string _path;
            private readonly object _lock = new object();
            private StreamWriter? _writer;
            private bool _autoFlush = true;

            public FileSink(string path) => _path = path;

            public bool AutoFlush {
                get { lock (_lock) return _autoFlush; }
                set {
                    lock (_lock) {
                        _autoFlush = value;
                        if (_writer != null)
                            _writer.AutoFlush = value;
                    }
                }
            }

            public void Write(string entry) {
                lock (_lock) {
                    EnsureOpen();
                    _writer!.Write(entry);
                }
            }

            public void Flush() {
                lock (_lock)
                    _writer?.Flush();
            }

            public void Close() {
                lock (_lock) {
                    _writer?.Flush();
                    _writer?.Dispose();
                    _writer = null; // a later Write reopens, so the sink stays reusable after CloseAll
                }
            }

            // Opened lazily so constructing a logger does not create the file until something is actually logged.
            private void EnsureOpen() {
                if (_writer != null)
                    return;

                var stream = new FileStream(_path, FileMode.Append, FileAccess.Write, FileShare.Read);
                _writer = new StreamWriter(stream) { AutoFlush = _autoFlush };
            }
        }
    }
}
