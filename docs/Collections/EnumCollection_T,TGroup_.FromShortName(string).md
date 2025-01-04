#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums').[EnumCollection&lt;T,TGroup&gt;](EnumCollection_T,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>')

## EnumCollection<T,TGroup>.FromShortName(string) Method

Retrieves an item from the collection by its short name.

```csharp
public T FromShortName(string shortName);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.FromShortName(string).shortName'></a>

`shortName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The short name of the item to retrieve.

#### Returns
[T](EnumCollection_T,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.T 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.T')  
The item corresponding to the specified short name.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown when no item with the specified short name exists in the collection.