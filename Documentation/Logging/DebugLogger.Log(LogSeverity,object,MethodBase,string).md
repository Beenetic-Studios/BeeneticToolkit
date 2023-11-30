#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging](index.md#BeeneticToolkit.Logging 'BeeneticToolkit.Logging').[DebugLogger](DebugLogger.md 'BeeneticToolkit.Logging.DebugLogger')

## DebugLogger.Log(LogSeverity, object, MethodBase, string) Method

Logs a message with additional context from an object and a method, and with the specified severity to the debug output.

```csharp
public override void Log(BeeneticToolkit.Logging.LogSeverity severity, object? obj, System.Reflection.MethodBase? method, string message);
```
#### Parameters

<a name='BeeneticToolkit.Logging.DebugLogger.Log(BeeneticToolkit.Logging.LogSeverity,object,System.Reflection.MethodBase,string).severity'></a>

`severity` [LogSeverity](LogSeverity.md 'BeeneticToolkit.Logging.LogSeverity')

The severity level of the log message.

<a name='BeeneticToolkit.Logging.DebugLogger.Log(BeeneticToolkit.Logging.LogSeverity,object,System.Reflection.MethodBase,string).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object context of the log message.

<a name='BeeneticToolkit.Logging.DebugLogger.Log(BeeneticToolkit.Logging.LogSeverity,object,System.Reflection.MethodBase,string).method'></a>

`method` [System.Reflection.MethodBase](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodBase 'System.Reflection.MethodBase')

The method context of the log message.

<a name='BeeneticToolkit.Logging.DebugLogger.Log(BeeneticToolkit.Logging.LogSeverity,object,System.Reflection.MethodBase,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The message to be logged.

Implements [Log(LogSeverity, object, MethodBase, string)](ILogger.Log(LogSeverity,object,MethodBase,string).md 'BeeneticToolkit.Logging.ILogger.Log(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase, string)')

### Remarks
This method will log the message only if the logger is enabled and the message severity meets or exceeds the logger's threshold level.  
If either [obj](DebugLogger.Log(LogSeverity,object,MethodBase,string).md#BeeneticToolkit.Logging.DebugLogger.Log(BeeneticToolkit.Logging.LogSeverity,object,System.Reflection.MethodBase,string).obj 'BeeneticToolkit.Logging.DebugLogger.Log(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase, string).obj') or [method](DebugLogger.Log(LogSeverity,object,MethodBase,string).md#BeeneticToolkit.Logging.DebugLogger.Log(BeeneticToolkit.Logging.LogSeverity,object,System.Reflection.MethodBase,string).method 'BeeneticToolkit.Logging.DebugLogger.Log(BeeneticToolkit.Logging.LogSeverity, object, System.Reflection.MethodBase, string).method') is null, 'UnknownObject' or 'UnknownMethod' will be used respectively.