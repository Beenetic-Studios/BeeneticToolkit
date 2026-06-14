#### [Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[NumericalUtils](NumericalUtils.md 'BeeneticToolkit.Numerics.NumericalUtils')

## NumericalUtils.IsApproximatelyRelative(decimal, decimal, decimal) Method

Determines whether two decimal values are approximately equal using a tolerance scaled to their magnitude.

```csharp
public static bool IsApproximatelyRelative(decimal value, decimal other, decimal relativeTolerance=0.000001m);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.NumericalUtils.IsApproximatelyRelative(decimal,decimal,decimal).value'></a>

`value` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The first value to compare.

<a name='BeeneticToolkit.Numerics.NumericalUtils.IsApproximatelyRelative(decimal,decimal,decimal).other'></a>

`other` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The second value to compare.

<a name='BeeneticToolkit.Numerics.NumericalUtils.IsApproximatelyRelative(decimal,decimal,decimal).relativeTolerance'></a>

`relativeTolerance` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The relative tolerance (fraction of the larger magnitude).

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the values are approximately equal; otherwise `false`.