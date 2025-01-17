#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Metadata](index.md#BeeneticToolkit.Collections.Enums.Metadata 'BeeneticToolkit.Collections.Enums.Metadata')

## EnumItemMetadataBase Class

Represents the base class for metadata that can be associated with [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances.

```csharp
public abstract class EnumItemMetadataBase :
BeeneticToolkit.Collections.Enums.Metadata.IHasMetadata<BeeneticToolkit.Collections.Enums.Metadata.EnumItemMetadataBase>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EnumItemMetadataBase

Implements [BeeneticToolkit.Collections.Enums.Metadata.IHasMetadata&lt;](IHasMetadata_T_.md 'BeeneticToolkit.Collections.Enums.Metadata.IHasMetadata<T>')[EnumItemMetadataBase](EnumItemMetadataBase.md 'BeeneticToolkit.Collections.Enums.Metadata.EnumItemMetadataBase')[&gt;](IHasMetadata_T_.md 'BeeneticToolkit.Collections.Enums.Metadata.IHasMetadata<T>')

### Remarks
This class provides a unique identifier (GUID) to distinguish metadata instances, supports readonly behavior, and can be extended to include additional properties as needed.

| Constructors | |
| :--- | :--- |
| [EnumItemMetadataBase()](EnumItemMetadataBase.EnumItemMetadataBase().md 'BeeneticToolkit.Collections.Enums.Metadata.EnumItemMetadataBase.EnumItemMetadataBase()') | Initializes a new instance of the [EnumItemMetadataBase](EnumItemMetadataBase.md 'BeeneticToolkit.Collections.Enums.Metadata.EnumItemMetadataBase') class with a unique GUID and timestamps. |

| Properties | |
| :--- | :--- |
| [CreatedOn](EnumItemMetadataBase.CreatedOn.md 'BeeneticToolkit.Collections.Enums.Metadata.EnumItemMetadataBase.CreatedOn') | Gets the timestamp indicating when this metadata instance was created. |
| [Guid](EnumItemMetadataBase.Guid.md 'BeeneticToolkit.Collections.Enums.Metadata.EnumItemMetadataBase.Guid') | Gets the globally unique identifier (GUID) for this metadata instance. |
| [IsReadOnly](EnumItemMetadataBase.IsReadOnly.md 'BeeneticToolkit.Collections.Enums.Metadata.EnumItemMetadataBase.IsReadOnly') | Gets a value indicating whether the metadata is readonly. |
| [ModifiedOn](EnumItemMetadataBase.ModifiedOn.md 'BeeneticToolkit.Collections.Enums.Metadata.EnumItemMetadataBase.ModifiedOn') | Gets or sets the timestamp indicating when this metadata instance was last modified. |

| Methods | |
| :--- | :--- |
| [CopyFrom(EnumItemMetadataBase)](EnumItemMetadataBase.CopyFrom(EnumItemMetadataBase).md 'BeeneticToolkit.Collections.Enums.Metadata.EnumItemMetadataBase.CopyFrom(BeeneticToolkit.Collections.Enums.Metadata.EnumItemMetadataBase)') | Copies shared properties from the provided metadata instance into the current instance. |
| [EnsureNotReadOnly()](EnumItemMetadataBase.EnsureNotReadOnly().md 'BeeneticToolkit.Collections.Enums.Metadata.EnumItemMetadataBase.EnsureNotReadOnly()') | Ensures that the metadata can be modified. |
| [Equals(object)](EnumItemMetadataBase.Equals(object).md 'BeeneticToolkit.Collections.Enums.Metadata.EnumItemMetadataBase.Equals(object)') | Determines whether the specified object is equal to the current metadata instance, based on the GUID. |
| [GetHashCode()](EnumItemMetadataBase.GetHashCode().md 'BeeneticToolkit.Collections.Enums.Metadata.EnumItemMetadataBase.GetHashCode()') | Returns a hash code for the current metadata instance, based on its GUID. |
| [MarkAsReadOnly()](EnumItemMetadataBase.MarkAsReadOnly().md 'BeeneticToolkit.Collections.Enums.Metadata.EnumItemMetadataBase.MarkAsReadOnly()') | Marks the metadata as readonly, preventing further modifications. |
| [Validate()](EnumItemMetadataBase.Validate().md 'BeeneticToolkit.Collections.Enums.Metadata.EnumItemMetadataBase.Validate()') | Validates the metadata instance to ensure all required properties are set. |
