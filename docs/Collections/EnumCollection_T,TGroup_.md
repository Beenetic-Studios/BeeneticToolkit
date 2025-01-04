#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums')

## EnumCollection<T,TGroup> Class

Represents a collection of strongly-typed enumeration items with utility methods for managing,  
retrieving, and searching items based on their properties.

```csharp
public abstract class EnumCollection<T,TGroup>
    where T : BeeneticToolkit.Collections.Enums.EnumItem<TGroup>
    where TGroup : struct, System.Enum, System.ValueType, System.ValueType
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.T'></a>

`T`

The type of the enumeration items, which must inherit from [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>').

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.TGroup'></a>

`TGroup`

The type of the group associated with the enumeration items, which must be an enumeration.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EnumCollection<T,TGroup>

| Methods | |
| :--- | :--- |
| [Add(T)](EnumCollection_T,TGroup_.Add(T).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.Add(T)') | Adds an enumeration item to the collection if it does not already exist. |
| [AddRange(IEnumerable&lt;T&gt;)](EnumCollection_T,TGroup_.AddRange(IEnumerable_T_).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.AddRange(System.Collections.Generic.IEnumerable<T>)') | Adds multiple enumeration items to the collection. |
| [FromKey(string)](EnumCollection_T,TGroup_.FromKey(string).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.FromKey(string)') | Retrieves an item from the collection by its unique key. |
| [FromName(string)](EnumCollection_T,TGroup_.FromName(string).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.FromName(string)') | Retrieves an item from the collection by its name. |
| [FromShortName(string)](EnumCollection_T,TGroup_.FromShortName(string).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.FromShortName(string)') | Retrieves an item from the collection by its short name. |
| [GetAll(IComparer&lt;T&gt;)](EnumCollection_T,TGroup_.GetAll(IComparer_T_).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.GetAll(System.Collections.Generic.IComparer<T>)') | Retrieves all items in the collection as a read-only list, optionally sorted using a specified comparer. |
| [GetByGroup(Nullable&lt;TGroup&gt;)](EnumCollection_T,TGroup_.GetByGroup(Nullable_TGroup_).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.GetByGroup(System.Nullable<TGroup>)') | Retrieves all items in the collection that belong to the specified group. |
| [Search(Func&lt;T,string&gt;, string, bool)](EnumCollection_T,TGroup_.Search(Func_T,string_,string,bool).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.Search(System.Func<T,string>, string, bool)') | Searches the collection for items whose selected property matches the search term. |
