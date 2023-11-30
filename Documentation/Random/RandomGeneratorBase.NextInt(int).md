#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGeneratorBase](RandomGeneratorBase.md 'BeeneticToolkit.Random.RandomGeneratorBase')

## RandomGeneratorBase.NextInt(int) Method

Generates a pseudo-random integer between 0 (inclusive) and the specified maximum (exclusive).  
It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [maxExclusive](RandomGeneratorBase.NextInt(int).md#BeeneticToolkit.Random.RandomGeneratorBase.NextInt(int).maxExclusive 'BeeneticToolkit.Random.RandomGeneratorBase.NextInt(int).maxExclusive') is less than or equal to 0.

```csharp
public virtual int NextInt(int maxExclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomGeneratorBase.NextInt(int).maxExclusive'></a>

`maxExclusive` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The upper bound (exclusive) of the random number to be generated. Must be greater than 0.

Implements [NextInt(int)](IRandomGenerator.NextInt(int).md 'BeeneticToolkit.Random.IRandomGenerator.NextInt(int)')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A random integer in the range [0, [maxExclusive](RandomGeneratorBase.NextInt(int).md#BeeneticToolkit.Random.RandomGeneratorBase.NextInt(int).maxExclusive 'BeeneticToolkit.Random.RandomGeneratorBase.NextInt(int).maxExclusive')).

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [maxExclusive](RandomGeneratorBase.NextInt(int).md#BeeneticToolkit.Random.RandomGeneratorBase.NextInt(int).maxExclusive 'BeeneticToolkit.Random.RandomGeneratorBase.NextInt(int).maxExclusive') is less than or equal to 0.