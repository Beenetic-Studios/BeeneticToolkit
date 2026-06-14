#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums').[EnumCollection&lt;T,TKey,TGroup&gt;](EnumCollection_T,TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>')

## EnumCollection<T,TKey,TGroup>.TryFromShortName(string, T) Method

Attempts to retrieve an item by its short name, without throwing.

```csharp
public bool TryFromShortName(string shortName, out T item);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.TryFromShortName(string,T).shortName'></a>

`shortName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The short name of the item to retrieve.

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.TryFromShortName(string,T).item'></a>

`item` [T](EnumCollection_T,TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.T 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.T')

When this method returns `true`, the first item with the given short name; otherwise `null`.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if an item with the specified short name exists; otherwise `false`.