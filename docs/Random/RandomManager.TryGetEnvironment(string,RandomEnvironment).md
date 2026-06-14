#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomManager](RandomManager.md 'BeeneticToolkit.Random.RandomManager')

## RandomManager.TryGetEnvironment(string, RandomEnvironment) Method

Attempts to get a previously registered environment by name, without throwing.

```csharp
public static bool TryGetEnvironment(string name, out BeeneticToolkit.Random.RandomEnvironment environment);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomManager.TryGetEnvironment(string,BeeneticToolkit.Random.RandomEnvironment).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the environment.

<a name='BeeneticToolkit.Random.RandomManager.TryGetEnvironment(string,BeeneticToolkit.Random.RandomEnvironment).environment'></a>

`environment` [RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment')

When this method returns `true`, the matching environment; otherwise `null`.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if an environment with the specified name exists; otherwise `false`.