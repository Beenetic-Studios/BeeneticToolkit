# BeeneticToolkit

[![CI](https://github.com/bfranksen/BeeneticToolkit/actions/workflows/ci.yml/badge.svg)](https://github.com/bfranksen/BeeneticToolkit/actions/workflows/ci.yml)

A set of small, focused .NET utility libraries. Each ships as its own NuGet package, so you take
only what you need. All target `netstandard2.1` (modern .NET and Unity-friendly).

## Packages

| Package | What it does |
|---|---|
| [`BeeneticToolkit.Random`](Source/Core/Random/README.md) | Deterministic, seedable RNG (xoshiro256\*\* and more) with reproducible environments, rich selection helpers, coherent noise (value/Perlin, 2D & 3D, fractal/fBm), and probability tools (weighted bags, loot tables, dice, pity). |
| [`BeeneticToolkit.Collections`](Source/Core/Collections/README.md) | Self-registering "smart enums" with attached data, O(1) lookups, flag sets and secondary indexes, plus general structures (ring buffer, priority queue, LRU cache) and a thread-safe object pool. |
| [`BeeneticToolkit.Numerics`](Source/Core/Numerics/README.md) | `Mathf`-style numeric helpers on one `MathKit` type — interpolation, splines, easing, remapping, angle math, smoothing, robust comparisons. |
| [`BeeneticToolkit.Logging`](Source/Core/Logging/README.md) | Lightweight, zero-dependency logger — severity levels fanning out to console/debug/file sinks, caller context, object dumps, and an optional static facade. |
| [`BeeneticToolkit.Spatial`](Source/Core/Spatial/README.md) | 2D grids (hex & square), pathfinding (A\*/Dijkstra/BFS, flow fields), field of view, and quadtree / spatial-hash queries — engine-agnostic, no `Vector2` required. |
| `BeeneticToolkit` | Meta-package that references all of the above. |

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

MIT — see [LICENSE.txt](LICENSE.txt).
