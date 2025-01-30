#### [Numerics](index.md 'index')
### [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics').[NumericalUtils](NumericalUtils.md 'BeeneticToolkit.Numerics.NumericalUtils')

## NumericalUtils.Clamp01(float) Method

Clamps a float value to ensure it falls within the range of 0 to 1.

```csharp
public static float Clamp01(float value);
```
#### Parameters

<a name='BeeneticToolkit.Numerics.NumericalUtils.Clamp01(float).value'></a>

`value` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The float value to be clamped.

#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
The clamped float value.

### Example
  
```csharp  
float normalizedValue = Clamp01(1.5f); // returns 1.0f  
float lowerBoundValue = Clamp01(-0.3f); // returns 0.0f  
```