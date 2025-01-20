#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums').[EnumCollection&lt;T,TKey,TGroup&gt;](EnumCollection_T,TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>')

## EnumCollection<T,TKey,TGroup>.AddRange(IEnumerable<T>) Method

Adds multiple enumeration items to the collection.

```csharp
public virtual void AddRange(System.Collections.Generic.IEnumerable<T> items);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.AddRange(System.Collections.Generic.IEnumerable_T_).items'></a>

`items` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](EnumCollection_T,TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.T 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The collection of enumeration items to add.

### Remarks
This method calls [Add(T)](EnumCollection_T,TKey,TGroup_.Add(T).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.Add(T)') for each item in the provided collection.