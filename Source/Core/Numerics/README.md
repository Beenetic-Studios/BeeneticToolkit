# BeeneticToolkit.Numerics

Small, allocation-free numeric helpers — a `Mathf`-style companion for plain .NET (and Unity).

Targets `netstandard2.1`. Most methods come in `float`/`double` (and `decimal` where it makes sense).

## Install

```sh
dotnet add package BeeneticToolkit.Numerics
```

## Highlights

```csharp
using BeeneticToolkit.Numerics;

// Interpolation
float y  = InterpolationUtils.Lerp(0, 100, t);              // clamped to [0,1]
float ye = InterpolationUtils.SmoothStep(0, 100, t);        // Hermite easing
float yx = InterpolationUtils.LerpUnclamped(0, 100, 1.5f);  // extrapolates

// Remap a value from one range to another (e.g. raw reading -> percentage)
float pct = InterpolationUtils.Remap(reading, 0, 1023, 0, 100);

// Normalize / clamp
float hp01 = NumericalUtils.Normalize(hp, 0, maxHp);        // -> [0, 1]
float c    = NumericalUtils.Clamp01(value);

// Angles
float radians = AngleUtils.ToRadians(90f);
float wrapped = AngleUtils.WrapDegrees(370f);              // -> 10

// Magnitude-aware float comparison (absolute comparison fails for large values)
bool equal = NumericalUtils.IsApproximatelyRelative(1e9, 1e9 + 50, 1e-6); // true
```

> **Tip:** these methods are overloaded for `float`, `double`, and `decimal`, so a call whose
> arguments are *all* untyped integer literals is ambiguous (e.g. `Remap(30, 0, 100, 0, 1)` won't
> compile). Use typed literals — `Remap(30f, 0f, 100f, 0f, 1f)`, `30.0`, or `30m` — or pass at least
> one typed argument so the compiler can pick an overload.

Also includes `RoundingUtils` (`RoundToNearest`, floored `Wrap`) and
`IntegralMappingExtensions` for signed/unsigned integral mapping.

## License

Licensed under the MIT License.
