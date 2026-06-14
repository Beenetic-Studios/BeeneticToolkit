#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging](index.md#BeeneticToolkit.Logging 'BeeneticToolkit.Logging').[LoggerBase](LoggerBase.md 'BeeneticToolkit.Logging.LoggerBase')

## LoggerBase.Log(LogSeverity, object, string, string, string, string) Method

Logs a message with additional context from an object and a method name, using the specified severity.

```csharp
public virtual void Log(BeeneticToolkit.Logging.Enums.LogSeverity severity, object? obj, string methodName, string message, string prepend=" ", string append="\n");
```
#### Parameters

<a name='BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.Enums.LogSeverity,object,string,string,string,string).severity'></a>

`severity` [LogSeverity](LogSeverity.md 'BeeneticToolkit.Logging.Enums.LogSeverity')

The severity level of the log message.

<a name='BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.Enums.LogSeverity,object,string,string,string,string).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object context for the log message.

<a name='BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.Enums.LogSeverity,object,string,string,string,string).methodName'></a>

`methodName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the method associated with the log message.

<a name='BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.Enums.LogSeverity,object,string,string,string,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The message to log.

<a name='BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.Enums.LogSeverity,object,string,string,string,string).prepend'></a>

`prepend` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

String value to prepend to the message string.

<a name='BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.Enums.LogSeverity,object,string,string,string,string).append'></a>

`append` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

String value to append to the message string.

### Remarks
The default implementation forwards the call to the [Log(LogSeverity, object, MethodBase, string, string, string)](LoggerBase.Log(LogSeverity,object,MethodBase,string,string,string).md 'BeeneticToolkit.Logging.LoggerBase.Log(BeeneticToolkit.Logging.Enums.LogSeverity, object, System.Reflection.MethodBase, string, string, string)')  
overload with a `null` method reference, preserving the object context but not the method name.  
Derived loggers can override this method to support explicit method-name logging.