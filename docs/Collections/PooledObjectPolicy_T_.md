#### [BeeneticToolkit.Collections](index.md 'index')
### [BeeneticToolkit.Collections.ObjectPooling.Policies](index.md#BeeneticToolkit.Collections.ObjectPooling.Policies 'BeeneticToolkit.Collections.ObjectPooling.Policies')

## PooledObjectPolicy<T> Class

Defines the policy for managing pooled objects, including creation, resetting, and validation.

```csharp
public abstract class PooledObjectPolicy<T>
```
#### Type parameters

<a name='BeeneticToolkit.Collections.ObjectPooling.Policies.PooledObjectPolicy_T_.T'></a>

`T`

The type of object managed by the policy.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; PooledObjectPolicy<T>

| Methods | |
| :--- | :--- |
| [Create()](PooledObjectPolicy_T_.Create().md 'BeeneticToolkit.Collections.ObjectPooling.Policies.PooledObjectPolicy<T>.Create()') | Creates a new instance of the object. |
| [Reset(T)](PooledObjectPolicy_T_.Reset(T).md 'BeeneticToolkit.Collections.ObjectPooling.Policies.PooledObjectPolicy<T>.Reset(T)') | Resets the object before it is returned to the pool. |
| [Validate(T)](PooledObjectPolicy_T_.Validate(T).md 'BeeneticToolkit.Collections.ObjectPooling.Policies.PooledObjectPolicy<T>.Validate(T)') | Validates whether the object is still suitable for reuse. |
