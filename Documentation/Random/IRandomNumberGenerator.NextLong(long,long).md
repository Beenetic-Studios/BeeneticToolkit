#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomNumberGenerator](IRandomNumberGenerator.md 'BeeneticToolkit.Random.IRandomNumberGenerator')

## IRandomNumberGenerator.NextLong(long, long) Method

Returns a random long integer within a specified range.

```csharp
long NextLong(long minInclusive, long maxExclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.IRandomNumberGenerator.NextLong(long,long).minInclusive'></a>

`minInclusive` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

The inclusive lower bound of the random number returned.

<a name='BeeneticToolkit.Random.IRandomNumberGenerator.NextLong(long,long).maxExclusive'></a>

`maxExclusive` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.

#### Returns
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
A random long integer that is within the range of minValue and maxValue.