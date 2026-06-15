using BeeneticToolkit.Spatial;
using BeeneticToolkit.Spatial.Pathfinding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeneticToolkit.Tests.Spatial {

    [TestClass]
    public class PathfindingTests {

        private const float Tolerance = 1e-4f;

        #region BreadthFirstSearch

        [TestMethod]
        public void Bfs_FindsFewestStepPath() {
            var grid = new GridGraph(5, 1);
            var result = Pathfinder.BreadthFirstSearch(grid, new GridCoord(0, 0), new GridCoord(4, 0));

            Assert.IsTrue(result.Found);
            Assert.AreEqual(5, result.Nodes.Count);
            Assert.AreEqual(new GridCoord(0, 0), result.Nodes[0]);
            Assert.AreEqual(new GridCoord(4, 0), result.Nodes[result.Nodes.Count - 1]);
            Assert.AreEqual(4f, result.Cost, Tolerance); // step count
        }

        [TestMethod]
        public void Bfs_IgnoresEdgeCost_UnlikeDijkstra() {
            // Center column is expensive; BFS still takes the short straight line, Dijkstra detours.
            float CostOf(GridCoord c) => c == new GridCoord(1, 0) ? 10f : 1f;
            var grid = new GridGraph(3, 3, GridConnectivity.FourWay, costOf: CostOf);
            var start = new GridCoord(0, 0);
            var goal = new GridCoord(2, 0);

            var bfs = Pathfinder.BreadthFirstSearch(grid, start, goal);
            Assert.AreEqual(3, bfs.Nodes.Count); // straight across, 2 steps
            Assert.IsTrue(bfs.Nodes.Contains(new GridCoord(1, 0)));

            var dijkstra = Pathfinder.Dijkstra(grid, start, goal);
            Assert.IsFalse(dijkstra.Nodes.Contains(new GridCoord(1, 0))); // routes around the costly cell
            Assert.AreEqual(4f, dijkstra.Cost, Tolerance);
        }

        [TestMethod]
        public void Bfs_StartEqualsGoal_ReturnsSingleNode() {
            var grid = new GridGraph(3, 3);
            var result = Pathfinder.BreadthFirstSearch(grid, new GridCoord(1, 1), new GridCoord(1, 1));

            Assert.IsTrue(result.Found);
            Assert.AreEqual(1, result.Nodes.Count);
            Assert.AreEqual(0f, result.Cost, Tolerance);
        }

        [TestMethod]
        public void Bfs_Unreachable_ReturnsFailure() {
            // Wall down column 1 splits the grid.
            bool Passable(GridCoord c) => c.X != 1;
            var grid = new GridGraph(3, 3, GridConnectivity.FourWay, Passable);
            var result = Pathfinder.BreadthFirstSearch(grid, new GridCoord(0, 0), new GridCoord(2, 2));

            Assert.IsFalse(result.Found);
            Assert.AreEqual(0, result.Nodes.Count);
            Assert.AreEqual(float.PositiveInfinity, result.Cost);
        }

        #endregion BreadthFirstSearch

        #region Dijkstra / A*

        [TestMethod]
        public void AStar_MatchesDijkstraCost_AndIsOptimal() {
            float CostOf(GridCoord c) => c == new GridCoord(1, 0) ? 10f : 1f;
            var grid = new GridGraph(3, 3, GridConnectivity.FourWay, costOf: CostOf);
            var start = new GridCoord(0, 0);
            var goal = new GridCoord(2, 0);

            var dijkstra = Pathfinder.Dijkstra(grid, start, goal);
            var astar = Pathfinder.AStar(grid, start, goal, grid.Heuristic);

            Assert.IsTrue(astar.Found);
            Assert.AreEqual(dijkstra.Cost, astar.Cost, Tolerance); // admissible heuristic -> optimal
        }

        [TestMethod]
        public void AStar_RoutesAroundObstacle() {
            // Wall across the middle row with a single gap at x = 2.
            bool Passable(GridCoord c) => !(c.Y == 1 && c.X != 2);
            var grid = new GridGraph(3, 3, GridConnectivity.FourWay, Passable);
            var start = new GridCoord(0, 0);
            var goal = new GridCoord(0, 2);

            var result = Pathfinder.AStar(grid, start, goal, grid.Heuristic);

            Assert.IsTrue(result.Found);
            Assert.IsTrue(result.Nodes.Contains(new GridCoord(2, 1))); // forced through the gap
            Assert.IsTrue(result.Nodes.All(grid.IsWalkable));
            // Every consecutive pair is adjacent.
            for (int i = 1; i < result.Nodes.Count; i++)
                Assert.AreEqual(1, GridCoord.Manhattan(result.Nodes[i - 1], result.Nodes[i]));
        }

        [TestMethod]
        public void AStar_NegativeCost_Throws() {
            var grid = new GridGraph(2, 1, GridConnectivity.FourWay, costOf: _ => -1f);
            Assert.ThrowsException<InvalidOperationException>(() =>
                Pathfinder.AStar(grid, new GridCoord(0, 0), new GridCoord(1, 0), grid.Heuristic));
        }

        #endregion Dijkstra / A*

        #region Eight-way connectivity

        [TestMethod]
        public void EightWay_DiagonalCornerCutting_Respected() {
            bool Passable(GridCoord c) => c != new GridCoord(1, 0);
            var start = new GridCoord(0, 0);
            var goal = new GridCoord(1, 1);

            var blocked = new GridGraph(2, 2, GridConnectivity.EightWay, Passable, allowDiagonalCornerCutting: false);
            var blockedPath = Pathfinder.AStar(blocked, start, goal, blocked.Heuristic);
            Assert.AreEqual(3, blockedPath.Nodes.Count); // must go around: (0,0)->(0,1)->(1,1)
            Assert.AreEqual(2f, blockedPath.Cost, Tolerance);

            var cutting = new GridGraph(2, 2, GridConnectivity.EightWay, Passable, allowDiagonalCornerCutting: true);
            var cutPath = Pathfinder.AStar(cutting, start, goal, cutting.Heuristic);
            Assert.AreEqual(2, cutPath.Nodes.Count); // diagonal straight through
            Assert.AreEqual((float)Math.Sqrt(2.0), cutPath.Cost, Tolerance);
        }

        #endregion Eight-way connectivity

        #region HexGraph

        [TestMethod]
        public void HexGraph_OpenField_PathLengthEqualsHexDistance() {
            var graph = new HexGraph();
            var start = new Hex(0, 0);
            var goal = new Hex(3, -1);

            var result = Pathfinder.AStar(graph, start, goal, graph.Heuristic);

            Assert.IsTrue(result.Found);
            Assert.AreEqual(start.DistanceTo(goal) + 1, result.Nodes.Count);
            Assert.AreEqual(start.DistanceTo(goal), result.Cost, Tolerance);
            for (int i = 1; i < result.Nodes.Count; i++)
                Assert.AreEqual(1, result.Nodes[i - 1].DistanceTo(result.Nodes[i]));
        }

        [TestMethod]
        public void HexGraph_RoutesAroundBlockedHex() {
            var blocked = new Hex(1, 0);
            var graph = new HexGraph(isPassable: h => h != blocked);
            var start = new Hex(0, 0);
            var goal = new Hex(2, 0);

            var result = Pathfinder.AStar(graph, start, goal, graph.Heuristic);

            Assert.IsTrue(result.Found);
            Assert.IsFalse(result.Nodes.Contains(blocked));
            Assert.AreEqual(3f, result.Cost, Tolerance); // detour costs one extra step
        }

        #endregion HexGraph

        #region FlowField

        [TestMethod]
        public void FlowField_CostsMatchDistance_AndPathReachesGoal() {
            var grid = new GridGraph(3, 3);
            var goal = new GridCoord(2, 2);
            var field = FlowField<GridCoord>.Compute(grid, new[] { goal });

            Assert.IsTrue(field.IsGoal(goal));
            Assert.IsTrue(field.TryGetCost(new GridCoord(0, 0), out float cost));
            Assert.AreEqual(4f, cost, Tolerance); // Manhattan distance on a 4-way grid
            Assert.IsFalse(field.TryGetNext(goal, out _)); // already at the goal

            var path = field.GetPath(new GridCoord(0, 0));
            Assert.IsTrue(path.Found);
            Assert.AreEqual(goal, path.Nodes[path.Nodes.Count - 1]);
            Assert.AreEqual(4f, path.Cost, Tolerance);
        }

        [TestMethod]
        public void FlowField_MultipleGoals_RoutesToNearest() {
            var grid = new GridGraph(5, 1);
            var field = FlowField<GridCoord>.Compute(grid, new[] { new GridCoord(0, 0), new GridCoord(4, 0) });

            // (1,0) is closer to goal (0,0); its path should end there.
            var path = field.GetPath(new GridCoord(1, 0));
            Assert.AreEqual(new GridCoord(0, 0), path.Nodes[path.Nodes.Count - 1]);
            Assert.AreEqual(1f, path.Cost, Tolerance);
        }

        [TestMethod]
        public void FlowField_Unreachable_IsExcluded() {
            // (0,0) is walled off from the rest of the grid.
            bool Passable(GridCoord c) => c != new GridCoord(0, 1) && c != new GridCoord(1, 0);
            var grid = new GridGraph(3, 3, GridConnectivity.FourWay, Passable);
            var field = FlowField<GridCoord>.Compute(grid, new[] { new GridCoord(2, 2) });

            Assert.IsFalse(field.IsReachable(new GridCoord(0, 0)));
            Assert.IsFalse(field.GetPath(new GridCoord(0, 0)).Found);
        }

        [TestMethod]
        public void FlowField_EmptyGoals_Throws() {
            var grid = new GridGraph(2, 2);
            Assert.ThrowsException<ArgumentException>(() =>
                FlowField<GridCoord>.Compute(grid, Array.Empty<GridCoord>()));
        }

        #endregion FlowField

        #region GridCoord / GridGraph basics

        [TestMethod]
        public void GridCoord_Equality_And_Distances() {
            Assert.AreEqual(new GridCoord(2, 3), new GridCoord(2, 3));
            Assert.IsTrue(new GridCoord(1, 1) != new GridCoord(1, 2));
            Assert.AreEqual(5, GridCoord.Manhattan(new GridCoord(0, 0), new GridCoord(2, 3)));
            Assert.AreEqual(3, GridCoord.Chebyshev(new GridCoord(0, 0), new GridCoord(2, 3)));
        }

        [TestMethod]
        public void GridGraph_RejectsNonPositiveSize() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new GridGraph(0, 5));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new GridGraph(5, -1));
        }

        [TestMethod]
        public void GridGraph_BoundsAndWalkability() {
            var grid = new GridGraph(3, 3, GridConnectivity.FourWay, c => c != new GridCoord(1, 1));
            Assert.IsTrue(grid.InBounds(new GridCoord(2, 2)));
            Assert.IsFalse(grid.InBounds(new GridCoord(3, 0)));
            Assert.IsFalse(grid.IsWalkable(new GridCoord(1, 1)));
            Assert.IsFalse(grid.IsWalkable(new GridCoord(-1, 0)));
        }

        #endregion GridCoord / GridGraph basics
    }
}
