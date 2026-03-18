#### [Random](index.md 'index')
### [BeeneticToolkit.Random.Utilities](index.md#BeeneticToolkit.Random.Utilities 'BeeneticToolkit.Random.Utilities').[RandomSelectors](RandomSelectors.md 'BeeneticToolkit.Random.Utilities.RandomSelectors')

## RandomSelectors.RandomWeightedChoice<T>(IList<T>, IList<double>, RandomGenerator) Method

Selects a random element from a list, with each element's likelihood of being chosen  
determined by its corresponding weight in a separate weight list.

```csharp
public static T RandomWeightedChoice<T>(System.Collections.Generic.IList<T> list, System.Collections.Generic.IList<double> weights, BeeneticToolkit.Random.RandomGenerator? random=null);
```
#### Type parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IList_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).T'></a>

`T`

The type of elements in the list.
#### Parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IList_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).list'></a>

`list` [System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T](RandomSelectors.RandomWeightedChoice_T_(IList_T_,IList_double_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IList_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IList<T>, System.Collections.Generic.IList<double>, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')

The list from which to select a random weighted element.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IList_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).weights'></a>

`weights` [System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')

A list of weights corresponding to each element in the list.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IList_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).random'></a>

`random` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The random number generator to use, or `null` to use the default generator.

#### Returns
[T](RandomSelectors.RandomWeightedChoice_T_(IList_T_,IList_double_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IList_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IList<T>, System.Collections.Generic.IList<double>, BeeneticToolkit.Random.RandomGenerator).T')  
A randomly selected element from the list, weighted by the corresponding weights.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when [list](RandomSelectors.RandomWeightedChoice_T_(IList_T_,IList_double_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IList_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).list 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IList<T>, System.Collections.Generic.IList<double>, BeeneticToolkit.Random.RandomGenerator).list') or [weights](RandomSelectors.RandomWeightedChoice_T_(IList_T_,IList_double_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IList_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).weights 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IList<T>, System.Collections.Generic.IList<double>, BeeneticToolkit.Random.RandomGenerator).weights') is null.

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [list](RandomSelectors.RandomWeightedChoice_T_(IList_T_,IList_double_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IList_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).list 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IList<T>, System.Collections.Generic.IList<double>, BeeneticToolkit.Random.RandomGenerator).list') is empty or the lengths of [list](RandomSelectors.RandomWeightedChoice_T_(IList_T_,IList_double_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IList_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).list 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IList<T>, System.Collections.Generic.IList<double>, BeeneticToolkit.Random.RandomGenerator).list') and [weights](RandomSelectors.RandomWeightedChoice_T_(IList_T_,IList_double_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IList_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).weights 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IList<T>, System.Collections.Generic.IList<double>, BeeneticToolkit.Random.RandomGenerator).weights') do not match.

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown when the total weight is zero or no valid item can be selected.