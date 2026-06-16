# BeeneticToolkit.Numerics

[![NuGet](https://img.shields.io/nuget/v/BeeneticToolkit.Numerics.svg)](https://www.nuget.org/packages/BeeneticToolkit.Numerics) [![Downloads](https://img.shields.io/nuget/dt/BeeneticToolkit.Numerics.svg)](https://www.nuget.org/packages/BeeneticToolkit.Numerics) [![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](../../../LICENSE.txt)

Small, allocation-free numeric helpers — a `Mathf`-style companion for plain .NET (and Unity).

Targets `netstandard2.1`. Most methods come in `float`/`double` (and `decimal` where it makes sense).

## Install

```sh
dotnet add package BeeneticToolkit.Numerics
```

## Highlights

Everything lives on one discoverable type, **`MathKit`** — like Unity's `Mathf` or .NET's `Math`, but for
this toolkit. Type `MathKit.` and browse.

```csharp
using BeeneticToolkit.Numerics;

// Interpolation
float y  = MathKit.Lerp(0, 100, t);              // clamped to [0,1]
float ye = MathKit.SmoothStep(0, 100, t);        // Hermite easing
float yx = MathKit.LerpUnclamped(0, 100, 1.5f);  // extrapolates

// Remap a value from one range to another (e.g. raw reading -> percentage)
float pct = MathKit.Remap(reading, 0, 1023, 0, 100);

// Splines: cubic Bezier (Cerp) and Catmull-Rom (passes through its control points)
float b = MathKit.Cerp(p0, p1, p2, p3, t);        // 4-point cubic Bezier
float s = MathKit.CatmullRom(p0, p1, p2, p3, t);  // smooth path through p1..p2

// Normalize / clamp
float hp01 = MathKit.Normalize(hp, 0, maxHp);    // -> [0, 1]
float c    = MathKit.Clamp01(value);

// Angles
float radians = MathKit.ToRadians(90f);
float wrapped = MathKit.WrapDegrees(370f);              // -> 10
float turn    = MathKit.DeltaAngleDegrees(350f, 10f);  // -> 20 (shortest signed turn across the seam)
float facing  = MathKit.LerpAngleDegrees(350f, 10f, t);        // interpolates the short way
float step    = MathKit.MoveTowardsAngleDegrees(350f, 10f, 5f);// turn ≤5° toward target

// Move a value toward a target at constant speed (no overshoot)
float meter = MathKit.MoveTowards(current, target, maxDelta);

// Smoothing & cycling
float ss   = MathKit.SmootherStep(0, 1, t);           // Perlin's gentler ease
float gate = MathKit.Step(0.5f, x);                   // hard threshold: 0 or 1
float ping = MathKit.PingPong(time, 3f);              // bounces 0..3..0
float cam  = MathKit.SmoothDamp(current, target, ref velocity, smoothTime, deltaTime); // spring follow

// Easing curves (also surfaced as MathKit.Ease)
float eased = MathKit.Ease(EasingType.OutBack, a, b, t);

// Magnitude-aware float comparison (absolute comparison fails for large values)
bool equal = MathKit.IsApproximatelyRelative(1e9, 1e9 + 50, 1e-6); // true
```

> **Tip:** these methods are overloaded for `float`, `double`, and `decimal`, so a call whose
> arguments are *all* untyped integer literals is ambiguous (e.g. `Remap(30, 0, 100, 0, 1)` won't
> compile). Use typed literals — `Remap(30f, 0f, 100f, 0f, 1f)`, `30.0`, or `30m` — or pass at least
> one typed argument so the compiler can pick an overload.

## Easing

The standard (Penner) easing curves for tweening and animation — Sine, Quad, Cubic, Quart, Quint, Expo,
Circ, Back, Elastic, and Bounce, each in `In` / `Out` / `InOut`. Every curve maps `t` in `[0, 1]` to eased
progress; combine with a lerp, or pick a curve at runtime with the `Ease` dispatcher.

```csharp
using BeeneticToolkit.Numerics;

float p = EasingUtils.OutCubic(t);                       // eased progress
float x = EasingUtils.Ease(EasingType.OutBack, a, b, t); // tween a→b (OutBack overshoots past b)

// Data-driven: store the curve choice and resolve it later.
EasingType curve = config.Curve;
float eased = EasingUtils.Ease(curve, t);
```

Provided for `float` and `double`. `Back` and `Elastic` intentionally overshoot outside `[0, 1]`. The named
curves live on `EasingUtils`; `MathKit.Ease(EasingType, …)` is the discoverable shortcut.

`MathKit` also includes `RoundToNearest` and floored `Wrap`. Integral mapping is a separate set of
extension methods (`IntegralMappingExtensions`), since those read fluently on the value itself.

## License

Licensed under the MIT License.
