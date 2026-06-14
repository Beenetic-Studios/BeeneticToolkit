#### [BeeneticToolkit.Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[NumericalUtils](NumericalUtils.md 'BeeneticToolkit.Numerics.NumericalUtils')

## NumericalUtils.Denormalize(float, float, float) Method

Converts a normalized float value (0 to 1) back to its original range.

```csharp
public static float Denormalize(float normalizedValue, float min, float max);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.NumericalUtils.Denormalize(float,float,float).normalizedValue'></a>

`normalizedValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The normalized value (0 to 1).

<a name='BeeneticToolkit.Numerics.NumericalUtils.Denormalize(float,float,float).min'></a>

`min` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The minimum value of the original range.

<a name='BeeneticToolkit.Numerics.NumericalUtils.Denormalize(float,float,float).max'></a>

`max` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The maximum value of the original range.

#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
The original value within the specified range.

#### Exceptions

[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
Thrown when the normalized value is outside the range 0 to 1.

### Example
  
```csharp  
float value = Denormalize(0.5f, 10f, 20f); // returns 15f  
```