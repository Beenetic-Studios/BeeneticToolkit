#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment')

## RngEnvironment.Register(RngKey, RandomGenerator) Method

Registers a random number generator under a specific [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey').  
If a generator was previously registered with the same key, it will be replaced.

```csharp
public void Register(BeeneticToolkit.Random.RngKey key, BeeneticToolkit.Random.RandomGenerator generator);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngEnvironment.Register(BeeneticToolkit.Random.RngKey,BeeneticToolkit.Random.RandomGenerator).key'></a>

`key` [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey')

The strongly typed key to associate with the generator.

<a name='BeeneticToolkit.Random.RngEnvironment.Register(BeeneticToolkit.Random.RngKey,BeeneticToolkit.Random.RandomGenerator).generator'></a>

`generator` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The generator instance to register.

### Remarks
If [Current](RngEnvironment.Current.md 'BeeneticToolkit.Random.RngEnvironment.Current') has not yet been assigned, it will be set to the newly registered generator.