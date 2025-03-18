#### [Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[NumericalUtils](NumericalUtils.md 'BeeneticToolkit.Numerics.NumericalUtils')

## NumericalUtils.Denormalize(decimal, decimal, decimal) Method

Converts a normalized decimal value (0 to 1) back to its original range.

```csharp
public static decimal Denormalize(decimal normalizedValue, decimal min, decimal max);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.NumericalUtils.Denormalize(decimal,decimal,decimal).normalizedValue'></a>

`normalizedValue` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The normalized value (0 to 1).

<a name='BeeneticToolkit.Numerics.NumericalUtils.Denormalize(decimal,decimal,decimal).min'></a>

`min` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The minimum value of the original range.

<a name='BeeneticToolkit.Numerics.NumericalUtils.Denormalize(decimal,decimal,decimal).max'></a>

`max` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The maximum value of the original range.

#### Returns
[System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')  
The original value within the specified range.

#### Exceptions

[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
Thrown when the normalized value is outside the range 0 to 1.

### Example
  
```csharp  
float value = Denormalize(0.5m, 10m, 20m); // returns 15m  
```