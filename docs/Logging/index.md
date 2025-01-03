#### [Logging](index.md 'index')

## Logging Assembly
### Namespaces

<a name='BeeneticToolkit.Logging'></a>

## BeeneticToolkit.Logging Namespace

The [BeeneticToolkit.Logging](index.md#BeeneticToolkit.Logging 'BeeneticToolkit.Logging') namespace encompasses classes and utilities that facilitate various logging operations.  
The LogManager class, as a central component of this namespace, provides a simplified and accessible  
interface for writing logs to various outputs, such as files, databases, or external logging services.  
It supports different levels of logging, such as info, debug, warning, and error,  
allowing for granular control over log output and severity.
- **[ConsoleLogger](ConsoleLogger.md 'BeeneticToolkit.Logging.ConsoleLogger')** `Class` A logger that writes log messages to the console.
  - **[ConsoleLogger(string, LogThreshold)](ConsoleLogger.ConsoleLogger(string,LogThreshold).md 'BeeneticToolkit.Logging.ConsoleLogger.ConsoleLogger(string, BeeneticToolkit.Logging.LogThreshold)')** `Constructor` Initializes a new instance of the [ConsoleLogger](ConsoleLogger.md 'BeeneticToolkit.Logging.ConsoleLogger') class.
  - **[Log(LogSeverity, object, MethodBase, string, string, string)](ConsoleLogger.Log(LogSeverity,object,MethodBase,string,string,string).md 'BeeneticToolkit.Logging.ConsoleLogger.Log(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase, string, string, string)')** `Method` Logs a message with additional context from an object and a method, and with the specified severity to the console.
  - **[Log(LogSeverity, string, string, string)](ConsoleLogger.Log(LogSeverity,string,string,string).md 'BeeneticToolkit.Logging.ConsoleLogger.Log(BeeneticToolkit.Logging.LogSeverity, string, string, string)')** `Method` Logs a message with the specified severity to the console.
- **[DebugLogger](DebugLogger.md 'BeeneticToolkit.Logging.DebugLogger')** `Class` A logger that writes log messages to the debug output.
  - **[DebugLogger(string, LogThreshold)](DebugLogger.DebugLogger(string,LogThreshold).md 'BeeneticToolkit.Logging.DebugLogger.DebugLogger(string, BeeneticToolkit.Logging.LogThreshold)')** `Constructor` Initializes a new instance of the [DebugLogger](DebugLogger.md 'BeeneticToolkit.Logging.DebugLogger') class.
  - **[Log(LogSeverity, object, MethodBase, string, string, string)](DebugLogger.Log(LogSeverity,object,MethodBase,string,string,string).md 'BeeneticToolkit.Logging.DebugLogger.Log(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase, string, string, string)')** `Method` Logs a message with additional context from an object and a method, and with the specified severity to the debug output.
  - **[Log(LogSeverity, string, string, string)](DebugLogger.Log(LogSeverity,string,string,string).md 'BeeneticToolkit.Logging.DebugLogger.Log(BeeneticToolkit.Logging.LogSeverity, string, string, string)')** `Method` Logs a message with the specified severity to the debug output.
- **[FileLogger](FileLogger.md 'BeeneticToolkit.Logging.FileLogger')** `Class` A logger that writes log messages to a file.
  - **[FileLogger(string, string, LogThreshold)](FileLogger.FileLogger(string,string,LogThreshold).md 'BeeneticToolkit.Logging.FileLogger.FileLogger(string, string, BeeneticToolkit.Logging.LogThreshold)')** `Constructor` Initializes a new instance of the [FileLogger](FileLogger.md 'BeeneticToolkit.Logging.FileLogger') class.
  - **[Log(LogSeverity, object, MethodBase, string, string, string)](FileLogger.Log(LogSeverity,object,MethodBase,string,string,string).md 'BeeneticToolkit.Logging.FileLogger.Log(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase, string, string, string)')** `Method` Logs a message with additional context from an object and a method, and with the specified severity to the file.
  - **[Log(LogSeverity, string, string, string)](FileLogger.Log(LogSeverity,string,string,string).md 'BeeneticToolkit.Logging.FileLogger.Log(BeeneticToolkit.Logging.LogSeverity, string, string, string)')** `Method` Logs a message with the specified severity to the file.
- **[LoggerBase](LoggerBase.md 'BeeneticToolkit.Logging.LoggerBase')** `Class` Provides a base implementation for loggers with common functionalities.
  - **[LoggerBase(string, LogThreshold)](LoggerBase.LoggerBase(string,LogThreshold).md 'BeeneticToolkit.Logging.LoggerBase.LoggerBase(string, BeeneticToolkit.Logging.LogThreshold)')** `Constructor` Initializes a new instance of the [LoggerBase](LoggerBase.md 'BeeneticToolkit.Logging.LoggerBase') class.
  - **[Enabled](LoggerBase.Enabled.md 'BeeneticToolkit.Logging.LoggerBase.Enabled')** `Property` Gets or sets a value indicating whether the logger is enabled.
  - **[Id](LoggerBase.Id.md 'BeeneticToolkit.Logging.LoggerBase.Id')** `Property` Gets the unique identifier for the logger.
  - **[Includes](LoggerBase.Includes.md 'BeeneticToolkit.Logging.LoggerBase.Includes')** `Property` Struct that contains flags for the individual components of [BaseMessage(LogSeverity, object, MethodBase)](LoggerBase.BaseMessage(LogSeverity,object,MethodBase).md 'BeeneticToolkit.Logging.LoggerBase.BaseMessage(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase)')
  - **[Name](LoggerBase.Name.md 'BeeneticToolkit.Logging.LoggerBase.Name')** `Property` Gets or sets the name of the logger.
  - **[Threshold](LoggerBase.Threshold.md 'BeeneticToolkit.Logging.LoggerBase.Threshold')** `Property` Gets or sets the logging threshold level.
  - **[TimestampFormat](LoggerBase.TimestampFormat.md 'BeeneticToolkit.Logging.LoggerBase.TimestampFormat')** `Property` Gets or sets the timestamp format, which is used in [BaseMessage(LogSeverity, object, MethodBase)](LoggerBase.BaseMessage(LogSeverity,object,MethodBase).md 'BeeneticToolkit.Logging.LoggerBase.BaseMessage(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase)').
  - **[AllowLogMessage(LogSeverity)](LoggerBase.AllowLogMessage(LogSeverity).md 'BeeneticToolkit.Logging.LoggerBase.AllowLogMessage(BeeneticToolkit.Logging.LogSeverity)')** `Method` Evaluates if a log message meets the required severity threshold and checks if the logger is currently enabled.
  - **[BaseMessage(LogSeverity, object, MethodBase)](LoggerBase.BaseMessage(LogSeverity,object,MethodBase).md 'BeeneticToolkit.Logging.LoggerBase.BaseMessage(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase)')** `Method` Generates a base message string including the current time, log level, and optionally the object and method context.
  - **[Log(LogSeverity, object, MethodBase, string, string, string)](LoggerBase.Log(LogSeverity,object,MethodBase,string,string,string).md 'BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase, string, string, string)')** `Method` Logs a message with additional context and the specified severity.
  - **[Log(LogSeverity, string, string, string)](LoggerBase.Log(LogSeverity,string,string,string).md 'BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.LogSeverity, string, string, string)')** `Method` Logs a message with the specified severity.
- **[LogManager](LogManager.md 'BeeneticToolkit.Logging.LogManager')** `Class` Manages logging operations by maintaining a collection of loggers and delegating log messages to them.
  - **[AddLogger(LoggerBase)](LogManager.AddLogger(LoggerBase).md 'BeeneticToolkit.Logging.LogManager.AddLogger(BeeneticToolkit.Logging.LoggerBase)')** `Method` Adds a logger to the LogManager and enables fluent configuration.
  - **[DisableLogger(string)](LogManager.DisableLogger(string).md 'BeeneticToolkit.Logging.LogManager.DisableLogger(string)')** `Method` Disables a logger with the specified identifier.
  - **[EnableLogger(string)](LogManager.EnableLogger(string).md 'BeeneticToolkit.Logging.LogManager.EnableLogger(string)')** `Method` Enables a logger with the specified identifier.
  - **[GetLogger(string)](LogManager.GetLogger(string).md 'BeeneticToolkit.Logging.LogManager.GetLogger(string)')** `Method` Gets a specified logger.
  - **[LogMessage(LogSeverity, object, MethodBase, string)](LogManager.LogMessage(LogSeverity,object,MethodBase,string).md 'BeeneticToolkit.Logging.LogManager.LogMessage(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase, string)')** `Method` Logs a message with additional context from an object and a method, using the specified severity.
  - **[LogMessage(LogSeverity, string)](LogManager.LogMessage(LogSeverity,string).md 'BeeneticToolkit.Logging.LogManager.LogMessage(BeeneticToolkit.Logging.LogSeverity, string)')** `Method` Logs a message with the specified severity.
- **[BaseMessageIncludes](BaseMessageIncludes.md 'BeeneticToolkit.Logging.BaseMessageIncludes')** `Struct` Represents a configuration of flags that specify which components are included in a log entry.
  - **[BaseMessageIncludes(bool, bool, bool, bool, bool)](BaseMessageIncludes.BaseMessageIncludes(bool,bool,bool,bool,bool).md 'BeeneticToolkit.Logging.BaseMessageIncludes.BaseMessageIncludes(bool, bool, bool, bool, bool)')** `Constructor` Initializes a new instance of the [BaseMessageIncludes](BaseMessageIncludes.md 'BeeneticToolkit.Logging.BaseMessageIncludes') struct with the specified component inclusion settings.
  - **[LogSeverity](BaseMessageIncludes.LogSeverity.md 'BeeneticToolkit.Logging.BaseMessageIncludes.LogSeverity')** `Property` Gets a value indicating whether the log severity is included in the log entry.
  - **[MethodName](BaseMessageIncludes.MethodName.md 'BeeneticToolkit.Logging.BaseMessageIncludes.MethodName')** `Property` Gets a value indicating whether the method name is included in the log entry.
  - **[ObjectName](BaseMessageIncludes.ObjectName.md 'BeeneticToolkit.Logging.BaseMessageIncludes.ObjectName')** `Property` Gets a value indicating whether the object name is included in the log entry.
  - **[Timestamp](BaseMessageIncludes.Timestamp.md 'BeeneticToolkit.Logging.BaseMessageIncludes.Timestamp')** `Property` Gets a value indicating whether the timestamp is included in the log entry.
  - **[TypeName](BaseMessageIncludes.TypeName.md 'BeeneticToolkit.Logging.BaseMessageIncludes.TypeName')** `Property` Gets a value indicating whether the type name is included in the log entry.
- **[ILogger](ILogger.md 'BeeneticToolkit.Logging.ILogger')** `Interface` Defines a general interface for loggers, allowing messages to be logged with varying levels of severity.
  - **[Log(LogSeverity, object, MethodBase, string, string, string)](ILogger.Log(LogSeverity,object,MethodBase,string,string,string).md 'BeeneticToolkit.Logging.ILogger.Log(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase, string, string, string)')** `Method` Logs a message with additional context from an object and a method, and with the specified severity.
  - **[Log(LogSeverity, string, string, string)](ILogger.Log(LogSeverity,string,string,string).md 'BeeneticToolkit.Logging.ILogger.Log(BeeneticToolkit.Logging.LogSeverity, string, string, string)')** `Method` Logs a message with the specified severity.
- **[LogSeverity](LogSeverity.md 'BeeneticToolkit.Logging.LogSeverity')** `Enum` Defines the severity levels for logging messages.
  - **[Debug](LogSeverity.md#BeeneticToolkit.Logging.LogSeverity.Debug 'BeeneticToolkit.Logging.LogSeverity.Debug')** `Field` Debug severity level, used for debugging purposes during development.
  - **[Error](LogSeverity.md#BeeneticToolkit.Logging.LogSeverity.Error 'BeeneticToolkit.Logging.LogSeverity.Error')** `Field` Error severity level, used for error events that might still allow the application to continue running.
  - **[Fatal](LogSeverity.md#BeeneticToolkit.Logging.LogSeverity.Fatal 'BeeneticToolkit.Logging.LogSeverity.Fatal')** `Field` Fatal severity level, used for very severe error events that will presumably lead the application to abort.
  - **[Info](LogSeverity.md#BeeneticToolkit.Logging.LogSeverity.Info 'BeeneticToolkit.Logging.LogSeverity.Info')** `Field` Informational severity level, used for general informational messages.
  - **[Trace](LogSeverity.md#BeeneticToolkit.Logging.LogSeverity.Trace 'BeeneticToolkit.Logging.LogSeverity.Trace')** `Field` Trace severity level, used for detailed and systematic logging.
  - **[Warn](LogSeverity.md#BeeneticToolkit.Logging.LogSeverity.Warn 'BeeneticToolkit.Logging.LogSeverity.Warn')** `Field` Warning severity level, used for potentially harmful situations.
- **[LogThreshold](LogThreshold.md 'BeeneticToolkit.Logging.LogThreshold')** `Enum` Defines the threshold levels for logging, determining which messages should be logged based on their severity.
  - **[All](LogThreshold.md#BeeneticToolkit.Logging.LogThreshold.All 'BeeneticToolkit.Logging.LogThreshold.All')** `Field` All logging levels are enabled. Every log message regardless of severity will be logged.
  - **[Debug](LogThreshold.md#BeeneticToolkit.Logging.LogThreshold.Debug 'BeeneticToolkit.Logging.LogThreshold.Debug')** `Field` Debug and higher severity levels are enabled. This includes Debug, Warn, Error, and Fatal.
  - **[Error](LogThreshold.md#BeeneticToolkit.Logging.LogThreshold.Error 'BeeneticToolkit.Logging.LogThreshold.Error')** `Field` Error and Fatal severity levels are enabled.
  - **[Fatal](LogThreshold.md#BeeneticToolkit.Logging.LogThreshold.Fatal 'BeeneticToolkit.Logging.LogThreshold.Fatal')** `Field` Only Fatal severity level is enabled.
  - **[Info](LogThreshold.md#BeeneticToolkit.Logging.LogThreshold.Info 'BeeneticToolkit.Logging.LogThreshold.Info')** `Field` Informational and higher severity levels are enabled. This includes Info, Debug, Warn, Error, and Fatal.
  - **[Off](LogThreshold.md#BeeneticToolkit.Logging.LogThreshold.Off 'BeeneticToolkit.Logging.LogThreshold.Off')** `Field` Logging is disabled. No log messages will be recorded.
  - **[Warn](LogThreshold.md#BeeneticToolkit.Logging.LogThreshold.Warn 'BeeneticToolkit.Logging.LogThreshold.Warn')** `Field` Warning and higher severity levels are enabled. This includes Warn, Error, and Fatal.

<a name='BeeneticToolkit.Logging.Utility'></a>

## BeeneticToolkit.Logging.Utility Namespace
- **[LogIgnoreAttribute](LogIgnoreAttribute.md 'BeeneticToolkit.Logging.Utility.LogIgnoreAttribute')** `Class` Specifies that a property should be ignored when generating a string representation  
  of an object's public properties using the [ToPropertiesString(object)](LogUtils.ToPropertiesString(object).md 'BeeneticToolkit.Logging.Utility.LogUtils.ToPropertiesString(object)') method.
- **[LogUtils](LogUtils.md 'BeeneticToolkit.Logging.Utility.LogUtils')** `Class` Provides utility methods for logging and displaying elements of collections and properties of objects.
  - **[PrintElements&lt;T&gt;(IEnumerable&lt;T&gt;, bool, string)](LogUtils.PrintElements_T_(IEnumerable_T_,bool,string).md 'BeeneticToolkit.Logging.Utility.LogUtils.PrintElements<T>(System.Collections.Generic.IEnumerable<T>, bool, string)')** `Method` Converts an IEnumerable sequence into a string representation, with options for inline display and custom delimiters.
  - **[PrintElements&lt;T&gt;(List&lt;T&gt;, bool, string)](LogUtils.PrintElements_T_(List_T_,bool,string).md 'BeeneticToolkit.Logging.Utility.LogUtils.PrintElements<T>(System.Collections.Generic.List<T>, bool, string)')** `Method` Converts a list of elements into a string representation, with options for inline display and custom delimiters.
  - **[PropertyZeroSet&lt;T&gt;(T)](LogUtils.PropertyZeroSet_T_(T).md 'BeeneticToolkit.Logging.Utility.LogUtils.PropertyZeroSet<T>(T)')** `Method` Sets all numeric properties of an object to zero.
  - **[ToPropertiesString(object)](LogUtils.ToPropertiesString(object).md 'BeeneticToolkit.Logging.Utility.LogUtils.ToPropertiesString(object)')** `Method` Creates a string representation of the public properties of an object, excluding any marked as obsolete.