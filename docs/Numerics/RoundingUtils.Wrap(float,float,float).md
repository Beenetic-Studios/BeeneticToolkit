#### [Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[RoundingUtils](RoundingUtils.md 'BeeneticToolkit.Numerics.RoundingUtils')

## RoundingUtils.Wrap(float, float, float) Method

Wraps a value within a specified range.

```csharp
public static float Wrap(float value, float min, float max);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.RoundingUtils.Wrap(float,float,float).value'></a>

`value` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The value to wrap.

<a name='BeeneticToolkit.Numerics.RoundingUtils.Wrap(float,float,float).min'></a>

`min` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The minimum value of the range.

<a name='BeeneticToolkit.Numerics.RoundingUtils.Wrap(float,float,float).max'></a>

`max` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The maximum value of the range.

#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
The wrapped value, in the half-open range `[, )`.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [max](RoundingUtils.Wrap(float,float,float).md#BeeneticToolkit.Numerics.RoundingUtils.Wrap(float,float,float).max 'BeeneticToolkit.Numerics.RoundingUtils.Wrap(float, float, float).max') is not greater than [min](RoundingUtils.Wrap(float,float,float).md#BeeneticToolkit.Numerics.RoundingUtils.Wrap(float,float,float).min 'BeeneticToolkit.Numerics.RoundingUtils.Wrap(float, float, float).min').