#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging](index.md#BeeneticToolkit.Logging 'BeeneticToolkit.Logging')

## LoggerBase Class

Provides a base implementation for loggers with common functionalities.

```csharp
public abstract class LoggerBase :
BeeneticToolkit.Logging.IBeeneticLogger
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LoggerBase

Derived  
&#8627; [ConsoleLogger](ConsoleLogger.md 'BeeneticToolkit.Logging.Loggers.ConsoleLogger')  
&#8627; [DebugLogger](DebugLogger.md 'BeeneticToolkit.Logging.Loggers.DebugLogger')  
&#8627; [FileLogger](FileLogger.md 'BeeneticToolkit.Logging.Loggers.FileLogger')

Implements [IBeeneticLogger](IBeeneticLogger.md 'BeeneticToolkit.Logging.IBeeneticLogger')

| Constructors | |
| :--- | :--- |
| [LoggerBase(string, LogThreshold)](LoggerBase.LoggerBase(string,LogThreshold).md 'BeeneticToolkit.Logging.LoggerBase.LoggerBase(string, BeeneticToolkit.Logging.Enums.LogThreshold)') | Initializes a new instance of the [LoggerBase](LoggerBase.md 'BeeneticToolkit.Logging.LoggerBase') class. |

| Properties | |
| :--- | :--- |
| [Enabled](LoggerBase.Enabled.md 'BeeneticToolkit.Logging.LoggerBase.Enabled') | Gets or sets a value indicating whether the logger is enabled. |
| [Id](LoggerBase.Id.md 'BeeneticToolkit.Logging.LoggerBase.Id') | Gets the unique identifier for the logger. |
| [Includes](LoggerBase.Includes.md 'BeeneticToolkit.Logging.LoggerBase.Includes') | Struct that contains flags for the individual components of [BaseMessage(LogSeverity, object, MethodBase)](LoggerBase.BaseMessage(LogSeverity,object,MethodBase).md 'BeeneticToolkit.Logging.LoggerBase.BaseMessage(BeeneticToolkit.Logging.Enums.LogSeverity, object, System.Reflection.MethodBase)') |
| [Name](LoggerBase.Name.md 'BeeneticToolkit.Logging.LoggerBase.Name') | Gets or sets the name of the logger. |
| [Threshold](LoggerBase.Threshold.md 'BeeneticToolkit.Logging.LoggerBase.Threshold') | Gets or sets the logging threshold level. |
| [TimestampFormat](LoggerBase.TimestampFormat.md 'BeeneticToolkit.Logging.LoggerBase.TimestampFormat') | Gets or sets the timestamp format, which is used in [BaseMessage(LogSeverity, object, MethodBase)](LoggerBase.BaseMessage(LogSeverity,object,MethodBase).md 'BeeneticToolkit.Logging.LoggerBase.BaseMessage(BeeneticToolkit.Logging.Enums.LogSeverity, object, System.Reflection.MethodBase)'). |

| Methods | |
| :--- | :--- |
| [AllowLogMessage(LogSeverity)](LoggerBase.AllowLogMessage(LogSeverity).md 'BeeneticToolkit.Logging.LoggerBase.AllowLogMessage(BeeneticToolkit.Logging.Enums.LogSeverity)') | Evaluates if a log message meets the required severity threshold and checks if the logger is currently enabled. |
| [BaseMessage(LogSeverity, object, string)](LoggerBase.BaseMessage(LogSeverity,object,string).md 'BeeneticToolkit.Logging.LoggerBase.BaseMessage(BeeneticToolkit.Logging.Enums.LogSeverity, object, string)') | Generates a base message string including the current time, log level, and optionally the object and method-name context. |
| [BaseMessage(LogSeverity, object, MethodBase)](LoggerBase.BaseMessage(LogSeverity,object,MethodBase).md 'BeeneticToolkit.Logging.LoggerBase.BaseMessage(BeeneticToolkit.Logging.Enums.LogSeverity, object, System.Reflection.MethodBase)') | Generates a base message string including the current time, log level, and optionally the object and method context. |
| [Log(LogSeverity, object, string, string, string, string)](LoggerBase.Log(LogSeverity,object,string,string,string,string).md 'BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.Enums.LogSeverity, object, string, string, string, string)') | Logs a message with additional context from an object and a method name, using the specified severity. |
| [Log(LogSeverity, object, MethodBase, string, string, string)](LoggerBase.Log(LogSeverity,object,MethodBase,string,string,string).md 'BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.Enums.LogSeverity, object, System.Reflection.MethodBase, string, string, string)') | Logs a message with additional context and the specified severity. |
| [Log(LogSeverity, string, string, string)](LoggerBase.Log(LogSeverity,string,string,string).md 'BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.Enums.LogSeverity, string, string, string)') | Logs a message with the specified severity. |
