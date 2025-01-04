#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums').[EnumCollection&lt;T,TGroup&gt;](EnumCollection_T,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>')

## EnumCollection<T,TGroup>.FromName(string) Method

Retrieves an item from the collection by its name.

```csharp
public T FromName(string name);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.FromName(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the item to retrieve.

#### Returns
[T](EnumCollection_T,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.T 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.T')  
The item corresponding to the specified name.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown when no item with the specified name exists in the collection.