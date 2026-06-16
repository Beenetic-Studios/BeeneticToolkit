using BeeneticToolkit.Spatial;
using BeeneticToolkit.Spatial.Pathfinding;
using BeeneticToolkit.Spatial.Visibility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Tests.Spatial {

    [TestClass]
    public class VisibilityTests {

        #region Grid field of view

        [TestMethod]
        public void GridFov_OpenField_SeesFullDisk() {
            var origin = new GridCoord(0, 0);
            const int radius = 4;
            HashSet<GridCoord> visible = GridFieldOfView.Compute(origin, radius, _ => false);

            var expected = new HashSet<GridCoord>();
            for (int x = -radius; x <= radius; x++)
                for (int y = -radius; y <= radius; y++)
                    if (x * x + y * y <= radius * radius)
                        expected.Add(new GridCoord(x, y));

            CollectionAssert.AreEquivalent(expected.ToList(), visible.ToList());
        }

        [TestMethod]
        public void GridFov_RadiusZero_OnlyOrigin() {
            var origin = new GridCoord(3, 7);
            HashSet<GridCoord> visible = GridFieldOfView.Compute(origin, 0, _ => false);

            Assert.AreEqual(1, visible.Count);
            Assert.IsTrue(visible.Contains(origin));
        }

        [TestMethod]
        public void GridFov_WallCastsShadow() {
            // A vertical wall segment at x = 2 spanning y = -1..1.
            var wall = new HashSet<GridCoord> { new GridCoord(2, -1), new GridCoord(2, 0), new GridCoord(2, 1) };
            var origin = new GridCoord(0, 0);
            HashSet<GridCoord> visible = GridFieldOfView.Compute(origin, 6, c => wall.Contains(c));

            Assert.IsTrue(visible.Contains(origin));                    // viewer sees itself
            Assert.IsTrue(visible.Contains(new GridCoord(2, 0)));       // the wall face is visible
            Assert.IsFalse(visible.Contains(new GridCoord(4, 0)));      // directly behind the wall: shadowed
            Assert.IsFalse(visible.Contains(new GridCoord(5, 0)));

            HashSet<GridCoord> open = GridFieldOfView.Compute(origin, 6, _ => false);
            Assert.IsTrue(visible.Count < open.Count);                  // the wall hides something
        }

        [TestMethod]
        public void GridFov_NullAndNegative_Throw() {
            var origin = new GridCoord(0, 0);
            Assert.ThrowsException<ArgumentNullException>(() => GridFieldOfView.Compute(origin, 3, null!));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GridFieldOfView.Compute(origin, -1, _ => false));
        }

        #endregion Grid field of view

        #region Hex field of view

        [TestMethod]
        public void HexFov_OpenField_EqualsRange() {
            var origin = new Hex(1, -2);
            const int radius = 3;
            HashSet<Hex> visible = HexFieldOfView.Compute(origin, radius, _ => false);

            CollectionAssert.AreEquivalent(origin.Range(radius), visible.ToList());
        }

        [TestMethod]
        public void HexFov_RadiusZero_OnlyOrigin() {
            var origin = new Hex(0, 0);
            HashSet<Hex> visible = HexFieldOfView.Compute(origin, 0, _ => false);

            Assert.AreEqual(1, visible.Count);
            Assert.IsTrue(visible.Contains(origin));
        }

        [TestMethod]
        public void HexFov_WallBlocksHexesBehindIt() {
            var blocker = new Hex(1, 0);
            var origin = new Hex(0, 0);
            HashSet<Hex> visible = HexFieldOfView.Compute(origin, 4, h => h == blocker);

            Assert.IsTrue(visible.Contains(origin));
            Assert.IsTrue(visible.Contains(blocker));                   // the wall hex itself is seen
            Assert.IsFalse(visible.Contains(new Hex(3, 0)));            // beyond the wall along the line
        }

        [TestMethod]
        public void HexFov_NullAndNegative_Throw() {
            var origin = new Hex(0, 0);
            Assert.ThrowsException<ArgumentNullException>(() => HexFieldOfView.Compute(origin, 3, null!));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => HexFieldOfView.Compute(origin, -1, _ => false));
        }

        #endregion Hex field of view
    }
}
