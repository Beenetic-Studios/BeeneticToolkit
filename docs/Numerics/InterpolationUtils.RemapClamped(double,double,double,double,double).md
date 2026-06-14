#### [BeeneticToolkit.Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[InterpolationUtils](InterpolationUtils.md 'BeeneticToolkit.Numerics.InterpolationUtils')

## InterpolationUtils.RemapClamped(double, double, double, double, double) Method

Remaps a value from one range to another, clamping the result to the destination range.

```csharp
public static double RemapClamped(double value, double fromMin, double fromMax, double toMin, double toMax);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(double,double,double,double,double).value'></a>

`value` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The value to remap.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(double,double,double,double,double).fromMin'></a>

`fromMin` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The lower bound of the source range.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(double,double,double,double,double).fromMax'></a>

`fromMax` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The upper bound of the source range.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(double,double,double,double,double).toMin'></a>

`toMin` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The lower bound of the destination range.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(double,double,double,double,double).toMax'></a>

`toMax` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The upper bound of the destination range.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
The value mapped into the destination range, clamped so it never leaves [[toMin](InterpolationUtils.RemapClamped(double,double,double,double,double).md#BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(double,double,double,double,double).toMin 'BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(double, double, double, double, double).toMin'), [toMax](InterpolationUtils.RemapClamped(double,double,double,double,double).md#BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(double,double,double,double,double).toMax 'BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(double, double, double, double, double).toMax')].

#### Exceptions

[System.DivideByZeroException](https://docs.microsoft.com/en-us/dotnet/api/System.DivideByZeroException 'System.DivideByZeroException')  
Thrown when [fromMin](InterpolationUtils.RemapClamped(double,double,double,double,double).md#BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(double,double,double,double,double).fromMin 'BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(double, double, double, double, double).fromMin') equals [fromMax](InterpolationUtils.RemapClamped(double,double,double,double,double).md#BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(double,double,double,double,double).fromMax 'BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(double, double, double, double, double).fromMax').