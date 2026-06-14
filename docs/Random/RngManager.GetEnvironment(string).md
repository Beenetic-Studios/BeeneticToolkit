#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngManager](RngManager.md 'BeeneticToolkit.Random.RngManager')

## RngManager.GetEnvironment(string) Method

Gets a previously registered environment by name.

```csharp
public static BeeneticToolkit.Random.RngEnvironment GetEnvironment(string name);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngManager.GetEnvironment(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the environment.

#### Returns
[RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment')  
The environment registered under [name](RngManager.GetEnvironment(string).md#BeeneticToolkit.Random.RngManager.GetEnvironment(string).name 'BeeneticToolkit.Random.RngManager.GetEnvironment(string).name').

#### Exceptions

[System.Collections.Generic.KeyNotFoundException](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException')  
Thrown when no environment is registered with the given name.