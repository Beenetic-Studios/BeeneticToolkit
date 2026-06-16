# Sandbox — Spatial Visual Test Harness

An **internal**, throwaway Unity project for *seeing* the `BeeneticToolkit.Spatial` package behave —
hex grids, pathfinding, and partitioning — before it gets published. It is not part of the toolkit build
(it's excluded from `BeeneticToolkit.sln`) and ships nothing.

Everything renders with **gizmos** in the Scene view: no materials, prefabs, lighting, or play mode required.
Use the **2D** toggle in the Scene window for a clean top-down view.

## One-time setup

1. **Create the Unity project** at `Sandbox/SpatialVisualizer`:
   - In Unity Hub → *New project* → 2D (Built-In) → set the location/name so the project folder is
     `Sandbox/SpatialVisualizer`. The provided `Assets/Scripts` and `Assets/Plugins` folders will be picked up.
   - If Hub refuses to target a non-empty folder, create the project elsewhere, then move/merge the generated
     `Library/`, `Packages/`, `ProjectSettings/` into `Sandbox/SpatialVisualizer` (the `Assets/` here already
     has the scripts).
   - Any reasonably recent LTS works (2021.3+); the scripts only use built-in modules. The API compatibility
     level must be **.NET Standard 2.1** (the modern default).
2. **Drop in the toolkit DLLs** — from a terminal at the repo root:
   ```powershell
   ./Sandbox/copy-dlls.ps1
   ```
   This builds `BeeneticToolkit.Spatial` (Release) and copies `Spatial.dll` +
   `BeeneticToolkit.Collections.dll` into `Assets/Plugins/BeeneticToolkit/`. Re-run it after any toolkit change,
   then let Unity reimport.

## Using it

Create an empty GameObject and add one of:

| Component | Shows |
|---|---|
| `HexGridVisualizer` | A pointy/flat hex grid with a highlighted **Range / Ring / Spiral / Line**, coordinate labels, and an optional traversal-order polyline. |
| `GridPathfindingVisualizer` | A square grid with editable blocked cells, the **A\*** path between start and goal, and an optional **flow field** toward the goal. |
| `GridFovVisualizer` | A square grid with a viewer, walls, and the **field of view** (lit vs. shadowed cells) computed by recursive shadowcasting. |
| `PartitioningVisualizer` | Seeded points in a **quadtree**: a box / circle / **nearest-k** query highlighting the hits, plus an optional spatial-hash cell overlay. |

Tweak the Inspector fields and watch the gizmos update live in the Scene view.

## What's committed vs. generated

- **Committed:** `Assets/Scripts/`, this README, `copy-dlls.ps1`, the empty `Directory.Build.props` shield,
  and (once Unity generates them) `.meta` files + `ProjectSettings/`.
- **Gitignored:** `Library/`, `Temp/`, `Obj/`, `Logs/`, generated `*.csproj`/`*.sln`, and the dropped
  `Assets/Plugins/BeeneticToolkit/*.dll` (regenerate via `copy-dlls.ps1`).
