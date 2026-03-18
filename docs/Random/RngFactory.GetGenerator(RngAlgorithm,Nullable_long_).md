#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngFactory](RngFactory.md 'BeeneticToolkit.Random.RngFactory')

## RngFactory.GetGenerator(RngAlgorithm, Nullable<long>) Method

Creates a random number generator using the specified algorithm and optional seed.

```csharp
public static BeeneticToolkit.Random.RandomGenerator GetGenerator(BeeneticToolkit.Random.RngAlgorithm algorithm, System.Nullable<long> seed);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngFactory.GetGenerator(BeeneticToolkit.Random.RngAlgorithm,System.Nullable_long_).algorithm'></a>

`algorithm` [RngAlgorithm](RngAlgorithm.md 'BeeneticToolkit.Random.RngAlgorithm')

The algorithm to use for random number generation.

<a name='BeeneticToolkit.Random.RngFactory.GetGenerator(BeeneticToolkit.Random.RngAlgorithm,System.Nullable_long_).seed'></a>

`seed` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The optional seed for the random number generator.

#### Returns
[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')  
An instance of a random number generator.