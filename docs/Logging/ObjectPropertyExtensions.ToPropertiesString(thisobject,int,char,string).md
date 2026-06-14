#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging.Utilities](index.md#BeeneticToolkit.Logging.Utilities 'BeeneticToolkit.Logging.Utilities').[ObjectPropertyExtensions](ObjectPropertyExtensions.md 'BeeneticToolkit.Logging.Utilities.ObjectPropertyExtensions')

## ObjectPropertyExtensions.ToPropertiesString(this object, int, char, string) Method

Converts an object to a string representation of its public properties, including nested objects, dictionaries, and collections.

```csharp
public static string ToPropertiesString(this object obj, int depth=0, char indent=' ', string newLineString="\n");
```
#### Parameters

<a name='BeeneticToolkit.Logging.Utilities.ObjectPropertyExtensions.ToPropertiesString(thisobject,int,char,string).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object to convert.

<a name='BeeneticToolkit.Logging.Utilities.ObjectPropertyExtensions.ToPropertiesString(thisobject,int,char,string).depth'></a>

`depth` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The current depth of recursion. Defaults to 0.

<a name='BeeneticToolkit.Logging.Utilities.ObjectPropertyExtensions.ToPropertiesString(thisobject,int,char,string).indent'></a>

`indent` [System.Char](https://docs.microsoft.com/en-us/dotnet/api/System.Char 'System.Char')

The indentation character for each level of depth. Defaults to a single space.

<a name='BeeneticToolkit.Logging.Utilities.ObjectPropertyExtensions.ToPropertiesString(thisobject,int,char,string).newLineString'></a>

`newLineString` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The string to append as a new line separator. Defaults to "\n".

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A string containing the object's public property names and values, including nested objects.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown when the input object is null.