using System;
using System.Text.RegularExpressions;

namespace BeeneticToolkit.Logging.Utilities {

    /// <summary>
    /// Shortens errors and messages for a log line, so a line carries what went wrong without dragging a whole
    /// server reply (and whatever names and ids it holds) into the log. For log lines only: keep passing the full
    /// error to any code that branches on it.
    /// </summary>
    public static class LogText {

        /// <summary>The default cap for <see cref="Brief(string, int)"/>.</summary>
        public const int DefaultMaxLength = 200;

        private const string Ellipsis = "...";

        // An object or array that actually looks like JSON: "{" before a key or "}", "[" before a value or "]".
        // A bare "[3]" or "{0}" in ordinary prose does not count.
        private static readonly Regex s_jsonStart = new Regex("\\{\\s*[\"}]|\\[\\s*[\"{\\[\\]]", RegexOptions.CultureInvariant);

        /// <summary>
        /// Cuts <paramref name="text"/> to at most <paramref name="maxLength"/> characters, ending in "..." when cut
        /// (a cap too small to hold the ellipsis just cuts). Null or empty comes back as-is.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxLength"/> is negative.</exception>
        public static string Truncate(string text, int maxLength) {
            if (maxLength < 0)
                throw new ArgumentOutOfRangeException(nameof(maxLength), maxLength, "Cap cannot be negative.");
            if (string.IsNullOrEmpty(text) || text.Length <= maxLength)
                return text;
            if (maxLength <= Ellipsis.Length)
                return text.Substring(0, maxLength);
            return text.Substring(0, maxLength - Ellipsis.Length) + Ellipsis;
        }

        /// <summary>
        /// A message for a log line: any embedded JSON body (whole, or after a prefix such as "save failed: ") is
        /// replaced by its size, and the result is capped at <paramref name="maxLength"/>. Null or empty comes back as-is.
        /// </summary>
        /// <remarks>
        /// Pulling fields worth keeping out of the JSON (a status, a reason code) is backend-specific; do that before
        /// calling this, or log those fields separately.
        /// </remarks>
        public static string Brief(string message, int maxLength = DefaultMaxLength) {
            if (string.IsNullOrEmpty(message))
                return message;

            Match json = s_jsonStart.Match(message);
            if (!json.Success)
                return Truncate(message, maxLength);

            int length = message.Length - json.Index;
            return Truncate(message.Substring(0, json.Index) + "<" + length + " chars of JSON>", maxLength);
        }

        /// <summary>
        /// An exception for a log line: its type name only, never its message.
        /// </summary>
        /// <remarks>
        /// Messages routinely embed the offending value ("Error converting value \"Ana\" to type ..."), which can be
        /// a player's name in a shape no redaction rule can recognize. Log the type, plus any context you chose.
        /// </remarks>
        public static string Brief(Exception exception) => exception.GetType().Name;
    }
}
