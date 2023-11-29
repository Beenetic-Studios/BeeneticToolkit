#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomNumberGenerator](IRandomNumberGenerator.md 'BeeneticToolkit.Random.IRandomNumberGenerator')

## IRandomNumberGenerator.NextLong(long) Method

Returns a non-negative random long integer that is less than the specified maximum.

```csharp
long NextLong(long maxExclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.IRandomNumberGenerator.NextLong(long).maxExclusive'></a>

`maxExclusive` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

The exclusive upper bound of the random number to be generated. maxValue must be greater than or equal to 0.

#### Returns
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
A non-negative random long integer that is less than maxValue.