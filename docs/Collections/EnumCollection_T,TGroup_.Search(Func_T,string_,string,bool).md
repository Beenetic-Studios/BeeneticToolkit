#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums').[EnumCollection&lt;T,TGroup&gt;](EnumCollection_T,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>')

## EnumCollection<T,TGroup>.Search(Func<T,string>, string, bool) Method

Searches the collection for items whose selected property matches the search term.

```csharp
public System.Collections.Generic.IEnumerable<T> Search(System.Func<T,string> selector, string searchTerm, bool caseSensitive=false);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.Search(System.Func_T,string_,string,bool).selector'></a>

`selector` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EnumCollection_T,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.T 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

A function that selects the property of each item to search.

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.Search(System.Func_T,string_,string,bool).searchTerm'></a>

`searchTerm` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The term to search for within the selected property.

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.Search(System.Func_T,string_,string,bool).caseSensitive'></a>

`caseSensitive` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether the search should be case-sensitive. Defaults to `false`.

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](EnumCollection_T,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.T 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A collection of items that match the search term.

### Example
The following example demonstrates how to search the collection for items  
where the `Name` property contains a specific term, ignoring case:  
  
```csharp  
var collection = new MyEnumCollection();  
// Add items to the collection...  
  
var searchResults = collection.Search(item => item.Name, "searchTerm", caseSensitive: false);  
foreach (var item in searchResults) {  
    Console.WriteLine(item.Name);  
}  
```