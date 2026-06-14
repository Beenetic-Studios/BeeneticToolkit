#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

## RandomGenerator.NextMaxInclusive Property

Gets the inclusive maximum value that [Next()](RandomGenerator.Next().md 'BeeneticToolkit.Random.RandomGenerator.Next()') can return.

```csharp
protected virtual long NextMaxInclusive { get; }
```

#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
The inclusive upper bound of [Next()](RandomGenerator.Next().md 'BeeneticToolkit.Random.RandomGenerator.Next()').

### Remarks
This is used to derive unbiased bounded values and to scale the `[0, 1)` float/double  
helpers. The base implementation assumes [Next()](RandomGenerator.Next().md 'BeeneticToolkit.Random.RandomGenerator.Next()') yields a uniform value in  
`[0, long.MaxValue]` (i.e. a full 63-bit result). Generators whose [Next()](RandomGenerator.Next().md 'BeeneticToolkit.Random.RandomGenerator.Next()')  
produces a narrower range (for example a modulus-bounded LCG) must override this so the  
derived values stay correct.