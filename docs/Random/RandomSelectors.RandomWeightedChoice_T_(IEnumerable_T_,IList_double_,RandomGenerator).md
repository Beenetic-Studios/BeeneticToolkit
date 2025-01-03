#### [Random](index.md 'index')
### [BeeneticToolkit.Random.Utility](index.md#BeeneticToolkit.Random.Utility 'BeeneticToolkit.Random.Utility').[RandomSelectors](RandomSelectors.md 'BeeneticToolkit.Random.Utility.RandomSelectors')

## RandomSelectors.RandomWeightedChoice<T>(IEnumerable<T>, IList<double>, RandomGenerator) Method

Selects a random element from an IEnumerable sequence, with each element's likelihood of being chosen  
determined by its corresponding weight in a separate weight list.

```csharp
public static T RandomWeightedChoice<T>(System.Collections.Generic.IEnumerable<T> sequence, System.Collections.Generic.IList<double> weights, BeeneticToolkit.Random.RandomGenerator? random=null);
```
#### Type parameters

<a name='BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).T'></a>

`T`

The type of elements in the sequence.
#### Parameters

<a name='BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).sequence'></a>

`sequence` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](RandomSelectors.RandomWeightedChoice_T_(IEnumerable_T_,IList_double_,RandomGenerator).md#BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IEnumerable<T>, System.Collections.Generic.IList<double>, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The sequence from which to select a random weighted element.

<a name='BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).weights'></a>

`weights` [System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')

A list of weights corresponding to each element in the sequence.

<a name='BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).random'></a>

`random` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The random number generator to use, or `null` to use the default generator.

#### Returns
[T](RandomSelectors.RandomWeightedChoice_T_(IEnumerable_T_,IList_double_,RandomGenerator).md#BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IList_double_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IEnumerable<T>, System.Collections.Generic.IList<double>, BeeneticToolkit.Random.RandomGenerator).T')  
A randomly selected element, weighted by the corresponding weights list.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when the input sequence is empty or the lengths of the sequence and weights do not match.

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown when no valid item is selected. This could occur if the weights are improperly configured  
(e.g., all weights are zero or negative).