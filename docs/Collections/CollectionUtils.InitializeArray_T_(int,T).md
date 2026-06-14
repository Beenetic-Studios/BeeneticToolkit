#### [BeeneticToolkit.Collections](index.md 'index')
### [BeeneticToolkit.Collections.Utilities](index.md#BeeneticToolkit.Collections.Utilities 'BeeneticToolkit.Collections.Utilities').[CollectionUtils](CollectionUtils.md 'BeeneticToolkit.Collections.Utilities.CollectionUtils')

## CollectionUtils.InitializeArray<T>(int, T) Method

Initializes an array of a specified size with a given default value for each element.

```csharp
public static T[] InitializeArray<T>(int size, T defaultValue=default(T));
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Utilities.CollectionUtils.InitializeArray_T_(int,T).T'></a>

`T`

The type of elements in the array.
#### Parameters

<a name='BeeneticToolkit.Collections.Utilities.CollectionUtils.InitializeArray_T_(int,T).size'></a>

`size` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The size of the array to initialize.

<a name='BeeneticToolkit.Collections.Utilities.CollectionUtils.InitializeArray_T_(int,T).defaultValue'></a>

`defaultValue` [T](CollectionUtils.InitializeArray_T_(int,T).md#BeeneticToolkit.Collections.Utilities.CollectionUtils.InitializeArray_T_(int,T).T 'BeeneticToolkit.Collections.Utilities.CollectionUtils.InitializeArray<T>(int, T).T')

The default value to assign to each element in the array. Defaults to the type's default value.

#### Returns
[T](CollectionUtils.InitializeArray_T_(int,T).md#BeeneticToolkit.Collections.Utilities.CollectionUtils.InitializeArray_T_(int,T).T 'BeeneticToolkit.Collections.Utilities.CollectionUtils.InitializeArray<T>(int, T).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
An array of the specified size initialized with the default value.

#### Exceptions

[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
Thrown when the specified size is less than or equal to 0.