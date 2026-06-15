using BeeneticToolkit.Spatial;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BeeneticToolkit.Tests.Spatial {

    [TestClass]
    public class HexTests {

        [TestMethod]
        public void CubeConstraint_Holds() {
            var h = new Hex(3, -5);
            Assert.AreEqual(-(h.Q + h.R), h.S);
            Assert.AreEqual(0, h.Q + h.R + h.S);
        }

        [TestMethod]
        public void FromCube_ValidatesSumZero() {
            Assert.AreEqual(new Hex(2, 4), Hex.FromCube(2, -6, 4)); // q=2, r=4, y=-6 = -(2+4)
            Assert.ThrowsException<ArgumentException>(() => Hex.FromCube(1, 1, 1));
        }

        [TestMethod]
        public void Arithmetic_Works() {
            Assert.AreEqual(new Hex(4, -6), new Hex(1, -3) + new Hex(3, -3));
            Assert.AreEqual(new Hex(-2, 0), new Hex(1, -3) - new Hex(3, -3));
            Assert.AreEqual(new Hex(2, -6), new Hex(1, -3) * 2);
        }

        [TestMethod]
        public void Distance_IsCorrect() {
            Assert.AreEqual(7, new Hex(3, 4).Length);                 // (|3|+|4|+|7|)/2
            Assert.AreEqual(7, Hex.Distance(new Hex(3, 4), new Hex(0, 0)));
            Assert.AreEqual(0, new Hex(5, -2).DistanceTo(new Hex(5, -2)));
        }

        [TestMethod]
        public void Neighbors_AreAdjacent() {
            var center = new Hex(2, -1);
            var neighbors = center.Neighbors();
            Assert.AreEqual(6, neighbors.Length);
            Assert.IsTrue(neighbors.All(n => center.DistanceTo(n) == 1));
            Assert.AreEqual(center + Hex.Direction(2), center.Neighbor(2));
            // Direction index wraps.
            Assert.AreEqual(Hex.Direction(0), Hex.Direction(6));
            Assert.AreEqual(Hex.Direction(5), Hex.Direction(-1));
        }

        [TestMethod]
        public void Diagonals_AreDistanceTwo() {
            var center = new Hex(0, 0);
            for (int i = 0; i < 6; i++)
                Assert.AreEqual(2, center.DistanceTo(center.DiagonalNeighbor(i)));
        }

        [TestMethod]
        public void Rotation_RoundTripsAndPreservesLength() {
            var h = new Hex(3, -2);

            Assert.AreEqual(h, h.RotateRight().RotateLeft());        // inverse
            var sixRight = h;
            for (int i = 0; i < 6; i++) sixRight = sixRight.RotateRight();
            Assert.AreEqual(h, sixRight);                            // 6 × 60° = identity
            Assert.AreEqual(h.Length, h.RotateRight().Length);       // rotation preserves ring
        }

        [TestMethod]
        public void Rotation_AroundCenter() {
            var center = new Hex(5, 5);
            var h = new Hex(6, 5); // a neighbor of center
            Assert.AreEqual(1, center.DistanceTo(h.RotateRight(center)));
        }

        [TestMethod]
        public void Range_HasExpectedCountAndMembership() {
            var center = new Hex(1, 2);
            for (int n = 0; n <= 4; n++) {
                var range = center.Range(n);
                Assert.AreEqual(3 * n * n + 3 * n + 1, range.Count, $"range count for n={n}");
                Assert.IsTrue(range.All(h => center.DistanceTo(h) <= n));
                Assert.IsTrue(range.Contains(center));
            }
        }

        [TestMethod]
        public void Ring_HasExpectedCountAndRadius() {
            var center = new Hex(-2, 3);
            Assert.AreEqual(1, center.Ring(0).Count);
            for (int n = 1; n <= 4; n++) {
                var ring = center.Ring(n);
                Assert.AreEqual(6 * n, ring.Count, $"ring count for n={n}");
                Assert.IsTrue(ring.All(h => center.DistanceTo(h) == n));
            }
        }

        [TestMethod]
        public void Spiral_MatchesRangeMembership() {
            var center = new Hex(0, 0);
            var spiral = center.Spiral(3);
            Assert.AreEqual(center, spiral[0]);
            CollectionAssert.AreEquivalent(center.Range(3), spiral);  // same set, spiral is ordered
        }

        [TestMethod]
        public void Line_IsContiguousBetweenEndpoints() {
            var a = new Hex(0, 0);
            var b = new Hex(1, -5); // cube (1,4,-5) -> distance 5
            var line = Hex.Line(a, b);

            Assert.AreEqual(a.DistanceTo(b) + 1, line.Count);
            Assert.AreEqual(a, line[0]);
            Assert.AreEqual(b, line[line.Count - 1]);
            for (int i = 1; i < line.Count; i++)
                Assert.AreEqual(1, line[i - 1].DistanceTo(line[i]), $"step {i} not adjacent");
        }

        [TestMethod]
        public void FractionalHex_RoundsToNearestValidHex() {
            Assert.AreEqual(new Hex(0, 0), new FractionalHex(0.2, -0.1).Round());
            var rounded = new FractionalHex(1.6, -2.4).Round();
            Assert.AreEqual(0, rounded.Q + rounded.R + rounded.S);   // stays a valid cube
        }

        [TestMethod]
        public void OffsetCoord_RoundTrips_AllLayouts_IncludingNegatives() {
            foreach (OffsetLayout layout in Enum.GetValues(typeof(OffsetLayout))) {
                for (int q = -4; q <= 4; q++) {
                    for (int r = -4; r <= 4; r++) {
                        var hex = new Hex(q, r);
                        var offset = OffsetCoord.FromHex(hex, layout);
                        Assert.AreEqual(hex, offset.ToHex(layout), $"{layout} round-trip failed at {hex}");
                    }
                }
            }
        }

        [TestMethod]
        public void HexLayout_PixelRoundTrip_BothOrientations() {
            var layouts = new[] {
                new HexLayout(HexOrientation.Pointy, (10f, 10f), (0f, 0f)),
                new HexLayout(HexOrientation.Flat, (12f, 8f), (5f, -3f)),
            };

            foreach (var layout in layouts) {
                for (int q = -3; q <= 3; q++) {
                    for (int r = -3; r <= 3; r++) {
                        var hex = new Hex(q, r);
                        Assert.AreEqual(hex, layout.PixelToHex(layout.ToPixel(hex)), $"pixel round-trip failed at {hex}");
                    }
                }
            }
        }

        [TestMethod]
        public void HexLayout_PolygonHasSixCorners() {
            var layout = new HexLayout(HexOrientation.Pointy, (10f, 10f), (0f, 0f));
            var corners = layout.PolygonCorners(new Hex(0, 0));
            Assert.AreEqual(6, corners.Length);
        }

        [TestMethod]
        public void Equality_And_HashCode() {
            Assert.AreEqual(new Hex(2, -3), new Hex(2, -3));
            Assert.AreEqual(new Hex(2, -3).GetHashCode(), new Hex(2, -3).GetHashCode());
            Assert.AreNotEqual(new Hex(2, -3), new Hex(-3, 2));
            Assert.IsTrue(new Hex(1, 1) == new Hex(1, 1));
            Assert.IsTrue(new Hex(1, 1) != new Hex(1, 2));
        }
    }
}
