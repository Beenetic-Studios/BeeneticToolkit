# BeeneticToolkit

![BeeneticToolkit](https://raw.githubusercontent.com/Beenetic-Studios/BeeneticToolkit/master/assets/logo-200.png)

[![CI](https://github.com/Beenetic-Studios/BeeneticToolkit/actions/workflows/ci.yml/badge.svg)](https://github.com/Beenetic-Studios/BeeneticToolkit/actions/workflows/ci.yml) [![NuGet](https://img.shields.io/nuget/v/BeeneticToolkit.svg)](https://www.nuget.org/packages/BeeneticToolkit) [![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/Beenetic-Studios/BeeneticToolkit/blob/master/LICENSE.txt)

A set of small, focused .NET utility libraries by **Beenetic Studios**. Each ships as its own NuGet
package, so you take only what you need. All target `netstandard2.1` (modern .NET and Unity-friendly).

## Packages

| Package | Version | What it does |
|---|---|---|
| [`BeeneticToolkit.Random`](https://github.com/Beenetic-Studios/BeeneticToolkit/blob/master/Source/Core/Random/README.md) | [![NuGet](https://img.shields.io/nuget/v/BeeneticToolkit.Random.svg)](https://www.nuget.org/packages/BeeneticToolkit.Random) | Deterministic, seedable RNG (xoshiro256\*\* and more) with reproducible environments, rich selection helpers, coherent noise (value/Perlin, 2D & 3D, fractal/fBm), and probability tools (weighted bags, loot tables, dice, pity). |
| [`BeeneticToolkit.Collections`](https://github.com/Beenetic-Studios/BeeneticToolkit/blob/master/Source/Core/Collections/README.md) | [![NuGet](https://img.shields.io/nuget/v/BeeneticToolkit.Collections.svg)](https://www.nuget.org/packages/BeeneticToolkit.Collections) | Self-registering "smart enums" with attached data, O(1) lookups, flag sets and secondary indexes, plus general structures (ring buffer, priority queue, LRU cache) and a thread-safe object pool. |
| [`BeeneticToolkit.Numerics`](https://github.com/Beenetic-Studios/BeeneticToolkit/blob/master/Source/Core/Numerics/README.md) | [![NuGet](https://img.shields.io/nuget/v/BeeneticToolkit.Numerics.svg)](https://www.nuget.org/packages/BeeneticToolkit.Numerics) | `Mathf`-style numeric helpers on one `MathKit` type — interpolation, splines, easing, remapping, angle math, smoothing, robust comparisons. |
| [`BeeneticToolkit.Logging`](https://github.com/Beenetic-Studios/BeeneticToolkit/blob/master/Source/Core/Logging/README.md) | [![NuGet](https://img.shields.io/nuget/v/BeeneticToolkit.Logging.svg)](https://www.nuget.org/packages/BeeneticToolkit.Logging) | Lightweight, zero-dependency logger — severity levels fanning out to console/debug/file sinks, caller context, object dumps, and an optional static facade. |
| [`BeeneticToolkit.Spatial`](https://github.com/Beenetic-Studios/BeeneticToolkit/blob/master/Source/Core/Spatial/README.md) | [![NuGet](https://img.shields.io/nuget/v/BeeneticToolkit.Spatial.svg)](https://www.nuget.org/packages/BeeneticToolkit.Spatial) | 2D grids (hex & square), pathfinding (A\*/Dijkstra/BFS, flow fields), field of view, and quadtree / spatial-hash queries — engine-agnostic, no `Vector2` required. |
| `BeeneticToolkit` | [![NuGet](https://img.shields.io/nuget/v/BeeneticToolkit.svg)](https://www.nuget.org/packages/BeeneticToolkit) | Meta-package that references all of the above. |

Install an individual package, e.g.:

```sh
dotnet add package BeeneticToolkit.Random
```

…or the meta-package for everything:

```sh
dotnet add package BeeneticToolkit
```

## Building from source

```sh
dotnet build BeeneticToolkit.sln -c Release
dotnet test  BeeneticToolkit.sln
```

## License

MIT — see [LICENSE.txt](https://github.com/Beenetic-Studios/BeeneticToolkit/blob/master/LICENSE.txt).
