#### [Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[InterpolationUtils](InterpolationUtils.md 'BeeneticToolkit.Numerics.InterpolationUtils')

## InterpolationUtils.LerpUnclamped(double, double, double) Method

Performs linear interpolation between two values without clamping the factor, allowing extrapolation.

```csharp
public static double LerpUnclamped(double start, double end, double factor);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.InterpolationUtils.LerpUnclamped(double,double,double).start'></a>

`start` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The start value.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.LerpUnclamped(double,double,double).end'></a>

`end` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The end value.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.LerpUnclamped(double,double,double).factor'></a>

`factor` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The interpolation factor. Values outside [0, 1] extrapolate beyond the endpoints.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
The (possibly extrapolated) interpolated value.