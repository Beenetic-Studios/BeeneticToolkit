#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomGenerator](IRandomGenerator.md 'BeeneticToolkit.Random.IRandomGenerator')

## IRandomGenerator.NextDouble(double) Method

Returns a non-negative random double that is less than the specified maximum.

```csharp
double NextDouble(double maxExclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.IRandomGenerator.NextDouble(double).maxExclusive'></a>

`maxExclusive` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The exclusive upper bound of the random number to be generated. maxValue must be greater than or equal to 0.0.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
A non-negative random double that is less than maxValue.