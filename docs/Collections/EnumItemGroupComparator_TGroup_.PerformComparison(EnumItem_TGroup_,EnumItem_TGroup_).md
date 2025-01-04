#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators').[EnumItemGroupComparator&lt;TGroup&gt;](EnumItemGroupComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator<TGroup>')

## EnumItemGroupComparator<TGroup>.PerformComparison(EnumItem<TGroup>, EnumItem<TGroup>) Method

Compares two [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances by their [Group](EnumItem_TGroup_.Group.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.Group') property.

```csharp
protected override int PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup> x, BeeneticToolkit.Collections.Enums.EnumItem<TGroup> y);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).x'></a>

`x` [BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')[TGroup](EnumItemGroupComparator_TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator<TGroup>.TGroup')[&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')

The first enumeration item to compare.

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).y'></a>

`y` [BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')[TGroup](EnumItemGroupComparator_TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator<TGroup>.TGroup')[&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')

The second enumeration item to compare.

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A negative value if [x](EnumItemGroupComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).x 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).x') precedes [y](EnumItemGroupComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).y 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).y') by group, zero if they are equal,  
or a positive value if [x](EnumItemGroupComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).x 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).x') follows [y](EnumItemGroupComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).y 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).y').  
Items with a `null` group are considered less than items with a defined group.

### Remarks
This comparison uses [System.Collections.Generic.Comparer&lt;&gt;.Default](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Comparer-1.Default 'System.Collections.Generic.Comparer`1.Default') for the [TGroup](EnumItemGroupComparator_TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemGroupComparator<TGroup>.TGroup') type,  
and treats `null` as less than any defined group.