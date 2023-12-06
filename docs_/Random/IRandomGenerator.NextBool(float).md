#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomGenerator](IRandomGenerator.md 'BeeneticToolkit.Random.IRandomGenerator')

## IRandomGenerator.NextBool(float) Method

Returns a random boolean value with the probability of returning true specified by the input parameter.

```csharp
bool NextBool(float probability);
```
#### Parameters

<a name='BeeneticToolkit.Random.IRandomGenerator.NextBool(float).probability'></a>

`probability` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The probability of returning true. Must be between 0.0 and 1.0.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
A random boolean value influenced by the specified probability.