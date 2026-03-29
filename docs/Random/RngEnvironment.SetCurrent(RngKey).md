#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment')

## RngEnvironment.SetCurrent(RngKey) Method

Sets the [Current](RngEnvironment.Current.md 'BeeneticToolkit.Random.RngEnvironment.Current') random number generator to the one  
associated with the specified [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey').

```csharp
public void SetCurrent(BeeneticToolkit.Random.RngKey key);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngEnvironment.SetCurrent(BeeneticToolkit.Random.RngKey).key'></a>

`key` [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey')

The strongly typed key of the generator to make current.

#### Exceptions

[System.Collections.Generic.KeyNotFoundException](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException')  
Thrown if no generator has been registered with the given key.