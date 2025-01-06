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
Use [NoGroup](NoGroup.md 'BeeneticToolkit.Collections.Enums.NoGroup') if grouping is not required.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EnumCollection<T,TGroup>

### Example
The following example demonstrates how to create an [EnumCollection&lt;T,TGroup&gt;](EnumCollection_T,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>') without grouping:  
  
```csharp  
public class PositionCollection : EnumCollection<Position, NoGroup> { }  
  
var positionCollection = new PositionCollection();  
positionCollection.Add(new Position("P001", "Manager", "Mgr"));  
  
var allPositions = positionCollection.GetAll();  
foreach (var position in allPositions) {  
    Console.WriteLine(position.Name);  
}  
```

### Remarks
This class supports both grouped and non-grouped enumeration items. When grouping is not relevant,  
use [NoGroup](NoGroup.md 'BeeneticToolkit.Collections.Enums.NoGroup') as the [TGroup](EnumCollection_T,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.TGroup') parameter. In such cases, methods like  
[GetByGroup(Nullable&lt;TGroup&gt;, Nullable&lt;bool&gt;)](EnumCollection_T,TGroup_.GetByGroup(Nullable_TGroup_,Nullable_bool_).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.GetByGroup(System.Nullable<TGroup>, System.Nullable<bool>)') will still function, but they will return all items in the collection when  
the `group"` parameter is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null').

| Methods | |
| :--- | :--- |
| [Add(T)](EnumCollection_T,TGroup_.Add(T).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.Add(T)') | Adds an enumeration item to the collection if it does not already exist. |
| [AddRange(IEnumerable&lt;T&gt;)](EnumCollection_T,TGroup_.AddRange(IEnumerable_T_).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.AddRange(System.Collections.Generic.IEnumerable<T>)') | Adds multiple enumeration items to the collection. |
| [FromKey(string)](EnumCollection_T,TGroup_.FromKey(string).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.FromKey(string)') | Retrieves an item from the collection by its unique key. |
| [FromName(string)](EnumCollection_T,TGroup_.FromName(string).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.FromName(string)') | Retrieves an item from the collection by its name. |
| [FromShortName(string)](EnumCollection_T,TGroup_.FromShortName(string).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.FromShortName(string)') | Retrieves an item from the collection by its short name. |
| [GetAll(IComparer&lt;T&gt;, Nullable&lt;bool&gt;)](EnumCollection_T,TGroup_.GetAll(IComparer_T_,Nullable_bool_).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.GetAll(System.Collections.Generic.IComparer<T>, System.Nullable<bool>)') | Retrieves all items in the collection as an [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'),<br/>optionally filtered by active state and sorted using a specified comparer. |
| [GetByGroup(Nullable&lt;TGroup&gt;, Nullable&lt;bool&gt;)](EnumCollection_T,TGroup_.GetByGroup(Nullable_TGroup_,Nullable_bool_).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.GetByGroup(System.Nullable<TGroup>, System.Nullable<bool>)') | Retrieves items in the collection that belong to the specified group,<br/>optionally filtered by active state. |
| [Search(Func&lt;T,string&gt;, string, bool, Nullable&lt;bool&gt;)](EnumCollection_T,TGroup_.Search(Func_T,string_,string,bool,Nullable_bool_).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TGroup>.Search(System.Func<T,string>, string, bool, System.Nullable<bool>)') | Searches the collection for items whose selected property matches the specified search term,<br/>optionally filtered by active state. |
