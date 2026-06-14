#### [Random](index.md 'index')
### [BeeneticToolkit.Random](index.md#BeeneticToolkit.Random 'BeeneticToolkit.Random').[RandomGenerator](RandomGenerator.md 'BeeneticToolkit.Random.RandomGenerator')

## RandomGenerator.NextGuid() Method

Generates a [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/System.Guid 'System.Guid') populated with random bytes.

```csharp
public virtual System.Guid NextGuid();
```

Implements [NextGuid()](IRandomGenerator.NextGuid().md 'BeeneticToolkit.Random.IRandomGenerator.NextGuid()')

#### Returns
[System.Guid](https://docs.microsoft.com/en-us/dotnet/api/System.Guid 'System.Guid')  
A [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/System.Guid 'System.Guid') composed of random bytes.

### Remarks
The bytes come from this (non-cryptographic) generator, so the result is not an RFC 4122  
version-4 UUID; do not use it where a secure or standards-compliant identifier is required.