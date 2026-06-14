#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment')

## RandomEnvironment.Register(RandomKey, RandomGenerator) Method

Registers a random number generator under a specific [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey').  
If a generator was previously registered with the same key, it will be replaced.

```csharp
public void Register(BeeneticToolkit.Random.RandomKey key, BeeneticToolkit.Random.RandomGenerator generator);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomEnvironment.Register(BeeneticToolkit.Random.RandomKey,BeeneticToolkit.Random.RandomGenerator).key'></a>

`key` [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey')

The strongly typed key to associate with the generator.

<a name='BeeneticToolkit.Random.RandomEnvironment.Register(BeeneticToolkit.Random.RandomKey,BeeneticToolkit.Random.RandomGenerator).generator'></a>

`generator` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The generator instance to register.

### Remarks
If [Current](RandomEnvironment.Current.md 'BeeneticToolkit.Random.RandomEnvironment.Current') has not yet been assigned, it will be set to the newly registered generator.