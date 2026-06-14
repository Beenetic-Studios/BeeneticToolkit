#### [BeeneticToolkit.Collections](index.md 'index')
### [BeeneticToolkit.Collections.ObjectPooling.Policies](index.md#BeeneticToolkit.Collections.ObjectPooling.Policies 'BeeneticToolkit.Collections.ObjectPooling.Policies').[StackObjectPool&lt;T&gt;](StackObjectPool_T_.md 'BeeneticToolkit.Collections.ObjectPooling.Policies.StackObjectPool<T>')

## StackObjectPool<T>.Clear() Method

Clears all objects from the pool.

```csharp
public override void Clear();
```

### Remarks
Objects implementing [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') are disposed during the clearing process.