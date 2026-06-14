#### [Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics')

## InterpolationUtils Class

Provides methods for interpolation, including linear interpolation (Lerp), quadratic Bezier  
interpolation (Qerp), range remapping, and smooth (Hermite) easing.

```csharp
public static class InterpolationUtils
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; InterpolationUtils

### Remarks
Unless a method documents otherwise, non-finite inputs ([System.Single.NaN](https://docs.microsoft.com/en-us/dotnet/api/System.Single.NaN 'System.Single.NaN'),  
[System.Single.PositiveInfinity](https://docs.microsoft.com/en-us/dotnet/api/System.Single.PositiveInfinity 'System.Single.PositiveInfinity'), etc.) are not specially handled and propagate through the result.

| Methods | |
| :--- | :--- |
| [InverseLerp(decimal, decimal, decimal)](InterpolationUtils.InverseLerp(decimal,decimal,decimal).md 'BeeneticToolkit.Numerics.InterpolationUtils.InverseLerp(decimal, decimal, decimal)') | Calculates the inverse linear interpolation factor between two values. |
| [InverseLerp(double, double, double)](InterpolationUtils.InverseLerp(double,double,double).md 'BeeneticToolkit.Numerics.InterpolationUtils.InverseLerp(double, double, double)') | Calculates the inverse linear interpolation factor between two values. |
| [InverseLerp(float, float, float)](InterpolationUtils.InverseLerp(float,float,float).md 'BeeneticToolkit.Numerics.InterpolationUtils.InverseLerp(float, float, float)') | Calculates the inverse linear interpolation factor between two values. |
| [Lerp(decimal, decimal, decimal)](InterpolationUtils.Lerp(decimal,decimal,decimal).md 'BeeneticToolkit.Numerics.InterpolationUtils.Lerp(decimal, decimal, decimal)') | Performs linear interpolation between two decimal values based on a given interpolation factor. |
| [Lerp(double, double, double)](InterpolationUtils.Lerp(double,double,double).md 'BeeneticToolkit.Numerics.InterpolationUtils.Lerp(double, double, double)') | Performs linear interpolation between two double values based on a given interpolation factor. |
| [Lerp(float, float, float)](InterpolationUtils.Lerp(float,float,float).md 'BeeneticToolkit.Numerics.InterpolationUtils.Lerp(float, float, float)') | Performs linear interpolation between two float values based on a given interpolation factor. |
| [LerpUnclamped(decimal, decimal, decimal)](InterpolationUtils.LerpUnclamped(decimal,decimal,decimal).md 'BeeneticToolkit.Numerics.InterpolationUtils.LerpUnclamped(decimal, decimal, decimal)') | Performs linear interpolation between two values without clamping the factor, allowing extrapolation. |
| [LerpUnclamped(double, double, double)](InterpolationUtils.LerpUnclamped(double,double,double).md 'BeeneticToolkit.Numerics.InterpolationUtils.LerpUnclamped(double, double, double)') | Performs linear interpolation between two values without clamping the factor, allowing extrapolation. |
| [LerpUnclamped(float, float, float)](InterpolationUtils.LerpUnclamped(float,float,float).md 'BeeneticToolkit.Numerics.InterpolationUtils.LerpUnclamped(float, float, float)') | Performs linear interpolation between two values without clamping the factor, allowing extrapolation. |
| [Qerp(decimal, decimal, decimal, decimal)](InterpolationUtils.Qerp(decimal,decimal,decimal,decimal).md 'BeeneticToolkit.Numerics.InterpolationUtils.Qerp(decimal, decimal, decimal, decimal)') | Performs quadratic Bezier interpolation between two values, influenced by a control point. |
| [Qerp(double, double, double, double)](InterpolationUtils.Qerp(double,double,double,double).md 'BeeneticToolkit.Numerics.InterpolationUtils.Qerp(double, double, double, double)') | Performs quadratic Bezier interpolation between two values, influenced by a control point. |
| [Qerp(float, float, float, float)](InterpolationUtils.Qerp(float,float,float,float).md 'BeeneticToolkit.Numerics.InterpolationUtils.Qerp(float, float, float, float)') | Performs quadratic Bezier interpolation between two values, influenced by a control point. |
| [Remap(decimal, decimal, decimal, decimal, decimal)](InterpolationUtils.Remap(decimal,decimal,decimal,decimal,decimal).md 'BeeneticToolkit.Numerics.InterpolationUtils.Remap(decimal, decimal, decimal, decimal, decimal)') | Remaps a value from one range to another (linear, unclamped). |
| [Remap(double, double, double, double, double)](InterpolationUtils.Remap(double,double,double,double,double).md 'BeeneticToolkit.Numerics.InterpolationUtils.Remap(double, double, double, double, double)') | Remaps a value from one range to another (linear, unclamped). |
| [Remap(float, float, float, float, float)](InterpolationUtils.Remap(float,float,float,float,float).md 'BeeneticToolkit.Numerics.InterpolationUtils.Remap(float, float, float, float, float)') | Remaps a value from one range to another (linear, unclamped). |
| [RemapClamped(decimal, decimal, decimal, decimal, decimal)](InterpolationUtils.RemapClamped(decimal,decimal,decimal,decimal,decimal).md 'BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(decimal, decimal, decimal, decimal, decimal)') | Remaps a value from one range to another, clamping the result to the destination range. |
| [RemapClamped(double, double, double, double, double)](InterpolationUtils.RemapClamped(double,double,double,double,double).md 'BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(double, double, double, double, double)') | Remaps a value from one range to another, clamping the result to the destination range. |
| [RemapClamped(float, float, float, float, float)](InterpolationUtils.RemapClamped(float,float,float,float,float).md 'BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(float, float, float, float, float)') | Remaps a value from one range to another, clamping the result to the destination range. |
| [SmoothStep(double, double, double)](InterpolationUtils.SmoothStep(double,double,double).md 'BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(double, double, double)') | Interpolates between two values with smooth (Hermite) easing, clamping the factor to [0, 1]. |
| [SmoothStep(float, float, float)](InterpolationUtils.SmoothStep(float,float,float).md 'BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(float, float, float)') | Interpolates between two values with smooth (Hermite) easing, clamping the factor to [0, 1]. |
