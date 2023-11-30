#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomGenerator](IRandomGenerator.md 'BeeneticToolkit.Random.IRandomGenerator')

## IRandomGenerator.NextNormal(double, double) Method

Returns a random double that follows a normal distribution with the specified mean and standard deviation.

```csharp
double NextNormal(double mean, double stdDev);
```
#### Parameters

<a name='BeeneticToolkit.Random.IRandomGenerator.NextNormal(double,double).mean'></a>

`mean` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The mean of the Normal distribution.

<a name='BeeneticToolkit.Random.IRandomGenerator.NextNormal(double,double).stdDev'></a>

`stdDev` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The standard deviation of the Normal distribution. Must be non-negative.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
A normally distributed random double with the specified mean and standard deviation.