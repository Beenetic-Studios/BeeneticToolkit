#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomGenerator](IRandomGenerator.md 'BeeneticToolkit.Random.IRandomGenerator')

## IRandomGenerator.NextBool(float) Method

Generates a random boolean value using the specified probability of returning [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

```csharp
bool NextBool(float probability);
```
#### Parameters

<a name='BeeneticToolkit.Random.IRandomGenerator.NextBool(float).probability'></a>

`probability` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The probability of returning [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool'). Must be between 0.0 and 1.0.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
A random boolean value influenced by the specified probability.