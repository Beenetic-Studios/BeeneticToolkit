#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random')

## RngManager Class

Provides global, process-wide access to the [RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment') system.  
  
[RngManager](RngManager.md 'BeeneticToolkit.Random.RngManager') owns a default environment (used by the convenience selection helpers via  
            [Current](RngManager.Current.md 'BeeneticToolkit.Random.RngManager.Current')) and a registry of additional named environments. Register and retrieve  
            generators through [Default](RngManager.Default.md 'BeeneticToolkit.Random.RngManager.Default') (or another environment); the manager itself is only the  
            global entry point, not a parallel API.

```csharp
public static class RngManager
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RngManager

| Fields | |
| :--- | :--- |
| [DefaultEnvironmentName](RngManager.DefaultEnvironmentName.md 'BeeneticToolkit.Random.RngManager.DefaultEnvironmentName') | The name of the default global environment. |

| Properties | |
| :--- | :--- |
| [Current](RngManager.Current.md 'BeeneticToolkit.Random.RngManager.Current') | Gets the current generator of the [Default](RngManager.Default.md 'BeeneticToolkit.Random.RngManager.Default') environment. This is the generator used by<br/>the selection helpers when no explicit generator is supplied. |
| [Default](RngManager.Default.md 'BeeneticToolkit.Random.RngManager.Default') | Gets the default global [RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment'). Use it to register and retrieve generators,<br/>e.g. `RngManager.Default.CreateAndRegister("enemies")`. |

| Methods | |
| :--- | :--- |
| [CreateEnvironment(string, Nullable&lt;long&gt;)](RngManager.CreateEnvironment(string,Nullable_long_).md 'BeeneticToolkit.Random.RngManager.CreateEnvironment(string, System.Nullable<long>)') | Creates a named environment and registers it with the manager, replacing any existing environment<br/>with the same name. |
| [GetEnvironment(string)](RngManager.GetEnvironment(string).md 'BeeneticToolkit.Random.RngManager.GetEnvironment(string)') | Gets a previously registered environment by name. |
| [SetDefault(string)](RngManager.SetDefault(string).md 'BeeneticToolkit.Random.RngManager.SetDefault(string)') | Makes a previously registered environment the [Default](RngManager.Default.md 'BeeneticToolkit.Random.RngManager.Default'). |
| [TryGetEnvironment(string, RngEnvironment)](RngManager.TryGetEnvironment(string,RngEnvironment).md 'BeeneticToolkit.Random.RngManager.TryGetEnvironment(string, BeeneticToolkit.Random.RngEnvironment)') | Attempts to get a previously registered environment by name, without throwing. |
