#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging](index.md#BeeneticToolkit.Logging 'BeeneticToolkit.Logging').[LoggerBase](LoggerBase.md 'BeeneticToolkit.Logging.LoggerBase')

## LoggerBase.Log(LogSeverity, object, MethodBase, string) Method

Logs a message with additional context and the specified severity.

```csharp
public abstract void Log(BeeneticToolkit.Logging.LogSeverity severity, object? obj, System.Reflection.MethodBase? method, string message);
```
#### Parameters

<a name='BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.LogSeverity,object,System.Reflection.MethodBase,string).severity'></a>

`severity` [LogSeverity](LogSeverity.md 'BeeneticToolkit.Logging.LogSeverity')

The severity level of the log message.

<a name='BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.LogSeverity,object,System.Reflection.MethodBase,string).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object context for the log message.

<a name='BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.LogSeverity,object,System.Reflection.MethodBase,string).method'></a>

`method` [System.Reflection.MethodBase](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodBase 'System.Reflection.MethodBase')

The method context for the log message.

<a name='BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.LogSeverity,object,System.Reflection.MethodBase,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The message to log.

Implements [Log(LogSeverity, object, MethodBase, string)](ILogger.Log(LogSeverity,object,MethodBase,string).md 'BeeneticToolkit.Logging.ILogger.Log(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase, string)')