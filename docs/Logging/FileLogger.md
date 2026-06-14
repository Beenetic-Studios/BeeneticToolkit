#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging.Loggers](index.md#BeeneticToolkit.Logging.Loggers 'BeeneticToolkit.Logging.Loggers')

## FileLogger Class

A logger that writes log messages to a file. Writes to the same file are serialized,  
so multiple [FileLogger](FileLogger.md 'BeeneticToolkit.Logging.Loggers.FileLogger') instances (and threads) can safely target one path.

```csharp
public class FileLogger : BeeneticToolkit.Logging.LoggerBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [LoggerBase](LoggerBase.md 'BeeneticToolkit.Logging.LoggerBase') &#129106; FileLogger

| Constructors | |
| :--- | :--- |
| [FileLogger(string, string, LogThreshold)](FileLogger.FileLogger(string,string,LogThreshold).md 'BeeneticToolkit.Logging.Loggers.FileLogger.FileLogger(string, string, BeeneticToolkit.Logging.Enums.LogThreshold)') | Initializes a new instance of the [FileLogger](FileLogger.md 'BeeneticToolkit.Logging.Loggers.FileLogger') class. |

| Methods | |
| :--- | :--- |
| [Log(LogSeverity, object, MethodBase, string, string, string)](FileLogger.Log(LogSeverity,object,MethodBase,string,string,string).md 'BeeneticToolkit.Logging.Loggers.FileLogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity, object, System.Reflection.MethodBase, string, string, string)') | Logs a message with additional context from an object and a method, and with the specified severity to the file. |
| [Log(LogSeverity, string, string, string)](FileLogger.Log(LogSeverity,string,string,string).md 'BeeneticToolkit.Logging.Loggers.FileLogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity, string, string, string)') | Logs a message with the specified severity to the file. |
