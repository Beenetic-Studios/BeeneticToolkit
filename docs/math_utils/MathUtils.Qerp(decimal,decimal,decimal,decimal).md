#### [MathUtils](index.md 'index')
### [BeeneticToolkit.MathUtils](index.md#BeeneticToolkit.MathUtils 'BeeneticToolkit.MathUtils').[MathUtils](MathUtils.md 'BeeneticToolkit.MathUtils.MathUtils')

## MathUtils.Qerp(decimal, decimal, decimal, decimal) Method

Performs quadratic Bezier interpolation between two values, influenced by a control point.

```csharp
public static decimal Qerp(decimal start, decimal control, decimal end, decimal factor);
```
#### Parameters

<a name='BeeneticToolkit.MathUtils.MathUtils.Qerp(decimal,decimal,decimal,decimal).start'></a>

`start` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The start value of the interpolation range.

<a name='BeeneticToolkit.MathUtils.MathUtils.Qerp(decimal,decimal,decimal,decimal).control'></a>

`control` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The control point that influences the shape of the interpolation curve.

<a name='BeeneticToolkit.MathUtils.MathUtils.Qerp(decimal,decimal,decimal,decimal).end'></a>

`end` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The end value of the interpolation range.

<a name='BeeneticToolkit.MathUtils.MathUtils.Qerp(decimal,decimal,decimal,decimal).factor'></a>

`factor` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The interpolation factor, typically between 0 and 1. A value of 0 returns the start value, 1 returns the end value, and values in between return a point along the quadratic curve defined by the start, control, and end values.

#### Returns
[System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')  
The interpolated value along the quadratic Bezier curve defined by the start, control, and end values at the specified factor.