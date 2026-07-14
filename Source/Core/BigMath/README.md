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

Notation/formatting and parsing are documented alongside the `INotation` types.
