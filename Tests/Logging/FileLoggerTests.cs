using BeeneticToolkit.Logging.Enums;
using BeeneticToolkit.Logging.Loggers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace BeeneticToolkit.Tests.Logging {

    // FileLogger keeps a process-wide writer open per path and CloseAll() acts on all of them, so keep these
    // off the parallel runner.
    [TestClass]
    [DoNotParallelize]
    public class FileLoggerTests {

        private static string TempPath() =>
            Path.Combine(Path.GetTempPath(), $"beenetic_log_{Guid.NewGuid():N}.log");

        // Reads a file that may still be held open by a logger's writer.
        private static string ReadSharing(string path) {
            using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var sr = new StreamReader(fs);
            return sr.ReadToEnd();
        }

        private static void Cleanup(string path) {
            FileLogger.CloseAll();
            try { if (File.Exists(path)) File.Delete(path); } catch { /* best effort */ }
        }

        [TestMethod]
        public void WritesEntriesToFile() {
            string path = TempPath();
            try {
                var logger = new FileLogger(path);
                logger.Log(LogSeverity.Info, "hello file");

                string contents = ReadSharing(path);          // AutoFlush is on by default
                StringAssert.Contains(contents, "hello file");
                StringAssert.Contains(contents, "[Info]");
            } finally {
                Cleanup(path);
            }
        }

        [TestMethod]
        public void Flush_PersistsBufferedEntries() {
            string path = TempPath();
            try {
                var logger = new FileLogger(path) { AutoFlush = false };
                logger.Log(LogSeverity.Info, "buffered line");

                logger.Flush();
                StringAssert.Contains(ReadSharing(path), "buffered line");
            } finally {
                Cleanup(path);
            }
        }

        [TestMethod]
        public void CloseAll_FlushesAndReleasesHandle() {
            string path = TempPath();
            try {
                var logger = new FileLogger(path);
                logger.Log(LogSeverity.Warn, "closing soon");

                FileLogger.CloseAll();

                // Handle released: a plain (exclusive-ish) read and a delete both succeed.
                string contents = File.ReadAllText(path);
                StringAssert.Contains(contents, "closing soon");
                File.Delete(path);
                Assert.IsFalse(File.Exists(path));
            } finally {
                Cleanup(path);
            }
        }

        [TestMethod]
        public void MultipleLoggers_SamePath_ShareOneWriter() {
            string path = TempPath();
            try {
                var a = new FileLogger(path, "a");
                var b = new FileLogger(path, "b");

                a.Log(LogSeverity.Info, "from-a");
                b.Log(LogSeverity.Info, "from-b");

                string contents = ReadSharing(path);
                StringAssert.Contains(contents, "from-a");
                StringAssert.Contains(contents, "from-b");
            } finally {
                Cleanup(path);
            }
        }

        [TestMethod]
        public void RespectsThreshold() {
            string path = TempPath();
            try {
                var logger = new FileLogger(path, threshold: LogThreshold.Error);

                logger.Log(LogSeverity.Info, "should-not-appear");
                logger.Log(LogSeverity.Error, "should-appear");
                logger.Flush();

                string contents = File.Exists(path) ? ReadSharing(path) : string.Empty;
                StringAssert.Contains(contents, "should-appear");
                Assert.IsFalse(contents.Contains("should-not-appear"));
            } finally {
                Cleanup(path);
            }
        }
    }
}
