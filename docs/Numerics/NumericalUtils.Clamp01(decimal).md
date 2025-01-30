#### [Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[NumericalUtils](NumericalUtils.md 'BeeneticToolkit.Numerics.NumericalUtils')

## NumericalUtils.Clamp01(decimal) Method

Clamps a decimal value to ensure it falls within the range of 0 to 1.

```csharp
public static decimal Clamp01(decimal value);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.NumericalUtils.Clamp01(decimal).value'></a>

`value` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

The decimal value to be clamped.

#### Returns
[System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')  
The clamped decimal value.

### Example
  
```csharp  
decimal normalizedValue = Clamp01(1.2m); // returns 1.0m  
decimal lowerBoundValue = Clamp01(-0.5m); // returns 0.0m  
```