#### [BeeneticToolkit.Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums').[EnumCollection&lt;T,TKey,TGroup&gt;](EnumCollection_T,TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>')

## EnumCollection<T,TKey,TGroup>.TryFromKey(TKey, T) Method

Attempts to retrieve an item by its unique key, without throwing.

```csharp
public bool TryFromKey(TKey key, out T item);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.TryFromKey(TKey,T).key'></a>

`key` [TKey](EnumCollection_T,TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.TKey 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.TKey')

The unique key of the item to retrieve.

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.TryFromKey(TKey,T).item'></a>

`item` [T](EnumCollection_T,TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.T 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.T')

When this method returns `true`, the matching item; otherwise `null`.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if an item with the specified key exists; otherwise `false`.