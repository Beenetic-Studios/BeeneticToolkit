#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators')

## EnumItemIsActiveComparator<TGroup> Class

A comparator for sorting [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances by their [IsActive](EnumItem_TGroup_.IsActive.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.IsActive') property.

```csharp
public class EnumItemIsActiveComparator<TGroup> : BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>
    where TGroup : struct, System.Enum, System.ValueType, System.ValueType
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator_TGroup_.TGroup'></a>

`TGroup`

The type of the group associated with the enumeration item. Must be an enumeration.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator&lt;](PropertyComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>')[TGroup](EnumItemIsActiveComparator_TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator<TGroup>.TGroup')[&gt;](PropertyComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>') &#129106; EnumItemIsActiveComparator<TGroup>

| Constructors | |
| :--- | :--- |
| [EnumItemIsActiveComparator(bool)](EnumItemIsActiveComparator_TGroup_.EnumItemIsActiveComparator(bool).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator<TGroup>.EnumItemIsActiveComparator(bool)') | Initializes a new instance of the [EnumItemIsActiveComparator&lt;TGroup&gt;](EnumItemIsActiveComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator<TGroup>') class. |

| Methods | |
| :--- | :--- |
| [PerformComparison(EnumItem&lt;TGroup&gt;, EnumItem&lt;TGroup&gt;)](EnumItemIsActiveComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>)') | Compares two [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances by their [IsActive](EnumItem_TGroup_.IsActive.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.IsActive') property. |
