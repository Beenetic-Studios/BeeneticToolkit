#### [BeeneticToolkit.Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators').[EnumItemComparators](EnumItemComparators.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators')

## EnumItemComparators.ByActiveState<TKey,TGroup>(bool) Method

Creates a comparator that sorts [EnumItem&lt;TKey,TGroup&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>') instances by their [IsActive](EnumItem_TKey,TGroup_.IsActive.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.IsActive') property.

```csharp
public static System.Collections.Generic.IComparer<BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>> ByActiveState<TKey,TGroup>(bool ascending=true)
    where TKey : notnull
    where TGroup : struct, System.Enum, System.ValueType, System.ValueType;
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators.ByActiveState_TKey,TGroup_(bool).TKey'></a>

`TKey`

The type of the key associated with the enumeration item.

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators.ByActiveState_TKey,TGroup_(bool).TGroup'></a>

`TGroup`

The type of the group associated with the enumeration item. Must be an enumeration.
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators.ByActiveState_TKey,TGroup_(bool).ascending'></a>

`ascending` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates whether the sorting should be in ascending order. Defaults to `true`.

#### Returns
[System.Collections.Generic.IComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1')[BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')[TKey](EnumItemComparators.ByActiveState_TKey,TGroup_(bool).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators.ByActiveState_TKey,TGroup_(bool).TKey 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators.ByActiveState<TKey,TGroup>(bool).TKey')[,](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')[TGroup](EnumItemComparators.ByActiveState_TKey,TGroup_(bool).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators.ByActiveState_TKey,TGroup_(bool).TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators.ByActiveState<TKey,TGroup>(bool).TGroup')[&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1')  
An [System.Collections.Generic.IComparer&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1') that sorts by [IsActive](EnumItem_TKey,TGroup_.IsActive.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.IsActive') in the specified order.