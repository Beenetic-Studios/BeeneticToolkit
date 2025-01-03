using BeeneticToolkit.Logging.Utility;
using System;
using System.Collections;
using System.Reflection;
using System.Text;

/// <summary>
/// Provides extension methods for objects.
/// </summary>
public static class ObjectExtensions {

    /// <summary>
    /// Converts an object to a string representation of its public properties.
    /// </summary>
    /// <param name="obj">The object to convert.</param>
    /// <param name="depth">The current depth of recursion. Default is 0.</param>
    /// <param name="indent">The indentation character for each level of depth. Default is ' ' (space).</param>
    /// <param name="newLineString">The string to append to each property line as a new line separator. Default is "\n".</param>
    /// <returns>A string containing the object's public property names and values.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input object is null.</exception>
    public static string ToPropertiesString(this object obj, int depth = 0, char indent = ' ', string newLineString = "\n") {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj));

        var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var stringBuilder = new StringBuilder();

        foreach (var property in properties) {
            if (!property.IsDefined(typeof(LogIgnoreAttribute), true) && !property.IsDefined(typeof(ObsoleteAttribute), true)) {
                var value = property.GetValue(obj);

                if (value is IDictionary dictionary) {
                    stringBuilder.Append($"{new string(indent, depth * 2)}{property.Name}:{newLineString}");

                    foreach (DictionaryEntry entry in dictionary) {
                        stringBuilder.Append($"{new string(indent, (depth + 1) * 2)}{entry.Key}: ");
                        stringBuilder.Append(entry.Value.ToPropertiesString(depth + 1, indent, newLineString));
                    }
                } else if (value is IEnumerable enumerable && !(value is string)) {
                    stringBuilder.Append($"{new string(indent, depth * 2)}{property.Name}:{newLineString}");

                    foreach (var item in enumerable) {
                        stringBuilder.Append($"{new string(indent, (depth + 1) * 2)}Item: ");
                        stringBuilder.Append(item.ToPropertiesString(depth + 1, indent, newLineString));
                    }
                } else if (IsSimpleType(value.GetType())) {
                    stringBuilder.Append($"{new string(indent, depth * 2)}{property.Name}: {value}{newLineString}");
                } else {
                    // Recursively print the properties of the complex object
                    stringBuilder.Append($"{new string(indent, depth * 2)}{property.Name}:{newLineString}");
                    stringBuilder.Append(value.ToPropertiesString(depth + 1, indent, newLineString));
                }
            }
        }
        return stringBuilder.ToString().TrimEnd();
    }

    /// <summary>
    /// Determines if the given type is a simple type or a complex object that needs recursive printing.
    /// </summary>
    /// <param name="type">The type to check.</param>
    /// <returns>True if it is a simple type, otherwise false.</returns>
    private static bool IsSimpleType(Type type) {
        return type == null || type.IsPrimitive || type == typeof(string) || type == typeof(DateTime) || type == typeof(decimal) || type.IsEnum;
    }
}

//using System;
//using System.Collections;
//using System.Reflection;
//using System.Text;

///// <summary>
///// Provides extension methods for objects.
///// </summary>
//public static class ObjectExtensions {
//    /// <summary>
//    /// Converts an object to a string representation of its public properties.
//    /// </summary>
//    /// <param name="obj">The object to convert.</param>
//    /// <param name="depth">The current depth of recursion. Default is 0.</param>
//    /// <param name="indent">The indentation character for each level of depth. Default is ' ' (space).</param>
//    /// <param name="newLineString">The string to append to each property line as a new line separator. Default is "\n".</param>
//    /// <returns>A string containing the object's public property names and values.</returns>
//    /// <exception cref="ArgumentNullException">Thrown when the input object is null.</exception>
//    public static string ToPropertiesString(this object obj, int depth = 0, char indent = ' ', string newLineString = "\n") {
//        if (obj == null)
//            throw new ArgumentNullException(nameof(obj));

//        var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

//        var stringBuilder = new StringBuilder();

//        foreach (var property in properties) {
//            var value = property.GetValue(obj);

//            if (value is IDictionary dictionary) {
//                stringBuilder.Append($"{new string(indent, depth * 2)}{property.Name}:{newLineString}");

//                foreach (var key in dictionary.Keys) {
//                    var entryValue = dictionary[key];
//                    stringBuilder.Append($"{new string(indent, (depth + 1) * 2)}{key}: {entryValue}{newLineString}");
//                }
//            } else if (value is IEnumerable enumerable && !(value is string)) {
//                stringBuilder.Append($"{new string(indent, depth * 2)}{property.Name}:{newLineString}");

//                foreach (var item in enumerable) {
//                    stringBuilder.Append($"{item.ToPropertiesString(depth + 1, indent, newLineString)}");
//                }
//            } else {
//                stringBuilder.Append($"{new string(indent, depth * 2)}{property.Name}: {value}{newLineString}");
//            }
//        }

//        return stringBuilder.ToString().TrimEnd();
//    }
//}