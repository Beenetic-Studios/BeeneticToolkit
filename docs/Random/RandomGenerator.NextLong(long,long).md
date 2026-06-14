#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

## RandomGenerator.NextLong(long, long) Method

Generates a pseudo-random long integer between the specified minimum (inclusive) and maximum (exclusive).  
It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [minInclusive](RandomGenerator.NextLong(long,long).md#BeeneticToolkit.Random.RandomGenerator.NextLong(long,long).minInclusive 'BeeneticToolkit.Random.RandomGenerator.NextLong(long, long).minInclusive') is greater than or equal to [maxExclusive](RandomGenerator.NextLong(long,long).md#BeeneticToolkit.Random.RandomGenerator.NextLong(long,long).maxExclusive 'BeeneticToolkit.Random.RandomGenerator.NextLong(long, long).maxExclusive').

```csharp
public virtual long NextLong(long minInclusive, long maxExclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomGenerator.NextLong(long,long).minInclusive'></a>

`minInclusive` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

The lower bound (inclusive) of the random long number to be generated.

<a name='BeeneticToolkit.Random.RandomGenerator.NextLong(long,long).maxExclusive'></a>

`maxExclusive` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

The upper bound (exclusive) of the random long number to be generated. Must be greater than [minInclusive](RandomGenerator.NextLong(long,long).md#BeeneticToolkit.Random.RandomGenerator.NextLong(long,long).minInclusive 'BeeneticToolkit.Random.RandomGenerator.NextLong(long, long).minInclusive').

Implements [NextLong(long, long)](IRandomGenerator.NextLong(long,long).md 'BeeneticToolkit.Random.IRandomGenerator.NextLong(long, long)')

#### Returns
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
A random long integer in the range [[minInclusive](RandomGenerator.NextLong(long,long).md#BeeneticToolkit.Random.RandomGenerator.NextLong(long,long).minInclusive 'BeeneticToolkit.Random.RandomGenerator.NextLong(long, long).minInclusive'), [maxExclusive](RandomGenerator.NextLong(long,long).md#BeeneticToolkit.Random.RandomGenerator.NextLong(long,long).maxExclusive 'BeeneticToolkit.Random.RandomGenerator.NextLong(long, long).maxExclusive')).

#### Exceptions

[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
Thrown when[minInclusive](RandomGenerator.NextLong(long,long).md#BeeneticToolkit.Random.RandomGenerator.NextLong(long,long).minInclusive 'BeeneticToolkit.Random.RandomGenerator.NextLong(long, long).minInclusive') is greater than or equal to [maxExclusive](RandomGenerator.NextLong(long,long).md#BeeneticToolkit.Random.RandomGenerator.NextLong(long,long).maxExclusive 'BeeneticToolkit.Random.RandomGenerator.NextLong(long, long).maxExclusive').