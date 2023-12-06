#### [CollectionUtils](index.md 'index')
### [BeeneticToolkit.CollectionUtils](index.md#BeeneticToolkit.CollectionUtils 'BeeneticToolkit.CollectionUtils').[CollectionUtils](CollectionUtils.md 'BeeneticToolkit.CollectionUtils.CollectionUtils')

## CollectionUtils.InitializeArray<T>(int, T) Method

Initializes an array of a specified size with a given default value for each element.

```csharp
public static T[] InitializeArray<T>(int size, T defaultValue=default(T));
```
#### Type parameters

<a name='BeeneticToolkit.CollectionUtils.CollectionUtils.InitializeArray_T_(int,T).T'></a>

`T`

The type of elements in the array.
#### Parameters

<a name='BeeneticToolkit.CollectionUtils.CollectionUtils.InitializeArray_T_(int,T).size'></a>

`size` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The size of the array to initialize.

<a name='BeeneticToolkit.CollectionUtils.CollectionUtils.InitializeArray_T_(int,T).defaultValue'></a>

`defaultValue` [T](CollectionUtils.InitializeArray_T_(int,T).md#BeeneticToolkit.CollectionUtils.CollectionUtils.InitializeArray_T_(int,T).T 'BeeneticToolkit.CollectionUtils.CollectionUtils.InitializeArray<T>(int, T).T')

The default value to assign to each element in the array.

#### Returns
[T](CollectionUtils.InitializeArray_T_(int,T).md#BeeneticToolkit.CollectionUtils.CollectionUtils.InitializeArray_T_(int,T).T 'BeeneticToolkit.CollectionUtils.CollectionUtils.InitializeArray<T>(int, T).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
An array of the specified size initialized with the default value.

#### Exceptions

[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
Thrown when the specified size is less than or equal to 0.