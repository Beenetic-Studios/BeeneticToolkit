#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging](index.md#BeeneticToolkit.Logging 'BeeneticToolkit.Logging').[FileLogger](FileLogger.md 'BeeneticToolkit.Logging.FileLogger')

## FileLogger(string, string, LogThreshold) Constructor

Initializes a new instance of the [FileLogger](FileLogger.md 'BeeneticToolkit.Logging.FileLogger') class.

```csharp
public FileLogger(string fileName, string? loggerName=null, BeeneticToolkit.Logging.LogThreshold threshold=BeeneticToolkit.Logging.LogThreshold.All);
```
#### Parameters

<a name='BeeneticToolkit.Logging.FileLogger.FileLogger(string,string,BeeneticToolkit.Logging.LogThreshold).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name where logs will be written.

<a name='BeeneticToolkit.Logging.FileLogger.FileLogger(string,string,BeeneticToolkit.Logging.LogThreshold).loggerName'></a>

`loggerName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optional name for the logger.

<a name='BeeneticToolkit.Logging.FileLogger.FileLogger(string,string,BeeneticToolkit.Logging.LogThreshold).threshold'></a>

`threshold` [LogThreshold](LogThreshold.md 'BeeneticToolkit.Logging.LogThreshold')

The threshold level for logging messages. Defaults to LogThreshold.All.