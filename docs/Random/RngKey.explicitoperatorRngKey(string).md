#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey')

## RngKey.explicit operator RngKey(string) Operator

Converts a string value to an [RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey').

```csharp
public static BeeneticToolkit.Random.RngKey explicit operator RngKey(string value);
```
#### Parameters

<a name='BeeneticToolkit.Random.RngKey.op_ExplicitBeeneticToolkit.Random.RngKey(string).value'></a>

`value` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The string value to convert.

#### Returns
[RngKey](RngKey.md 'BeeneticToolkit.Random.RngKey')

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [value](RngKey.explicitoperatorRngKey(string).md#BeeneticToolkit.Random.RngKey.op_ExplicitBeeneticToolkit.Random.RngKey(string).value 'BeeneticToolkit.Random.RngKey.op_Explicit BeeneticToolkit.Random.RngKey(string).value') is null, empty, or whitespace.