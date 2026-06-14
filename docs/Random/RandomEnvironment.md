#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random')

## RandomEnvironment Class

Represents an isolated collection of random number generators grouped under a single environment.  
  
[RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment') allows related RNG instances to be registered and retrieved  
            by either string key or [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey') while keeping them scoped to a specific environment.  
  
Each environment also exposes a convenience [Current](RandomEnvironment.Current.md 'BeeneticToolkit.Random.RandomEnvironment.Current') generator,  
which remains [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null') until the first generator is registered  
unless explicitly assigned later through [SetCurrent(string)](RandomEnvironment.SetCurrent(string).md 'BeeneticToolkit.Random.RandomEnvironment.SetCurrent(string)') or  
[SetCurrent(RandomKey)](RandomEnvironment.SetCurrent(RandomKey).md 'BeeneticToolkit.Random.RandomEnvironment.SetCurrent(BeeneticToolkit.Random.RandomKey)').

```csharp
public sealed class RandomEnvironment
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RandomEnvironment

| Constructors | |
| :--- | :--- |
| [RandomEnvironment(string, Nullable&lt;long&gt;)](RandomEnvironment.RandomEnvironment(string,Nullable_long_).md 'BeeneticToolkit.Random.RandomEnvironment.RandomEnvironment(string, System.Nullable<long>)') | Initializes a new instance of the [RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment') class. |

| Properties | |
| :--- | :--- |
| [Current](RandomEnvironment.Current.md 'BeeneticToolkit.Random.RandomEnvironment.Current') | Gets the current random number generator for this environment.<br/><br/><br/>This property is assigned to the first generator registered in the environment,<br/>but may be reassigned through [SetCurrent(string)](RandomEnvironment.SetCurrent(string).md 'BeeneticToolkit.Random.RandomEnvironment.SetCurrent(string)') or [SetCurrent(RandomKey)](RandomEnvironment.SetCurrent(RandomKey).md 'BeeneticToolkit.Random.RandomEnvironment.SetCurrent(BeeneticToolkit.Random.RandomKey)'). |
| [Name](RandomEnvironment.Name.md 'BeeneticToolkit.Random.RandomEnvironment.Name') | Gets the name of the environment. |
| [RootSeed](RandomEnvironment.RootSeed.md 'BeeneticToolkit.Random.RandomEnvironment.RootSeed') | Gets the root seed of the environment, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null') if none was supplied. |

| Methods | |
| :--- | :--- |
| [CreateAndRegister(RandomKey, Nullable&lt;long&gt;, RandomAlgorithm)](RandomEnvironment.CreateAndRegister(RandomKey,Nullable_long_,RandomAlgorithm).md 'BeeneticToolkit.Random.RandomEnvironment.CreateAndRegister(BeeneticToolkit.Random.RandomKey, System.Nullable<long>, BeeneticToolkit.Random.RandomAlgorithm)') | Creates a new random number generator, registers it under the specified [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey'),<br/>and returns the created instance.<br/>If a generator was previously registered with the same key, it will be replaced. |
| [CreateAndRegister(string, Nullable&lt;long&gt;, RandomAlgorithm)](RandomEnvironment.CreateAndRegister(string,Nullable_long_,RandomAlgorithm).md 'BeeneticToolkit.Random.RandomEnvironment.CreateAndRegister(string, System.Nullable<long>, BeeneticToolkit.Random.RandomAlgorithm)') | Creates a new random number generator, registers it under the specified key,<br/>and returns the created instance.<br/>If a generator was previously registered with the same key, it will be replaced. |
| [Get(RandomKey)](RandomEnvironment.Get(RandomKey).md 'BeeneticToolkit.Random.RandomEnvironment.Get(BeeneticToolkit.Random.RandomKey)') | Retrieves a random number generator previously registered under the specified [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey'). |
| [Get(string)](RandomEnvironment.Get(string).md 'BeeneticToolkit.Random.RandomEnvironment.Get(string)') | Retrieves a random number generator previously registered under the specified key. |
| [Register(RandomKey, RandomGenerator)](RandomEnvironment.Register(RandomKey,RandomGenerator).md 'BeeneticToolkit.Random.RandomEnvironment.Register(BeeneticToolkit.Random.RandomKey, BeeneticToolkit.Random.RandomGenerator)') | Registers a random number generator under a specific [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey').<br/>If a generator was previously registered with the same key, it will be replaced. |
| [Register(string, RandomGenerator)](RandomEnvironment.Register(string,RandomGenerator).md 'BeeneticToolkit.Random.RandomEnvironment.Register(string, BeeneticToolkit.Random.RandomGenerator)') | Registers a random number generator under a specific string key.<br/>If a generator was previously registered with the same key, it will be replaced. |
| [SetCurrent(RandomKey)](RandomEnvironment.SetCurrent(RandomKey).md 'BeeneticToolkit.Random.RandomEnvironment.SetCurrent(BeeneticToolkit.Random.RandomKey)') | Sets the [Current](RandomEnvironment.Current.md 'BeeneticToolkit.Random.RandomEnvironment.Current') random number generator to the one<br/>associated with the specified [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey'). |
| [SetCurrent(string)](RandomEnvironment.SetCurrent(string).md 'BeeneticToolkit.Random.RandomEnvironment.SetCurrent(string)') | Sets the [Current](RandomEnvironment.Current.md 'BeeneticToolkit.Random.RandomEnvironment.Current') random number generator to the one<br/>associated with the specified key. |
| [TryGet(RandomKey, RandomGenerator)](RandomEnvironment.TryGet(RandomKey,RandomGenerator).md 'BeeneticToolkit.Random.RandomEnvironment.TryGet(BeeneticToolkit.Random.RandomKey, BeeneticToolkit.Random.RandomGenerator)') | Attempts to retrieve a generator registered under the specified [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey'), without throwing. |
| [TryGet(string, RandomGenerator)](RandomEnvironment.TryGet(string,RandomGenerator).md 'BeeneticToolkit.Random.RandomEnvironment.TryGet(string, BeeneticToolkit.Random.RandomGenerator)') | Attempts to retrieve a generator registered under the specified key, without throwing. |
