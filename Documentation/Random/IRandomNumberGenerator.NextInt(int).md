#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomNumberGenerator](IRandomNumberGenerator.md 'BeeneticToolkit.Random.IRandomNumberGenerator')

## IRandomNumberGenerator.NextInt(int) Method

Returns a non-negative random integer that is less than the specified maximum.

```csharp
int NextInt(int maxExclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.IRandomNumberGenerator.NextInt(int).maxExclusive'></a>

`maxExclusive` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The exclusive upper bound of the random number to be generated. maxValue must be greater than or equal to 0.

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A non-negative random integer that is less than maxValue.