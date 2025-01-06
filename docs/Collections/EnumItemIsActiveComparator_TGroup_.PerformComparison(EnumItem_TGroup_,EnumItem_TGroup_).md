#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators').[EnumItemIsActiveComparator&lt;TGroup&gt;](EnumItemIsActiveComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator<TGroup>')

## EnumItemIsActiveComparator<TGroup>.PerformComparison(EnumItem<TGroup>, EnumItem<TGroup>) Method

Compares two [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances by their [IsActive](EnumItem_TGroup_.IsActive.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.IsActive') property.

```csharp
protected override int PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup> x, BeeneticToolkit.Collections.Enums.EnumItem<TGroup> y);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).x'></a>

`x` [BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')[TGroup](EnumItemIsActiveComparator_TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator<TGroup>.TGroup')[&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')

The first enumeration item to compare.

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).y'></a>

`y` [BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')[TGroup](EnumItemIsActiveComparator_TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator<TGroup>.TGroup')[&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')

The second enumeration item to compare.

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A negative value if [x](EnumItemIsActiveComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).x 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).x') precedes [y](EnumItemIsActiveComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).y 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).y'), zero if they are equal, or a positive value if [x](EnumItemIsActiveComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).x 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).x') follows [y](EnumItemIsActiveComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).y 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemIsActiveComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).y').

### Remarks
Active items (`true`) are considered greater than inactive items (`false`), and both are considered greater than items with an undefined active state (`null`).