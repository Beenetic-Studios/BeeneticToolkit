#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGeneratorBase](RandomGeneratorBase.md 'BeeneticToolkit.Random.RandomGeneratorBase')

## RandomGeneratorBase.NextDouble(double) Method

Generates a pseudo-random double between 0 (inclusive) and the specified maximum (inclusive).  
It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [maxInclusive](RandomGeneratorBase.NextDouble(double).md#BeeneticToolkit.Random.RandomGeneratorBase.NextDouble(double).maxInclusive 'BeeneticToolkit.Random.RandomGeneratorBase.NextDouble(double).maxInclusive') is less than or equal to 0.

```csharp
public virtual double NextDouble(double maxInclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomGeneratorBase.NextDouble(double).maxInclusive'></a>

`maxInclusive` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The upper bound (inclusive) of the random double number to be generated. Must be greater than 0.

Implements [NextDouble(double)](IRandomGenerator.NextDouble(double).md 'BeeneticToolkit.Random.IRandomGenerator.NextDouble(double)')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
A random double in the range [0, [maxInclusive](RandomGeneratorBase.NextDouble(double).md#BeeneticToolkit.Random.RandomGeneratorBase.NextDouble(double).maxInclusive 'BeeneticToolkit.Random.RandomGeneratorBase.NextDouble(double).maxInclusive')].

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [maxInclusive](RandomGeneratorBase.NextDouble(double).md#BeeneticToolkit.Random.RandomGeneratorBase.NextDouble(double).maxInclusive 'BeeneticToolkit.Random.RandomGeneratorBase.NextDouble(double).maxInclusive') is less than or equal to 0.