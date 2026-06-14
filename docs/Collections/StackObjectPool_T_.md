#### [BeeneticToolkit.Collections](index.md 'index')
### [BeeneticToolkit.Collections.ObjectPooling.Policies](index.md#BeeneticToolkit.Collections.ObjectPooling.Policies 'BeeneticToolkit.Collections.ObjectPooling.Policies')

## StackObjectPool<T> Class

Stack-based implementation of [ObjectPool&lt;T&gt;](ObjectPool_T_.md 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>'), using a last-in-first-out (LIFO) approach for object storage.

```csharp
public class StackObjectPool<T> : BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>
    where T : class
```
#### Type parameters

<a name='BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool_T_.T'></a>

`T`

The type of object managed by the pool.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [BeeneticToolkit.Collections.ObjectPooling.ObjectPool&lt;](ObjectPool_T_.md 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>')[T](StackObjectPool_T_.md#BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool_T_.T 'BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool<T>.T')[&gt;](ObjectPool_T_.md 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>') &#129106; StackObjectPool<T>

| Constructors | |
| :--- | :--- |
| [StackObjectPool(PooledObjectPolicy&lt;T&gt;, bool, int, int)](StackObjectPool_T_.StackObjectPool(PooledObjectPolicy_T_,bool,int,int).md 'BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool<T>.StackObjectPool(BeeneticToolkit.Collections.ObjectPooling.Policies.PooledObjectPolicy<T>, bool, int, int)') | Initializes a new instance of the [StackObjectPool&lt;T&gt;](StackObjectPool_T_.md 'BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool<T>') class. |

| Properties | |
| :--- | :--- |
| [Count](StackObjectPool_T_.Count.md 'BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool<T>.Count') | Gets the current number of objects in the pool. |

| Methods | |
| :--- | :--- |
| [Clear()](StackObjectPool_T_.Clear().md 'BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool<T>.Clear()') | Clears all objects from the pool. |
| [Get()](StackObjectPool_T_.Get().md 'BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool<T>.Get()') | Retrieves an object from the pool. |
| [Return(T)](StackObjectPool_T_.Return(T).md 'BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool<T>.Return(T)') | Returns an object to the pool. |
