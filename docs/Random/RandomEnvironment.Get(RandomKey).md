#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment')

## RandomEnvironment.Get(RandomKey) Method

Retrieves a random number generator previously registered under the specified [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey').

```csharp
public BeeneticToolkit.Random.RandomGenerator Get(BeeneticToolkit.Random.RandomKey key);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomEnvironment.Get(BeeneticToolkit.Random.RandomKey).key'></a>

`key` [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey')

The strongly typed key of the generator to retrieve.

#### Returns
[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')  
The generator associated with the specified key.

#### Exceptions

[System.Collections.Generic.KeyNotFoundException](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException')  
Thrown if no generator has been registered with the given key.