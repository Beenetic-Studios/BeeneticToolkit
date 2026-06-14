#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random')

## RandomFactory Class

Provides factory methods for creating random number generators based on different algorithms.

```csharp
public static class RandomFactory
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RandomFactory

| Methods | |
| :--- | :--- |
| [GetGenerator()](RandomFactory.GetGenerator().md 'BeeneticToolkit.Random.RandomFactory.GetGenerator()') | Creates a random number generator using the default algorithm (xoshiro256**) without a specific seed. |
| [GetGenerator(RandomAlgorithm, Nullable&lt;long&gt;)](RandomFactory.GetGenerator(RandomAlgorithm,Nullable_long_).md 'BeeneticToolkit.Random.RandomFactory.GetGenerator(BeeneticToolkit.Random.RandomAlgorithm, System.Nullable<long>)') | Creates a random number generator using the specified algorithm and optional seed. |
| [GetGenerator(RandomAlgorithm)](RandomFactory.GetGenerator(RandomAlgorithm).md 'BeeneticToolkit.Random.RandomFactory.GetGenerator(BeeneticToolkit.Random.RandomAlgorithm)') | Creates a random number generator using a specified algorithm without a specific seed. |
| [GetGenerator(Nullable&lt;long&gt;)](RandomFactory.GetGenerator(Nullable_long_).md 'BeeneticToolkit.Random.RandomFactory.GetGenerator(System.Nullable<long>)') | Creates a random number generator using the default algorithm (xoshiro256**) with a specified seed. |
