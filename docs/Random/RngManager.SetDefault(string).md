#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngManager](RngManager.md 'BeeneticToolkit.Random.RngManager')

## RngManager.SetDefault(string) Method

Makes a previously registered environment the [Default](RngManager.Default.md 'BeeneticToolkit.Random.RngManager.Default').

```csharp
public static void SetDefault(string name);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngManager.SetDefault(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the environment to make default.

#### Exceptions

[System.Collections.Generic.KeyNotFoundException](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException')  
Thrown when no environment is registered with the given name.