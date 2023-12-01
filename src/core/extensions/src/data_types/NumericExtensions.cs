namespace BeeneticToolkit.Extensions {

    /// <summary>
    /// Provides extension methods for numeric type conversions.
    /// </summary>
    public static class NumericExtensions {

        /// <summary>
        /// Converts a byte value to a mapped sbyte value.
        /// </summary>
        /// <param name="value">The byte value to convert.</param>
        /// <returns>The converted sbyte value.</returns>
        public static sbyte ToMappedSByte(this byte value) {
            return (sbyte)(value + sbyte.MinValue);
        }

        /// <summary>
        /// Converts an sbyte value to a mapped byte value.
        /// </summary>
        /// <param name="value">The sbyte value to convert.</param>
        /// <returns>The converted byte value.</returns>
        public static byte ToMappedByte(this sbyte value) {
            return (byte)(value - sbyte.MinValue);
        }

        /// <summary>
        /// Converts a ushort value to a mapped short value.
        /// </summary>
        /// <param name="value">The ushort value to convert.</param>
        /// <returns>The converted short value.</returns>
        public static short ToMappedInt16(this ushort value) {
            return (short)(value + short.MinValue);
        }

        /// <summary>
        /// Converts a short value to a mapped ushort value.
        /// </summary>
        /// <param name="value">The short value to convert.</param>
        /// <returns>The converted ushort value.</returns>
        public static ushort ToMappedUInt16(this short value) {
            return (ushort)(value - short.MinValue);
        }

        /// <summary>
        /// Converts a uint value to a mapped int value.
        /// </summary>
        /// <param name="value">The uint value to convert.</param>
        /// <returns>The converted int value.</returns>
        public static int ToMappedInt32(this uint value) {
            return (int)(value + int.MinValue);
        }

        /// <summary>
        /// Converts an int value to a mapped uint value.
        /// </summary>
        /// <param name="value">The int value to convert.</param>
        /// <returns>The converted uint value.</returns>
        public static uint ToMappedUInt32(this int value) {
            return (uint)((long)value - int.MinValue);
        }

        /// <summary>
        /// Converts a ulong value to a mapped long value.
        /// </summary>
        /// <param name="value">The ulong value to convert.</param>
        /// <returns>The converted long value.</returns>
        public static long ToMappedInt64(this ulong value) {
            return (long)value + long.MinValue;
        }

        /// <summary>
        /// Converts a long value to a mapped ulong value.
        /// </summary>
        /// <param name="value">The long value to convert.</param>
        /// <returns>The converted ulong value.</returns>
        public static ulong ToMappedUInt64(this long value) {
            return (ulong)(value - long.MinValue);
        }
    }
}