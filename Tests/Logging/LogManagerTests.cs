using BeeneticToolkit.Logging;
using BeeneticToolkit.Logging.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeeneticToolkit.Tests.Logging {

    [TestClass]
    public class LogManagerTests {

        [TestMethod]
        public void AddLogger_NullLogger_ThrowsArgumentNullException() {
            var logManager = new LogManager();

            Assert.ThrowsException<ArgumentNullException>(() => logManager.AddLogger(null));
        }

        [TestMethod]
        public void LogManager_LogMessage_NoLoggers_NoExceptionThrown() {
            var logManager = new LogManager();

            try {
                logManager.LogMessage(LogSeverity.Info, "Test message");
            } catch (Exception ex) {
                Assert.Fail($"Logging with no loggers should not throw an exception, but threw {ex.GetType().Name}");
            }
        }

        [TestMethod]
        public void AddLogger_DuplicateName_ThrowsArgumentException() {
            var logManager = new LogManager();
            var logger1 = new MockLoggerBase("Logger1");
            var logger2 = new MockLoggerBase("Logger1");

            logManager.AddLogger(logger1);
            Assert.ThrowsException<ArgumentException>(() => logManager.AddLogger(logger2));
        }

        [TestMethod]
        public void GetLogger_ExistingLogger_ReturnsNotNullLoggerBase() {
            var logManager = new LogManager();
            var logger = new MockLoggerBase() { Name = "TestLogger" };
            logManager.AddLogger(logger);

            var result = logManager.GetLogger("TestLogger");

            Assert.IsNotNull(result);
            Assert.AreEqual(logger, result);
        }

        [TestMethod]
        public void GetLogger_NonExistingLogger_ReturnsNull() {
            var logManager = new LogManager();

            var result = logManager.GetLogger("TestLogger");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void EnableLogger_ExistingLogger_ReturnsTrue() {
            var logManager = new LogManager();
            var logger = new MockLoggerBase() { Name = "TestLogger" };
            logManager.AddLogger(logger);

            var result = logManager.EnableLogger("TestLogger");

            Assert.IsTrue(result);
            Assert.IsTrue(logger.Enabled);
        }

        [TestMethod]
        public void DisableLogger_NonExistingLogger_ReturnsFalse() {
            var logManager = new LogManager();
            var result = logManager.DisableLogger("NonExistingLogger");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LogManager_AddLogger_LoggerDelegation() {
            var logManager = new LogManager();
            var mockLoggerA = new MockLoggerBase("A");
            var mockLoggerB = new MockLoggerBase();

            var testInfoMessage = "Test info message";
            var testErrorMessage = "Test error message";

            logManager.AddLogger(mockLoggerA);
            logManager.LogMessage(LogSeverity.Info, testInfoMessage);

            StringAssert.Contains(mockLoggerA.LastLoggedMessage, testInfoMessage);
            StringAssert.Contains(mockLoggerA.LastLoggedMessage, "[Info]");
            Assert.IsNull(mockLoggerB.LastLoggedMessage);

            logManager.AddLogger(mockLoggerB);
            logManager.LogMessage(LogSeverity.Error, testErrorMessage);

            // Verify that the mock logger received the log message (may require additional logic in MockLoggerBase)
            StringAssert.Contains(mockLoggerA.LastLoggedMessage, testErrorMessage);
            StringAssert.Contains(mockLoggerA.LastLoggedMessage, "[Error]");

            StringAssert.Contains(mockLoggerB.LastLoggedMessage, testErrorMessage);
            StringAssert.Contains(mockLoggerB.LastLoggedMessage, "[Error]");
        }

        [TestMethod]
        public void LogManager_LogMessage_WithMethodName_DelegatesToAllLoggers() {
            var logManager = new LogManager();
            var mockLoggerA = new MockLoggerBase("A");
            var mockLoggerB = new MockLoggerBase("B");
            var testObject = new TestLogContext();
            var testMessage = "Delegated message";

            logManager.AddLogger(mockLoggerA);
            logManager.AddLogger(mockLoggerB);

            logManager.LogMessage(LogSeverity.Warn, testObject, "ManagerMethod", testMessage);

            Assert.IsNotNull(mockLoggerA.LastLoggedMessage);
            Assert.IsNotNull(mockLoggerB.LastLoggedMessage);

            StringAssert.Contains(mockLoggerA.LastLoggedMessage, testMessage);
            StringAssert.Contains(mockLoggerA.LastLoggedMessage, "[Warn]");
            StringAssert.Contains(mockLoggerA.LastLoggedMessage, "[ManagerMethod]");

            StringAssert.Contains(mockLoggerB.LastLoggedMessage, testMessage);
            StringAssert.Contains(mockLoggerB.LastLoggedMessage, "[Warn]");
            StringAssert.Contains(mockLoggerB.LastLoggedMessage, "[ManagerMethod]");
        }

        private sealed class TestLogContext {

            public override string ToString() => "TestLogContextInstance";
        }
    }
}