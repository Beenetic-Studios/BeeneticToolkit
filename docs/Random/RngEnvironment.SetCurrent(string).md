#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment')

## RngEnvironment.SetCurrent(string) Method

Sets the [Current](RngEnvironment.Current.md 'BeeneticToolkit.Random.RngEnvironment.Current') random number generator to the one  
associated with the specified key.

```csharp
public void SetCurrent(string key);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngEnvironment.SetCurrent(string).key'></a>

`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The key of the generator to make current.

#### Exceptions

[System.Collections.Generic.KeyNotFoundException](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException')  
Thrown if no generator has been registered with the given key.