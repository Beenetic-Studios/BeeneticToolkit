#### [Random](index.md 'index')
### [BeeneticToolkit.Random.Utility](index.md#BeeneticToolkit.Random.Utility 'BeeneticToolkit.Random.Utility').[RandomExtensions](RandomExtensions.md 'BeeneticToolkit.Random.Utility.RandomExtensions')

## RandomExtensions.Shuffle<T>(this IEnumerable<T>, RandomGenerator) Method

Shuffles elements in a collection using a specified or default random number generator.

```csharp
public static System.Collections.Generic.IEnumerable<T> Shuffle<T>(this System.Collections.Generic.IEnumerable<T> source, BeeneticToolkit.Random.RandomGenerator? random=null);
```
#### Type parameters

<a name='BeeneticToolkit.Random.Utility.RandomExtensions.Shuffle_T_(thisSystem.Collections.Generic.IEnumerable_T_,BeeneticToolkit.Random.RandomGenerator).T'></a>

`T`

The type of elements in the collection.
#### Parameters

<a name='BeeneticToolkit.Random.Utility.RandomExtensions.Shuffle_T_(thisSystem.Collections.Generic.IEnumerable_T_,BeeneticToolkit.Random.RandomGenerator).source'></a>

`source` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](RandomExtensions.Shuffle_T_(thisIEnumerable_T_,RandomGenerator).md#BeeneticToolkit.Random.Utility.RandomExtensions.Shuffle_T_(thisSystem.Collections.Generic.IEnumerable_T_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utility.RandomExtensions.Shuffle<T>(this System.Collections.Generic.IEnumerable<T>, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The collection to shuffle.

<a name='BeeneticToolkit.Random.Utility.RandomExtensions.Shuffle_T_(thisSystem.Collections.Generic.IEnumerable_T_,BeeneticToolkit.Random.RandomGenerator).random'></a>

`random` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The random number generator to use, or null to use the default generator.

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](RandomExtensions.Shuffle_T_(thisIEnumerable_T_,RandomGenerator).md#BeeneticToolkit.Random.Utility.RandomExtensions.Shuffle_T_(thisSystem.Collections.Generic.IEnumerable_T_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utility.RandomExtensions.Shuffle<T>(this System.Collections.Generic.IEnumerable<T>, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A shuffled version of the source collection.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when the source collection is null or empty.