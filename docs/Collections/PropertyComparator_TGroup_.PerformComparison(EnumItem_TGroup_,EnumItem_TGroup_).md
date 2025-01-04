#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators').[PropertyComparator&lt;TGroup&gt;](PropertyComparator_TGroup_.md 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>')

## PropertyComparator<TGroup>.PerformComparison(EnumItem<TGroup>, EnumItem<TGroup>) Method

Performs the primary comparison for the specific property this comparator is designed to sort by.

```csharp
protected abstract int PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup> x, BeeneticToolkit.Collections.Enums.EnumItem<TGroup> y);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).x'></a>

`x` [BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')[TGroup](PropertyComparator_TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>.TGroup')[&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')

The first enumeration item to compare.

<a name='BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).y'></a>

`y` [BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')[TGroup](PropertyComparator_TGroup_.md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>.TGroup')[&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')

The second enumeration item to compare.

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A negative value if [x](PropertyComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).x 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).x') precedes [y](PropertyComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).y 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).y') based on the primary property,  
zero if they are equal, or a positive value if [x](PropertyComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).x 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).x') follows [y](PropertyComparator_TGroup_.PerformComparison(EnumItem_TGroup_,EnumItem_TGroup_).md#BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator_TGroup_.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem_TGroup_,BeeneticToolkit.Collections.Enums.EnumItem_TGroup_).y 'BeeneticToolkit.Collections.Enums.Comparators.PropertyComparator<TGroup>.PerformComparison(BeeneticToolkit.Collections.Enums.EnumItem<TGroup>, BeeneticToolkit.Collections.Enums.EnumItem<TGroup>).y').

#### Exceptions

[System.NotImplementedException](https://docs.microsoft.com/en-us/dotnet/api/System.NotImplementedException 'System.NotImplementedException')  
Thrown if this method is called without being overridden in a subclass.

### Remarks
Subclasses must override this method to define the primary comparison logic for the desired property.