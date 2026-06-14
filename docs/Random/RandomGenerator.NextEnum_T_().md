#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

## RandomGenerator.NextEnum<T>() Method

Returns a uniformly random value of the enum type [T](RandomGenerator.NextEnum_T_().md#BeeneticToolkit.Random.RandomGenerator.NextEnum_T_().T 'BeeneticToolkit.Random.RandomGenerator.NextEnum<T>().T').

```csharp
public virtual T NextEnum<T>()
    where T : struct, System.Enum, System.ValueType, System.ValueType;
```
#### Type parameters

<a name='BeeneticToolkit.Random.RandomGenerator.NextEnum_T_().T'></a>

`T`

An enumeration type.

Implements [NextEnum&lt;T&gt;()](IRandomGenerator.NextEnum_T_().md 'BeeneticToolkit.Random.IRandomGenerator.NextEnum<T>()')

#### Returns
[T](RandomGenerator.NextEnum_T_().md#BeeneticToolkit.Random.RandomGenerator.NextEnum_T_().T 'BeeneticToolkit.Random.RandomGenerator.NextEnum<T>().T')  
A randomly selected value defined by [T](RandomGenerator.NextEnum_T_().md#BeeneticToolkit.Random.RandomGenerator.NextEnum_T_().T 'BeeneticToolkit.Random.RandomGenerator.NextEnum<T>().T').

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown when [T](RandomGenerator.NextEnum_T_().md#BeeneticToolkit.Random.RandomGenerator.NextEnum_T_().T 'BeeneticToolkit.Random.RandomGenerator.NextEnum<T>().T') defines no values.