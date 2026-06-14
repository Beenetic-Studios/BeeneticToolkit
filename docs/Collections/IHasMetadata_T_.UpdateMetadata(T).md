#### [BeeneticToolkit.Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Metadata](index.md#BeeneticToolkit.Collections.Enums.Metadata 'BeeneticToolkit.Collections.Enums.Metadata').[IHasMetadata&lt;T&gt;](IHasMetadata_T_.md 'BeeneticToolkit.Collections.Enums.Metadata.IHasMetadata<T>')

## IHasMetadata<T>.UpdateMetadata(T) Method

Attempts to update the metadata, enforcing readonly behavior and validation.

```csharp
bool UpdateMetadata(T metadata);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.Metadata.IHasMetadata_T_.UpdateMetadata(T).metadata'></a>

`metadata` [T](IHasMetadata_T_.md#BeeneticToolkit.Collections.Enums.Metadata.IHasMetadata_T_.T 'BeeneticToolkit.Collections.Enums.Metadata.IHasMetadata<T>.T')

The new metadata instance to associate.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if the metadata was successfully updated; otherwise, `false`.