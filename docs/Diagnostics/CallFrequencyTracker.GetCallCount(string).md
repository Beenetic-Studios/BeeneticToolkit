#### [Diagnostics](index.md 'index')
### [BeeneticToolkit.Diagnostics](index.md#BeeneticToolkit.Diagnostics 'BeeneticToolkit.Diagnostics').[CallFrequencyTracker](CallFrequencyTracker.md 'BeeneticToolkit.Diagnostics.CallFrequencyTracker')

## CallFrequencyTracker.GetCallCount(string) Method

Gets the call count for a specified method.

```csharp
public static int GetCallCount(string methodName);
```
#### Parameters

<a name='BeeneticToolkit.Diagnostics.CallFrequencyTracker.GetCallCount(string).methodName'></a>

`methodName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the method.

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The number of times the method has been called.