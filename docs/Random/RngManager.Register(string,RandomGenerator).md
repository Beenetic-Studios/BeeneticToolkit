#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngManager](RngManager.md 'BeeneticToolkit.Random.RngManager')

## RngManager.Register(string, RandomGenerator) Method

Registers a random number generator under a custom string key.  
This is useful for experimental, modding, or ad hoc scenarios  
where predefined [RngRole](RngRole.md 'BeeneticToolkit.Random.RngRole') values are insufficient.  
If a generator was previously registered with the same key, it will be replaced.

```csharp
public static void Register(string key, BeeneticToolkit.Random.RandomGenerator generator);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngManager.Register(string,BeeneticToolkit.Random.RandomGenerator).key'></a>

`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The custom key to associate with the generator.

<a name='BeeneticToolkit.Random.RngManager.Register(string,BeeneticToolkit.Random.RandomGenerator).generator'></a>

`generator` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The generator instance to register.