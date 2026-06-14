#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngManager](RngManager.md 'BeeneticToolkit.Random.RngManager')

## RngManager.Current Property

Gets the current global random number generator.  
  
This property is initialized to [Default](RngRole.md#BeeneticToolkit.Random.RngRole.Default 'BeeneticToolkit.Random.RngRole.Default') during startup,  
and is therefore guaranteed to be non-null.  
  
It may be reassigned to any registered generator through  
[SetCurrent(RngRole)](RngManager.SetCurrent(RngRole).md 'BeeneticToolkit.Random.RngManager.SetCurrent(BeeneticToolkit.Random.RngRole)') or [SetCurrent(string)](RngManager.SetCurrent(string).md 'BeeneticToolkit.Random.RngManager.SetCurrent(string)').

```csharp
public static BeeneticToolkit.Random.RandomGenerator Current { get; }
```

#### Property Value
[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown only if the default generator has been removed, which cannot happen through the public API.