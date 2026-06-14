#### [Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[InterpolationUtils](InterpolationUtils.md 'BeeneticToolkit.Numerics.InterpolationUtils')

## InterpolationUtils.SmoothStep(float, float, float) Method

Interpolates between two values with smooth (Hermite) easing, clamping the factor to [0, 1].

```csharp
public static float SmoothStep(float from, float to, float t);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(float,float,float).from'></a>

`from` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The start value (returned when [t](InterpolationUtils.SmoothStep(float,float,float).md#BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(float,float,float).t 'BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(float, float, float).t') is 0 or less).

<a name='BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(float,float,float).to'></a>

`to` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The end value (returned when [t](InterpolationUtils.SmoothStep(float,float,float).md#BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(float,float,float).t 'BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(float, float, float).t') is 1 or more).

<a name='BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(float,float,float).t'></a>

`t` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The interpolation factor. Clamped to [0, 1] before easing.

#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
The eased value between [from](InterpolationUtils.SmoothStep(float,float,float).md#BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(float,float,float).from 'BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(float, float, float).from') and [to](InterpolationUtils.SmoothStep(float,float,float).md#BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(float,float,float).to 'BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(float, float, float).to').