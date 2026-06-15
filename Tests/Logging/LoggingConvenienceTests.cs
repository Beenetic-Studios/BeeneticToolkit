using BeeneticToolkit.Logging;
using BeeneticToolkit.Logging.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeeneticToolkit.Tests.Logging {

    // LoggerService is process-wide static state; keep these tests off the parallel runner so they don't
    // race each other on LoggerService.Instance. (The LogManager/LoggerBase tests use no global state and
    // parallelize freely — that is the point of keeping LogManager the testable primitive.)
    [TestClass]
    [DoNotParallelize]
    public class LoggingConvenienceTests {

        // --- LogManager convenience methods ---

        [TestMethod]
        public void LogManager_SeverityMethods_RouteToCorrectSeverity() {
            var logger = new MockLoggerBase();
            var manager = new LogManager().AddLogger(logger);

            manager.Trace("a"); Assert.AreEqual(LogSeverity.Trace, logger.LastSeverity);
            manager.Info("a"); Assert.AreEqual(LogSeverity.Info, logger.LastSeverity);
            manager.Debug("a"); Assert.AreEqual(LogSeverity.Debug, logger.LastSeverity);
            manager.Warn("a"); Assert.AreEqual(LogSeverity.Warn, logger.LastSeverity);
            manager.Error("a"); Assert.AreEqual(LogSeverity.Error, logger.LastSeverity);
            manager.Fatal("a"); Assert.AreEqual(LogSeverity.Fatal, logger.LastSeverity);
        }

        [TestMethod]
        public void LogManager_Convenience_CapturesCallingMember() {
            var logger = new MockLoggerBase();
            var manager = new LogManager().AddLogger(logger);

            manager.Info("hello");

            // [CallerMemberName] should bake in this test method's name with no MethodBase/reflection.
            StringAssert.Contains(logger.LastLoggedMessage, nameof(LogManager_Convenience_CapturesCallingMember));
            StringAssert.Contains(logger.LastLoggedMessage, "hello");
            StringAssert.Contains(logger.LastLoggedMessage, "[Info]");
        }

        [TestMethod]
        public void LogManager_Convenience_IncludesObjectContext() {
            var logger = new MockLoggerBase();
            var manager = new LogManager().AddLogger(logger);
            var context = new Ctx();

            manager.Warn("oops", context);

            StringAssert.Contains(logger.LastLoggedMessage, "[Ctx]");
            StringAssert.Contains(logger.LastLoggedMessage, "[CtxInstance]");
            StringAssert.Contains(logger.LastLoggedMessage, "[Warn]");
        }

        // --- LoggerService static facade ---

        [TestMethod]
        public void LoggerService_BeforeInitialize_IsNoOpAndDoesNotThrow() {
            LoggerService.Initialize(null);
            LoggerService.Info("no manager set");   // must not throw
            Assert.IsNull(LoggerService.Instance);
        }

        [TestMethod]
        public void LoggerService_RoutesThroughManager_AndCapturesMember() {
            var logger = new MockLoggerBase();
            var manager = new LogManager().AddLogger(logger);
            LoggerService.Initialize(manager);

            try {
                LoggerService.Error("boom");

                Assert.AreEqual(LogSeverity.Error, logger.LastSeverity);
                StringAssert.Contains(logger.LastLoggedMessage, "boom");
                // The captured member must be THIS method, not the facade's own "Error" method — proving the
                // facade forwards its caller-name rather than re-capturing at its own call to the manager.
                StringAssert.Contains(logger.LastLoggedMessage, nameof(LoggerService_RoutesThroughManager_AndCapturesMember));
            } finally {
                LoggerService.Initialize(null);
            }
        }

        // --- LoggerExtensions (single logger) ---

        [TestMethod]
        public void LoggerExtensions_LogDirectlyToLogger_CaptureMemberAndSeverity() {
            var logger = new MockLoggerBase();

            logger.Debug("direct");

            Assert.AreEqual(LogSeverity.Debug, logger.LastSeverity);
            StringAssert.Contains(logger.LastLoggedMessage, "direct");
            StringAssert.Contains(logger.LastLoggedMessage, nameof(LoggerExtensions_LogDirectlyToLogger_CaptureMemberAndSeverity));
        }

        [TestMethod]
        public void LoggerExtensions_NullLogger_Throws() {
            MockLoggerBase logger = null;
            Assert.ThrowsException<ArgumentNullException>(() => logger.Info("x"));
        }

        // --- Threshold still honored through the convenience path ---

        [TestMethod]
        public void Convenience_RespectsThreshold() {
            var logger = new MockLoggerBase(threshold: LogThreshold.Error);
            var manager = new LogManager().AddLogger(logger);

            manager.Info("filtered out");
            Assert.IsNull(logger.LastLoggedMessage);
            Assert.AreEqual(0, logger.WriteCount);

            manager.Error("gets through");
            Assert.AreEqual(1, logger.WriteCount);
        }

        private sealed class Ctx {
            public override string ToString() => "CtxInstance";
        }
    }
}
