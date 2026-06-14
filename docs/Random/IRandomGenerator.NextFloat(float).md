#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomGenerator](IRandomGenerator.md 'BeeneticToolkit.Random.IRandomGenerator')

## IRandomGenerator.NextFloat(float) Method

Generates a non-negative random float that is less than or equal to the specified maximum.

```csharp
float NextFloat(float maxInclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.IRandomGenerator.NextFloat(float).maxInclusive'></a>

`maxInclusive` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The inclusive upper bound of the random number to generate. Must be greater than 0.

#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
A random float in the range [0, [maxInclusive](IRandomGenerator.NextFloat(float).md#BeeneticToolkit.Random.IRandomGenerator.NextFloat(float).maxInclusive 'BeeneticToolkit.Random.IRandomGenerator.NextFloat(float).maxInclusive')].