#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment')

## RandomEnvironment.CreateAndRegister(RandomKey, Nullable<long>, RandomAlgorithm) Method

Creates a new random number generator, registers it under the specified [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey'),  
and returns the created instance.  
If a generator was previously registered with the same key, it will be replaced.

```csharp
public BeeneticToolkit.Random.RandomGenerator CreateAndRegister(BeeneticToolkit.Random.RandomKey key, System.Nullable<long> seed=null, BeeneticToolkit.Random.RandomAlgorithm algorithm=BeeneticToolkit.Random.RandomAlgorithm.Xoshiro256);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomEnvironment.CreateAndRegister(BeeneticToolkit.Random.RandomKey,System.Nullable_long_,BeeneticToolkit.Random.RandomAlgorithm).key'></a>

`key` [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey')

The strongly typed key to register the generator under.

<a name='BeeneticToolkit.Random.RandomEnvironment.CreateAndRegister(BeeneticToolkit.Random.RandomKey,System.Nullable_long_,BeeneticToolkit.Random.RandomAlgorithm).seed'></a>

`seed` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Optional seed value.

<a name='BeeneticToolkit.Random.RandomEnvironment.CreateAndRegister(BeeneticToolkit.Random.RandomKey,System.Nullable_long_,BeeneticToolkit.Random.RandomAlgorithm).algorithm'></a>

`algorithm` [RandomAlgorithm](RandomAlgorithm.md 'BeeneticToolkit.Random.RandomAlgorithm')

Optional algorithm to use. Defaults to xoshiro256**.

#### Returns
[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')  
The created and registered [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator') instance.