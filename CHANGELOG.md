# Changelog

All notable changes to BeeneticToolkit are documented here. The format is based on
[Keep a Changelog](https://keepachangelog.com/en/1.1.0/). All packages share a single
version number. Pre-1.0, breaking changes bump the **minor** version.

## [Unreleased]

## [0.10.0] - 2026-06-21

### Added
- **`net8.0` target.** Every package now multi-targets `netstandard2.1` and `net8.0`. Unity and
  other netstandard2.1 consumers are unaffected (that build is unchanged); .NET 8 consumers get a
  build compiled for that runtime.
- API reference site, generated with DocFX and published to GitHub Pages.

### Changed
- Tightened public-API nullability (surfaced by the net8 build): added `notnull` constraints to
  generic node/key types (`IGraph`/`IWeightedGraph`/`FlowField` node type; `EnumIndex` and its
  `AddIndex`/`IndexBy` value type; the weighted-choice key type), annotated `Equals(object?)` on
  `DiceRoll`/`RandomKey`, and made `LogManager.GetLogger` return a nullable `LoggerBase?`. The added
  generic constraints are technically source-breaking, hence the minor version bump.
- Enabled NuGet package validation in the build (cross-framework public-API consistency).

## [0.9.0] - 2026-06-18

### Changed
- Refreshed the package icon — the kinetic bee mark now has a more upright bee and flatter,
  skinnier, sharper motion streaks. Shown on nuget.org and in IDE package managers across every
  package.

## [0.8.2] - 2026-06-16

### Changed
- Repository moved to the **Beenetic-Studios** GitHub organization. All repository URLs
  (`RepositoryUrl`, `PackageProjectUrl`, README badges/logo/links, and changelog links) now point
  at `github.com/Beenetic-Studios/BeeneticToolkit`. With the repository now public, the README
  images, the nuget "Source" link, and SourceLink debugging resolve correctly.

## [0.8.1] - 2026-06-16

### Fixed
- The root / meta-package README now renders correctly on nuget.org: replaced the raw HTML
  header (which nuget escapes for safety, so it showed as literal markup) with pure Markdown,
  and switched all images and links to absolute URLs. Per-package README license links were
  made absolute as well.

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

[Unreleased]: https://github.com/Beenetic-Studios/BeeneticToolkit/compare/v0.10.0...HEAD
[0.10.0]: https://github.com/Beenetic-Studios/BeeneticToolkit/compare/v0.9.0...v0.10.0
[0.9.0]: https://github.com/Beenetic-Studios/BeeneticToolkit/compare/v0.8.2...v0.9.0
[0.8.2]: https://github.com/Beenetic-Studios/BeeneticToolkit/compare/v0.8.1...v0.8.2
[0.8.1]: https://github.com/Beenetic-Studios/BeeneticToolkit/compare/v0.8.0...v0.8.1
[0.8.0]: https://github.com/Beenetic-Studios/BeeneticToolkit/compare/v0.7.0...v0.8.0
[0.7.0]: https://github.com/Beenetic-Studios/BeeneticToolkit/compare/v0.6.0...v0.7.0
[0.6.0]: https://github.com/Beenetic-Studios/BeeneticToolkit/compare/v0.5.0...v0.6.0
[0.5.0]: https://github.com/Beenetic-Studios/BeeneticToolkit/compare/v0.4.0...v0.5.0
[0.4.0]: https://github.com/Beenetic-Studios/BeeneticToolkit/compare/v0.3.0...v0.4.0
[0.3.0]: https://github.com/Beenetic-Studios/BeeneticToolkit/compare/v0.2.0...v0.3.0
[0.2.0]: https://github.com/Beenetic-Studios/BeeneticToolkit/compare/v0.1.0...v0.2.0
[0.1.0]: https://github.com/Beenetic-Studios/BeeneticToolkit/releases/tag/v0.1.0
