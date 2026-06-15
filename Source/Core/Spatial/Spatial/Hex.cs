using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Spatial {

    /// <summary>
    /// A hexagon on a hex grid, stored in <b>axial</b> coordinates (<see cref="Q"/>, <see cref="R"/>) with the
    /// third <b>cube</b> coordinate <see cref="S"/> derived (<c>S = -Q - R</c>). Axial is compact for storage;
    /// the cube view drives the algorithms (distance, rounding, rotation). Immutable value type.
    /// </summary>
    /// <remarks>
    /// Coordinate conventions follow the Red Blob Games hex grid guide. Pair with <see cref="HexLayout"/> to
    /// convert to and from pixel/world space, and <see cref="OffsetCoord"/> for rectangular storage.
    /// </remarks>
    public readonly struct Hex : IEquatable<Hex> {

        /// <summary>The axial Q coordinate (cube X).</summary>
        public int Q { get; }

        /// <summary>The axial R coordinate (cube Z).</summary>
        public int R { get; }

        /// <summary>The derived cube S coordinate (<c>-Q - R</c>; cube Y).</summary>
        public int S => -Q - R;

        /// <summary>Creates a hex from axial coordinates.</summary>
        public Hex(int q, int r) {
            Q = q;
            R = r;
        }

        /// <summary>Creates a hex from cube coordinates, validating the <c>x + y + z == 0</c> constraint.</summary>
        /// <exception cref="ArgumentException">Thrown when <paramref name="x"/> + <paramref name="y"/> + <paramref name="z"/> is not zero.</exception>
        public static Hex FromCube(int x, int y, int z) {
            if (x + y + z != 0)
                throw new ArgumentException("Cube coordinates must sum to zero.");

            return new Hex(x, z);
        }

        #region Arithmetic

        /// <summary>Adds two hexes component-wise.</summary>
        public static Hex operator +(Hex a, Hex b) => new Hex(a.Q + b.Q, a.R + b.R);

        /// <summary>Subtracts two hexes component-wise.</summary>
        public static Hex operator -(Hex a, Hex b) => new Hex(a.Q - b.Q, a.R - b.R);

        /// <summary>Scales a hex by an integer factor.</summary>
        public static Hex operator *(Hex a, int k) => new Hex(a.Q * k, a.R * k);

        #endregion Arithmetic

        #region Distance

        /// <summary>Gets the distance from the origin, in hex steps.</summary>
        public int Length => (Math.Abs(Q) + Math.Abs(R) + Math.Abs(S)) / 2;

        /// <summary>Returns the hex-grid distance between two hexes (number of steps).</summary>
        public static int Distance(Hex a, Hex b) => (a - b).Length;

        /// <summary>Returns the hex-grid distance from this hex to <paramref name="other"/>.</summary>
        public int DistanceTo(Hex other) => Distance(this, other);

        #endregion Distance

        #region Neighbors

        /// <summary>The six axial direction vectors, ordered counterclockwise starting from "east".</summary>
        public static readonly IReadOnlyList<Hex> Directions = new[] {
            new Hex(1, 0), new Hex(1, -1), new Hex(0, -1),
            new Hex(-1, 0), new Hex(-1, 1), new Hex(0, 1),
        };

        /// <summary>The six diagonal direction vectors.</summary>
        public static readonly IReadOnlyList<Hex> Diagonals = new[] {
            new Hex(2, -1), new Hex(1, -2), new Hex(-1, -1),
            new Hex(-2, 1), new Hex(-1, 2), new Hex(1, 1),
        };

        /// <summary>Gets a unit direction vector by index (wraps modulo 6, supports negatives).</summary>
        public static Hex Direction(int index) => Directions[((index % 6) + 6) % 6];

        /// <summary>Returns the adjacent hex in the given direction (0–5, wraps).</summary>
        public Hex Neighbor(int direction) => this + Direction(direction);

        /// <summary>Returns the diagonally adjacent hex in the given direction (0–5, wraps).</summary>
        public Hex DiagonalNeighbor(int direction) => this + Diagonals[((direction % 6) + 6) % 6];

        /// <summary>Returns the six adjacent hexes, in direction order.</summary>
        public Hex[] Neighbors() {
            var result = new Hex[6];
            for (int i = 0; i < 6; i++)
                result[i] = Neighbor(i);
            return result;
        }

        #endregion Neighbors

        #region Rotation

        /// <summary>Rotates this hex 60° counterclockwise around the origin.</summary>
        public Hex RotateLeft() => FromCube(-S, -R, -Q);

        /// <summary>Rotates this hex 60° clockwise around the origin.</summary>
        public Hex RotateRight() => FromCube(-R, -Q, -S);

        /// <summary>Rotates this hex 60° counterclockwise around <paramref name="center"/>.</summary>
        public Hex RotateLeft(Hex center) => (this - center).RotateLeft() + center;

        /// <summary>Rotates this hex 60° clockwise around <paramref name="center"/>.</summary>
        public Hex RotateRight(Hex center) => (this - center).RotateRight() + center;

        #endregion Rotation

        #region Shapes

        /// <summary>Returns every hex within <paramref name="radius"/> steps of this hex (inclusive), this hex first by ring.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="radius"/> is negative.</exception>
        public List<Hex> Range(int radius) {
            if (radius < 0)
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be non-negative.");

            var results = new List<Hex>();
            for (int q = -radius; q <= radius; q++) {
                int rMin = Math.Max(-radius, -q - radius);
                int rMax = Math.Min(radius, -q + radius);
                for (int r = rMin; r <= rMax; r++)
                    results.Add(this + new Hex(q, r));
            }

            return results;
        }

        /// <summary>Returns the hexes forming the ring at exactly <paramref name="radius"/> steps from this hex.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="radius"/> is negative.</exception>
        public List<Hex> Ring(int radius) {
            if (radius < 0)
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be non-negative.");

            var results = new List<Hex>();
            if (radius == 0) {
                results.Add(this);
                return results;
            }

            Hex hex = this + Direction(4) * radius;
            for (int side = 0; side < 6; side++) {
                for (int step = 0; step < radius; step++) {
                    results.Add(hex);
                    hex = hex.Neighbor(side);
                }
            }

            return results;
        }

        /// <summary>Returns the hexes from this hex outward to <paramref name="radius"/>, ring by ring (a filled spiral).</summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="radius"/> is negative.</exception>
        public List<Hex> Spiral(int radius) {
            if (radius < 0)
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be non-negative.");

            var results = new List<Hex> { this };
            for (int k = 1; k <= radius; k++)
                results.AddRange(Ring(k));

            return results;
        }

        /// <summary>Returns the hexes on the straight line between two hexes (inclusive of both endpoints).</summary>
        public static List<Hex> Line(Hex a, Hex b) {
            int n = Distance(a, b);
            var results = new List<Hex>(n + 1);

            // Nudge the endpoints off exact edges so the rounding never wavers between two equidistant hexes.
            var aNudge = new FractionalHex(a.Q + 1e-6, a.R + 1e-6);
            var bNudge = new FractionalHex(b.Q + 1e-6, b.R + 1e-6);

            double step = n == 0 ? 0.0 : 1.0 / n;
            for (int i = 0; i <= n; i++)
                results.Add(FractionalHex.Lerp(aNudge, bNudge, step * i).Round());

            return results;
        }

        #endregion Shapes

        #region Equality

        /// <inheritdoc/>
        public bool Equals(Hex other) => Q == other.Q && R == other.R;

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is Hex other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => unchecked((Q * 397) ^ R);

        /// <summary>Determines whether two hexes are equal.</summary>
        public static bool operator ==(Hex a, Hex b) => a.Equals(b);

        /// <summary>Determines whether two hexes are not equal.</summary>
        public static bool operator !=(Hex a, Hex b) => !a.Equals(b);

        /// <summary>Returns the axial coordinates as <c>"(q, r)"</c>.</summary>
        public override string ToString() => $"({Q}, {R})";

        #endregion Equality
    }
}
