#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGeneratorFactory](RandomGeneratorFactory.md 'BeeneticToolkit.Random.RandomGeneratorFactory')

## RandomGeneratorFactory.GetGenerator(long, RngAlgorithm) Method

Creates a random number generator using a specified algorithm and seed.

```csharp
public static BeeneticToolkit.Random.RandomGeneratorBase GetGenerator(long seed, BeeneticToolkit.Random.RngAlgorithm algorithm);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomGeneratorFactory.GetGenerator(long,BeeneticToolkit.Random.RngAlgorithm).seed'></a>

`seed` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

The seed for the random number generator.

<a name='BeeneticToolkit.Random.RandomGeneratorFactory.GetGenerator(long,BeeneticToolkit.Random.RngAlgorithm).algorithm'></a>

`algorithm` [RngAlgorithm](RngAlgorithm.md 'BeeneticToolkit.Random.RngAlgorithm')

The algorithm to be used for random number generation.

#### Returns
[RandomGeneratorBase](RandomGeneratorBase.md 'BeeneticToolkit.Random.RandomGeneratorBase')  
An instance of a random number generator.