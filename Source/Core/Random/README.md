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

```csharp
using BeeneticToolkit.Random;

var rng = RandomFactory.GetGenerator();   // xoshiro256**, time-seeded

int roll   = rng.NextInt(1, 7);            // [1, 7)
double unit = rng.NextDouble();            // [0, 1)
bool crit  = rng.NextBool(0.05f);          // 5% chance of true
var dir    = rng.NextEnum<Direction>();    // a random value of your enum
Guid id    = rng.NextGuid();
```

### Reproducible runs

```csharp
var a = RandomFactory.GetGenerator(seed: 12345);
var b = RandomFactory.GetGenerator(seed: 12345);
// a and b now produce identical sequences.
```

### Choose an algorithm

```csharp
var lcg = RandomFactory.GetGenerator(RandomAlgorithm.CombinedLCG, seed: 42);
```

## Selection helpers

```csharp
using BeeneticToolkit.Random.Utilities;

var loot = new[] { "common", "rare", "epic" };
string pick = RandomSelectors.RandomChoice(loot, rng);

// Weighted — "common" is chosen ~90% of the time.
string weighted = RandomSelectors.RandomWeightedChoice(
    new[] { ("common", 9.0), ("rare", 1.0) }, rng);

// Shuffle returns a new list; ShuffleInPlace mutates the source.
var deck = Enumerable.Range(1, 52).ToList();
List<int> shuffled = deck.Shuffle(rng);
deck.ShuffleInPlace(rng);
```

## Reproducible environments

Group related generators under one root seed; each generator's seed is derived from the
root and its key, so the whole environment replays from a single number:

```csharp
var world = new RandomEnvironment("world", rootSeed: 2024);
var terrain = world.CreateAndRegister("terrain");
var loot    = world.CreateAndRegister("loot");   // distinct stream, also reproducible
```

Or use the global manager for shared, process-wide access:

```csharp
RandomManager.Default.CreateAndRegister("enemies");
var enemyRng = RandomManager.Default.Get("enemies");

int n = RandomManager.Current.NextInt(100);      // the default global generator
```

## License

Licensed under the MIT License.
