#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGeneratorBase](RandomGeneratorBase.md 'BeeneticToolkit.Random.RandomGeneratorBase')

## RandomGeneratorBase.NextNormal(double, double) Method

Generates a normally distributed random number with a specified mean and standard deviation.  
This method uses the Box-Muller transform to produce a normal distribution.  
It throws an [System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException') if the standard deviation is negative.

```csharp
public virtual double NextNormal(double mean, double stDev);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomGeneratorBase.NextNormal(double,double).mean'></a>

`mean` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The mean (μ) of the normal distribution.

<a name='BeeneticToolkit.Random.RandomGeneratorBase.NextNormal(double,double).stDev'></a>

`stDev` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The standard deviation (σ) of the normal distribution. Must be non-negative.

Implements [NextNormal(double, double)](IRandomGenerator.NextNormal(double,double).md 'BeeneticToolkit.Random.IRandomGenerator.NextNormal(double, double)')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
A random double number following the normal distribution with the specified mean and standard deviation.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [stDev](RandomGeneratorBase.NextNormal(double,double).md#BeeneticToolkit.Random.RandomGeneratorBase.NextNormal(double,double).stDev 'BeeneticToolkit.Random.RandomGeneratorBase.NextNormal(double, double).stDev') is negative.