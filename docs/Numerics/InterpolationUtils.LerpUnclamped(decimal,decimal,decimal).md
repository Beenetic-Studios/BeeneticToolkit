#### [BeeneticToolkit.Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[InterpolationUtils](InterpolationUtils.md 'BeeneticToolkit.Numerics.InterpolationUtils')

## InterpolationUtils.LerpUnclamped(decimal, decimal, decimal) Method

Performs linear interpolation between two values without clamping the factor, allowing extrapolation.

```csharp
public static decimal LerpUnclamped(decimal start, decimal end, decimal factor);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.InterpolationUtils.LerpUnclamped(decimal,decimal,decimal).start'></a>

`start` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The start value.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.LerpUnclamped(decimal,decimal,decimal).end'></a>

`end` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The end value.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.LerpUnclamped(decimal,decimal,decimal).factor'></a>

`factor` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The interpolation factor. Values outside [0, 1] extrapolate beyond the endpoints.

#### Returns
[System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')  
The (possibly extrapolated) interpolated value.