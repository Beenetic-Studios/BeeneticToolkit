#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomNumberGeneratorBase](RandomNumberGeneratorBase.md 'BeeneticToolkit.Random.RandomNumberGeneratorBase')

## RandomNumberGeneratorBase.NextGaussian(double, double) Method

Generates a normally distributed (Gaussian) random number with a specified mean and standard deviation.  
This method uses the Box-Muller transform to produce a Gaussian distribution.  
It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if the standard deviation is negative.

```csharp
public virtual double NextGaussian(double mean, double stDev);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomNumberGeneratorBase.NextGaussian(double,double).mean'></a>

`mean` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The mean (μ) of the Gaussian distribution.

<a name='BeeneticToolkit.Random.RandomNumberGeneratorBase.NextGaussian(double,double).stDev'></a>

`stDev` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The standard deviation (σ) of the Gaussian distribution. Must be non-negative.

Implements [NextGaussian(double, double)](IRandomNumberGenerator.NextGaussian(double,double).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextGaussian(double, double)')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
A random double number following the Gaussian distribution with the specified mean and standard deviation.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [stDev](RandomNumberGeneratorBase.NextGaussian(double,double).md#BeeneticToolkit.Random.RandomNumberGeneratorBase.NextGaussian(double,double).stDev 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextGaussian(double, double).stDev') is negative.