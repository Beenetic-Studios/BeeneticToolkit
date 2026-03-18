#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment')

## RngEnvironment.Register(string, RandomGenerator) Method

Registers a random number generator under a specific string key.  
If a generator was previously registered with the same key, it will be replaced.

```csharp
public void Register(string key, BeeneticToolkit.Random.RandomGenerator generator);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngEnvironment.Register(string,BeeneticToolkit.Random.RandomGenerator).key'></a>

`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The key to associate with the generator.

<a name='BeeneticToolkit.Random.RngEnvironment.Register(string,BeeneticToolkit.Random.RandomGenerator).generator'></a>

`generator` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The generator instance to register.

### Remarks
If [Current](RngEnvironment.Current.md 'BeeneticToolkit.Random.RngEnvironment.Current') has not yet been assigned, it will be set to the newly registered generator.