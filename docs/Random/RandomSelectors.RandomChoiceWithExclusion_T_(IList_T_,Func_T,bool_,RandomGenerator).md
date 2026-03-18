#### [Random](index.md 'index')
### [BeeneticToolkit.Random.Utilities](index.md#BeeneticToolkit.Random.Utilities 'BeeneticToolkit.Random.Utilities').[RandomSelectors](RandomSelectors.md 'BeeneticToolkit.Random.Utilities.RandomSelectors')

## RandomSelectors.RandomChoiceWithExclusion<T>(IList<T>, Func<T,bool>, RandomGenerator) Method

Selects a random element from a list, excluding elements that match a specified predicate.

```csharp
public static T RandomChoiceWithExclusion<T>(System.Collections.Generic.IList<T> list, System.Func<T,bool> exclusionPredicate, BeeneticToolkit.Random.RandomGenerator? random=null);
```
#### Type parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion_T_(System.Collections.Generic.IList_T_,System.Func_T,bool_,BeeneticToolkit.Random.RandomGenerator).T'></a>

`T`

The type of elements in the list.
#### Parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion_T_(System.Collections.Generic.IList_T_,System.Func_T,bool_,BeeneticToolkit.Random.RandomGenerator).list'></a>

`list` [System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T](RandomSelectors.RandomChoiceWithExclusion_T_(IList_T_,Func_T,bool_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion_T_(System.Collections.Generic.IList_T_,System.Func_T,bool_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion<T>(System.Collections.Generic.IList<T>, System.Func<T,bool>, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')

The list from which to select a random element.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion_T_(System.Collections.Generic.IList_T_,System.Func_T,bool_,BeeneticToolkit.Random.RandomGenerator).exclusionPredicate'></a>

`exclusionPredicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](RandomSelectors.RandomChoiceWithExclusion_T_(IList_T_,Func_T,bool_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion_T_(System.Collections.Generic.IList_T_,System.Func_T,bool_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion<T>(System.Collections.Generic.IList<T>, System.Func<T,bool>, BeeneticToolkit.Random.RandomGenerator).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

A predicate to exclude elements from being selected.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion_T_(System.Collections.Generic.IList_T_,System.Func_T,bool_,BeeneticToolkit.Random.RandomGenerator).random'></a>

`random` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The random number generator to use, or null to use the default generator.

#### Returns
[T](RandomSelectors.RandomChoiceWithExclusion_T_(IList_T_,Func_T,bool_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion_T_(System.Collections.Generic.IList_T_,System.Func_T,bool_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion<T>(System.Collections.Generic.IList<T>, System.Func<T,bool>, BeeneticToolkit.Random.RandomGenerator).T')  
A randomly selected element from the list that does not match the exclusion predicate.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when [list](RandomSelectors.RandomChoiceWithExclusion_T_(IList_T_,Func_T,bool_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion_T_(System.Collections.Generic.IList_T_,System.Func_T,bool_,BeeneticToolkit.Random.RandomGenerator).list 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion<T>(System.Collections.Generic.IList<T>, System.Func<T,bool>, BeeneticToolkit.Random.RandomGenerator).list') or [exclusionPredicate](RandomSelectors.RandomChoiceWithExclusion_T_(IList_T_,Func_T,bool_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion_T_(System.Collections.Generic.IList_T_,System.Func_T,bool_,BeeneticToolkit.Random.RandomGenerator).exclusionPredicate 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion<T>(System.Collections.Generic.IList<T>, System.Func<T,bool>, BeeneticToolkit.Random.RandomGenerator).exclusionPredicate') is null.

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown when no elements remain after applying the exclusion filter.