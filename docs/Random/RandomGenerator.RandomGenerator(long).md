#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

## RandomGenerator(long) Constructor

Initializes a new instance of the random number generator with the specified seed.

```csharp
protected RandomGenerator(long seed);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomGenerator.RandomGenerator(long).seed'></a>

`seed` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

The seed to use in random number generation.

#### Exceptions

[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
Thrown when[seed](RandomGenerator.RandomGenerator(long).md#BeeneticToolkit.Random.RandomGenerator.RandomGenerator(long).seed 'BeeneticToolkit.Random.RandomGenerator.RandomGenerator(long).seed') is less than or equal to 0.