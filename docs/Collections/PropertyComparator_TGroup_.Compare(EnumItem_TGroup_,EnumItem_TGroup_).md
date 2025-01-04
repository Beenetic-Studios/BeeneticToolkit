#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators').[PropertyComparator&lt;TGroup&gt;](PropertyComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>')

## PropertyComparator<TGroup>.Compare(EnumItem<TGroup>, EnumItem<TGroup>) Method

Compares two [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances, first by the property defined in  
[PerformComparison(EnumItem&lt;TGroup&gt;, EnumItem&lt;TGroup&gt;)](PropertyComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>)'), and then by  
the [Key](EnumItem_TGroup_.Key.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.Key') property as a secondary criterion.

```csharp
public int Compare(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>? x, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>? y);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TGroup_.Compare(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).x'></a>

`x` [BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')[TGroup](PropertyComparator_TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>.TGroup')[&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')

The first enumeration item to compare.

<a name='BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TGroup_.Compare(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).y'></a>

`y` [BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')[TGroup](PropertyComparator_TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>.TGroup')[&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')

The second enumeration item to compare.

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A negative value if [x](PropertyComparator_TGroup_.Compare(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TGroup_.Compare(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).x 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>.Compare(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).x') precedes [y](PropertyComparator_TGroup_.Compare(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TGroup_.Compare(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).y 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>.Compare(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).y') in the sort order,  
zero if they are equal, or a positive value if [x](PropertyComparator_TGroup_.Compare(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TGroup_.Compare(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).x 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>.Compare(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).x') follows [y](PropertyComparator_TGroup_.Compare(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TGroup_.Compare(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).y 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>.Compare(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).y').

### Remarks
If both [x](PropertyComparator_TGroup_.Compare(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TGroup_.Compare(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).x 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>.Compare(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).x') and [y](PropertyComparator_TGroup_.Compare(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TGroup_.Compare(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).y 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>.Compare(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).y') are `null`, they are considered equal.  
If only one is `null`, the non-null item is considered to precede the `null` item.