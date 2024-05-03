#### [MathUtils](index.md 'index')
### [BeeneticToolkit.MathUtils](index.md#BeeneticToolkit.MathUtils 'BeeneticToolkit.MathUtils').[MathUtils](MathUtils.md 'BeeneticToolkit.MathUtils.MathUtils')

## MathUtils.Lerp(decimal, decimal, decimal) Method

Performs linear interpolation between two decimal values based on a given interpolation factor.

```csharp
public static decimal Lerp(decimal start, decimal end, decimal factor);
```
#### Parameters

<a name='BeeneticToolkit.MathUtils.MathUtils.Lerp(decimal,decimal,decimal).start'></a>

`start` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The start value.

<a name='BeeneticToolkit.MathUtils.MathUtils.Lerp(decimal,decimal,decimal).end'></a>

`end` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The end value.

<a name='BeeneticToolkit.MathUtils.MathUtils.Lerp(decimal,decimal,decimal).factor'></a>

`factor` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The interpolation factor, typically between 0 and 1. Values outside this range are clamped to the range [0, 1].

#### Returns
[System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')  
The interpolated decimal value between the start and end values.