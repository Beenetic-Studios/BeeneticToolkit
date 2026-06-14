#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey')

## RandomKey.IsEmpty Property

Gets a value indicating whether this key is uninitialized or empty.

```csharp
public bool IsEmpty { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the key has no usable value; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

### Remarks
Because [RandomKey](RandomKey.md 'BeeneticToolkit.Random.RandomKey') is a struct, a default instance can exist with a null value.