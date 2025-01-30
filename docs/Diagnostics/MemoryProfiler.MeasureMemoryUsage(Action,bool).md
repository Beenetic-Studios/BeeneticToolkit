#### [Diagnostics](index.md 'index')
### [BeeneticToolkit.Diagnostics](index.md#BeeneticToolkit.Diagnostics 'BeeneticToolkit.Diagnostics').[MemoryProfiler](MemoryProfiler.md 'BeeneticToolkit.Diagnostics.MemoryProfiler')

## MemoryProfiler.MeasureMemoryUsage(Action, bool) Method

Measures the change in memory usage before and after a method's execution (void method).

```csharp
public static long MeasureMemoryUsage(System.Action method, bool forceGC=true);
```
#### Parameters

<a name='BeeneticToolkit.Diagnostics.MemoryProfiler.MeasureMemoryUsage(System.Action,bool).method'></a>

`method` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

The method to profile.

<a name='BeeneticToolkit.Diagnostics.MemoryProfiler.MeasureMemoryUsage(System.Action,bool).forceGC'></a>

`forceGC` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates whether garbage collection should be forced before measurement.

#### Returns
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
The change in memory usage in bytes.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown if the provided method is null.