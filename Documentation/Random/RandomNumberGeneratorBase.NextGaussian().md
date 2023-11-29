#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomNumberGeneratorBase](RandomNumberGeneratorBase.md 'BeeneticToolkit.Random.RandomNumberGeneratorBase')

## RandomNumberGeneratorBase.NextGaussian() Method

Generates a normally distributed (Gaussian) random number with a default mean of 0.0 and standard deviation of 1.0.  
This method is an overload of the NextGaussian method that uses default parameters to produce a standard Gaussian distribution.

```csharp
public virtual double NextGaussian();
```

Implements [NextGaussian()](IRandomNumberGenerator.NextGaussian().md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextGaussian()')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
A random double number following the standard Gaussian distribution with a mean of 0.0 and a standard deviation of 1.0.