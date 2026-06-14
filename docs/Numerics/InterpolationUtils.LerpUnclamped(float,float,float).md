#### [BeeneticToolkit.Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[InterpolationUtils](InterpolationUtils.md 'BeeneticToolkit.Numerics.InterpolationUtils')

## InterpolationUtils.LerpUnclamped(float, float, float) Method

Performs linear interpolation between two values without clamping the factor, allowing extrapolation.

```csharp
public static float LerpUnclamped(float start, float end, float factor);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.InterpolationUtils.LerpUnclamped(float,float,float).start'></a>

`start` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The start value.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.LerpUnclamped(float,float,float).end'></a>

`end` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The end value.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.LerpUnclamped(float,float,float).factor'></a>

`factor` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The interpolation factor. Values outside [0, 1] extrapolate beyond the endpoints.

#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
The (possibly extrapolated) interpolated value.