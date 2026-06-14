#### [Random](index.md 'index')
### [BeeneticToolkit.Random.Utilities](index.md#BeeneticToolkit.Random.Utilities 'BeeneticToolkit.Random.Utilities').[RandomSelectors](RandomSelectors.md 'BeeneticToolkit.Random.Utilities.RandomSelectors')

## RandomSelectors.RandomWeightedChoice<T>(IEnumerable<T>, Func<T,double>, RandomGenerator) Method

Selects a random element from a sequence, with each item's likelihood proportional to the  
weight returned by [weightSelector](RandomSelectors.RandomWeightedChoice_T_(IEnumerable_T_,Func_T,double_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,double_,BeeneticToolkit.Random.RandomGenerator).weightSelector 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IEnumerable<T>, System.Func<T,double>, BeeneticToolkit.Random.RandomGenerator).weightSelector').

```csharp
public static T RandomWeightedChoice<T>(System.Collections.Generic.IEnumerable<T> items, System.Func<T,double> weightSelector, BeeneticToolkit.Random.RandomGenerator? random=null);
```
#### Type parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,double_,BeeneticToolkit.Random.RandomGenerator).T'></a>

`T`

The type of the items.
#### Parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,double_,BeeneticToolkit.Random.RandomGenerator).items'></a>

`items` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](RandomSelectors.RandomWeightedChoice_T_(IEnumerable_T_,Func_T,double_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,double_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IEnumerable<T>, System.Func<T,double>, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The items to choose from.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,double_,BeeneticToolkit.Random.RandomGenerator).weightSelector'></a>

`weightSelector` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](RandomSelectors.RandomWeightedChoice_T_(IEnumerable_T_,Func_T,double_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,double_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IEnumerable<T>, System.Func<T,double>, BeeneticToolkit.Random.RandomGenerator).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

A function returning the weight for a given item.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,double_,BeeneticToolkit.Random.RandomGenerator).random'></a>

`random` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The random number generator to use, or null to use the default generator.

#### Returns
[T](RandomSelectors.RandomWeightedChoice_T_(IEnumerable_T_,Func_T,double_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,double_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IEnumerable<T>, System.Func<T,double>, BeeneticToolkit.Random.RandomGenerator).T')  
A randomly selected item, weighted by [weightSelector](RandomSelectors.RandomWeightedChoice_T_(IEnumerable_T_,Func_T,double_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,double_,BeeneticToolkit.Random.RandomGenerator).weightSelector 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IEnumerable<T>, System.Func<T,double>, BeeneticToolkit.Random.RandomGenerator).weightSelector').

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when [items](RandomSelectors.RandomWeightedChoice_T_(IEnumerable_T_,Func_T,double_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,double_,BeeneticToolkit.Random.RandomGenerator).items 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IEnumerable<T>, System.Func<T,double>, BeeneticToolkit.Random.RandomGenerator).items') or [weightSelector](RandomSelectors.RandomWeightedChoice_T_(IEnumerable_T_,Func_T,double_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,double_,BeeneticToolkit.Random.RandomGenerator).weightSelector 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IEnumerable<T>, System.Func<T,double>, BeeneticToolkit.Random.RandomGenerator).weightSelector') is null.

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [items](RandomSelectors.RandomWeightedChoice_T_(IEnumerable_T_,Func_T,double_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.IEnumerable_T_,System.Func_T,double_,BeeneticToolkit.Random.RandomGenerator).items 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.IEnumerable<T>, System.Func<T,double>, BeeneticToolkit.Random.RandomGenerator).items') is empty.

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown when the total weight is not greater than zero.