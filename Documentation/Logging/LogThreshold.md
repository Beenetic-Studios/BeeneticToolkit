#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging](index.md#BeeneticToolkit.Logging 'BeeneticToolkit.Logging')

## LogThreshold Enum

Defines the threshold levels for logging, determining which messages should be logged based on their severity.

```csharp
public enum LogThreshold
```
### Fields

<a name='BeeneticToolkit.Logging.LogThreshold.All'></a>

`All` 0

All logging levels are enabled. Every log message regardless of severity will be logged.

<a name='BeeneticToolkit.Logging.LogThreshold.Debug'></a>

`Debug` 2

Debug and higher severity levels are enabled. This includes Debug, Warn, Error, and Fatal.

<a name='BeeneticToolkit.Logging.LogThreshold.Error'></a>

`Error` 4

Error and Fatal severity levels are enabled.

<a name='BeeneticToolkit.Logging.LogThreshold.Fatal'></a>

`Fatal` 5

Only Fatal severity level is enabled.

<a name='BeeneticToolkit.Logging.LogThreshold.Info'></a>

`Info` 1

Informational and higher severity levels are enabled. This includes Info, Debug, Warn, Error, and Fatal.

<a name='BeeneticToolkit.Logging.LogThreshold.Off'></a>

`Off` 6

Logging is disabled. No log messages will be recorded.

<a name='BeeneticToolkit.Logging.LogThreshold.Warn'></a>

`Warn` 3

Warning and higher severity levels are enabled. This includes Warn, Error, and Fatal.