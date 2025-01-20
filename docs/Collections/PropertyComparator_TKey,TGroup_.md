#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators')

## PropertyComparator<TKey,TGroup> Class

Serves as a base class for comparators that sort [EnumItem&lt;TKey,TGroup&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>') instances by a specific property,  
with a fallback to the [Key](EnumItem_TKey,TGroup_.Key.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.Key') property for deterministic ordering.

```csharp
public abstract class PropertyComparator<TKey,TGroup> :
System.Collections.Generic.IComparer<BeeneticToolkit.Collections.Enums.EnumItem<TKey, TGroup>>
    where TKey : notnull
    where TGroup : struct, System.Enum, System.ValueType, System.ValueType
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TKey,TGroup_.TKey'></a>

`TKey`

The type of the key associated with the enumeration item.

<a name='BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TKey,TGroup_.TGroup'></a>

`TGroup`

The type of the group associated with the enumeration item. Must be an enumeration.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; PropertyComparator<TKey,TGroup>

Derived  
&#8627; [EnumItemDisplayOrderComparator&lt;TKey,TGroup&gt;](EnumItemDisplayOrderComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemDisplayOrderComparator<TKey,TGroup>')  
&#8627; [EnumItemGroupComparator&lt;TKey,TGroup&gt;](EnumItemGroupComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator<TKey,TGroup>')  
&#8627; [EnumItemIsActiveComparator&lt;TKey,TGroup&gt;](EnumItemIsActiveComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator<TKey,TGroup>')  
&#8627; [EnumItemKeyComparator&lt;TKey,TGroup&gt;](EnumItemKeyComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TKey,TGroup>')  
&#8627; [EnumItemNameComparator&lt;TKey,TGroup&gt;](EnumItemNameComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemNameComparator<TKey,TGroup>')  
&#8627; [EnumItemShortNameComparator&lt;TKey,TGroup&gt;](EnumItemShortNameComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator<TKey,TGroup>')

Implements [System.Collections.Generic.IComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1')[BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')[TKey](PropertyComparator_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TKey,TGroup_.TKey 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>.TKey')[,](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')[TGroup](PropertyComparator_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TKey,TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>.TGroup')[&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1')

### Remarks
This class provides common logic for handling null values, sorting order (ascending or descending),  
and fallback to the [Key](EnumItem_TKey,TGroup_.Key.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.Key') property.

| Constructors | |
| :--- | :--- |
| [PropertyComparator(bool)](PropertyComparator_TKey,TGroup_.PropertyComparator(bool).md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>.PropertyComparator(bool)') | Initializes a new instance of the [PropertyComparator&lt;TKey,TGroup&gt;](PropertyComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>') class. |

| Methods | |
| :--- | :--- |
| [Compare(EnumItem&lt;TKey,TGroup&gt;, EnumItem&lt;TKey,TGroup&gt;)](PropertyComparator_TKey,TGroup_.Compare(EnumItem_TKey,TGroup_,EnumItem_TKey,TGroup_).md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>.Compare(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>)') | Compares two [EnumItem&lt;TKey,TGroup&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>') instances by the property defined in [PerformComparison(EnumItem&lt;TKey,TGroup&gt;, EnumItem&lt;TKey,TGroup&gt;)](PropertyComparator_TKey,TGroup_.PerformComparison(EnumItem_TKey,TGroup_,EnumItem_TKey,TGroup_).md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>)'),<br/>with a fallback to the [Key](EnumItem_TKey,TGroup_.Key.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.Key') property. |
| [PerformComparison(EnumItem&lt;TKey,TGroup&gt;, EnumItem&lt;TKey,TGroup&gt;)](PropertyComparator_TKey,TGroup_.PerformComparison(EnumItem_TKey,TGroup_,EnumItem_TKey,TGroup_).md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>)') | Performs the primary comparison for the specific property this comparator is designed to sort by. |
