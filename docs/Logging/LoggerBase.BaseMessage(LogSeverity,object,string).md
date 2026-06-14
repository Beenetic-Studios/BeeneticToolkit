#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging](index.md#BeeneticToolkit.Logging 'BeeneticToolkit.Logging').[LoggerBase](LoggerBase.md 'BeeneticToolkit.Logging.LoggerBase')

## LoggerBase.BaseMessage(LogSeverity, object, string) Method

Generates a base message string including the current time, log level, and optionally the object and method-name context.

```csharp
protected string BaseMessage(BeeneticToolkit.Logging.Enums.LogSeverity severity, object? obj, string? methodName="");
```
#### Parameters

<a name='BeeneticToolkit.Logging.LoggerBase.BaseMessage(BeeneticToolkit.Logging.Enums.LogSeverity,object,string).severity'></a>

`severity` [LogSeverity](LogSeverity.md 'BeeneticToolkit.Logging.Enums.LogSeverity')

The severity level of the log message.

<a name='BeeneticToolkit.Logging.LoggerBase.BaseMessage(BeeneticToolkit.Logging.Enums.LogSeverity,object,string).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object context for the log message, optional. If null, object-related context is omitted.

<a name='BeeneticToolkit.Logging.LoggerBase.BaseMessage(BeeneticToolkit.Logging.Enums.LogSeverity,object,string).methodName'></a>

`methodName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the method context for the log message, optional. If null, method-related context is omitted.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The formatted base message string.

### Remarks
This overload is intended for scenarios where only a method name string is available rather than a [System.Reflection.MethodBase](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodBase 'System.Reflection.MethodBase') instance.  
Included components are controlled by [Includes](LoggerBase.Includes.md 'BeeneticToolkit.Logging.LoggerBase.Includes').