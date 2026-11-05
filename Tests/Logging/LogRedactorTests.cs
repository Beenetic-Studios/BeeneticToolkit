using BeeneticToolkit.Logging;
using BeeneticToolkit.Logging.Enums;
using BeeneticToolkit.Logging.Redaction;
using BeeneticToolkit.Logging.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeeneticToolkit.Tests.Logging {

    [TestClass]
    public class LogRedactorTests {

        private const string ShareAlphabet = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";

        private static LogRedactor WithJsonKeys(params string[] keys) {
            LogRedactionOptions options = LogRedactionOptions.CreateDefault();
            foreach (string key in keys)
                options.JsonKeys.Add(key);
            return new LogRedactor(options);
        }

        private static LogRedactor WithShareCodes() {
            LogRedactionOptions options = LogRedactionOptions.CreateDefault();
            options.Codes.Add(new CodeRedactionRule("code", ShareAlphabet, 6));
            return new LogRedactor(options);
        }

        #region Defaults

        [DataTestMethod]
        [DataRow("profile 3F2504E0-4F89-11D3-9A0C-0305E82C3301 loaded", "profile <id> loaded", DisplayName = "guid upper")]
        [DataRow("profile 3f2504e0-4f89-11d3-9a0c-0305e82c3301", "profile <id>", DisplayName = "guid lower")]
        [DataRow("device d41d8cd98f00b204e9800998ecf8427e ok", "device <id> ok", DisplayName = "hex32")]
        [DataRow("player 123456789012345678 joined", "player <id> joined", DisplayName = "long digits")]
        public void Default_ScrubsIdShapes(string line, string expected) {
            Assert.AreEqual(expected, LogRedactor.Default.Redact(line));
        }

        [DataTestMethod]
        [DataRow("score 12345678901234 at tick 9001", DisplayName = "14 digits stays")]
        [DataRow("hash d41d8cd98f00b204e9800998ecf8427 short", DisplayName = "31 hex stays")]
        [DataRow("token d41d8cd98f00b204e9800998ecf8427e0 long", DisplayName = "33 hex stays")]
        [DataRow("ONLINE PLAYER code path", DisplayName = "words stay")]
        public void Default_LeavesNearMissesAlone(string line) {
            Assert.AreEqual(line, LogRedactor.Default.Redact(line));
        }

        [TestMethod]
        public void Default_NullAndEmptyComeBackAsIs() {
            Assert.IsNull(LogRedactor.Default.Redact(null));
            Assert.AreEqual(string.Empty, LogRedactor.Default.Redact(string.Empty));
        }

        [TestMethod]
        public void Default_HasNoJsonKeysOrCodes() {
            LogRedactionOptions options = LogRedactionOptions.CreateDefault();
            Assert.AreEqual(0, options.JsonKeys.Count);
            Assert.AreEqual(0, options.Codes.Count);
            Assert.AreEqual(3, options.IdPatterns.Count);
        }

        #endregion Defaults

        #region Json

        [TestMethod]
        public void Json_BlanksConfiguredKeysCaseInsensitively() {
            string line = "reply {\"PlayerName\" : \"Ana 2024\",\"score\":\"12\",\"email\":\"a@b.c\"}";
            string result = WithJsonKeys("playerName", "email").Redact(line);
            Assert.AreEqual("reply {\"PlayerName\":\"<redacted>\",\"score\":\"12\",\"email\":\"<redacted>\"}", result);
        }

        [TestMethod]
        public void Json_HonorsEscapedQuotesInsideTheValue() {
            string line = "{\"name\":\"a \\\"b\\\" 123456789012345678\",\"next\":1}";
            Assert.AreEqual("{\"name\":\"<redacted>\",\"next\":1}", WithJsonKeys("name").Redact(line));
        }

        [TestMethod]
        public void Json_RunsBeforeIdPatternsSoTheValueGoesWhole() {
            string line = "{\"status\":\"call me 123456789012345678\"}";
            Assert.AreEqual("{\"status\":\"<redacted>\"}", WithJsonKeys("status").Redact(line));
        }

        [TestMethod]
        public void Json_KeyWithRegexCharactersIsLiteral() {
            string line = "{\"a.b\":\"secret\",\"axb\":\"kept\"}";
            Assert.AreEqual("{\"a.b\":\"<redacted>\",\"axb\":\"kept\"}", WithJsonKeys("a.b").Redact(line));
        }

        [TestMethod]
        public void Placeholders_AreConfigurableAndTakenLiterally() {
            LogRedactionOptions options = LogRedactionOptions.CreateDefault();
            options.JsonKeys.Add("name");
            options.IdPlaceholder = "$1#";
            options.ValuePlaceholder = "$0";
            LogRedactor redactor = new LogRedactor(options);
            Assert.AreEqual("{\"name\":\"$0\"} id $1#", redactor.Redact("{\"name\":\"Ana\"} id d41d8cd98f00b204e9800998ecf8427e"));
        }

        #endregion Json

        #region Patterns And Codes

        [TestMethod]
        public void IdPatterns_CustomPatternAppliesInOrder() {
            LogRedactionOptions options = LogRedactionOptions.CreateDefault();
            options.IdPatterns.Add(@"\bg\d{10,}\b");
            Assert.AreEqual("signed in as <id>", new LogRedactor(options).Redact("signed in as g1234567890"));
        }

        [TestMethod]
        public void IdPatterns_InvalidPatternThrowsAtConstruction() {
            LogRedactionOptions options = new LogRedactionOptions();
            options.IdPatterns.Add("(unclosed");
            try {
                new LogRedactor(options);
                Assert.Fail("an invalid pattern should fail when the redactor is built, not when it first redacts");
            } catch (ArgumentException) {
                // RegexParseException on newer runtimes, which derives from ArgumentException.
            }
        }

        [DataTestMethod]
        [DataRow("Share code ready: X7KQ2M", "Share code ready: <id>", DisplayName = "after trigger")]
        [DataRow("CODE stored: abc -> X7KQ2M", "CODE stored: abc -> <id>", DisplayName = "trigger any case")]
        [DataRow("player X7KQ2M is ONLINE", "player X7KQ2M is ONLINE", DisplayName = "no trigger, kept")]
        [DataRow("code: X7KQ1M", "code: X7KQ1M", DisplayName = "char outside alphabet, kept")]
        [DataRow("code: X7KQ2MM", "code: X7KQ2MM", DisplayName = "wrong length, kept")]
        [DataRow("barcode X7KQ2M", "barcode X7KQ2M", DisplayName = "trigger must be a whole word")]
        public void Codes_OnlyScrubbedNearTheirTrigger(string line, string expected) {
            Assert.AreEqual(expected, WithShareCodes().Redact(line));
        }

        [TestMethod]
        public void Codes_OutsideTheWindowAreKept() {
            string line = "code " + new string('.', 41) + " X7KQ2M";
            Assert.AreEqual(line, WithShareCodes().Redact(line));
        }

        [TestMethod]
        public void Codes_AlphabetWithClassMetacharactersIsLiteral() {
            LogRedactionOptions options = new LogRedactionOptions();
            options.Codes.Add(new CodeRedactionRule("pin", "0123456789-", 4));
            LogRedactor redactor = new LogRedactor(options);
            Assert.AreEqual("pin <id>", redactor.Redact("pin 1234"));
            Assert.AreEqual("pin AB12", redactor.Redact("pin AB12"));
        }

        [TestMethod]
        public void CodeRule_RejectsBadArguments() {
            Assert.ThrowsException<ArgumentException>(() => new CodeRedactionRule(" ", ShareAlphabet, 6));
            Assert.ThrowsException<ArgumentException>(() => new CodeRedactionRule("code", "", 6));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new CodeRedactionRule("code", ShareAlphabet, 0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new CodeRedactionRule("code", ShareAlphabet, 6, -1));
        }

        #endregion Patterns And Codes

        #region Cap And Snapshot

        [TestMethod]
        public void MaxLength_CapsAfterRedaction() {
            LogRedactionOptions options = LogRedactionOptions.CreateDefault();
            options.MaxLength = 12;
            Assert.AreEqual("player <i...", new LogRedactor(options).Redact("player 123456789012345678 joined"));
        }

        [TestMethod]
        public void MaxLength_NegativeThrowsAtConstruction() {
            LogRedactionOptions options = new LogRedactionOptions { MaxLength = -1 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new LogRedactor(options));
        }

        [TestMethod]
        public void Options_AreSnapshottedAtConstruction() {
            LogRedactionOptions options = new LogRedactionOptions();
            LogRedactor redactor = new LogRedactor(options);
            options.IdPatterns.Add(LogRedactionPatterns.Hex32);
            Assert.AreEqual("d41d8cd98f00b204e9800998ecf8427e", redactor.Redact("d41d8cd98f00b204e9800998ecf8427e"));
        }

        #endregion Cap And Snapshot

        #region Logger Hook

        [TestMethod]
        public void LoggerRedactor_RedactsHeaderAndMessageButKeepsAppend() {
            MockLoggerBase logger = new MockLoggerBase {
                Includes = new BaseMessageIncludes(timestamp: false, logSeverity: true, typeName: false, objectName: false, methodName: false),
            };
            LogRedactionOptions options = LogRedactionOptions.CreateDefault();
            options.MaxLength = 21;
            logger.Redactor = new LogRedactor(options);

            logger.Log(LogSeverity.Info, "player 123456789012345678 joined the lobby");

            Assert.AreEqual("[Info] player <id>...\n", logger.LastLoggedMessage);
        }

        [TestMethod]
        public void LoggerRedactor_NullByDefaultWritesUnchanged() {
            MockLoggerBase logger = new MockLoggerBase {
                Includes = new BaseMessageIncludes(timestamp: false, logSeverity: false, typeName: false, objectName: false, methodName: false),
            };
            logger.Log(LogSeverity.Info, "player 123456789012345678");
            Assert.IsNull(logger.Redactor);
            Assert.AreEqual(" player 123456789012345678\n", logger.LastLoggedMessage);
        }

        #endregion Logger Hook
    }

    [TestClass]
    public class LogTextTests {

        [DataTestMethod]
        [DataRow("short", 10, "short")]
        [DataRow("exactly10!", 10, "exactly10!")]
        [DataRow("this is too long", 10, "this is...")]
        [DataRow("abcdef", 3, "abc")]
        [DataRow("abcdef", 0, "")]
        public void Truncate_CapsWithEllipsis(string text, int max, string expected) {
            Assert.AreEqual(expected, LogText.Truncate(text, max));
        }

        [TestMethod]
        public void Truncate_NegativeCapThrows() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => LogText.Truncate("x", -1));
        }

        [TestMethod]
        public void Brief_ReplacesEmbeddedJsonWithItsSize() {
            string body = "{\"status\":400,\"message\":\"bad\",\"data\":{\"name\":\"Ana\"}}";
            Assert.AreEqual($"save failed: <{body.Length} chars of JSON>", LogText.Brief("save failed: " + body));
        }

        [TestMethod]
        public void Brief_DetectsArraysAndEmptyObjects() {
            Assert.AreEqual("rows <12 chars of JSON>", LogText.Brief("rows [{\"a\":1}, 2]"));
            Assert.AreEqual("reply <2 chars of JSON>", LogText.Brief("reply {}"));
        }

        [TestMethod]
        public void Brief_LeavesBracketsInProseAlone() {
            string line = "loaded [3] items into slot {0}";
            Assert.AreEqual(line, LogText.Brief(line));
        }

        [TestMethod]
        public void Brief_CapsPlainText() {
            Assert.AreEqual(LogText.DefaultMaxLength, LogText.Brief(new string('x', 500)).Length);
            Assert.AreEqual("abcdefg...", LogText.Brief("abcdefghijklmnop", 10));
        }

        [TestMethod]
        public void Brief_ExceptionIsTypeNameOnlyNeverMessage() {
            Exception e = new FormatException("Error converting value \"Ana\" to type Int32");
            Assert.AreEqual("FormatException", LogText.Brief(e));
        }
    }
}
