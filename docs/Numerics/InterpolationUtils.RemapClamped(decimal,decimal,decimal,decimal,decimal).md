#### [BeeneticToolkit.Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[InterpolationUtils](InterpolationUtils.md 'BeeneticToolkit.Numerics.InterpolationUtils')

## InterpolationUtils.RemapClamped(decimal, decimal, decimal, decimal, decimal) Method

Remaps a value from one range to another, clamping the result to the destination range.

```csharp
public static decimal RemapClamped(decimal value, decimal fromMin, decimal fromMax, decimal toMin, decimal toMax);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(decimal,decimal,decimal,decimal,decimal).value'></a>

`value` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The value to remap.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(decimal,decimal,decimal,decimal,decimal).fromMin'></a>

`fromMin` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The lower bound of the source range.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(decimal,decimal,decimal,decimal,decimal).fromMax'></a>

`fromMax` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The upper bound of the source range.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(decimal,decimal,decimal,decimal,decimal).toMin'></a>

`toMin` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The lower bound of the destination range.

<a name='BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(decimal,decimal,decimal,decimal,decimal).toMax'></a>

`toMax` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The upper bound of the destination range.

#### Returns
[System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')  
The value mapped into the destination range, clamped so it never leaves [[toMin](InterpolationUtils.RemapClamped(decimal,decimal,decimal,decimal,decimal).md#BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(decimal,decimal,decimal,decimal,decimal).toMin 'BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(decimal, decimal, decimal, decimal, decimal).toMin'), [toMax](InterpolationUtils.RemapClamped(decimal,decimal,decimal,decimal,decimal).md#BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(decimal,decimal,decimal,decimal,decimal).toMax 'BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(decimal, decimal, decimal, decimal, decimal).toMax')].

#### Exceptions

[System.DivideByZeroException](https://docs.microsoft.com/en-us/dotnet/api/System.DivideByZeroException 'System.DivideByZeroException')  
Thrown when [fromMin](InterpolationUtils.RemapClamped(decimal,decimal,decimal,decimal,decimal).md#BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(decimal,decimal,decimal,decimal,decimal).fromMin 'BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(decimal, decimal, decimal, decimal, decimal).fromMin') equals [fromMax](InterpolationUtils.RemapClamped(decimal,decimal,decimal,decimal,decimal).md#BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(decimal,decimal,decimal,decimal,decimal).fromMax 'BeeneticToolkit.Numerics.InterpolationUtils.RemapClamped(decimal, decimal, decimal, decimal, decimal).fromMax').