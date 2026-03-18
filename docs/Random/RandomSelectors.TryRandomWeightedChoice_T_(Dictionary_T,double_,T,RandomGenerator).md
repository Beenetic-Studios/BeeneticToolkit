#### [Random](index.md 'index')
### [BeeneticToolkit.Random.Utilities](index.md#BeeneticToolkit.Random.Utilities 'BeeneticToolkit.Random.Utilities').[RandomSelectors](RandomSelectors.md 'BeeneticToolkit.Random.Utilities.RandomSelectors')

## RandomSelectors.TryRandomWeightedChoice<T>(Dictionary<T,double>, T, RandomGenerator) Method

Attempts to select a random element from a dictionary, with each element's likelihood determined by its associated weight, without throwing exceptions.

```csharp
public static bool TryRandomWeightedChoice<T>(System.Collections.Generic.Dictionary<T,double>? typeWeightDict, out T result, BeeneticToolkit.Random.RandomGenerator? random=null);
```
#### Type parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomWeightedChoice_T_(System.Collections.Generic.Dictionary_T,double_,T,BeeneticToolkit.Random.RandomGenerator).T'></a>

`T`

The type of keys in the dictionary.
#### Parameters

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomWeightedChoice_T_(System.Collections.Generic.Dictionary_T,double_,T,BeeneticToolkit.Random.RandomGenerator).typeWeightDict'></a>

`typeWeightDict` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[T](RandomSelectors.TryRandomWeightedChoice_T_(Dictionary_T,double_,T,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomWeightedChoice_T_(System.Collections.Generic.Dictionary_T,double_,T,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomWeightedChoice<T>(System.Collections.Generic.Dictionary<T,double>, T, BeeneticToolkit.Random.RandomGenerator).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

The dictionary containing items as keys and their associated weights as values. May be null or empty.

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomWeightedChoice_T_(System.Collections.Generic.Dictionary_T,double_,T,BeeneticToolkit.Random.RandomGenerator).result'></a>

`result` [T](RandomSelectors.TryRandomWeightedChoice_T_(Dictionary_T,double_,T,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomWeightedChoice_T_(System.Collections.Generic.Dictionary_T,double_,T,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomWeightedChoice<T>(System.Collections.Generic.Dictionary<T,double>, T, BeeneticToolkit.Random.RandomGenerator).T')

When this method returns, contains the randomly selected key if the operation succeeded; otherwise, the default value for [T](RandomSelectors.TryRandomWeightedChoice_T_(Dictionary_T,double_,T,RandomGenerator).md#BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomWeightedChoice_T_(System.Collections.Generic.Dictionary_T,double_,T,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomWeightedChoice<T>(System.Collections.Generic.Dictionary<T,double>, T, BeeneticToolkit.Random.RandomGenerator).T').

<a name='BeeneticToolkit.Random.Utilities.RandomSelectors.TryRandomWeightedChoice_T_(System.Collections.Generic.Dictionary_T,double_,T,BeeneticToolkit.Random.RandomGenerator).random'></a>

`random` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The random number generator to use, or null to use the default generator.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if a weighted random key was successfully selected; otherwise `false`.