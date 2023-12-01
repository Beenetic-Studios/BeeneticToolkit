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
  - **[Log(LogSeverity, object, MethodBase, string)](ConsoleLogger.Log(LogSeverity,object,MethodBase,string).md 'BeeneticToolkit.Logging.ConsoleLogger.Log(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase, string)')** `Method` Logs a message with additional context from an object and a method, and with the specified severity to the console.
  - **[Log(LogSeverity, string)](ConsoleLogger.Log(LogSeverity,string).md 'BeeneticToolkit.Logging.ConsoleLogger.Log(BeeneticToolkit.Logging.LogSeverity, string)')** `Method` Logs a message with the specified severity to the console.
- **[DebugLogger](DebugLogger.md 'BeeneticToolkit.Logging.DebugLogger')** `Class` A logger that writes log messages to the debug output.
  - **[DebugLogger(string, LogThreshold)](DebugLogger.DebugLogger(string,LogThreshold).md 'BeeneticToolkit.Logging.DebugLogger.DebugLogger(string, BeeneticToolkit.Logging.LogThreshold)')** `Constructor` Initializes a new instance of the [DebugLogger](DebugLogger.md 'BeeneticToolkit.Logging.DebugLogger') class.
  - **[Log(LogSeverity, object, MethodBase, string)](DebugLogger.Log(LogSeverity,object,MethodBase,string).md 'BeeneticToolkit.Logging.DebugLogger.Log(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase, string)')** `Method` Logs a message with additional context from an object and a method, and with the specified severity to the debug output.
  - **[Log(LogSeverity, string)](DebugLogger.Log(LogSeverity,string).md 'BeeneticToolkit.Logging.DebugLogger.Log(BeeneticToolkit.Logging.LogSeverity, string)')** `Method` Logs a message with the specified severity to the debug output.
- **[FileLogger](FileLogger.md 'BeeneticToolkit.Logging.FileLogger')** `Class` A logger that writes log messages to a file.
  - **[FileLogger(string, string, LogThreshold)](FileLogger.FileLogger(string,string,LogThreshold).md 'BeeneticToolkit.Logging.FileLogger.FileLogger(string, string, BeeneticToolkit.Logging.LogThreshold)')** `Constructor` Initializes a new instance of the [FileLogger](FileLogger.md 'BeeneticToolkit.Logging.FileLogger') class.
  - **[Log(LogSeverity, object, MethodBase, string)](FileLogger.Log(LogSeverity,object,MethodBase,string).md 'BeeneticToolkit.Logging.FileLogger.Log(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase, string)')** `Method` Logs a message with additional context from an object and a method, and with the specified severity to the file.
  - **[Log(LogSeverity, string)](FileLogger.Log(LogSeverity,string).md 'BeeneticToolkit.Logging.FileLogger.Log(BeeneticToolkit.Logging.LogSeverity, string)')** `Method` Logs a message with the specified severity to the file.
- **[LoggerBase](LoggerBase.md 'BeeneticToolkit.Logging.LoggerBase')** `Class` Provides a base implementation for loggers with common functionalities.
  - **[LoggerBase(string, LogThreshold)](LoggerBase.LoggerBase(string,LogThreshold).md 'BeeneticToolkit.Logging.LoggerBase.LoggerBase(string, BeeneticToolkit.Logging.LogThreshold)')** `Constructor` Initializes a new instance of the [LoggerBase](LoggerBase.md 'BeeneticToolkit.Logging.LoggerBase') class.
  - **[Enabled](LoggerBase.Enabled.md 'BeeneticToolkit.Logging.LoggerBase.Enabled')** `Property` Gets or sets a value indicating whether the logger is enabled.
  - **[Id](LoggerBase.Id.md 'BeeneticToolkit.Logging.LoggerBase.Id')** `Property` Gets the unique identifier for the logger.
  - **[Name](LoggerBase.Name.md 'BeeneticToolkit.Logging.LoggerBase.Name')** `Property` Gets or sets the name of the logger.
  - **[Threshold](LoggerBase.Threshold.md 'BeeneticToolkit.Logging.LoggerBase.Threshold')** `Property` Gets or sets the logging threshold level.
  - **[TimestampFormat](LoggerBase.TimestampFormat.md 'BeeneticToolkit.Logging.LoggerBase.TimestampFormat')** `Property` Gets or sets the timestamp format, which is used in [BaseMessage(LogSeverity, object, MethodBase)](LoggerBase.BaseMessage(LogSeverity,object,MethodBase).md 'BeeneticToolkit.Logging.LoggerBase.BaseMessage(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase)').
  - **[AllowLogMessage(LogSeverity)](LoggerBase.AllowLogMessage(LogSeverity).md 'BeeneticToolkit.Logging.LoggerBase.AllowLogMessage(BeeneticToolkit.Logging.LogSeverity)')** `Method` Evaluates if a log message meets the required severity threshold and checks if the logger is currently enabled.
  - **[BaseMessage(LogSeverity, object, MethodBase)](LoggerBase.BaseMessage(LogSeverity,object,MethodBase).md 'BeeneticToolkit.Logging.LoggerBase.BaseMessage(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase)')** `Method` Generates a base message string including the current time, log level, and optionally the object and method context.
  - **[Log(LogSeverity, object, MethodBase, string)](LoggerBase.Log(LogSeverity,object,MethodBase,string).md 'BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase, string)')** `Method` Logs a message with additional context and the specified severity.
  - **[Log(LogSeverity, string)](LoggerBase.Log(LogSeverity,string).md 'BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.LogSeverity, string)')** `Method` Logs a message with the specified severity.
- **[LogManager](LogManager.md 'BeeneticToolkit.Logging.LogManager')** `Class` Manages logging operations by maintaining a collection of loggers and delegating log messages to them.
  - **[AddLogger(LoggerBase)](LogManager.AddLogger(LoggerBase).md 'BeeneticToolkit.Logging.LogManager.AddLogger(BeeneticToolkit.Logging.LoggerBase)')** `Method` Adds a logger to the LogManager and enables fluent configuration.
  - **[DisableLogger(string)](LogManager.DisableLogger(string).md 'BeeneticToolkit.Logging.LogManager.DisableLogger(string)')** `Method` Disables a logger with the specified identifier.
  - **[EnableLogger(string)](LogManager.EnableLogger(string).md 'BeeneticToolkit.Logging.LogManager.EnableLogger(string)')** `Method` Enables a logger with the specified identifier.
  - **[LogMessage(LogSeverity, object, MethodBase, string)](LogManager.LogMessage(LogSeverity,object,MethodBase,string).md 'BeeneticToolkit.Logging.LogManager.LogMessage(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase, string)')** `Method` Logs a message with additional context from an object and a method, using the specified severity.
  - **[LogMessage(LogSeverity, string)](LogManager.LogMessage(LogSeverity,string).md 'BeeneticToolkit.Logging.LogManager.LogMessage(BeeneticToolkit.Logging.LogSeverity, string)')** `Method` Logs a message with the specified severity.
- **[ILogger](ILogger.md 'BeeneticToolkit.Logging.ILogger')** `Interface` Defines a general interface for loggers, allowing messages to be logged with varying levels of severity.
  - **[Log(LogSeverity, object, MethodBase, string)](ILogger.Log(LogSeverity,object,MethodBase,string).md 'BeeneticToolkit.Logging.ILogger.Log(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase, string)')** `Method` Logs a message with additional context from an object and a method, and with the specified severity.
  - **[Log(LogSeverity, string)](ILogger.Log(LogSeverity,string).md 'BeeneticToolkit.Logging.ILogger.Log(BeeneticToolkit.Logging.LogSeverity, string)')** `Method` Logs a message with the specified severity.
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