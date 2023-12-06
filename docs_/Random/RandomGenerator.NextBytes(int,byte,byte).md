#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

## RandomGenerator.NextBytes(int, byte, byte) Method

Generates a random byte array of a specified length, with each byte within a specified range.

```csharp
public byte[] NextBytes(int length, byte minInclusive, byte maxExclusive);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomGenerator.NextBytes(int,byte,byte).length'></a>

`length` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The length of the byte array to generate.

<a name='BeeneticToolkit.Random.RandomGenerator.NextBytes(int,byte,byte).minInclusive'></a>

`minInclusive` [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')

The inclusive lower bound of the byte range.

<a name='BeeneticToolkit.Random.RandomGenerator.NextBytes(int,byte,byte).maxExclusive'></a>

`maxExclusive` [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')

The exclusive upper bound of the byte range.

Implements [NextBytes(int, byte, byte)](IRandomGenerator.NextBytes(int,byte,byte).md 'BeeneticToolkit.Random.IRandomGenerator.NextBytes(int, byte, byte)')

#### Returns
[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
A random byte array of the specified length, with each byte within the specified range.