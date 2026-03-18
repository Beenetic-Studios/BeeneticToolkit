#### [Random](index.md 'index')
### [BeeneticToolkit.Random.Utilities](index.md#BeeneticToolkit.Random.Utilities 'BeeneticToolkit.Random.Utilities').[RandomSelectors](RandomSelectors.md 'BeeneticToolkit.Random.Utilities.RandomSelectors')

## RandomSelectors.RandomWeightedChoice<T>(IEnumerable<T>, IList<double>, RandomGenerator) Method

Selects a random element from an [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1') sequence, with each element's likelihood of being chosen  
determined by its corresponding weight in a separate weight list.

```csharp
public static T RandomWeightedChoice<T>(System.Collections.Generic.IEnumerable<T> sequence, System.Collections.Generic.IList<double> weights, BeeneticToolkit.Random.RandomGenerator? random=null);
```
#### Type parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).T'></a>

`T`

The type of elements in the sequence.
#### Parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).sequence'></a>

`sequence` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](RandomSelectors.RandomWeightedChoice_T_(IEnumerable_T_,IList_double_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IEnumerable<T>, System.Collections.Generic.IList<double>, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The sequence from which to select a random weighted element.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).weights'></a>

`weights` [System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')

A list of weights corresponding to each element in the sequence.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).random'></a>

`random` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The random number generator to use, or `null` to use the default generator.

#### Returns
[T](RandomSelectors.RandomWeightedChoice_T_(IEnumerable_T_,IList_double_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IEnumerable<T>, System.Collections.Generic.IList<double>, BeeneticToolkit.Random.RandomGenerator).T')  
A randomly selected element from the sequence, weighted by the corresponding weights.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when [sequence](RandomSelectors.RandomWeightedChoice_T_(IEnumerable_T_,IList_double_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).sequence 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IEnumerable<T>, System.Collections.Generic.IList<double>, BeeneticToolkit.Random.RandomGenerator).sequence') or [weights](RandomSelectors.RandomWeightedChoice_T_(IEnumerable_T_,IList_double_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).weights 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IEnumerable<T>, System.Collections.Generic.IList<double>, BeeneticToolkit.Random.RandomGenerator).weights') is null.

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when the sequence is empty or lengths do not match.

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown when the total weight is zero or no valid item can be selected.