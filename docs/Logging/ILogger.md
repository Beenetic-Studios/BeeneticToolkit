#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging](index.md#BeeneticToolkit.Logging 'BeeneticToolkit.Logging')

## ILogger Interface

Defines a general interface for loggers, allowing messages to be logged with varying levels of severity.

```csharp
public interface ILogger
```

Derived  
&#8627; [LoggerBase](LoggerBase.md 'BeeneticToolkit.Logging.LoggerBase')

| Methods | |
| :--- | :--- |
| [Log(LogSeverity, object, MethodBase, string, string, string)](ILogger.Log(LogSeverity,object,MethodBase,string,string,string).md 'BeeneticToolkit.Logging.ILogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity, object, System.Reflection.MethodBase, string, string, string)') | Logs a message with additional context from an object and a method, and with the specified severity. |
| [Log(LogSeverity, string, string, string)](ILogger.Log(LogSeverity,string,string,string).md 'BeeneticToolkit.Logging.ILogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity, string, string, string)') | Logs a message with the specified severity. |
