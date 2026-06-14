#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment')

## RngEnvironment.TryGet(RngKey, RandomGenerator) Method

Attempts to retrieve a generator registered under the specified [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey'), without throwing.

```csharp
public bool TryGet(BeeneticToolkit.Random.RngKey key, out BeeneticToolkit.Random.RandomGenerator generator);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngEnvironment.TryGet(BeeneticToolkit.Random.RngKey,BeeneticToolkit.Random.RandomGenerator).key'></a>

`key` [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey')

The strongly typed key of the generator to retrieve.

<a name='BeeneticToolkit.Random.RngEnvironment.TryGet(BeeneticToolkit.Random.RngKey,BeeneticToolkit.Random.RandomGenerator).generator'></a>

`generator` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

When this method returns `true`, the registered generator; otherwise `null`.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if a generator was registered under [key](RngEnvironment.TryGet(RngKey,RandomGenerator).md#BeeneticToolkit.Random.RngEnvironment.TryGet(BeeneticToolkit.Random.RngKey,BeeneticToolkit.Random.RandomGenerator).key 'BeeneticToolkit.Random.RngEnvironment.TryGet(BeeneticToolkit.Random.RngKey, BeeneticToolkit.Random.RandomGenerator).key'); otherwise `false`.