#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging.Loggers](index.md#BeeneticToolkit.Logging.Loggers 'BeeneticToolkit.Logging.Loggers').[ConsoleLogger](ConsoleLogger.md 'BeeneticToolkit.Logging.Loggers.ConsoleLogger')

## ConsoleLogger.Log(LogSeverity, object, MethodBase, string, string, string) Method

Logs a message with additional context from an object and a method, and with the specified severity to the console.

```csharp
public override void Log(BeeneticToolkit.Logging.Enums.LogSeverity severity, object? obj, System.Reflection.MethodBase? method, string message, string prepend=" ", string append="\n");
```
#### Parameters

<a name='BeeneticToolkit.Logging.Loggers.ConsoleLogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity,object,System.Reflection.MethodBase,string,string,string).severity'></a>

`severity` [LogSeverity](LogSeverity.md 'BeeneticToolkit.Logging.Enums.LogSeverity')

The severity level of the log message.

<a name='BeeneticToolkit.Logging.Loggers.ConsoleLogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity,object,System.Reflection.MethodBase,string,string,string).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object context of the log message.

<a name='BeeneticToolkit.Logging.Loggers.ConsoleLogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity,object,System.Reflection.MethodBase,string,string,string).method'></a>

`method` [System.Reflection.MethodBase](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodBase 'System.Reflection.MethodBase')

The method context of the log message.

<a name='BeeneticToolkit.Logging.Loggers.ConsoleLogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity,object,System.Reflection.MethodBase,string,string,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The message to be logged.

<a name='BeeneticToolkit.Logging.Loggers.ConsoleLogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity,object,System.Reflection.MethodBase,string,string,string).prepend'></a>

`prepend` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

String value to prepend to the message string.

<a name='BeeneticToolkit.Logging.Loggers.ConsoleLogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity,object,System.Reflection.MethodBase,string,string,string).append'></a>

`append` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

String value to append to the message string.

Implements [Log(LogSeverity, object, MethodBase, string, string, string)](ILogger.Log(LogSeverity,object,MethodBase,string,string,string).md 'BeeneticToolkit.Logging.ILogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity, object, System.Reflection.MethodBase, string, string, string)')

### Remarks
This method will log the message only if the logger is enabled and the message severity meets or exceeds the logger's threshold level.  
If either [obj](ConsoleLogger.Log(LogSeverity,object,MethodBase,string,string,string).md#BeeneticToolkit.Logging.Loggers.ConsoleLogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity,object,System.Reflection.MethodBase,string,string,string).obj 'BeeneticToolkit.Logging.Loggers.ConsoleLogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity, object, System.Reflection.MethodBase, string, string, string).obj') or [method](ConsoleLogger.Log(LogSeverity,object,MethodBase,string,string,string).md#BeeneticToolkit.Logging.Loggers.ConsoleLogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity,object,System.Reflection.MethodBase,string,string,string).method 'BeeneticToolkit.Logging.Loggers.ConsoleLogger.Log(BeeneticToolkit.Logging.Enums.LogSeverity, object, System.Reflection.MethodBase, string, string, string).method') is null, 'UnknownObject' or 'UnknownMethod' will be used respectively.