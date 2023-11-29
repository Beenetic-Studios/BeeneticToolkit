#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomNumberGeneratorBase](RandomNumberGeneratorBase.md 'BeeneticToolkit.Random.RandomNumberGeneratorBase')

## RandomNumberGeneratorBase.NextInt(int, int) Method

Generates a pseudo-random integer between the specified minimum (inclusive) and maximum (exclusive).  
It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [minInclusive](RandomNumberGeneratorBase.NextInt(int,int).md#BeeneticToolkit.Random.RandomNumberGeneratorBase.NextInt(int,int).minInclusive 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextInt(int, int).minInclusive') is greater than or equal to [maxExclusive](RandomNumberGeneratorBase.NextInt(int,int).md#BeeneticToolkit.Random.RandomNumberGeneratorBase.NextInt(int,int).maxExclusive 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextInt(int, int).maxExclusive').

```csharp
public virtual int NextInt(int minInclusive, int maxExclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomNumberGeneratorBase.NextInt(int,int).minInclusive'></a>

`minInclusive` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The lower bound (inclusive) of the random number to be generated.

<a name='BeeneticToolkit.Random.RandomNumberGeneratorBase.NextInt(int,int).maxExclusive'></a>

`maxExclusive` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The upper bound (exclusive) of the random number to be generated. Must be greater than [minInclusive](RandomNumberGeneratorBase.NextInt(int,int).md#BeeneticToolkit.Random.RandomNumberGeneratorBase.NextInt(int,int).minInclusive 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextInt(int, int).minInclusive').

Implements [NextInt(int, int)](IRandomNumberGenerator.NextInt(int,int).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextInt(int, int)')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A random integer in the range [[minInclusive](RandomNumberGeneratorBase.NextInt(int,int).md#BeeneticToolkit.Random.RandomNumberGeneratorBase.NextInt(int,int).minInclusive 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextInt(int, int).minInclusive'), [maxExclusive](RandomNumberGeneratorBase.NextInt(int,int).md#BeeneticToolkit.Random.RandomNumberGeneratorBase.NextInt(int,int).maxExclusive 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextInt(int, int).maxExclusive')).

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [minInclusive](RandomNumberGeneratorBase.NextInt(int,int).md#BeeneticToolkit.Random.RandomNumberGeneratorBase.NextInt(int,int).minInclusive 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextInt(int, int).minInclusive') is greater than or equal to [maxExclusive](RandomNumberGeneratorBase.NextInt(int,int).md#BeeneticToolkit.Random.RandomNumberGeneratorBase.NextInt(int,int).maxExclusive 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextInt(int, int).maxExclusive').