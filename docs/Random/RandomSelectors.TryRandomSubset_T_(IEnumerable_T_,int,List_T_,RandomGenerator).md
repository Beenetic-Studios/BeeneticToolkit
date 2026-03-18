#### [Random](index.md 'index')
### [BeeneticToolkit.Random.Utilities](index.md#BeeneticToolkit.Random.Utilities 'BeeneticToolkit.Random.Utilities').[RandomSelectors](RandomSelectors.md 'BeeneticToolkit.Random.Utilities.RandomSelectors')

## RandomSelectors.TryRandomSubset<T>(IEnumerable<T>, int, List<T>, RandomGenerator) Method

Attempts to select a random subset of a specified size from an [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1') sequence without throwing exceptions.

```csharp
public static bool TryRandomSubset<T>(System.Collections.Generic.IEnumerable<T>? sequence, int subsetSize, out System.Collections.Generic.List<T>? result, BeeneticToolkit.Random.RandomGenerator? random=null);
```
#### Type parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomSubset_T_(System.Collections.Generic.IEnumerable_T_,int,System.Collections.Generic.List_T_,BeeneticToolkit.Random.RandomGenerator).T'></a>

`T`

The type of elements in the sequence.
#### Parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomSubset_T_(System.Collections.Generic.IEnumerable_T_,int,System.Collections.Generic.List_T_,BeeneticToolkit.Random.RandomGenerator).sequence'></a>

`sequence` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](RandomSelectors.TryRandomSubset_T_(IEnumerable_T_,int,List_T_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomSubset_T_(System.Collections.Generic.IEnumerable_T_,int,System.Collections.Generic.List_T_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomSubset<T>(System.Collections.Generic.IEnumerable<T>, int, System.Collections.Generic.List<T>, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The sequence from which to select a random subset. May be null or empty.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomSubset_T_(System.Collections.Generic.IEnumerable_T_,int,System.Collections.Generic.List_T_,BeeneticToolkit.Random.RandomGenerator).subsetSize'></a>

`subsetSize` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The desired size of the subset. Must be greater than 0 and less than or equal to the sequence size.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomSubset_T_(System.Collections.Generic.IEnumerable_T_,int,System.Collections.Generic.List_T_,BeeneticToolkit.Random.RandomGenerator).result'></a>

`result` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](RandomSelectors.TryRandomSubset_T_(IEnumerable_T_,int,List_T_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomSubset_T_(System.Collections.Generic.IEnumerable_T_,int,System.Collections.Generic.List_T_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomSubset<T>(System.Collections.Generic.IEnumerable<T>, int, System.Collections.Generic.List<T>, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

When this method returns, contains the random subset if the operation succeeded; otherwise, null.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomSubset_T_(System.Collections.Generic.IEnumerable_T_,int,System.Collections.Generic.List_T_,BeeneticToolkit.Random.RandomGenerator).random'></a>

`random` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The random number generator to use, or null to use the default generator.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if a valid subset was successfully selected; otherwise `false`.