#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGeneratorBase](RandomGeneratorBase.md 'BeeneticToolkit.Random.RandomGeneratorBase')

## RandomGeneratorBase(long) Constructor

Initializes a new instance of the random number generator with the specified seed.

```csharp
protected RandomGeneratorBase(long seed);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomGeneratorBase.RandomGeneratorBase(long).seed'></a>

`seed` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

The seed to use in random number generation.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [seed](RandomGeneratorBase.RandomGeneratorBase(long).md#BeeneticToolkit.Random.RandomGeneratorBase.RandomGeneratorBase(long).seed 'BeeneticToolkit.Random.RandomGeneratorBase.RandomGeneratorBase(long).seed') is less than or equal to 0.