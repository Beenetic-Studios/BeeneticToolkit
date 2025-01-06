#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums').[EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')

## EnumItem(string, string, string, string, Nullable<int>, Nullable<bool>, Nullable<TGroup>) Constructor

Initializes a new instance of the [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') class.

```csharp
protected EnumItem(string key, string name, string shortName, string? description=null, System.Nullable<int> displayOrder=null, System.Nullable<bool> isActive=null, System.Nullable<TGroup> group=null);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.EnumItem_TGroup_.EnumItem(string,string,string,string,System.Nullable_int_,System.Nullable_bool_,System.Nullable_TGroup_).key'></a>

`key` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The unique key identifying the enumeration item. Must not be `null`, empty, or whitespace.

<a name='BeeneticToolkit.Collections.Enums.EnumItem_TGroup_.EnumItem(string,string,string,string,System.Nullable_int_,System.Nullable_bool_,System.Nullable_TGroup_).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The display name of the enumeration item. Must not be `null`, empty, or whitespace.

<a name='BeeneticToolkit.Collections.Enums.EnumItem_TGroup_.EnumItem(string,string,string,string,System.Nullable_int_,System.Nullable_bool_,System.Nullable_TGroup_).shortName'></a>

`shortName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The short name of the enumeration item. Must not be `null`, empty, or whitespace.

<a name='BeeneticToolkit.Collections.Enums.EnumItem_TGroup_.EnumItem(string,string,string,string,System.Nullable_int_,System.Nullable_bool_,System.Nullable_TGroup_).description'></a>

`description` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

An optional description of the enumeration item. Defaults to `null`.

<a name='BeeneticToolkit.Collections.Enums.EnumItem_TGroup_.EnumItem(string,string,string,string,System.Nullable_int_,System.Nullable_bool_,System.Nullable_TGroup_).displayOrder'></a>

`displayOrder` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

An optional display order for the enumeration item. Defaults to `null`.

<a name='BeeneticToolkit.Collections.Enums.EnumItem_TGroup_.EnumItem(string,string,string,string,System.Nullable_int_,System.Nullable_bool_,System.Nullable_TGroup_).isActive'></a>

`isActive` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

An optional flag indicating whether the enumeration item is active. Defaults to `null`.

<a name='BeeneticToolkit.Collections.Enums.EnumItem_TGroup_.EnumItem(string,string,string,string,System.Nullable_int_,System.Nullable_bool_,System.Nullable_TGroup_).group'></a>

`group` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[TGroup](EnumItem_TGroup_.md#BeeneticToolkit.Collections.Enums.EnumItem_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.TGroup')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

An optional group associated with the enumeration item. Defaults to `null`. Use [NoGroup](NoGroup.md 'BeeneticToolkit.Collections.Enums.NoGroup') as the [TGroup](EnumItem_TGroup_.md#BeeneticToolkit.Collections.Enums.EnumItem_TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.TGroup') if grouping is not required.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when any required parameter is `null`, empty, or whitespace.