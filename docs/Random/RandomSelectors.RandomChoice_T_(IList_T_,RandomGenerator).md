#### [Random](index.md 'index')
### [BeeneticToolkit.Random.Utility](index.md#BeeneticToolkit.Random.Utility 'BeeneticToolkit.Random.Utility').[RandomSelectors](RandomSelectors.md 'BeeneticToolkit.Random.Utility.RandomSelectors')

## RandomSelectors.RandomChoice<T>(IList<T>, RandomGenerator) Method

Selects a random element from a list.

```csharp
public static T RandomChoice<T>(System.Collections.Generic.IList<T> list, BeeneticToolkit.Random.RandomGenerator? random=null);
```
#### Type parameters

<a name='BeeneticToolkit.Random.Utility.RandomSelectors.RandomChoice_T_(System.Collections.Generic.IList_T_,BeeneticToolkit.Random.RandomGenerator).T'></a>

`T`

The type of elements in the list.
#### Parameters

<a name='BeeneticToolkit.Random.Utility.RandomSelectors.RandomChoice_T_(System.Collections.Generic.IList_T_,BeeneticToolkit.Random.RandomGenerator).list'></a>

`list` [System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T](RandomSelectors.RandomChoice_T_(IList_T_,RandomGenerator).md#BeeneticToolkit.Random.Utility.RandomSelectors.RandomChoice_T_(System.Collections.Generic.IList_T_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utility.RandomSelectors.RandomChoice<T>(System.Collections.Generic.IList<T>, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')

The list from which to select a random element.

<a name='BeeneticToolkit.Random.Utility.RandomSelectors.RandomChoice_T_(System.Collections.Generic.IList_T_,BeeneticToolkit.Random.RandomGenerator).random'></a>

`random` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The random number generator to use, or null to use the default generator.

#### Returns
[T](RandomSelectors.RandomChoice_T_(IList_T_,RandomGenerator).md#BeeneticToolkit.Random.Utility.RandomSelectors.RandomChoice_T_(System.Collections.Generic.IList_T_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utility.RandomSelectors.RandomChoice<T>(System.Collections.Generic.IList<T>, BeeneticToolkit.Random.RandomGenerator).T')  
A randomly selected element from the list.