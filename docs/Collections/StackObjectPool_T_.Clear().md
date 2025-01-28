#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.ObjectPooling](index.md#BeeneticToolkit.Collections.ObjectPooling 'BeeneticToolkit.Collections.ObjectPooling').[StackObjectPool&lt;T&gt;](StackObjectPool_T_.md 'BeeneticToolkit.Collections.ObjectPooling.StackObjectPool<T>')

## StackObjectPool<T>.Clear() Method

Clears all objects from the pool.

```csharp
public override void Clear();
```

### Remarks
Objects implementing [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') are disposed during the clearing process.