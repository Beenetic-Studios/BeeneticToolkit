#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomGenerator](IRandomGenerator.md 'BeeneticToolkit.Random.IRandomGenerator')

## IRandomGenerator.NextLong(long, long) Method

Generates a random long integer within the specified range.

```csharp
long NextLong(long minInclusive, long maxExclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.IRandomGenerator.NextLong(long,long).minInclusive'></a>

`minInclusive` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

The inclusive lower bound of the random number to generate.

<a name='BeeneticToolkit.Random.IRandomGenerator.NextLong(long,long).maxExclusive'></a>

`maxExclusive` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

The exclusive upper bound of the random number to generate.  
Must be greater than [minInclusive](IRandomGenerator.NextLong(long,long).md#BeeneticToolkit.Random.IRandomGenerator.NextLong(long,long).minInclusive 'BeeneticToolkit.Random.IRandomGenerator.NextLong(long, long).minInclusive').

#### Returns
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
A random long integer in the range  
[[minInclusive](IRandomGenerator.NextLong(long,long).md#BeeneticToolkit.Random.IRandomGenerator.NextLong(long,long).minInclusive 'BeeneticToolkit.Random.IRandomGenerator.NextLong(long, long).minInclusive'), [maxExclusive](IRandomGenerator.NextLong(long,long).md#BeeneticToolkit.Random.IRandomGenerator.NextLong(long,long).maxExclusive 'BeeneticToolkit.Random.IRandomGenerator.NextLong(long, long).maxExclusive')).