# BeeneticToolkit.Collections

Type-safe "smart enums" with attached data and fast lookups, plus a small thread-safe object pool.

Targets `netstandard2.1` (modern .NET and Unity).

## Install

```sh
dotnet add package BeeneticToolkit.Collections
```

## Smart enums (`EnumCollection`)

A richer alternative to a C# `enum`: attach arbitrary data to each item, then look items up by
key or name, group them, and search — all strongly typed.

```csharp
using BeeneticToolkit.Collections.Enums;

public sealed class Planet : EnumItem<string, NoGroup> {
    public Planet(string key, string name, string shortName, double massKg)
        : base(key, name, shortName) => MassKg = massKg;

    public double MassKg { get; }
}

public sealed class Planets : EnumCollection<Planet, string, NoGroup> {
    public Planets() {
        Add(new Planet("earth", "Earth", "E", 5.97e24));
        Add(new Planet("mars",  "Mars",  "M", 6.42e23));
    }
}

var planets = new Planets();

Planet earth = planets.FromKey("earth");              // O(1); throws if missing
if (planets.TryFromName("Mars", out var mars)) { /* ... */ }

foreach (var p in planets.GetAll())                    // insertion order
    Console.WriteLine($"{p.Name}: {p.MassKg} kg");
```

Keyed lookups are O(1). Supply a real `enum` as the third type argument to group items
(`GetByGroup(group)`); use `NoGroup` when you don't need grouping.

## Object pooling

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

`StackObjectPool<T>` is thread-safe. `Rent(out …)` returns a `PooledObjectScope<T>` (a struct,
so no allocation) that returns the object when disposed; `Get()`/`Return(obj)` are available for
manual control.

## License

Licensed under the MIT License.
