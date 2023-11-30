#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging](index.md#BeeneticToolkit.Logging 'BeeneticToolkit.Logging')

## LogSeverity Enum

Defines the severity levels for logging messages.

```csharp
public enum LogSeverity
```
### Fields

<a name='BeeneticToolkit.Logging.LogSeverity.Debug'></a>

`Debug` 2

Debug severity level, used for debugging purposes during development.

<a name='BeeneticToolkit.Logging.LogSeverity.Error'></a>

`Error` 4

Error severity level, used for error events that might still allow the application to continue running.

<a name='BeeneticToolkit.Logging.LogSeverity.Fatal'></a>

`Fatal` 5

Fatal severity level, used for very severe error events that will presumably lead the application to abort.

<a name='BeeneticToolkit.Logging.LogSeverity.Info'></a>

`Info` 1

Informational severity level, used for general informational messages.

<a name='BeeneticToolkit.Logging.LogSeverity.Trace'></a>

`Trace` 0

Trace severity level, used for detailed and systematic logging.

<a name='BeeneticToolkit.Logging.LogSeverity.Warn'></a>

`Warn` 3

Warning severity level, used for potentially harmful situations.