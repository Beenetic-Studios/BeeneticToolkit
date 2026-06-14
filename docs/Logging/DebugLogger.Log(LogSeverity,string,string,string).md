#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging.Loggers](index.md#BeeneticToolkit.Logging.Loggers 'BeeneticToolkit.Logging.Loggers').[DebugLogger](DebugLogger.md 'BeeneticToolkit.Logging.Loggers.DebugLogger')

## DebugLogger.Log(LogSeverity, string, string, string) Method

Logs a message with the specified severity to the debug output.

```csharp
public override void Log(BeeneticToolkit.Logging.Enums.LogSeverity severity, string message, string prepend=" ", string append="\n");
```
#### Parameters

<a name='BeeneticToolkit.Logging.Loggers.DebugLogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity,string,string,string).severity'></a>

`severity` [LogSeverity](LogSeverity.md 'BeeneticToolkit.Logging.Enums.LogSeverity')

The severity level of the log message.

<a name='BeeneticToolkit.Logging.Loggers.DebugLogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity,string,string,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The message to be logged.

<a name='BeeneticToolkit.Logging.Loggers.DebugLogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity,string,string,string).prepend'></a>

`prepend` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

String value to prepend to the message string.

<a name='BeeneticToolkit.Logging.Loggers.DebugLogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity,string,string,string).append'></a>

`append` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

String value to append to the message string.

Implements [Log(LogSeverity, string, string, string)](IBeeneticLogger.Log(LogSeverity,string,string,string).md 'BeeneticToolkit.Logging.IBeeneticLogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity, string, string, string)')

### Remarks
This method will log the message only if the logger is enabled and the message severity meets or exceeds the logger's threshold level.