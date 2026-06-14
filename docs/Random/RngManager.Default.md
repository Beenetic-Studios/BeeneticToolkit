#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngManager](RngManager.md 'BeeneticToolkit.Random.RngManager')

## RngManager.Default Property

Gets the default global [RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment'). Use it to register and retrieve generators,  
e.g. `RngManager.Default.CreateAndRegister("enemies")`.

```csharp
public static BeeneticToolkit.Random.RngEnvironment Default { get; }
```

#### Property Value
[RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment')