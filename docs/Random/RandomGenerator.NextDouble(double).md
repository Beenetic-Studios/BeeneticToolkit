#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

## RandomGenerator.NextDouble(double) Method

Generates a pseudo-random double between 0 (inclusive) and the specified maximum (inclusive).  
It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [maxInclusive](RandomGenerator.NextDouble(double).md#BeeneticToolkit.Random.RandomGenerator.NextDouble(double).maxInclusive 'BeeneticToolkit.Random.RandomGenerator.NextDouble(double).maxInclusive') is less than or equal to 0.

```csharp
public virtual double NextDouble(double maxInclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomGenerator.NextDouble(double).maxInclusive'></a>

`maxInclusive` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The upper bound (inclusive) of the random double number to be generated. Must be greater than 0.

Implements [NextDouble(double)](IRandomGenerator.NextDouble(double).md 'BeeneticToolkit.Random.IRandomGenerator.NextDouble(double)')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
A random double in the range [0, [maxInclusive](RandomGenerator.NextDouble(double).md#BeeneticToolkit.Random.RandomGenerator.NextDouble(double).maxInclusive 'BeeneticToolkit.Random.RandomGenerator.NextDouble(double).maxInclusive')].

#### Exceptions

[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
Thrown when[maxInclusive](RandomGenerator.NextDouble(double).md#BeeneticToolkit.Random.RandomGenerator.NextDouble(double).maxInclusive 'BeeneticToolkit.Random.RandomGenerator.NextDouble(double).maxInclusive') is less than or equal to 0.