#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment')

## RandomEnvironment.TryGet(RandomKey, RandomGenerator) Method

Attempts to retrieve a generator registered under the specified [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey'), without throwing.

```csharp
public bool TryGet(BeeneticToolkit.Random.RandomKey key, out BeeneticToolkit.Random.RandomGenerator generator);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomEnvironment.TryGet(BeeneticToolkit.Random.RandomKey,BeeneticToolkit.Random.RandomGenerator).key'></a>

`key` [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey')

The strongly typed key of the generator to retrieve.

<a name='BeeneticToolkit.Random.RandomEnvironment.TryGet(BeeneticToolkit.Random.RandomKey,BeeneticToolkit.Random.RandomGenerator).generator'></a>

`generator` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

When this method returns `true`, the registered generator; otherwise `null`.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if a generator was registered under [key](RandomEnvironment.TryGet(RandomKey,RandomGenerator).md#BeeneticToolkit.Random.RandomEnvironment.TryGet(BeeneticToolkit.Random.RandomKey,BeeneticToolkit.Random.RandomGenerator).key 'BeeneticToolkit.Random.RandomEnvironment.TryGet(BeeneticToolkit.Random.RandomKey, BeeneticToolkit.Random.RandomGenerator).key'); otherwise `false`.