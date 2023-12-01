#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGeneratorFactory](RandomGeneratorFactory.md 'BeeneticToolkit.Random.RandomGeneratorFactory')

## RandomGeneratorFactory.GetGenerator(RngAlgorithm) Method

Creates a random number generator using a specified algorithm without a specific seed.

```csharp
public static BeeneticToolkit.Random.RandomGeneratorBase GetGenerator(BeeneticToolkit.Random.RngAlgorithm algorithm);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomGeneratorFactory.GetGenerator(BeeneticToolkit.Random.RngAlgorithm).algorithm'></a>

`algorithm` [RngAlgorithm](RngAlgorithm.md 'BeeneticToolkit.Random.RngAlgorithm')

The algorithm to be used for random number generation.

#### Returns
[RandomGeneratorBase](RandomGeneratorBase.md 'BeeneticToolkit.Random.RandomGeneratorBase')  
An instance of a random number generator.