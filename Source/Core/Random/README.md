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

## Coherent noise

Deterministic, cross-platform **value** and **Perlin** noise (2D & 3D) with a fractal/fBm wrapper, in
the `BeeneticToolkit.Random.Noise` namespace. Unlike Unity's `Mathf.PerlinNoise`, it is seedable and
bit-identical across platforms, so procedural content reproduces exactly. Allocation-free scalar sampling.

```csharp
using BeeneticToolkit.Random.Noise;

INoise perlin = NoiseFactory.Create(NoiseAlgorithm.Perlin, seed: 1337);
float v   = perlin.Sample(x, y);       // [-1, 1]
float v01 = perlin.Sample01(x, y);     // [0, 1]
float cave = perlin.Sample(x, y, z);   // 3D

// Fractal Brownian motion — natural-looking terrain/textures:
var terrain = new FractalNoise(perlin, octaves: 5, frequency: 0.01f);
float height = terrain.Sample(worldX, worldY);
```

Seed it from an environment's `RootSeed` to keep noise reproducible alongside the rest of a run:

```csharp
INoise noise = NoiseFactory.Create(NoiseAlgorithm.Perlin, world.RootSeed);
```

## Poisson-disk point sampling

Blue-noise point distributions (`BeeneticToolkit.Random.Sampling`) — random points kept at least a
minimum distance apart, so they scatter evenly with no clumps or gaps. Ideal for placing vegetation,
props, spawns, or decoration; deterministic for a seeded generator.

```csharp
using BeeneticToolkit.Random.Sampling;

// Points at least 4 units apart, filling a 100x100 region:
IReadOnlyList<(float X, float Y)> points =
    PoissonDisk.Sample(rng, width: 100f, height: 100f, minDistance: 4f);

foreach (var (x, y) in points)
    PlaceTree(x, y);
```

## Spatial point sampling

Single random directions and points inside 2D/3D shapes, as extension methods on the generator
(`BeeneticToolkit.Random.Sampling`). Points inside areas and volumes are **uniformly distributed**
(no center-crowding), and results are returned as value tuples — no allocation, no engine-specific
vector type to convert:

```csharp
using BeeneticToolkit.Random.Sampling;

float angle              = rng.NextAngle();                  // [0, 2π)
(float X, float Y) dir   = rng.NextUnitVector2();            // point on the unit circle
var dir3                 = rng.NextUnitVector3();            // point on the unit sphere

var spawn   = rng.NextPointInCircle(radius: 5f);            // uniform inside a disk
var ring    = rng.NextPointInAnnulus(inner: 3f, outer: 5f); // uniform inside a ring
var inBlast = rng.NextPointInSphere(radius: 2f);            // uniform inside a ball
```

## Probability & loot

Game-ready probability building blocks in the `BeeneticToolkit.Random.Probability` namespace. Each takes a
generator at draw time, so everything is reproducible from a seed:

```csharp
using BeeneticToolkit.Random.Probability;

// Weighted bag — draw with replacement, or without (the bag depletes).
var bag = new WeightedBag<string>().Add("common", 9).Add("rare", 1);
string drop   = bag.Draw(rng);                    // bag unchanged
string unique = bag.DrawWithoutReplacement(rng);  // removed from the bag

// Loot table — weighted entries, nestable into tiers.
var rares = new LootTable<string>().Add("epic", 3).Add("legendary", 1);
var chest = new LootTable<string>()
    .Add("gold", 80)
    .AddTable(rares, 20);          // 20% chance to roll the rare sub-table
string loot = chest.Roll(rng);
List<string> haul = chest.Roll(rng, count: 5);

// Dice notation — "NdS±M", parse once or roll inline.
int damage = rng.Roll("2d6+1");
var attack = DiceRoll.Parse("1d20+5");
int hit    = attack.Roll(rng);    // attack.Min .. attack.Max

// Gacha pity — base rate, soft-pity ramp, guaranteed at hard pity.
var pity = new PityCounter(baseChance: 0.006, hardPity: 90, softPityStart: 73, softPityIncrement: 0.06);
bool fiveStar = pity.Roll(rng);   // resets the streak on success
```

## Thread safety

Generators are **not** thread-safe — each draw advances mutable state. For concurrent work, give each
thread its own generator from an environment (`env.CreateAndRegister(perThreadKey)`); because their seeds
derive from the shared root, that is both thread-safe *and* reproducible. `RandomManager.Scratch` is
likewise single-threaded by contract.

## License

Licensed under the MIT License.
