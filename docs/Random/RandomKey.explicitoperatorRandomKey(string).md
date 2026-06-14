#### [BeeneticToolkit.Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey')

## RandomKey.explicit operator RandomKey(string) Operator

Converts a string value to an [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey').

```csharp
public static BeeneticToolkit.Random.RandomKey explicit operator RandomKey(string value);
```
#### Parameters

<a name='BeeneticToolkit.Random.RandomKey.op_ExplicitBeeneticToolkit.Random.RandomKey(string).value'></a>

`value` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The string value to convert.

#### Returns
[RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey')

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
Thrown when [value](RandomKey.explicitoperatorRandomKey(string).md#BeeneticToolkit.Random.RandomKey.op_ExplicitBeeneticToolkit.Random.RandomKey(string).value 'BeeneticToolkit.Random.RandomKey.op_Explicit BeeneticToolkit.Random.RandomKey(string).value') is null, empty, or whitespace.