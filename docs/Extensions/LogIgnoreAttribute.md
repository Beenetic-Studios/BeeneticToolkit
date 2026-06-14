#### [Extensions](index.md 'index')
### [BeeneticToolkit.Extensions](index.md#BeeneticToolkit.Extensions 'BeeneticToolkit.Extensions')

## LogIgnoreAttribute Class

Specifies that a property should be ignored when generating a string representation  
of an object's public properties using [ToPropertiesString(this object, int, char, string)](ObjectPropertyExtensions.ToPropertiesString(thisobject,int,char,string).md 'BeeneticToolkit.Extensions.ObjectPropertyExtensions.ToPropertiesString(this object, int, char, string)').

```csharp
public class LogIgnoreAttribute : System.Attribute
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Attribute](https://docs.microsoft.com/en-us/dotnet/api/System.Attribute 'System.Attribute') &#129106; LogIgnoreAttribute

### Remarks
Apply this attribute to properties that should be excluded from property dumps (for example,  
sensitive or irrelevant information that should not appear in logs).