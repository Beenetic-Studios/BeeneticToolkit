#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums').[EnumCollection&lt;T,TGroup&gt;](EnumCollection_T,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>')

## EnumCollection<T,TGroup>.FromKey(string) Method

Retrieves an item from the collection by its unique key.

```csharp
public T FromKey(string key);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.FromKey(string).key'></a>

`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The unique key of the item to retrieve.

#### Returns
[T](EnumCollection_T,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.T 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.T')  
The item corresponding to the specified key.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown when no item with the specified key exists in the collection.