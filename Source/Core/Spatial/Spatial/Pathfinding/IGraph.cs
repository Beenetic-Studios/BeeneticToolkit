using System.Collections.Generic;

namespace BeeneticToolkit.Spatial.Pathfinding {

    /// <summary>
    /// An abstract graph over nodes of type <typeparamref name="TNode"/> — the only thing the pathfinders need to
    /// know is, given a node, which nodes you can move to from it. Implement this (or use a built-in adapter like
    /// <see cref="GridGraph"/> or <see cref="HexGraph"/>) to run <see cref="Pathfinder.BreadthFirstSearch{TNode}"/>.
    /// </summary>
    /// <remarks>
    /// Nodes are used as dictionary keys internally, so <typeparamref name="TNode"/> must have sensible equality
    /// (override <c>Equals</c>/<c>GetHashCode</c>, or pass an <see cref="IEqualityComparer{T}"/> to the pathfinder).
    /// </remarks>
    /// <typeparam name="TNode">The node type (a cell, a hex, a waypoint — whatever your graph connects).</typeparam>
    public interface IGraph<TNode> where TNode : notnull {

        /// <summary>Returns the nodes reachable in one step from <paramref name="node"/>.</summary>
        IEnumerable<TNode> Neighbors(TNode node);
    }

    /// <summary>
    /// A graph whose edges carry a movement cost — required by the cost-aware pathfinders
    /// (<see cref="Pathfinder.Dijkstra{TNode}"/>, <see cref="Pathfinder.AStar{TNode}"/>, and
    /// <see cref="FlowField{TNode}"/>). For uniform-cost graphs every edge can simply return 1.
    /// </summary>
    /// <typeparam name="TNode">The node type.</typeparam>
    public interface IWeightedGraph<TNode> : IGraph<TNode> where TNode : notnull {

        /// <summary>
        /// Returns the cost of moving from <paramref name="from"/> to the adjacent node <paramref name="to"/>.
        /// Must be non-negative; the heuristic-based search assumes a minimum step cost when judging admissibility.
        /// </summary>
        float Cost(TNode from, TNode to);
    }
}
