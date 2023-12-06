#### [MathUtils](index.md 'index')
### [BeeneticToolkit.MathUtils](index.md#BeeneticToolkit.MathUtils 'BeeneticToolkit.MathUtils').[MathUtils](MathUtils.md 'BeeneticToolkit.MathUtils.MathUtils')

## MathUtils.Qerp(double, double, double, double) Method

Performs quadratic Bezier interpolation between two values, influenced by a control point.

```csharp
public static double Qerp(double start, double control, double end, double factor);
```
#### Parameters

<a name='BeeneticToolkit.MathUtils.MathUtils.Qerp(double,double,double,double).start'></a>

`start` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The start value of the interpolation range.

<a name='BeeneticToolkit.MathUtils.MathUtils.Qerp(double,double,double,double).control'></a>

`control` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The control point that influences the shape of the interpolation curve.

<a name='BeeneticToolkit.MathUtils.MathUtils.Qerp(double,double,double,double).end'></a>

`end` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The end value of the interpolation range.

<a name='BeeneticToolkit.MathUtils.MathUtils.Qerp(double,double,double,double).factor'></a>

`factor` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The interpolation factor, typically between 0 and 1. A value of 0 returns the start value, 1 returns the end value, and values in between return a point along the quadratic curve defined by the start, control, and end values.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
The interpolated value along the quadratic Bezier curve defined by the start, control, and end values at the specified factor.