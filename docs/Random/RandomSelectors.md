#### [Random](index.md 'index')
### [BeeneticToolkit.Random.Utility](index.md#BeeneticToolkit.Random.Utility 'BeeneticToolkit.Random.Utility')

## RandomSelectors Class

Provides utility methods for random operations, such as selecting random elements from collections.

```csharp
public static class RandomSelectors
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RandomSelectors

| Methods | |
| :--- | :--- |
| [RandomChoice&lt;T&gt;(IEnumerable&lt;T&gt;, RandomGenerator)](RandomSelectors.RandomChoice_T_(IEnumerable_T_,RandomGenerator).md 'BeeneticToolkit.Random.Utility.RandomSelectors.RandomChoice<T>(System.Collections.Generic.IEnumerable<T>, BeeneticToolkit.Random.RandomGenerator)') | Selects a random element from an IEnumerable sequence. |
| [RandomChoice&lt;T&gt;(IList&lt;T&gt;, RandomGenerator)](RandomSelectors.RandomChoice_T_(IList_T_,RandomGenerator).md 'BeeneticToolkit.Random.Utility.RandomSelectors.RandomChoice<T>(System.Collections.Generic.IList<T>, BeeneticToolkit.Random.RandomGenerator)') | Selects a random element from a list. |
| [RandomChoiceWithExclusion&lt;T&gt;(IEnumerable&lt;T&gt;, Func&lt;T,bool&gt;, RandomGenerator)](RandomSelectors.RandomChoiceWithExclusion_T_(IEnumerable_T_,Func_T,bool_,RandomGenerator).md 'BeeneticToolkit.Random.Utility.RandomSelectors.RandomChoiceWithExclusion<T>(System.Collections.Generic.IEnumerable<T>, System.Func<T,bool>, BeeneticToolkit.Random.RandomGenerator)') | Selects a random element from an IEnumerable sequence, excluding elements that match a specified predicate. |
| [RandomChoiceWithExclusion&lt;T&gt;(IList&lt;T&gt;, Func&lt;T,bool&gt;, RandomGenerator)](RandomSelectors.RandomChoiceWithExclusion_T_(IList_T_,Func_T,bool_,RandomGenerator).md 'BeeneticToolkit.Random.Utility.RandomSelectors.RandomChoiceWithExclusion<T>(System.Collections.Generic.IList<T>, System.Func<T,bool>, BeeneticToolkit.Random.RandomGenerator)') | Selects a random element from a list, excluding elements that match a specified predicate. |
| [RandomSubset&lt;T&gt;(IEnumerable&lt;T&gt;, int, RandomGenerator)](RandomSelectors.RandomSubset_T_(IEnumerable_T_,int,RandomGenerator).md 'BeeneticToolkit.Random.Utility.RandomSelectors.RandomSubset<T>(System.Collections.Generic.IEnumerable<T>, int, BeeneticToolkit.Random.RandomGenerator)') | Selects a random subset of a specified size from an IEnumerable sequence. |
| [RandomSubset&lt;T&gt;(IList&lt;T&gt;, int, RandomGenerator)](RandomSelectors.RandomSubset_T_(IList_T_,int,RandomGenerator).md 'BeeneticToolkit.Random.Utility.RandomSelectors.RandomSubset<T>(System.Collections.Generic.IList<T>, int, BeeneticToolkit.Random.RandomGenerator)') | Selects a random subset of a specified size from a list. |
| [RandomWeightedChoice&lt;T&gt;(Dictionary&lt;T,double&gt;, bool, RandomGenerator)](RandomSelectors.RandomWeightedChoice_T_(Dictionary_T,double_,bool,RandomGenerator).md 'BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.Dictionary<T,double>, bool, BeeneticToolkit.Random.RandomGenerator)') | Selects a random element from a dictionary, with each element's likelihood of being chosen<br/>determined by its associated weight. |
| [RandomWeightedChoice&lt;T&gt;(IEnumerable&lt;T&gt;, IList&lt;double&gt;, RandomGenerator)](RandomSelectors.RandomWeightedChoice_T_(IEnumerable_T_,IList_double_,RandomGenerator).md 'BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IEnumerable<T>, System.Collections.Generic.IList<double>, BeeneticToolkit.Random.RandomGenerator)') | Selects a random element from an IEnumerable sequence, with each element's likelihood of being chosen<br/>determined by its corresponding weight in a separate weight list. |
| [RandomWeightedChoice&lt;T&gt;(IList&lt;T&gt;, IList&lt;double&gt;, RandomGenerator)](RandomSelectors.RandomWeightedChoice_T_(IList_T_,IList_double_,RandomGenerator).md 'BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IList<T>, System.Collections.Generic.IList<double>, BeeneticToolkit.Random.RandomGenerator)') | Selects a random element from a list, with each element's likelihood of being chosen<br/>determined by its corresponding weight in a separate weight list. |
