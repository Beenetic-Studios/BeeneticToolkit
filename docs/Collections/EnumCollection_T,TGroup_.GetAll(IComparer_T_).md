#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums').[EnumCollection&lt;T,TGroup&gt;](EnumCollection_T,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>')

## EnumCollection<T,TGroup>.GetAll(IComparer<T>) Method

Retrieves all items in the collection as a read-only list, optionally sorted using a specified comparer.

```csharp
public System.Collections.Generic.IReadOnlyList<T> GetAll(System.Collections.Generic.IComparer<T>? comparer=null);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.GetAll(System.Collections.Generic.IComparer_T_).comparer'></a>

`comparer` [System.Collections.Generic.IComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1')[T](EnumCollection_T,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.T 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1')

An optional comparer to determine the sort order of the items.

#### Returns
[System.Collections.Generic.IReadOnlyList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyList-1 'System.Collections.Generic.IReadOnlyList`1')[T](EnumCollection_T,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.T 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyList-1 'System.Collections.Generic.IReadOnlyList`1')  
A read-only list of all items in the collection.

### Example
The following example demonstrates how to retrieve all items from the collection  
and sort them using a custom comparer:  
  
```csharp  
var collection = new MyEnumCollection();  
// Add items to the collection...  
  
var sortedItems = collection.GetAll(new MyCustomComparer());  
foreach (var item in sortedItems) {  
    Console.WriteLine(item.Name);  
}  
```