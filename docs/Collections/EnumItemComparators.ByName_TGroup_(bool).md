#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators').[EnumItemComparators](EnumItemComparators.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators')

## EnumItemComparators.ByName<TGroup>(bool) Method

Creates a comparator that sorts [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances by their [Name](EnumItem_TGroup_.Name.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.Name') property.

```csharp
public static System.Collections.Generic.IComparer<BeeneticToolkit.Collections.Enums.EnumItem<TGroup>> ByName<TGroup>(bool ascending=true)
    where TGroup : struct, System.Enum, System.ValueType, System.ValueType;
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators.ByName_TGroup_(bool).TGroup'></a>

`TGroup`

The type of the group associated with the enumeration item. Must be an enumeration.
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators.ByName_TGroup_(bool).ascending'></a>

`ascending` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Indicates whether the sorting should be in ascending order. Defaults to `true`.

#### Returns
[System.Collections.Generic.IComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1')[BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')[TGroup](EnumItemComparators.ByName_TGroup_(bool).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators.ByName_TGroup_(bool).TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators.ByName<TGroup>(bool).TGroup')[&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1')  
An [System.Collections.Generic.IComparer&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1') that sorts by [Name](EnumItem_TGroup_.Name.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.Name') in the specified order.