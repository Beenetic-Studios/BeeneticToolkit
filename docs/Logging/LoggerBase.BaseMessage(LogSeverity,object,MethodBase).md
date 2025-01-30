#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging](index.md#BeeneticToolkit.Logging 'BeeneticToolkit.Logging').[LoggerBase](LoggerBase.md 'BeeneticToolkit.Logging.LoggerBase')

## LoggerBase.BaseMessage(LogSeverity, object, MethodBase) Method

Generates a base message string including the current time, log level, and optionally the object and method context.

```csharp
protected string BaseMessage(BeeneticToolkit.Logging.Enums.LogSeverity severity, object? obj=null, System.Reflection.MethodBase? method=null);
```
#### Parameters

<a name='BeeneticToolkit.Logging.LoggerBase.BaseMessage(BeeneticToolkit.Logging.Enums.LogSeverity,object,System.Reflection.MethodBase).severity'></a>

`severity` [LogSeverity](LogSeverity.md 'BeeneticToolkit.Logging.Enums.LogSeverity')

The severity level of the log message.

<a name='BeeneticToolkit.Logging.LoggerBase.BaseMessage(BeeneticToolkit.Logging.Enums.LogSeverity,object,System.Reflection.MethodBase).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object context for the log message, optional. If null, 'UnknownObject' is used.

<a name='BeeneticToolkit.Logging.LoggerBase.BaseMessage(BeeneticToolkit.Logging.Enums.LogSeverity,object,System.Reflection.MethodBase).method'></a>

`method` [System.Reflection.MethodBase](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodBase 'System.Reflection.MethodBase')

The method context for the log message, optional. If null, 'UnknownMethod' is used.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The formatted base message string.

### Remarks
The method context information will be included only if both [obj](LoggerBase.BaseMessage(LogSeverity,object,MethodBase).md#BeeneticToolkit.Logging.LoggerBase.BaseMessage(BeeneticToolkit.Logging.Enums.LogSeverity,object,System.Reflection.MethodBase).obj 'BeeneticToolkit.Logging.LoggerBase.BaseMessage(BeeneticToolkit.Logging.Enums.LogSeverity, object, System.Reflection.MethodBase).obj')  
and [method](LoggerBase.BaseMessage(LogSeverity,object,MethodBase).md#BeeneticToolkit.Logging.LoggerBase.BaseMessage(BeeneticToolkit.Logging.Enums.LogSeverity,object,System.Reflection.MethodBase).method 'BeeneticToolkit.Logging.LoggerBase.BaseMessage(BeeneticToolkit.Logging.Enums.LogSeverity, object, System.Reflection.MethodBase).method') are provided.