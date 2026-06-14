#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomManager](RandomManager.md 'BeeneticToolkit.Random.RandomManager')

## RandomManager.Current Property

Gets the current generator of the [Default](RandomManager.Default.md 'BeeneticToolkit.Random.RandomManager.Default') environment. This is the generator used by  
the selection helpers when no explicit generator is supplied.

```csharp
public static BeeneticToolkit.Random.RandomGenerator Current { get; }
```

#### Property Value
[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown only if the default environment has no current generator, which cannot happen through the public API.