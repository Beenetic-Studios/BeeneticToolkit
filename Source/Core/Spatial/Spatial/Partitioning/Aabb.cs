using System;

namespace BeeneticToolkit.Spatial.Partitioning {

    /// <summary>
    /// An axis-aligned bounding box in 2D float space, used to describe the region a partitioning structure covers
    /// and the windows you query against it. Points and sizes cross the API as plain <c>(float X, float Y)</c>
    /// tuples so no engine vector type leaks in.
    /// </summary>
    public readonly struct Aabb : IEquatable<Aabb> {

        /// <summary>The minimum (left) X edge.</summary>
        public float MinX { get; }

        /// <summary>The minimum (bottom) Y edge.</summary>
        public float MinY { get; }

        /// <summary>The maximum (right) X edge.</summary>
        public float MaxX { get; }

        /// <summary>The maximum (top) Y edge.</summary>
        public float MaxY { get; }

        /// <summary>Creates a box from its min and max edges.</summary>
        /// <exception cref="ArgumentException">Thrown when a max edge is less than its corresponding min edge.</exception>
        public Aabb(float minX, float minY, float maxX, float maxY) {
            if (maxX < minX)
                throw new ArgumentException("maxX must be greater than or equal to minX.", nameof(maxX));
            if (maxY < minY)
                throw new ArgumentException("maxY must be greater than or equal to minY.", nameof(maxY));

            MinX = minX;
            MinY = minY;
            MaxX = maxX;
            MaxY = maxY;
        }

        /// <summary>Creates a box from a center point and half-extents along each axis.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when a half-extent is negative.</exception>
        public static Aabb FromCenter((float X, float Y) center, float halfWidth, float halfHeight) {
            if (halfWidth < 0f)
                throw new ArgumentOutOfRangeException(nameof(halfWidth), "Half-extents must be non-negative.");
            if (halfHeight < 0f)
                throw new ArgumentOutOfRangeException(nameof(halfHeight), "Half-extents must be non-negative.");

            return new Aabb(center.X - halfWidth, center.Y - halfHeight, center.X + halfWidth, center.Y + halfHeight);
        }

        /// <summary>The box width (<c>MaxX - MinX</c>).</summary>
        public float Width => MaxX - MinX;

        /// <summary>The box height (<c>MaxY - MinY</c>).</summary>
        public float Height => MaxY - MinY;

        /// <summary>The center point of the box.</summary>
        public (float X, float Y) Center => ((MinX + MaxX) * 0.5f, (MinY + MaxY) * 0.5f);

        /// <summary>Whether the box contains <paramref name="point"/> (edges inclusive).</summary>
        public bool Contains((float X, float Y) point) =>
            point.X >= MinX && point.X <= MaxX && point.Y >= MinY && point.Y <= MaxY;

        /// <summary>Whether this box fully contains <paramref name="other"/>.</summary>
        public bool Contains(Aabb other) =>
            other.MinX >= MinX && other.MaxX <= MaxX && other.MinY >= MinY && other.MaxY <= MaxY;

        /// <summary>Whether this box overlaps <paramref name="other"/> (touching edges count as overlap).</summary>
        public bool Intersects(Aabb other) =>
            MinX <= other.MaxX && MaxX >= other.MinX && MinY <= other.MaxY && MaxY >= other.MinY;

        /// <summary>Whether this box overlaps the circle at <paramref name="center"/> with the given radius.</summary>
        public bool IntersectsCircle((float X, float Y) center, float radius) =>
            SquaredDistanceTo(center) <= radius * radius;

        /// <summary>
        /// The squared Euclidean distance from <paramref name="point"/> to the nearest point on or inside the box
        /// (0 when the point is inside). Squared to avoid the square root; used by nearest-neighbor pruning.
        /// </summary>
        public float SquaredDistanceTo((float X, float Y) point) {
            float dx = point.X - Clamp(point.X, MinX, MaxX);
            float dy = point.Y - Clamp(point.Y, MinY, MaxY);
            return dx * dx + dy * dy;
        }

        private static float Clamp(float value, float min, float max) =>
            value < min ? min : value > max ? max : value;

        /// <inheritdoc/>
        public bool Equals(Aabb other) =>
            MinX == other.MinX && MinY == other.MinY && MaxX == other.MaxX && MaxY == other.MaxY;

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is Aabb other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() {
            unchecked {
                int hash = 17;
                hash = hash * 31 + MinX.GetHashCode();
                hash = hash * 31 + MinY.GetHashCode();
                hash = hash * 31 + MaxX.GetHashCode();
                hash = hash * 31 + MaxY.GetHashCode();
                return hash;
            }
        }

        /// <summary>Returns <c>"[(minX, minY) .. (maxX, maxY)]"</c>.</summary>
        public override string ToString() => $"[({MinX}, {MinY}) .. ({MaxX}, {MaxY})]";
    }
}
