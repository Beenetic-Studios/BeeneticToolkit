using BeeneticToolkit.Logging.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BeeneticToolkit.Logging.Redaction {

    /// <summary>
    /// Scrubs identifiers out of a log line before it leaves the device: sensitive JSON values, id-shaped tokens, and
    /// context-dependent short codes, driven entirely by a <see cref="LogRedactionOptions"/>. Immutable and
    /// thread-safe once built; build one per rule set and reuse it.
    /// </summary>
    /// <remarks>
    /// Use it standalone (<see cref="Redact"/>) or attach it to a sink through <see cref="LoggerBase.Redactor"/>, so a
    /// remote sink (crash-report breadcrumbs) is redacted while a local file the player sends you stays complete.
    /// Patterns are not compiled with <see cref="RegexOptions.Compiled"/>: IL2CPP has no JIT, so it buys nothing on
    /// device. Order of application: JSON values, id patterns, code rules, then the length cap.
    /// </remarks>
    public sealed class LogRedactor {

        private const RegexOptions PatternOptions = RegexOptions.CultureInvariant;

        // The value honors escaped quotes, so "name":"a \"b\" c" is consumed to its real closing quote.
        private const string JsonStringValue = "\"(?:[^\"\\\\]|\\\\.)*\"";

        private readonly Regex? _jsonValues;
        private readonly string _jsonReplacement;
        private readonly Regex[] _idPatterns;
        private readonly string _idReplacement;
        private readonly int _maxLength;

        /// <summary>A redactor with <see cref="LogRedactionOptions.CreateDefault"/> rules.</summary>
        public static LogRedactor Default { get; } = new LogRedactor(LogRedactionOptions.CreateDefault());

        /// <summary>Builds a redactor from a snapshot of <paramref name="options"/>.</summary>
        /// <exception cref="System.ArgumentException">An id pattern is not a valid regular expression, or the cap is negative.</exception>
        public LogRedactor(LogRedactionOptions options) {
            if (options.MaxLength < 0)
                throw new System.ArgumentOutOfRangeException(nameof(options), options.MaxLength, "MaxLength cannot be negative (0 means no cap).");

            _jsonValues = options.JsonKeys.Count == 0
                ? null
                : new Regex(
                    "\"(" + string.Join("|", options.JsonKeys.Select(Regex.Escape)) + ")\"\\s*:\\s*" + JsonStringValue,
                    PatternOptions | RegexOptions.IgnoreCase);
            _jsonReplacement = "\"$1\":\"" + EscapeReplacement(options.ValuePlaceholder) + "\"";

            List<Regex> patterns = options.IdPatterns.Select(p => new Regex(p, PatternOptions)).ToList();
            patterns.AddRange(options.Codes.Select(BuildCodePattern));
            _idPatterns = patterns.ToArray();
            _idReplacement = EscapeReplacement(options.IdPlaceholder);
            _maxLength = options.MaxLength;
        }

        /// <summary>Returns <paramref name="line"/> with every rule applied. Null or empty comes back as-is.</summary>
        public string Redact(string line) {
            if (string.IsNullOrEmpty(line))
                return line;

            string result = _jsonValues == null ? line : _jsonValues.Replace(line, _jsonReplacement);
            foreach (Regex pattern in _idPatterns)
                result = pattern.Replace(result, _idReplacement);

            return _maxLength > 0 ? LogText.Truncate(result, _maxLength) : result;
        }

        // "<trigger> ... CODE": a lookbehind for the trigger word within the window, then a whole-word code.
        private static Regex BuildCodePattern(CodeRedactionRule rule) {
            StringBuilder alphabet = new StringBuilder();
            foreach (char c in rule.Alphabet.Distinct()) {
                if (c == '\\' || c == ']' || c == '[' || c == '^' || c == '-')
                    alphabet.Append('\\');
                alphabet.Append(c);
            }
            string pattern = "(?<=\\b(?i:" + Regex.Escape(rule.Trigger) + ")\\b[^\\r\\n]{0," + rule.Window + "}?)"
                + "\\b[" + alphabet + "]{" + rule.Length + "}\\b";
            return new Regex(pattern, PatternOptions);
        }

        private static string EscapeReplacement(string text) => text.Replace("$", "$$");
    }
}
