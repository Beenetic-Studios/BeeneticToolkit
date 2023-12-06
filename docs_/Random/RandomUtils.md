#### [Random](index.md 'index')
### [BeeneticToolkit.Random.Utility](index.md#BeeneticToolkit.Random.Utility 'BeeneticToolkit.Random.Utility')

## RandomUtils Class

Provides utility methods for random operations, such as selecting random elements from collections.

```csharp
public static class RandomUtils
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RandomUtils

| Methods | |
| :--- | :--- |
| [RandomChoice&lt;T&gt;(IEnumerable&lt;T&gt;, RandomGenerator)](RandomUtils.RandomChoice_T_(IEnumerable_T_,RandomGenerator).md 'BeeneticToolkit.Random.Utility.RandomUtils.RandomChoice<T>(System.Collections.Generic.IEnumerable<T>, BeeneticToolkit.Random.RandomGenerator)') | Selects a random element from an IEnumerable sequence. |
| [RandomChoice&lt;T&gt;(IList&lt;T&gt;, RandomGenerator)](RandomUtils.RandomChoice_T_(IList_T_,RandomGenerator).md 'BeeneticToolkit.Random.Utility.RandomUtils.RandomChoice<T>(System.Collections.Generic.IList<T>, BeeneticToolkit.Random.RandomGenerator)') | Selects a random element from a list. |
| [RandomChoiceWithExclusion&lt;T&gt;(IEnumerable&lt;T&gt;, Func&lt;T,bool&gt;, RandomGenerator)](RandomUtils.RandomChoiceWithExclusion_T_(IEnumerable_T_,Func_T,bool_,RandomGenerator).md 'BeeneticToolkit.Random.Utility.RandomUtils.RandomChoiceWithExclusion<T>(System.Collections.Generic.IEnumerable<T>, System.Func<T,bool>, BeeneticToolkit.Random.RandomGenerator)') | Selects a random element from an IEnumerable sequence, excluding elements that match a specified predicate. |
| [RandomChoiceWithExclusion&lt;T&gt;(IList&lt;T&gt;, Func&lt;T,bool&gt;, RandomGenerator)](RandomUtils.RandomChoiceWithExclusion_T_(IList_T_,Func_T,bool_,RandomGenerator).md 'BeeneticToolkit.Random.Utility.RandomUtils.RandomChoiceWithExclusion<T>(System.Collections.Generic.IList<T>, System.Func<T,bool>, BeeneticToolkit.Random.RandomGenerator)') | Selects a random element from a list, excluding elements that match a specified predicate. |
| [RandomSubset&lt;T&gt;(IEnumerable&lt;T&gt;, int, RandomGenerator)](RandomUtils.RandomSubset_T_(IEnumerable_T_,int,RandomGenerator).md 'BeeneticToolkit.Random.Utility.RandomUtils.RandomSubset<T>(System.Collections.Generic.IEnumerable<T>, int, BeeneticToolkit.Random.RandomGenerator)') | Selects a random subset of a specified size from an IEnumerable sequence. |
| [RandomSubset&lt;T&gt;(IList&lt;T&gt;, int, RandomGenerator)](RandomUtils.RandomSubset_T_(IList_T_,int,RandomGenerator).md 'BeeneticToolkit.Random.Utility.RandomUtils.RandomSubset<T>(System.Collections.Generic.IList<T>, int, BeeneticToolkit.Random.RandomGenerator)') | Selects a random subset of a specified size from a list. |
| [RandomWeightedChoice&lt;T&gt;(IEnumerable&lt;T&gt;, IList&lt;double&gt;, RandomGenerator)](RandomUtils.RandomWeightedChoice_T_(IEnumerable_T_,IList_double_,RandomGenerator).md 'BeeneticToolkit.Random.Utility.RandomUtils.RandomWeightedChoice<T>(System.Collections.Generic.IEnumerable<T>, System.Collections.Generic.IList<double>, BeeneticToolkit.Random.RandomGenerator)') | Selects a random element from an IEnumerable sequence, with each element's likelihood of being chosen<br/>determined by its corresponding weight in a separate weight list. |
| [RandomWeightedChoice&lt;T&gt;(IList&lt;T&gt;, IList&lt;double&gt;, RandomGenerator)](RandomUtils.RandomWeightedChoice_T_(IList_T_,IList_double_,RandomGenerator).md 'BeeneticToolkit.Random.Utility.RandomUtils.RandomWeightedChoice<T>(System.Collections.Generic.IList<T>, System.Collections.Generic.IList<double>, BeeneticToolkit.Random.RandomGenerator)') | Selects a random element from a list, with each element's likelihood of being chosen<br/>determined by its corresponding weight in a separate weight list. |
