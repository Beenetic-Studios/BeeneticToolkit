#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomGenerator](IRandomGenerator.md 'BeeneticToolkit.Random.IRandomGenerator')

## IRandomGenerator.NextFloat(float, float) Method

Generates a random float within the specified range.

```csharp
float NextFloat(float minInclusive, float maxInclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.IRandomGenerator.NextFloat(float,float).minInclusive'></a>

`minInclusive` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The inclusive lower bound of the random number to generate.

<a name='BeeneticToolkit.Random.IRandomGenerator.NextFloat(float,float).maxInclusive'></a>

`maxInclusive` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The inclusive upper bound of the random number to generate.  
Must be greater than [minInclusive](IRandomGenerator.NextFloat(float,float).md#BeeneticToolkit.Random.IRandomGenerator.NextFloat(float,float).minInclusive 'BeeneticToolkit.Random.IRandomGenerator.NextFloat(float, float).minInclusive').

#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
A random float in the range  
[[minInclusive](IRandomGenerator.NextFloat(float,float).md#BeeneticToolkit.Random.IRandomGenerator.NextFloat(float,float).minInclusive 'BeeneticToolkit.Random.IRandomGenerator.NextFloat(float, float).minInclusive'), [maxInclusive](IRandomGenerator.NextFloat(float,float).md#BeeneticToolkit.Random.IRandomGenerator.NextFloat(float,float).maxInclusive 'BeeneticToolkit.Random.IRandomGenerator.NextFloat(float, float).maxInclusive')].