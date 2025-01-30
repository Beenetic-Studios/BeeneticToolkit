#### [Diagnostics](index.md 'index')
### [BeeneticToolkit.Diagnostics](index.md#BeeneticToolkit.Diagnostics 'BeeneticToolkit.Diagnostics').[ExecutionTimer](ExecutionTimer.md 'BeeneticToolkit.Diagnostics.ExecutionTimer')

## ExecutionTimer.MeasureExecutionTime(Action) Method

Measures the execution time of a method that does not return a result.

```csharp
public static System.TimeSpan MeasureExecutionTime(System.Action method);
```
#### Parameters

<a name='BeeneticToolkit.Diagnostics.ExecutionTimer.MeasureExecutionTime(System.Action).method'></a>

`method` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

The method to measure.

#### Returns
[System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')  
The elapsed time of the method's execution.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown if the provided method is null.