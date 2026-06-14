#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums').[EnumItem&lt;TKey,TGroup&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')

## EnumItem<TKey,TGroup>.Equals(EnumItem<TKey,TGroup>) Method

Determines whether the specified item is equal to the current one, based on its key and runtime type.

```csharp
public bool Equals(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>? other);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_.Equals(BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_).other'></a>

`other` [BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')[TKey](EnumItem_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_.TKey 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.TKey')[,](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')[TGroup](EnumItem_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.TGroup')[&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')

The item to compare with the current enumeration item.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
`true` if [other](EnumItem_TKey,TGroup_.Equals(EnumItem_TKey,TGroup_).md#BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_.Equals(BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_).other 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.Equals(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>).other') has the same runtime type and key; otherwise, `false`.