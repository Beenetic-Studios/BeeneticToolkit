#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random.Utilities](index.md#BeeneticToolkit.Random.Utilities 'BeeneticToolkit.Random.Utilities').[RandomSelectors](RandomSelectors.md 'BeeneticToolkit.Random.Utilities.RandomSelectors')

## RandomSelectors.RandomSubset<T>(IEnumerable<T>, int, RandomGenerator) Method

Selects a random subset of a specified size from an IEnumerable sequence.

```csharp
public static System.Collections.Generic.List<T> RandomSubset<T>(System.Collections.Generic.IEnumerable<T> sequence, int subsetSize, BeeneticToolkit.Random.RandomGenerator? random=null);
```
#### Type parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomSubset_T_(System.Collections.Generic.IEnumerable_T_,int,BeeneticToolkit.Random.RandomGenerator).T'></a>

`T`

The type of elements in the sequence.
#### Parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomSubset_T_(System.Collections.Generic.IEnumerable_T_,int,BeeneticToolkit.Random.RandomGenerator).sequence'></a>

`sequence` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](RandomSelectors.RandomSubset_T_(IEnumerable_T_,int,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomSubset_T_(System.Collections.Generic.IEnumerable_T_,int,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomSubset<T>(System.Collections.Generic.IEnumerable<T>, int, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The sequence from which to select a random subset.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomSubset_T_(System.Collections.Generic.IEnumerable_T_,int,BeeneticToolkit.Random.RandomGenerator).subsetSize'></a>

`subsetSize` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The size of the subset to select.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomSubset_T_(System.Collections.Generic.IEnumerable_T_,int,BeeneticToolkit.Random.RandomGenerator).random'></a>

`random` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The random number generator to use, or null to use the default generator.

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](RandomSelectors.RandomSubset_T_(IEnumerable_T_,int,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomSubset_T_(System.Collections.Generic.IEnumerable_T_,int,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomSubset<T>(System.Collections.Generic.IEnumerable<T>, int, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')  
A list containing a random subset of the specified size.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when [sequence](RandomSelectors.RandomSubset_T_(IEnumerable_T_,int,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomSubset_T_(System.Collections.Generic.IEnumerable_T_,int,BeeneticToolkit.Random.RandomGenerator).sequence 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomSubset<T>(System.Collections.Generic.IEnumerable<T>, int, BeeneticToolkit.Random.RandomGenerator).sequence') is null.

[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
Thrown when [subsetSize](RandomSelectors.RandomSubset_T_(IEnumerable_T_,int,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomSubset_T_(System.Collections.Generic.IEnumerable_T_,int,BeeneticToolkit.Random.RandomGenerator).subsetSize 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomSubset<T>(System.Collections.Generic.IEnumerable<T>, int, BeeneticToolkit.Random.RandomGenerator).subsetSize') is invalid for the list size.

### Remarks
Converts the sequence to a list before selecting the subset.