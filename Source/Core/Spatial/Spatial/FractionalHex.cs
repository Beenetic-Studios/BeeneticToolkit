using System;

namespace BeeneticToolkit.Spatial {

    /// <summary>
    /// A continuous (floating-point) hex coordinate, used as an intermediate when interpolating along a line or
    /// converting from pixel space. Call <see cref="Round"/> to snap to the nearest whole <see cref="Hex"/>.
    /// </summary>
    public readonly struct FractionalHex {

        /// <summary>The fractional axial Q coordinate (cube X).</summary>
        public double Q { get; }

        /// <summary>The fractional axial R coordinate (cube Z).</summary>
        public double R { get; }

        /// <summary>The derived fractional cube S coordinate (<c>-Q - R</c>; cube Y).</summary>
        public double S => -Q - R;

        /// <summary>Creates a fractional hex from axial coordinates.</summary>
        public FractionalHex(double q, double r) {
            Q = q;
            R = r;
        }

        /// <summary>Rounds to the nearest whole <see cref="Hex"/>, preserving the cube constraint.</summary>
        public Hex Round() {
            int q = (int)Math.Round(Q);
            int r = (int)Math.Round(R);
            int s = (int)Math.Round(S);

            double qDiff = Math.Abs(q - Q);
            double rDiff = Math.Abs(r - R);
            double sDiff = Math.Abs(s - S);

            // Reset whichever coordinate drifted most, recomputing it from the other two so q + r + s stays 0.
            if (qDiff > rDiff && qDiff > sDiff)
                q = -r - s;
            else if (rDiff > sDiff)
                r = -q - s;

            return new Hex(q, r);
        }

        /// <summary>Linearly interpolates between two fractional hexes.</summary>
        /// <param name="a">The start.</param>
        /// <param name="b">The end.</param>
        /// <param name="t">The interpolation factor (0 returns <paramref name="a"/>, 1 returns <paramref name="b"/>).</param>
        public static FractionalHex Lerp(FractionalHex a, FractionalHex b, double t) =>
            new FractionalHex(a.Q + (b.Q - a.Q) * t, a.R + (b.R - a.R) * t);
    }
}
