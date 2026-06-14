#### [Random](index.md 'index')
### [BeeneticToolkit.Random.Utilities](index.md#BeeneticToolkit.Random.Utilities 'BeeneticToolkit.Random.Utilities').[RandomExtensions](RandomExtensions.md 'BeeneticToolkit.Random.Utilities.RandomExtensions')

## RandomExtensions.ShuffleInPlace<T>(this IList<T>, RandomGenerator) Method

Shuffles the elements of a list in place using a Fisher-Yates shuffle, without allocating.

```csharp
public static void ShuffleInPlace<T>(this System.Collections.Generic.IList<T> list, BeeneticToolkit.Random.RandomGenerator? random=null);
```
#### Type parameters

<a name='BeeneticToolkit.Random.Utilities.RandomExtensions.ShuffleInPlace_T_(thisSystem.Collections.Generic.IList_T_,BeeneticToolkit.Random.RandomGenerator).T'></a>

`T`

The type of elements in the list.
#### Parameters

<a name='BeeneticToolkit.Random.Utilities.RandomExtensions.ShuffleInPlace_T_(thisSystem.Collections.Generic.IList_T_,BeeneticToolkit.Random.RandomGenerator).list'></a>

`list` [System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T](RandomExtensions.ShuffleInPlace_T_(thisIList_T_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomExtensions.ShuffleInPlace_T_(thisSystem.Collections.Generic.IList_T_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomExtensions.ShuffleInPlace<T>(this System.Collections.Generic.IList<T>, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')

The list to shuffle in place.

<a name='BeeneticToolkit.Random.Utilities.RandomExtensions.ShuffleInPlace_T_(thisSystem.Collections.Generic.IList_T_,BeeneticToolkit.Random.RandomGenerator).random'></a>

`random` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The random number generator to use, or null to use the default generator.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when [list](RandomExtensions.ShuffleInPlace_T_(thisIList_T_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomExtensions.ShuffleInPlace_T_(thisSystem.Collections.Generic.IList_T_,BeeneticToolkit.Random.RandomGenerator).list 'BeeneticToolkit.Random.Utilities.RandomExtensions.ShuffleInPlace<T>(this System.Collections.Generic.IList<T>, BeeneticToolkit.Random.RandomGenerator).list') is null.