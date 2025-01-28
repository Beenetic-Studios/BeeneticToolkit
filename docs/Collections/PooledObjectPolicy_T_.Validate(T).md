#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.ObjectPooling](index.md#BeeneticToolkit.Collections.ObjectPooling 'BeeneticToolkit.Collections.ObjectPooling').[PooledObjectPolicy&lt;T&gt;](PooledObjectPolicy_T_.md 'BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy<T>')

## PooledObjectPolicy<T>.Validate(T) Method

Validates whether the object is still suitable for reuse.

```csharp
public virtual bool Validate(T obj);
```
#### Parameters

<a name='BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy_T_.Validate(T).obj'></a>

`obj` [T](PooledObjectPolicy_T_.md#BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy_T_.T 'BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy<T>.T')

The object to validate.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the object is valid for reuse; otherwise, `false`.