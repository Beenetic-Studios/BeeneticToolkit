#### [Collections](index.md 'index')
### [BeeneticToolkit.Collections.Enums](index.md#BeeneticToolkit.Collections.Enums 'BeeneticToolkit.Collections.Enums').[EnumItem&lt;TKey,TGroup&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')

## EnumItem<TKey,TGroup>.CompareTo(EnumItem<TKey,TGroup>) Method

Compares the current enumeration item to another based on their keys.

```csharp
public int CompareTo(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>? other);
```
#### Parameters

<a name='BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_.CompareTo(BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_).other'></a>

`other` [BeeneticToolkit.Collections.Enums.EnumItem&lt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')[TKey](EnumItem_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_.TKey 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.TKey')[,](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')[TGroup](EnumItem_TKey,TGroup_.md#BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_.TGroup 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.TGroup')[&gt;](EnumItem_TKey,TGroup_.md 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>')

The other enumeration item to compare to. A `null` value sorts before this instance.

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A value indicating the relative order of the items being compared. Less than zero if this instance precedes [other](EnumItem_TKey,TGroup_.CompareTo(EnumItem_TKey,TGroup_).md#BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_.CompareTo(BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_).other 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.CompareTo(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>).other'), zero if they are equal, and greater than zero if this instance follows [other](EnumItem_TKey,TGroup_.CompareTo(EnumItem_TKey,TGroup_).md#BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_.CompareTo(BeeneticToolkit.Collections.Enums.EnumItem_TKey,TGroup_).other 'BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>.CompareTo(BeeneticToolkit.Collections.Enums.EnumItem<TKey,TGroup>).other').