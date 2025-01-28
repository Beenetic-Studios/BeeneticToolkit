#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.ObjectPooling](index.md#BeeneticToolkit.Collections.ObjectPooling 'BeeneticToolkit.Collections.ObjectPooling').[StackObjectPool&lt;T&gt;](StackObjectPool_T_.md 'BeeneticToolkit.Collections.ObjectPooling.StackObjectPool<T>')

## StackObjectPool(PooledObjectPolicy<T>, bool, int, int) Constructor

Initializes a new instance of the [StackObjectPool&lt;T&gt;](StackObjectPool_T_.md 'BeeneticToolkit.Collections.ObjectPooling.StackObjectPool<T>') class.

```csharp
public StackObjectPool(BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy<T> policy, bool isDynamic=true, int maxSize=0, int initialCapacity=0);
```
#### Parameters

<a name='BeeneticToolkit.Collections.ObjectPooling.StackObjectPool_T_.StackObjectPool(BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy_T_,bool,int,int).policy'></a>

`policy` [BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy&lt;](PooledObjectPolicy_T_.md 'BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy<T>')[T](StackObjectPool_T_.md#BeeneticToolkit.Collections.ObjectPooling.StackObjectPool_T_.T 'BeeneticToolkit.Collections.ObjectPooling.StackObjectPool<T>.T')[&gt;](PooledObjectPolicy_T_.md 'BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy<T>')

The policy used for creating, resetting, and validating pooled objects.

<a name='BeeneticToolkit.Collections.ObjectPooling.StackObjectPool_T_.StackObjectPool(BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy_T_,bool,int,int).isDynamic'></a>

`isDynamic` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates whether the pool can dynamically grow when empty.

<a name='BeeneticToolkit.Collections.ObjectPooling.StackObjectPool_T_.StackObjectPool(BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy_T_,bool,int,int).maxSize'></a>

`maxSize` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The maximum number of objects allowed in the pool. Set to 0 for no limit.

<a name='BeeneticToolkit.Collections.ObjectPooling.StackObjectPool_T_.StackObjectPool(BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy_T_,bool,int,int).initialCapacity'></a>

`initialCapacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The initial number of objects to preload into the pool.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when [policy](StackObjectPool_T_.StackObjectPool(PooledObjectPolicy_T_,bool,int,int).md#BeeneticToolkit.Collections.ObjectPooling.StackObjectPool_T_.StackObjectPool(BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy_T_,bool,int,int).policy 'BeeneticToolkit.Collections.ObjectPooling.StackObjectPool<T>.StackObjectPool(BeeneticToolkit.Collections.ObjectPooling.PooledObjectPolicy<T>, bool, int, int).policy') is null.