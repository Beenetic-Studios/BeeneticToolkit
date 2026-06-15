# BeeneticToolkit.Random

Deterministic, seedable pseudo-random generation for games and simulations.

`System.Random` gives you one algorithm and no reproducibility guarantees. `BeeneticToolkit.Random` adds:

- **Seedable, swappable algorithms** — xoshiro256\*\* (default), Xorshift, Combined LCG, Middle-Square-Weyl.
- **Reproducible environments** — group named generators under a single root seed so an entire run replays from one number.
- **Rich selection helpers** — weighted choice, random subsets, exclusions, shuffles, and random enum values.

> Not cryptographically secure — designed for game logic, procedural generation, and simulations. Targets `netstandard2.1` (modern .NET and Unity).

## Install

```sh
dotnet add package BeeneticToolkit.Random
```

## Quick start

Generators come from **environments** — the seedable unit. Create one, register a generator on it, and draw:

```csharp
using BeeneticToolkit.Random;

var env = new RandomEnvironment("game", rootSeed: 12345);
var rng = env.CreateAndRegister("main");

int roll    = rng.NextInt(1, 7);            // [1, 7)
double unit = rng.NextDouble();             // [0, 1)
bool crit   = rng.NextBool(0.05f);          // 5% chance of true
var dir     = rng.NextEnum<Direction>();    // a random value of your enum
Guid id     = rng.NextGuid();
```

Just need a number and don't care about reproducibility? Use the shared scratch generator:

```csharp
int n = RandomManager.Scratch.NextInt(100);   // entropy-seeded, not reproducible
```

## Reproducible environments

Group related generators under one root seed. Each generator's seed is derived from the root
and its key, so every stream is independent yet the whole environment replays from a single number:

```csharp
var world = new RandomEnvironment("world", rootSeed: 2024);
var terrain = world.CreateAndRegister("terrain");
var loot    = world.CreateAndRegister("loot");    // distinct stream, also reproducible
```

An environment **always** has a `RootSeed`. If you don't supply one, a high-entropy seed is generated
and recorded — so even an unseeded run can be reproduced after the fact:

```csharp
var run = new RandomEnvironment("run");           // auto-seeded
long seed = run.RootSeed;                          // capture it to replay this exact run later
```

Use `RandomKey` constants instead of raw strings for compile-time safety against typos. Pick a default
algorithm per environment, or override per generator:

```csharp
var env = new RandomEnvironment("sim", rootSeed: 7, algorithm: RandomAlgorithm.CombinedLCG);
var fast = env.CreateAndRegister("fast", algorithm: RandomAlgorithm.Xorshift);
```

### Process-wide access

The global `RandomManager` is a registry of named environments:

```csharp
var enemies = RandomManager.CreateEnvironment("enemies", rootSeed: 99);
enemies.CreateAndRegister("spawns");

var sameEnv = RandomManager.GetEnvironment("enemies");
var spawnRng = sameEnv.Get("spawns");
```

## Selection helpers

The selection and shuffle helpers are **extension methods on the generator**, so the source of
randomness is always explicit:

```csharp
var loot = new[] { "common", "rare", "epic" };
string pick = rng.RandomChoice(loot);

// Weighted — "common" is chosen ~90% of the time.
string weighted = rng.RandomWeightedChoice(
    new[] { ("common", 9.0), ("rare", 1.0) });

// Shuffle returns a new list; ShuffleInPlace mutates in place.
var deck = Enumerable.Range(1, 52).ToList();
List<int> shuffled = rng.Shuffle(deck);
rng.ShuffleInPlace(deck);

// Non-throwing Try* variants are available for all selectors.
if (rng.TryRandomChoice(loot, out string chosen)) { /* ... */ }
```

## Thread safety

Generators are **not** thread-safe — each draw advances mutable state. For concurrent work, give each
thread its own generator from an environment (`env.CreateAndRegister(perThreadKey)`); because their seeds
derive from the shared root, that is both thread-safe *and* reproducible. `RandomManager.Scratch` is
likewise single-threaded by contract.

## License

Licensed under the MIT License.
