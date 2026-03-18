#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngManager](RngManager.md 'BeeneticToolkit.Random.RngManager')

## RngManager.Register(RngRole, RandomGenerator) Method

Registers a random number generator under a specific [RngRole](RngRole.md 'BeeneticToolkit.Random.RngRole').  
If a generator was previously registered for the same role, it will be replaced.

```csharp
public static void Register(BeeneticToolkit.Random.RngRole role, BeeneticToolkit.Random.RandomGenerator generator);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngManager.Register(BeeneticToolkit.Random.RngRole,BeeneticToolkit.Random.RandomGenerator).role'></a>

`role` [RngRole](RngRole.md 'BeeneticToolkit.Random.RngRole')

The role to associate with the generator.

<a name='BeeneticToolkit.Random.RngManager.Register(BeeneticToolkit.Random.RngRole,BeeneticToolkit.Random.RandomGenerator).generator'></a>

`generator` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The generator instance to register.