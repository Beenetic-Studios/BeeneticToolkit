#### [BeeneticToolkit.Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[NumericalUtils](NumericalUtils.md 'BeeneticToolkit.Numerics.NumericalUtils')

## NumericalUtils.IsApproximately(decimal, decimal, decimal) Method

Determines if two decimal values are approximately equal within a tolerance.

```csharp
public static bool IsApproximately(decimal value, decimal other, decimal tolerance=0.0001m);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.NumericalUtils.IsApproximately(decimal,decimal,decimal).value'></a>

`value` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The first value to compare.

<a name='BeeneticToolkit.Numerics.NumericalUtils.IsApproximately(decimal,decimal,decimal).other'></a>

`other` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The second value to compare.

<a name='BeeneticToolkit.Numerics.NumericalUtils.IsApproximately(decimal,decimal,decimal).tolerance'></a>

`tolerance` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The tolerance for comparison.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if the values are approximately equal; otherwise, false.