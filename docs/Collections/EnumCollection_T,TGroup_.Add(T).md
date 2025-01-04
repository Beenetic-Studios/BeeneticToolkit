#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums').[EnumCollection&lt;T,TGroup&gt;](EnumCollection_T,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>')

## EnumCollection<T,TGroup>.Add(T) Method

Adds an enumeration item to the collection if it does not already exist.

```csharp
public void Add(T item);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.Add(T).item'></a>

`item` [T](EnumCollection_T,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.T 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.T')

The enumeration item to add.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown when an item with the same key as the specified item already exists in the collection.