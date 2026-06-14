#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging](index.md#BeeneticToolkit.Logging 'BeeneticToolkit.Logging').[LoggerBase](LoggerBase.md 'BeeneticToolkit.Logging.LoggerBase')

## LoggerBase.Log(LogSeverity, string, string, string) Method

Logs a message with the specified severity.

```csharp
public abstract void Log(BeeneticToolkit.Logging.Enums.LogSeverity severity, string message, string prepend=" ", string append="\n");
```
#### Parameters

<a name='BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.Enums.LogSeverity,string,string,string).severity'></a>

`severity` [LogSeverity](LogSeverity.md 'BeeneticToolkit.Logging.Enums.LogSeverity')

The severity level of the log message.

<a name='BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.Enums.LogSeverity,string,string,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The message to log.

<a name='BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.Enums.LogSeverity,string,string,string).prepend'></a>

`prepend` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

String value to prepend to the message string.

<a name='BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.Enums.LogSeverity,string,string,string).append'></a>

`append` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

String value to append to the message string.

Implements [Log(LogSeverity, string, string, string)](IBeeneticLogger.Log(LogSeverity,string,string,string).md 'BeeneticToolkit.Logging.IBeeneticLogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity, string, string, string)')