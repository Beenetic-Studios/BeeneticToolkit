#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random')

## RandomGeneratorFactory Class

Provides factory methods for creating random number generators based on different algorithms.

```csharp
public static class RandomGeneratorFactory
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RandomGeneratorFactory

| Methods | |
| :--- | :--- |
| [GetGenerator()](RandomGeneratorFactory.GetGenerator().md 'BeeneticToolkit.Random.RandomGeneratorFactory.GetGenerator()') | Creates a random number generator using the default algorithm (Xorshift) without a specific seed. |
| [GetGenerator(RngAlgorithm)](RandomGeneratorFactory.GetGenerator(RngAlgorithm).md 'BeeneticToolkit.Random.RandomGeneratorFactory.GetGenerator(BeeneticToolkit.Random.RngAlgorithm)') | Creates a random number generator using a specified algorithm without a specific seed. |
| [GetGenerator(RngAlgorithm, Nullable&lt;long&gt;)](RandomGeneratorFactory.GetGenerator(RngAlgorithm,Nullable_long_).md 'BeeneticToolkit.Random.RandomGeneratorFactory.GetGenerator(BeeneticToolkit.Random.RngAlgorithm, System.Nullable<long>)') | Creates a random number generator using a specified algorithm and seed. |
| [GetGenerator(Nullable&lt;long&gt;)](RandomGeneratorFactory.GetGenerator(Nullable_long_).md 'BeeneticToolkit.Random.RandomGeneratorFactory.GetGenerator(System.Nullable<long>)') | Creates a random number generator using the default algorithm (Xorshift) with a specified seed. |
