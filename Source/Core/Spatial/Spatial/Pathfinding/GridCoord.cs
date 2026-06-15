using System;

namespace BeeneticToolkit.Spatial.Pathfinding {

    /// <summary>
    /// An integer (column, row) cell on a square grid — the node type for <see cref="GridGraph"/>. Like
    /// <see cref="Hex"/>, it keeps grid math in its own integer struct, exposing world positions only as
    /// <c>(float X, float Y)</c> tuples at the boundary so no engine vector type leaks in.
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

        /// <summary>Adds two coordinates component-wise.</summary>
        public static GridCoord operator +(GridCoord a, GridCoord b) => new GridCoord(a.X + b.X, a.Y + b.Y);

        /// <summary>Subtracts two coordinates component-wise.</summary>
        public static GridCoord operator -(GridCoord a, GridCoord b) => new GridCoord(a.X - b.X, a.Y - b.Y);

        /// <summary>The 4-way (orthogonal) step distance between two cells.</summary>
        public static int Manhattan(GridCoord a, GridCoord b) => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);

        /// <summary>The 8-way (king-move) step distance between two cells.</summary>
        public static int Chebyshev(GridCoord a, GridCoord b) => Math.Max(Math.Abs(a.X - b.X), Math.Abs(a.Y - b.Y));

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
    }
}
