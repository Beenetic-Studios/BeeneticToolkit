#### [Random](index.md 'index')
### [BeeneticToolkit.Random.Utility](index.md#BeeneticToolkit.Random.Utility 'BeeneticToolkit.Random.Utility').[RandomSelectors](RandomSelectors.md 'BeeneticToolkit.Random.Utility.RandomSelectors')

## RandomSelectors.RandomWeightedChoice<T>(Dictionary<T,double>, RandomGenerator) Method

Selects a random element from a dictionary, with each element's likelihood of being chosen  
determined by its associated weight.

```csharp
public static T RandomWeightedChoice<T>(System.Collections.Generic.Dictionary<T,double> typeWeightDict, BeeneticToolkit.Random.RandomGenerator? random=null);
```
#### Type parameters

<a name='BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.Dictionary_T,double_,BeeneticToolkit.Random.RandomGenerator).T'></a>

`T`

The type of elements used as the dictionary's keys.
#### Parameters

<a name='BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.Dictionary_T,double_,BeeneticToolkit.Random.RandomGenerator).typeWeightDict'></a>

`typeWeightDict` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[T](RandomSelectors.RandomWeightedChoice_T_(Dictionary_T,double_,RandomGenerator).md#BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.Dictionary_T,double_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.Dictionary<T,double>, BeeneticToolkit.Random.RandomGenerator).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

The dictionary containing items as keys and their associated weights as values.

<a name='BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.Dictionary_T,double_,BeeneticToolkit.Random.RandomGenerator).random'></a>

`random` [RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

The random number generator to use, or `null` to use the default generator.

#### Returns
[T](RandomSelectors.RandomWeightedChoice_T_(Dictionary_T,double_,RandomGenerator).md#BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.Dictionary_T,double_,BeeneticToolkit.Random.RandomGenerator).T 'BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.Dictionary<T,double>, BeeneticToolkit.Random.RandomGenerator).T')  
A randomly selected key from the dictionary, weighted by the corresponding values.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when [typeWeightDict](RandomSelectors.RandomWeightedChoice_T_(Dictionary_T,double_,RandomGenerator).md#BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.Dictionary_T,double_,BeeneticToolkit.Random.RandomGenerator).typeWeightDict 'BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.Dictionary<T,double>, BeeneticToolkit.Random.RandomGenerator).typeWeightDict') is `null`.

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [typeWeightDict](RandomSelectors.RandomWeightedChoice_T_(Dictionary_T,double_,RandomGenerator).md#BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice_T_(System.Collections.Generic.Dictionary_T,double_,BeeneticToolkit.Random.RandomGenerator).typeWeightDict 'BeeneticToolkit.Random.Utility.RandomSelectors.RandomWeightedChoice<T>(System.Collections.Generic.Dictionary<T,double>, BeeneticToolkit.Random.RandomGenerator).typeWeightDict') is empty.

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown when no valid item is selected. This could occur if the weights are improperly configured  
(e.g., all weights are zero or negative).