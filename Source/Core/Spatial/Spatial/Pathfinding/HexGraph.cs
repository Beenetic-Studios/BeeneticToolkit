using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Spatial.Pathfinding {

    /// <summary>
    /// A hex-grid adapter for the pathfinders, layered over <see cref="Hex"/>'s six-neighbor topology with
    /// per-hex passability and entry cost. Pair it with <see cref="Pathfinder.AStar{TNode}"/> using its
    /// <see cref="Heuristic"/> (the hex distance), or build a <see cref="FlowField{TNode}"/> from it.
    /// </summary>
    /// <remarks>
    /// A hex plane is infinite, so a passability predicate that never returns <c>false</c> makes the reachable
    /// region unbounded — fine for <see cref="Pathfinder.AStar{TNode}"/> toward a reachable goal, but
    /// <see cref="FlowField{TNode}"/> requires the walkable region to be finite.
    /// </remarks>
    public sealed class HexGraph : IWeightedGraph<Hex> {

        private readonly Func<Hex, bool> _isPassable;
        private readonly Func<Hex, float> _costOf;

        /// <summary>
        /// Creates a hex graph.
        /// </summary>
        /// <param name="isPassable">Returns whether a hex can be entered, or null to treat every hex as passable.</param>
        /// <param name="costOf">
        /// Returns the cost of entering a hex (terrain weight), or null for a uniform cost of 1. The heuristic
        /// assumes a minimum cost of 1, so values below 1 break A* optimality (Dijkstra stays correct).
        /// </param>
        public HexGraph(Func<Hex, bool>? isPassable = null, Func<Hex, float>? costOf = null) {
            _isPassable = isPassable ?? (_ => true);
            _costOf = costOf ?? (_ => 1f);
        }

        /// <summary>Whether a hex is passable.</summary>
        public bool IsWalkable(Hex hex) => _isPassable(hex);

        /// <inheritdoc/>
        public IEnumerable<Hex> Neighbors(Hex node) {
            for (int direction = 0; direction < 6; direction++) {
                Hex next = node.Neighbor(direction);
                if (_isPassable(next))
                    yield return next;
            }
        }

        /// <inheritdoc/>
        public float Cost(Hex from, Hex to) => _costOf(to);

        /// <summary>An admissible heuristic for <see cref="Pathfinder.AStar{TNode}"/>: the hex-grid distance.</summary>
        public float Heuristic(Hex a, Hex b) => Hex.Distance(a, b);
    }
}
