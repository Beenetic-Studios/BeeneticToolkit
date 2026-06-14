#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging](index.md#BeeneticToolkit.Logging 'BeeneticToolkit.Logging')

## IBeeneticLogger Interface

Defines a general interface for loggers, allowing messages to be logged with varying levels of severity.

```csharp
public interface IBeeneticLogger
```

Derived  
&#8627; [LoggerBase](LoggerBase.md 'BeeneticToolkit.Logging.LoggerBase')

### Remarks
Named to avoid collision with `Microsoft.Extensions.Logging.ILogger`, which consumers  
frequently import in the same scope.

| Methods | |
| :--- | :--- |
| [Log(LogSeverity, object, MethodBase, string, string, string)](IBeeneticLogger.Log(LogSeverity,object,MethodBase,string,string,string).md 'BeeneticToolkit.Logging.IBeeneticLogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity, object, System.Reflection.MethodBase, string, string, string)') | Logs a message with additional context from an object and a method, and with the specified severity. |
| [Log(LogSeverity, string, string, string)](IBeeneticLogger.Log(LogSeverity,string,string,string).md 'BeeneticToolkit.Logging.IBeeneticLogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity, string, string, string)') | Logs a message with the specified severity. |
