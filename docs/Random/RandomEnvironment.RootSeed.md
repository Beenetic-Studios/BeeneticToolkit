#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment')

## RandomEnvironment.RootSeed Property

Gets the root seed of the environment, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null') if none was supplied.

```csharp
public System.Nullable<long> RootSeed { get; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

### Remarks
When a root seed is present, [CreateAndRegister(string, Nullable&lt;long&gt;, RandomAlgorithm)](RandomEnvironment.CreateAndRegister(string,Nullable_long_,RandomAlgorithm).md 'BeeneticToolkit.Random.RandomEnvironment.CreateAndRegister(string, System.Nullable<long>, BeeneticToolkit.Random.RandomAlgorithm)') derives each  
generator's seed deterministically from the root seed and the registration key, so the whole  
environment is reproducible from this single value.