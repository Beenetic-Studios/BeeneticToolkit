---
_layout: landing
---

# BeeneticToolkit

A family of small, focused, engine-agnostic .NET utility libraries for game development —
deterministic by design and allocation-aware. Targets `netstandard2.1` (Unity-friendly) and
`net8.0`.

| Package | Summary |
|---|---|
| **BeeneticToolkit.Random** | Deterministic, seedable RNG (xoshiro256\*\* and more), reproducible environments, selection helpers, coherent noise, Poisson/spatial sampling, and probability/loot tools. |
| **BeeneticToolkit.Collections** | Self-registering "smart enums" (`AutoEnumItem`) with grouping, flag sets, and secondary indexes, plus RingBuffer / PriorityQueue / LruCache and a thread-safe object pool. |
| **BeeneticToolkit.Numerics** | `MathKit`: interpolation, splines, easing, angle math, smoothing, and robust comparisons; plus WCAG color contrast. |
| **BeeneticToolkit.Logging** | Lightweight, zero-dependency logger with console/debug/file sinks, caller context, object dumps, and rule-driven redaction. |
| **BeeneticToolkit.Spatial** | Hex & square grids, A\*/Dijkstra/BFS pathfinding and flow fields, field of view, and quadtree / spatial-hash queries. |
| **BeeneticToolkit.BigMath** | Large-number `BigDouble` for incremental/idle games — arithmetic, powers/logs beyond `double`, and a pluggable notation system for display and round-trippable parsing. |
| **BeeneticToolkit.Text** | A bad-word filter for player-entered text (names, statuses, chat) that sees through lookalikes, leet, and separators, over a word list you supply. |

Browse the full **[API Reference](api/index.md)**.

- **Source:** [github.com/Beenetic-Studios/BeeneticToolkit](https://github.com/Beenetic-Studios/BeeneticToolkit)
- **NuGet:** [nuget.org/profiles/Beenetic-Studios](https://www.nuget.org/packages?q=BeeneticToolkit)
