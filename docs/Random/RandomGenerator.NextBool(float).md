#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

## RandomGenerator.NextBool(float) Method

Returns a random boolean value with the probability of returning true specified by the input parameter.

```csharp
public virtual bool NextBool(float probability);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomGenerator.NextBool(float).probability'></a>

`probability` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The probability of returning true. Must be between 0.0 and 1.0.

Implements [NextBool(float)](IRandomGenerator.NextBool(float).md 'BeeneticToolkit.Random.IRandomGenerator.NextBool(float)')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
A random boolean value influenced by the specified probability.