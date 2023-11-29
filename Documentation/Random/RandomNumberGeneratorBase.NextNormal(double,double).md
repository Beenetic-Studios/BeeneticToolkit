#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomNumberGeneratorBase](RandomNumberGeneratorBase.md 'BeeneticToolkit.Random.RandomNumberGeneratorBase')

## RandomNumberGeneratorBase.NextNormal(double, double) Method

Generates a normally distributed (Normal) random number with a specified mean and standard deviation.  
This method uses the Box-Muller transform to produce a Normal distribution.  
It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if the standard deviation is negative.

```csharp
public virtual double NextNormal(double mean, double stDev);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomNumberGeneratorBase.NextNormal(double,double).mean'></a>

`mean` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The mean (μ) of the Normal distribution.

<a name='BeeneticToolkit.Random.RandomNumberGeneratorBase.NextNormal(double,double).stDev'></a>

`stDev` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The standard deviation (σ) of the Normal distribution. Must be non-negative.

Implements [NextNormal(double, double)](IRandomNumberGenerator.NextNormal(double,double).md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextNormal(double, double)')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
A random double number following the Normal distribution with the specified mean and standard deviation.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [stDev](RandomNumberGeneratorBase.NextNormal(double,double).md#BeeneticToolkit.Random.RandomNumberGeneratorBase.NextNormal(double,double).stDev 'BeeneticToolkit.Random.RandomNumberGeneratorBase.NextNormal(double, double).stDev') is negative.