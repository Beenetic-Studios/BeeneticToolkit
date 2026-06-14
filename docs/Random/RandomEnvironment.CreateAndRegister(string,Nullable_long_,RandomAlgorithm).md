#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment')

## RandomEnvironment.CreateAndRegister(string, Nullable<long>, RandomAlgorithm) Method

Creates a new random number generator, registers it under the specified key,  
and returns the created instance.  
If a generator was previously registered with the same key, it will be replaced.

```csharp
public BeeneticToolkit.Random.RandomGenerator CreateAndRegister(string key, System.Nullable<long> seed=null, BeeneticToolkit.Random.RandomAlgorithm algorithm=BeeneticToolkit.Random.RandomAlgorithm.Xoshiro256);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomEnvironment.CreateAndRegister(string,System.Nullable_long_,BeeneticToolkit.Random.RandomAlgorithm).key'></a>

`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The key to register the generator under.

<a name='BeeneticToolkit.Random.RandomEnvironment.CreateAndRegister(string,System.Nullable_long_,BeeneticToolkit.Random.RandomAlgorithm).seed'></a>

`seed` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Optional explicit seed. If omitted and the environment has a [RootSeed](RandomEnvironment.RootSeed.md 'BeeneticToolkit.Random.RandomEnvironment.RootSeed'), the seed is  
derived deterministically from the root seed and [key](RandomEnvironment.CreateAndRegister(string,Nullable_long_,RandomAlgorithm).md#BeeneticToolkit.Random.RandomEnvironment.CreateAndRegister(string,System.Nullable_long_,BeeneticToolkit.Random.RandomAlgorithm).key 'BeeneticToolkit.Random.RandomEnvironment.CreateAndRegister(string, System.Nullable<long>, BeeneticToolkit.Random.RandomAlgorithm).key'); otherwise it is time-based.

<a name='BeeneticToolkit.Random.RandomEnvironment.CreateAndRegister(string,System.Nullable_long_,BeeneticToolkit.Random.RandomAlgorithm).algorithm'></a>

`algorithm` [RandomAlgorithm](RandomAlgorithm.md 'BeeneticToolkit.Random.RandomAlgorithm')

Optional algorithm to use. Defaults to xoshiro256**.

#### Returns
[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')  
The created and registered [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator') instance.