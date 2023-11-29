#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomNumberGenerator](IRandomNumberGenerator.md 'BeeneticToolkit.Random.IRandomNumberGenerator')

## IRandomNumberGenerator.NextBytes(int, byte, byte) Method

Generates a random byte array of a specified length, with each byte within a specified range.

```csharp
byte[] NextBytes(int length, byte min, byte max);
```
#### Parameters

<a name='BeeneticToolkit.Random.IRandomNumberGenerator.NextBytes(int,byte,byte).length'></a>

`length` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The length of the byte array to generate.

<a name='BeeneticToolkit.Random.IRandomNumberGenerator.NextBytes(int,byte,byte).min'></a>

`min` [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')

The inclusive lower bound of the byte range.

<a name='BeeneticToolkit.Random.IRandomNumberGenerator.NextBytes(int,byte,byte).max'></a>

`max` [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')

The exclusive upper bound of the byte range.

#### Returns
[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
A random byte array of the specified length, with each byte within the specified range.