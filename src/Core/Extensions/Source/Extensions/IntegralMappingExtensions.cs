namespace BeeneticToolkit.Extensions {

    /// <summary>Provides extension methods for mapping between signed and unsigned numeric types while preserving relative positions within their ranges.</summary>
    public static class IntegralMappingExtensions {

        /// <summary>Maps a <see cref="byte"/> value to its equivalent <see cref="sbyte"/> value, preserving its relative position within the data type's range.</summary>
        /// <param name="value">The <see cref="byte"/> value to map.</param>
        /// <returns>The mapped <see cref="sbyte"/> value.</returns>
        public static sbyte ToMappedSByte(this byte value) {
            return (sbyte)(value + sbyte.MinValue);
        }

        /// <summary>Maps an <see cref="sbyte"/> value to its equivalent <see cref="byte"/> value, preserving its relative position within the data type's range.</summary>
        /// <param name="value">The <see cref="sbyte"/> value to map.</param>
        /// <returns>The mapped <see cref="byte"/> value.</returns>
        public static byte ToMappedByte(this sbyte value) {
            return (byte)(value - sbyte.MinValue);
        }

        /// <summary>Maps a <see cref="ushort"/> value to its equivalent <see cref="short"/> value, preserving its relative position within the data type's range.</summary>
        /// <param name="value">The <see cref="ushort"/> value to map.</param>
        /// <returns>The mapped <see cref="short"/> value.</returns>
        public static short ToMappedInt16(this ushort value) {
            return (short)(value + short.MinValue);
        }

        /// <summary>Maps a <see cref="short"/> value to its equivalent <see cref="ushort"/> value, preserving its relative position within the data type's range.</summary>
        /// <param name="value">The <see cref="short"/> value to map.</param>
        /// <returns>The mapped <see cref="ushort"/> value.</returns>
        public static ushort ToMappedUInt16(this short value) {
            return (ushort)(value - short.MinValue);
        }

        /// <summary>Maps a <see cref="uint"/> value to its equivalent <see cref="int"/> value, preserving its relative position within the data type's range.</summary>
        /// <param name="value">The <see cref="uint"/> value to map.</param>
        /// <returns>The mapped <see cref="int"/> value.</returns>
        public static int ToMappedInt32(this uint value) {
            return (int)(value + int.MinValue);
        }

        /// <summary>Maps an <see cref="int"/> value to its equivalent <see cref="uint"/> value, preserving its relative position within the data type's range.</summary>
        /// <param name="value">The <see cref="int"/> value to map.</param>
        /// <returns>The mapped <see cref="uint"/> value.</returns>
        public static uint ToMappedUInt32(this int value) {
            return (uint)((long)value - int.MinValue);
        }

        /// <summary>Maps a <see cref="ulong"/> value to its equivalent <see cref="long"/> value, preserving its relative position within the data type's range.</summary>
        /// <param name="value">The <see cref="ulong"/> value to map.</param>
        /// <returns>The mapped <see cref="long"/> value.</returns>
        public static long ToMappedInt64(this ulong value) {
            return (long)value + long.MinValue;
        }

        /// <summary>Maps a <see cref="long"/> value to its equivalent <see cref="ulong"/> value, preserving its relative position within the data type's range.</summary>
        /// <param name="value">The <see cref="long"/> value to map.</param>
        /// <returns>The mapped <see cref="ulong"/> value.</returns>
        public static ulong ToMappedUInt64(this long value) {
            return (ulong)(value - long.MinValue);
        }
    }
}