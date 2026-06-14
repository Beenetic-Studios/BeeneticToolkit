#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random.Utilities](index.md#BeeneticToolkit.Random.Utilities 'BeeneticToolkit.Random.Utilities').[RandomSelectors](RandomSelectors.md 'BeeneticToolkit.Random.Utilities.RandomSelectors')

## RandomSelectors.RandomChoice<T>(ReadOnlySpan<T>, RandomGenerator) Method

Selects a random element from a span, without allocating.

```csharp
public static T RandomChoice<T>(System.ReadOnlySpan<T> span, BeeneticToolkit.Random.RandomGenerator? random=null);
```
#### Type parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoice_T_(System.ReadOnlySpan_T_,BeeneticToolkit.Random.RandomGenerator).T'></a>

`T`

The type of elements in the span.
#### Parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoice_T_(System.ReadOnlySpan_T_,BeeneticToolkit.Random.RandomGenerator).span'></a>

`span` [System.ReadOnlySpan&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')[T](RandomSelectors.RandomChoice_T_(ReadOnlySpan_T_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoice_T_(System.ReadOnlySpan_T_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoice<T>(System.ReadOnlySpan<T>, BeeneticToolkit.Random.RandomGenerator).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')

The span from which to select a random element.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoice_T_(System.ReadOnlySpan_T_,BeeneticToolkit.Random.RandomGenerator).random'></a>

`random` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The random number generator to use, or null to use the default generator.

#### Returns
[T](RandomSelectors.RandomChoice_T_(ReadOnlySpan_T_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoice_T_(System.ReadOnlySpan_T_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoice<T>(System.ReadOnlySpan<T>, BeeneticToolkit.Random.RandomGenerator).T')  
A randomly selected element from the span.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [span](RandomSelectors.RandomChoice_T_(ReadOnlySpan_T_,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoice_T_(System.ReadOnlySpan_T_,BeeneticToolkit.Random.RandomGenerator).span 'BeeneticToolkit.Random.Utilities.RandomSelectors.RandomChoice<T>(System.ReadOnlySpan<T>, BeeneticToolkit.Random.RandomGenerator).span') is empty.