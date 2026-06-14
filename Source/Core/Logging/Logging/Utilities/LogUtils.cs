using BeeneticToolkit.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BeeneticToolkit.Logging.Utilities {

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

            int count = 0;
            foreach (var item in list) {
                count++;
                var s = item?.ToString();
                if (inline && count < list.Count)
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

            int count = 0;
            do {
                count++;
                var s = enumerator.Current?.ToString();
                if (inline && count < enumerable.Count())
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
        public static string ToPropertiesString(object obj) {
            if (obj == null)
                return "null";

            PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var sb = new StringBuilder();

            foreach (PropertyInfo property in properties) {
                if (!property.IsDefined(typeof(LogIgnoreAttribute), true) && !property.IsDefined(typeof(ObsoleteAttribute), true)) {
                    try {
                        var value = property.GetValue(obj);
                        sb.AppendLine($"{property.Name}: {value ?? "null"}");
                    } catch {
                        sb.AppendLine($"{property.Name}: [Error retrieving value]");
                    }
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Sets all numeric properties of an object to zero.
        /// </summary>
        /// <typeparam name="T">The type of the object whose numeric properties will be set to zero.</typeparam>
        /// <param name="obj">The object whose numeric properties are to be updated. Must not be <c>null</c>.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="obj"/> is <c>null</c>.</exception>
        public static void PropertyZeroSet<T>(T obj) {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), "The object cannot be null.");

            var properties = obj.GetType().GetProperties();
            foreach (PropertyInfo property in properties) {
                if (IsNumericType(property.PropertyType)) {
                    property.SetValue(obj, 0);
                }
            }
        }

        /// <summary>
        /// A set of types that are considered numeric, including both integral and floating-point types.
        /// </summary>
        private static readonly HashSet<Type> NumericTypes = new HashSet<Type>() {
            typeof(byte),
            typeof(sbyte),
            typeof(short),
            typeof(ushort),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(float),
            typeof(double),
            typeof(decimal)
        };

        /// <summary>
        /// Determines whether a given type is numeric.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to check.</param>
        /// <returns><c>true</c> if the type is numeric or a nullable numeric type; otherwise, <c>false</c>.</returns>
        private static bool IsNumericType(Type type) {
            return NumericTypes.Contains(type) ||
                   NumericTypes.Contains(Nullable.GetUnderlyingType(type));
        }

        #endregion Properties
    }
}