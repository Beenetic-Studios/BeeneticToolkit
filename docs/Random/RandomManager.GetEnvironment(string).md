#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomManager](RandomManager.md 'BeeneticToolkit.Random.RandomManager')

## RandomManager.GetEnvironment(string) Method

Gets a previously registered environment by name.

```csharp
public static BeeneticToolkit.Random.RandomEnvironment GetEnvironment(string name);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomManager.GetEnvironment(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the environment.

#### Returns
[RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment')  
The environment registered under [name](RandomManager.GetEnvironment(string).md#BeeneticToolkit.Random.RandomManager.GetEnvironment(string).name 'BeeneticToolkit.Random.RandomManager.GetEnvironment(string).name').

#### Exceptions

[System.Collections.Generic.KeyNotFoundException](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException')  
Thrown when no environment is registered with the given name.