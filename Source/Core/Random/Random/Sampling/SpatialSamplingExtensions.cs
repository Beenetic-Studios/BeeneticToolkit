using System;

namespace BeeneticToolkit.Random.Sampling {

    /// <summary>
    /// Extension methods on <see cref="RandomGenerator"/> for sampling single random directions and points
    /// in 2D/3D shapes. Results are returned as value tuples (no allocation, no engine-specific vector type),
    /// and points inside areas/volumes are uniformly distributed.
    /// </summary>
    public static class SpatialSamplingExtensions {

        private const float Tau = MathF.PI * 2f;

        /// <summary>Returns a random angle in radians, in the range <c>[0, 2π)</c>.</summary>
        /// <param name="random">The generator to draw from.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> is null.</exception>
        public static float NextAngle(this RandomGenerator random) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));

            return random.NextFloat() * Tau;
        }

        /// <summary>Returns a uniformly random 2D unit vector (a point on the unit circle).</summary>
        /// <param name="random">The generator to draw from.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> is null.</exception>
        public static (float X, float Y) NextUnitVector2(this RandomGenerator random) {
            float angle = random.NextAngle();
            return (MathF.Cos(angle), MathF.Sin(angle));
        }

        /// <summary>Returns a uniformly random 3D unit vector (a point on the unit sphere).</summary>
        /// <param name="random">The generator to draw from.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> is null.</exception>
        public static (float X, float Y, float Z) NextUnitVector3(this RandomGenerator random) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));

            // Archimedes' hat-box theorem: a uniform z plus a uniform azimuth gives a uniform sphere.
            float z = random.NextFloat() * 2f - 1f;
            float theta = random.NextFloat() * Tau;
            float r = MathF.Sqrt(MathF.Max(0f, 1f - z * z));
            return (r * MathF.Cos(theta), r * MathF.Sin(theta), z);
        }

        /// <summary>Returns a uniformly random point inside a circle of the given radius, centered at the origin.</summary>
        /// <param name="random">The generator to draw from.</param>
        /// <param name="radius">The circle radius. Must be non-negative.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="radius"/> is negative.</exception>
        public static (float X, float Y) NextPointInCircle(this RandomGenerator random, float radius = 1f) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));
            if (radius < 0f)
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be non-negative.");

            // sqrt makes the radial density uniform by area (otherwise points crowd the center).
            float r = radius * MathF.Sqrt(random.NextFloat());
            float angle = random.NextFloat() * Tau;
            return (r * MathF.Cos(angle), r * MathF.Sin(angle));
        }

        /// <summary>Returns a uniformly random point inside an annulus (ring), centered at the origin.</summary>
        /// <param name="random">The generator to draw from.</param>
        /// <param name="innerRadius">The inner radius. Must be non-negative.</param>
        /// <param name="outerRadius">The outer radius. Must be greater than <paramref name="innerRadius"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the radii are invalid.</exception>
        public static (float X, float Y) NextPointInAnnulus(this RandomGenerator random, float innerRadius, float outerRadius) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));
            if (innerRadius < 0f)
                throw new ArgumentOutOfRangeException(nameof(innerRadius), "Inner radius must be non-negative.");
            if (outerRadius <= innerRadius)
                throw new ArgumentOutOfRangeException(nameof(outerRadius), "Outer radius must be greater than the inner radius.");

            // Area-uniform radius across the ring: r = sqrt(u * (outer^2 - inner^2) + inner^2).
            float r = MathF.Sqrt(random.NextFloat() * (outerRadius * outerRadius - innerRadius * innerRadius) + innerRadius * innerRadius);
            float angle = random.NextFloat() * Tau;
            return (r * MathF.Cos(angle), r * MathF.Sin(angle));
        }

        /// <summary>Returns a uniformly random point inside a sphere of the given radius, centered at the origin.</summary>
        /// <param name="random">The generator to draw from.</param>
        /// <param name="radius">The sphere radius. Must be non-negative.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="random"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="radius"/> is negative.</exception>
        public static (float X, float Y, float Z) NextPointInSphere(this RandomGenerator random, float radius = 1f) {
            if (random == null)
                throw new ArgumentNullException(nameof(random));
            if (radius < 0f)
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be non-negative.");

            (float ux, float uy, float uz) = random.NextUnitVector3();
            // Cube root makes the radial density uniform by volume.
            float r = radius * MathF.Pow(random.NextFloat(), 1f / 3f);
            return (ux * r, uy * r, uz * r);
        }
    }
}
