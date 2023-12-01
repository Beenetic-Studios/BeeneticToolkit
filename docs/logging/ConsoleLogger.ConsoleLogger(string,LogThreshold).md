#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging](index.md#BeeneticToolkit.Logging 'BeeneticToolkit.Logging').[ConsoleLogger](ConsoleLogger.md 'BeeneticToolkit.Logging.ConsoleLogger')

## ConsoleLogger(string, LogThreshold) Constructor

Initializes a new instance of the [ConsoleLogger](ConsoleLogger.md 'BeeneticToolkit.Logging.ConsoleLogger') class.

```csharp
public ConsoleLogger(string? loggerName=null, BeeneticToolkit.Logging.LogThreshold threshold=BeeneticToolkit.Logging.LogThreshold.All);
```
#### Parameters

<a name='BeeneticToolkit.Logging.ConsoleLogger.ConsoleLogger(string,BeeneticToolkit.Logging.LogThreshold).loggerName'></a>

`loggerName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optional name for the logger.

<a name='BeeneticToolkit.Logging.ConsoleLogger.ConsoleLogger(string,BeeneticToolkit.Logging.LogThreshold).threshold'></a>

`threshold` [LogThreshold](LogThreshold.md 'BeeneticToolkit.Logging.LogThreshold')

The threshold level for logging messages. Defaults to LogThreshold.All.