#### [Random](index.md 'index')
### [BeeneticToolkit.Random.Utilities](index.md#BeeneticToolkit.Random.Utilities 'BeeneticToolkit.Random.Utilities').[RandomSelectors](RandomSelectors.md 'BeeneticToolkit.Random.Utilities.RandomSelectors')

## RandomSelectors.TryRandomChoice<T>(IList<T>, T, RandomGenerator) Method

Attempts to select a random element from a list without throwing exceptions.

```csharp
public static bool TryRandomChoice<T>(System.Collections.Generic.IList<T>? list, out T result, BeeneticToolkit.Random.RandomGenerator? random=null);
```
#### Type parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice_T_(System.Collections.Generic.IList_T_,T,BeeneticToolkit.Random.RandomGenerator).T'></a>

`T`

The type of elements in the list.
#### Parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice_T_(System.Collections.Generic.IList_T_,T,BeeneticToolkit.Random.RandomGenerator).list'></a>

`list` [System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[T](RandomSelectors.TryRandomChoice_T_(IList_T_,T,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice_T_(System.Collections.Generic.IList_T_,T,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice<T>(System.Collections.Generic.IList<T>, T, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')

The list from which to select a random element. May be null or empty.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice_T_(System.Collections.Generic.IList_T_,T,BeeneticToolkit.Random.RandomGenerator).result'></a>

`result` [T](RandomSelectors.TryRandomChoice_T_(IList_T_,T,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice_T_(System.Collections.Generic.IList_T_,T,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice<T>(System.Collections.Generic.IList<T>, T, BeeneticToolkit.Random.RandomGenerator).T')

When this method returns, contains the randomly selected element if the operation succeeded; otherwise, the default value for [T](RandomSelectors.TryRandomChoice_T_(IList_T_,T,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice_T_(System.Collections.Generic.IList_T_,T,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice<T>(System.Collections.Generic.IList<T>, T, BeeneticToolkit.Random.RandomGenerator).T').

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice_T_(System.Collections.Generic.IList_T_,T,BeeneticToolkit.Random.RandomGenerator).random'></a>

`random` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The random number generator to use, or null to use the default generator.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if a random element was successfully selected; otherwise `false`.