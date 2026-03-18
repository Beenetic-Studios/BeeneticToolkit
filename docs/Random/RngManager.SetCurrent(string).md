#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngManager](RngManager.md 'BeeneticToolkit.Random.RngManager')

## RngManager.SetCurrent(string) Method

Sets the [Current](RngManager.Current.md 'BeeneticToolkit.Random.RngManager.Current') random number generator to the one  
associated with the specified custom string key.

```csharp
public static void SetCurrent(string key);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngManager.SetCurrent(string).key'></a>

`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The key of the generator to make current.

#### Exceptions

[System.Collections.Generic.KeyNotFoundException](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException')  
Thrown if no generator has been registered with the given key.