#### [MathUtils](index.md 'index')
### [BeeneticToolkit.MathUtils](index.md#BeeneticToolkit.MathUtils 'BeeneticToolkit.MathUtils').[MathUtils](MathUtils.md 'BeeneticToolkit.MathUtils.MathUtils')

## MathUtils.Lerp(float, float, float) Method

Performs linear interpolation between two float values based on a given interpolation factor.

```csharp
public static float Lerp(float start, float end, float factor);
```
#### Parameters

<a name='BeeneticToolkit.MathUtils.MathUtils.Lerp(float,float,float).start'></a>

`start` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The start value.

<a name='BeeneticToolkit.MathUtils.MathUtils.Lerp(float,float,float).end'></a>

`end` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The end value.

<a name='BeeneticToolkit.MathUtils.MathUtils.Lerp(float,float,float).factor'></a>

`factor` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The interpolation factor, typically between 0 and 1. Values outside this range are clamped to the range [0, 1].

#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
The interpolated float value between the start and end values.