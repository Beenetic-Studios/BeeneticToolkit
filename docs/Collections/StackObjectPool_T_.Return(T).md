#### [BeeneticToolkit.Collections](index.md 'index')
### [BeeneticToolkit.Collections.ObjectPooling.Policies](index.md#BeeneticToolkit.Collections.ObjectPooling.Policies 'BeeneticToolkit.Collections.ObjectPooling.Policies').[StackObjectPool&lt;T&gt;](StackObjectPool_T_.md 'BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool<T>')

## StackObjectPool<T>.Return(T) Method

Returns an object to the pool.

```csharp
public override void Return(T obj);
```
#### Parameters

<a name='BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool_T_.Return(T).obj'></a>

`obj` [T](StackObjectPool_T_.md#BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool_T_.T 'BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool<T>.T')

The object to return to the pool.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown if [obj](StackObjectPool_T_.Return(T).md#BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool_T_.Return(T).obj 'BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool<T>.Return(T).obj') is null.