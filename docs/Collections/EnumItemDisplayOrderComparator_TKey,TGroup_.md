#### [BeeneticToolkit.Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators')

## EnumItemDisplayOrderComparator<TKey,TGroup> Class

A comparator for sorting [EnumItem&lt;TKey,TGroup&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>') instances by their [DisplayOrder](EnumItem_TKey,TGroup_.DisplayOrder.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.DisplayOrder') property.

```csharp
public class EnumItemDisplayOrderComparator<TKey,TGroup> : BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey, TGroup>
    where TKey : notnull
    where TGroup : struct, System.Enum, System.ValueType, System.ValueType
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemDisplayOrderComparator_TKey,TGroup_.TKey'></a>

`TKey`

The type of the key associated with the enumeration item.

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemDisplayOrderComparator_TKey,TGroup_.TGroup'></a>

`TGroup`

The type of the group associated with the enumeration item. Must be an enumeration.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator&lt;](PropertyComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>')[TKey](EnumItemDisplayOrderComparator_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemDisplayOrderComparator_TKey,TGroup_.TKey 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemDisplayOrderComparator<TKey,TGroup>.TKey')[,](PropertyComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>')[TGroup](EnumItemDisplayOrderComparator_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemDisplayOrderComparator_TKey,TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemDisplayOrderComparator<TKey,TGroup>.TGroup')[&gt;](PropertyComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>') &#129106; EnumItemDisplayOrderComparator<TKey,TGroup>

| Constructors | |
| :--- | :--- |
| [EnumItemDisplayOrderComparator(bool)](EnumItemDisplayOrderComparator_TKey,TGroup_.EnumItemDisplayOrderComparator(bool).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemDisplayOrderComparator<TKey,TGroup>.EnumItemDisplayOrderComparator(bool)') | Initializes a new instance of the [EnumItemDisplayOrderComparator&lt;TKey,TGroup&gt;](EnumItemDisplayOrderComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemDisplayOrderComparator<TKey,TGroup>') class. |

| Methods | |
| :--- | :--- |
| [PerformComparison(EnumItem&lt;TKey,TGroup&gt;, EnumItem&lt;TKey,TGroup&gt;)](EnumItemDisplayOrderComparator_TKey,TGroup_.PerformComparison(EnumItem_TKey,TGroup_,EnumItem_TKey,TGroup_).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemDisplayOrderComparator<TKey,TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>)') | Compares two [EnumItem&lt;TKey,TGroup&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>') instances by their [DisplayOrder](EnumItem_TKey,TGroup_.DisplayOrder.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.DisplayOrder') property. |
