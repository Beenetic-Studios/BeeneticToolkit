#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging.Utilities](index.md#BeeneticToolkit.Logging.Utilities 'BeeneticToolkit.Logging.Utilities').[ObjectPropertyExtensions](ObjectPropertyExtensions.md 'BeeneticToolkit.Logging.Utilities.ObjectPropertyExtensions')

## ObjectPropertyExtensions.SumNumericProperties(this object, Func<PropertyInfo,bool>) Method

Calculates the sum of all numeric properties of an object, optionally filtered by a custom condition.

```csharp
public static double SumNumericProperties(this object obj, System.Func<System.Reflection.PropertyInfo,bool>? filter=null);
```
#### Parameters

<a name='BeeneticToolkit.Logging.Utilities.ObjectPropertyExtensions.SumNumericProperties(thisobject,System.Func_System.Reflection.PropertyInfo,bool_).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object whose numeric properties are to be summed.

<a name='BeeneticToolkit.Logging.Utilities.ObjectPropertyExtensions.SumNumericProperties(thisobject,System.Func_System.Reflection.PropertyInfo,bool_).filter'></a>

`filter` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Reflection.PropertyInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.PropertyInfo 'System.Reflection.PropertyInfo')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

An optional filter to include specific properties based on a condition. Defaults to including all numeric properties.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
The sum of the numeric properties that match the filter.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when the input object is null.