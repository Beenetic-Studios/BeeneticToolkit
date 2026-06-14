#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums').[EnumItem&lt;TKey,TGroup&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')

## EnumItem<TKey,TGroup>.CompareTo(object) Method

Compares the current enumeration item to another object based on their keys.

```csharp
public int CompareTo(object? other);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_.CompareTo(object).other'></a>

`other` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The other enumeration item to compare to.

Implements [CompareTo(object)](https://docs.microsoft.com/en-us/dotnet/api/System.IComparable.CompareTo#System_IComparable_CompareTo_System_Object_ 'System.IComparable.CompareTo(System.Object)')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A value indicating the relative order of the items being compared.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [other](EnumItem_TKey,TGroup_.CompareTo(object).md#BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_.CompareTo(object).other 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.CompareTo(object).other') is not an [EnumItem&lt;TKey,TGroup&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>').