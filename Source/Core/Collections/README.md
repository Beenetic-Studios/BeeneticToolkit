# BeeneticToolkit.Collections

Type-safe "smart enums" — a richer alternative to a C# `enum` where each value is a real object that
can carry data, be looked up by key/name, grouped, sorted, and searched. Plus a small thread-safe
object pool.

Targets `netstandard2.1` (modern .NET and Unity).

## Install

```sh
dotnet add package BeeneticToolkit.Collections
```

---

## Smart enums

A plain C# `enum` is just a named integer — you can't attach data to it, and parsing/looking it up is
clumsy. A *smart enum* makes each value a strongly-typed object with whatever properties you need, while
keeping the "fixed set of named values" feel.

There are two ways to declare one:

| You want… | Use | Items are… |
| --- | --- | --- |
| The normal case — a fixed set known at compile time | **`AutoEnumItem<TSelf, TKey, TGroup>`** | declared as `static readonly` fields, auto-registered |
| A set built from data at runtime (JSON, mods, DB rows) | **`EnumItem` + `EnumCollection`** | added manually via `Add()` |

Start with `AutoEnumItem`. Reach for the manual pair only when items aren't known until runtime.

---

## `AutoEnumItem` — the recommended path

Declare your items as `public static readonly` fields on the type. That's it — they register themselves,
and you get static lookups (`FromKey`, `All`, …) for free. No collection class, no `Add` calls, no
hand-written lookup methods.

```csharp
using BeeneticToolkit.Collections.Enums;

public enum PlanetGroup { None = 0, Rocky, GasGiant }

// The type names itself as TSelf — "public sealed class Planet : AutoEnumItem<Planet, …>".
public sealed class Planet : AutoEnumItem<Planet, string, PlanetGroup> {

    // Items: public static readonly fields of this type. They are discovered automatically.
    public static readonly Planet Earth   = new("earth",   "Earth",   "E", 5.97e24, PlanetGroup.Rocky);
    public static readonly Planet Mars    = new("mars",    "Mars",    "M", 6.42e23, PlanetGroup.Rocky);
    public static readonly Planet Jupiter = new("jupiter", "Jupiter", "J", 1.90e27, PlanetGroup.GasGiant);

    // Attach any data you like — just add properties.
    public double MassKg { get; }

    // A private constructor keeps the value set closed (only the fields above can exist).
    private Planet(string key, string name, string shortName, double massKg, PlanetGroup group)
        : base(key, name, shortName, group: group) {
        MassKg = massKg;
    }
}
```

Now use it through static members on the type itself:

```csharp
Planet earth = Planet.FromKey("earth");              // O(1); throws if missing
if (Planet.TryFromKey("mars", out var mars)) { /* … */ }

Planet byName  = Planet.FromName("Jupiter");         // also O(1) (indexed by name)
Planet byShort = Planet.FromShortName("E");           // also O(1) (indexed by short name)

foreach (Planet p in Planet.All)                     // every item, in declaration order
    Console.WriteLine($"{p.Name}: {p.MassKg} kg");

int howMany = Planet.Count;
```

Key, name, and short-name lookups are all O(1) — keyed by a dictionary, with the name/short-name
indexes built on first use and kept fresh as items are added or removed. Lookups are case-sensitive and,
when names repeat, return the first item declared.

### The constructor base parameters

`AutoEnumItem` requires `key`, `name`, and `shortName`, and accepts four optional values. Pass the
optional ones by name:

```csharp
private Planet(...) : base(
    key,                      // unique identity, any non-null type (string, an int enum, a Guid…)
    name,                     // display name, e.g. "Jupiter"
    shortName,                // abbreviation, e.g. "J"
    description: "…",         // optional
    displayOrder: 3,          // optional, for ordered display
    isActive: true,           // optional, filterable via isActive: below
    group: PlanetGroup.GasGiant) { }   // optional
```

### Grouping

Supply a real `enum` as the third type argument to group items, then filter by group. Use the built-in
`NoGroup` when you don't need grouping:

```csharp
foreach (Planet rocky in Planet.GetByGroup(PlanetGroup.Rocky)) { /* … */ }

// No grouping needed:
public sealed class Currency : AutoEnumItem<Currency, string, NoGroup> { /* … */ }
```

### Filtering, sorting, and searching

```csharp
using BeeneticToolkit.Collections.Enums.Comparators;

// Active items only (uses the optional isActive flag on each item).
var active = Planet.GetAll(isActive: true);

// Sort with a built-in comparator (ByKey / ByName / ByShortName / ByDisplayOrder / ByActiveState / ByGroup).
var byName = Planet.GetAll(EnumItemComparators.ByName<string, PlanetGroup>());

// Substring search over any string property (case-insensitive by default).
var hits = Planet.Search(p => p.Name, "ar");          // → Mars
```

### Why it's robust: registration is order-independent

Items register the first time you touch *any* static member of the type — and registration explicitly
runs the type's static constructor first, so the set is **always fully populated no matter what you touch
first** (`Planet.All`, `Planet.FromKey(...)`, or a field like `Planet.Earth`). Initialization runs once,
under the runtime's type-init lock, so it's thread-safe with no work on your part.

> **Unity / IL2CPP note:** auto-registration uses reflection over the type's static fields. This works
> under IL2CPP, but aggressive managed-code stripping can remove members only ever accessed via
> reflection. Your item fields are normally also referenced directly in code (`Planet.Earth`), which keeps
> them — but verify on an actual IL2CPP build, or add a `link.xml` preserve rule for your enum types if you
> rely on stripping. If you need a reflection-free option, use the manual `EnumCollection` path below.

---

## `EnumItem` + `EnumCollection` — dynamic / runtime-built sets

When the items aren't known at compile time — loaded from JSON, defined by mods, or read from a database —
derive the item from `EnumItem` and add instances to an `EnumCollection` at runtime.

```csharp
using BeeneticToolkit.Collections.Enums;

public sealed class Card : EnumItem<string, NoGroup> {
    public Card(string key, string name, string shortName, int cost)
        : base(key, name, shortName) => Cost = cost;

    public int Cost { get; }
}

public sealed class CardCatalog : EnumCollection<Card, string, NoGroup> { }

var catalog = new CardCatalog();
foreach (var dto in LoadCardsFromJson())              // built at runtime
    catalog.Add(new Card(dto.Key, dto.Name, dto.Short, dto.Cost));

Card fireball = catalog.FromKey("fireball");
var cheap = catalog.GetAll(EnumItemComparators.ByName<string, NoGroup>())
                   .Where(c => c.Cost <= 2);
```

`EnumCollection` supports `Add`/`AddRange`/`Remove`/`RemoveRange` and the same lookup/query surface
(`FromKey`, `FromName`, `FromShortName`, `GetAll`, `GetByGroup`, `Search`) that `AutoEnumItem` exposes
statically. `AutoEnumItem` is in fact built on these two types — this is the same engine, with manual
control over the item set.

### Equality and comparison (both paths)

Every item is equal to another when they share the **same runtime type and key**, and items sort by key
by default. So items work correctly as dictionary keys, in sets, and in sorted collections.

---

## Flag sets (`EnumSet<T>`)

`EnumSet<T>` is the smart-enum equivalent of a `[Flags]` enum — hold a *combination* of items as one value
and do set algebra on it — but without the 64-value ceiling, the manual `1 << n` bookkeeping, or losing
type safety. It's backed by a compact bitmask (one bit per item), so membership tests and combinations are
fast and the in-place operations allocate nothing.

For an `AutoEnumItem`, the factories come for free on the type:

```csharp
EnumSet<Planet> inner = Planet.SetOf(Planet.Earth, Planet.Mars);
EnumSet<Planet> rocky = Planet.Domain.From(Planet.GetByGroup(PlanetGroup.Rocky));

bool hasEarth = inner.Contains(Planet.Earth);
EnumSet<Planet> everythingElse = ~inner;             // complement, relative to all planets
EnumSet<Planet> both = inner & rocky;                // intersection
bool subset = inner.IsSubsetOf(Planet.FullSet());

foreach (Planet p in inner) { /* yielded in declaration order */ }
```

Combine with operators (`|` union, `&` intersection, `^` symmetric difference, `-` difference, `~`
complement), or mutate in place without allocating (`Add`, `Remove`, `UnionWith`, `IntersectWith`,
`ExceptWith`, `SymmetricExceptWith`). Query with `Contains`, `IsSubsetOf`, `IsSupersetOf`, `Overlaps`,
`SetEquals`, `Count`, `IsEmpty`.

The **domain** is the complete pool of valid items a set draws from — it's what `complement` is relative to,
and only sets built from the **same domain** can be combined (mixing throws). For a runtime-built
`EnumCollection`, snapshot a domain with `collection.ToDomain()`:

```csharp
EnumDomain<Card> domain = catalog.ToDomain();         // snapshot of the current items
EnumSet<Card> starter = domain.Of(catalog.FromKey("strike"), catalog.FromKey("defend"));
```

---

## Secondary indexes

`FromKey` / `FromName` / `FromShortName` cover the built-in lookups. To look items up O(1) by *any* other
property, register a secondary index. You get back a typed, queryable handle — no stringly-typed names:

```csharp
// Runtime-built collection: the index stays in sync as items are added/removed.
EnumIndex<string, Card> byColor = catalog.AddIndex(c => c.Color);
IReadOnlyList<Card> reds = byColor.Get("Red");
Card theOnly = byColor.GetSingle("Colorless");        // throws if not exactly one

// Fixed smart enum: built once over the item set.
public sealed class Planet : AutoEnumItem<Planet, string, PlanetGroup> {
    public static readonly EnumIndex<PlanetGroup, Planet> ByGroup = IndexBy(p => p.Group ?? PlanetGroup.None);
}
var gasGiants = Planet.ByGroup.Get(PlanetGroup.GasGiant);
```

Query with `Get` (all matches), `GetSingle` / `TryGetSingle` (exactly one), `Contains`, `Keys`, and
`Count`. Items whose indexed value is `null` are skipped.

---

## Object pooling

A small, thread-safe object pool for reusing instances and avoiding allocations on hot paths.

```csharp
using BeeneticToolkit.Collections.ObjectPooling;
using BeeneticToolkit.Collections.ObjectPooling.Policies;
using System.Text;

sealed class StringBuilderPolicy : PooledObjectPolicy<StringBuilder> {
    public override StringBuilder Create() => new StringBuilder();
    public override void Reset(StringBuilder sb) => sb.Clear();
    public override bool Validate(StringBuilder sb) => true;
}

var pool = new StackObjectPool<StringBuilder>(new StringBuilderPolicy());

using (pool.Rent(out var sb)) {   // automatically returned to the pool on dispose
    sb.Append("hello");
}
```

`StackObjectPool<T>` is thread-safe. `Rent(out …)` returns a `PooledObjectScope<T>` (a struct, so no
allocation) that returns the object when disposed; `Get()` / `Return(obj)` are available for manual
control.

## Ring buffer

`RingBuffer<T>` is a fixed-capacity circular FIFO. Once full, adding overwrites and drops the oldest
element — perfect for rolling windows like input/command history, recent frame-time or telemetry samples,
netcode snapshots, or "last N events" logs. Backed by a single array, so it allocates nothing in use
(`foreach` is allocation-free via a struct enumerator).

```csharp
using BeeneticToolkit.Collections;

var recent = new RingBuffer<float>(60);   // keep the last 60 frame times
recent.Add(deltaTime);                    // overwrites the oldest once full

float newest = recent.PeekNewest();
float oldest = recent[0];                 // indexer: 0 = oldest … Count-1 = newest
float average = recent.Sum() / recent.Count;

foreach (float dt in recent) { /* oldest → newest */ }
```

Use `Add` for overwrite-oldest behavior, or `TryAdd` to reject when full (a bounded queue). Drain with
`RemoveOldest` / `TryRemoveOldest`; inspect with `PeekOldest` / `PeekNewest` (and `Try…` variants),
`Count`, `Capacity`, `IsEmpty`, `IsFull`.

## Priority queue

`PriorityQueue<TElement, TPriority>` is a binary min-heap: each element is enqueued with a priority, and the
**lowest** priority is always dequeued first. .NET 6+ ships one in the BCL, but `netstandard2.1` / Unity do
not — this is a drop-in with the same API, handy for event scheduling, turn/cooldown ordering, and
pathfinding frontiers.

```csharp
using BeeneticToolkit.Collections;

var events = new PriorityQueue<string, float>();   // priority = time
events.Enqueue("spawn wave", 12.5f);
events.Enqueue("tick",        1.0f);
events.Enqueue("boss",       60.0f);

string next = events.Peek();                        // "tick" (lowest time)
while (events.TryDequeue(out string e, out float t))
    Process(e, t);                                  // fired in time order
```

Pass an `IComparer<TPriority>` to change the ordering (e.g. a reverse comparer for a max-heap). Also
provides `Dequeue`, `EnqueueDequeue` (enqueue then pop the min in one step), `Clear`, and `Count`.

> On .NET 6+ the BCL also defines `PriorityQueue`. If you import both `System.Collections.Generic` and
> `BeeneticToolkit.Collections`, alias or fully qualify to disambiguate. On Unity/`netstandard2.1` there's
> no conflict.

## LRU cache

`LruCache<TKey, TValue>` is a fixed-capacity cache that evicts the least-recently-used entry when it fills
up — so memory stays bounded for asset, result, or path caches. Lookups, inserts, and eviction are all
O(1). Reading or writing a key marks it most-recently-used; `TryPeek`/`ContainsKey` deliberately don't.

```csharp
using BeeneticToolkit.Collections;

var thumbnails = new LruCache<string, Texture>(capacity: 100);
thumbnails.Evicted += (key, tex) => tex.Dispose();         // release what falls out

Texture icon = thumbnails.GetOrAdd(path, LoadTexture);     // cached, or loaded + cached
if (thumbnails.TryGet(path, out Texture cached)) { /* hit, now most-recently-used */ }
```

`Set` / the indexer add-or-update; `TryGet` / `GetOrAdd` read (and bump recency); `TryPeek` / `ContainsKey`
inspect without bumping; `Remove`, `Clear`, `Count`, `Capacity`, and a recency-ordered `Keys` round it out.
Pass an `IEqualityComparer<TKey>` for things like case-insensitive string keys.

## License

Licensed under the MIT License.
