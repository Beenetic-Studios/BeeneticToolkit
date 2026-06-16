using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Spatial.Visibility {

    /// <summary>
    /// Computes a square-grid field of view with recursive shadowcasting: given a viewer, a sight radius, and a
    /// "does this cell block light" test, it returns every cell the viewer can see. The classic roguelike
    /// algorithm — symmetric, artifact-free, and O(cells in radius).
    /// </summary>
    /// <remarks>
    /// The viewer's own cell is always visible. A blocking cell is itself visible (you see the wall face) but
    /// hides whatever is behind it. Visibility is circular: a cell counts as in range when its squared offset is
    /// within <c>radius²</c>.
    /// </remarks>
    public static class GridFieldOfView {

        // Per-octant transforms (xx, xy, yx, yy) that map local shadowcasting space into grid offsets.
        private static readonly int[] Xx = { 1, 0, 0, -1, -1, 0, 0, 1 };
        private static readonly int[] Xy = { 0, 1, -1, 0, 0, -1, 1, 0 };
        private static readonly int[] Yx = { 0, 1, 1, 0, 0, -1, -1, 0 };
        private static readonly int[] Yy = { 1, 0, 0, 1, -1, 0, 0, -1 };

        /// <summary>
        /// Returns the set of cells visible from <paramref name="origin"/> within <paramref name="radius"/>.
        /// </summary>
        /// <param name="origin">The viewer's cell.</param>
        /// <param name="radius">The sight radius (in cells). Must be non-negative.</param>
        /// <param name="blocksLight">Returns whether a cell blocks line of sight (e.g. a wall).</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="blocksLight"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="radius"/> is negative.</exception>
        public static HashSet<GridCoord> Compute(GridCoord origin, int radius, Func<GridCoord, bool> blocksLight) {
            var visible = new HashSet<GridCoord>();
            Compute(origin, radius, blocksLight, c => visible.Add(c));
            return visible;
        }

        /// <summary>
        /// Invokes <paramref name="onVisible"/> for every cell visible from <paramref name="origin"/> within
        /// <paramref name="radius"/> (allocation-free).
        /// </summary>
        /// <remarks>
        /// Cells on octant seams (the axes and diagonals) may be reported more than once; deduplicate downstream if
        /// that matters, or use the <see cref="Compute(GridCoord, int, Func{GridCoord, bool})"/> overload.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="blocksLight"/> or <paramref name="onVisible"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="radius"/> is negative.</exception>
        public static void Compute(GridCoord origin, int radius, Func<GridCoord, bool> blocksLight, Action<GridCoord> onVisible) {
            if (blocksLight is null)
                throw new ArgumentNullException(nameof(blocksLight));
            if (onVisible is null)
                throw new ArgumentNullException(nameof(onVisible));
            if (radius < 0)
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be non-negative.");

            onVisible(origin); // the viewer always sees their own cell
            for (int octant = 0; octant < 8; octant++)
                CastLight(origin, radius, 1, 1.0, 0.0, Xx[octant], Xy[octant], Yx[octant], Yy[octant], blocksLight, onVisible);
        }

        private static void CastLight(
            GridCoord origin, int radius, int row, double startSlope, double endSlope,
            int xx, int xy, int yx, int yy, Func<GridCoord, bool> blocksLight, Action<GridCoord> onVisible) {

            if (startSlope < endSlope)
                return;

            int radiusSq = radius * radius;
            double nextStartSlope = startSlope;
            bool blocked = false;

            for (int distance = row; distance <= radius && !blocked; distance++) {
                int dy = -distance;
                for (int dx = -distance; dx <= 0; dx++) {
                    double leftSlope = (dx - 0.5) / (dy + 0.5);
                    double rightSlope = (dx + 0.5) / (dy - 0.5);

                    if (startSlope < rightSlope)
                        continue;
                    if (endSlope > leftSlope)
                        break;

                    int mapX = origin.X + dx * xx + dy * xy;
                    int mapY = origin.Y + dx * yx + dy * yy;
                    var cell = new GridCoord(mapX, mapY);

                    if (dx * dx + dy * dy <= radiusSq)
                        onVisible(cell);

                    bool cellBlocks = blocksLight(cell);
                    if (blocked) {
                        if (cellBlocks) {
                            nextStartSlope = rightSlope;
                            continue;
                        }

                        blocked = false;
                        startSlope = nextStartSlope;
                    } else if (cellBlocks && distance < radius) {
                        blocked = true;
                        CastLight(origin, radius, distance + 1, startSlope, leftSlope, xx, xy, yx, yy, blocksLight, onVisible);
                        nextStartSlope = rightSlope;
                    }
                }
            }
        }
    }
}
