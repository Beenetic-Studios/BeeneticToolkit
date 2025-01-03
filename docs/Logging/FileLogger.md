#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging](index.md#BeeneticToolkit.Logging 'BeeneticToolkit.Logging')

## FileLogger Class

A logger that writes log messages to a file.

```csharp
public class FileLogger : BeeneticToolkit.Logging.LoggerBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [LoggerBase](LoggerBase.md 'BeeneticToolkit.Logging.LoggerBase') &#129106; FileLogger

| Constructors | |
| :--- | :--- |
| [FileLogger(string, string, LogThreshold)](FileLogger.FileLogger(string,string,LogThreshold).md 'BeeneticToolkit.Logging.FileLogger.FileLogger(string, string, BeeneticToolkit.Logging.LogThreshold)') | Initializes a new instance of the [FileLogger](FileLogger.md 'BeeneticToolkit.Logging.FileLogger') class. |

| Methods | |
| :--- | :--- |
| [Log(LogSeverity, object, MethodBase, string, string, string)](FileLogger.Log(LogSeverity,object,MethodBase,string,string,string).md 'BeeneticToolkit.Logging.FileLogger.Log(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase, string, string, string)') | Logs a message with additional context from an object and a method, and with the specified severity to the file. |
| [Log(LogSeverity, string, string, string)](FileLogger.Log(LogSeverity,string,string,string).md 'BeeneticToolkit.Logging.FileLogger.Log(BeeneticToolkit.Logging.LogSeverity, string, string, string)') | Logs a message with the specified severity to the file. |
