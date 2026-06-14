using BeeneticToolkit.Logging.Utilities;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BeeneticToolkit.Extensions {

    /// <summary>Provides extension methods for objects.</summary>
    public static class ObjectPropertyExtensions {

        #region Numerics

        /// <summary>Calculates the sum of all numeric properties of an object, optionally filtered by a custom condition.</summary>
        /// <param name="obj">The object whose numeric properties are to be summed.</param>
        /// <param name="filter">An optional filter to include specific properties based on a condition. Defaults to including all numeric properties.</param>
        /// <returns>The sum of the numeric properties that match the filter.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input object is null.</exception>
        public static double SumNumericProperties(this object obj, Func<PropertyInfo, bool>? filter = null) {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            filter ??= p => IsNumericType(p.PropertyType);

            return GetCachedProperties(obj.GetType())
                .Where(filter)
                .Select(p => Convert.ToDouble(p.GetValue(obj) ?? 0))
                .Sum();
        }

        /// <summary>Counts the number of numeric properties in an object, optionally filtered by a custom condition.</summary>
        /// <param name="obj">The object whose numeric properties are to be counted.</param>
        /// <param name="filter">An optional filter to include specific properties based on a condition. Defaults to including all numeric properties.</param>
        /// <returns>The count of numeric properties that match the filter.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input object is null.</exception>
        public static int CountNumericProperties(this object obj, Func<PropertyInfo, bool>? filter = null) {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            filter ??= p => IsNumericType(p.PropertyType);

            return GetCachedProperties(obj.GetType())
                .Count(filter);
        }

        /// <summary>Counts the number of non-zero numeric properties in an object, optionally filtered by a custom condition.</summary>
        /// <param name="obj">The object whose numeric properties are to be evaluated.</param>
        /// <param name="filter">An optional filter to include specific properties based on a condition. Defaults to including all numeric properties.</param>
        /// <returns>The count of non-zero numeric properties that match the filter.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input object is null.</exception>
        public static int CountNonZeroNumericProperties(this object obj, Func<PropertyInfo, bool>? filter = null) {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            filter ??= p => IsNumericType(p.PropertyType);

            return GetCachedProperties(obj.GetType())
                .Where(filter)
                .Select(p => Convert.ToDouble(p.GetValue(obj) ?? 0))
                .Count(value => value != 0);
        }

        #endregion Numerics

        #region Strings

        /// <summary>Converts an object to a string representation of its public properties, including nested objects, dictionaries, and collections.</summary>
        /// <param name="obj">The object to convert.</param>
        /// <param name="depth">The current depth of recursion. Defaults to 0.</param>
        /// <param name="indent">The indentation character for each level of depth. Defaults to a single space.</param>
        /// <param name="newLineString">The string to append as a new line separator. Defaults to "\n".</param>
        /// <returns>A string containing the object's public property names and values, including nested objects.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input object is null.</exception>
        public static string ToPropertiesString(this object obj, int depth = 0, char indent = ' ', string newLineString = "\n") {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            // Get cached properties for the runtime type of the object
            var properties = GetCachedProperties(obj.GetType());
            var stringBuilder = new StringBuilder();

            foreach (var property in properties) {
                // Skip properties that require index parameters (e.g., indexers)
                if (property.GetIndexParameters().Length > 0)
                    continue;

                // Skip properties with LogIgnore or Obsolete attributes
                if (property.IsDefined(typeof(LogIgnoreAttribute), true) || property.IsDefined(typeof(ObsoleteAttribute), true))
                    continue;

                // Safely access the property value
                object? value;
                try {
                    value = property.GetValue(obj);
                } catch {
                    stringBuilder.Append($"{new string(indent, depth * 2)}{property.Name}: Error retrieving value{newLineString}");
                    continue;
                }

                // Handle value types
                if (value is IDictionary dictionary) {
                    stringBuilder.Append($"{new string(indent, depth * 2)}{property.Name}:{newLineString}");

                    foreach (DictionaryEntry entry in dictionary) {
                        stringBuilder.Append($"{new string(indent, (depth + 1) * 2)}{entry.Key}:");

                        if (entry.Value != null) {
                            if (IsSimpleType(entry.Value.GetType())) {
                                // Append simple type values directly
                                stringBuilder.Append($" {entry.Value}{newLineString}");
                            } else {
                                // Append a newline after the key and recursively process the value
                                stringBuilder.Append($"{newLineString}{entry.Value.ToPropertiesString(depth + 2, indent, newLineString)}{newLineString}");
                            }
                        } else {
                            // Append "null" for null values
                            stringBuilder.Append(" null\n");
                        }
                    }
                } else if (value is IEnumerable enumerable && !(value is string)) {
                    stringBuilder.Append($"{new string(indent, depth * 2)}{property.Name}:{newLineString}");

                    foreach (var item in enumerable) {
                        stringBuilder.Append($"{new string(indent, (depth + 1) * 2)}Item:");

                        if (item != null) {
                            if (IsSimpleType(item.GetType())) {
                                // Append a space and the value for simple items
                                stringBuilder.Append($" {item}{newLineString}");
                            } else {
                                // Append a newline before and after processing complex items
                                stringBuilder.Append($"{newLineString}{item.ToPropertiesString(depth + 2, indent, newLineString)}{newLineString}");
                            }
                        } else {
                            // Append "null" for null items
                            stringBuilder.Append(" null\n");
                        }
                    }
                } else if (value != null && IsSimpleType(value.GetType())) {
                    stringBuilder.Append($"{new string(indent, depth * 2)}{property.Name}: {value}{newLineString}");
                } else {
                    stringBuilder.Append($"{new string(indent, depth * 2)}{property.Name}:{newLineString}");

                    if (value != null) {
                        stringBuilder.Append($"{value.ToPropertiesString(depth + 1, indent, newLineString)}{newLineString}");
                    } else {
                        stringBuilder.Append("null\n");
                    }
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }

        #endregion Strings

        #region Type Checks

        /// <summary>Determines if the given type is a simple type or a complex object that needs recursive printing.</summary>
        /// <param name="type">The type to check.</param>
        /// <returns><c>true</c> if the type is simple; otherwise, <c>false</c>.</returns>
        private static bool IsSimpleType(Type type) {
            return type == null || type.IsPrimitive || type == typeof(string) || type == typeof(DateTime) || type == typeof(decimal) || type.IsEnum;
        }

        /// <summary>Determines whether a type represents a numeric value.</summary>
        /// <param name="type">The type to evaluate.</param>
        /// <returns><c>true</c> if the type is numeric; otherwise, <c>false</c>.</returns>
        private static bool IsNumericType(Type type) =>
            type == typeof(byte) || type == typeof(sbyte) ||
            type == typeof(short) || type == typeof(ushort) ||
            type == typeof(int) || type == typeof(uint) ||
            type == typeof(long) || type == typeof(ulong) ||
            type == typeof(float) || type == typeof(double) ||
            type == typeof(decimal);

        #endregion Type Checks

        #region Cache Management

        /// <summary>Thread-safe cache for storing property information by type for optimized access.</summary>
        private static readonly ConcurrentDictionary<Type, PropertyInfo[]> _propertyCache = new ConcurrentDictionary<Type, PropertyInfo[]>();

        /// <summary>Gets the cached public properties of a given type, leveraging caching for efficiency.</summary>
        /// <param name="type">The type whose properties are to be retrieved.</param>
        /// <returns>An array of public properties for the specified type.</returns>
        private static PropertyInfo[] GetCachedProperties(Type type) {
            return _propertyCache.GetOrAdd(type, t => t.GetProperties(BindingFlags.Public | BindingFlags.Instance));
        }

        #endregion Cache Management
    }
}