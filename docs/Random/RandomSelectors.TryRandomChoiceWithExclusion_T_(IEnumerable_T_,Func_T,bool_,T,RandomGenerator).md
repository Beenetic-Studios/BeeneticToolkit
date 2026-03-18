#### [Random](index.md 'index')
### [BeeneticToolkit.Random.Utilities](index.md#BeeneticToolkit.Random.Utilities 'BeeneticToolkit.Random.Utilities').[RandomSelectors](RandomSelectors.md 'BeeneticToolkit.Random.Utilities.RandomSelectors')

## RandomSelectors.TryRandomChoiceWithExclusion<T>(IEnumerable<T>, Func<T,bool>, T, RandomGenerator) Method

Attempts to select a random element from an [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1') sequence, excluding elements that match a specified predicate, without throwing exceptions.

```csharp
public static bool TryRandomChoiceWithExclusion<T>(System.Collections.Generic.IEnumerable<T>? sequence, System.Func<T,bool>? exclusionPredicate, out T result, BeeneticToolkit.Random.RandomGenerator? random=null);
```
#### Type parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoiceWithExclusion_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,bool_,T,BeeneticToolkit.Random.RandomGenerator).T'></a>

`T`

The type of elements in the sequence.
#### Parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoiceWithExclusion_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,bool_,T,BeeneticToolkit.Random.RandomGenerator).sequence'></a>

`sequence` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](RandomSelectors.TryRandomChoiceWithExclusion_T_(IEnumerable_T_,Func_T,bool_,T,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoiceWithExclusion_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,bool_,T,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoiceWithExclusion<T>(System.Collections.Generic.IEnumerable<T>, System.Func<T,bool>, T, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The sequence from which to select a random element. May be null or empty.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoiceWithExclusion_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,bool_,T,BeeneticToolkit.Random.RandomGenerator).exclusionPredicate'></a>

`exclusionPredicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](RandomSelectors.TryRandomChoiceWithExclusion_T_(IEnumerable_T_,Func_T,bool_,T,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoiceWithExclusion_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,bool_,T,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoiceWithExclusion<T>(System.Collections.Generic.IEnumerable<T>, System.Func<T,bool>, T, BeeneticToolkit.Random.RandomGenerator).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

A predicate to exclude elements from being selected. May be null.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoiceWithExclusion_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,bool_,T,BeeneticToolkit.Random.RandomGenerator).result'></a>

`result` [T](RandomSelectors.TryRandomChoiceWithExclusion_T_(IEnumerable_T_,Func_T,bool_,T,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoiceWithExclusion_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,bool_,T,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoiceWithExclusion<T>(System.Collections.Generic.IEnumerable<T>, System.Func<T,bool>, T, BeeneticToolkit.Random.RandomGenerator).T')

When this method returns, contains the randomly selected element if the operation succeeded; otherwise, the default value for [T](RandomSelectors.TryRandomChoiceWithExclusion_T_(IEnumerable_T_,Func_T,bool_,T,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoiceWithExclusion_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,bool_,T,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoiceWithExclusion<T>(System.Collections.Generic.IEnumerable<T>, System.Func<T,bool>, T, BeeneticToolkit.Random.RandomGenerator).T').

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoiceWithExclusion_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,bool_,T,BeeneticToolkit.Random.RandomGenerator).random'></a>

`random` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The random number generator to use, or null to use the default generator.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if a valid random element was successfully selected; otherwise `false`.