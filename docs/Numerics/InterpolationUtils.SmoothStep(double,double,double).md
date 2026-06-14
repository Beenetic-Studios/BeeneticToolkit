#### [BeeneticToolkit.Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[InterpolationUtils](InterpolationUtils.md 'BeeneticToolkit.Numerics.InterpolationUtils')

## InterpolationUtils.SmoothStep(double, double, double) Method

Interpolates between two values with smooth (Hermite) easing, clamping the factor to [0, 1].

```csharp
public static double SmoothStep(double from, double to, double t);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(double,double,double).from'></a>

`from` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The start value (returned when [t](InterpolationUtils.SmoothStep(double,double,double).md#BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(double,double,double).t 'BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(double, double, double).t') is 0 or less).

<a name='BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(double,double,double).to'></a>

`to` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The end value (returned when [t](InterpolationUtils.SmoothStep(double,double,double).md#BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(double,double,double).t 'BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(double, double, double).t') is 1 or more).

<a name='BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(double,double,double).t'></a>

`t` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The interpolation factor. Clamped to [0, 1] before easing.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
The eased value between [from](InterpolationUtils.SmoothStep(double,double,double).md#BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(double,double,double).from 'BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(double, double, double).from') and [to](InterpolationUtils.SmoothStep(double,double,double).md#BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(double,double,double).to 'BeeneticToolkit.Numerics.InterpolationUtils.SmoothStep(double, double, double).to').