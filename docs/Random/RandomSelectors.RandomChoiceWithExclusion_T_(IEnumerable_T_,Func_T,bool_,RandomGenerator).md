#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random.Utilities](index.md#BeeneticToolkit.Random.Utilities 'BeeneticToolkit.Random.Utilities').[RandomSelectors](RandomSelectors.md 'BeeneticToolkit.Random.Utilities.RandomSelectors')

## RandomSelectors.RandomChoiceWithExclusion<T>(IEnumerable<T>, Func<T,bool>, RandomGenerator) Method

Selects a random element from an IEnumerable sequence, excluding elements that match a specified predicate.

```csharp
public static T RandomChoiceWithExclusion<T>(System.Collections.Generic.IEnumerable<T> sequence, System.Func<T,bool> exclusionPredicate, BeeneticToolkit.Random.RandomGenerator? random=null);
```
#### Type parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,bool_,BeeneticToolkit.Random.RandomGenerator).T'></a>

`T`

The type of elements in the sequence.
#### Parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,bool_,BeeneticToolkit.Random.RandomGenerator).sequence'></a>

`sequence` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](RandomSelectors.RandomChoiceWithExclusion_T_(IEnumerable_T_,Func_T,bool_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,bool_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion<T>(System.Collections.Generic.IEnumerable<T>, System.Func<T,bool>, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The sequence from which to select a random element.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,bool_,BeeneticToolkit.Random.RandomGenerator).exclusionPredicate'></a>

`exclusionPredicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](RandomSelectors.RandomChoiceWithExclusion_T_(IEnumerable_T_,Func_T,bool_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,bool_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion<T>(System.Collections.Generic.IEnumerable<T>, System.Func<T,bool>, BeeneticToolkit.Random.RandomGenerator).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

A predicate to exclude elements from being selected.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,bool_,BeeneticToolkit.Random.RandomGenerator).random'></a>

`random` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The random number generator to use, or null to use the default generator.

#### Returns
[T](RandomSelectors.RandomChoiceWithExclusion_T_(IEnumerable_T_,Func_T,bool_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,bool_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion<T>(System.Collections.Generic.IEnumerable<T>, System.Func<T,bool>, BeeneticToolkit.Random.RandomGenerator).T')  
A randomly selected element from the sequence that does not match the exclusion predicate.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when [sequence](RandomSelectors.RandomChoiceWithExclusion_T_(IEnumerable_T_,Func_T,bool_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,bool_,BeeneticToolkit.Random.RandomGenerator).sequence 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion<T>(System.Collections.Generic.IEnumerable<T>, System.Func<T,bool>, BeeneticToolkit.Random.RandomGenerator).sequence') or [exclusionPredicate](RandomSelectors.RandomChoiceWithExclusion_T_(IEnumerable_T_,Func_T,bool_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,bool_,BeeneticToolkit.Random.RandomGenerator).exclusionPredicate 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoiceWithExclusion<T>(System.Collections.Generic.IEnumerable<T>, System.Func<T,bool>, BeeneticToolkit.Random.RandomGenerator).exclusionPredicate') is null.

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown when no elements remain after applying the exclusion filter.