#### [Random](index.md 'index')
### [BeeneticToolkit.Random.Utilities](index.md#BeeneticToolkit.Random.Utilities 'BeeneticToolkit.Random.Utilities').[RandomSelectors](RandomSelectors.md 'BeeneticToolkit.Random.Utilities.RandomSelectors')

## RandomSelectors.RandomChoice<T>(IEnumerable<T>, RandomGenerator) Method

Selects a random element from an IEnumerable sequence.

```csharp
public static T RandomChoice<T>(System.Collections.Generic.IEnumerable<T> sequence, BeeneticToolkit.Random.RandomGenerator? random=null);
```
#### Type parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoice_T_(System.Collections.Generic.IEnumerable_T_,BeeneticToolkit.Random.RandomGenerator).T'></a>

`T`

The type of elements in the sequence.
#### Parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoice_T_(System.Collections.Generic.IEnumerable_T_,BeeneticToolkit.Random.RandomGenerator).sequence'></a>

`sequence` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](RandomSelectors.RandomChoice_T_(IEnumerable_T_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoice_T_(System.Collections.Generic.IEnumerable_T_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoice<T>(System.Collections.Generic.IEnumerable<T>, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The sequence from which to select a random element.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoice_T_(System.Collections.Generic.IEnumerable_T_,BeeneticToolkit.Random.RandomGenerator).random'></a>

`random` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The random number generator to use, or null to use the default generator.

#### Returns
[T](RandomSelectors.RandomChoice_T_(IEnumerable_T_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoice_T_(System.Collections.Generic.IEnumerable_T_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoice<T>(System.Collections.Generic.IEnumerable<T>, BeeneticToolkit.Random.RandomGenerator).T')  
A randomly selected element from the sequence.