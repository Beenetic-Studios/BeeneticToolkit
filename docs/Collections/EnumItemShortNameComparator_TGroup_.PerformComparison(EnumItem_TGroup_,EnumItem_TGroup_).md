#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators').[EnumItemShortNameComparator&lt;TGroup&gt;](EnumItemShortNameComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator<TGroup>')

## EnumItemShortNameComparator<TGroup>.PerformComparison(EnumItem<TGroup>, EnumItem<TGroup>) Method

Compares two [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances by their [ShortName](EnumItem_TGroup_.ShortName.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.ShortName') property.

```csharp
protected override int PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup> x, BeeneticToolkit.Collections.Enums.EnumItem<TGroup> y);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).x'></a>

`x` [BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')[TGroup](EnumItemShortNameComparator_TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator<TGroup>.TGroup')[&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')

The first enumeration item to compare.

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).y'></a>

`y` [BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')[TGroup](EnumItemShortNameComparator_TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator<TGroup>.TGroup')[&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')

The second enumeration item to compare.

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A negative value if [x](EnumItemShortNameComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).x 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).x') precedes [y](EnumItemShortNameComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).y 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).y') by short name, zero if they are equal,  
or a positive value if [x](EnumItemShortNameComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).x 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).x') follows [y](EnumItemShortNameComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).y 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemShortNameComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).y').