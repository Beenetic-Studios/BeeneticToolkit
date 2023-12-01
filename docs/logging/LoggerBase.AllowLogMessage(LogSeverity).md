#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging](index.md#BeeneticToolkit.Logging 'BeeneticToolkit.Logging').[LoggerBase](LoggerBase.md 'BeeneticToolkit.Logging.LoggerBase')

## LoggerBase.AllowLogMessage(LogSeverity) Method

Evaluates if a log message meets the required severity threshold and checks if the logger is currently enabled.

```csharp
protected bool AllowLogMessage(BeeneticToolkit.Logging.LogSeverity severity);
```
#### Parameters

<a name='BeeneticToolkit.Logging.LoggerBase.AllowLogMessage(BeeneticToolkit.Logging.LogSeverity).severity'></a>

`severity` [LogSeverity](LogSeverity.md 'BeeneticToolkit.Logging.LogSeverity')

The severity of the message.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if the message should be logged, false otherwise.