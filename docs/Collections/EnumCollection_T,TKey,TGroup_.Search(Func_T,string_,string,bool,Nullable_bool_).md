#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums').[EnumCollection&lt;T,TKey,TGroup&gt;](EnumCollection_T,TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>')

## EnumCollection<T,TKey,TGroup>.Search(Func<T,string>, string, bool, Nullable<bool>) Method

Searches the collection for items whose selected property matches the specified search term, optionally filtered by active state.

```csharp
public System.Collections.Generic.IEnumerable<T> Search(System.Func<T,string> selector, string searchTerm, bool caseSensitive=false, System.Nullable<bool> isActive=null);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.Search(System.Func_T,string_,string,bool,System.Nullable_bool_).selector'></a>

`selector` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EnumCollection_T,TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.T 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

A function that selects the property of each item to search.

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.Search(System.Func_T,string_,string,bool,System.Nullable_bool_).searchTerm'></a>

`searchTerm` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The term to search for within the selected property.

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.Search(System.Func_T,string_,string,bool,System.Nullable_bool_).caseSensitive'></a>

`caseSensitive` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates whether the search should be case-sensitive. Defaults to `false`.

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.Search(System.Func_T,string_,string,bool,System.Nullable_bool_).isActive'></a>

`isActive` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

An optional filter to include only active or inactive items. If [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null'), both active and inactive items are included.

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](EnumCollection_T,TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.T 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
An [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1') containing the items that match the search term, optionally filtered by active state.

### Example
  
```csharp  
var collection = new MyEnumCollection();  
// Add items to the collection...  
  
// Search for items with "term" in their name, ignoring case  
var searchResults = collection.Search(item => item.Name, "term");  
foreach (var item in searchResults) {  
    Console.WriteLine(item.Name);  
}  
  
// Search for active items with "term" in their name, ignoring case  
var activeSearchResults = collection.Search(item => item.Name, "term", isActive: true);  
foreach (var item in activeSearchResults) {  
    Console.WriteLine(item.Name);  
}  
```

### Remarks
Combines search term matching and active state filtering to provide precise results. Case sensitivity is controlled by the [caseSensitive](EnumCollection_T,TKey,TGroup_.Search(Func_T,string_,string,bool,Nullable_bool_).md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.Search(System.Func_T,string_,string,bool,System.Nullable_bool_).caseSensitive 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.Search(System.Func<T,string>, string, bool, System.Nullable<bool>).caseSensitive') parameter.