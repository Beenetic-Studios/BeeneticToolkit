#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomNumberGeneratorBase](RandomNumberGeneratorBase.md 'BeeneticToolkit.Random.RandomNumberGeneratorBase')

## RandomNumberGeneratorBase.NextNormal() Method

Generates a normally distributed (Normal) random number with a default mean of 0.0 and standard deviation of 1.0.  
This method is an overload of the NextNormal method that uses default parameters to produce a standard Normal distribution.

```csharp
public virtual double NextNormal();
```

Implements [NextNormal()](IRandomNumberGenerator.NextNormal().md 'BeeneticToolkit.Random.IRandomNumberGenerator.NextNormal()')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
A random double number following the standard Normal distribution with a mean of 0.0 and a standard deviation of 1.0.