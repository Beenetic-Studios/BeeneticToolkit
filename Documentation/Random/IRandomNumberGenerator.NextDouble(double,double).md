#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomNumberGenerator](IRandomNumberGenerator.md 'BeeneticToolkit.Random.IRandomNumberGenerator')

## IRandomNumberGenerator.NextDouble(double, double) Method

Returns a random double within a specified range.

```csharp
double NextDouble(double minInclusive, double maxExclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.IRandomNumberGenerator.NextDouble(double,double).minInclusive'></a>

`minInclusive` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The inclusive lower bound of the random number returned.

<a name='BeeneticToolkit.Random.IRandomNumberGenerator.NextDouble(double,double).maxExclusive'></a>

`maxExclusive` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
A random double that is within the range of minValue and maxValue.