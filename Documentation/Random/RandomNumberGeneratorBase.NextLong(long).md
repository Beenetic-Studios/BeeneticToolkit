#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomNumberGeneratorBase](RandomNumberGeneratorBase.md 'BeeneticToolkit.Random.RandomNumberGeneratorBase')

## RandomNumberGeneratorBase.NextLong(long) Method

Generates a pseudo-random long integer between 0 (inclusive) and the specified maximum (exclusive).  
It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [maxExclusive](RandomNumberGeneratorBase.NextLong(long).md#BeeneticToolkit.Random.RandomNumberGeneratorBase.NextLong(long).maxExclusive 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextLong(long).maxExclusive') is less than or equal to 0.

```csharp
public virtual long NextLong(long maxExclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomNumberGeneratorBase.NextLong(long).maxExclusive'></a>

`maxExclusive` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

The upper bound (exclusive) of the random long number to be generated. Must be greater than 0.

Implements [NextLong(long)](IRandomNumberGenerator.NextLong(long).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextLong(long)')

#### Returns
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
A random long integer in the range [0, [maxExclusive](RandomNumberGeneratorBase.NextLong(long).md#BeeneticToolkit.Random.RandomNumberGeneratorBase.NextLong(long).maxExclusive 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextLong(long).maxExclusive')).

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [maxExclusive](RandomNumberGeneratorBase.NextLong(long).md#BeeneticToolkit.Random.RandomNumberGeneratorBase.NextLong(long).maxExclusive 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextLong(long).maxExclusive') is less than or equal to 0.