#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging.Utility](index.md#BeeneticToolkit.Logging.Utility 'BeeneticToolkit.Logging.Utility').[LogUtils](LogUtils.md 'BeeneticToolkit.Logging.Utility.LogUtils')

## LogUtils.PropertyZeroSet<T>(T) Method

Sets all numeric properties of an object to zero.

```csharp
public static void PropertyZeroSet<T>(T obj);
```
#### Type parameters

<a name='BeeneticToolkit.Logging.Utility.LogUtils.PropertyZeroSet_T_(T).T'></a>

`T`

The type of the object whose numeric properties will be set to zero.
#### Parameters

<a name='BeeneticToolkit.Logging.Utility.LogUtils.PropertyZeroSet_T_(T).obj'></a>

`obj` [T](LogUtils.PropertyZeroSet_T_(T).md#BeeneticToolkit.Logging.Utility.LogUtils.PropertyZeroSet_T_(T).T 'BeeneticToolkit.Logging.Utility.LogUtils.PropertyZeroSet<T>(T).T')

The object whose numeric properties are to be updated. Must not be `null`.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when [obj](LogUtils.PropertyZeroSet_T_(T).md#BeeneticToolkit.Logging.Utility.LogUtils.PropertyZeroSet_T_(T).obj 'BeeneticToolkit.Logging.Utility.LogUtils.PropertyZeroSet<T>(T).obj') is `null`.