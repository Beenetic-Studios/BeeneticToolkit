#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomManager](RandomManager.md 'BeeneticToolkit.Random.RandomManager')

## RandomManager.Default Property

Gets the default global [RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment'). Use it to register and retrieve generators,  
e.g. `RandomManager.Default.CreateAndRegister("enemies")`.

```csharp
public static BeeneticToolkit.Random.RandomEnvironment Default { get; }
```

#### Property Value
[RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment')