#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators')

## PropertyComparator<TGroup> Class

Serves as a base class for comparators that sort [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances by a specific property, with a fallback to the [Key](EnumItem_TGroup_.Key.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.Key') property for deterministic ordering.

```csharp
public abstract class PropertyComparator<TGroup> :
System.Collections.Generic.IComparer<BeeneticToolkit.Collections.Enums.EnumItem<TGroup>>
    where TGroup : struct, System.Enum, System.ValueType, System.ValueType
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TGroup_.TGroup'></a>

`TGroup`

The type of the group associated with the enumeration item. Must be an enumeration.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; PropertyComparator<TGroup>

Derived  
&#8627; [EnumItemDisplayOrderComparator&lt;TGroup&gt;](EnumItemDisplayOrderComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemDisplayOrderComparator<TGroup>')  
&#8627; [EnumItemGroupComparator&lt;TGroup&gt;](EnumItemGroupComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator<TGroup>')  
&#8627; [EnumItemIsActiveComparator&lt;TGroup&gt;](EnumItemIsActiveComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator<TGroup>')  
&#8627; [EnumItemKeyComparator&lt;TGroup&gt;](EnumItemKeyComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TGroup>')  
&#8627; [EnumItemNameComparator&lt;TGroup&gt;](EnumItemNameComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemNameComparator<TGroup>')  
&#8627; [EnumItemShortNameComparator&lt;TGroup&gt;](EnumItemShortNameComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator<TGroup>')

Implements [System.Collections.Generic.IComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1')[BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')[TGroup](PropertyComparator_TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>.TGroup')[&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1')

### Remarks
This class provides common logic for handling null values, sorting order (ascending or descending), and fallback to the [Key](EnumItem_TGroup_.Key.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.Key') property.

| Constructors | |
| :--- | :--- |
| [PropertyComparator(bool)](PropertyComparator_TGroup_.PropertyComparator(bool).md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>.PropertyComparator(bool)') | Initializes a new instance of the [PropertyComparator&lt;TGroup&gt;](PropertyComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>') class. |

| Methods | |
| :--- | :--- |
| [Compare(EnumItem&lt;TGroup&gt;, EnumItem&lt;TGroup&gt;)](PropertyComparator_TGroup_.Compare(EnumItem_TGroup_,EnumItem_TGroup_).md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>.Compare(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>)') | Compares two [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances by the property defined in [PerformComparison(EnumItem&lt;TGroup&gt;, EnumItem&lt;TGroup&gt;)](PropertyComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>)'), with a fallback to the [Key](EnumItem_TGroup_.Key.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.Key') property. |
| [PerformComparison(EnumItem&lt;TGroup&gt;, EnumItem&lt;TGroup&gt;)](PropertyComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>)') | Performs the primary comparison for the specific property this comparator is designed to sort by. |
