#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators').[EnumItemKeyComparator&lt;TGroup&gt;](EnumItemKeyComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TGroup>')

## EnumItemKeyComparator<TGroup>.PerformComparison(EnumItem<TGroup>, EnumItem<TGroup>) Method

Compares two [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances by their [Key](EnumItem_TGroup_.Key.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.Key') property.

```csharp
protected override int PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup> x, BeeneticToolkit.Collections.Enums.EnumItem<TGroup> y);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).x'></a>

`x` [BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')[TGroup](EnumItemKeyComparator_TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TGroup>.TGroup')[&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')

The first enumeration item to compare.

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).y'></a>

`y` [BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')[TGroup](EnumItemKeyComparator_TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TGroup>.TGroup')[&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')

The second enumeration item to compare.

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A negative value if [x](EnumItemKeyComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).x 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).x') precedes [y](EnumItemKeyComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).y 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).y'), zero if they are equal, or a positive value if [x](EnumItemKeyComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).x 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).x') follows [y](EnumItemKeyComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).y 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).y').