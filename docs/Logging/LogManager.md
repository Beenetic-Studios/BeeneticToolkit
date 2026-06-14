#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging](index.md#BeeneticToolkit.Logging 'BeeneticToolkit.Logging')

## LogManager Class

Manages logging operations by maintaining a collection of loggers and delegating log messages to them.

```csharp
public class LogManager
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LogManager

| Methods | |
| :--- | :--- |
| [AddLogger(LoggerBase)](LogManager.AddLogger(LoggerBase).md 'BeeneticToolkit.Logging.LogManager.AddLogger(BeeneticToolkit.Logging.LoggerBase)') | Adds a logger to the LogManager and enables fluent configuration. |
| [DisableLogger(string)](LogManager.DisableLogger(string).md 'BeeneticToolkit.Logging.LogManager.DisableLogger(string)') | Disables a logger with the specified identifier. |
| [EnableLogger(string)](LogManager.EnableLogger(string).md 'BeeneticToolkit.Logging.LogManager.EnableLogger(string)') | Enables a logger with the specified identifier. |
| [GetLogger(string)](LogManager.GetLogger(string).md 'BeeneticToolkit.Logging.LogManager.GetLogger(string)') | Gets a specified logger. |
| [LogMessage(LogSeverity, object, string, string)](LogManager.LogMessage(LogSeverity,object,string,string).md 'BeeneticToolkit.Logging.LogManager.LogMessage(BeeneticToolkit.Logging.Enums.LogSeverity, object, string, string)') | Logs a message with additional context from an object and a method name, using the specified severity. |
| [LogMessage(LogSeverity, object, MethodBase, string)](LogManager.LogMessage(LogSeverity,object,MethodBase,string).md 'BeeneticToolkit.Logging.LogManager.LogMessage(BeeneticToolkit.Logging.Enums.LogSeverity, object, System.Reflection.MethodBase, string)') | Logs a message with additional context from an object and a method, using the specified severity. |
| [LogMessage(LogSeverity, string)](LogManager.LogMessage(LogSeverity,string).md 'BeeneticToolkit.Logging.LogManager.LogMessage(BeeneticToolkit.Logging.Enums.LogSeverity, string)') | Logs a message with the specified severity. |
