#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment')

## RandomEnvironment.SetCurrent(RandomKey) Method

Sets the [Current](RandomEnvironment.Current.md 'BeeneticToolkit.Random.RandomEnvironment.Current') random number generator to the one  
associated with the specified [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey').

```csharp
public void SetCurrent(BeeneticToolkit.Random.RandomKey key);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomEnvironment.SetCurrent(BeeneticToolkit.Random.RandomKey).key'></a>

`key` [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey')

The strongly typed key of the generator to make current.

#### Exceptions

[System.Collections.Generic.KeyNotFoundException](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException')  
Thrown if no generator has been registered with the given key.