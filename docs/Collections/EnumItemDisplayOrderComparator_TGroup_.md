#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators')

## EnumItemDisplayOrderComparator<TGroup> Class

A comparator for sorting [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances by their [DisplayOrder](EnumItem_TGroup_.DisplayOrder.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.DisplayOrder') property.

```csharp
public class EnumItemDisplayOrderComparator<TGroup> : BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>
    where TGroup : struct, System.Enum, System.ValueType, System.ValueType
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemDisplayOrderComparator_TGroup_.TGroup'></a>

`TGroup`

The type of the group associated with the enumeration item, which must be an enumeration.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator&lt;](PropertyComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>')[TGroup](EnumItemDisplayOrderComparator_TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemDisplayOrderComparator_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemDisplayOrderComparator<TGroup>.TGroup')[&gt;](PropertyComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>') &#129106; EnumItemDisplayOrderComparator<TGroup>

| Constructors | |
| :--- | :--- |
| [EnumItemDisplayOrderComparator(bool)](EnumItemDisplayOrderComparator_TGroup_.EnumItemDisplayOrderComparator(bool).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemDisplayOrderComparator<TGroup>.EnumItemDisplayOrderComparator(bool)') | Initializes a new instance of the [EnumItemDisplayOrderComparator&lt;TGroup&gt;](EnumItemDisplayOrderComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemDisplayOrderComparator<TGroup>') class. |

| Methods | |
| :--- | :--- |
| [PerformComparison(EnumItem&lt;TGroup&gt;, EnumItem&lt;TGroup&gt;)](EnumItemDisplayOrderComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemDisplayOrderComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>)') | Compares two [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances by their [DisplayOrder](EnumItem_TGroup_.DisplayOrder.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.DisplayOrder') property. |
