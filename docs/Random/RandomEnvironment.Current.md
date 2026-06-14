#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment')

## RandomEnvironment.Current Property

Gets the current random number generator for this environment.  
  
This property is assigned to the first generator registered in the environment,  
but may be reassigned through [SetCurrent(string)](RandomEnvironment.SetCurrent(string).md 'BeeneticToolkit.Random.RandomEnvironment.SetCurrent(string)') or [SetCurrent(RandomKey)](RandomEnvironment.SetCurrent(RandomKey).md 'BeeneticToolkit.Random.RandomEnvironment.SetCurrent(BeeneticToolkit.Random.RandomKey)').

```csharp
public BeeneticToolkit.Random.RandomGenerator? Current { get; }
```

#### Property Value
[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')  
The current random number generator for the environment,  
or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null') if no generator has been registered yet.