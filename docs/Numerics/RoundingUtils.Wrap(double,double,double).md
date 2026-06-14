#### [Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[RoundingUtils](RoundingUtils.md 'BeeneticToolkit.Numerics.RoundingUtils')

## RoundingUtils.Wrap(double, double, double) Method

Wraps a value within a specified range.

```csharp
public static double Wrap(double value, double min, double max);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.RoundingUtils.Wrap(double,double,double).value'></a>

`value` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The value to wrap.

<a name='BeeneticToolkit.Numerics.RoundingUtils.Wrap(double,double,double).min'></a>

`min` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The minimum value of the range.

<a name='BeeneticToolkit.Numerics.RoundingUtils.Wrap(double,double,double).max'></a>

`max` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The maximum value of the range.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
The wrapped value, in the half-open range `[, )`.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [max](RoundingUtils.Wrap(double,double,double).md#BeeneticToolkit.Numerics.RoundingUtils.Wrap(double,double,double).max 'BeeneticToolkit.Numerics.RoundingUtils.Wrap(double, double, double).max') is not greater than [min](RoundingUtils.Wrap(double,double,double).md#BeeneticToolkit.Numerics.RoundingUtils.Wrap(double,double,double).min 'BeeneticToolkit.Numerics.RoundingUtils.Wrap(double, double, double).min').