#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngManager](RngManager.md 'BeeneticToolkit.Random.RngManager')

## RngManager.TryGet(RngRole, RandomGenerator) Method

Attempts to retrieve a generator registered under the specified [RngRole](RngRole.md 'BeeneticToolkit.Random.RngRole'), without throwing.

```csharp
public static bool TryGet(BeeneticToolkit.Random.RngRole role, out BeeneticToolkit.Random.RandomGenerator generator);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngManager.TryGet(BeeneticToolkit.Random.RngRole,BeeneticToolkit.Random.RandomGenerator).role'></a>

`role` [RngRole](RngRole.md 'BeeneticToolkit.Random.RngRole')

The role of the generator to retrieve.

<a name='BeeneticToolkit.Random.RngManager.TryGet(BeeneticToolkit.Random.RngRole,BeeneticToolkit.Random.RandomGenerator).generator'></a>

`generator` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

When this method returns `true`, the registered generator; otherwise `null`.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if a generator was registered for [role](RngManager.TryGet(RngRole,RandomGenerator).md#BeeneticToolkit.Random.RngManager.TryGet(BeeneticToolkit.Random.RngRole,BeeneticToolkit.Random.RandomGenerator).role 'BeeneticToolkit.Random.RngManager.TryGet(BeeneticToolkit.Random.RngRole, BeeneticToolkit.Random.RandomGenerator).role'); otherwise `false`.