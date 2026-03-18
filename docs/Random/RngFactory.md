#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random')

## RngFactory Class

Provides factory methods for creating random number generators based on different algorithms.

```csharp
public static class RngFactory
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RngFactory

| Methods | |
| :--- | :--- |
| [GetGenerator()](RngFactory.GetGenerator().md 'BeeneticToolkit.Random.RngFactory.GetGenerator()') | Creates a random number generator using the default algorithm (Xorshift) without a specific seed. |
| [GetGenerator(RngAlgorithm)](RngFactory.GetGenerator(RngAlgorithm).md 'BeeneticToolkit.Random.RngFactory.GetGenerator(BeeneticToolkit.Random.RngAlgorithm)') | Creates a random number generator using a specified algorithm without a specific seed. |
| [GetGenerator(RngAlgorithm, Nullable&lt;long&gt;)](RngFactory.GetGenerator(RngAlgorithm,Nullable_long_).md 'BeeneticToolkit.Random.RngFactory.GetGenerator(BeeneticToolkit.Random.RngAlgorithm, System.Nullable<long>)') | Creates a random number generator using the specified algorithm and optional seed. |
| [GetGenerator(Nullable&lt;long&gt;)](RngFactory.GetGenerator(Nullable_long_).md 'BeeneticToolkit.Random.RngFactory.GetGenerator(System.Nullable<long>)') | Creates a random number generator using the default algorithm (Xorshift) with a specified seed. |
