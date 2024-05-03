#### [MathUtils](index.md 'index')
### [BeeneticToolkit.MathUtils](index.md#BeeneticToolkit.MathUtils 'BeeneticToolkit.MathUtils').[MathUtils](MathUtils.md 'BeeneticToolkit.MathUtils.MathUtils')

## MathUtils.Lerp(double, double, double) Method

Performs linear interpolation between two double values based on a given interpolation factor.

```csharp
public static double Lerp(double start, double end, double factor);
```
#### Parameters

<a name='BeeneticToolkit.MathUtils.MathUtils.Lerp(double,double,double).start'></a>

`start` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The start value.

<a name='BeeneticToolkit.MathUtils.MathUtils.Lerp(double,double,double).end'></a>

`end` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The end value.

<a name='BeeneticToolkit.MathUtils.MathUtils.Lerp(double,double,double).factor'></a>

`factor` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The interpolation factor, typically between 0 and 1. Values outside this range are clamped to the range [0, 1].

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
The interpolated double value between the start and end values.