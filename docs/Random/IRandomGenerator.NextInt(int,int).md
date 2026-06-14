#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomGenerator](IRandomGenerator.md 'BeeneticToolkit.Random.IRandomGenerator')

## IRandomGenerator.NextInt(int, int) Method

Generates a random integer within the specified range.

```csharp
int NextInt(int minInclusive, int maxExclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.IRandomGenerator.NextInt(int,int).minInclusive'></a>

`minInclusive` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The inclusive lower bound of the random number to generate.

<a name='BeeneticToolkit.Random.IRandomGenerator.NextInt(int,int).maxExclusive'></a>

`maxExclusive` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The exclusive upper bound of the random number to generate.  
Must be greater than [minInclusive](IRandomGenerator.NextInt(int,int).md#BeeneticToolkit.Random.IRandomGenerator.NextInt(int,int).minInclusive 'BeeneticToolkit.Random.IRandomGenerator.NextInt(int, int).minInclusive').

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A random integer in the range  
[[minInclusive](IRandomGenerator.NextInt(int,int).md#BeeneticToolkit.Random.IRandomGenerator.NextInt(int,int).minInclusive 'BeeneticToolkit.Random.IRandomGenerator.NextInt(int, int).minInclusive'), [maxExclusive](IRandomGenerator.NextInt(int,int).md#BeeneticToolkit.Random.IRandomGenerator.NextInt(int,int).maxExclusive 'BeeneticToolkit.Random.IRandomGenerator.NextInt(int, int).maxExclusive')).