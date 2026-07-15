# BeeneticToolkit.BigMath

Large-number math for incremental/idle games and long-running simulations. `BigDouble` is a value type that
stores a normalized mantissa times a power of ten (`Mantissa × 10^Exponent`), so it shrugs off `double`'s
~1.8e308 ceiling while staying fast and allocation-free.

```csharp
using BeeneticToolkit.BigMath;

BigDouble gold   = 1_000_000;          // implicit from int/long/double
BigDouble income = BigDouble.Pow10(42) * 3.5;

BigDouble total  = gold + income;      // full arithmetic: + - * /
BigDouble cost   = new BigDouble(1.5, 30) * total.Pow(1.15);  // geometric cost curves

bool canAfford   = total >= cost;      // full comparison + equality
double howMany   = total.Log10();      // logs return a plain double
```

## Why a big-number type?

Idle/incremental games routinely blow past `double` and need to display values like `1.50M`, `3.24B`, or
`9.99e1234`. `BigDouble` gives you exact-order-of-magnitude arithmetic far beyond that, plus a pluggable
notation system for display and round-trippable parsing of saved values.

## Representation

`BigDouble` keeps a `double` mantissa (`0`, or `1 <= |Mantissa| < 10`) and a `double` exponent that is capped
at `±9e15` (`BigDouble.ExponentLimit`, just under 2^53) so it is always an **exact** integer. This matches the
representation used by `break_infinity.js`; exponent arithmetic saturates to infinity instead of wrapping.
Tetration-scale magnitudes (10↑↑n) are intentionally out of scope.

## Highlights

- Arithmetic (`+ - * /`, unary `-`), with an addition short-circuit for negligible operands.
- Powers, roots, and logs: `Pow`, `Sqrt`, `Root`, `Log10`, `Ln`, `Log`, `Pow10`, `Exp`.
- Full comparison/equality plus `EqualsApproximately` for tolerant checks.
- IEEE-style edge cases: `NaN`, `±Infinity`, saturating overflow — defined, not thrown.
- Multi-targets `netstandard2.1` and `net8.0`; deterministic and Unity-friendly.

## Display notation

Formatting is pluggable via `INotation`. Pick a preset per call, or pass one wherever you render:

```csharp
var value = new BigDouble(1.0, 15.0); // 10^15 (a quadrillion)

Notation.Scientific.Format(value, 2);   // "1.00e15"
Notation.Engineering.Format(value, 2);  // "1.00e15" (exponent kept a multiple of 3)
Notation.Standard.Format(value, 2);     // "1.00aa"  (see below)
Notation.ShortScale.Format(value, 2);   // "1.00Qa"  (see below)
```

### Two abbreviated styles — and how to reach each

Both use `K/M/B/T` for thousand through trillion. They diverge at quadrillion (10^15) and up:

| Preset | 10^15 | 10^18 | 10^33 | 10^36 | Style |
|---|---|---|---|---|---|
| `Notation.Standard` **(default)** | `1.00aa` | `1.00ab` | `1.00ag` | `1.00ah` | Alphabetic `aa, ab … zz, aaa …` (compact, unbounded) |
| `Notation.ShortScale` | `1.00Qa` | `1.00Qi` | `1.00Dc` | `1.00UDc` | Short-scale names `Qa, Qi, Sx, Sp, Oc, No, Dc, UDc …` (the convention most idle games show) |

`BigDouble.ToString()` (and the `"A"`/`"D"` format specifiers) use `Notation.Standard` — the **alphabetic** style
is the default and is unchanged. Short-scale names are **opt-in**: reach them via the `Notation.ShortScale` preset,
or pass `new StandardNotation(ShortScaleSuffixProvider.Instance)` where you need it.

```csharp
// App-wide: format with the short-scale preset instead of ToString().
string label = Notation.ShortScale.Format(playerGold, 2); // e.g. "3.72Dc"
```

`ShortScaleSuffixProvider` composes names algorithmically past decillion (`UDc, DDc, … Vg, Tg, … Ce`) up to
millinillion, then defers to the alphabetic set. To stop naming at decillion and let larger tiers fall back to
`aa/ab`, cap it: `new ShortScaleSuffixProvider(maxNamedTier: 11)`. Supply your own `ISuffixProvider` for
custom flavor (see `StandardNotation`). `MixedScientificNotation` switches to scientific above a chosen exponent.

Parsing round-trips saved values and is documented alongside `BigDouble.Parse`/`TryParse`.
