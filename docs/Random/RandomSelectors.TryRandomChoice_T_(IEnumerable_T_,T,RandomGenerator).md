#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random.Utilities](index.md#BeeneticToolkit.Random.Utilities 'BeeneticToolkit.Random.Utilities').[RandomSelectors](RandomSelectors.md 'BeeneticToolkit.Random.Utilities.RandomSelectors')

## RandomSelectors.TryRandomChoice<T>(IEnumerable<T>, T, RandomGenerator) Method

Attempts to select a random element from an [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1') sequence without throwing exceptions.

```csharp
public static bool TryRandomChoice<T>(System.Collections.Generic.IEnumerable<T>? sequence, out T result, BeeneticToolkit.Random.RandomGenerator? random=null);
```
#### Type parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice_T_(System.Collections.Generic.IEnumerable_T_,T,BeeneticToolkit.Random.RandomGenerator).T'></a>

`T`

The type of elements in the sequence.
#### Parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice_T_(System.Collections.Generic.IEnumerable_T_,T,BeeneticToolkit.Random.RandomGenerator).sequence'></a>

`sequence` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](RandomSelectors.TryRandomChoice_T_(IEnumerable_T_,T,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice_T_(System.Collections.Generic.IEnumerable_T_,T,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice<T>(System.Collections.Generic.IEnumerable<T>, T, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The sequence from which to select a random element. May be null or empty.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice_T_(System.Collections.Generic.IEnumerable_T_,T,BeeneticToolkit.Random.RandomGenerator).result'></a>

`result` [T](RandomSelectors.TryRandomChoice_T_(IEnumerable_T_,T,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice_T_(System.Collections.Generic.IEnumerable_T_,T,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice<T>(System.Collections.Generic.IEnumerable<T>, T, BeeneticToolkit.Random.RandomGenerator).T')

When this method returns, contains the randomly selected element if the operation succeeded; otherwise, the default value for [T](RandomSelectors.TryRandomChoice_T_(IEnumerable_T_,T,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice_T_(System.Collections.Generic.IEnumerable_T_,T,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice<T>(System.Collections.Generic.IEnumerable<T>, T, BeeneticToolkit.Random.RandomGenerator).T').

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomChoice_T_(System.Collections.Generic.IEnumerable_T_,T,BeeneticToolkit.Random.RandomGenerator).random'></a>

`random` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The random number generator to use, or null to use the default generator.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if a random element was successfully selected; otherwise `false`.