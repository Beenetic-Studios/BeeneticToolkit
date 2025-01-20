#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums').[EnumCollection&lt;T,TKey,TGroup&gt;](EnumCollection_T,TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>')

## EnumCollection<T,TKey,TGroup>.GetByGroup(Nullable<TGroup>, Nullable<bool>) Method

Retrieves items in the collection that belong to the specified group, optionally filtered by active state.

```csharp
public System.Collections.Generic.IEnumerable<T> GetByGroup(System.Nullable<TGroup> group=null, System.Nullable<bool> isActive=null);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.GetByGroup(System.Nullable_TGroup_,System.Nullable_bool_).group'></a>

`group` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[TGroup](EnumCollection_T,TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.TGroup')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The group to filter items by. If [group](EnumCollection_T,TKey,TGroup_.GetByGroup(Nullable_TGroup_,Nullable_bool_).md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.GetByGroup(System.Nullable_TGroup_,System.Nullable_bool_).group 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.GetByGroup(System.Nullable<TGroup>, System.Nullable<bool>).group') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null'), all items are included regardless of their group.

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.GetByGroup(System.Nullable_TGroup_,System.Nullable_bool_).isActive'></a>

`isActive` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

An optional filter to include only active or inactive items. If [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null'), both active and inactive items are included.

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](EnumCollection_T,TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.T 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
An [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1') containing the items in the specified group, optionally filtered by active state.

### Example
  
```csharp  
var collection = new MyEnumCollection();  
// Add items to the collection...  
  
// Retrieve all items in Group1  
var groupItems = collection.GetByGroup(MyEnumGroup.Group1);  
foreach (var item in groupItems) {  
    Console.WriteLine(item.Name);  
}  
  
// Retrieve only active items in Group1  
var activeGroupItems = collection.GetByGroup(MyEnumGroup.Group1, isActive: true);  
foreach (var item in activeGroupItems) {  
    Console.WriteLine(item.Name);  
}  
```

### Remarks
Group filtering and active state filtering are combined to provide flexible queries for retrieving desired subsets of items.