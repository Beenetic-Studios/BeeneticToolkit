using System;

namespace BeeneticToolkit.Logging.Utilities {

    /// <summary>
    /// Specifies that a property should be ignored when generating a string representation
    /// of an object's public properties using the <see cref="LogUtils.ToPropertiesString"/> method.
    /// </summary>
    /// <remarks>
    /// Apply this attribute to properties that should be excluded from the output of
    /// <see cref="LogUtils.ToPropertiesString"/>. This can be useful for sensitive or irrelevant information
    /// that should not be included in logs.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property)]
    public class LogIgnoreAttribute : Attribute {
    }
}