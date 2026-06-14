#### [BeeneticToolkit.Collections](index.md 'index')
### [BeeneticToolkit.Collections.ObjectPooling](index.md#BeeneticToolkit.Collections.ObjectPooling 'BeeneticToolkit.Collections.ObjectPooling').[ObjectPool&lt;T&gt;](ObjectPool_T_.md 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>')

## ObjectPool<T>.Rent(T) Method

Rents an object from the pool and returns a scope that returns it when disposed.

```csharp
public BeeneticToolkit.Collections.ObjectPooling.PooledObjectScope<T> Rent(out T obj);
```
#### Parameters

<a name='BeeneticToolkit.Collections.ObjectPooling.ObjectPool_T_.Rent(T).obj'></a>

`obj` [T](ObjectPool_T_.md#BeeneticToolkit.Collections.ObjectPooling.ObjectPool_T_.T 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>.T')

The rented object.

#### Returns
[BeeneticToolkit.Collections.ObjectPooling.PooledObjectScope&lt;](PooledObjectScope_T_.md 'BeeneticToolkit.Collections.ObjectPooling.PooledObjectScope<T>')[T](ObjectPool_T_.md#BeeneticToolkit.Collections.ObjectPooling.ObjectPool_T_.T 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>.T')[&gt;](PooledObjectScope_T_.md 'BeeneticToolkit.Collections.ObjectPooling.PooledObjectScope<T>')  
A disposable scope; disposing it returns [obj](ObjectPool_T_.Rent(T).md#BeeneticToolkit.Collections.ObjectPooling.ObjectPool_T_.Rent(T).obj 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>.Rent(T).obj') to the pool.

### Example
  
```csharp  
using (pool.Rent(out var buffer)) {  
    // use buffer ...  
} // buffer is automatically returned here  
```