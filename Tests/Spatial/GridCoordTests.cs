using BeeneticToolkit.Spatial;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BeeneticToolkit.Tests.Spatial {

    [TestClass]
    public class GridCoordTests {

        [TestMethod]
        public void Arithmetic_Works() {
            Assert.AreEqual(new GridCoord(4, 2), new GridCoord(1, 3) + new GridCoord(3, -1));
            Assert.AreEqual(new GridCoord(-2, 4), new GridCoord(1, 3) - new GridCoord(3, -1));
            Assert.AreEqual(new GridCoord(2, 6), new GridCoord(1, 3) * 2);
        }

        [TestMethod]
        public void Distances_StaticAndInstance() {
            var a = new GridCoord(0, 0);
            var b = new GridCoord(2, 3);
            Assert.AreEqual(5, GridCoord.Manhattan(a, b));
            Assert.AreEqual(3, GridCoord.Chebyshev(a, b));
            Assert.AreEqual(5, a.ManhattanDistanceTo(b));
            Assert.AreEqual(3, a.ChebyshevDistanceTo(b));
        }

        [TestMethod]
        public void Neighbors_AreAdjacent() {
            var c = new GridCoord(5, 5);

            var four = c.Neighbors();
            Assert.AreEqual(4, four.Length);
            Assert.IsTrue(four.All(n => c.ManhattanDistanceTo(n) == 1));

            var diag = c.DiagonalNeighbors();
            Assert.AreEqual(4, diag.Length);
            Assert.IsTrue(diag.All(n => c.ChebyshevDistanceTo(n) == 1 && c.ManhattanDistanceTo(n) == 2));

            var eight = c.Neighbors8();
            Assert.AreEqual(8, eight.Length);
            Assert.IsTrue(eight.All(n => c.ChebyshevDistanceTo(n) == 1));
            Assert.AreEqual(8, eight.Distinct().Count());
        }

        [TestMethod]
        public void Direction_Wraps() {
            Assert.AreEqual(GridCoord.Direction(0), GridCoord.Direction(4));
            Assert.AreEqual(GridCoord.Direction(3), GridCoord.Direction(-1));
            Assert.AreEqual(new GridCoord(7, 5), new GridCoord(6, 5).Neighbor(0)); // east
        }

        [TestMethod]
        public void Line_Endpoints_And_Contiguity() {
            var a = new GridCoord(0, 0);
            var b = new GridCoord(5, 2);
            var line = GridCoord.Line(a, b);

            Assert.AreEqual(a, line[0]);
            Assert.AreEqual(b, line[line.Count - 1]);
            for (int i = 1; i < line.Count; i++)
                Assert.AreEqual(1, line[i - 1].ChebyshevDistanceTo(line[i]), $"step {i} not adjacent");

            CollectionAssert.AreEqual(
                new[] { new GridCoord(0, 0), new GridCoord(1, 1), new GridCoord(2, 2), new GridCoord(3, 3) },
                GridCoord.Line(new GridCoord(0, 0), new GridCoord(3, 3)));
            Assert.AreEqual(4, GridCoord.Line(new GridCoord(0, 0), new GridCoord(3, 0)).Count); // horizontal
        }

        [TestMethod]
        public void Range_Manhattan_IsDiamond() {
            var c = new GridCoord(2, -1);
            for (int r = 0; r <= 4; r++) {
                var range = c.Range(r, GridMetric.Manhattan);
                Assert.AreEqual(2 * r * r + 2 * r + 1, range.Count, $"diamond count r={r}");
                Assert.IsTrue(range.All(g => c.ManhattanDistanceTo(g) <= r));
                Assert.IsTrue(range.Contains(c));
            }
        }

        [TestMethod]
        public void Range_Chebyshev_IsSquare() {
            var c = new GridCoord(0, 0);
            for (int r = 0; r <= 4; r++) {
                var range = c.Range(r, GridMetric.Chebyshev);
                Assert.AreEqual((2 * r + 1) * (2 * r + 1), range.Count, $"square count r={r}");
                Assert.IsTrue(range.All(g => c.ChebyshevDistanceTo(g) <= r));
            }
        }

        [TestMethod]
        public void Ring_Counts_And_Membership() {
            var c = new GridCoord(-3, 4);
            Assert.AreEqual(1, c.Ring(0, GridMetric.Manhattan).Count);

            for (int r = 1; r <= 4; r++) {
                var diamond = c.Ring(r, GridMetric.Manhattan);
                Assert.AreEqual(4 * r, diamond.Count, $"manhattan ring r={r}");
                Assert.IsTrue(diamond.All(g => c.ManhattanDistanceTo(g) == r));

                var square = c.Ring(r, GridMetric.Chebyshev);
                Assert.AreEqual(8 * r, square.Count, $"chebyshev ring r={r}");
                Assert.IsTrue(square.All(g => c.ChebyshevDistanceTo(g) == r));
            }
        }

        [TestMethod]
        public void Range_And_Ring_Negative_Throw() {
            var c = new GridCoord(0, 0);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => c.Range(-1, GridMetric.Manhattan));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => c.Ring(-1, GridMetric.Chebyshev));
        }
    }
}
