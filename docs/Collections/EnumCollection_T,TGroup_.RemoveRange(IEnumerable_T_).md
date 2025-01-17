#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums').[EnumCollection&lt;T,TGroup&gt;](EnumCollection_T,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>')

## EnumCollection<T,TGroup>.RemoveRange(IEnumerable<T>) Method

Removes multiple enumeration items from the collection by their references.

```csharp
public virtual void RemoveRange(System.Collections.Generic.IEnumerable<T> items);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.RemoveRange(System.Collections.Generic.IEnumerable_T_).items'></a>

`items` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](EnumCollection_T,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.T 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The collection of enumeration items to remove.

### Remarks
This method calls [Remove(T)](EnumCollection_T,TGroup_.Remove(T).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.Remove(T)') for each item in the provided collection.