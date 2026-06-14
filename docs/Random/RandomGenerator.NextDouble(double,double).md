#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

## RandomGenerator.NextDouble(double, double) Method

Generates a pseudo-random double between the specified minimum (inclusive) and maximum (inclusive).  
It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if [minInclusive](RandomGenerator.NextDouble(double,double).md#BeeneticToolkit.Random.RandomGenerator.NextDouble(double,double).minInclusive 'BeeneticToolkit.Random.RandomGenerator.NextDouble(double, double).minInclusive') is greater than or equal to [maxInclusive](RandomGenerator.NextDouble(double,double).md#BeeneticToolkit.Random.RandomGenerator.NextDouble(double,double).maxInclusive 'BeeneticToolkit.Random.RandomGenerator.NextDouble(double, double).maxInclusive').

```csharp
public virtual double NextDouble(double minInclusive, double maxInclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomGenerator.NextDouble(double,double).minInclusive'></a>

`minInclusive` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The lower bound (inclusive) of the random double number to be generated.

<a name='BeeneticToolkit.Random.RandomGenerator.NextDouble(double,double).maxInclusive'></a>

`maxInclusive` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The upper bound (inclusive) of the random double number to be generated. Must be greater than [minInclusive](RandomGenerator.NextDouble(double,double).md#BeeneticToolkit.Random.RandomGenerator.NextDouble(double,double).minInclusive 'BeeneticToolkit.Random.RandomGenerator.NextDouble(double, double).minInclusive').

Implements [NextDouble(double, double)](IRandomGenerator.NextDouble(double,double).md 'BeeneticToolkit.Random.IRandomGenerator.NextDouble(double, double)')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
A random double in the range [[minInclusive](RandomGenerator.NextDouble(double,double).md#BeeneticToolkit.Random.RandomGenerator.NextDouble(double,double).minInclusive 'BeeneticToolkit.Random.RandomGenerator.NextDouble(double, double).minInclusive'), [maxInclusive](RandomGenerator.NextDouble(double,double).md#BeeneticToolkit.Random.RandomGenerator.NextDouble(double,double).maxInclusive 'BeeneticToolkit.Random.RandomGenerator.NextDouble(double, double).maxInclusive')].

#### Exceptions

[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
Thrown when[minInclusive](RandomGenerator.NextDouble(double,double).md#BeeneticToolkit.Random.RandomGenerator.NextDouble(double,double).minInclusive 'BeeneticToolkit.Random.RandomGenerator.NextDouble(double, double).minInclusive') is greater than or equal to [maxInclusive](RandomGenerator.NextDouble(double,double).md#BeeneticToolkit.Random.RandomGenerator.NextDouble(double,double).maxInclusive 'BeeneticToolkit.Random.RandomGenerator.NextDouble(double, double).maxInclusive').