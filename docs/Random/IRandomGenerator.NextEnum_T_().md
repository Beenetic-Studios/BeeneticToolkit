#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[IRandomGenerator](IRandomGenerator.md 'BeeneticToolkit.Random.IRandomGenerator')

## IRandomGenerator.NextEnum<T>() Method

Returns a uniformly random value of the enum type [T](IRandomGenerator.NextEnum_T_().md#BeeneticToolkit.Random.IRandomGenerator.NextEnum_T_().T 'BeeneticToolkit.Random.IRandomGenerator.NextEnum<T>().T').

```csharp
T NextEnum<T>()
    where T : struct, System.Enum, System.ValueType, System.ValueType;
```
#### Type parameters

<a name='BeeneticToolkit.Random.IRandomGenerator.NextEnum_T_().T'></a>

`T`

An enumeration type.

#### Returns
[T](IRandomGenerator.NextEnum_T_().md#BeeneticToolkit.Random.IRandomGenerator.NextEnum_T_().T 'BeeneticToolkit.Random.IRandomGenerator.NextEnum<T>().T')  
A randomly selected value defined by [T](IRandomGenerator.NextEnum_T_().md#BeeneticToolkit.Random.IRandomGenerator.NextEnum_T_().T 'BeeneticToolkit.Random.IRandomGenerator.NextEnum<T>().T').