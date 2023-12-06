using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BeeneticToolkit.Logging.Utility {

    /// <summary>
    /// Provides utility methods for logging and displaying elements of collections and properties of objects.
    /// </summary>
    public static class LogUtils {

        #region Print Elements

        /// <summary>
        /// Converts a list of elements into a string representation, with options for inline display and custom delimiters.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to be converted into a string.</param>
        /// <param name="inline">Specifies whether the elements should be displayed inline.</param>
        /// <param name="delimiter">The delimiter to use between elements when displayed inline.</param>
        /// <returns>A string representation of the list's elements.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input list is null.</exception>
        public static string PrintElements<T>(List<T> list, bool inline = true, string delimiter = " ") {
            if (list == null) {
                throw new ArgumentNullException(nameof(list), "The list cannot be null.");
            }

            if (list.Count == 0) {
                return "The list is empty.\n";
            }

            var sb = new StringBuilder();
            sb.Append(inline ? "" : "\n");
            foreach (var item in list) {
                var s = item?.ToString();
                if (inline)
                    sb.Append(s).Append(delimiter);
                else
                    sb.AppendLine(s);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Converts an IEnumerable sequence into a string representation, with options for inline display and custom delimiters.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="enumerable">The enumerable to be converted into a string.</param>
        /// <param name="inline">Specifies whether the elements should be displayed inline.</param>
        /// <param name="delimiter">The delimiter to use between elements when displayed inline.</param>
        /// <returns>A string representation of the sequence's elements.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input enumerable is null.</exception>
        public static string PrintElements<T>(IEnumerable<T> enumerable, bool inline = true, string delimiter = " ") {
            if (enumerable == null) {
                throw new ArgumentNullException(nameof(enumerable), "The enumerable cannot be null.");
            }

            using var enumerator = enumerable.GetEnumerator();
            if (!enumerator.MoveNext()) {
                return "The enumerable is empty.\n";
            }

            var sb = new StringBuilder();
            sb.Append(inline ? "" : "\n");
            do {
                var s = enumerator.Current?.ToString();
                if (inline)
                    sb.Append(s).Append(delimiter);
                else
                    sb.AppendLine(s);
            } while (enumerator.MoveNext());

            return sb.ToString();
        }

        #endregion Print Elements

        #region Properties

        /// <summary>
        /// Creates a string representation of the public properties of an object, excluding any marked as obsolete.
        /// </summary>
        /// <param name="obj">The object whose properties are to be represented in a string.</param>
        /// <returns>A string listing the object's properties and their values.</returns>
        public static string PropertiesString(object obj) {
            var sb = new StringBuilder();
            PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in properties) {
                if (!property.IsDefined(typeof(ObsoleteAttribute), true)) {
                    var value = property.GetValue(obj, null) ?? "null";
                    sb.AppendLine($"{property.Name}:\t{value}");
                }
            }

            return sb.ToString();
        }

        #endregion Properties
    }
}