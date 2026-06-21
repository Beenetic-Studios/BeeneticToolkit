using BeeneticToolkit.Collections;
using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Spatial.Pathfinding {

    /// <summary>
    /// Single-source/single-goal pathfinding over any <see cref="IGraph{TNode}"/>:
    /// <see cref="BreadthFirstSearch{TNode}"/> for unweighted graphs, <see cref="Dijkstra{TNode}"/> for weighted
    /// graphs, and <see cref="AStar{TNode}"/> when an admissible heuristic is available. The cost-aware searches
    /// use <see cref="Collections.PriorityQueue{TElement, TPriority}"/> from BeeneticToolkit.Collections.
    /// </summary>
    /// <remarks>
    /// For one goal served by many sources (e.g. lots of agents converging on the same target), prefer a
    /// <see cref="FlowField{TNode}"/>, which solves every source at once.
    /// </remarks>
    public static class Pathfinder {

        /// <summary>
        /// Finds a shortest path (fewest edges) from <paramref name="start"/> to <paramref name="goal"/> using a
        /// breadth-first search. Edge costs are ignored — every step counts as 1.
        /// </summary>
        /// <param name="graph">The graph to search.</param>
        /// <param name="start">The starting node.</param>
        /// <param name="goal">The goal node.</param>
        /// <param name="comparer">Node equality comparer, or null for the default.</param>
        /// <returns>The path, or <see cref="PathResult{TNode}.Failure"/> if the goal is unreachable.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="graph"/> is null.</exception>
        public static PathResult<TNode> BreadthFirstSearch<TNode>(
            IGraph<TNode> graph, TNode start, TNode goal, IEqualityComparer<TNode>? comparer = null)
            where TNode : notnull {

            if (graph is null)
                throw new ArgumentNullException(nameof(graph));

            comparer ??= EqualityComparer<TNode>.Default;

            if (comparer.Equals(start, goal))
                return new PathResult<TNode>(new[] { start }, 0f);

            var cameFrom = new Dictionary<TNode, TNode>(comparer) { [start] = start };
            var frontier = new Queue<TNode>();
            frontier.Enqueue(start);

            while (frontier.Count > 0) {
                TNode current = frontier.Dequeue();

                foreach (TNode next in graph.Neighbors(current)) {
                    if (cameFrom.ContainsKey(next))
                        continue;

                    cameFrom[next] = current;
                    if (comparer.Equals(next, goal))
                        return Reconstruct(cameFrom, start, goal, comparer, costSoFar: null);

                    frontier.Enqueue(next);
                }
            }

            return PathResult<TNode>.Failure;
        }

        /// <summary>
        /// Finds a least-cost path from <paramref name="start"/> to <paramref name="goal"/> using Dijkstra's
        /// algorithm. Equivalent to <see cref="AStar{TNode}"/> with a zero heuristic.
        /// </summary>
        /// <param name="graph">The weighted graph to search.</param>
        /// <param name="start">The starting node.</param>
        /// <param name="goal">The goal node.</param>
        /// <param name="comparer">Node equality comparer, or null for the default.</param>
        /// <returns>The least-cost path, or <see cref="PathResult{TNode}.Failure"/> if the goal is unreachable.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="graph"/> is null.</exception>
        public static PathResult<TNode> Dijkstra<TNode>(
            IWeightedGraph<TNode> graph, TNode start, TNode goal, IEqualityComparer<TNode>? comparer = null)
            where TNode : notnull =>
            AStar(graph, start, goal, (_, __) => 0f, comparer);

        /// <summary>
        /// Finds a least-cost path from <paramref name="start"/> to <paramref name="goal"/> using A*. The
        /// <paramref name="heuristic"/> estimates the remaining cost from a node to the goal; it must never
        /// overestimate (be admissible) for the result to be optimal.
        /// </summary>
        /// <param name="graph">The weighted graph to search.</param>
        /// <param name="start">The starting node.</param>
        /// <param name="goal">The goal node.</param>
        /// <param name="heuristic">Estimated remaining cost from a candidate node (first arg) to the goal (second arg).</param>
        /// <param name="comparer">Node equality comparer, or null for the default.</param>
        /// <returns>The least-cost path, or <see cref="PathResult{TNode}.Failure"/> if the goal is unreachable.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="graph"/> or <paramref name="heuristic"/> is null.</exception>
        public static PathResult<TNode> AStar<TNode>(
            IWeightedGraph<TNode> graph, TNode start, TNode goal, Func<TNode, TNode, float> heuristic,
            IEqualityComparer<TNode>? comparer = null) where TNode : notnull {

            if (graph is null)
                throw new ArgumentNullException(nameof(graph));
            if (heuristic is null)
                throw new ArgumentNullException(nameof(heuristic));

            comparer ??= EqualityComparer<TNode>.Default;

            if (comparer.Equals(start, goal))
                return new PathResult<TNode>(new[] { start }, 0f);

            var cameFrom = new Dictionary<TNode, TNode>(comparer) { [start] = start };
            var costSoFar = new Dictionary<TNode, float>(comparer) { [start] = 0f };
            var frontier = new Collections.PriorityQueue<TNode, float>();
            frontier.Enqueue(start, 0f);

            while (frontier.TryDequeue(out TNode current, out _)) {
                if (comparer.Equals(current, goal))
                    return Reconstruct(cameFrom, start, goal, comparer, costSoFar);

                float currentCost = costSoFar[current];
                foreach (TNode next in graph.Neighbors(current)) {
                    float stepCost = graph.Cost(current, next);
                    if (stepCost < 0f)
                        throw new InvalidOperationException("Edge costs must be non-negative.");

                    float newCost = currentCost + stepCost;
                    if (costSoFar.TryGetValue(next, out float existing) && newCost >= existing)
                        continue;

                    costSoFar[next] = newCost;
                    cameFrom[next] = current;
                    frontier.Enqueue(next, newCost + heuristic(next, goal));
                }
            }

            return PathResult<TNode>.Failure;
        }

        /// <summary>
        /// Walks the <paramref name="cameFrom"/> chain back from the goal, reversing it into a start-to-goal path.
        /// When <paramref name="costSoFar"/> is supplied the goal's accumulated cost is used; otherwise the cost is
        /// the number of steps (for the unweighted search).
        /// </summary>
        internal static PathResult<TNode> Reconstruct<TNode>(
            Dictionary<TNode, TNode> cameFrom, TNode start, TNode goal,
            IEqualityComparer<TNode> comparer, Dictionary<TNode, float>? costSoFar) where TNode : notnull {

            var path = new List<TNode> { goal };
            TNode current = goal;
            while (!comparer.Equals(current, start)) {
                current = cameFrom[current];
                path.Add(current);
            }

            path.Reverse();
            float cost = costSoFar != null ? costSoFar[goal] : path.Count - 1;
            return new PathResult<TNode>(path, cost);
        }
    }
}
