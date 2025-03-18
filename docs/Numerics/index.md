#### [Numerics](index.md 'index')

## Numerics Assembly
### Namespaces

<a name='BeeneticToolkit.Numerics'></a>

## BeeneticToolkit.Numerics Namespace

The [BeeneticToolkit.Numerics](index.md#BeeneticToolkit.Numerics 'BeeneticToolkit.Numerics') namespace provides utility classes for performing  
various mathematical operations, including numerical transformations, interpolation, angle conversions,  
and rounding.
- **[AngleUtils](AngleUtils.md 'BeeneticToolkit.Numerics.AngleUtils')** `Class` Provides methods for angle conversions between degrees and radians.
  - **[ToDegrees(decimal)](AngleUtils.ToDegrees(decimal).md 'BeeneticToolkit.Numerics.AngleUtils.ToDegrees(decimal)')** `Method` Converts radians to degrees.
  - **[ToDegrees(double)](AngleUtils.ToDegrees(double).md 'BeeneticToolkit.Numerics.AngleUtils.ToDegrees(double)')** `Method` Converts radians to degrees.
  - **[ToDegrees(float)](AngleUtils.ToDegrees(float).md 'BeeneticToolkit.Numerics.AngleUtils.ToDegrees(float)')** `Method` Converts radians to degrees.
  - **[ToRadians(decimal)](AngleUtils.ToRadians(decimal).md 'BeeneticToolkit.Numerics.AngleUtils.ToRadians(decimal)')** `Method` Converts degrees to radians.
  - **[ToRadians(double)](AngleUtils.ToRadians(double).md 'BeeneticToolkit.Numerics.AngleUtils.ToRadians(double)')** `Method` Converts degrees to radians.
  - **[ToRadians(float)](AngleUtils.ToRadians(float).md 'BeeneticToolkit.Numerics.AngleUtils.ToRadians(float)')** `Method` Converts degrees to radians.
- **[InterpolationUtils](InterpolationUtils.md 'BeeneticToolkit.Numerics.InterpolationUtils')** `Class` Provides methods for interpolation, including linear interpolation (Lerp) and quadratic Bezier interpolation (Qerp).
  - **[InverseLerp(decimal, decimal, decimal)](InterpolationUtils.InverseLerp(decimal,decimal,decimal).md 'BeeneticToolkit.Numerics.InterpolationUtils.InverseLerp(decimal, decimal, decimal)')** `Method` Calculates the inverse linear interpolation factor between two values.
  - **[InverseLerp(double, double, double)](InterpolationUtils.InverseLerp(double,double,double).md 'BeeneticToolkit.Numerics.InterpolationUtils.InverseLerp(double, double, double)')** `Method` Calculates the inverse linear interpolation factor between two values.
  - **[InverseLerp(float, float, float)](InterpolationUtils.InverseLerp(float,float,float).md 'BeeneticToolkit.Numerics.InterpolationUtils.InverseLerp(float, float, float)')** `Method` Calculates the inverse linear interpolation factor between two values.
  - **[Lerp(decimal, decimal, decimal)](InterpolationUtils.Lerp(decimal,decimal,decimal).md 'BeeneticToolkit.Numerics.InterpolationUtils.Lerp(decimal, decimal, decimal)')** `Method` Performs linear interpolation between two decimal values based on a given interpolation factor.
  - **[Lerp(double, double, double)](InterpolationUtils.Lerp(double,double,double).md 'BeeneticToolkit.Numerics.InterpolationUtils.Lerp(double, double, double)')** `Method` Performs linear interpolation between two double values based on a given interpolation factor.
  - **[Lerp(float, float, float)](InterpolationUtils.Lerp(float,float,float).md 'BeeneticToolkit.Numerics.InterpolationUtils.Lerp(float, float, float)')** `Method` Performs linear interpolation between two float values based on a given interpolation factor.
  - **[Qerp(decimal, decimal, decimal, decimal)](InterpolationUtils.Qerp(decimal,decimal,decimal,decimal).md 'BeeneticToolkit.Numerics.InterpolationUtils.Qerp(decimal, decimal, decimal, decimal)')** `Method` Performs quadratic Bezier interpolation between two values, influenced by a control point.
  - **[Qerp(double, double, double, double)](InterpolationUtils.Qerp(double,double,double,double).md 'BeeneticToolkit.Numerics.InterpolationUtils.Qerp(double, double, double, double)')** `Method` Performs quadratic Bezier interpolation between two values, influenced by a control point.
  - **[Qerp(float, float, float, float)](InterpolationUtils.Qerp(float,float,float,float).md 'BeeneticToolkit.Numerics.InterpolationUtils.Qerp(float, float, float, float)')** `Method` Performs quadratic Bezier interpolation between two values, influenced by a control point.
- **[NumericalUtils](NumericalUtils.md 'BeeneticToolkit.Numerics.NumericalUtils')** `Class` Provides utility methods for common numerical operations, including clamping, normalization, and approximate comparisons.
  - **[Clamp01(decimal)](NumericalUtils.Clamp01(decimal).md 'BeeneticToolkit.Numerics.NumericalUtils.Clamp01(decimal)')** `Method` Clamps a decimal value to ensure it falls within the range of 0 to 1.
  - **[Clamp01(double)](NumericalUtils.Clamp01(double).md 'BeeneticToolkit.Numerics.NumericalUtils.Clamp01(double)')** `Method` Clamps a double value to ensure it falls within the range of 0 to 1.
  - **[Clamp01(float)](NumericalUtils.Clamp01(float).md 'BeeneticToolkit.Numerics.NumericalUtils.Clamp01(float)')** `Method` Clamps a float value to ensure it falls within the range of 0 to 1.
  - **[Denormalize(decimal, decimal, decimal)](NumericalUtils.Denormalize(decimal,decimal,decimal).md 'BeeneticToolkit.Numerics.NumericalUtils.Denormalize(decimal, decimal, decimal)')** `Method` Converts a normalized decimal value (0 to 1) back to its original range.
  - **[Denormalize(double, double, double)](NumericalUtils.Denormalize(double,double,double).md 'BeeneticToolkit.Numerics.NumericalUtils.Denormalize(double, double, double)')** `Method` Converts a normalized double value (0 to 1) back to its original range.
  - **[Denormalize(float, float, float)](NumericalUtils.Denormalize(float,float,float).md 'BeeneticToolkit.Numerics.NumericalUtils.Denormalize(float, float, float)')** `Method` Converts a normalized float value (0 to 1) back to its original range.
  - **[IsApproximately(decimal, decimal, decimal)](NumericalUtils.IsApproximately(decimal,decimal,decimal).md 'BeeneticToolkit.Numerics.NumericalUtils.IsApproximately(decimal, decimal, decimal)')** `Method` Determines if two decimal values are approximately equal within a tolerance.
  - **[IsApproximately(double, double, double)](NumericalUtils.IsApproximately(double,double,double).md 'BeeneticToolkit.Numerics.NumericalUtils.IsApproximately(double, double, double)')** `Method` Determines if two double values are approximately equal within a tolerance.
  - **[IsApproximately(float, float, float)](NumericalUtils.IsApproximately(float,float,float).md 'BeeneticToolkit.Numerics.NumericalUtils.IsApproximately(float, float, float)')** `Method` Determines if two float values are approximately equal within a tolerance.
  - **[Normalize(decimal, decimal, decimal)](NumericalUtils.Normalize(decimal,decimal,decimal).md 'BeeneticToolkit.Numerics.NumericalUtils.Normalize(decimal, decimal, decimal)')** `Method` Normalizes a decimal value to a range defined by a minimum and maximum.
  - **[Normalize(double, double, double)](NumericalUtils.Normalize(double,double,double).md 'BeeneticToolkit.Numerics.NumericalUtils.Normalize(double, double, double)')** `Method` Normalizes a double value to a range defined by a minimum and maximum.
  - **[Normalize(float, float, float)](NumericalUtils.Normalize(float,float,float).md 'BeeneticToolkit.Numerics.NumericalUtils.Normalize(float, float, float)')** `Method` Normalizes a float value to a range defined by a minimum and maximum.
- **[RoundingUtils](RoundingUtils.md 'BeeneticToolkit.Numerics.RoundingUtils')** `Class` Provides methods for rounding values, including rounding to the nearest interval and wrapping values within a range.
  - **[RoundToNearest(decimal, decimal)](RoundingUtils.RoundToNearest(decimal,decimal).md 'BeeneticToolkit.Numerics.RoundingUtils.RoundToNearest(decimal, decimal)')** `Method` Rounds a value to the nearest specified interval.
  - **[RoundToNearest(double, double)](RoundingUtils.RoundToNearest(double,double).md 'BeeneticToolkit.Numerics.RoundingUtils.RoundToNearest(double, double)')** `Method` Rounds a value to the nearest specified interval.
  - **[RoundToNearest(float, float)](RoundingUtils.RoundToNearest(float,float).md 'BeeneticToolkit.Numerics.RoundingUtils.RoundToNearest(float, float)')** `Method` Rounds a value to the nearest specified interval.
  - **[Wrap(decimal, decimal, decimal)](RoundingUtils.Wrap(decimal,decimal,decimal).md 'BeeneticToolkit.Numerics.RoundingUtils.Wrap(decimal, decimal, decimal)')** `Method` Wraps a value within a specified range.
  - **[Wrap(double, double, double)](RoundingUtils.Wrap(double,double,double).md 'BeeneticToolkit.Numerics.RoundingUtils.Wrap(double, double, double)')** `Method` Wraps a value within a specified range.
  - **[Wrap(float, float, float)](RoundingUtils.Wrap(float,float,float).md 'BeeneticToolkit.Numerics.RoundingUtils.Wrap(float, float, float)')** `Method` Wraps a value within a specified range.