#### [Diagnostics](index.md 'index')
### [BeeneticToolkit.Diagnostics](index.md#BeeneticToolkit.Diagnostics 'BeeneticToolkit.Diagnostics').[ExecutionTimer](ExecutionTimer.md 'BeeneticToolkit.Diagnostics.ExecutionTimer')

## ExecutionTimer.MeasureExecutionTime<T>(Func<T>) Method

Measures the execution time of a method that returns a result.

```csharp
public static (T Result,System.TimeSpan ElapsedTime) MeasureExecutionTime<T>(System.Func<T> method);
```
#### Type parameters

<a name='BeeneticToolkit.Diagnostics.ExecutionTimer.MeasureExecutionTime_T_(System.Func_T_).T'></a>

`T`

The return type of the method.
#### Parameters

<a name='BeeneticToolkit.Diagnostics.ExecutionTimer.MeasureExecutionTime_T_(System.Func_T_).method'></a>

`method` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[T](ExecutionTimer.MeasureExecutionTime_T_(Func_T_).md#BeeneticToolkit.Diagnostics.ExecutionTimer.MeasureExecutionTime_T_(System.Func_T_).T 'BeeneticToolkit.Diagnostics.ExecutionTimer.MeasureExecutionTime<T>(System.Func<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

The method to measure.

#### Returns
[&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[T](ExecutionTimer.MeasureExecutionTime_T_(Func_T_).md#BeeneticToolkit.Diagnostics.ExecutionTimer.MeasureExecutionTime_T_(System.Func_T_).T 'BeeneticToolkit.Diagnostics.ExecutionTimer.MeasureExecutionTime<T>(System.Func<T>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')  
A tuple containing the method's result and the elapsed time.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown if the provided method is null.