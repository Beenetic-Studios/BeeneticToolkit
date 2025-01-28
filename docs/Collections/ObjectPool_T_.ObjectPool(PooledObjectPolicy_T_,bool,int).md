#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.ObjectPooling](index.md#BeeneticToolkit.Collections.ObjectPooling 'BeeneticToolkit.Collections.ObjectPooling').[ObjectPool&lt;T&gt;](ObjectPool_T_.md 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>')

## ObjectPool(PooledObjectPolicy<T>, bool, int) Constructor

Initializes a new instance of the [ObjectPool&lt;T&gt;](ObjectPool_T_.md 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>') class.

```csharp
protected ObjectPool(BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy<T> policy, bool isDynamic=true, int maxSize=0);
```
#### Parameters

<a name='BeeneticToolkit.Collections.ObjectPooling.ObjectPool_T_.ObjectPool(BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy_T_,bool,int).policy'></a>

`policy` [BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy&lt;](PooledObjectPolicy_T_.md 'BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy<T>')[T](ObjectPool_T_.md#BeeneticToolkit.Collections.ObjectPooling.ObjectPool_T_.T 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>.T')[&gt;](PooledObjectPolicy_T_.md 'BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy<T>')

The policy used for creating, resetting, and validating pooled objects.

<a name='BeeneticToolkit.Collections.ObjectPooling.ObjectPool_T_.ObjectPool(BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy_T_,bool,int).isDynamic'></a>

`isDynamic` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates whether the pool can dynamically grow when empty.

<a name='BeeneticToolkit.Collections.ObjectPooling.ObjectPool_T_.ObjectPool(BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy_T_,bool,int).maxSize'></a>

`maxSize` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The maximum number of objects allowed in the pool. Set to 0 for no limit.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when [policy](ObjectPool_T_.ObjectPool(PooledObjectPolicy_T_,bool,int).md#BeeneticToolkit.Collections.ObjectPooling.ObjectPool_T_.ObjectPool(BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy_T_,bool,int).policy 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>.ObjectPool(BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy<T>, bool, int).policy') is null.