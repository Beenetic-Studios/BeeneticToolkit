#### [Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[NumericalUtils](NumericalUtils.md 'BeeneticToolkit.Numerics.NumericalUtils')

## NumericalUtils.Clamp01(double) Method

Clamps a double value to ensure it falls within the range of 0 to 1.

```csharp
public static double Clamp01(double value);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.NumericalUtils.Clamp01(double).value'></a>

`value` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The double value to be clamped.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
The clamped double value.

### Example
  
```csharp  
double normalizedValue = Clamp01(2.5); // returns 1.0  
double lowerBoundValue = Clamp01(-1.0); // returns 0.0  
```