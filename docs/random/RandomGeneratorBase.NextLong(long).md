#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGeneratorBase](RandomGeneratorBase.md 'BeeneticToolkit.Random.RandomGeneratorBase')

## RandomGeneratorBase.NextLong(long) Method

Generates a pseudo-random long integer between 0 (inclusive) and the specified maximum (exclusive).  
It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [maxExclusive](RandomGeneratorBase.NextLong(long).md#BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long).maxExclusive 'BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long).maxExclusive') is less than or equal to 0.

```csharp
public virtual long NextLong(long maxExclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long).maxExclusive'></a>

`maxExclusive` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

The upper bound (exclusive) of the random long number to be generated. Must be greater than 0.

Implements [NextLong(long)](IRandomGenerator.NextLong(long).md 'BeeneticToolkit.Random.IRandomGenerator.NextLong(long)')

#### Returns
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
A random long integer in the range [0, [maxExclusive](RandomGeneratorBase.NextLong(long).md#BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long).maxExclusive 'BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long).maxExclusive')).

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [maxExclusive](RandomGeneratorBase.NextLong(long).md#BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long).maxExclusive 'BeeneticToolkit.Random.RandomGeneratorBase.NextLong(long).maxExclusive') is less than or equal to 0.