using System;
using System.Collections.Generic;

namespace BeeneticToolkit.Spatial.Visibility {

    /// <summary>
    /// Computes a hex-grid field of view by line of sight: a hex is visible when the straight <see cref="Hex.Line"/>
    /// from the viewer to it is not interrupted by a blocker before it arrives. Simple and predictable — the common
    /// approach for hex tactics/strategy games — though, like all single-ray FOV, it is not perfectly symmetric in
    /// pathological wall arrangements.
    /// </summary>
    /// <remarks>
    /// The viewer's own hex is always visible. A blocking hex is itself visible (you see its near face) but hides
    /// hexes beyond it along the ray.
    /// </remarks>
    public static class HexFieldOfView {

        /// <summary>
        /// Returns the set of hexes visible from <paramref name="origin"/> within <paramref name="radius"/> steps.
        /// </summary>
        /// <param name="origin">The viewer's hex.</param>
        /// <param name="radius">The sight radius (in hex steps). Must be non-negative.</param>
        /// <param name="blocksLight">Returns whether a hex blocks line of sight.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="blocksLight"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="radius"/> is negative.</exception>
        public static HashSet<Hex> Compute(Hex origin, int radius, Func<Hex, bool> blocksLight) {
            if (blocksLight is null)
                throw new ArgumentNullException(nameof(blocksLight));
            if (radius < 0)
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be non-negative.");

            var visible = new HashSet<Hex> { origin };
            foreach (Hex target in origin.Range(radius)) {
                if (IsVisible(origin, target, blocksLight))
                    visible.Add(target);
            }

            return visible;
        }

        /// <summary>
        /// Whether <paramref name="target"/> is visible from <paramref name="origin"/> — i.e. no hex strictly
        /// between them along the hex line blocks light. The endpoints themselves are not treated as blockers.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="blocksLight"/> is null.</exception>
        public static bool IsVisible(Hex origin, Hex target, Func<Hex, bool> blocksLight) {
            if (blocksLight is null)
                throw new ArgumentNullException(nameof(blocksLight));

            List<Hex> line = Hex.Line(origin, target);
            for (int i = 1; i < line.Count - 1; i++) {
                if (blocksLight(line[i]))
                    return false;
            }

            return true;
        }
    }
}
