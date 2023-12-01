#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGeneratorFactory](RandomGeneratorFactory.md 'BeeneticToolkit.Random.RandomGeneratorFactory')

## RandomGeneratorFactory.GetGenerator(RngAlgorithm, Nullable<long>) Method

Creates a random number generator using a specified algorithm and seed.

```csharp
public static BeeneticToolkit.Random.RandomGeneratorBase GetGenerator(BeeneticToolkit.Random.RngAlgorithm algorithm, System.Nullable<long> seed);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomGeneratorFactory.GetGenerator(BeeneticToolkit.Random.RngAlgorithm,System.Nullable_long_).algorithm'></a>

`algorithm` [RngAlgorithm](RngAlgorithm.md 'BeeneticToolkit.Random.RngAlgorithm')

The algorithm to be used for random number generation.

<a name='BeeneticToolkit.Random.RandomGeneratorFactory.GetGenerator(BeeneticToolkit.Random.RngAlgorithm,System.Nullable_long_).seed'></a>

`seed` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The seed for the random number generator.

#### Returns
[RandomGeneratorBase](RandomGeneratorBase.md 'BeeneticToolkit.Random.RandomGeneratorBase')  
An instance of a random number generator.