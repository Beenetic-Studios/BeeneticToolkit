#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

## RandomGenerator.NextFloat(float, float) Method

Generates a pseudo-random float between the specified minimum (inclusive) and maximum (inclusive).  
It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [minInclusive](RandomGenerator.NextFloat(float,float).md#BeeneticToolkit.Random.RandomGenerator.NextFloat(float,float).minInclusive 'BeeneticToolkit.Random.RandomGenerator.NextFloat(float, float).minInclusive') is greater than or equal to [maxInclusive](RandomGenerator.NextFloat(float,float).md#BeeneticToolkit.Random.RandomGenerator.NextFloat(float,float).maxInclusive 'BeeneticToolkit.Random.RandomGenerator.NextFloat(float, float).maxInclusive').

```csharp
public virtual float NextFloat(float minInclusive, float maxInclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomGenerator.NextFloat(float,float).minInclusive'></a>

`minInclusive` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The lower bound (inclusive) of the random float number to be generated.

<a name='BeeneticToolkit.Random.RandomGenerator.NextFloat(float,float).maxInclusive'></a>

`maxInclusive` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The upper bound (inclusive) of the random float number to be generated. Must be greater than [minInclusive](RandomGenerator.NextFloat(float,float).md#BeeneticToolkit.Random.RandomGenerator.NextFloat(float,float).minInclusive 'BeeneticToolkit.Random.RandomGenerator.NextFloat(float, float).minInclusive').

Implements [NextFloat(float, float)](IRandomGenerator.NextFloat(float,float).md 'BeeneticToolkit.Random.IRandomGenerator.NextFloat(float, float)')

#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
A random float in the range [[minInclusive](RandomGenerator.NextFloat(float,float).md#BeeneticToolkit.Random.RandomGenerator.NextFloat(float,float).minInclusive 'BeeneticToolkit.Random.RandomGenerator.NextFloat(float, float).minInclusive'), [maxInclusive](RandomGenerator.NextFloat(float,float).md#BeeneticToolkit.Random.RandomGenerator.NextFloat(float,float).maxInclusive 'BeeneticToolkit.Random.RandomGenerator.NextFloat(float, float).maxInclusive')].

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [minInclusive](RandomGenerator.NextFloat(float,float).md#BeeneticToolkit.Random.RandomGenerator.NextFloat(float,float).minInclusive 'BeeneticToolkit.Random.RandomGenerator.NextFloat(float, float).minInclusive') is greater than or equal to [maxInclusive](RandomGenerator.NextFloat(float,float).md#BeeneticToolkit.Random.RandomGenerator.NextFloat(float,float).maxInclusive 'BeeneticToolkit.Random.RandomGenerator.NextFloat(float, float).maxInclusive').