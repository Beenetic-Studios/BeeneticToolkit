#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomGenerator](IRandomGenerator.md 'BeeneticToolkit.Random.IRandomGenerator')

## IRandomGenerator.NextDouble(double) Method

Generates a non-negative random double that is less than or equal to the specified maximum.

```csharp
double NextDouble(double maxInclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.IRandomGenerator.NextDouble(double).maxInclusive'></a>

`maxInclusive` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The inclusive upper bound of the random number to generate. Must be greater than 0.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
A random double in the range [0, [maxInclusive](IRandomGenerator.NextDouble(double).md#BeeneticToolkit.Random.IRandomGenerator.NextDouble(double).maxInclusive 'BeeneticToolkit.Random.IRandomGenerator.NextDouble(double).maxInclusive')].