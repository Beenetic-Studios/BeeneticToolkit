using System;

namespace BeeneticToolkit.Spatial {

    /// <summary>
    /// Identifies an offset-coordinate layout: pointy-top rows (<c>R</c>) or flat-top columns (<c>Q</c>), with the
    /// odd or even line shoved over by half a hex.
    /// </summary>
    public enum OffsetLayout {

        /// <summary>Pointy-top; odd rows shifted right.</summary>
        OddR,

        /// <summary>Pointy-top; even rows shifted right.</summary>
        EvenR,

        /// <summary>Flat-top; odd columns shifted down.</summary>
        OddQ,

        /// <summary>Flat-top; even columns shifted down.</summary>
        EvenQ,
    }

    /// <summary>
    /// A hex addressed by rectangular <see cref="Col"/>/<see cref="Row"/> offset coordinates — convenient for
    /// storing a hex map in a 2D array. Convert to and from the algorithm-friendly axial <see cref="Hex"/> with a
    /// chosen <see cref="OffsetLayout"/>.
    /// </summary>
    public readonly struct OffsetCoord : IEquatable<OffsetCoord> {

        /// <summary>The column.</summary>
        public int Col { get; }

        /// <summary>The row.</summary>
        public int Row { get; }

        /// <summary>Creates an offset coordinate.</summary>
        public OffsetCoord(int col, int row) {
            Col = col;
            Row = row;
        }

        /// <summary>Converts an axial <see cref="Hex"/> to offset coordinates under the given layout.</summary>
        public static OffsetCoord FromHex(Hex hex, OffsetLayout layout) {
            switch (layout) {
                case OffsetLayout.OddR: return RFromHex(hex, Odd);
                case OffsetLayout.EvenR: return RFromHex(hex, Even);
                case OffsetLayout.OddQ: return QFromHex(hex, Odd);
                case OffsetLayout.EvenQ: return QFromHex(hex, Even);
                default: throw new ArgumentOutOfRangeException(nameof(layout), layout, "Unknown offset layout.");
            }
        }

        /// <summary>Converts these offset coordinates to an axial <see cref="Hex"/> under the given layout.</summary>
        public Hex ToHex(OffsetLayout layout) {
            switch (layout) {
                case OffsetLayout.OddR: return RToHex(Odd);
                case OffsetLayout.EvenR: return RToHex(Even);
                case OffsetLayout.OddQ: return QToHex(Odd);
                case OffsetLayout.EvenQ: return QToHex(Even);
                default: throw new ArgumentOutOfRangeException(nameof(layout), layout, "Unknown offset layout.");
            }
        }

        private const int Even = 1;
        private const int Odd = -1;

        private static OffsetCoord RFromHex(Hex h, int offset) =>
            new OffsetCoord(h.Q + (h.R + offset * (h.R & 1)) / 2, h.R);

        private Hex RToHex(int offset) =>
            new Hex(Col - (Row + offset * (Row & 1)) / 2, Row);

        private static OffsetCoord QFromHex(Hex h, int offset) =>
            new OffsetCoord(h.Q, h.R + (h.Q + offset * (h.Q & 1)) / 2);

        private Hex QToHex(int offset) {
            int q = Col;
            int r = Row - (Col + offset * (Col & 1)) / 2;
            return new Hex(q, r);
        }

        /// <inheritdoc/>
        public bool Equals(OffsetCoord other) => Col == other.Col && Row == other.Row;

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is OffsetCoord other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => unchecked((Col * 397) ^ Row);

        /// <summary>Returns <c>"(col, row)"</c>.</summary>
        public override string ToString() => $"({Col}, {Row})";
    }
}
