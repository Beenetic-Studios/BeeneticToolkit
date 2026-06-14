#### [BeeneticToolkit.Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[NumericalUtils](NumericalUtils.md 'BeeneticToolkit.Numerics.NumericalUtils')

## NumericalUtils.Denormalize(double, double, double) Method

Converts a normalized double value (0 to 1) back to its original range.

```csharp
public static double Denormalize(double normalizedValue, double min, double max);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.NumericalUtils.Denormalize(double,double,double).normalizedValue'></a>

`normalizedValue` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The normalized value (0 to 1).

<a name='BeeneticToolkit.Numerics.NumericalUtils.Denormalize(double,double,double).min'></a>

`min` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The minimum value of the original range.

<a name='BeeneticToolkit.Numerics.NumericalUtils.Denormalize(double,double,double).max'></a>

`max` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The maximum value of the original range.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
The original value within the specified range.

#### Exceptions

[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
Thrown when the normalized value is outside the range 0 to 1.

### Example
  
```csharp  
float value = Denormalize(0.5, 10.0, 20.0); // returns 15.0  
```