#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomFactory](RandomFactory.md 'BeeneticToolkit.Random.RandomFactory')

## RandomFactory.GetGenerator(RandomAlgorithm) Method

Creates a random number generator using a specified algorithm without a specific seed.

```csharp
public static BeeneticToolkit.Random.RandomGenerator GetGenerator(BeeneticToolkit.Random.RandomAlgorithm algorithm);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomFactory.GetGenerator(BeeneticToolkit.Random.RandomAlgorithm).algorithm'></a>

`algorithm` [RandomAlgorithm](RandomAlgorithm.md 'BeeneticToolkit.Random.RandomAlgorithm')

The algorithm to be used for random number generation.

#### Returns
[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')  
An instance of a random number generator.