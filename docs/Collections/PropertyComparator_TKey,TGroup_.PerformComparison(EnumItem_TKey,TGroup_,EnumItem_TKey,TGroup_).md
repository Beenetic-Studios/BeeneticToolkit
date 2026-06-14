#### [BeeneticToolkit.Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators').[PropertyComparator&lt;TKey,TGroup&gt;](PropertyComparator_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>')

## PropertyComparator<TKey,TGroup>.PerformComparison(EnumItem<TKey,TGroup>, EnumItem<TKey,TGroup>) Method

Performs the primary comparison for the specific property this comparator is designed to sort by.

```csharp
protected abstract int PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup> x, BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup> y);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TKey,TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_).x'></a>

`x` [BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')[TKey](PropertyComparator_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TKey,TGroup_.TKey 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>.TKey')[,](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')[TGroup](PropertyComparator_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TKey,TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>.TGroup')[&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')

The first enumeration item to compare.

<a name='BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TKey,TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_).y'></a>

`y` [BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')[TKey](PropertyComparator_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TKey,TGroup_.TKey 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>.TKey')[,](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')[TGroup](PropertyComparator_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TKey,TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>.TGroup')[&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')

The second enumeration item to compare.

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A negative value if [x](PropertyComparator_TKey,TGroup_.PerformComparison(EnumItem_TKey,TGroup_,EnumItem_TKey,TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TKey,TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_).x 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>).x') precedes [y](PropertyComparator_TKey,TGroup_.PerformComparison(EnumItem_TKey,TGroup_,EnumItem_TKey,TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TKey,TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_).y 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>).y'), zero if they are equal, or a positive value if [x](PropertyComparator_TKey,TGroup_.PerformComparison(EnumItem_TKey,TGroup_,EnumItem_TKey,TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TKey,TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_).x 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>).x') follows [y](PropertyComparator_TKey,TGroup_.PerformComparison(EnumItem_TKey,TGroup_,EnumItem_TKey,TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TKey,TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_).y 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TKey,TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>).y').

#### Exceptions

[System.NotImplementedException](https://docs.microsoft.com/en-us/dotnet/api/System.NotImplementedException 'System.NotImplementedException')  
Thrown if this method is called without being overridden in a subclass.

### Remarks
Subclasses must override this method to define the primary comparison logic for the desired property.