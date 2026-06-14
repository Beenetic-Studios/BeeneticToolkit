#### [BeeneticToolkit.Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums')

## EnumCollection<T,TKey,TGroup> Class

Represents a collection of strongly-typed enumeration items with utility methods for managing, retrieving, and searching items based on their properties.

```csharp
public abstract class EnumCollection<T,TKey,TGroup>
    where T : BeeneticToolkit.Collections.Enums.EnumItem<TKey, TGroup>
    where TKey : notnull
    where TGroup : struct, System.Enum, System.ValueType, System.ValueType
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.T'></a>

`T`

The type of the enumeration items, which must inherit from [EnumItem&lt;TKey,TGroup&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>').

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.TKey'></a>

`TKey`

The type of the key for the enumeration items.

<a name='BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.TGroup'></a>

`TGroup`

The type of the group associated with the enumeration items. Must be an enumeration. Use [NoGroup](NoGroup.md 'BeeneticToolkit.Collections.Enums.NoGroup') if grouping is not required.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EnumCollection<T,TKey,TGroup>

### Example
  
```csharp  
public class PositionCollection : EnumCollection<Position, PositionKey, NoGroup> { }  
  
var positionCollection = new PositionCollection();  
positionCollection.Add(new Position("P001", "Manager", "Mgr"));  
  
var allPositions = positionCollection.GetAll();  
foreach (var position in allPositions) {  
    Console.WriteLine(position.Name);  
}  
```

### Remarks
This class supports both grouped and non-grouped enumeration items. When grouping is not relevant, use [NoGroup](NoGroup.md 'BeeneticToolkit.Collections.Enums.NoGroup') as the [TGroup](EnumCollection_T,TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumCollection_T,TKey,TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.TGroup') parameter. Methods like [GetByGroup(Nullable&lt;TGroup&gt;, Nullable&lt;bool&gt;)](EnumCollection_T,TKey,TGroup_.GetByGroup(Nullable_TGroup_,Nullable_bool_).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.GetByGroup(System.Nullable<TGroup>, System.Nullable<bool>)') return all items when the `group` parameter is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null').

| Methods | |
| :--- | :--- |
| [Add(T)](EnumCollection_T,TKey,TGroup_.Add(T).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.Add(T)') | Adds an enumeration item to the collection if it does not already exist. |
| [AddRange(IEnumerable&lt;T&gt;)](EnumCollection_T,TKey,TGroup_.AddRange(IEnumerable_T_).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.AddRange(System.Collections.Generic.IEnumerable<T>)') | Adds multiple enumeration items to the collection. |
| [FromKey(TKey)](EnumCollection_T,TKey,TGroup_.FromKey(TKey).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.FromKey(TKey)') | Retrieves an item from the collection by its unique key. |
| [FromName(string)](EnumCollection_T,TKey,TGroup_.FromName(string).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.FromName(string)') | Retrieves an item from the collection by its name. |
| [FromShortName(string)](EnumCollection_T,TKey,TGroup_.FromShortName(string).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.FromShortName(string)') | Retrieves an item from the collection by its short name. |
| [GetAll(IComparer&lt;T&gt;, Nullable&lt;bool&gt;)](EnumCollection_T,TKey,TGroup_.GetAll(IComparer_T_,Nullable_bool_).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.GetAll(System.Collections.Generic.IComparer<T>, System.Nullable<bool>)') | Retrieves all items in the collection as an [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), optionally filtered by active state and sorted using a specified comparer. |
| [GetByGroup(Nullable&lt;TGroup&gt;, Nullable&lt;bool&gt;)](EnumCollection_T,TKey,TGroup_.GetByGroup(Nullable_TGroup_,Nullable_bool_).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.GetByGroup(System.Nullable<TGroup>, System.Nullable<bool>)') | Retrieves items in the collection that belong to the specified group, optionally filtered by active state. |
| [Remove(T)](EnumCollection_T,TKey,TGroup_.Remove(T).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.Remove(T)') | Removes an enumeration item from the collection by its reference. |
| [RemoveRange(IEnumerable&lt;T&gt;)](EnumCollection_T,TKey,TGroup_.RemoveRange(IEnumerable_T_).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.RemoveRange(System.Collections.Generic.IEnumerable<T>)') | Removes multiple enumeration items from the collection by their references. |
| [Search(Func&lt;T,string&gt;, string, bool, Nullable&lt;bool&gt;)](EnumCollection_T,TKey,TGroup_.Search(Func_T,string_,string,bool,Nullable_bool_).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.Search(System.Func<T,string>, string, bool, System.Nullable<bool>)') | Searches the collection for items whose selected property matches the specified search term, optionally filtered by active state. |
| [TryFromKey(TKey, T)](EnumCollection_T,TKey,TGroup_.TryFromKey(TKey,T).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.TryFromKey(TKey, T)') | Attempts to retrieve an item by its unique key, without throwing. |
| [TryFromName(string, T)](EnumCollection_T,TKey,TGroup_.TryFromName(string,T).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.TryFromName(string, T)') | Attempts to retrieve an item by its name, without throwing. |
| [TryFromShortName(string, T)](EnumCollection_T,TKey,TGroup_.TryFromShortName(string,T).md 'BeeneticToolkit.Collections.Enums.EnumCollection<T,TKey,TGroup>.TryFromShortName(string, T)') | Attempts to retrieve an item by its short name, without throwing. |
