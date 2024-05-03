#### [Extensions](index.md 'index')

## Extensions Assembly
### Namespaces

<a name='BeeneticToolkit.Extensions'></a>

## BeeneticToolkit.Extensions Namespace

The [BeeneticToolkit.Extensions](index.md#BeeneticToolkit.Extensions 'BeeneticToolkit.Extensions') namespace contains a collection of custom extension methods designed to enhance and simplify various programming tasks in C#.  
This may include numeric type conversions, string manipulations, data structure enhancements, and other utility functions that are frequently needed in various development scenarios.
- **[IntegralMappingExtensions](IntegralMappingExtensions.md 'BeeneticToolkit.Extensions.IntegralMappingExtensions')** `Class` Provides extension methods for mapping between signed and unsigned numeric types.
  - **[ToMappedByte(this sbyte)](IntegralMappingExtensions.ToMappedByte(thissbyte).md 'BeeneticToolkit.Extensions.IntegralMappingExtensions.ToMappedByte(this sbyte)')** `Method` Maps an sbyte value to its equivalent byte value, preserving its relative position within the data type's range.
  - **[ToMappedInt16(this ushort)](IntegralMappingExtensions.ToMappedInt16(thisushort).md 'BeeneticToolkit.Extensions.IntegralMappingExtensions.ToMappedInt16(this ushort)')** `Method` Maps a ushort value to its equivalent short value, preserving its relative position within the data type's range.
  - **[ToMappedInt32(this uint)](IntegralMappingExtensions.ToMappedInt32(thisuint).md 'BeeneticToolkit.Extensions.IntegralMappingExtensions.ToMappedInt32(this uint)')** `Method` Maps a uint value to its equivalent int value, preserving its relative position within the data type's range.
  - **[ToMappedInt64(this ulong)](IntegralMappingExtensions.ToMappedInt64(thisulong).md 'BeeneticToolkit.Extensions.IntegralMappingExtensions.ToMappedInt64(this ulong)')** `Method` Maps a ulong value to its equivalent long value, preserving its relative position within the data type's range.
  - **[ToMappedSByte(this byte)](IntegralMappingExtensions.ToMappedSByte(thisbyte).md 'BeeneticToolkit.Extensions.IntegralMappingExtensions.ToMappedSByte(this byte)')** `Method` Maps a byte value to its equivalent sbyte value, preserving its relative position within the data type's range.
  - **[ToMappedUInt16(this short)](IntegralMappingExtensions.ToMappedUInt16(thisshort).md 'BeeneticToolkit.Extensions.IntegralMappingExtensions.ToMappedUInt16(this short)')** `Method` Maps a short value to its equivalent ushort value, preserving its relative position within the data type's range.
  - **[ToMappedUInt32(this int)](IntegralMappingExtensions.ToMappedUInt32(thisint).md 'BeeneticToolkit.Extensions.IntegralMappingExtensions.ToMappedUInt32(this int)')** `Method` Maps an int value to its equivalent uint value, preserving its relative position within the data type's range.
  - **[ToMappedUInt64(this long)](IntegralMappingExtensions.ToMappedUInt64(thislong).md 'BeeneticToolkit.Extensions.IntegralMappingExtensions.ToMappedUInt64(this long)')** `Method` Maps a long value to its equivalent ulong value, preserving its relative position within the data type's range.
- **[ObjectExtensions](ObjectExtensions.md 'BeeneticToolkit.Extensions.ObjectExtensions')** `Class` Provides extension methods for objects.
  - **[ToPropertiesString(this object, string, string)](ObjectExtensions.ToPropertiesString(thisobject,string,string).md 'BeeneticToolkit.Extensions.ObjectExtensions.ToPropertiesString(this object, string, string)')** `Method` Converts an object to a string representation of its public properties.