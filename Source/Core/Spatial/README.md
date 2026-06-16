# BeeneticToolkit.Spatial

[![NuGet](https://img.shields.io/nuget/v/BeeneticToolkit.Spatial.svg)](https://www.nuget.org/packages/BeeneticToolkit.Spatial) [![Downloads](https://img.shields.io/nuget/dt/BeeneticToolkit.Spatial.svg)](https://www.nuget.org/packages/BeeneticToolkit.Spatial) [![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/bfranksen/BeeneticToolkit/blob/master/LICENSE.txt)

Grids, pathfinding, visibility, and spatial queries for 2D games — engine-agnostic and deterministic.

Targets `netstandard2.1` (works in plain .NET and Unity). It never references an engine vector type: grids use
their own integer coordinate structs (`Hex`, `GridCoord`), and world-space positions cross the API as plain
`(float X, float Y)` tuples that you convert to your `Vector2` at the call site.

## Install

```sh
dotnet add package BeeneticToolkit.Spatial
```

## What's inside

| Area | Namespace | Types |
|---|---|---|
| Hex grids | `BeeneticToolkit.Spatial` | `Hex`, `HexLayout`, `OffsetCoord`, `FractionalHex` |
| Square grids | `BeeneticToolkit.Spatial` | `GridCoord`, `GridMetric` |
| Pathfinding | `BeeneticToolkit.Spatial.Pathfinding` | `Pathfinder`, `FlowField`, `GridGraph`, `HexGraph`, `IGraph`/`IWeightedGraph` |
| Field of view | `BeeneticToolkit.Spatial.Visibility` | `GridFieldOfView`, `HexFieldOfView` |
| Spatial partitioning | `BeeneticToolkit.Spatial.Partitioning` | `Quadtree`, `SpatialHash`, `Aabb` |

## Hex grids

Axial coordinates (Red Blob Games conventions), with cube math under the hood and offset/pixel conversions at
the edges.

```csharp
using BeeneticToolkit.Spatial;

var center = new Hex(0, 0);
int dist = center.DistanceTo(new Hex(3, -1));   // hex steps

foreach (Hex h in center.Range(2)) { /* filled disk */ }
var ring   = center.Ring(3);                     // just the border
var spiral = center.Spiral(3);                   // same cells as Range, center-outward order
var line   = Hex.Line(center, new Hex(4, -2));   // line of hexes

// World <-> hex (size and origin are (float X, float Y) tuples)
var layout = new HexLayout(HexOrientation.Pointy, (32f, 32f), (0f, 0f));
(float x, float y) = layout.ToPixel(center);
Hex under = layout.PixelToHex((mouseX, mouseY));
(float X, float Y)[] corners = layout.PolygonCorners(center);   // for drawing

// Rectangular storage
var offset = OffsetCoord.FromHex(center, OffsetLayout.OddR);
```

## Square grids

`GridCoord` is the square-grid counterpart to `Hex`, with a `GridMetric` (Manhattan or Chebyshev) choosing
diamonds vs. squares.

```csharp
using BeeneticToolkit.Spatial;

var c = new GridCoord(2, 3);
var four  = c.Neighbors();      // 4 orthogonal
var eight = c.Neighbors8();     // + diagonals
int d = c.ManhattanDistanceTo(new GridCoord(6, 0));

var diamond = c.Range(3, GridMetric.Manhattan);   // diamond-shaped area
var square  = c.Ring(3, GridMetric.Chebyshev);    // square border
var beam    = GridCoord.Line(c, new GridCoord(9, 5));  // Bresenham line
```

## Pathfinding

An abstract graph (`IGraph` / `IWeightedGraph`) drives the search, so the algorithms are grid-agnostic. Built-in
`GridGraph` (square, 4/8-way, per-cell passability and cost, corner-cutting policy) and `HexGraph` adapters are
included. The cost-aware searches reuse `BeeneticToolkit.Collections.PriorityQueue`.

```csharp
using BeeneticToolkit.Spatial;
using BeeneticToolkit.Spatial.Pathfinding;

var grid = new GridGraph(width, height, GridConnectivity.EightWay,
    isPassable: cell => !walls.Contains(cell));

PathResult<GridCoord> path = Pathfinder.AStar(grid, start, goal, grid.Heuristic);
if (path.Found)
    foreach (GridCoord step in path.Nodes) { /* ... */ }

// Also: Pathfinder.Dijkstra (weighted) and Pathfinder.BreadthFirstSearch (unweighted).

// Many agents, one destination: solve once, route everyone for free.
FlowField<GridCoord> field = FlowField<GridCoord>.Compute(grid, new[] { goal });
if (field.TryGetNext(here, out GridCoord next)) { /* step toward goal */ }
```

The same algorithms work on hexes via `HexGraph`:

```csharp
var hexGraph = new HexGraph(isPassable: h => !blocked.Contains(h));
var hexPath  = Pathfinder.AStar(hexGraph, new Hex(0, 0), new Hex(5, -2), hexGraph.Heuristic);
```

## Field of view

`GridFieldOfView` uses recursive shadowcasting (circular and symmetric); `HexFieldOfView` uses per-hex line of
sight. The viewer is always visible, and a wall is visible but blocks whatever is behind it.

```csharp
using BeeneticToolkit.Spatial;
using BeeneticToolkit.Spatial.Visibility;

HashSet<GridCoord> visible = GridFieldOfView.Compute(viewer, radius, cell => walls.Contains(cell));
HashSet<Hex> hexVisible    = HexFieldOfView.Compute(origin, radius, h => blocked.Contains(h));
```

## Spatial partitioning

Fast 2D proximity queries over points. `Quadtree` adapts to clustered data; `SpatialHash` is an unbounded uniform
grid that suits many similarly-sized moving entities (and supports cheap `Remove`). Both answer rectangle, radius,
and nearest-neighbor queries, and offer allocation-free callback overloads.

```csharp
using BeeneticToolkit.Spatial.Partitioning;

var tree = new Quadtree<Enemy>(new Aabb(0f, 0f, 1000f, 1000f));
tree.Insert((enemy.X, enemy.Y), enemy);

List<Enemy> inRange  = tree.QueryRadius((px, py), 50f);
List<Enemy> inBox    = tree.Query(new Aabb(0f, 0f, 100f, 100f));
List<Enemy> nearest5 = tree.Nearest((px, py), 5);     // closest-first

// Uniform grid alternative with O(1)-ish updates:
var hash = new SpatialHash<Enemy>(cellSize: 32f);
hash.Insert((enemy.X, enemy.Y), enemy);
hash.Remove((enemy.X, enemy.Y), enemy);
hash.TryNearest((px, py), out Enemy closest);
```

## Why no `Vector2`?

There is no universal 2D vector type shared by Unity, MonoGame, and plain .NET, so binding to one would tie this
package to a single engine. Instead, discrete grid positions are their own integer structs (`Hex`, `GridCoord`)
and continuous positions are `(float X, float Y)` tuples — a couple of trivial conversions at the boundary keep
the whole library portable.

## License

Licensed under the MIT License.
