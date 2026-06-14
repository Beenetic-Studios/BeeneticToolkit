#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomGenerator](IRandomGenerator.md 'BeeneticToolkit.Random.IRandomGenerator')

## IRandomGenerator.NextInt(int) Method

Generates a non-negative random integer that is less than the specified maximum.

```csharp
int NextInt(int maxExclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.IRandomGenerator.NextInt(int).maxExclusive'></a>

`maxExclusive` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The exclusive upper bound of the random number to generate. Must be greater than 0.

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A random integer in the range [0, [maxExclusive](IRandomGenerator.NextInt(int).md#BeeneticToolkit.Random.IRandomGenerator.NextInt(int).maxExclusive 'BeeneticToolkit.Random.IRandomGenerator.NextInt(int).maxExclusive')).