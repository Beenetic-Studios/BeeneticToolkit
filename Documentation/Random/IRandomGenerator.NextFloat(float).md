#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomGenerator](IRandomGenerator.md 'BeeneticToolkit.Random.IRandomGenerator')

## IRandomGenerator.NextFloat(float) Method

Returns a non-negative random float that is less than the specified maximum.

```csharp
float NextFloat(float maxExclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.IRandomGenerator.NextFloat(float).maxExclusive'></a>

`maxExclusive` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The exclusive upper bound of the random number to be generated. maxValue must be greater than or equal to 0.0.

#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
A non-negative random float that is less than maxValue.