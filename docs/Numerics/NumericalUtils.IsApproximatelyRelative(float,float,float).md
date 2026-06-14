#### [Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[NumericalUtils](NumericalUtils.md 'BeeneticToolkit.Numerics.NumericalUtils')

## NumericalUtils.IsApproximatelyRelative(float, float, float) Method

Determines whether two float values are approximately equal using a tolerance scaled to their magnitude.

```csharp
public static bool IsApproximatelyRelative(float value, float other, float relativeTolerance=1E-06f);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.NumericalUtils.IsApproximatelyRelative(float,float,float).value'></a>

`value` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The first value to compare.

<a name='BeeneticToolkit.Numerics.NumericalUtils.IsApproximatelyRelative(float,float,float).other'></a>

`other` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The second value to compare.

<a name='BeeneticToolkit.Numerics.NumericalUtils.IsApproximatelyRelative(float,float,float).relativeTolerance'></a>

`relativeTolerance` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The relative tolerance (fraction of the larger magnitude).

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the values are approximately equal; otherwise `false`. Equal infinities return  
            `true`; [System.Single.NaN](https://docs.microsoft.com/en-us/dotnet/api/System.Single.NaN 'System.Single.NaN') and mismatched non-finite values return `false`.