#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomGenerator](IRandomGenerator.md 'BeeneticToolkit.Random.IRandomGenerator')

## IRandomGenerator.NextLong(long) Method

Generates a non-negative random long integer that is less than the specified maximum.

```csharp
long NextLong(long maxExclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.IRandomGenerator.NextLong(long).maxExclusive'></a>

`maxExclusive` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

The exclusive upper bound of the random number to generate. Must be greater than 0.

#### Returns
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
A random long integer in the range [0, [maxExclusive](IRandomGenerator.NextLong(long).md#BeeneticToolkit.Random.IRandomGenerator.NextLong(long).maxExclusive 'BeeneticToolkit.Random.IRandomGenerator.NextLong(long).maxExclusive')).