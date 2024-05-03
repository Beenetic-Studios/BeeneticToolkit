using System;
using System.Reflection;
using System.Text;

namespace BeeneticToolkit.Extensions {

    /// <summary>
    /// Provides extension methods for objects.
    /// </summary>
    public static class ObjectExtensions {

        /// <summary>
        /// Converts an object to a string representation of its public properties.
        /// </summary>
        /// <param name="obj">The object to convert.</param>
        /// <param name="prependString">The string to prepend to each property line. Default is an empty string.</param>
        /// <param name="endlineString">The string to append to each property line as a new line separator. Default is "\n".</param>
        /// <returns>A string containing the object's public property names and values.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input object is null.</exception>
        public static string ToPropertiesString(this object obj, string prependString = "", string endlineString = "\n") {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var stringBuilder = new StringBuilder();

            foreach (var property in properties) {
                var value = property.GetValue(obj);
                stringBuilder.Append($"{prependString}{property.Name}: {value}{endlineString}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}