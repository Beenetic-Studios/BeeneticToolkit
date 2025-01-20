#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums').[EnumCollection&lt;T,TKey,TGroup&gt;](EnumCollection_T,TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>')

## EnumCollection<T,TKey,TGroup>.FromName(string) Method

Retrieves an item from the collection by its name.

```csharp
public T FromName(string name);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.FromName(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the item to retrieve.

#### Returns
[T](EnumCollection_T,TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.T 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.T')  
The item corresponding to the specified name.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown when no item with the specified name exists in the collection.