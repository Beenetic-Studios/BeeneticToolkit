using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Spatial.Pathfinding {

    /// <summary>
    /// The outcome of a pathfinding query: whether a path was found, the ordered nodes from start to goal
    /// (inclusive of both), and the total cost. When no path exists, <see cref="Found"/> is <c>false</c>,
    /// <see cref="Nodes"/> is empty, and <see cref="Cost"/> is <see cref="float.PositiveInfinity"/>.
    /// </summary>
    /// <typeparam name="TNode">The node type.</typeparam>
    public readonly struct PathResult<TNode> {

        /// <summary>Whether a path from the start to the goal was found.</summary>
        public bool Found { get; }

        /// <summary>The path from start to goal (inclusive of both endpoints), or an empty list if none was found.</summary>
        public IReadOnlyList<TNode> Nodes { get; }

        /// <summary>The total path cost (step count for unweighted searches), or infinity if no path was found.</summary>
        public float Cost { get; }

        /// <summary>Creates a successful result.</summary>
        public PathResult(IReadOnlyList<TNode> nodes, float cost) {
            Nodes = nodes ?? throw new ArgumentNullException(nameof(nodes));
            Cost = cost;
            Found = true;
        }

        private PathResult(bool found, IReadOnlyList<TNode> nodes, float cost) {
            Found = found;
            Nodes = nodes;
            Cost = cost;
        }

        /// <summary>A result representing "no path exists".</summary>
        public static PathResult<TNode> Failure { get; } =
            new PathResult<TNode>(false, Array.Empty<TNode>(), float.PositiveInfinity);
    }
}
