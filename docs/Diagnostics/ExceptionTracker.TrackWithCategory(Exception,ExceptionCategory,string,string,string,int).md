#### [Diagnostics](index.md 'index')
### [BeeneticToolkit.Diagnostics](index.md#BeeneticToolkit.Diagnostics 'BeeneticToolkit.Diagnostics').[ExceptionTracker](ExceptionTracker.md 'BeeneticToolkit.Diagnostics.ExceptionTracker')

## ExceptionTracker.TrackWithCategory(Exception, ExceptionCategory, string, string, string, int) Method

Tracks an exception with detailed method context, using a specified category.

```csharp
public static string TrackWithCategory(System.Exception exception, BeeneticToolkit.Diagnostics.ExceptionCategory category, string context="", string methodName="", string filePath="", int lineNumber=0);
```
#### Parameters

<a name='BeeneticToolkit.Diagnostics.ExceptionTracker.TrackWithCategory(System.Exception,BeeneticToolkit.Diagnostics.ExceptionCategory,string,string,string,int).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

The exception to track.

<a name='BeeneticToolkit.Diagnostics.ExceptionTracker.TrackWithCategory(System.Exception,BeeneticToolkit.Diagnostics.ExceptionCategory,string,string,string,int).category'></a>

`category` [ExceptionCategory](ExceptionCategory.md 'BeeneticToolkit.Diagnostics.ExceptionCategory')

The category of the exception.

<a name='BeeneticToolkit.Diagnostics.ExceptionTracker.TrackWithCategory(System.Exception,BeeneticToolkit.Diagnostics.ExceptionCategory,string,string,string,int).context'></a>

`context` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Additional context information (optional).

<a name='BeeneticToolkit.Diagnostics.ExceptionTracker.TrackWithCategory(System.Exception,BeeneticToolkit.Diagnostics.ExceptionCategory,string,string,string,int).methodName'></a>

`methodName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the method where the exception occurred (auto-filled).

<a name='BeeneticToolkit.Diagnostics.ExceptionTracker.TrackWithCategory(System.Exception,BeeneticToolkit.Diagnostics.ExceptionCategory,string,string,string,int).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file path of the method (auto-filled).

<a name='BeeneticToolkit.Diagnostics.ExceptionTracker.TrackWithCategory(System.Exception,BeeneticToolkit.Diagnostics.ExceptionCategory,string,string,string,int).lineNumber'></a>

`lineNumber` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The line number of the method (auto-filled).

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A detailed exception report as a string.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Thrown if the provided exception is null.