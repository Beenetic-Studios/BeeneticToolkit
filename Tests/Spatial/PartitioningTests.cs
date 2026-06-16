using BeeneticToolkit.Spatial.Partitioning;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Tests.Spatial {

    [TestClass]
    public class PartitioningTests {

        private const float Tolerance = 1e-4f;

        // A deterministic mix of a lattice plus a tight cluster (to force deep subdivision in the quadtree).
        private static List<(float X, float Y, int Id)> BuildPoints() {
            var points = new List<(float, float, int)>();
            int id = 0;
            for (int i = -7; i <= 7; i++)
                for (int j = -7; j <= 7; j++)
                    points.Add((i, j, id++));

            for (int k = 0; k < 40; k++)
                points.Add((2.0f + k * 0.001f, 3.0f - k * 0.001f, id++));

            return points;
        }

        private static List<int> BruteForceRegion(List<(float X, float Y, int Id)> points, Aabb region) =>
            points.Where(p => region.Contains((p.X, p.Y))).Select(p => p.Id).OrderBy(x => x).ToList();

        private static List<int> BruteForceRadius(List<(float X, float Y, int Id)> points, (float X, float Y) c, float r) =>
            points.Where(p => {
                float dx = p.X - c.X, dy = p.Y - c.Y;
                return dx * dx + dy * dy <= r * r;
            }).Select(p => p.Id).OrderBy(x => x).ToList();

        #region Aabb

        [TestMethod]
        public void Aabb_Contains_PointAndBox_EdgesInclusive() {
            var box = new Aabb(0f, 0f, 10f, 10f);
            Assert.IsTrue(box.Contains((5f, 5f)));
            Assert.IsTrue(box.Contains((0f, 10f)));  // corner/edge inclusive
            Assert.IsFalse(box.Contains((-0.1f, 5f)));
            Assert.IsTrue(box.Contains(new Aabb(2f, 2f, 8f, 8f)));
            Assert.IsFalse(box.Contains(new Aabb(2f, 2f, 12f, 8f)));
        }

        [TestMethod]
        public void Aabb_Intersects_BoxAndCircle() {
            var box = new Aabb(0f, 0f, 10f, 10f);
            Assert.IsTrue(box.Intersects(new Aabb(8f, 8f, 12f, 12f)));
            Assert.IsFalse(box.Intersects(new Aabb(11f, 0f, 12f, 10f)));
            Assert.IsTrue(box.IntersectsCircle((12f, 5f), 3f));   // reaches the right edge
            Assert.IsFalse(box.IntersectsCircle((12f, 5f), 1f));  // falls short
            Assert.IsTrue(box.IntersectsCircle((5f, 5f), 0f));    // center inside
        }

        [TestMethod]
        public void Aabb_FromCenter_And_Accessors() {
            var box = Aabb.FromCenter((5f, 5f), 2f, 3f);
            Assert.AreEqual(3f, box.MinX, Tolerance);
            Assert.AreEqual(7f, box.MaxX, Tolerance);
            Assert.AreEqual(2f, box.MinY, Tolerance);
            Assert.AreEqual(8f, box.MaxY, Tolerance);
            Assert.AreEqual(4f, box.Width, Tolerance);
            Assert.AreEqual(6f, box.Height, Tolerance);
            Assert.AreEqual((5f, 5f), box.Center);
        }

        [TestMethod]
        public void Aabb_InvalidConstruction_Throws() {
            Assert.ThrowsException<ArgumentException>(() => new Aabb(5f, 0f, 1f, 10f));
            Assert.ThrowsException<ArgumentException>(() => new Aabb(0f, 5f, 10f, 1f));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Aabb.FromCenter((0f, 0f), -1f, 1f));
        }

        [TestMethod]
        public void Aabb_Equality() {
            Assert.AreEqual(new Aabb(0f, 0f, 1f, 1f), new Aabb(0f, 0f, 1f, 1f));
            Assert.AreEqual(new Aabb(0f, 0f, 1f, 1f).GetHashCode(), new Aabb(0f, 0f, 1f, 1f).GetHashCode());
            Assert.AreNotEqual(new Aabb(0f, 0f, 1f, 1f), new Aabb(0f, 0f, 1f, 2f));
        }

        #endregion Aabb

        #region Quadtree

        [TestMethod]
        public void Quadtree_InsertOutsideBounds_Rejected() {
            var tree = new Quadtree<int>(new Aabb(0f, 0f, 10f, 10f));
            Assert.IsTrue(tree.Insert((5f, 5f), 1));
            Assert.IsFalse(tree.Insert((20f, 20f), 2));
            Assert.AreEqual(1, tree.Count);
        }

        [TestMethod]
        public void Quadtree_RegionQuery_MatchesBruteForce() {
            var points = BuildPoints();
            var tree = new Quadtree<int>(new Aabb(-8f, -8f, 8f, 8f), capacity: 4, maxDepth: 8);
            foreach (var p in points)
                tree.Insert((p.X, p.Y), p.Id);

            Assert.AreEqual(points.Count, tree.Count);

            var regions = new[] {
                new Aabb(-3f, -3f, 3f, 3f),
                new Aabb(1.5f, 2.5f, 2.5f, 3.5f),  // tight box around the cluster
                new Aabb(-8f, -8f, 8f, 8f),        // everything
                new Aabb(100f, 100f, 110f, 110f),  // nothing
            };

            foreach (var region in regions) {
                var actual = tree.Query(region).OrderBy(x => x).ToList();
                CollectionAssert.AreEqual(BruteForceRegion(points, region), actual, $"region {region}");
            }
        }

        [TestMethod]
        public void Quadtree_RadiusQuery_MatchesBruteForce() {
            var points = BuildPoints();
            var tree = new Quadtree<int>(new Aabb(-8f, -8f, 8f, 8f), capacity: 4);
            foreach (var p in points)
                tree.Insert((p.X, p.Y), p.Id);

            foreach (var (c, r) in new[] { ((0f, 0f), 2.5f), ((2f, 3f), 0.5f), ((-5f, -5f), 10f) }) {
                var actual = tree.QueryRadius(c, r).OrderBy(x => x).ToList();
                CollectionAssert.AreEqual(BruteForceRadius(points, c, r), actual, $"radius {r} at ({c.Item1},{c.Item2})");
            }
        }

        [TestMethod]
        public void Quadtree_Clear_Empties() {
            var tree = new Quadtree<int>(new Aabb(0f, 0f, 10f, 10f), capacity: 2);
            for (int i = 0; i < 20; i++)
                tree.Insert((i % 10, i % 10), i); // forces subdivision

            tree.Clear();
            Assert.AreEqual(0, tree.Count);
            Assert.AreEqual(0, tree.Query(new Aabb(0f, 0f, 10f, 10f)).Count);
            Assert.IsTrue(tree.Insert((1f, 1f), 99)); // usable again
            Assert.AreEqual(1, tree.Count);
        }

        [TestMethod]
        public void Quadtree_InvalidConstruction_Throws() {
            var b = new Aabb(0f, 0f, 1f, 1f);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Quadtree<int>(b, capacity: 0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Quadtree<int>(b, maxDepth: -1));
        }

        #endregion Quadtree

        #region SpatialHash

        [TestMethod]
        public void SpatialHash_RegionQuery_MatchesBruteForce_AcrossOrigin() {
            var points = BuildPoints();
            var hash = new SpatialHash<int>(cellSize: 2.5f);
            foreach (var p in points)
                hash.Insert((p.X, p.Y), p.Id);

            Assert.AreEqual(points.Count, hash.Count);

            var regions = new[] {
                new Aabb(-3f, -3f, 3f, 3f),        // straddles the origin (negative cells)
                new Aabb(1.5f, 2.5f, 2.5f, 3.5f),
                new Aabb(-8f, -8f, 8f, 8f),
            };

            foreach (var region in regions) {
                var actual = hash.Query(region).OrderBy(x => x).ToList();
                CollectionAssert.AreEqual(BruteForceRegion(points, region), actual, $"region {region}");
            }
        }

        [TestMethod]
        public void SpatialHash_RadiusQuery_MatchesBruteForce() {
            var points = BuildPoints();
            var hash = new SpatialHash<int>(cellSize: 1.0f);
            foreach (var p in points)
                hash.Insert((p.X, p.Y), p.Id);

            foreach (var (c, r) in new[] { ((0f, 0f), 2.5f), ((2f, 3f), 0.5f), ((-4f, 6f), 3f) }) {
                var actual = hash.QueryRadius(c, r).OrderBy(x => x).ToList();
                CollectionAssert.AreEqual(BruteForceRadius(points, c, r), actual, $"radius {r} at ({c.Item1},{c.Item2})");
            }
        }

        [TestMethod]
        public void SpatialHash_Remove_Works() {
            var hash = new SpatialHash<string>(cellSize: 1f);
            hash.Insert((1.2f, 1.2f), "a");
            hash.Insert((1.3f, 1.4f), "b"); // same cell as "a"
            Assert.AreEqual(2, hash.Count);

            Assert.IsTrue(hash.Remove((1.2f, 1.2f), "a"));
            Assert.AreEqual(1, hash.Count);
            Assert.IsFalse(hash.Remove((1.2f, 1.2f), "a"));        // already gone
            Assert.IsFalse(hash.Remove((50f, 50f), "b"));          // empty cell
            CollectionAssert.AreEqual(new[] { "b" }, hash.Query(new Aabb(0f, 0f, 2f, 2f)));
        }

        [TestMethod]
        public void SpatialHash_Clear_Empties() {
            var hash = new SpatialHash<int>(cellSize: 1f);
            for (int i = 0; i < 10; i++)
                hash.Insert((i, i), i);

            hash.Clear();
            Assert.AreEqual(0, hash.Count);
            Assert.AreEqual(0, hash.Query(new Aabb(-100f, -100f, 100f, 100f)).Count);
        }

        [TestMethod]
        public void SpatialHash_InvalidCellSize_Throws() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new SpatialHash<int>(0f));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new SpatialHash<int>(-1f));
        }

        #endregion SpatialHash

        #region Nearest neighbor

        // The sorted distances of the k points nearest to c, computed by a full scan.
        private static List<float> BruteForceNearestDistances(List<(float X, float Y, int Id)> points, (float X, float Y) c, int k) =>
            points.Select(p => { float dx = p.X - c.X, dy = p.Y - c.Y; return dx * dx + dy * dy; })
                  .OrderBy(d => d).Take(k).ToList();

        // The sorted distances of the returned ids, for comparison (robust to tie ordering).
        private static List<float> DistancesOf(List<(float X, float Y, int Id)> points, IEnumerable<int> ids, (float X, float Y) c) =>
            ids.Select(id => { var p = points[id]; float dx = p.X - c.X, dy = p.Y - c.Y; return dx * dx + dy * dy; })
               .OrderBy(d => d).ToList();

        [TestMethod]
        public void Quadtree_Nearest_MatchesBruteForce() {
            var points = BuildPoints();
            var tree = new Quadtree<int>(new Aabb(-8f, -8f, 8f, 8f), capacity: 4);
            foreach (var p in points)
                tree.Insert((p.X, p.Y), p.Id);

            foreach (var c in new[] { (0f, 0f), (2.05f, 2.95f), (-6f, 6f), (100f, 100f) }) {
                foreach (int k in new[] { 1, 5, 25 }) {
                    List<int> got = tree.Nearest(c, k);
                    // Returned closest-first.
                    var dists = DistancesOf(points, got, c);
                    for (int i = 1; i < dists.Count; i++)
                        Assert.IsTrue(dists[i] >= dists[i - 1], "not ordered closest-first");
                    CollectionAssert.AreEqual(BruteForceNearestDistances(points, c, k), dists, $"k={k} at ({c.Item1},{c.Item2})");
                }
            }
        }

        [TestMethod]
        public void Quadtree_TryNearest_And_Empty() {
            var tree = new Quadtree<string>(new Aabb(0f, 0f, 10f, 10f));
            Assert.IsFalse(tree.TryNearest((5f, 5f), out _)); // empty

            tree.Insert((1f, 1f), "a");
            tree.Insert((9f, 9f), "b");
            Assert.IsTrue(tree.TryNearest((0f, 0f), out string nearest));
            Assert.AreEqual("a", nearest);
        }

        [TestMethod]
        public void SpatialHash_Nearest_MatchesBruteForce() {
            var points = BuildPoints();
            var hash = new SpatialHash<int>(cellSize: 1.5f);
            foreach (var p in points)
                hash.Insert((p.X, p.Y), p.Id);

            foreach (var c in new[] { (0f, 0f), (2.05f, 2.95f), (-6f, 6f), (100f, 100f) }) {
                foreach (int k in new[] { 1, 5, 25 }) {
                    List<int> got = hash.Nearest(c, k);
                    var dists = DistancesOf(points, got, c);
                    for (int i = 1; i < dists.Count; i++)
                        Assert.IsTrue(dists[i] >= dists[i - 1], "not ordered closest-first");
                    CollectionAssert.AreEqual(BruteForceNearestDistances(points, c, k), dists, $"k={k} at ({c.Item1},{c.Item2})");
                }
            }
        }

        [TestMethod]
        public void SpatialHash_TryNearest_And_Empty() {
            var hash = new SpatialHash<string>(cellSize: 2f);
            Assert.IsFalse(hash.TryNearest((5f, 5f), out _));

            hash.Insert((1f, 1f), "a");
            hash.Insert((9f, 9f), "b");
            Assert.IsTrue(hash.TryNearest((0f, 0f), out string nearest));
            Assert.AreEqual("a", nearest);
        }

        [TestMethod]
        public void Nearest_InvalidCount_Throws() {
            var tree = new Quadtree<int>(new Aabb(0f, 0f, 1f, 1f));
            var hash = new SpatialHash<int>(1f);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => tree.Nearest((0f, 0f), 0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => hash.Nearest((0f, 0f), -1));
        }

        #endregion Nearest neighbor
    }
}
