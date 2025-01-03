#### [Random](index.md 'index')
### [BeeneticToolkit.Random.Utility](index.md#BeeneticToolkit.Random.Utility 'BeeneticToolkit.Random.Utility').[RandomSelectors](RandomSelectors.md 'BeeneticToolkit.Random.Utility.RandomSelectors')

## RandomSelectors.RandomSubset<T>(IList<T>, int, RandomGenerator) Method

Selects a random subset of a specified size from a list.

```csharp
public static System.Collections.Generic.List<T> RandomSubset<T>(System.Collections.Generic.IList<T> list, int subsetSize, BeeneticToolkit.Random.RandomGenerator? random=null);
```
#### Type parameters

<a name='BeeneticToolkit.Random.Utility.RandomSelectors.RandomSubset_T_(System.Collections.Generic.IList_T_,int,BeeneticToolkit.Random.RandomGenerator).T'></a>

`T`

The type of elements in the list.
#### Parameters

<a name='BeeneticToolkit.Random.Utility.RandomSelectors.RandomSubset_T_(System.Collections.Generic.IList_T_,int,BeeneticToolkit.Random.RandomGenerator).list'></a>

`list` [System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T](RandomSelectors.RandomSubset_T_(IList_T_,int,RandomGenerator).md#BeeneticToolkit.Random.Utility.RandomSelectors.RandomSubset_T_(System.Collections.Generic.IList_T_,int,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utility.RandomSelectors.RandomSubset<T>(System.Collections.Generic.IList<T>, int, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')

The list from which to select a random subset.

<a name='BeeneticToolkit.Random.Utility.RandomSelectors.RandomSubset_T_(System.Collections.Generic.IList_T_,int,BeeneticToolkit.Random.RandomGenerator).subsetSize'></a>

`subsetSize` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The size of the subset to select.

<a name='BeeneticToolkit.Random.Utility.RandomSelectors.RandomSubset_T_(System.Collections.Generic.IList_T_,int,BeeneticToolkit.Random.RandomGenerator).random'></a>

`random` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The random number generator to use, or null to use the default generator.

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](RandomSelectors.RandomSubset_T_(IList_T_,int,RandomGenerator).md#BeeneticToolkit.Random.Utility.RandomSelectors.RandomSubset_T_(System.Collections.Generic.IList_T_,int,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utility.RandomSelectors.RandomSubset<T>(System.Collections.Generic.IList<T>, int, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
A list containing a random subset of the specified size.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when the input list is empty.

[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
Thrown when the subset size is not within the valid range.