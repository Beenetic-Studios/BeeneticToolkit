using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Spatial.Partitioning {

    /// <summary>
    /// A uniform-grid spatial hash for 2D space: items are bucketed into square cells of a fixed size, so range
    /// and radius queries only touch the cells a window overlaps instead of every item. Unbounded — cells exist
    /// only where items live — and supports cheap <see cref="Remove"/>, making it a good fit for many moving
    /// entities of similar scale.
    /// </summary>
    /// <remarks>
    /// Pick a cell size near the typical query radius (or object spacing): too small wastes time spanning many
    /// cells, too large degrades each cell toward a linear scan. For tightly clustered data a
    /// <see cref="Quadtree{T}"/> adapts better.
    /// </remarks>
    /// <typeparam name="T">The item type stored at each point.</typeparam>
    public sealed class SpatialHash<T> {

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

        private readonly Dictionary<(int Cx, int Cy), List<Entry>> _cells = new Dictionary<(int, int), List<Entry>>();
        private readonly float _cellSize;

        /// <summary>The edge length of each square cell.</summary>
        public float CellSize => _cellSize;

        /// <summary>The number of items currently stored.</summary>
        public int Count { get; private set; }

        /// <summary>Creates a spatial hash with the given cell size.</summary>
        /// <param name="cellSize">The edge length of each square cell. Must be positive.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="cellSize"/> is not positive.</exception>
        public SpatialHash(float cellSize) {
            if (cellSize <= 0f)
                throw new ArgumentOutOfRangeException(nameof(cellSize), "Cell size must be positive.");

            _cellSize = cellSize;
        }

        /// <summary>Inserts <paramref name="item"/> at <paramref name="point"/>.</summary>
        public void Insert((float X, float Y) point, T item) {
            (int, int) cell = CellOf(point.X, point.Y);
            if (!_cells.TryGetValue(cell, out List<Entry>? bucket)) {
                bucket = new List<Entry>();
                _cells[cell] = bucket;
            }

            bucket.Add(new Entry(point.X, point.Y, item));
            Count++;
        }

        /// <summary>
        /// Removes one item equal to <paramref name="item"/> stored at <paramref name="point"/>.
        /// </summary>
        /// <param name="point">The point the item was inserted at (must match the cell it hashes to).</param>
        /// <param name="item">The item to remove.</param>
        /// <param name="comparer">Item equality comparer, or null for the default.</param>
        /// <returns><c>true</c> if an item was removed; otherwise <c>false</c>.</returns>
        public bool Remove((float X, float Y) point, T item, IEqualityComparer<T>? comparer = null) {
            (int, int) cell = CellOf(point.X, point.Y);
            if (!_cells.TryGetValue(cell, out List<Entry>? bucket))
                return false;

            comparer ??= EqualityComparer<T>.Default;
            for (int i = 0; i < bucket.Count; i++) {
                if (comparer.Equals(bucket[i].Item, item)) {
                    bucket.RemoveAt(i);
                    if (bucket.Count == 0)
                        _cells.Remove(cell);
                    Count--;
                    return true;
                }
            }

            return false;
        }

        /// <summary>Removes every item.</summary>
        public void Clear() {
            _cells.Clear();
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

            (int minCx, int minCy) = CellOf(region.MinX, region.MinY);
            (int maxCx, int maxCy) = CellOf(region.MaxX, region.MaxY);

            for (int cx = minCx; cx <= maxCx; cx++) {
                for (int cy = minCy; cy <= maxCy; cy++) {
                    if (!_cells.TryGetValue((cx, cy), out List<Entry>? bucket))
                        continue;

                    foreach (Entry entry in bucket)
                        if (region.Contains((entry.X, entry.Y)))
                            onItem(entry.Item);
                }
            }
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

            float radiusSq = radius * radius;
            (int minCx, int minCy) = CellOf(center.X - radius, center.Y - radius);
            (int maxCx, int maxCy) = CellOf(center.X + radius, center.Y + radius);

            for (int cx = minCx; cx <= maxCx; cx++) {
                for (int cy = minCy; cy <= maxCy; cy++) {
                    if (!_cells.TryGetValue((cx, cy), out List<Entry>? bucket))
                        continue;

                    foreach (Entry entry in bucket) {
                        float dx = entry.X - center.X;
                        float dy = entry.Y - center.Y;
                        if (dx * dx + dy * dy <= radiusSq)
                            onItem(entry.Item);
                    }
                }
            }
        }

        private (int, int) CellOf(float x, float y) =>
            ((int)Math.Floor(x / _cellSize), (int)Math.Floor(y / _cellSize));
    }
}
