#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random')

## RngRole Enum

Represents the roles or contexts in which a random number generator can be used.  
This provides type-safe identifiers for registering and retrieving  
random number generators via the [RngManager](RngManager.md 'BeeneticToolkit.Random.RngManager').

```csharp
public enum RngRole
```
### Fields

<a name='BeeneticToolkit.Random.RngRole.AI'></a>

`AI` 1

A generator dedicated to AI-related randomness,  
such as decision-making, behavior trees, or procedural logic.

<a name='BeeneticToolkit.Random.RngRole.Default'></a>

`Default` 0

The default global random number generator role.

<a name='BeeneticToolkit.Random.RngRole.Gameplay'></a>

`Gameplay` 2

A generator dedicated to core gameplay randomness,  
such as combat rolls, item drops, or level generation.

<a name='BeeneticToolkit.Random.RngRole.Testing'></a>

`Testing` 3

A generator reserved for testing or debugging scenarios,  
where predictable or isolated random behavior is desired.

### Remarks
Registering a generator under a key or role will overwrite any existing generator for that identifier.  
This behavior is consistent across all registration methods.