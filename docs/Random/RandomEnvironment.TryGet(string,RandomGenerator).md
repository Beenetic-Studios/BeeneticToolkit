#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment')

## RandomEnvironment.TryGet(string, RandomGenerator) Method

Attempts to retrieve a generator registered under the specified key, without throwing.

```csharp
public bool TryGet(string key, out BeeneticToolkit.Random.RandomGenerator generator);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomEnvironment.TryGet(string,BeeneticToolkit.Random.RandomGenerator).key'></a>

`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The key of the generator to retrieve.

<a name='BeeneticToolkit.Random.RandomEnvironment.TryGet(string,BeeneticToolkit.Random.RandomGenerator).generator'></a>

`generator` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

When this method returns `true`, the registered generator; otherwise `null`.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if a generator was registered under [key](RandomEnvironment.TryGet(string,RandomGenerator).md#BeeneticToolkit.Random.RandomEnvironment.TryGet(string,BeeneticToolkit.Random.RandomGenerator).key 'BeeneticToolkit.Random.RandomEnvironment.TryGet(string, BeeneticToolkit.Random.RandomGenerator).key'); otherwise `false`.