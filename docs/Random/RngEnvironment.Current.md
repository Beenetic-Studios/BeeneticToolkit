#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment')

## RngEnvironment.Current Property

Gets the current random number generator for this environment.  
  
This property is assigned to the first generator registered in the environment,  
but may be reassigned through [SetCurrent(string)](RngEnvironment.SetCurrent(string).md 'BeeneticToolkit.Random.RngEnvironment.SetCurrent(string)') or [SetCurrent(RngKey)](RngEnvironment.SetCurrent(RngKey).md 'BeeneticToolkit.Random.RngEnvironment.SetCurrent(BeeneticToolkit.Random.RngKey)').

```csharp
public BeeneticToolkit.Random.RandomGenerator? Current { get; set; }
```

#### Property Value
[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')  
The current random number generator for the environment,  
or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null') if no generator has been registered yet.