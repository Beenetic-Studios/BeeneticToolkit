#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums').[EnumCollection&lt;T,TGroup&gt;](EnumCollection_T,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>')

## EnumCollection<T,TGroup>.GetByGroup(Nullable<TGroup>) Method

Retrieves all items in the collection that belong to the specified group.

```csharp
public System.Collections.Generic.IEnumerable<T> GetByGroup(System.Nullable<TGroup> group=null);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.GetByGroup(System.Nullable_TGroup_).group'></a>

`group` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[TGroup](EnumCollection_T,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.TGroup')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The group to filter items by. If [group](EnumCollection_T,TGroup_.GetByGroup(Nullable_TGroup_).md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.GetByGroup(System.Nullable_TGroup_).group 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.GetByGroup(System.Nullable<TGroup>).group') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null'), all items in the collection are returned.

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](EnumCollection_T,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.T 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
An [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1') containing the items that belong to the specified group.  
If [group](EnumCollection_T,TGroup_.GetByGroup(Nullable_TGroup_).md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.GetByGroup(System.Nullable_TGroup_).group 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.GetByGroup(System.Nullable<TGroup>).group') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null'), all items are returned.

### Example
The following example demonstrates how to retrieve items from the collection  
that belong to a specific group:  
  
```csharp  
var collection = new MyEnumCollection();  
// Add items to the collection...  
  
var groupItems = collection.GetByGroup(MyEnumGroup.Category1);  
foreach (var item in groupItems) {  
    Console.WriteLine(item.Name);  
}  
```