using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Spatial {

    /// <summary>The distance metric used by square-grid <see cref="GridCoord.Range"/> / <see cref="GridCoord.Ring"/> shapes.</summary>
    public enum GridMetric {

        /// <summary>4-way (orthogonal) distance — ranges form diamonds.</summary>
        Manhattan,

        /// <summary>8-way (king-move) distance — ranges form squares.</summary>
        Chebyshev,
    }

    /// <summary>
    /// An integer (X, Y) cell on a square grid — the square-grid counterpart to <see cref="Hex"/>, and the node
    /// type for <see cref="Pathfinding.GridGraph"/> and <see cref="Visibility.GridFieldOfView"/>. World positions
    /// are kept out of this type entirely; convert to your engine's vector at the boundary.
    /// </summary>
    public readonly struct GridCoord : IEquatable<GridCoord> {

        /// <summary>The X coordinate (column).</summary>
        public int X { get; }

        /// <summary>The Y coordinate (row).</summary>
        public int Y { get; }

        /// <summary>Creates a grid coordinate.</summary>
        public GridCoord(int x, int y) {
            X = x;
            Y = y;
        }

        #region Arithmetic

        /// <summary>Adds two coordinates component-wise.</summary>
        public static GridCoord operator +(GridCoord a, GridCoord b) => new GridCoord(a.X + b.X, a.Y + b.Y);

        /// <summary>Subtracts two coordinates component-wise.</summary>
        public static GridCoord operator -(GridCoord a, GridCoord b) => new GridCoord(a.X - b.X, a.Y - b.Y);

        /// <summary>Scales a coordinate by an integer factor.</summary>
        public static GridCoord operator *(GridCoord a, int k) => new GridCoord(a.X * k, a.Y * k);

        #endregion Arithmetic

        #region Distance

        /// <summary>The 4-way (orthogonal) step distance between two cells.</summary>
        public static int Manhattan(GridCoord a, GridCoord b) => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);

        /// <summary>The 8-way (king-move) step distance between two cells.</summary>
        public static int Chebyshev(GridCoord a, GridCoord b) => Math.Max(Math.Abs(a.X - b.X), Math.Abs(a.Y - b.Y));

        /// <summary>The 4-way (orthogonal) step distance from this cell to <paramref name="other"/>.</summary>
        public int ManhattanDistanceTo(GridCoord other) => Manhattan(this, other);

        /// <summary>The 8-way (king-move) step distance from this cell to <paramref name="other"/>.</summary>
        public int ChebyshevDistanceTo(GridCoord other) => Chebyshev(this, other);

        #endregion Distance

        #region Neighbors

        /// <summary>The four orthogonal direction vectors, ordered E, N, W, S.</summary>
        public static readonly IReadOnlyList<GridCoord> Orthogonal = new[] {
            new GridCoord(1, 0), new GridCoord(0, 1), new GridCoord(-1, 0), new GridCoord(0, -1),
        };

        /// <summary>The four diagonal direction vectors.</summary>
        public static readonly IReadOnlyList<GridCoord> Diagonal = new[] {
            new GridCoord(1, 1), new GridCoord(-1, 1), new GridCoord(-1, -1), new GridCoord(1, -1),
        };

        /// <summary>Gets an orthogonal direction vector by index (wraps modulo 4, supports negatives).</summary>
        public static GridCoord Direction(int index) => Orthogonal[((index % 4) + 4) % 4];

        /// <summary>Returns the orthogonally adjacent cell in the given direction (0–3, wraps).</summary>
        public GridCoord Neighbor(int direction) => this + Direction(direction);

        /// <summary>Returns the four orthogonally adjacent cells.</summary>
        public GridCoord[] Neighbors() {
            var result = new GridCoord[4];
            for (int i = 0; i < 4; i++)
                result[i] = this + Orthogonal[i];
            return result;
        }

        /// <summary>Returns the four diagonally adjacent cells.</summary>
        public GridCoord[] DiagonalNeighbors() {
            var result = new GridCoord[4];
            for (int i = 0; i < 4; i++)
                result[i] = this + Diagonal[i];
            return result;
        }

        /// <summary>Returns all eight adjacent cells (orthogonal then diagonal).</summary>
        public GridCoord[] Neighbors8() {
            var result = new GridCoord[8];
            for (int i = 0; i < 4; i++) {
                result[i] = this + Orthogonal[i];
                result[i + 4] = this + Diagonal[i];
            }
            return result;
        }

        #endregion Neighbors

        #region Shapes

        /// <summary>
        /// Returns the cells on the straight line between two cells (inclusive of both endpoints), via Bresenham's
        /// algorithm. Consecutive cells are 8-connected — useful for line of sight, beams, and trajectories.
        /// </summary>
        public static List<GridCoord> Line(GridCoord a, GridCoord b) {
            var result = new List<GridCoord>();

            int x0 = a.X, y0 = a.Y;
            int dx = Math.Abs(b.X - x0), dy = Math.Abs(b.Y - y0);
            int sx = x0 < b.X ? 1 : -1;
            int sy = y0 < b.Y ? 1 : -1;
            int err = dx - dy;

            while (true) {
                result.Add(new GridCoord(x0, y0));
                if (x0 == b.X && y0 == b.Y)
                    break;

                int e2 = 2 * err;
                if (e2 > -dy) {
                    err -= dy;
                    x0 += sx;
                }
                if (e2 < dx) {
                    err += dx;
                    y0 += sy;
                }
            }

            return result;
        }

        /// <summary>
        /// Returns every cell within <paramref name="radius"/> of this cell (inclusive) under the given metric:
        /// <see cref="GridMetric.Manhattan"/> yields a diamond, <see cref="GridMetric.Chebyshev"/> a square.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="radius"/> is negative.</exception>
        public List<GridCoord> Range(int radius, GridMetric metric) {
            if (radius < 0)
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be non-negative.");

            var results = new List<GridCoord>();
            for (int dx = -radius; dx <= radius; dx++) {
                for (int dy = -radius; dy <= radius; dy++) {
                    if (WithinRadius(dx, dy, radius, metric))
                        results.Add(new GridCoord(X + dx, Y + dy));
                }
            }

            return results;
        }

        /// <summary>
        /// Returns the cells exactly <paramref name="radius"/> away from this cell (the border of the
        /// <see cref="Range"/>) under the given metric.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="radius"/> is negative.</exception>
        public List<GridCoord> Ring(int radius, GridMetric metric) {
            if (radius < 0)
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be non-negative.");

            var results = new List<GridCoord>();
            if (radius == 0) {
                results.Add(this);
                return results;
            }

            for (int dx = -radius; dx <= radius; dx++) {
                for (int dy = -radius; dy <= radius; dy++) {
                    if (DistanceOf(dx, dy, metric) == radius)
                        results.Add(new GridCoord(X + dx, Y + dy));
                }
            }

            return results;
        }

        private static bool WithinRadius(int dx, int dy, int radius, GridMetric metric) =>
            DistanceOf(dx, dy, metric) <= radius;

        private static int DistanceOf(int dx, int dy, GridMetric metric) =>
            metric == GridMetric.Manhattan ? Math.Abs(dx) + Math.Abs(dy) : Math.Max(Math.Abs(dx), Math.Abs(dy));

        #endregion Shapes

        #region Equality

        /// <inheritdoc/>
        public bool Equals(GridCoord other) => X == other.X && Y == other.Y;

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is GridCoord other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => unchecked((X * 397) ^ Y);

        /// <summary>Determines whether two coordinates are equal.</summary>
        public static bool operator ==(GridCoord a, GridCoord b) => a.Equals(b);

        /// <summary>Determines whether two coordinates are not equal.</summary>
        public static bool operator !=(GridCoord a, GridCoord b) => !a.Equals(b);

        /// <summary>Returns <c>"(x, y)"</c>.</summary>
        public override string ToString() => $"({X}, {Y})";

        #endregion Equality
    }
}
