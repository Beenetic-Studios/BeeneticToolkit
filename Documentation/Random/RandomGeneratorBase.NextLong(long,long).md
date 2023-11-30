#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGeneratorBase](RandomGeneratorBase.md 'BeeneticToolkit.Random.RandomGeneratorBase')

## RandomGeneratorBase.NextLong(long, long) Method

Generates a pseudo-random long integer between the specified minimum (inclusive) and maximum (exclusive).  
It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [minInclusive](RandomGeneratorBase.NextLong(long,long).md#BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long,long).minInclusive 'BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long, long).minInclusive') is greater than or equal to [maxExclusive](RandomGeneratorBase.NextLong(long,long).md#BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long,long).maxExclusive 'BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long, long).maxExclusive').

```csharp
public virtual long NextLong(long minInclusive, long maxExclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long,long).minInclusive'></a>

`minInclusive` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

The lower bound (inclusive) of the random long number to be generated.

<a name='BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long,long).maxExclusive'></a>

`maxExclusive` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

The upper bound (exclusive) of the random long number to be generated. Must be greater than [minInclusive](RandomGeneratorBase.NextLong(long,long).md#BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long,long).minInclusive 'BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long, long).minInclusive').

Implements [NextLong(long, long)](IRandomGenerator.NextLong(long,long).md 'BeeneticToolkit.Random.IRandomGenerator.NextLong(long, long)')

#### Returns
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
A random long integer in the range [[minInclusive](RandomGeneratorBase.NextLong(long,long).md#BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long,long).minInclusive 'BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long, long).minInclusive'), [maxExclusive](RandomGeneratorBase.NextLong(long,long).md#BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long,long).maxExclusive 'BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long, long).maxExclusive')).

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [minInclusive](RandomGeneratorBase.NextLong(long,long).md#BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long,long).minInclusive 'BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long, long).minInclusive') is greater than or equal to [maxExclusive](RandomGeneratorBase.NextLong(long,long).md#BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long,long).maxExclusive 'BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long, long).maxExclusive').