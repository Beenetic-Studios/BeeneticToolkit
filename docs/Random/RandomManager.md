#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random')

## RandomManager Class

Provides global, process-wide access to the [RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment') system.  
  
[RandomManager](RandomManager.md 'BeeneticToolkit.Random.RandomManager') owns a default environment (used by the convenience selection helpers via  
            [Current](RandomManager.Current.md 'BeeneticToolkit.Random.RandomManager.Current')) and a registry of additional named environments. Register and retrieve  
            generators through [Default](RandomManager.Default.md 'BeeneticToolkit.Random.RandomManager.Default') (or another environment); the manager itself is only the  
            global entry point, not a parallel API.

```csharp
public static class RandomManager
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RandomManager

| Fields | |
| :--- | :--- |
| [DefaultEnvironmentName](RandomManager.DefaultEnvironmentName.md 'BeeneticToolkit.Random.RandomManager.DefaultEnvironmentName') | The name of the default global environment. |

| Properties | |
| :--- | :--- |
| [Current](RandomManager.Current.md 'BeeneticToolkit.Random.RandomManager.Current') | Gets the current generator of the [Default](RandomManager.Default.md 'BeeneticToolkit.Random.RandomManager.Default') environment. This is the generator used by<br/>the selection helpers when no explicit generator is supplied. |
| [Default](RandomManager.Default.md 'BeeneticToolkit.Random.RandomManager.Default') | Gets the default global [RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment'). Use it to register and retrieve generators,<br/>e.g. `RandomManager.Default.CreateAndRegister("enemies")`. |

| Methods | |
| :--- | :--- |
| [CreateEnvironment(string, Nullable&lt;long&gt;)](RandomManager.CreateEnvironment(string,Nullable_long_).md 'BeeneticToolkit.Random.RandomManager.CreateEnvironment(string, System.Nullable<long>)') | Creates a named environment and registers it with the manager, replacing any existing environment<br/>with the same name. |
| [GetEnvironment(string)](RandomManager.GetEnvironment(string).md 'BeeneticToolkit.Random.RandomManager.GetEnvironment(string)') | Gets a previously registered environment by name. |
| [SetDefault(string)](RandomManager.SetDefault(string).md 'BeeneticToolkit.Random.RandomManager.SetDefault(string)') | Makes a previously registered environment the [Default](RandomManager.Default.md 'BeeneticToolkit.Random.RandomManager.Default'). |
| [TryGetEnvironment(string, RandomEnvironment)](RandomManager.TryGetEnvironment(string,RandomEnvironment).md 'BeeneticToolkit.Random.RandomManager.TryGetEnvironment(string, BeeneticToolkit.Random.RandomEnvironment)') | Attempts to get a previously registered environment by name, without throwing. |
