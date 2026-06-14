#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random.Utilities](index.md#BeeneticToolkit.Random.Utilities 'BeeneticToolkit.Random.Utilities').[RandomUtils](RandomUtils.md 'BeeneticToolkit.Random.Utilities.RandomUtils')

## RandomUtils.DeriveSeed(long, string) Method

Derives a deterministic seed from a root seed and a system key.  
Ensures same root+key combo always yields the same result.

```csharp
public static long DeriveSeed(long rootSeed, string key);
```
#### Parameters

<a name='BeeneticToolkit.Random.Utilities.RandomUtils.DeriveSeed(long,string).rootSeed'></a>

`rootSeed` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

<a name='BeeneticToolkit.Random.Utilities.RandomUtils.DeriveSeed(long,string).key'></a>

`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')