#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomGenerator](IRandomGenerator.md 'BeeneticToolkit.Random.IRandomGenerator')

## IRandomGenerator.NextDouble(double, double) Method

Generates a random double within the specified range.

```csharp
double NextDouble(double minInclusive, double maxInclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.IRandomGenerator.NextDouble(double,double).minInclusive'></a>

`minInclusive` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The inclusive lower bound of the random number to generate.

<a name='BeeneticToolkit.Random.IRandomGenerator.NextDouble(double,double).maxInclusive'></a>

`maxInclusive` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The inclusive upper bound of the random number to generate.  
Must be greater than [minInclusive](IRandomGenerator.NextDouble(double,double).md#BeeneticToolkit.Random.IRandomGenerator.NextDouble(double,double).minInclusive 'BeeneticToolkit.Random.IRandomGenerator.NextDouble(double, double).minInclusive').

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
A random double in the range  
[[minInclusive](IRandomGenerator.NextDouble(double,double).md#BeeneticToolkit.Random.IRandomGenerator.NextDouble(double,double).minInclusive 'BeeneticToolkit.Random.IRandomGenerator.NextDouble(double, double).minInclusive'), [maxInclusive](IRandomGenerator.NextDouble(double,double).md#BeeneticToolkit.Random.IRandomGenerator.NextDouble(double,double).maxInclusive 'BeeneticToolkit.Random.IRandomGenerator.NextDouble(double, double).maxInclusive')].