#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random')

## RngEnvironment Class

Represents an isolated collection of random number generators grouped under a single environment.  
  
[RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment') allows related RNG instances to be registered and retrieved  
            by either string key or [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey') while keeping them scoped to a specific environment.  
  
Each environment also exposes a convenience [Current](RngEnvironment.Current.md 'BeeneticToolkit.Random.RngEnvironment.Current') generator,  
which remains [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null') until the first generator is registered  
unless explicitly assigned later through [SetCurrent(string)](RngEnvironment.SetCurrent(string).md 'BeeneticToolkit.Random.RngEnvironment.SetCurrent(string)') or  
[SetCurrent(RngKey)](RngEnvironment.SetCurrent(RngKey).md 'BeeneticToolkit.Random.RngEnvironment.SetCurrent(BeeneticToolkit.Random.RngKey)').

```csharp
public sealed class RngEnvironment
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RngEnvironment

| Constructors | |
| :--- | :--- |
| [RngEnvironment(string)](RngEnvironment.RngEnvironment(string).md 'BeeneticToolkit.Random.RngEnvironment.RngEnvironment(string)') | Initializes a new instance of the [RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment') class. |

| Properties | |
| :--- | :--- |
| [Current](RngEnvironment.Current.md 'BeeneticToolkit.Random.RngEnvironment.Current') | Gets the current random number generator for this environment.<br/><br/><br/>This property is assigned to the first generator registered in the environment,<br/>but may be reassigned through [SetCurrent(string)](RngEnvironment.SetCurrent(string).md 'BeeneticToolkit.Random.RngEnvironment.SetCurrent(string)') or [SetCurrent(RngKey)](RngEnvironment.SetCurrent(RngKey).md 'BeeneticToolkit.Random.RngEnvironment.SetCurrent(BeeneticToolkit.Random.RngKey)'). |
| [Name](RngEnvironment.Name.md 'BeeneticToolkit.Random.RngEnvironment.Name') | Gets the name of the environment. |

| Methods | |
| :--- | :--- |
| [CreateAndRegister(RngKey, Nullable&lt;long&gt;, RngAlgorithm)](RngEnvironment.CreateAndRegister(RngKey,Nullable_long_,RngAlgorithm).md 'BeeneticToolkit.Random.RngEnvironment.CreateAndRegister(BeeneticToolkit.Random.RngKey, System.Nullable<long>, BeeneticToolkit.Random.RngAlgorithm)') | Creates a new random number generator, registers it under the specified [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey'),<br/>and returns the created instance.<br/>If a generator was previously registered with the same key, it will be replaced. |
| [CreateAndRegister(string, Nullable&lt;long&gt;, RngAlgorithm)](RngEnvironment.CreateAndRegister(string,Nullable_long_,RngAlgorithm).md 'BeeneticToolkit.Random.RngEnvironment.CreateAndRegister(string, System.Nullable<long>, BeeneticToolkit.Random.RngAlgorithm)') | Creates a new random number generator, registers it under the specified key,<br/>and returns the created instance.<br/>If a generator was previously registered with the same key, it will be replaced. |
| [Get(RngKey)](RngEnvironment.Get(RngKey).md 'BeeneticToolkit.Random.RngEnvironment.Get(BeeneticToolkit.Random.RngKey)') | Retrieves a random number generator previously registered under the specified [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey'). |
| [Get(string)](RngEnvironment.Get(string).md 'BeeneticToolkit.Random.RngEnvironment.Get(string)') | Retrieves a random number generator previously registered under the specified key. |
| [Register(RngKey, RandomGenerator)](RngEnvironment.Register(RngKey,RandomGenerator).md 'BeeneticToolkit.Random.RngEnvironment.Register(BeeneticToolkit.Random.RngKey, BeeneticToolkit.Random.RandomGenerator)') | Registers a random number generator under a specific [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey').<br/>If a generator was previously registered with the same key, it will be replaced. |
| [Register(string, RandomGenerator)](RngEnvironment.Register(string,RandomGenerator).md 'BeeneticToolkit.Random.RngEnvironment.Register(string, BeeneticToolkit.Random.RandomGenerator)') | Registers a random number generator under a specific string key.<br/>If a generator was previously registered with the same key, it will be replaced. |
| [SetCurrent(RngKey)](RngEnvironment.SetCurrent(RngKey).md 'BeeneticToolkit.Random.RngEnvironment.SetCurrent(BeeneticToolkit.Random.RngKey)') | Sets the [Current](RngEnvironment.Current.md 'BeeneticToolkit.Random.RngEnvironment.Current') random number generator to the one<br/>associated with the specified [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey'). |
| [SetCurrent(string)](RngEnvironment.SetCurrent(string).md 'BeeneticToolkit.Random.RngEnvironment.SetCurrent(string)') | Sets the [Current](RngEnvironment.Current.md 'BeeneticToolkit.Random.RngEnvironment.Current') random number generator to the one<br/>associated with the specified key. |
