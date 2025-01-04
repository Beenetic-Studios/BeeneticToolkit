#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums')

## EnumItem<TGroup> Class

Represents a base class for strongly-typed enumeration items with properties for identification,  
grouping, and display purposes.

```csharp
public abstract class EnumItem<TGroup> :
System.IComparable
    where TGroup : struct, System.Enum, System.ValueType, System.ValueType
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Enums.EnumItem_TGroup_.TGroup'></a>

`TGroup`

The type of the group associated with the enumeration item, which must be an enumeration.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EnumItem<TGroup>

Implements [System.IComparable](https://docs.microsoft.com/en-us/dotnet/api/System.IComparable 'System.IComparable')

| Constructors | |
| :--- | :--- |
| [EnumItem(string, string, string, string, Nullable&lt;int&gt;, Nullable&lt;bool&gt;, Nullable&lt;TGroup&gt;)](EnumItem_TGroup_.EnumItem(string,string,string,string,Nullable_int_,Nullable_bool_,Nullable_TGroup_).md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.EnumItem(string, string, string, string, System.Nullable<int>, System.Nullable<bool>, System.Nullable<TGroup>)') | Initializes a new instance of the [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') class. |

| Properties | |
| :--- | :--- |
| [Description](EnumItem_TGroup_.Description.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.Description') | Gets the optional description of this enumeration item. |
| [DisplayOrder](EnumItem_TGroup_.DisplayOrder.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.DisplayOrder') | Gets the optional display order of this enumeration item. |
| [Group](EnumItem_TGroup_.Group.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.Group') | Gets the optional group associated with this enumeration item. |
| [IsActive](EnumItem_TGroup_.IsActive.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.IsActive') | Gets the optional active state of this enumeration item. |
| [Key](EnumItem_TGroup_.Key.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.Key') | Gets the unique key that identifies this enumeration item. |
| [Name](EnumItem_TGroup_.Name.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.Name') | Gets the display name of this enumeration item. |
| [ShortName](EnumItem_TGroup_.ShortName.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.ShortName') | Gets the short name of this enumeration item. |

| Methods | |
| :--- | :--- |
| [CompareTo(object)](EnumItem_TGroup_.CompareTo(object).md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.CompareTo(object)') | Compares the current enumeration item to another based on their keys. |
| [Equals(object)](EnumItem_TGroup_.Equals(object).md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.Equals(object)') | Determines whether the specified object is equal to the current enumeration item,<br/>based on its key and type. |
| [GetHashCode()](EnumItem_TGroup_.GetHashCode().md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.GetHashCode()') | Returns a hash code for this enumeration item. |
| [ToString()](EnumItem_TGroup_.ToString().md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.ToString()') | Returns a string representation of the enumeration item. |
