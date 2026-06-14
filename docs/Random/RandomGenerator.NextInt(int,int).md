#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

## RandomGenerator.NextInt(int, int) Method

Generates a pseudo-random integer between the specified minimum (inclusive) and maximum (exclusive).  
It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [minInclusive](RandomGenerator.NextInt(int,int).md#BeeneticToolkit.Random.RandomGenerator.NextInt(int,int).minInclusive 'BeeneticToolkit.Random.RandomGenerator.NextInt(int, int).minInclusive') is greater than or equal to [maxExclusive](RandomGenerator.NextInt(int,int).md#BeeneticToolkit.Random.RandomGenerator.NextInt(int,int).maxExclusive 'BeeneticToolkit.Random.RandomGenerator.NextInt(int, int).maxExclusive').

```csharp
public virtual int NextInt(int minInclusive, int maxExclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomGenerator.NextInt(int,int).minInclusive'></a>

`minInclusive` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The lower bound (inclusive) of the random number to be generated.

<a name='BeeneticToolkit.Random.RandomGenerator.NextInt(int,int).maxExclusive'></a>

`maxExclusive` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The upper bound (exclusive) of the random number to be generated. Must be greater than [minInclusive](RandomGenerator.NextInt(int,int).md#BeeneticToolkit.Random.RandomGenerator.NextInt(int,int).minInclusive 'BeeneticToolkit.Random.RandomGenerator.NextInt(int, int).minInclusive').

Implements [NextInt(int, int)](IRandomGenerator.NextInt(int,int).md 'BeeneticToolkit.Random.IRandomGenerator.NextInt(int, int)')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A random integer in the range [[minInclusive](RandomGenerator.NextInt(int,int).md#BeeneticToolkit.Random.RandomGenerator.NextInt(int,int).minInclusive 'BeeneticToolkit.Random.RandomGenerator.NextInt(int, int).minInclusive'), [maxExclusive](RandomGenerator.NextInt(int,int).md#BeeneticToolkit.Random.RandomGenerator.NextInt(int,int).maxExclusive 'BeeneticToolkit.Random.RandomGenerator.NextInt(int, int).maxExclusive')).

#### Exceptions

[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
Thrown when[minInclusive](RandomGenerator.NextInt(int,int).md#BeeneticToolkit.Random.RandomGenerator.NextInt(int,int).minInclusive 'BeeneticToolkit.Random.RandomGenerator.NextInt(int, int).minInclusive') is greater than or equal to [maxExclusive](RandomGenerator.NextInt(int,int).md#BeeneticToolkit.Random.RandomGenerator.NextInt(int,int).maxExclusive 'BeeneticToolkit.Random.RandomGenerator.NextInt(int, int).maxExclusive').