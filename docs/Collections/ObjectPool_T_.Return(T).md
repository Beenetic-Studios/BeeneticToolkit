#### [BeeneticToolkit.Collections](index.md 'index')
### [BeeneticToolkit.Collections.ObjectPooling](index.md#BeeneticToolkit.Collections.ObjectPooling 'BeeneticToolkit.Collections.ObjectPooling').[ObjectPool&lt;T&gt;](ObjectPool_T_.md 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>')

## ObjectPool<T>.Return(T) Method

Returns an object to the pool.

```csharp
public abstract void Return(T obj);
```
#### Parameters

<a name='BeeneticToolkit.Collections.ObjectPooling.ObjectPool_T_.Return(T).obj'></a>

`obj` [T](ObjectPool_T_.md#BeeneticToolkit.Collections.ObjectPooling.ObjectPool_T_.T 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>.T')

The object to return to the pool.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown if [obj](ObjectPool_T_.Return(T).md#BeeneticToolkit.Collections.ObjectPooling.ObjectPool_T_.Return(T).obj 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>.Return(T).obj') is null.