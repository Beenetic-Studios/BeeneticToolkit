#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators')

## EnumItemGroupComparator<TKey,TGroup> Class

A comparator for sorting [EnumItem&lt;TKey,TGroup&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>') instances by their [Group](EnumItem_TKey,TGroup_.Group.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.Group') property.

```csharp
public class EnumItemGroupComparator<TKey,TGroup> : BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey, TGroup>
    where TKey : notnull
    where TGroup : struct, System.Enum, System.ValueType, System.ValueType
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator_TKey,TGroup_.TKey'></a>

`TKey`

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator_TKey,TGroup_.TGroup'></a>

`TGroup`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator&lt;](PropertyComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>')[TKey](EnumItemGroupComparator_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator_TKey,TGroup_.TKey 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator<TKey,TGroup>.TKey')[,](PropertyComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>')[TGroup](EnumItemGroupComparator_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator_TKey,TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator<TKey,TGroup>.TGroup')[&gt;](PropertyComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>') &#129106; EnumItemGroupComparator<TKey,TGroup>

| Constructors | |
| :--- | :--- |
| [EnumItemGroupComparator(bool)](EnumItemGroupComparator_TKey,TGroup_.EnumItemGroupComparator(bool).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator<TKey,TGroup>.EnumItemGroupComparator(bool)') | Initializes a new instance of the [EnumItemGroupComparator&lt;TKey,TGroup&gt;](EnumItemGroupComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator<TKey,TGroup>') class. |

| Methods | |
| :--- | :--- |
| [PerformComparison(EnumItem&lt;TKey,TGroup&gt;, EnumItem&lt;TKey,TGroup&gt;)](EnumItemGroupComparator_TKey,TGroup_.PerformComparison(EnumItem_TKey,TGroup_,EnumItem_TKey,TGroup_).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator<TKey,TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>)') | Compares two [EnumItem&lt;TKey,TGroup&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>') instances by their [Group](EnumItem_TKey,TGroup_.Group.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.Group') property. |
