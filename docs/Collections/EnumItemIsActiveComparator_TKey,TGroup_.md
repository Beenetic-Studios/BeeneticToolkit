#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators')

## EnumItemIsActiveComparator<TKey,TGroup> Class

A comparator for sorting [EnumItem&lt;TKey,TGroup&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>') instances by their [IsActive](EnumItem_TKey,TGroup_.IsActive.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.IsActive') property.

```csharp
public class EnumItemIsActiveComparator<TKey,TGroup> : BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey, TGroup>
    where TKey : notnull
    where TGroup : struct, System.Enum, System.ValueType, System.ValueType
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator_TKey,TGroup_.TKey'></a>

`TKey`

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator_TKey,TGroup_.TGroup'></a>

`TGroup`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator&lt;](PropertyComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>')[TKey](EnumItemIsActiveComparator_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator_TKey,TGroup_.TKey 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator<TKey,TGroup>.TKey')[,](PropertyComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>')[TGroup](EnumItemIsActiveComparator_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator_TKey,TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator<TKey,TGroup>.TGroup')[&gt;](PropertyComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>') &#129106; EnumItemIsActiveComparator<TKey,TGroup>

| Constructors | |
| :--- | :--- |
| [EnumItemIsActiveComparator(bool)](EnumItemIsActiveComparator_TKey,TGroup_.EnumItemIsActiveComparator(bool).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator<TKey,TGroup>.EnumItemIsActiveComparator(bool)') | Initializes a new instance of the [EnumItemIsActiveComparator&lt;TKey,TGroup&gt;](EnumItemIsActiveComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator<TKey,TGroup>') class. |

| Methods | |
| :--- | :--- |
| [PerformComparison(EnumItem&lt;TKey,TGroup&gt;, EnumItem&lt;TKey,TGroup&gt;)](EnumItemIsActiveComparator_TKey,TGroup_.PerformComparison(EnumItem_TKey,TGroup_,EnumItem_TKey,TGroup_).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator<TKey,TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>)') | Compares two [EnumItem&lt;TKey,TGroup&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>') instances by their [IsActive](EnumItem_TKey,TGroup_.IsActive.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.IsActive') property. |
