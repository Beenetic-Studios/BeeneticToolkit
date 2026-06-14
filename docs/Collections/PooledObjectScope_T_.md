#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.ObjectPooling](index.md#BeeneticToolkit.Collections.ObjectPooling 'BeeneticToolkit.Collections.ObjectPooling')

## PooledObjectScope<T> Struct

A disposable scope, returned by [Rent(T)](ObjectPool_T_.Rent(T).md 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>.Rent(T)'), that returns a rented  
object to its pool when disposed. Being a [struct](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/struct 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/struct'), it does not allocate.

```csharp
public readonly struct PooledObjectScope<T> :
System.IDisposable
    where T : class
```
#### Type parameters

<a name='BeeneticToolkit.Collections.ObjectPooling.PooledObjectScope_T_.T'></a>

`T`

The type of object managed by the pool.

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Properties | |
| :--- | :--- |
| [Value](PooledObjectScope_T_.Value.md 'BeeneticToolkit.Collections.ObjectPooling.PooledObjectScope<T>.Value') | Gets the rented object. |

| Methods | |
| :--- | :--- |
| [Dispose()](PooledObjectScope_T_.Dispose().md 'BeeneticToolkit.Collections.ObjectPooling.PooledObjectScope<T>.Dispose()') | Returns the rented object to its pool. |
