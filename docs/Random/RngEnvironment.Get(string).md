#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment')

## RngEnvironment.Get(string) Method

Retrieves a random number generator previously registered under the specified key.

```csharp
public BeeneticToolkit.Random.RandomGenerator Get(string key);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngEnvironment.Get(string).key'></a>

`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The key of the generator to retrieve.

#### Returns
[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')  
The generator associated with the specified key.

#### Exceptions

[System.Collections.Generic.KeyNotFoundException](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException')  
Thrown if no generator has been registered with the given key.