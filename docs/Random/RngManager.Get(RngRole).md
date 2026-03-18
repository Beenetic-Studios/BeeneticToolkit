#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngManager](RngManager.md 'BeeneticToolkit.Random.RngManager')

## RngManager.Get(RngRole) Method

Retrieves a random number generator previously registered under a specific [RngRole](RngRole.md 'BeeneticToolkit.Random.RngRole').

```csharp
public static BeeneticToolkit.Random.RandomGenerator Get(BeeneticToolkit.Random.RngRole role);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngManager.Get(BeeneticToolkit.Random.RngRole).role'></a>

`role` [RngRole](RngRole.md 'BeeneticToolkit.Random.RngRole')

The role of the generator to retrieve.

#### Returns
[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')  
The generator associated with the specified role.

#### Exceptions

[System.Collections.Generic.KeyNotFoundException](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException')  
Thrown if no generator has been registered for the given role.