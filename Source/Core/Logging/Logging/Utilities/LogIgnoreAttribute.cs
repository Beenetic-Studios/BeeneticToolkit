using System;

namespace BeeneticToolkit.Logging.Utilities {

    /// <summary>
    /// Specifies that a property should be ignored when generating a string representation
    /// of an object's public properties using <see cref="ObjectPropertyExtensions.ToPropertiesString"/>.
    /// </summary>
    /// <remarks>
    /// Apply this attribute to properties that should be excluded from property dumps (for example,
    /// sensitive or irrelevant information that should not appear in logs).
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property)]
    public class LogIgnoreAttribute : Attribute {
    }
}