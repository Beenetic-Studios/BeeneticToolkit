#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomNumberGeneratorBase](RandomNumberGeneratorBase.md 'BeeneticToolkit.Random.RandomNumberGeneratorBase')

## RandomNumberGeneratorBase.NextDouble(double) Method

Generates a pseudo-random double between 0 (inclusive) and the specified maximum (inclusive).  
It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [maxInclusive](RandomNumberGeneratorBase.NextDouble(double).md#BeeneticToolkit.Random.RandomNumberGeneratorBase.NextDouble(double).maxInclusive 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextDouble(double).maxInclusive') is less than or equal to 0.

```csharp
public virtual double NextDouble(double maxInclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomNumberGeneratorBase.NextDouble(double).maxInclusive'></a>

`maxInclusive` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The upper bound (inclusive) of the random double number to be generated. Must be greater than 0.

Implements [NextDouble(double)](IRandomNumberGenerator.NextDouble(double).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextDouble(double)')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
A random double in the range [0, [maxInclusive](RandomNumberGeneratorBase.NextDouble(double).md#BeeneticToolkit.Random.RandomNumberGeneratorBase.NextDouble(double).maxInclusive 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextDouble(double).maxInclusive')].

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [maxInclusive](RandomNumberGeneratorBase.NextDouble(double).md#BeeneticToolkit.Random.RandomNumberGeneratorBase.NextDouble(double).maxInclusive 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextDouble(double).maxInclusive') is less than or equal to 0.