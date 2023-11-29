#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomNumberGenerator](IRandomNumberGenerator.md 'BeeneticToolkit.Random.IRandomNumberGenerator')

## IRandomNumberGenerator.NextGaussian(double, double) Method

Returns a random double that follows a Gaussian (normal) distribution with the specified mean and standard deviation.

```csharp
double NextGaussian(double mean, double stdDev);
```
#### Parameters

<a name='BeeneticToolkit.Random.IRandomNumberGenerator.NextGaussian(double,double).mean'></a>

`mean` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The mean of the Gaussian distribution.

<a name='BeeneticToolkit.Random.IRandomNumberGenerator.NextGaussian(double,double).stdDev'></a>

`stdDev` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The standard deviation of the Gaussian distribution. Must be non-negative.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
A normally distributed random double with the specified mean and standard deviation.