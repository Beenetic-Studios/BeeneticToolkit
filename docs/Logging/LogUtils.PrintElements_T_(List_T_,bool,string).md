#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging.Utility](index.md#BeeneticToolkit.Logging.Utility 'BeeneticToolkit.Logging.Utility').[LogUtils](LogUtils.md 'BeeneticToolkit.Logging.Utility.LogUtils')

## LogUtils.PrintElements<T>(List<T>, bool, string) Method

Converts a list of elements into a string representation, with options for inline display and custom delimiters.

```csharp
public static string PrintElements<T>(System.Collections.Generic.List<T> list, bool inline=true, string delimiter=" ");
```
#### Type parameters

<a name='BeeneticToolkit.Logging.Utility.LogUtils.PrintElements_T_(System.Collections.Generic.List_T_,bool,string).T'></a>

`T`

The type of elements in the list.
#### Parameters

<a name='BeeneticToolkit.Logging.Utility.LogUtils.PrintElements_T_(System.Collections.Generic.List_T_,bool,string).list'></a>

`list` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](LogUtils.PrintElements_T_(List_T_,bool,string).md#BeeneticToolkit.Logging.Utility.LogUtils.PrintElements_T_(System.Collections.Generic.List_T_,bool,string).T 'BeeneticToolkit.Logging.Utility.LogUtils.PrintElements<T>(System.Collections.Generic.List<T>, bool, string).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

The list to be converted into a string.

<a name='BeeneticToolkit.Logging.Utility.LogUtils.PrintElements_T_(System.Collections.Generic.List_T_,bool,string).inline'></a>

`inline` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Specifies whether the elements should be displayed inline.

<a name='BeeneticToolkit.Logging.Utility.LogUtils.PrintElements_T_(System.Collections.Generic.List_T_,bool,string).delimiter'></a>

`delimiter` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The delimiter to use between elements when displayed inline.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A string representation of the list's elements.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when the input list is null.