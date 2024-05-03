#### [Extensions](index.md 'index')
### [BeeneticToolkit.Extensions](index.md#BeeneticToolkit.Extensions 'BeeneticToolkit.Extensions').[ObjectExtensions](ObjectExtensions.md 'BeeneticToolkit.Extensions.ObjectExtensions')

## ObjectExtensions.ToPropertiesString(this object, string, string) Method

Converts an object to a string representation of its public properties.

```csharp
public static string ToPropertiesString(this object obj, string prependString="", string endlineString="\n");
```
#### Parameters

<a name='BeeneticToolkit.Extensions.ObjectExtensions.ToPropertiesString(thisobject,string,string).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object to convert.

<a name='BeeneticToolkit.Extensions.ObjectExtensions.ToPropertiesString(thisobject,string,string).prependString'></a>

`prependString` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The string to prepend to each property line. Default is an empty string.

<a name='BeeneticToolkit.Extensions.ObjectExtensions.ToPropertiesString(thisobject,string,string).endlineString'></a>

`endlineString` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The string to append to each property line as a new line separator. Default is "\n".

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A string containing the object's public property names and values.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when the input object is null.