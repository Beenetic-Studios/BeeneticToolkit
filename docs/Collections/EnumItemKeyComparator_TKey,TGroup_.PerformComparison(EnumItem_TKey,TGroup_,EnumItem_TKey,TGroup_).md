#### [BeeneticToolkit.Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators').[EnumItemKeyComparator&lt;TKey,TGroup&gt;](EnumItemKeyComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TKey,TGroup>')

## EnumItemKeyComparator<TKey,TGroup>.PerformComparison(EnumItem<TKey,TGroup>, EnumItem<TKey,TGroup>) Method

Compares two [EnumItem&lt;TKey,TGroup&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>') instances by their [Key](EnumItem_TKey,TGroup_.Key.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.Key') property.

```csharp
protected override int PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup> x, BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup> y);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator_TKey,TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_).x'></a>

`x` [BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')[TKey](EnumItemKeyComparator_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator_TKey,TGroup_.TKey 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TKey,TGroup>.TKey')[,](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')[TGroup](EnumItemKeyComparator_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator_TKey,TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TKey,TGroup>.TGroup')[&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')

The first enumeration item to compare.

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator_TKey,TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_).y'></a>

`y` [BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')[TKey](EnumItemKeyComparator_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator_TKey,TGroup_.TKey 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TKey,TGroup>.TKey')[,](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')[TGroup](EnumItemKeyComparator_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator_TKey,TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TKey,TGroup>.TGroup')[&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')

The second enumeration item to compare.

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A negative value if [x](EnumItemKeyComparator_TKey,TGroup_.PerformComparison(EnumItem_TKey,TGroup_,EnumItem_TKey,TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator_TKey,TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_).x 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TKey,TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>).x') precedes [y](EnumItemKeyComparator_TKey,TGroup_.PerformComparison(EnumItem_TKey,TGroup_,EnumItem_TKey,TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator_TKey,TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_).y 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TKey,TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>).y'), zero if they are equal,  
or a positive value if [x](EnumItemKeyComparator_TKey,TGroup_.PerformComparison(EnumItem_TKey,TGroup_,EnumItem_TKey,TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator_TKey,TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_).x 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TKey,TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>).x') follows [y](EnumItemKeyComparator_TKey,TGroup_.PerformComparison(EnumItem_TKey,TGroup_,EnumItem_TKey,TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator_TKey,TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_).y 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemKeyComparator<TKey,TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>).y').