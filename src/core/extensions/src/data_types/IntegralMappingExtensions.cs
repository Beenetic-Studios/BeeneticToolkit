namespace BeeneticToolkit.Extensions {

    /// <summary>
    /// Provides extension methods for mapping between signed and unsigned numeric types.
    /// </summary>
    public static class IntegralMappingExtensions {

        /// <summary>
        /// Maps a byte value to its equivalent sbyte value, preserving its relative position within the data type's range.
        /// </summary>
        /// <param name="value">The byte value to map.</param>
        /// <returns>The mapped sbyte value.</returns>
        public static sbyte ToMappedSByte(this byte value) {
            return (sbyte)(value + sbyte.MinValue);
        }

        /// <summary>
        /// Maps an sbyte value to its equivalent byte value, preserving its relative position within the data type's range.
        /// </summary>
        /// <param name="value">The sbyte value to map.</param>
        /// <returns>The mapped byte value.</returns>
        public static byte ToMappedByte(this sbyte value) {
            return (byte)(value - sbyte.MinValue);
        }

        /// <summary>
        /// Maps a ushort value to its equivalent short value, preserving its relative position within the data type's range.
        /// </summary>
        /// <param name="value">The ushort value to map.</param>
        /// <returns>The mapped short value.</returns>
        public static short ToMappedInt16(this ushort value) {
            return (short)(value + short.MinValue);
        }

        /// <summary>
        /// Maps a short value to its equivalent ushort value, preserving its relative position within the data type's range.
        /// </summary>
        /// <param name="value">The short value to map.</param>
        /// <returns>The mapped ushort value.</returns>
        public static ushort ToMappedUInt16(this short value) {
            return (ushort)(value - short.MinValue);
        }

        /// <summary>
        /// Maps a uint value to its equivalent int value, preserving its relative position within the data type's range.
        /// </summary>
        /// <param name="value">The uint value to map.</param>
        /// <returns>The mapped int value.</returns>
        public static int ToMappedInt32(this uint value) {
            return (int)(value + int.MinValue);
        }

        /// <summary>
        /// Maps an int value to its equivalent uint value, preserving its relative position within the data type's range.
        /// </summary>
        /// <param name="value">The int value to map.</param>
        /// <returns>The mapped uint value.</returns>
        public static uint ToMappedUInt32(this int value) {
            return (uint)((long)value - int.MinValue);
        }

        /// <summary>
        /// Maps a ulong value to its equivalent long value, preserving its relative position within the data type's range.
        /// </summary>
        /// <param name="value">The ulong value to map.</param>
        /// <returns>The mapped long value.</returns>
        public static long ToMappedInt64(this ulong value) {
            return (long)value + long.MinValue;
        }

        /// <summary>
        /// Maps a long value to its equivalent ulong value, preserving its relative position within the data type's range.
        /// </summary>
        /// <param name="value">The long value to map.</param>
        /// <returns>The mapped ulong value.</returns>
        public static ulong ToMappedUInt64(this long value) {
            return (ulong)(value - long.MinValue);
        }
    }
}