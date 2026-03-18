#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngManager](RngManager.md 'BeeneticToolkit.Random.RngManager')

## RngManager.SetCurrent(RngRole) Method

Sets the [Current](RngManager.Current.md 'BeeneticToolkit.Random.RngManager.Current') random number generator to the one  
associated with the specified [RngRole](RngRole.md 'BeeneticToolkit.Random.RngRole').

```csharp
public static void SetCurrent(BeeneticToolkit.Random.RngRole role);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngManager.SetCurrent(BeeneticToolkit.Random.RngRole).role'></a>

`role` [RngRole](RngRole.md 'BeeneticToolkit.Random.RngRole')

The role of the generator to make current.

#### Exceptions

[System.Collections.Generic.KeyNotFoundException](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException')  
Thrown if no generator has been registered for the given role.