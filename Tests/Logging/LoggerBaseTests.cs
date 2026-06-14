using BeeneticToolkit.Logging.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeeneticToolkit.Tests.Logging {

    [TestClass]
    public class LoggerBaseTests {

        [TestMethod]
        public void LoggerBase_AllowLogMessage_ThresholdCheck() {
            var loggerBase = new MockLoggerBase(threshold: LogThreshold.Warn);

            Assert.IsTrue(loggerBase.AllowLogMessagePublic(LogSeverity.Warn));
        }

        [TestMethod]
        public void LoggerBase_DisallowLogMessage_ThresholdCheck() {
            var loggerBase = new MockLoggerBase(threshold: LogThreshold.Warn);

            Assert.IsFalse(loggerBase.AllowLogMessagePublic(LogSeverity.Info));
        }

        [TestMethod]
        public void LoggerBase_WritesExpectedMessage() {
            var mockLogger = new MockLoggerBase();
            var testMessage = "Test message";
            mockLogger.Log(LogSeverity.Info, testMessage);

            StringAssert.Contains(mockLogger.LastLoggedMessage, testMessage);
            StringAssert.Contains(mockLogger.LastLoggedMessage, "[Info]");
        }

        [TestMethod]
        public void LoggerBase_DoesNotWriteMessageBelowThreshold() {
            var mockLogger = new MockLoggerBase(threshold: LogThreshold.Error);
            mockLogger.Log(LogSeverity.Debug, "Test message");

            Assert.IsNull(mockLogger.LastLoggedMessage);
        }

        [TestMethod]
        public void LoggerBase_BaseMessageFormatting_Check() {
            var loggerBase = new MockLoggerBase();
            var message = loggerBase.BaseMessagePublic(LogSeverity.Info);

            StringAssert.Contains(message, "[Info]");
        }

        [TestMethod]
        public void LoggerBase_BaseMessage_WithObjectAndMethodName_ContainsExpectedContext() {
            var loggerBase = new MockLoggerBase();
            var testObject = new TestLogContext();

            var message = loggerBase.BaseMessagePublic(LogSeverity.Info, testObject, "TestMethod");

            StringAssert.Contains(message, "[Info]");
            StringAssert.Contains(message, "[TestLogContext]");
            StringAssert.Contains(message, "[TestLogContextInstance]");
            StringAssert.Contains(message, "[TestMethod]");
        }

        [TestMethod]
        public void LoggerBase_Log_WithMethodName_WritesExpectedMessage() {
            var mockLogger = new MockLoggerBase();
            var testObject = new TestLogContext();
            var testMessage = "Test message";

            mockLogger.Log(LogSeverity.Info, testObject, "TestMethod", testMessage);

            Assert.IsNotNull(mockLogger.LastLoggedMessage);
            StringAssert.Contains(mockLogger.LastLoggedMessage, testMessage);
            StringAssert.Contains(mockLogger.LastLoggedMessage, "[Info]");
            StringAssert.Contains(mockLogger.LastLoggedMessage, "[TestLogContext]");
            StringAssert.Contains(mockLogger.LastLoggedMessage, "[TestLogContextInstance]");
            StringAssert.Contains(mockLogger.LastLoggedMessage, "[TestMethod]");
        }

        [TestMethod]
        public void LoggerBase_Log_WithMethodName_BelowThreshold_DoesNotWriteMessage() {
            var mockLogger = new MockLoggerBase(threshold: LogThreshold.Error);
            var testObject = new TestLogContext();

            mockLogger.Log(LogSeverity.Info, testObject, "TestMethod", "Test message");

            Assert.IsNull(mockLogger.LastLoggedMessage);
        }

        private sealed class TestLogContext {

            public override string ToString() => "TestLogContextInstance";
        }
    }
}