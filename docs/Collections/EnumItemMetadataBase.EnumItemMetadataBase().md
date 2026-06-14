#### [BeeneticToolkit.Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Metadata](index.md#BeeneticToolkit.Collections.Enums.Metadata 'BeeneticToolkit.Collections.Enums.Metadata').[EnumItemMetadataBase](EnumItemMetadataBase.md 'BeeneticToolkit.Collections.Enums.Metadata.EnumItemMetadataBase')

## EnumItemMetadataBase() Constructor

Initializes a new instance of the [EnumItemMetadataBase](EnumItemMetadataBase.md 'BeeneticToolkit.Collections.Enums.Metadata.EnumItemMetadataBase') class with a unique GUID and timestamps.

```csharp
public EnumItemMetadataBase();
```

#### Exceptions

[MetadataValidationException](MetadataValidationException.md 'BeeneticToolkit.Collections.Enums.Metadata.MetadataValidationException')  
Thrown if the metadata fails validation during creation.

### Remarks
The constructor ensures that the metadata is validated during creation. If validation fails, the object will not be created.