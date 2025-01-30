#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging.Loggers](index.md#BeeneticToolkit.Logging.Loggers 'BeeneticToolkit.Logging.Loggers').[ConsoleLogger](ConsoleLogger.md 'BeeneticToolkit.Logging.Loggers.ConsoleLogger')

## ConsoleLogger(string, LogThreshold) Constructor

Initializes a new instance of the [ConsoleLogger](ConsoleLogger.md 'BeeneticToolkit.Logging.Loggers.ConsoleLogger') class.

```csharp
public ConsoleLogger(string? loggerName=null, BeeneticToolkit.Logging.Enums.LogThreshold threshold=BeeneticToolkit.Logging.Enums.LogThreshold.All);
```
#### Parameters

<a name='BeeneticToolkit.Logging.Loggers.ConsoleLogger.ConsoleLogger(string,BeeneticToolkit.Logging.Enums.LogThreshold).loggerName'></a>

`loggerName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optional name for the logger.

<a name='BeeneticToolkit.Logging.Loggers.ConsoleLogger.ConsoleLogger(string,BeeneticToolkit.Logging.Enums.LogThreshold).threshold'></a>

`threshold` [LogThreshold](LogThreshold.md 'BeeneticToolkit.Logging.Enums.LogThreshold')

The threshold level for logging messages. Defaults to LogThreshold.All.