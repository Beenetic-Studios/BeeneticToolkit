#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomGenerator](IRandomGenerator.md 'BeeneticToolkit.Random.IRandomGenerator')

## IRandomGenerator.NextFloat(float, float) Method

Returns a random float within a specified range.

```csharp
float NextFloat(float minInclusive, float maxExclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.IRandomGenerator.NextFloat(float,float).minInclusive'></a>

`minInclusive` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The inclusive lower bound of the random number returned.

<a name='BeeneticToolkit.Random.IRandomGenerator.NextFloat(float,float).maxExclusive'></a>

`maxExclusive` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.

#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
A random float that is within the range of minValue and maxValue.