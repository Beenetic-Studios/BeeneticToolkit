#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment')

## RngEnvironment.CreateAndRegister(RngKey, Nullable<long>, RngAlgorithm) Method

Creates a new random number generator, registers it under the specified [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey'),  
and returns the created instance.  
If a generator was previously registered with the same key, it will be replaced.

```csharp
public BeeneticToolkit.Random.RandomGenerator CreateAndRegister(BeeneticToolkit.Random.RngKey key, System.Nullable<long> seed=null, BeeneticToolkit.Random.RngAlgorithm algorithm=BeeneticToolkit.Random.RngAlgorithm.Xorshift);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngEnvironment.CreateAndRegister(BeeneticToolkit.Random.RngKey,System.Nullable_long_,BeeneticToolkit.Random.RngAlgorithm).key'></a>

`key` [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey')

The strongly typed key to register the generator under.

<a name='BeeneticToolkit.Random.RngEnvironment.CreateAndRegister(BeeneticToolkit.Random.RngKey,System.Nullable_long_,BeeneticToolkit.Random.RngAlgorithm).seed'></a>

`seed` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Optional seed value.

<a name='BeeneticToolkit.Random.RngEnvironment.CreateAndRegister(BeeneticToolkit.Random.RngKey,System.Nullable_long_,BeeneticToolkit.Random.RngAlgorithm).algorithm'></a>

`algorithm` [RngAlgorithm](RngAlgorithm.md 'BeeneticToolkit.Random.RngAlgorithm')

Optional algorithm to use. Defaults to [Xorshift](RngAlgorithm.md#BeeneticToolkit.Random.RngAlgorithm.Xorshift 'BeeneticToolkit.Random.RngAlgorithm.Xorshift').

#### Returns
[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')  
The created and registered [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator') instance.