#### [BeeneticToolkit.Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[NumericalUtils](NumericalUtils.md 'BeeneticToolkit.Numerics.NumericalUtils')

## NumericalUtils.Normalize(float, float, float) Method

Normalizes a float value to a range defined by a minimum and maximum.

```csharp
public static float Normalize(float value, float min, float max);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.NumericalUtils.Normalize(float,float,float).value'></a>

`value` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The value to normalize.

<a name='BeeneticToolkit.Numerics.NumericalUtils.Normalize(float,float,float).min'></a>

`min` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The minimum value of the range.

<a name='BeeneticToolkit.Numerics.NumericalUtils.Normalize(float,float,float).max'></a>

`max` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The maximum value of the range.

#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
The normalized value, scaled to the range 0 to 1.

#### Exceptions

[System.DivideByZeroException](https://docs.microsoft.com/en-us/dotnet/api/System.DivideByZeroException 'System.DivideByZeroException')  
Thrown when the min and max values are equal.

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when min is greater than max.

### Example
  
```csharp  
float normalized = Normalize(15f, 10f, 20f); // returns 0.5f  
```