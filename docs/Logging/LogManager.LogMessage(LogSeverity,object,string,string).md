#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging](index.md#BeeneticToolkit.Logging 'BeeneticToolkit.Logging').[LogManager](LogManager.md 'BeeneticToolkit.Logging.LogManager')

## LogManager.LogMessage(LogSeverity, object, string, string) Method

Logs a message with additional context from an object and a method name, using the specified severity.

```csharp
public void LogMessage(BeeneticToolkit.Logging.Enums.LogSeverity severity, object? obj, string methodName, string message);
```
#### Parameters

<a name='BeeneticToolkit.Logging.LogManager.LogMessage(BeeneticToolkit.Logging.Enums.LogSeverity,object,string,string).severity'></a>

`severity` [LogSeverity](LogSeverity.md 'BeeneticToolkit.Logging.Enums.LogSeverity')

The severity of the log message.

<a name='BeeneticToolkit.Logging.LogManager.LogMessage(BeeneticToolkit.Logging.Enums.LogSeverity,object,string,string).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object context of the log message.

<a name='BeeneticToolkit.Logging.LogManager.LogMessage(BeeneticToolkit.Logging.Enums.LogSeverity,object,string,string).methodName'></a>

`methodName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the method associated with the log message.

<a name='BeeneticToolkit.Logging.LogManager.LogMessage(BeeneticToolkit.Logging.Enums.LogSeverity,object,string,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The message to be logged.