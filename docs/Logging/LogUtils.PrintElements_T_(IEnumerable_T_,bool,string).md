#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging.Utilities](index.md#BeeneticToolkit.Logging.Utilities 'BeeneticToolkit.Logging.Utilities').[LogUtils](LogUtils.md 'BeeneticToolkit.Logging.Utilities.LogUtils')

## LogUtils.PrintElements<T>(IEnumerable<T>, bool, string) Method

Converts an IEnumerable sequence into a string representation, with options for inline display and custom delimiters.

```csharp
public static string PrintElements<T>(System.Collections.Generic.IEnumerable<T> enumerable, bool inline=true, string delimiter=" ");
```
#### Type parameters

<a name='BeeneticToolkit.Logging.Utilities.LogUtils.PrintElements_T_(System.Collections.Generic.IEnumerable_T_,bool,string).T'></a>

`T`

The type of elements in the sequence.
#### Parameters

<a name='BeeneticToolkit.Logging.Utilities.LogUtils.PrintElements_T_(System.Collections.Generic.IEnumerable_T_,bool,string).enumerable'></a>

`enumerable` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](LogUtils.PrintElements_T_(IEnumerable_T_,bool,string).md#BeeneticToolkit.Logging.Utilities.LogUtils.PrintElements_T_(System.Collections.Generic.IEnumerable_T_,bool,string).T 'BeeneticToolkit.Logging.Utilities.LogUtils.PrintElements<T>(System.Collections.Generic.IEnumerable<T>, bool, string).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The enumerable to be converted into a string.

<a name='BeeneticToolkit.Logging.Utilities.LogUtils.PrintElements_T_(System.Collections.Generic.IEnumerable_T_,bool,string).inline'></a>

`inline` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Specifies whether the elements should be displayed inline.

<a name='BeeneticToolkit.Logging.Utilities.LogUtils.PrintElements_T_(System.Collections.Generic.IEnumerable_T_,bool,string).delimiter'></a>

`delimiter` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The delimiter to use between elements when displayed inline.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A string representation of the sequence's elements.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when the input enumerable is null.