#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment')

## RandomEnvironment(string, Nullable<long>) Constructor

Initializes a new instance of the [RandomEnvironment](RandomEnvironment.md 'BeeneticToolkit.Random.RandomEnvironment') class.

```csharp
public RandomEnvironment(string name, System.Nullable<long> rootSeed=null);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomEnvironment.RandomEnvironment(string,System.Nullable_long_).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the environment.

<a name='BeeneticToolkit.Random.RandomEnvironment.RandomEnvironment(string,System.Nullable_long_).rootSeed'></a>

`rootSeed` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

An optional root seed. When supplied, generators created via  
[CreateAndRegister(string, Nullable&lt;long&gt;, RandomAlgorithm)](RandomEnvironment.CreateAndRegister(string,Nullable_long_,RandomAlgorithm).md 'BeeneticToolkit.Random.RandomEnvironment.CreateAndRegister(string, System.Nullable<long>, BeeneticToolkit.Random.RandomAlgorithm)') without an explicit seed derive a  
deterministic per-key seed from it, making the entire environment reproducible.