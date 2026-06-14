#### [BeeneticToolkit.Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[NumericalUtils](NumericalUtils.md 'BeeneticToolkit.Numerics.NumericalUtils')

## NumericalUtils.Normalize(decimal, decimal, decimal) Method

Normalizes a decimal value to a range defined by a minimum and maximum.

```csharp
public static decimal Normalize(decimal value, decimal min, decimal max);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.NumericalUtils.Normalize(decimal,decimal,decimal).value'></a>

`value` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The value to normalize.

<a name='BeeneticToolkit.Numerics.NumericalUtils.Normalize(decimal,decimal,decimal).min'></a>

`min` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The minimum value of the range.

<a name='BeeneticToolkit.Numerics.NumericalUtils.Normalize(decimal,decimal,decimal).max'></a>

`max` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The maximum value of the range.

#### Returns
[System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')  
The normalized value, scaled to the range 0 to 1.

#### Exceptions

[System.DivideByZeroException](https://docs.microsoft.com/en-us/dotnet/api/System.DivideByZeroException 'System.DivideByZeroException')  
Thrown when the min and max values are equal.

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when min is greater than max.

### Example
  
```csharp  
decimal normalized = Normalize(300m, 200m, 400m); // returns 0.5m  
```