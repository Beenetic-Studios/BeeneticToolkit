#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators')

## EnumItemShortNameComparator<TKey,TGroup> Class

A comparator for sorting [EnumItem&lt;TKey,TGroup&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>') instances by their [ShortName](EnumItem_TKey,TGroup_.ShortName.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.ShortName') property.

```csharp
public class EnumItemShortNameComparator<TKey,TGroup> : BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey, TGroup>
    where TKey : notnull
    where TGroup : struct, System.Enum, System.ValueType, System.ValueType
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator_TKey,TGroup_.TKey'></a>

`TKey`

The type of the key associated with the enumeration item.

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator_TKey,TGroup_.TGroup'></a>

`TGroup`

The type of the group associated with the enumeration item. Must be an enumeration.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator&lt;](PropertyComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>')[TKey](EnumItemShortNameComparator_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator_TKey,TGroup_.TKey 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator<TKey,TGroup>.TKey')[,](PropertyComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>')[TGroup](EnumItemShortNameComparator_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator_TKey,TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator<TKey,TGroup>.TGroup')[&gt;](PropertyComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>') &#129106; EnumItemShortNameComparator<TKey,TGroup>

| Constructors | |
| :--- | :--- |
| [EnumItemShortNameComparator(bool)](EnumItemShortNameComparator_TKey,TGroup_.EnumItemShortNameComparator(bool).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator<TKey,TGroup>.EnumItemShortNameComparator(bool)') | Initializes a new instance of the [EnumItemShortNameComparator&lt;TKey,TGroup&gt;](EnumItemShortNameComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator<TKey,TGroup>') class. |

| Methods | |
| :--- | :--- |
| [PerformComparison(EnumItem&lt;TKey,TGroup&gt;, EnumItem&lt;TKey,TGroup&gt;)](EnumItemShortNameComparator_TKey,TGroup_.PerformComparison(EnumItem_TKey,TGroup_,EnumItem_TKey,TGroup_).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator<TKey,TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>)') | Compares two [EnumItem&lt;TKey,TGroup&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>') instances by their [ShortName](EnumItem_TKey,TGroup_.ShortName.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.ShortName') property. |
