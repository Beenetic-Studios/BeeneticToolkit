#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.ObjectPooling](index.md#BeeneticToolkit.Collections.ObjectPooling 'BeeneticToolkit.Collections.ObjectPooling')

## ObjectPool<T> Class

Abstract base class for object pools, providing core operations for retrieving, returning, and clearing pooled objects.

```csharp
public abstract class ObjectPool<T>
    where T : class
```
#### Type parameters

<a name='BeeneticToolkit.Collections.ObjectPooling.ObjectPool_T_.T'></a>

`T`

The type of object managed by the pool.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ObjectPool<T>

Derived  
&#8627; [StackObjectPool&lt;T&gt;](StackObjectPool_T_.md 'BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool<T>')

| Constructors | |
| :--- | :--- |
| [ObjectPool(PooledObjectPolicy&lt;T&gt;, bool, int)](ObjectPool_T_.ObjectPool(PooledObjectPolicy_T_,bool,int).md 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>.ObjectPool(BeeneticToolkit.Collections.ObjectPooling.Policies.PooledObjectPolicy<T>, bool, int)') | Initializes a new instance of the [ObjectPool&lt;T&gt;](ObjectPool_T_.md 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>') class. |

| Fields | |
| :--- | :--- |
| [_isDynamic](ObjectPool_T_._isDynamic.md 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>._isDynamic') | Indicates whether the pool can dynamically grow when it runs out of objects. |
| [_maxSize](ObjectPool_T_._maxSize.md 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>._maxSize') | Specifies the maximum number of objects allowed in the pool. A value of 0 indicates no limit. |
| [_policy](ObjectPool_T_._policy.md 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>._policy') | Defines the policy used for creating, resetting, and validating pooled objects. |

| Properties | |
| :--- | :--- |
| [Count](ObjectPool_T_.Count.md 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>.Count') | Gets the current number of objects in the pool. |

| Methods | |
| :--- | :--- |
| [Clear()](ObjectPool_T_.Clear().md 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>.Clear()') | Clears all objects from the pool. |
| [Get()](ObjectPool_T_.Get().md 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>.Get()') | Retrieves an object from the pool. |
| [Return(T)](ObjectPool_T_.Return(T).md 'BeeneticToolkit.Collections.ObjectPooling.ObjectPool<T>.Return(T)') | Returns an object to the pool. |
