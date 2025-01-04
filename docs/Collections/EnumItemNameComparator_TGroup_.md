#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators')

## EnumItemNameComparator<TGroup> Class

A comparator for sorting [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances by their [Name](EnumItem_TGroup_.Name.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.Name') property.

```csharp
public class EnumItemNameComparator<TGroup> : BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>
    where TGroup : struct, System.Enum, System.ValueType, System.ValueType
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemNameComparator_TGroup_.TGroup'></a>

`TGroup`

The type of the group associated with the enumeration item, which must be an enumeration.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator&lt;](PropertyComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>')[TGroup](EnumItemNameComparator_TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemNameComparator_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemNameComparator<TGroup>.TGroup')[&gt;](PropertyComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>') &#129106; EnumItemNameComparator<TGroup>

| Constructors | |
| :--- | :--- |
| [EnumItemNameComparator(bool)](EnumItemNameComparator_TGroup_.EnumItemNameComparator(bool).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemNameComparator<TGroup>.EnumItemNameComparator(bool)') | Initializes a new instance of the [EnumItemNameComparator&lt;TGroup&gt;](EnumItemNameComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemNameComparator<TGroup>') class. |

| Methods | |
| :--- | :--- |
| [PerformComparison(EnumItem&lt;TGroup&gt;, EnumItem&lt;TGroup&gt;)](EnumItemNameComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemNameComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>)') | Compares two [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances by their [Name](EnumItem_TGroup_.Name.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.Name') property. |
