#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random')

## RngManager Class

Provides centralized access to a default global [RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment').  
  
[RngManager](RngManager.md 'BeeneticToolkit.Random.RngManager') acts as a convenience facade for applications that want  
            a shared global RNG context identified by either a strongly typed [RngRole](RngRole.md 'BeeneticToolkit.Random.RngRole')  
            or a flexible string key.  
  
For projects that require isolated RNG scopes, use [RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment') directly.

```csharp
public static class RngManager
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RngManager

| Properties | |
| :--- | :--- |
| [Current](RngManager.Current.md 'BeeneticToolkit.Random.RngManager.Current') | Gets the current global random number generator.<br/><br/><br/>This property is initialized to [Default](RngRole.md#BeeneticToolkit.Random.RngRole.Default 'BeeneticToolkit.Random.RngRole.Default') during startup,<br/>and is therefore guaranteed to be non-null.<br/><br/>It may be reassigned to any registered generator through<br/>[SetCurrent(RngRole)](RngManager.SetCurrent(RngRole).md 'BeeneticToolkit.Random.RngManager.SetCurrent(BeeneticToolkit.Random.RngRole)') or [SetCurrent(string)](RngManager.SetCurrent(string).md 'BeeneticToolkit.Random.RngManager.SetCurrent(string)'). |

| Methods | |
| :--- | :--- |
| [CreateAndRegister(RngRole, Nullable&lt;long&gt;, RngAlgorithm)](RngManager.CreateAndRegister(RngRole,Nullable_long_,RngAlgorithm).md 'BeeneticToolkit.Random.RngManager.CreateAndRegister(BeeneticToolkit.Random.RngRole, System.Nullable<long>, BeeneticToolkit.Random.RngAlgorithm)') | Creates and registers a random number generator for the given role,<br/>then returns it. Overwrites any existing generator for the role. |
| [CreateAndRegister(string, Nullable&lt;long&gt;, RngAlgorithm)](RngManager.CreateAndRegister(string,Nullable_long_,RngAlgorithm).md 'BeeneticToolkit.Random.RngManager.CreateAndRegister(string, System.Nullable<long>, BeeneticToolkit.Random.RngAlgorithm)') | Creates and registers a random number generator for the given key,<br/>then returns it. Overwrites existing entries. |
| [Get(RngRole)](RngManager.Get(RngRole).md 'BeeneticToolkit.Random.RngManager.Get(BeeneticToolkit.Random.RngRole)') | Retrieves a random number generator previously registered under a specific [RngRole](RngRole.md 'BeeneticToolkit.Random.RngRole'). |
| [Get(string)](RngManager.Get(string).md 'BeeneticToolkit.Random.RngManager.Get(string)') | Retrieves a random number generator previously registered under a custom string key. |
| [Register(RngRole, RandomGenerator)](RngManager.Register(RngRole,RandomGenerator).md 'BeeneticToolkit.Random.RngManager.Register(BeeneticToolkit.Random.RngRole, BeeneticToolkit.Random.RandomGenerator)') | Registers a random number generator under a specific [RngRole](RngRole.md 'BeeneticToolkit.Random.RngRole').<br/>If a generator was previously registered for the same role, it will be replaced. |
| [Register(string, RandomGenerator)](RngManager.Register(string,RandomGenerator).md 'BeeneticToolkit.Random.RngManager.Register(string, BeeneticToolkit.Random.RandomGenerator)') | Registers a random number generator under a custom string key.<br/>This is useful for experimental, modding, or ad hoc scenarios<br/>where predefined [RngRole](RngRole.md 'BeeneticToolkit.Random.RngRole') values are insufficient.<br/>If a generator was previously registered with the same key, it will be replaced. |
| [SetCurrent(RngRole)](RngManager.SetCurrent(RngRole).md 'BeeneticToolkit.Random.RngManager.SetCurrent(BeeneticToolkit.Random.RngRole)') | Sets the [Current](RngManager.Current.md 'BeeneticToolkit.Random.RngManager.Current') random number generator to the one<br/>associated with the specified [RngRole](RngRole.md 'BeeneticToolkit.Random.RngRole'). |
| [SetCurrent(string)](RngManager.SetCurrent(string).md 'BeeneticToolkit.Random.RngManager.SetCurrent(string)') | Sets the [Current](RngManager.Current.md 'BeeneticToolkit.Random.RngManager.Current') random number generator to the one<br/>associated with the specified custom string key. |
| [TryGet(RngRole, RandomGenerator)](RngManager.TryGet(RngRole,RandomGenerator).md 'BeeneticToolkit.Random.RngManager.TryGet(BeeneticToolkit.Random.RngRole, BeeneticToolkit.Random.RandomGenerator)') | Attempts to retrieve a generator registered under the specified [RngRole](RngRole.md 'BeeneticToolkit.Random.RngRole'), without throwing. |
| [TryGet(string, RandomGenerator)](RngManager.TryGet(string,RandomGenerator).md 'BeeneticToolkit.Random.RngManager.TryGet(string, BeeneticToolkit.Random.RandomGenerator)') | Attempts to retrieve a generator registered under a custom string key, without throwing. |
