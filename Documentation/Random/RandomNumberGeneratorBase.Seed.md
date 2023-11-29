#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomNumberGeneratorBase](RandomNumberGeneratorBase.md 'BeeneticToolkit.Random.RandomNumberGeneratorBase')

## RandomNumberGeneratorBase.Seed Property

Gets the seed value used for random number generation.

```csharp
protected long Seed { get; set; }
```

#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
The seed as a long integer. This seed is used to initialize the state of the random number generator  
to ensure consistent random sequences for the same seed.