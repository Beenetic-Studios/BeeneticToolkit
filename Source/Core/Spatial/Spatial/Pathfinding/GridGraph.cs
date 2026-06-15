using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Spatial.Pathfinding {

    /// <summary>How cells connect to their neighbors on a <see cref="GridGraph"/>.</summary>
    public enum GridConnectivity {

        /// <summary>Orthogonal moves only (up/down/left/right).</summary>
        FourWay,

        /// <summary>Orthogonal and diagonal moves (king moves).</summary>
        EightWay,
    }

    /// <summary>
    /// A rectangular square-grid adapter for the pathfinders: bounds, per-cell passability, and per-cell entry
    /// cost, with 4- or 8-way connectivity. Pair it with <see cref="Pathfinder.AStar{TNode}"/> using its own
    /// <see cref="Heuristic"/>, or build a <see cref="FlowField{TNode}"/> from it.
    /// </summary>
    public sealed class GridGraph : IWeightedGraph<GridCoord> {

        private static readonly float Sqrt2 = (float)Math.Sqrt(2.0);

        private static readonly GridCoord[] Orthogonal = {
            new GridCoord(1, 0), new GridCoord(-1, 0), new GridCoord(0, 1), new GridCoord(0, -1),
        };

        private static readonly GridCoord[] Diagonal = {
            new GridCoord(1, 1), new GridCoord(1, -1), new GridCoord(-1, 1), new GridCoord(-1, -1),
        };

        private readonly Func<GridCoord, bool> _isPassable;
        private readonly Func<GridCoord, float> _costOf;

        /// <summary>The grid width (number of columns); valid X is <c>0 .. Width - 1</c>.</summary>
        public int Width { get; }

        /// <summary>The grid height (number of rows); valid Y is <c>0 .. Height - 1</c>.</summary>
        public int Height { get; }

        /// <summary>The connectivity (4-way or 8-way).</summary>
        public GridConnectivity Connectivity { get; }

        /// <summary>
        /// Whether a diagonal move is allowed to "cut the corner" past a blocked orthogonal cell. When
        /// <c>false</c> (the default), a diagonal step requires both shared orthogonal cells to be passable.
        /// Only relevant for <see cref="GridConnectivity.EightWay"/>.
        /// </summary>
        public bool AllowDiagonalCornerCutting { get; }

        /// <summary>
        /// Creates a grid graph.
        /// </summary>
        /// <param name="width">The number of columns. Must be positive.</param>
        /// <param name="height">The number of rows. Must be positive.</param>
        /// <param name="connectivity">4-way (default) or 8-way movement.</param>
        /// <param name="isPassable">
        /// Returns whether a cell can be entered, or null to treat every in-bounds cell as passable.
        /// </param>
        /// <param name="costOf">
        /// Returns the cost of entering a cell (terrain weight), or null for a uniform cost of 1. The heuristic
        /// assumes a minimum cost of 1, so values below 1 break A* optimality (Dijkstra stays correct).
        /// </param>
        /// <param name="allowDiagonalCornerCutting">Whether 8-way diagonals may cut blocked corners (default false).</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="width"/> or <paramref name="height"/> is not positive.</exception>
        public GridGraph(
            int width, int height, GridConnectivity connectivity = GridConnectivity.FourWay,
            Func<GridCoord, bool>? isPassable = null, Func<GridCoord, float>? costOf = null,
            bool allowDiagonalCornerCutting = false) {

            if (width <= 0)
                throw new ArgumentOutOfRangeException(nameof(width), "Width must be positive.");
            if (height <= 0)
                throw new ArgumentOutOfRangeException(nameof(height), "Height must be positive.");

            Width = width;
            Height = height;
            Connectivity = connectivity;
            AllowDiagonalCornerCutting = allowDiagonalCornerCutting;
            _isPassable = isPassable ?? (_ => true);
            _costOf = costOf ?? (_ => 1f);
        }

        /// <summary>Whether a coordinate lies inside the grid bounds.</summary>
        public bool InBounds(GridCoord cell) => cell.X >= 0 && cell.X < Width && cell.Y >= 0 && cell.Y < Height;

        /// <summary>Whether a coordinate is both in bounds and passable.</summary>
        public bool IsWalkable(GridCoord cell) => InBounds(cell) && _isPassable(cell);

        /// <inheritdoc/>
        public IEnumerable<GridCoord> Neighbors(GridCoord node) {
            foreach (GridCoord dir in Orthogonal) {
                GridCoord next = node + dir;
                if (IsWalkable(next))
                    yield return next;
            }

            if (Connectivity != GridConnectivity.EightWay)
                yield break;

            foreach (GridCoord dir in Diagonal) {
                GridCoord next = node + dir;
                if (!IsWalkable(next))
                    continue;

                if (!AllowDiagonalCornerCutting &&
                    (!IsWalkable(new GridCoord(node.X + dir.X, node.Y)) ||
                     !IsWalkable(new GridCoord(node.X, node.Y + dir.Y))))
                    continue;

                yield return next;
            }
        }

        /// <inheritdoc/>
        public float Cost(GridCoord from, GridCoord to) {
            float enter = _costOf(to);
            bool diagonal = from.X != to.X && from.Y != to.Y;
            return diagonal ? enter * Sqrt2 : enter;
        }

        /// <summary>
        /// An admissible heuristic for <see cref="Pathfinder.AStar{TNode}"/> matching this grid's connectivity:
        /// Manhattan distance for 4-way, octile distance for 8-way. Assumes a minimum step cost of 1.
        /// </summary>
        public float Heuristic(GridCoord a, GridCoord b) {
            int dx = Math.Abs(a.X - b.X);
            int dy = Math.Abs(a.Y - b.Y);

            if (Connectivity == GridConnectivity.FourWay)
                return dx + dy;

            // Octile: straight segments at cost 1 plus the diagonal shortcut for the overlap.
            int min = Math.Min(dx, dy);
            int max = Math.Max(dx, dy);
            return (max - min) + Sqrt2 * min;
        }
    }
}
