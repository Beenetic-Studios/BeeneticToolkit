#### [Diagnostics](index.md 'index')
### [BeeneticToolkit.Diagnostics](index.md#BeeneticToolkit.Diagnostics 'BeeneticToolkit.Diagnostics').[MemoryProfiler](MemoryProfiler.md 'BeeneticToolkit.Diagnostics.MemoryProfiler')

## MemoryProfiler.MeasureMemoryUsage<T>(Func<T>, bool) Method

Measures the change in memory usage before and after a method's execution.

```csharp
public static (long MemoryChange,T Result) MeasureMemoryUsage<T>(System.Func<T> method, bool forceGC=true);
```
#### Type parameters

<a name='BeeneticToolkit.Diagnostics.MemoryProfiler.MeasureMemoryUsage_T_(System.Func_T_,bool).T'></a>

`T`

The return type of the method.
#### Parameters

<a name='BeeneticToolkit.Diagnostics.MemoryProfiler.MeasureMemoryUsage_T_(System.Func_T_,bool).method'></a>

`method` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[T](MemoryProfiler.MeasureMemoryUsage_T_(Func_T_,bool).md#BeeneticToolkit.Diagnostics.MemoryProfiler.MeasureMemoryUsage_T_(System.Func_T_,bool).T 'BeeneticToolkit.Diagnostics.MemoryProfiler.MeasureMemoryUsage<T>(System.Func<T>, bool).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

The method to profile.

<a name='BeeneticToolkit.Diagnostics.MemoryProfiler.MeasureMemoryUsage_T_(System.Func_T_,bool).forceGC'></a>

`forceGC` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates whether garbage collection should be forced before measurement.

#### Returns
[&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[T](MemoryProfiler.MeasureMemoryUsage_T_(Func_T_,bool).md#BeeneticToolkit.Diagnostics.MemoryProfiler.MeasureMemoryUsage_T_(System.Func_T_,bool).T 'BeeneticToolkit.Diagnostics.MemoryProfiler.MeasureMemoryUsage<T>(System.Func<T>, bool).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')  
A tuple containing the memory change in bytes and the method's execution result.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown if the provided method is null.