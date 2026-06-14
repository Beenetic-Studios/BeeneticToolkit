#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment')

## RngEnvironment(string, Nullable<long>) Constructor

Initializes a new instance of the [RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment') class.

```csharp
public RngEnvironment(string name, System.Nullable<long> rootSeed=null);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngEnvironment.RngEnvironment(string,System.Nullable_long_).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the environment.

<a name='BeeneticToolkit.Random.RngEnvironment.RngEnvironment(string,System.Nullable_long_).rootSeed'></a>

`rootSeed` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

An optional root seed. When supplied, generators created via  
[CreateAndRegister(string, Nullable&lt;long&gt;, RngAlgorithm)](RngEnvironment.CreateAndRegister(string,Nullable_long_,RngAlgorithm).md 'BeeneticToolkit.Random.RngEnvironment.CreateAndRegister(string, System.Nullable<long>, BeeneticToolkit.Random.RngAlgorithm)') without an explicit seed derive a  
deterministic per-key seed from it, making the entire environment reproducible.