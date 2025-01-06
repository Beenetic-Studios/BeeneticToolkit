#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators')

## EnumItemKeyComparator<TGroup> Class

A comparator for sorting [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances by their [Key](EnumItem_TGroup_.Key.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.Key') property.

```csharp
public class EnumItemKeyComparator<TGroup> : BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>
    where TGroup : struct, System.Enum, System.ValueType, System.ValueType
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator_TGroup_.TGroup'></a>

`TGroup`

The type of the group associated with the enumeration item. Must be an enumeration.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator&lt;](PropertyComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>')[TGroup](EnumItemKeyComparator_TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TGroup>.TGroup')[&gt;](PropertyComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>') &#129106; EnumItemKeyComparator<TGroup>

| Constructors | |
| :--- | :--- |
| [EnumItemKeyComparator(bool)](EnumItemKeyComparator_TGroup_.EnumItemKeyComparator(bool).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TGroup>.EnumItemKeyComparator(bool)') | Initializes a new instance of the [EnumItemKeyComparator&lt;TGroup&gt;](EnumItemKeyComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TGroup>') class. |

| Methods | |
| :--- | :--- |
| [PerformComparison(EnumItem&lt;TGroup&gt;, EnumItem&lt;TGroup&gt;)](EnumItemKeyComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>)') | Compares two [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances by their [Key](EnumItem_TGroup_.Key.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.Key') property. |
