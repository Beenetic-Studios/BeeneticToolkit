#### [Logging](index.md 'index')
### [BeeneticToolkit.Logging.Utilities](index.md#BeeneticToolkit.Logging.Utilities 'BeeneticToolkit.Logging.Utilities')

## LogIgnoreAttribute Class

Specifies that a property should be ignored when generating a string representation  
of an object's public properties using the [ToPropertiesString(object)](LogUtils.ToPropertiesString(object).md 'BeeneticToolkit.Logging.Utilities.LogUtils.ToPropertiesString(object)') method.

```csharp
public class LogIgnoreAttribute : System.Attribute
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Attribute](https://docs.microsoft.com/en-us/dotnet/api/System.Attribute 'System.Attribute') &#129106; LogIgnoreAttribute

### Remarks
Apply this attribute to properties that should be excluded from the output of  
[ToPropertiesString(object)](LogUtils.ToPropertiesString(object).md 'BeeneticToolkit.Logging.Utilities.LogUtils.ToPropertiesString(object)'). This can be useful for sensitive or irrelevant information  
that should not be included in logs.