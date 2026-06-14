#### [Random](index.md 'index')
### [BeeneticToolkit.Random.Utilities](index.md#BeeneticToolkit.Random.Utilities 'BeeneticToolkit.Random.Utilities').[RandomExtensions](RandomExtensions.md 'BeeneticToolkit.Random.Utilities.RandomExtensions')

## RandomExtensions.Shuffle<T>(this IEnumerable<T>, RandomGenerator) Method

Returns a new, shuffled copy of the source collection, leaving the source untouched.

```csharp
public static System.Collections.Generic.List<T> Shuffle<T>(this System.Collections.Generic.IEnumerable<T> source, BeeneticToolkit.Random.RandomGenerator? random=null);
```
#### Type parameters

<a name='BeeneticToolkit.Random.Utilities.RandomExtensions.Shuffle_T_(thisSystem.Collections.Generic.IEnumerable_T_,BeeneticToolkit.Random.RandomGenerator).T'></a>

`T`

The type of elements in the collection.
#### Parameters

<a name='BeeneticToolkit.Random.Utilities.RandomExtensions.Shuffle_T_(thisSystem.Collections.Generic.IEnumerable_T_,BeeneticToolkit.Random.RandomGenerator).source'></a>

`source` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](RandomExtensions.Shuffle_T_(thisIEnumerable_T_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomExtensions.Shuffle_T_(thisSystem.Collections.Generic.IEnumerable_T_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomExtensions.Shuffle<T>(this System.Collections.Generic.IEnumerable<T>, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The collection to shuffle. It is not modified.

<a name='BeeneticToolkit.Random.Utilities.RandomExtensions.Shuffle_T_(thisSystem.Collections.Generic.IEnumerable_T_,BeeneticToolkit.Random.RandomGenerator).random'></a>

`random` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The random number generator to use, or null to use the default generator.

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](RandomExtensions.Shuffle_T_(thisIEnumerable_T_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomExtensions.Shuffle_T_(thisSystem.Collections.Generic.IEnumerable_T_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomExtensions.Shuffle<T>(this System.Collections.Generic.IEnumerable<T>, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
A new [System.Collections.Generic.List&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1') containing the source elements in random order.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when [source](RandomExtensions.Shuffle_T_(thisIEnumerable_T_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomExtensions.Shuffle_T_(thisSystem.Collections.Generic.IEnumerable_T_,BeeneticToolkit.Random.RandomGenerator).source 'BeeneticToolkit.Random.Utilities.RandomExtensions.Shuffle<T>(this System.Collections.Generic.IEnumerable<T>, BeeneticToolkit.Random.RandomGenerator).source') is null.