#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngManager](RngManager.md 'BeeneticToolkit.Random.RngManager')

## RngManager.CreateEnvironment(string, Nullable<long>) Method

Creates a named environment and registers it with the manager, replacing any existing environment  
with the same name.

```csharp
public static BeeneticToolkit.Random.RngEnvironment CreateEnvironment(string name, System.Nullable<long> rootSeed=null);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngManager.CreateEnvironment(string,System.Nullable_long_).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name to register the environment under.

<a name='BeeneticToolkit.Random.RngManager.CreateEnvironment(string,System.Nullable_long_).rootSeed'></a>

`rootSeed` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

An optional root seed making the environment reproducible (see [RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment')).

#### Returns
[RngEnvironment](RngEnvironment.md 'BeeneticToolkit.Random.RngEnvironment')  
The created environment.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when [name](RngManager.CreateEnvironment(string,Nullable_long_).md#BeeneticToolkit.Random.RngManager.CreateEnvironment(string,System.Nullable_long_).name 'BeeneticToolkit.Random.RngManager.CreateEnvironment(string, System.Nullable<long>).name') is null.