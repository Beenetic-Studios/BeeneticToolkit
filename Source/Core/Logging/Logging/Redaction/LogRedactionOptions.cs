using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Logging.Redaction {

    /// <summary>
    /// Ready-made id patterns for <see cref="LogRedactionOptions.IdPatterns"/>. These are the defaults; add your own
    /// platform ids (a store's player id format, say) alongside them.
    /// </summary>
    public static class LogRedactionPatterns {

        /// <summary>A GUID / UUID in the usual 8-4-4-4-12 hex form, any case.</summary>
        public const string Guid = @"(?i)\b[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}\b";

        /// <summary>A bare 32-character hex token (a dashless GUID, an MD5, many session and device ids), any case.</summary>
        public const string Hex32 = @"(?i)\b[0-9a-f]{32}\b";

        /// <summary>A run of 15 or more digits (platform account ids; short counts and timestamps are left alone).</summary>
        public const string LongDigits = @"\b\d{15,}\b";
    }

    /// <summary>
    /// A short code (an invite or share code) that is only recognizable by context: a word of exactly
    /// <see cref="Length"/> characters from <see cref="Alphabet"/>, appearing within <see cref="Window"/> characters
    /// after <see cref="Trigger"/> on the same line ("Share code ready: X7KQ2M").
    /// </summary>
    /// <remarks>
    /// The trigger is what keeps ordinary words safe: a six-letter upper-case code alphabet also matches ONLINE or
    /// PLAYER, so codes are only scrubbed where the line says it is talking about one.
    /// </remarks>
    public sealed class CodeRedactionRule {

        /// <summary>The default distance, in characters, a code may sit after its trigger word.</summary>
        public const int DefaultWindow = 40;

        /// <summary>The word that introduces a code, matched case-insensitively as a whole word (e.g. "code").</summary>
        public string Trigger { get; }

        /// <summary>The characters a code is drawn from, matched case-sensitively (e.g. "ABCDEFGHJKLMNPQRSTUVWXYZ23456789").</summary>
        public string Alphabet { get; }

        /// <summary>The exact length of a code.</summary>
        public int Length { get; }

        /// <summary>How many characters after the trigger a code may start.</summary>
        public int Window { get; }

        /// <summary>Creates a code rule.</summary>
        /// <exception cref="ArgumentException">The trigger or alphabet is empty, or length or window is out of range.</exception>
        public CodeRedactionRule(string trigger, string alphabet, int length, int window = DefaultWindow) {
            if (string.IsNullOrWhiteSpace(trigger))
                throw new ArgumentException("A code rule needs a trigger word.", nameof(trigger));
            if (string.IsNullOrEmpty(alphabet))
                throw new ArgumentException("A code rule needs an alphabet.", nameof(alphabet));
            if (length < 1)
                throw new ArgumentOutOfRangeException(nameof(length), length, "Code length must be at least 1.");
            if (window < 0)
                throw new ArgumentOutOfRangeException(nameof(window), window, "Window cannot be negative.");

            Trigger = trigger;
            Alphabet = alphabet;
            Length = length;
            Window = window;
        }
    }

    /// <summary>
    /// The rules a <see cref="LogRedactor"/> applies. Fill one in, then hand it to the redactor, which compiles it
    /// once; later changes to the options do not affect a redactor already built from them.
    /// </summary>
    public sealed class LogRedactionOptions {

        /// <summary>The placeholder written over an id or code. Default <c>&lt;id&gt;</c>.</summary>
        public string IdPlaceholder { get; set; } = "<id>";

        /// <summary>The placeholder written over a sensitive JSON string value. Default <c>&lt;redacted&gt;</c>.</summary>
        public string ValuePlaceholder { get; set; } = "<redacted>";

        /// <summary>
        /// JSON keys (matched case-insensitively) whose string values are blanked: <c>"email":"a@b.c"</c> becomes
        /// <c>"email":"&lt;redacted&gt;"</c>. Runs before the id patterns, so a value is dropped whole rather than
        /// half-scrubbed. Escaped quotes inside a value are honored. Non-string values are left to the id patterns.
        /// </summary>
        public IList<string> JsonKeys { get; } = new List<string>();

        /// <summary>
        /// Regular expressions whose matches are replaced by <see cref="IdPlaceholder"/>, applied in order. They are
        /// compiled culture-invariant and case-sensitive; use an inline <c>(?i)</c> for case-insensitive patterns.
        /// </summary>
        public IList<string> IdPatterns { get; } = new List<string>();

        /// <summary>Context-dependent short codes, applied after the id patterns.</summary>
        public IList<CodeRedactionRule> Codes { get; } = new List<CodeRedactionRule>();

        /// <summary>
        /// Caps the redacted line at this many characters (ending in "..."), or 0 for no cap. Useful for sinks with a
        /// size limit such as crash-report breadcrumbs.
        /// </summary>
        public int MaxLength { get; set; }

        /// <summary>Options with the default id patterns (GUIDs, 32-hex tokens, long digit runs) and nothing else.</summary>
        public static LogRedactionOptions CreateDefault() {
            LogRedactionOptions options = new LogRedactionOptions();
            options.IdPatterns.Add(LogRedactionPatterns.Guid);
            options.IdPatterns.Add(LogRedactionPatterns.Hex32);
            options.IdPatterns.Add(LogRedactionPatterns.LongDigits);
            return options;
        }
    }
}
