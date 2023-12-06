#### [MathUtils](index.md 'index')
### [BeeneticToolkit.MathUtils](index.md#BeeneticToolkit.MathUtils 'BeeneticToolkit.MathUtils').[MathUtils](MathUtils.md 'BeeneticToolkit.MathUtils.MathUtils')

## MathUtils.Normalize(double, double, double) Method

Normalizes a double value to a range defined by a minimum and maximum.

```csharp
public static double Normalize(double value, double min, double max);
```
#### Parameters

<a name='BeeneticToolkit.MathUtils.MathUtils.Normalize(double,double,double).value'></a>

`value` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The value to normalize.

<a name='BeeneticToolkit.MathUtils.MathUtils.Normalize(double,double,double).min'></a>

`min` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The minimum value of the range.

<a name='BeeneticToolkit.MathUtils.MathUtils.Normalize(double,double,double).max'></a>

`max` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The maximum value of the range.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
The normalized value, scaled to the range 0 to 1.

#### Exceptions

[System.DivideByZeroException](https://docs.microsoft.com/en-us/dotnet/api/System.DivideByZeroException 'System.DivideByZeroException')  
Thrown when the min and max values are equal.

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when min is greater than max.

### Example
  
```csharp  
double normalized = Normalize(50.0, 0.0, 100.0); // returns 0.5  
```