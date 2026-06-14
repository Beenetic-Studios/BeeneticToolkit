#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment')

## RngEnvironment.RootSeed Property

Gets the root seed of the environment, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null') if none was supplied.

```csharp
public System.Nullable<long> RootSeed { get; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

### Remarks
When a root seed is present, [CreateAndRegister(string, Nullable&lt;long&gt;, RngAlgorithm)](RngEnvironment.CreateAndRegister(string,Nullable_long_,RngAlgorithm).md 'BeeneticToolkit.Random.RngEnvironment.CreateAndRegister(string, System.Nullable<long>, BeeneticToolkit.Random.RngAlgorithm)') derives each  
generator's seed deterministically from the root seed and the registration key, so the whole  
environment is reproducible from this single value.