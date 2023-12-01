using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeeneticToolkit.Extensions.Tests {

    [TestClass]
    public class NumericExtensionsTests {

        #region Byte

        [TestMethod]
        public void ToMappedSByte_WithMinByteValue_ReturnsMinSByteValue() {
            byte minByteValue = byte.MinValue;
            var result = minByteValue.ToMappedSByte();
            Assert.AreEqual(sbyte.MinValue, result);
        }

        [TestMethod]
        public void ToMappedSByte_WithMaxByteValue_ReturnsMaxSByteValue() {
            byte maxByteValue = byte.MaxValue;
            var result = maxByteValue.ToMappedSByte();
            Assert.AreEqual(sbyte.MaxValue, result);
        }

        [TestMethod]
        public void ToMappedSByte_WithMidByteValue_ReturnsZero() {
            byte midByteValue = sbyte.MaxValue + 1;
            var result = midByteValue.ToMappedSByte();
            Assert.AreEqual((sbyte)byte.MinValue, result);
        }

        [TestMethod]
        public void ToMappedByte_WithMinSByteValue_ReturnsMinByteValue() {
            sbyte minSByteValue = sbyte.MinValue;
            var result = minSByteValue.ToMappedByte();
            Assert.AreEqual(byte.MinValue, result);
        }

        [TestMethod]
        public void ToMappedByte_WithMaxSByteValue_ReturnsMaxByteValue() {
            sbyte maxSByteValue = sbyte.MaxValue;
            var result = maxSByteValue.ToMappedByte();
            Assert.AreEqual(byte.MaxValue, result);
        }

        [TestMethod]
        public void ToMappedByte_WithZeroSByteValue_ReturnsMidByteValue() {
            sbyte zeroSByteValue = (sbyte)byte.MinValue;
            var result = zeroSByteValue.ToMappedByte();
            Assert.AreEqual((byte)(sbyte.MaxValue + 1), result);
        }

        #endregion Byte

        #region Short

        [TestMethod]
        public void ToMappedInt16_WithMinUInt16Value_ReturnsMinInt16Value() {
            ushort minUInt16Value = ushort.MinValue;
            var result = minUInt16Value.ToMappedInt16();
            Assert.AreEqual(short.MinValue, result);
        }

        [TestMethod]
        public void ToMappedInt16_WithMaxUInt16Value_ReturnsMaxInt16Value() {
            ushort maxUInt16Value = ushort.MaxValue;
            var result = maxUInt16Value.ToMappedInt16();
            Assert.AreEqual(short.MaxValue, result);
        }

        [TestMethod]
        public void ToMappedInt16_WithMidUInt16Value_ReturnsZero() {
            ushort midUInt16Value = (ushort)short.MaxValue + 1;
            var result = midUInt16Value.ToMappedInt16();
            Assert.AreEqual((short)ushort.MinValue, result);
        }

        [TestMethod]
        public void ToMappedUInt16_WithMinInt16Value_ReturnsMinUInt16Value() {
            short minInt16Value = short.MinValue;
            var result = minInt16Value.ToMappedUInt16();
            Assert.AreEqual(ushort.MinValue, result);
        }

        [TestMethod]
        public void ToMappedUInt16_WithMaxInt16Value_ReturnsMaxUInt16Value() {
            short maxInt16Value = short.MaxValue;
            var result = maxInt16Value.ToMappedUInt16();
            Assert.AreEqual(ushort.MaxValue, result);
        }

        [TestMethod]
        public void ToMappedUInt16_WithZeroInt16Value_ReturnsMidUInt16Value() {
            short zeroInt16Value = (short)ushort.MinValue;
            var result = zeroInt16Value.ToMappedUInt16();
            Assert.AreEqual((ushort)(short.MaxValue + 1), result);
        }

        #endregion Short

        #region Int

        [TestMethod]
        public void ToMappedInt32_WithMinUInt32Value_ReturnsMinInt32Value() {
            uint minUInt32Value = uint.MinValue;
            var result = minUInt32Value.ToMappedInt32();
            Assert.AreEqual(int.MinValue, result);
        }

        [TestMethod]
        public void ToMappedInt32_WithMaxUInt32Value_ReturnsMaxInt32Value() {
            uint maxUInt32Value = uint.MaxValue;
            var result = maxUInt32Value.ToMappedInt32();
            Assert.AreEqual(int.MaxValue, result);
        }

        [TestMethod]
        public void ToMappedInt32_WithMidUInt32Value_ReturnsZero() {
            uint midUInt32Value = (uint)int.MaxValue + 1;
            var result = midUInt32Value.ToMappedInt32();
            Assert.AreEqual((int)uint.MinValue, result);
        }

        [TestMethod]
        public void ToMappedUInt32_WithMinInt32Value_ReturnsMinUInt32Value() {
            int minInt32Value = int.MinValue;
            var result = minInt32Value.ToMappedUInt32();
            Assert.AreEqual(uint.MinValue, result);
        }

        [TestMethod]
        public void ToMappedUInt32_WithMaxInt32Value_ReturnsMaxUInt32Value() {
            int maxInt32Value = int.MaxValue;
            var result = maxInt32Value.ToMappedUInt32();
            Assert.AreEqual(uint.MaxValue, result);
        }

        [TestMethod]
        public void ToMappedUInt32_WithZeroInt32Value_ReturnsMidUInt32Value() {
            int zeroInt32Value = (int)uint.MinValue;
            var result = zeroInt32Value.ToMappedUInt32();
            Assert.AreEqual((uint)int.MaxValue + 1, result);
        }

        #endregion Int

        #region Long

        [TestMethod]
        public void ToMappedInt64_WithMinUInt64Value_ReturnsMinInt64Value() {
            ulong minUInt64Value = ulong.MinValue;
            var result = minUInt64Value.ToMappedInt64();
            Assert.AreEqual(long.MinValue, result);
        }

        [TestMethod]
        public void ToMappedInt64_WithMaxUInt64Value_ReturnsMaxInt64Value() {
            ulong maxUInt64Value = ulong.MaxValue;
            var result = maxUInt64Value.ToMappedInt64();
            Assert.AreEqual(long.MaxValue, result);
        }

        [TestMethod]
        public void ToMappedInt64_WithMidUInt64Value_ReturnsZero() {
            ulong midUInt64Value = (ulong)long.MaxValue + 1;
            var result = midUInt64Value.ToMappedInt64();
            Assert.AreEqual((long)ulong.MinValue, result);
        }

        [TestMethod]
        public void ToMappedUInt64_WithMinInt64Value_ReturnsMinUInt64Value() {
            long minInt64Value = long.MinValue;
            var result = minInt64Value.ToMappedUInt64();
            Assert.AreEqual(ulong.MinValue, result);
        }

        [TestMethod]
        public void ToMappedUInt64_WithMaxInt64Value_ReturnsMaxUInt64Value() {
            long maxInt64Value = long.MaxValue;
            var result = maxInt64Value.ToMappedUInt64();
            Assert.AreEqual(ulong.MaxValue, result);
        }

        [TestMethod]
        public void ToMappedUInt64_WithZeroInt64Value_ReturnsMidUInt64Value() {
            long zeroInt64Value = (long)ulong.MinValue;
            var result = zeroInt64Value.ToMappedUInt64();
            Assert.AreEqual((ulong)long.MaxValue + 1, result);
        }

        #endregion Long
    }
}