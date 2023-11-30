#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging](index.md#BeeneticToolkit.Logging 'BeeneticToolkit.Logging').[LogManager](LogManager.md 'BeeneticToolkit.Logging.LogManager')

## LogManager.AddLogger(LoggerBase) Method

Adds a logger to the LogManager and enables fluent configuration.

```csharp
public BeeneticToolkit.Logging.LogManager AddLogger(BeeneticToolkit.Logging.LoggerBase logger);
```
#### Parameters

<a name='BeeneticToolkit.Logging.LogManager.AddLogger(BeeneticToolkit.Logging.LoggerBase).logger'></a>

`logger` [LoggerBase](LoggerBase.md 'BeeneticToolkit.Logging.LoggerBase')

The logger to be added. Must not be null.

#### Returns
[LogManager](LogManager.md 'BeeneticToolkit.Logging.LogManager')  
The [LogManager](LogManager.md 'BeeneticToolkit.Logging.LogManager') instance to allow for method chaining.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when the provided logger is null.

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when a logger with the same name already exists.