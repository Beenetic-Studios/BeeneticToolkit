#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging](index.md#BeeneticToolkit.Logging 'BeeneticToolkit.Logging').[DebugLogger](DebugLogger.md 'BeeneticToolkit.Logging.DebugLogger')

## DebugLogger.Log(LogSeverity, string) Method

Logs a message with the specified severity to the debug output.

```csharp
public override void Log(BeeneticToolkit.Logging.LogSeverity severity, string message);
```
#### Parameters

<a name='BeeneticToolkit.Logging.DebugLogger.Log(BeeneticToolkit.Logging.LogSeverity,string).severity'></a>

`severity` [LogSeverity](LogSeverity.md 'BeeneticToolkit.Logging.LogSeverity')

The severity level of the log message.

<a name='BeeneticToolkit.Logging.DebugLogger.Log(BeeneticToolkit.Logging.LogSeverity,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The message to be logged.

Implements [Log(LogSeverity, string)](ILogger.Log(LogSeverity,string).md 'BeeneticToolkit.Logging.ILogger.Log(BeeneticToolkit.Logging.LogSeverity, string)')

### Remarks
This method will log the message only if the logger is enabled and the message severity meets or exceeds the logger's threshold level.