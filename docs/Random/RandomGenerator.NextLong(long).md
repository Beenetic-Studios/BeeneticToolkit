#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

## RandomGenerator.NextLong(long) Method

Generates a pseudo-random long integer between 0 (inclusive) and the specified maximum (exclusive).  
It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [maxExclusive](RandomGenerator.NextLong(long).md#BeeneticToolkit.Random.RandomGenerator.NextLong(long).maxExclusive 'BeeneticToolkit.Random.RandomGenerator.NextLong(long).maxExclusive') is less than or equal to 0.

```csharp
public virtual long NextLong(long maxExclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomGenerator.NextLong(long).maxExclusive'></a>

`maxExclusive` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

The upper bound (exclusive) of the random long number to be generated. Must be greater than 0.

Implements [NextLong(long)](IRandomGenerator.NextLong(long).md 'BeeneticToolkit.Random.IRandomGenerator.NextLong(long)')

#### Returns
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
A random long integer in the range [0, [maxExclusive](RandomGenerator.NextLong(long).md#BeeneticToolkit.Random.RandomGenerator.NextLong(long).maxExclusive 'BeeneticToolkit.Random.RandomGenerator.NextLong(long).maxExclusive')).

#### Exceptions

[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
Thrown when[maxExclusive](RandomGenerator.NextLong(long).md#BeeneticToolkit.Random.RandomGenerator.NextLong(long).maxExclusive 'BeeneticToolkit.Random.RandomGenerator.NextLong(long).maxExclusive') is less than or equal to 0.