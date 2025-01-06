#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Utility](index.md#BeeneticToolkit.Collections.Utility 'BeeneticToolkit.Collections.Utility').[CollectionUtils](CollectionUtils.md 'BeeneticToolkit.Collections.Utility.CollectionUtils')

## CollectionUtils.IsNullOrEmpty<T>(this IEnumerable<T>) Method

Determines whether a collection is null or contains no elements.

```csharp
public static bool IsNullOrEmpty<T>(this System.Collections.Generic.IEnumerable<T> collection);
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Utility.CollectionUtils.IsNullOrEmpty_T_(thisSystem.Collections.Generic.IEnumerable_T_).T'></a>

`T`

The type of elements in the collection.
#### Parameters

<a name='BeeneticToolkit.Collections.Utility.CollectionUtils.IsNullOrEmpty_T_(thisSystem.Collections.Generic.IEnumerable_T_).collection'></a>

`collection` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](CollectionUtils.IsNullOrEmpty_T_(thisIEnumerable_T_).md#BeeneticToolkit.Collections.Utility.CollectionUtils.IsNullOrEmpty_T_(thisSystem.Collections.Generic.IEnumerable_T_).T 'BeeneticToolkit.Collections.Utility.CollectionUtils.IsNullOrEmpty<T>(this System.Collections.Generic.IEnumerable<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The collection to check for null or emptiness.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the collection is null or empty; otherwise, `false`.