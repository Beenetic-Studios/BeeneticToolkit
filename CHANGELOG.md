# Changelog

All notable changes to BeeneticToolkit are documented here. The format is based on
[Keep a Changelog](https://keepachangelog.com/en/1.1.0/). All packages share a single
version number. Pre-1.0, breaking changes bump the **minor** version.

## [Unreleased]

## [0.8.0] - 2026-06-16

### Added
- Package icon — the Beenetic Studios kinetic bee mark — now shown on nuget.org and in IDE
  package managers, shared across every package.
- NuGet version / downloads / license badges in the root and per-package READMEs, plus the
  logo in the root README.
- This changelog. `PackageReleaseNotes` points here.

### Fixed
- Resolved the two `CS0419` ambiguous-cref documentation warnings in `LoggerService`; the
  solution now builds with zero warnings.

## [0.7.0] - 2026-06-15

### Added
- **BeeneticToolkit.Spatial** — new package. Hex and square grids (coordinates, layouts,
  lines, ranges/rings), A\*/Dijkstra/BFS pathfinding and flow fields over an abstract graph,
  recursive-shadowcasting and hex line-of-sight field of view, and quadtree / spatial-hash
  partitioning with rectangle, radius, and nearest-neighbor queries. Engine-agnostic — uses
  integer coordinate structs and `(float X, float Y)` tuples, never an engine `Vector2`.
- Internal Unity visual-test harness under `Sandbox/` (not shipped).

## [0.6.0] - 2026-06-15

### Added
- **BeeneticToolkit.Logging** published. Modernized: caller-info ergonomics, sink refactor,
  optional static facade, `IsEnabled` guards and deferred `Func<string>` overloads, and a
  more durable/faster `FileLogger`.

### Changed
- `LogSeverity`/`LogThreshold` reordered to the conventional Trace < Debug < Info < … order.

### Removed
- The Diagnostics module.

## [0.5.0] - 2026-06-15

### Added
- Collections: `RingBuffer<T>`, `PriorityQueue<TElement, TPriority>` (binary min-heap), and
  `LruCache<TKey, TValue>`.
- Numerics: consolidated into a single `MathKit` facade; spline interpolation (`Cerp`,
  `CatmullRom`), Penner easing curves (`EasingUtils`), angle delta/lerp/move-towards, scalar
  `MoveTowards`, and Tier-2 helpers.

## [0.4.0] - 2026-06-15

### Added
- Collections: `AutoEnumItem` (self-registering smart enums), `EnumSet<T>` flag sets, and
  `EnumIndex` secondary indexes; name/short-name lookups are now O(1).

### Removed
- The `EnumItem` metadata base, for a slimmer public surface pre-1.0.

## [0.3.0] - 2026-06-14

### Added
- Random: coherent noise (`BeeneticToolkit.Random.Noise`), Poisson-disk (blue-noise) sampling,
  deterministic spatial point sampling, and probability/loot tools (weighted bags, loot tables,
  dice, pity).

## [0.2.0] - 2026-06-14

### Changed
- **Random redesigned** around reproducible environments (xoshiro256\*\* default;
  `RandomManager`/`RandomEnvironment`; selectors and shuffle as extension methods on
  `RandomGenerator`). **Breaking.**

### Removed
- Random's dependency on Collections.

## [0.1.0] - 2026-06-14

### Added
- Initial public release: `BeeneticToolkit.Random`, `BeeneticToolkit.Collections`,
  `BeeneticToolkit.Numerics`, and the `BeeneticToolkit` meta-package.

[Unreleased]: https://github.com/bfranksen/BeeneticToolkit/compare/v0.8.0...HEAD
[0.8.0]: https://github.com/bfranksen/BeeneticToolkit/compare/v0.7.0...v0.8.0
[0.7.0]: https://github.com/bfranksen/BeeneticToolkit/compare/v0.6.0...v0.7.0
[0.6.0]: https://github.com/bfranksen/BeeneticToolkit/compare/v0.5.0...v0.6.0
[0.5.0]: https://github.com/bfranksen/BeeneticToolkit/compare/v0.4.0...v0.5.0
[0.4.0]: https://github.com/bfranksen/BeeneticToolkit/compare/v0.3.0...v0.4.0
[0.3.0]: https://github.com/bfranksen/BeeneticToolkit/compare/v0.2.0...v0.3.0
[0.2.0]: https://github.com/bfranksen/BeeneticToolkit/compare/v0.1.0...v0.2.0
[0.1.0]: https://github.com/bfranksen/BeeneticToolkit/releases/tag/v0.1.0
