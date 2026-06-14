#### [BeeneticToolkit.Collections](index.md 'index')
### [BeeneticToolkit.Collections.ObjectPooling.Policies](index.md#BeeneticToolkit.Collections.ObjectPooling.Policies 'BeeneticToolkit.Collections.ObjectPooling.Policies').[StackObjectPool&lt;T&gt;](StackObjectPool_T_.md 'BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool<T>')

## StackObjectPool<T>.Get() Method

Retrieves an object from the pool.

```csharp
public override T Get();
```

#### Returns
[T](StackObjectPool_T_.md#BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool_T_.T 'BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool<T>.T')  
An instance of [T](StackObjectPool_T_.md#BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool_T_.T 'BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool<T>.T') from the pool.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown if the pool is empty and cannot grow dynamically.