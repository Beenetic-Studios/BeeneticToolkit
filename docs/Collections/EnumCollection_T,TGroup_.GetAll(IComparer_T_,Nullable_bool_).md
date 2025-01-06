#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums').[EnumCollection&lt;T,TGroup&gt;](EnumCollection_T,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>')

## EnumCollection<T,TGroup>.GetAll(IComparer<T>, Nullable<bool>) Method

Retrieves all items in the collection as an [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), optionally filtered by active state and sorted using a specified comparer.

```csharp
public System.Collections.Generic.IEnumerable<T> GetAll(System.Collections.Generic.IComparer<T>? comparer=null, System.Nullable<bool> isActive=null);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.GetAll(System.Collections.Generic.IComparer_T_,System.Nullable_bool_).comparer'></a>

`comparer` [System.Collections.Generic.IComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1')[T](EnumCollection_T,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.T 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1')

An optional comparer to determine the sort order of the items. If no comparer is provided, the items are returned in their natural order as stored in the collection. Predefined comparators are available in [EnumItemComparators](EnumItemComparators.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators').

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.GetAll(System.Collections.Generic.IComparer_T_,System.Nullable_bool_).isActive'></a>

`isActive` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

An optional filter to include only active or inactive items. If [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null'), both active and inactive items are included.

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](EnumCollection_T,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.T 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
An [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1') containing the items in the collection.  
If a comparer is specified, the items are returned in the specified order; otherwise, they are returned in their natural order. Items are filtered by their active state if [isActive](EnumCollection_T,TGroup_.GetAll(IComparer_T_,Nullable_bool_).md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.GetAll(System.Collections.Generic.IComparer_T_,System.Nullable_bool_).isActive 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.GetAll(System.Collections.Generic.IComparer<T>, System.Nullable<bool>).isActive') is provided.

### Example
The following example demonstrates how to retrieve all items from the collection, optionally filtering by active state and sorting them using a custom or predefined comparer:  
  
```csharp  
var collection = new MyEnumCollection();  
// Add items to the collection...  
  
// Retrieve all active items in their natural order  
var activeItems = collection.GetAll(isActive: true);  
foreach (var item in activeItems) {  
    Console.WriteLine(item.Name);  
}  
  
// Retrieve all items sorted using a predefined comparator by name  
var sortedByName = collection.GetAll(EnumItemComparators.ByName<MyGroup>());  
foreach (var item in sortedByName) {  
    Console.WriteLine(item.Name);  
}  
```

### Remarks
This method leverages caching for optimized repeated retrievals. When no filters or comparers are provided, a cached list of items is returned to minimize overhead.  
  
Predefined comparators in [EnumItemComparators](EnumItemComparators.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators') include:  
- [ByKey&lt;TGroup&gt;(bool)](EnumItemComparators.ByKey_TGroup_(bool).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators.ByKey<TGroup>(bool)') - Sorts by the key property.  
- [ByName&lt;TGroup&gt;(bool)](EnumItemComparators.ByName_TGroup_(bool).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators.ByName<TGroup>(bool)') - Sorts by the name property.  
- [ByShortName&lt;TGroup&gt;(bool)](EnumItemComparators.ByShortName_TGroup_(bool).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators.ByShortName<TGroup>(bool)') - Sorts by the short name property.  
- [ByDisplayOrder&lt;TGroup&gt;(bool)](EnumItemComparators.ByDisplayOrder_TGroup_(bool).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators.ByDisplayOrder<TGroup>(bool)') - Sorts by the display order property.  
- [ByActiveState&lt;TGroup&gt;(bool)](EnumItemComparators.ByActiveState_TGroup_(bool).md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators.ByActiveState<TGroup>(bool)') - Sorts by the active state property.