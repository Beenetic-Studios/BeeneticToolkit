#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngManager](RngManager.md 'BeeneticToolkit.Random.RngManager')

## RngManager.TryGetEnvironment(string, RngEnvironment) Method

Attempts to get a previously registered environment by name, without throwing.

```csharp
public static bool TryGetEnvironment(string name, out BeeneticToolkit.Random.RngEnvironment environment);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngManager.TryGetEnvironment(string,BeeneticToolkit.Random.RngEnvironment).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the environment.

<a name='BeeneticToolkit.Random.RngManager.TryGetEnvironment(string,BeeneticToolkit.Random.RngEnvironment).environment'></a>

`environment` [RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment')

When this method returns `true`, the matching environment; otherwise `null`.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if an environment with the specified name exists; otherwise `false`.