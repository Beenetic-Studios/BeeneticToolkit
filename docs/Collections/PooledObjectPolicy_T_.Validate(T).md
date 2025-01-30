#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.ObjectPooling.Policies](index.md#BeeneticToolkit.Collections.ObjectPooling.Policies 'BeeneticToolkit.Collections.ObjectPooling.Policies').[PooledObjectPolicy&lt;T&gt;](PooledObjectPolicy_T_.md 'BeeneticToolkit.Collections.ObjectPooling.Policies.PooledObjectPolicy<T>')

## PooledObjectPolicy<T>.Validate(T) Method

Validates whether the object is still suitable for reuse.

```csharp
public virtual bool Validate(T obj);
```
#### Parameters

<a name='BeeneticToolkit.Collections.ObjectPooling.Policies.PooledObjectPolicy_T_.Validate(T).obj'></a>

`obj` [T](PooledObjectPolicy_T_.md#BeeneticToolkit.Collections.ObjectPooling.Policies.PooledObjectPolicy_T_.T 'BeeneticToolkit.Collections.ObjectPooling.Policies.PooledObjectPolicy<T>.T')

The object to validate.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the object is valid for reuse; otherwise, `false`.