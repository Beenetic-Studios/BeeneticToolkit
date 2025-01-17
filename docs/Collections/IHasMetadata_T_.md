#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Metadata](index.md#BeeneticToolkit.Collections.Enums.Metadata 'BeeneticToolkit.Collections.Enums.Metadata')

## IHasMetadata<T> Interface

Defines an interface for types that can be associated with metadata, supporting readonly behavior.

```csharp
public interface IHasMetadata<T>
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Enums.Metadata.IHasMetadata_T_.T'></a>

`T`

The type of the metadata.

Derived  
&#8627; [EnumItemMetadataBase](EnumItemMetadataBase.md 'BeeneticToolkit.Collections.Enums.Metadata.EnumItemMetadataBase')

| Properties | |
| :--- | :--- |
| [IsReadOnly](IHasMetadata_T_.IsReadOnly.md 'BeeneticToolkit.Collections.Enums.Metadata.IHasMetadata<T>.IsReadOnly') | Gets a value indicating whether the metadata is readonly. |

| Methods | |
| :--- | :--- |
| [EnsureNotReadOnly()](IHasMetadata_T_.EnsureNotReadOnly().md 'BeeneticToolkit.Collections.Enums.Metadata.IHasMetadata<T>.EnsureNotReadOnly()') | Ensures that the metadata can be modified. |
| [MarkAsReadOnly()](IHasMetadata_T_.MarkAsReadOnly().md 'BeeneticToolkit.Collections.Enums.Metadata.IHasMetadata<T>.MarkAsReadOnly()') | Marks the metadata as readonly, preventing further modifications. |
| [UpdateMetadata(T)](IHasMetadata_T_.UpdateMetadata(T).md 'BeeneticToolkit.Collections.Enums.Metadata.IHasMetadata<T>.UpdateMetadata(T)') | Attempts to update the metadata, enforcing readonly behavior and validation. |
