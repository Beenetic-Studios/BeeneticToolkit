using BeeneticToolkit.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BeeneticToolkit.Spatial.Pathfinding {

    /// <summary>
    /// A precomputed least-cost field over a finite graph: for every reachable node it stores the cost to the
    /// nearest goal and which neighbor to step to in order to get there. Build it once with
    /// <see cref="Compute"/>, then route any number of agents toward the goal(s) for free with
    /// <see cref="TryGetNext"/> or <see cref="GetPath"/> — far cheaper than running <see cref="Pathfinder"/>
    /// per agent when they share a destination.
    /// </summary>
    /// <remarks>
    /// Computed by a multi-source Dijkstra expanding outward from the goals over forward edges, so it assumes
    /// movement costs are <b>symmetric</b> (<c>Cost(a, b) == Cost(b, a)</c>) — true for ordinary grids/hex maps.
    /// The graph's reachable region must be <b>finite</b>, or the computation will not terminate.
    /// </remarks>
    /// <typeparam name="TNode">The node type.</typeparam>
    public sealed class FlowField<TNode> where TNode : notnull {

        private readonly Dictionary<TNode, float> _cost;
        private readonly Dictionary<TNode, TNode> _next;
        private readonly HashSet<TNode> _goals;
        private readonly IEqualityComparer<TNode> _comparer;

        private FlowField(
            Dictionary<TNode, float> cost, Dictionary<TNode, TNode> next,
            HashSet<TNode> goals, IEqualityComparer<TNode> comparer) {

            _cost = cost;
            _next = next;
            _goals = goals;
            _comparer = comparer;
        }

        /// <summary>The cost to the nearest goal for every reachable node (a goal itself costs 0).</summary>
        public IReadOnlyDictionary<TNode, float> Costs => _cost;

        /// <summary>The number of reachable nodes (including the goals).</summary>
        public int Count => _cost.Count;

        /// <summary>Whether <paramref name="node"/> is one of the goals this field flows toward.</summary>
        public bool IsGoal(TNode node) => _goals.Contains(node);

        /// <summary>Whether <paramref name="node"/> can reach a goal at all.</summary>
        public bool IsReachable(TNode node) => _cost.ContainsKey(node);

        /// <summary>Gets the cost from <paramref name="node"/> to the nearest goal.</summary>
        /// <returns><c>true</c> if the node is reachable; otherwise <c>false</c>.</returns>
        public bool TryGetCost(TNode node, out float cost) => _cost.TryGetValue(node, out cost);

        /// <summary>
        /// Gets the next node to step to from <paramref name="node"/> to move toward the nearest goal.
        /// </summary>
        /// <returns>
        /// <c>false</c> if <paramref name="node"/> is a goal (already arrived) or is unreachable; otherwise <c>true</c>.
        /// </returns>
        public bool TryGetNext(TNode node, [MaybeNullWhen(false)] out TNode next) => _next.TryGetValue(node, out next);

        /// <summary>
        /// Follows the field from <paramref name="from"/> step by step to the nearest goal, returning the full path.
        /// </summary>
        /// <returns>The path to the goal, or <see cref="PathResult{TNode}.Failure"/> if unreachable.</returns>
        public PathResult<TNode> GetPath(TNode from) {
            if (!_cost.TryGetValue(from, out float total))
                return PathResult<TNode>.Failure;

            var path = new List<TNode> { from };
            TNode current = from;
            while (_next.ContainsKey(current)) {
                current = _next[current];
                path.Add(current);
            }

            return new PathResult<TNode>(path, total);
        }

        /// <summary>
        /// Builds a flow field over <paramref name="graph"/> directed toward every node in <paramref name="goals"/>.
        /// </summary>
        /// <param name="graph">The weighted graph (assumed to have a finite reachable region and symmetric costs).</param>
        /// <param name="goals">One or more goal nodes the field flows toward.</param>
        /// <param name="comparer">Node equality comparer, or null for the default.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="graph"/> or <paramref name="goals"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="goals"/> is empty.</exception>
        public static FlowField<TNode> Compute(
            IWeightedGraph<TNode> graph, IEnumerable<TNode> goals, IEqualityComparer<TNode>? comparer = null) {

            if (graph is null)
                throw new ArgumentNullException(nameof(graph));
            if (goals is null)
                throw new ArgumentNullException(nameof(goals));

            comparer ??= EqualityComparer<TNode>.Default;

            var goalSet = new HashSet<TNode>(goals, comparer);
            if (goalSet.Count == 0)
                throw new ArgumentException("At least one goal is required.", nameof(goals));

            var cost = new Dictionary<TNode, float>(comparer);
            var next = new Dictionary<TNode, TNode>(comparer);
            var frontier = new Collections.PriorityQueue<TNode, float>();

            foreach (TNode goal in goalSet) {
                cost[goal] = 0f;
                frontier.Enqueue(goal, 0f);
            }

            while (frontier.TryDequeue(out TNode current, out float currentCost)) {
                // Skip stale queue entries left behind by a cheaper relaxation.
                if (currentCost > cost[current])
                    continue;

                foreach (TNode neighbor in graph.Neighbors(current)) {
                    // Cost is read as the step neighbor -> current (toward the goal), assuming symmetric costs.
                    float stepCost = graph.Cost(current, neighbor);
                    if (stepCost < 0f)
                        throw new InvalidOperationException("Edge costs must be non-negative.");

                    float newCost = currentCost + stepCost;
                    if (cost.TryGetValue(neighbor, out float existing) && newCost >= existing)
                        continue;

                    cost[neighbor] = newCost;
                    next[neighbor] = current;
                    frontier.Enqueue(neighbor, newCost);
                }
            }

            return new FlowField<TNode>(cost, next, goalSet, comparer);
        }
    }
}
