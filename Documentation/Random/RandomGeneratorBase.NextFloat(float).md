#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGeneratorBase](RandomGeneratorBase.md 'BeeneticToolkit.Random.RandomGeneratorBase')

## RandomGeneratorBase.NextFloat(float) Method

Generates a pseudo-random float between 0 (inclusive) and the specified maximum (inclusive).  
It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [maxInclusive](RandomGeneratorBase.NextFloat(float).md#BeeneticToolkit.Random.RandomGeneratorBase.NextFloat(float).maxInclusive 'BeeneticToolkit.Random.RandomGeneratorBase.NextFloat(float).maxInclusive') is less than or equal to 0.

```csharp
public virtual float NextFloat(float maxInclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomGeneratorBase.NextFloat(float).maxInclusive'></a>

`maxInclusive` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The upper bound (inclusive) of the random float number to be generated. Must be greater than 0.

Implements [NextFloat(float)](IRandomGenerator.NextFloat(float).md 'BeeneticToolkit.Random.IRandomGenerator.NextFloat(float)')

#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
A random float in the range [0, [maxInclusive](RandomGeneratorBase.NextFloat(float).md#BeeneticToolkit.Random.RandomGeneratorBase.NextFloat(float).maxInclusive 'BeeneticToolkit.Random.RandomGeneratorBase.NextFloat(float).maxInclusive')].

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [maxInclusive](RandomGeneratorBase.NextFloat(float).md#BeeneticToolkit.Random.RandomGeneratorBase.NextFloat(float).maxInclusive 'BeeneticToolkit.Random.RandomGeneratorBase.NextFloat(float).maxInclusive') is less than or equal to 0.