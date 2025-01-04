#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums.Comparators](index.md#BeeneticToolkit.Collections.Enums.Comparators 'BeeneticToolkit.Collections.Enums.Comparators').[EnumItemComparators](EnumItemComparators.md 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators')

## EnumItemComparators.ByKey<TGroup>(bool) Method

Creates a comparator that sorts [EnumItem&lt;TGroup&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>') instances by their [Key](EnumItem_TGroup_.Key.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.Key') property.

```csharp
public static System.Collections.Generic.IComparer<BeeneticToolkit.Collections.Enums.EnumItem<TGroup>> ByKey<TGroup>(bool ascending=true)
    where TGroup : struct, System.Enum, System.ValueType, System.ValueType;
```
#### Type parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators.ByKey_TGroup_(bool).TGroup'></a>

`TGroup`

The type of the group associated with the enumeration item, which must be an enumeration.
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators.ByKey_TGroup_(bool).ascending'></a>

`ascending` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

A value indicating whether the sorting should be in ascending order. Defaults to `true`.

#### Returns
[System.Collections.Generic.IComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1')[BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')[TGroup](EnumItemComparators.ByKey_TGroup_(bool).md#BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators.ByKey_TGroup_(bool).TGroup 'BeeneticToolkit.Collections.Enums.Comparators.EnumItemComparators.ByKey<TGroup>(bool).TGroup')[&gt;](EnumItem_TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1')  
An [System.Collections.Generic.IComparer&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1') that sorts by [Key](EnumItem_TGroup_.Key.md 'BeeneticToolkit.Collections.Enums.EnumItem<TGroup>.Key') in the specified order.