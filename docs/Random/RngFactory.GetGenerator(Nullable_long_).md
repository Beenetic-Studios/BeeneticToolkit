#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngFactory](RngFactory.md 'BeeneticToolkit.Random.RngFactory')

## RngFactory.GetGenerator(Nullable<long>) Method

Creates a random number generator using the default algorithm (xoshiro256**) with a specified seed.

```csharp
public static BeeneticToolkit.Random.RandomGenerator GetGenerator(System.Nullable<long> seed);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngFactory.GetGenerator(System.Nullable_long_).seed'></a>

`seed` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The seed for the random number generator.

#### Returns
[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')  
An instance of a random number generator.