#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging](index.md#BeeneticToolkit.Logging 'BeeneticToolkit.Logging').[ILogger](ILogger.md 'BeeneticToolkit.Logging.ILogger')

## ILogger.Log(LogSeverity, object, MethodBase, string, string, string) Method

Logs a message with additional context from an object and a method, and with the specified severity.

```csharp
void Log(BeeneticToolkit.Logging.LogSeverity severity, object obj, System.Reflection.MethodBase method, string message, string prepend=" ", string append="\n");
```
#### Parameters

<a name='BeeneticToolkit.Logging.ILogger.Log(BeeneticToolkit.Logging.LogSeverity,object,System.Reflection.MethodBase,string,string,string).severity'></a>

`severity` [LogSeverity](LogSeverity.md 'BeeneticToolkit.Logging.LogSeverity')

The severity level of the log message.

<a name='BeeneticToolkit.Logging.ILogger.Log(BeeneticToolkit.Logging.LogSeverity,object,System.Reflection.MethodBase,string,string,string).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object context of the log message.

<a name='BeeneticToolkit.Logging.ILogger.Log(BeeneticToolkit.Logging.LogSeverity,object,System.Reflection.MethodBase,string,string,string).method'></a>

`method` [System.Reflection.MethodBase](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodBase 'System.Reflection.MethodBase')

The method context of the log message.

<a name='BeeneticToolkit.Logging.ILogger.Log(BeeneticToolkit.Logging.LogSeverity,object,System.Reflection.MethodBase,string,string,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The message to be logged.

<a name='BeeneticToolkit.Logging.ILogger.Log(BeeneticToolkit.Logging.LogSeverity,object,System.Reflection.MethodBase,string,string,string).prepend'></a>

`prepend` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

String value to prepend to the message string.

<a name='BeeneticToolkit.Logging.ILogger.Log(BeeneticToolkit.Logging.LogSeverity,object,System.Reflection.MethodBase,string,string,string).append'></a>

`append` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

String value to append to the message string.