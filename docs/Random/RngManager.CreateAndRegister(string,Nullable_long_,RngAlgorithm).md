#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngManager](RngManager.md 'BeeneticToolkit.Random.RngManager')

## RngManager.CreateAndRegister(string, Nullable<long>, RngAlgorithm) Method

Creates and registers a random number generator for the given key,  
then returns it. Overwrites existing entries.

```csharp
public static BeeneticToolkit.Random.RandomGenerator CreateAndRegister(string key, System.Nullable<long> seed=null, BeeneticToolkit.Random.RngAlgorithm algorithm=BeeneticToolkit.Random.RngAlgorithm.Xorshift);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngManager.CreateAndRegister(string,System.Nullable_long_,BeeneticToolkit.Random.RngAlgorithm).key'></a>

`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The string key to register the generator under.

<a name='BeeneticToolkit.Random.RngManager.CreateAndRegister(string,System.Nullable_long_,BeeneticToolkit.Random.RngAlgorithm).seed'></a>

`seed` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Optional seed value.

<a name='BeeneticToolkit.Random.RngManager.CreateAndRegister(string,System.Nullable_long_,BeeneticToolkit.Random.RngAlgorithm).algorithm'></a>

`algorithm` [RngAlgorithm](RngAlgorithm.md 'BeeneticToolkit.Random.RngAlgorithm')

Optional algorithm to use (defaults to Xorshift).

#### Returns
[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')  
The created and registered [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator') instance.