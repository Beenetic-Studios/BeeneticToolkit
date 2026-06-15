using System;

namespace BeeneticToolkit.Spatial {

    /// <summary>
    /// The forward/inverse matrices and starting corner angle for one hex orientation. Use the
    /// <see cref="Pointy"/> or <see cref="Flat"/> presets.
    /// </summary>
    public readonly struct HexOrientation {

        /// <summary>Forward matrix component (hex → pixel).</summary>
        public double F0 { get; }
        /// <summary>Forward matrix component (hex → pixel).</summary>
        public double F1 { get; }
        /// <summary>Forward matrix component (hex → pixel).</summary>
        public double F2 { get; }
        /// <summary>Forward matrix component (hex → pixel).</summary>
        public double F3 { get; }
        /// <summary>Inverse matrix component (pixel → hex).</summary>
        public double B0 { get; }
        /// <summary>Inverse matrix component (pixel → hex).</summary>
        public double B1 { get; }
        /// <summary>Inverse matrix component (pixel → hex).</summary>
        public double B2 { get; }
        /// <summary>Inverse matrix component (pixel → hex).</summary>
        public double B3 { get; }
        /// <summary>Corner start angle, in multiples of 60° (0.5 = pointy-top, 0 = flat-top).</summary>
        public double StartAngle { get; }

        private HexOrientation(double f0, double f1, double f2, double f3, double b0, double b1, double b2, double b3, double startAngle) {
            F0 = f0; F1 = f1; F2 = f2; F3 = f3;
            B0 = b0; B1 = b1; B2 = b2; B3 = b3;
            StartAngle = startAngle;
        }

        private static readonly double Sqrt3 = Math.Sqrt(3.0);

        /// <summary>Pointy-top orientation (hexes have a vertex at top).</summary>
        public static readonly HexOrientation Pointy = new HexOrientation(
            Sqrt3, Sqrt3 / 2.0, 0.0, 3.0 / 2.0,
            Sqrt3 / 3.0, -1.0 / 3.0, 0.0, 2.0 / 3.0,
            0.5);

        /// <summary>Flat-top orientation (hexes have an edge at top).</summary>
        public static readonly HexOrientation Flat = new HexOrientation(
            3.0 / 2.0, 0.0, Sqrt3 / 2.0, Sqrt3,
            2.0 / 3.0, 0.0, -1.0 / 3.0, Sqrt3 / 3.0,
            0.0);
    }

    /// <summary>
    /// Maps hexes to and from pixel/world space, given an orientation, a hex size, and an origin. Pixel positions
    /// are plain <c>(float X, float Y)</c> tuples so this stays free of any engine-specific vector type — convert
    /// to your <c>Vector2</c> at the call site.
    /// </summary>
    public readonly struct HexLayout {

        /// <summary>The orientation (pointy- or flat-top).</summary>
        public HexOrientation Orientation { get; }

        /// <summary>The hex size (radius) along each axis.</summary>
        public (float X, float Y) Size { get; }

        /// <summary>The pixel-space position of the origin hex (0, 0).</summary>
        public (float X, float Y) Origin { get; }

        /// <summary>Creates a layout from an orientation, size, and origin.</summary>
        public HexLayout(HexOrientation orientation, (float X, float Y) size, (float X, float Y) origin) {
            Orientation = orientation;
            Size = size;
            Origin = origin;
        }

        /// <summary>Returns the pixel-space center of a hex.</summary>
        public (float X, float Y) ToPixel(Hex hex) {
            HexOrientation m = Orientation;
            double x = (m.F0 * hex.Q + m.F1 * hex.R) * Size.X;
            double y = (m.F2 * hex.Q + m.F3 * hex.R) * Size.Y;
            return ((float)(x + Origin.X), (float)(y + Origin.Y));
        }

        /// <summary>Converts a pixel-space point to a fractional hex (call <see cref="FractionalHex.Round"/> to snap).</summary>
        public FractionalHex ToFractionalHex((float X, float Y) point) {
            HexOrientation m = Orientation;
            double x = (point.X - Origin.X) / Size.X;
            double y = (point.Y - Origin.Y) / Size.Y;
            double q = m.B0 * x + m.B1 * y;
            double r = m.B2 * x + m.B3 * y;
            return new FractionalHex(q, r);
        }

        /// <summary>Converts a pixel-space point to the hex containing it.</summary>
        public Hex PixelToHex((float X, float Y) point) => ToFractionalHex(point).Round();

        /// <summary>Returns the pixel offset, relative to a hex center, of the given corner (0–5).</summary>
        public (float X, float Y) CornerOffset(int corner) {
            double angle = 2.0 * Math.PI * (Orientation.StartAngle + corner) / 6.0;
            return ((float)(Size.X * Math.Cos(angle)), (float)(Size.Y * Math.Sin(angle)));
        }

        /// <summary>Returns the six pixel-space corners of a hex, for drawing its outline.</summary>
        public (float X, float Y)[] PolygonCorners(Hex hex) {
            var corners = new (float X, float Y)[6];
            (float cx, float cy) = ToPixel(hex);
            for (int i = 0; i < 6; i++) {
                (float ox, float oy) = CornerOffset(i);
                corners[i] = (cx + ox, cy + oy);
            }

            return corners;
        }
    }
}
