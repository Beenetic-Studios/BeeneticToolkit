#### [Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[InterpolationUtils](InterpolationUtils.md 'BeeneticToolkit.Numerics.InterpolationUtils')

## InterpolationUtils.RemapClamped(float, float, float, float, float) Method

Remaps a value from one range to another, clamping the result to the destination range.

```csharp
public static float RemapClamped(float value, float fromMin, float fromMax, float toMin, float toMax);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(float,float,float,float,float).value'></a>

`value` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The value to remap.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(float,float,float,float,float).fromMin'></a>

`fromMin` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The lower bound of the source range.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(float,float,float,float,float).fromMax'></a>

`fromMax` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The upper bound of the source range.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(float,float,float,float,float).toMin'></a>

`toMin` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The lower bound of the destination range.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(float,float,float,float,float).toMax'></a>

`toMax` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The upper bound of the destination range.

#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
The value mapped into the destination range, clamped so it never leaves [[toMin](InterpolationUtils.RemapClamped(float,float,float,float,float).md#BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(float,float,float,float,float).toMin 'BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(float, float, float, float, float).toMin'), [toMax](InterpolationUtils.RemapClamped(float,float,float,float,float).md#BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(float,float,float,float,float).toMax 'BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(float, float, float, float, float).toMax')].

#### Exceptions

[System.DivideByZeroException](https://docs.microsoft.com/en-us/dotnet/api/System.DivideByZeroException 'System.DivideByZeroException')  
Thrown when [fromMin](InterpolationUtils.RemapClamped(float,float,float,float,float).md#BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(float,float,float,float,float).fromMin 'BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(float, float, float, float, float).fromMin') equals [fromMax](InterpolationUtils.RemapClamped(float,float,float,float,float).md#BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(float,float,float,float,float).fromMax 'BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(float, float, float, float, float).fromMax').