#### [BeeneticToolkit.Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[NumericalUtils](NumericalUtils.md 'BeeneticToolkit.Numerics.NumericalUtils')

## NumericalUtils.IsApproximatelyRelative(double, double, double) Method

Determines whether two double values are approximately equal using a tolerance scaled to their magnitude.

```csharp
public static bool IsApproximatelyRelative(double value, double other, double relativeTolerance=1E-12);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.NumericalUtils.IsApproximatelyRelative(double,double,double).value'></a>

`value` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The first value to compare.

<a name='BeeneticToolkit.Numerics.NumericalUtils.IsApproximatelyRelative(double,double,double).other'></a>

`other` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The second value to compare.

<a name='BeeneticToolkit.Numerics.NumericalUtils.IsApproximatelyRelative(double,double,double).relativeTolerance'></a>

`relativeTolerance` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The relative tolerance (fraction of the larger magnitude).

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the values are approximately equal; otherwise `false`. Equal infinities return  
            `true`; [System.Double.NaN](https://docs.microsoft.com/en-us/dotnet/api/System.Double.NaN 'System.Double.NaN') and mismatched non-finite values return `false`.