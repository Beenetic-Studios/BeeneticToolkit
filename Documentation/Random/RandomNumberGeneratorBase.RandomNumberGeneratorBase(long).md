#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomNumberGeneratorBase](RandomNumberGeneratorBase.md 'BeeneticToolkit.Random.RandomNumberGeneratorBase')

## RandomNumberGeneratorBase(long) Constructor

Initializes a new instance of the random number generator with the specified seed.

```csharp
protected RandomNumberGeneratorBase(long seed);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomNumberGeneratorBase.RandomNumberGeneratorBase(long).seed'></a>

`seed` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

The seed to use in random number generation.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [seed](RandomNumberGeneratorBase.RandomNumberGeneratorBase(long).md#BeeneticToolkit.Random.RandomNumberGeneratorBase.RandomNumberGeneratorBase(long).seed 'BeeneticToolkit.Random.RandomNumberGeneratorBase.RandomNumberGeneratorBase(long).seed') is less than or equal to 0.