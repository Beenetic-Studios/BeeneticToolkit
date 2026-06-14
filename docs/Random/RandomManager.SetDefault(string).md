#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomManager](RandomManager.md 'BeeneticToolkit.Random.RandomManager')

## RandomManager.SetDefault(string) Method

Makes a previously registered environment the [Default](RandomManager.Default.md 'BeeneticToolkit.Random.RandomManager.Default').

```csharp
public static void SetDefault(string name);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomManager.SetDefault(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the environment to make default.

#### Exceptions

[System.Collections.Generic.KeyNotFoundException](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException')  
Thrown when no environment is registered with the given name.