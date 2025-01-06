#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators')

## EnumItemShortNameComparator<TGroup> Class

A comparator for sorting [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances by their [ShortName](EnumItem_TGroup_.ShortName.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.ShortName') property.

```csharp
public class EnumItemShortNameComparator<TGroup> : BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>
    where TGroup : struct, System.Enum, System.ValueType, System.ValueType
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator_TGroup_.TGroup'></a>

`TGroup`

The type of the group associated with the enumeration item. Must be an enumeration.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator&lt;](PropertyComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>')[TGroup](EnumItemShortNameComparator_TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator<TGroup>.TGroup')[&gt;](PropertyComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>') &#129106; EnumItemShortNameComparator<TGroup>

| Constructors | |
| :--- | :--- |
| [EnumItemShortNameComparator(bool)](EnumItemShortNameComparator_TGroup_.EnumItemShortNameComparator(bool).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator<TGroup>.EnumItemShortNameComparator(bool)') | Initializes a new instance of the [EnumItemShortNameComparator&lt;TGroup&gt;](EnumItemShortNameComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator<TGroup>') class. |

| Methods | |
| :--- | :--- |
| [PerformComparison(EnumItem&lt;TGroup&gt;, EnumItem&lt;TGroup&gt;)](EnumItemShortNameComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>)') | Compares two [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances by their [ShortName](EnumItem_TGroup_.ShortName.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.ShortName') property. |
