# BeeneticToolkit

[![CI](https://github.com/bfranksen/BeeneticToolkit/actions/workflows/ci.yml/badge.svg)](https://github.com/bfranksen/BeeneticToolkit/actions/workflows/ci.yml)

A set of small, focused .NET utility libraries. Each ships as its own NuGet package, so you take
only what you need. All target `netstandard2.1` (modern .NET and Unity-friendly).

## Packages

| Package | What it does |
|---|---|
| [`BeeneticToolkit.Random`](Source/Core/Random/README.md) | Deterministic, seedable RNG (xoshiro256\*\* and more) with reproducible environments, rich selection helpers, and coherent noise (value/Perlin, 2D & 3D, fractal/fBm). |
| [`BeeneticToolkit.Collections`](Source/Core/Collections/README.md) | Type-safe "smart enums" with attached data and O(1) lookups, plus a thread-safe object pool. |
| [`BeeneticToolkit.Numerics`](Source/Core/Numerics/README.md) | `Mathf`-style numeric helpers — interpolation, remapping, angle math, robust comparisons. |
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
