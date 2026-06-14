#### [Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[InterpolationUtils](InterpolationUtils.md 'BeeneticToolkit.Numerics.InterpolationUtils')

## InterpolationUtils.Remap(double, double, double, double, double) Method

Remaps a value from one range to another (linear, unclamped).

```csharp
public static double Remap(double value, double fromMin, double fromMax, double toMin, double toMax);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.InterpolationUtils.Remap(double,double,double,double,double).value'></a>

`value` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The value to remap.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.Remap(double,double,double,double,double).fromMin'></a>

`fromMin` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The lower bound of the source range.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.Remap(double,double,double,double,double).fromMax'></a>

`fromMax` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The upper bound of the source range.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.Remap(double,double,double,double,double).toMin'></a>

`toMin` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The lower bound of the destination range.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.Remap(double,double,double,double,double).toMax'></a>

`toMax` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The upper bound of the destination range.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
The value mapped into the destination range. Inputs outside the source range extrapolate.

#### Exceptions

[System.DivideByZeroException](https://docs.microsoft.com/en-us/dotnet/api/System.DivideByZeroException 'System.DivideByZeroException')  
Thrown when [fromMin](InterpolationUtils.Remap(double,double,double,double,double).md#BeeneticToolkit.Numerics.InterpolationUtils.Remap(double,double,double,double,double).fromMin 'BeeneticToolkit.Numerics.InterpolationUtils.Remap(double, double, double, double, double).fromMin') equals [fromMax](InterpolationUtils.Remap(double,double,double,double,double).md#BeeneticToolkit.Numerics.InterpolationUtils.Remap(double,double,double,double,double).fromMax 'BeeneticToolkit.Numerics.InterpolationUtils.Remap(double, double, double, double, double).fromMax').