#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums')

## EnumItem<TKey,TGroup> Class

Represents a base class for strongly-typed enumeration items with properties for identification, grouping, and display purposes.

```csharp
public abstract class EnumItem<TKey,TGroup> :
System.IComparable
    where TKey : notnull
    where TGroup : struct, System.Enum, System.ValueType, System.ValueType
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_.TKey'></a>

`TKey`

The type of the key identifying this enumeration item. Must be a non-nullable type.

<a name='BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_.TGroup'></a>

`TGroup`

The type of the group associated with the enumeration item. Must be an enumeration. Use [NoGroup](NoGroup.md 'BeeneticToolkit.Collections.Enums.NoGroup') if grouping is not required.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EnumItem<TKey,TGroup>

Implements [System.IComparable](https://docs.microsoft.com/en-us/dotnet/api/System.IComparable 'System.IComparable')

| Constructors | |
| :--- | :--- |
| [EnumItem(TKey, string, string, string, Nullable&lt;int&gt;, Nullable&lt;bool&gt;, Nullable&lt;TGroup&gt;)](EnumItem_TKey,TGroup_.EnumItem(TKey,string,string,string,Nullable_int_,Nullable_bool_,Nullable_TGroup_).md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.EnumItem(TKey, string, string, string, System.Nullable<int>, System.Nullable<bool>, System.Nullable<TGroup>)') | Initializes a new instance of the [EnumItem&lt;TKey,TGroup&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>') class. |

| Properties | |
| :--- | :--- |
| [Description](EnumItem_TKey,TGroup_.Description.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.Description') | Gets the optional description of this enumeration item. |
| [DisplayOrder](EnumItem_TKey,TGroup_.DisplayOrder.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.DisplayOrder') | Gets the optional display order of this enumeration item. |
| [Group](EnumItem_TKey,TGroup_.Group.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.Group') | Gets the optional group associated with this enumeration item. |
| [IsActive](EnumItem_TKey,TGroup_.IsActive.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.IsActive') | Gets the optional active state of this enumeration item. |
| [Key](EnumItem_TKey,TGroup_.Key.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.Key') | Gets the unique key identifying this enumeration item. |
| [Name](EnumItem_TKey,TGroup_.Name.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.Name') | Gets the display name of this enumeration item. |
| [ShortName](EnumItem_TKey,TGroup_.ShortName.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.ShortName') | Gets the short name of this enumeration item. |

| Methods | |
| :--- | :--- |
| [CompareTo(object)](EnumItem_TKey,TGroup_.CompareTo(object).md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.CompareTo(object)') | Compares the current enumeration item to another based on their keys. |
| [Equals(object)](EnumItem_TKey,TGroup_.Equals(object).md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.Equals(object)') | Determines whether the specified object is equal to the current enumeration item, based on its key and type. |
| [GetHashCode()](EnumItem_TKey,TGroup_.GetHashCode().md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.GetHashCode()') | Returns a hash code for this enumeration item. |
| [ToString()](EnumItem_TKey,TGroup_.ToString().md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.ToString()') | Returns a string representation of the enumeration item. |
