#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators')

## EnumItemGroupComparator<TGroup> Class

A comparator for sorting [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances by their [Group](EnumItem_TGroup_.Group.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.Group') property.

```csharp
public class EnumItemGroupComparator<TGroup> : BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>
    where TGroup : struct, System.Enum, System.ValueType, System.ValueType
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator_TGroup_.TGroup'></a>

`TGroup`

The type of the group associated with the enumeration item. Must be an enumeration.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator&lt;](PropertyComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>')[TGroup](EnumItemGroupComparator_TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator<TGroup>.TGroup')[&gt;](PropertyComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>') &#129106; EnumItemGroupComparator<TGroup>

| Constructors | |
| :--- | :--- |
| [EnumItemGroupComparator(bool)](EnumItemGroupComparator_TGroup_.EnumItemGroupComparator(bool).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator<TGroup>.EnumItemGroupComparator(bool)') | Initializes a new instance of the [EnumItemGroupComparator&lt;TGroup&gt;](EnumItemGroupComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator<TGroup>') class. |

| Methods | |
| :--- | :--- |
| [PerformComparison(EnumItem&lt;TGroup&gt;, EnumItem&lt;TGroup&gt;)](EnumItemGroupComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>)') | Compares two [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances by their [Group](EnumItem_TGroup_.Group.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.Group') property. |
