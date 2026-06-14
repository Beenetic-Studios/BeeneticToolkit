#### [BeeneticToolkit.Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[InterpolationUtils](InterpolationUtils.md 'BeeneticToolkit.Numerics.InterpolationUtils')

## InterpolationUtils.Qerp(float, float, float, float) Method

Performs quadratic Bezier interpolation between two values, influenced by a control point.

```csharp
public static float Qerp(float start, float control, float end, float factor);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.InterpolationUtils.Qerp(float,float,float,float).start'></a>

`start` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The start value of the interpolation range.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.Qerp(float,float,float,float).control'></a>

`control` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The control point that influences the shape of the interpolation curve.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.Qerp(float,float,float,float).end'></a>

`end` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The end value of the interpolation range.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.Qerp(float,float,float,float).factor'></a>

`factor` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The interpolation factor, typically between 0 and 1. A value of 0 returns the start value, 1 returns the end value, and values in between return a point along the quadratic curve defined by the start, control, and end values.

#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
The interpolated value along the quadratic Bezier curve defined by the start, control, and end values at the specified factor.