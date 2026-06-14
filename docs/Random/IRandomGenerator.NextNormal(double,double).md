#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomGenerator](IRandomGenerator.md 'BeeneticToolkit.Random.IRandomGenerator')

## IRandomGenerator.NextNormal(double, double) Method

Generates a random double from a normal distribution with the specified mean and standard deviation.

```csharp
double NextNormal(double mean, double stDev);
```
#### Parameters

<a name='BeeneticToolkit.Random.IRandomGenerator.NextNormal(double,double).mean'></a>

`mean` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The mean of the normal distribution.

<a name='BeeneticToolkit.Random.IRandomGenerator.NextNormal(double,double).stDev'></a>

`stDev` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The standard deviation of the normal distribution. Must be non-negative.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
A normally distributed random double with the specified mean and standard deviation.