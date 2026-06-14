#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging.Utilities](index.md#BeeneticToolkit.Logging.Utilities 'BeeneticToolkit.Logging.Utilities').[ObjectPropertyExtensions](ObjectPropertyExtensions.md 'BeeneticToolkit.Logging.Utilities.ObjectPropertyExtensions')

## ObjectPropertyExtensions.CountNonZeroNumericProperties(this object, Func<PropertyInfo,bool>) Method

Counts the number of non-zero numeric properties in an object, optionally filtered by a custom condition.

```csharp
public static int CountNonZeroNumericProperties(this object obj, System.Func<System.Reflection.PropertyInfo,bool>? filter=null);
```
#### Parameters

<a name='BeeneticToolkit.Logging.Utilities.ObjectPropertyExtensions.CountNonZeroNumericProperties(thisobject,System.Func_System.Reflection.PropertyInfo,bool_).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object whose numeric properties are to be evaluated.

<a name='BeeneticToolkit.Logging.Utilities.ObjectPropertyExtensions.CountNonZeroNumericProperties(thisobject,System.Func_System.Reflection.PropertyInfo,bool_).filter'></a>

`filter` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Reflection.PropertyInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.PropertyInfo 'System.Reflection.PropertyInfo')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

An optional filter to include specific properties based on a condition. Defaults to including all numeric properties.

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The count of non-zero numeric properties that match the filter.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when the input object is null.