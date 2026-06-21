using BeeneticToolkit.Collections;
using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Spatial.Partitioning {

    /// <summary>
    /// A point quadtree for 2D space: insert items at <c>(float X, float Y)</c> positions, then query everything
    /// inside a rectangle (<see cref="Query(Aabb)"/>) or circle (<see cref="QueryRadius(ValueTuple{float, float}, float)"/>) far faster than a
    /// linear scan. Nodes split into four quadrants once they exceed a capacity, down to a maximum depth.
    /// </summary>
    /// <remarks>
    /// Best when items are unevenly clustered (the tree adapts its resolution to density). For roughly uniform
    /// distributions a <see cref="SpatialHash{T}"/> is usually simpler and faster. Items are stored by position;
    /// to move an item, rebuild or <see cref="Clear"/> and re-insert (there is no in-place reposition).
    /// </remarks>
    /// <typeparam name="T">The item type stored at each point.</typeparam>
    public sealed class Quadtree<T> {

        private readonly struct Entry {
            public readonly float X;
            public readonly float Y;
            public readonly T Item;

            public Entry(float x, float y, T item) {
                X = x;
                Y = y;
                Item = item;
            }
        }

        private sealed class Node {
            public readonly Aabb Bounds;
            public readonly int Depth;
            public List<Entry>? Entries = new List<Entry>();
            public Node[]? Children;

            public Node(Aabb bounds, int depth) {
                Bounds = bounds;
                Depth = depth;
            }

            public bool IsLeaf => Children is null;
        }

        // A nearest-neighbor frontier element: either an interior node to expand or a concrete item result.
        private readonly struct NearestCandidate {
            public readonly Node? Node;
            public readonly T Item;
            public readonly bool IsItem;

            private NearestCandidate(Node? node, T item, bool isItem) {
                Node = node;
                Item = item;
                IsItem = isItem;
            }

            public static NearestCandidate ForNode(Node node) => new NearestCandidate(node, default!, false);
            public static NearestCandidate ForItem(T item) => new NearestCandidate(null, item, true);
        }

        private readonly Node _root;
        private readonly int _capacity;
        private readonly int _maxDepth;

        /// <summary>The region this quadtree covers; inserts outside it are rejected.</summary>
        public Aabb Bounds => _root.Bounds;

        /// <summary>The number of items currently stored.</summary>
        public int Count { get; private set; }

        /// <summary>
        /// Creates a quadtree covering <paramref name="bounds"/>.
        /// </summary>
        /// <param name="bounds">The total region the tree covers.</param>
        /// <param name="capacity">How many items a leaf holds before it subdivides. Must be positive.</param>
        /// <param name="maxDepth">The maximum subdivision depth; deeper leaves overflow past capacity. Must be non-negative.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="capacity"/> is not positive or <paramref name="maxDepth"/> is negative.</exception>
        public Quadtree(Aabb bounds, int capacity = 8, int maxDepth = 8) {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be positive.");
            if (maxDepth < 0)
                throw new ArgumentOutOfRangeException(nameof(maxDepth), "Max depth must be non-negative.");

            _root = new Node(bounds, 0);
            _capacity = capacity;
            _maxDepth = maxDepth;
        }

        /// <summary>
        /// Inserts <paramref name="item"/> at <paramref name="point"/>.
        /// </summary>
        /// <returns><c>true</c> if inserted; <c>false</c> if the point lies outside <see cref="Bounds"/>.</returns>
        public bool Insert((float X, float Y) point, T item) {
            if (!_root.Bounds.Contains(point))
                return false;

            InsertInto(_root, new Entry(point.X, point.Y, item));
            Count++;
            return true;
        }

        /// <summary>Removes every item, returning the tree to a single empty root node.</summary>
        public void Clear() {
            _root.Entries = new List<Entry>();
            _root.Children = null;
            Count = 0;
        }

        /// <summary>Returns every item whose point falls inside <paramref name="region"/>.</summary>
        public List<T> Query(Aabb region) {
            var results = new List<T>();
            Query(region, results.Add);
            return results;
        }

        /// <summary>Invokes <paramref name="onItem"/> for every item whose point falls inside <paramref name="region"/> (allocation-free).</summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="onItem"/> is null.</exception>
        public void Query(Aabb region, Action<T> onItem) {
            if (onItem is null)
                throw new ArgumentNullException(nameof(onItem));

            QueryNode(_root, region, onItem);
        }

        /// <summary>Returns every item within <paramref name="radius"/> of <paramref name="center"/>.</summary>
        public List<T> QueryRadius((float X, float Y) center, float radius) {
            var results = new List<T>();
            QueryRadius(center, radius, results.Add);
            return results;
        }

        /// <summary>Invokes <paramref name="onItem"/> for every item within <paramref name="radius"/> of <paramref name="center"/> (allocation-free).</summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="onItem"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="radius"/> is negative.</exception>
        public void QueryRadius((float X, float Y) center, float radius, Action<T> onItem) {
            if (onItem is null)
                throw new ArgumentNullException(nameof(onItem));
            if (radius < 0f)
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be non-negative.");

            QueryRadiusNode(_root, center, radius, radius * radius, onItem);
        }

        /// <summary>Gets the single item closest to <paramref name="point"/>.</summary>
        /// <returns><c>true</c> if the tree had any item; otherwise <c>false</c>.</returns>
        public bool TryNearest((float X, float Y) point, out T nearest) {
            foreach (T item in Nearest(point, 1)) {
                nearest = item;
                return true;
            }

            nearest = default!;
            return false;
        }

        /// <summary>
        /// Returns up to <paramref name="count"/> items nearest to <paramref name="point"/>, ordered closest first.
        /// Uses a best-first branch-and-bound over the tree, so it visits far fewer items than a full scan.
        /// </summary>
        /// <param name="point">The query point.</param>
        /// <param name="count">The maximum number of neighbors to return. Must be positive.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="count"/> is not positive.</exception>
        public List<T> Nearest((float X, float Y) point, int count) {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be positive.");

            var results = new List<T>(Math.Min(count, Count));
            if (Count == 0)
                return results;

            // Min-heap keyed by squared distance: nodes by their bounds' distance, items by their exact distance.
            // When an item surfaces to the top, nothing unexplored can be closer, so it is the next nearest.
            var frontier = new Collections.PriorityQueue<NearestCandidate, float>();
            frontier.Enqueue(NearestCandidate.ForNode(_root), _root.Bounds.SquaredDistanceTo(point));

            while (results.Count < count && frontier.TryDequeue(out NearestCandidate current, out _)) {
                if (current.IsItem) {
                    results.Add(current.Item);
                    continue;
                }

                Node node = current.Node!;
                if (node.IsLeaf) {
                    foreach (Entry entry in node.Entries!) {
                        float dx = entry.X - point.X;
                        float dy = entry.Y - point.Y;
                        frontier.Enqueue(NearestCandidate.ForItem(entry.Item), dx * dx + dy * dy);
                    }
                } else {
                    foreach (Node child in node.Children!)
                        frontier.Enqueue(NearestCandidate.ForNode(child), child.Bounds.SquaredDistanceTo(point));
                }
            }

            return results;
        }

        private void InsertInto(Node node, Entry entry) {
            while (true) {
                if (!node.IsLeaf) {
                    node = node.Children![QuadrantOf(node.Bounds, entry.X, entry.Y)];
                    continue;
                }

                node.Entries!.Add(entry);
                if (node.Entries.Count > _capacity && node.Depth < _maxDepth)
                    Subdivide(node);

                return;
            }
        }

        private void Subdivide(Node node) {
            (float cx, float cy) = node.Bounds.Center;
            Aabb b = node.Bounds;

            // Index layout: 0 = SW, 1 = SE, 2 = NW, 3 = NE (east bit + north bit).
            node.Children = new[] {
                new Node(new Aabb(b.MinX, b.MinY, cx, cy), node.Depth + 1),
                new Node(new Aabb(cx, b.MinY, b.MaxX, cy), node.Depth + 1),
                new Node(new Aabb(b.MinX, cy, cx, b.MaxY), node.Depth + 1),
                new Node(new Aabb(cx, cy, b.MaxX, b.MaxY), node.Depth + 1),
            };

            foreach (Entry entry in node.Entries!)
                node.Children[QuadrantOf(node.Bounds, entry.X, entry.Y)].Entries!.Add(entry);

            node.Entries = null; // internal nodes hold no entries
        }

        private static int QuadrantOf(Aabb bounds, float x, float y) {
            (float cx, float cy) = bounds.Center;
            int east = x >= cx ? 1 : 0;
            int north = y >= cy ? 2 : 0;
            return east + north;
        }

        private static void QueryNode(Node node, Aabb region, Action<T> onItem) {
            if (!node.Bounds.Intersects(region))
                return;

            if (node.IsLeaf) {
                foreach (Entry entry in node.Entries!)
                    if (region.Contains((entry.X, entry.Y)))
                        onItem(entry.Item);
                return;
            }

            foreach (Node child in node.Children!)
                QueryNode(child, region, onItem);
        }

        private static void QueryRadiusNode(Node node, (float X, float Y) center, float radius, float radiusSq, Action<T> onItem) {
            if (!node.Bounds.IntersectsCircle(center, radius))
                return;

            if (node.IsLeaf) {
                foreach (Entry entry in node.Entries!) {
                    float dx = entry.X - center.X;
                    float dy = entry.Y - center.Y;
                    if (dx * dx + dy * dy <= radiusSq)
                        onItem(entry.Item);
                }
                return;
            }

            foreach (Node child in node.Children!)
                QueryRadiusNode(child, center, radius, radiusSq, onItem);
        }
    }
}
