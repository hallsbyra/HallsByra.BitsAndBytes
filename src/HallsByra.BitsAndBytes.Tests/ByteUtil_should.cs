using System;
using System.Linq;
using HallsByra.BitsAndBytes;

namespace Areff.Swapar.Core.Tests.BitsAndBytes
{
    /*
    [TestClass]
    public class ByteUtil_should
    {
        [TestMethod]
        public void HexStringToByteArray_Should_Convert_Hex_String_To_Byte_Array()
        {
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0, 1, 10, 255 }, ByteUtil.HexStringToByteArray("00010AFF")));
        }

        [TestMethod]
        public void HexStringToByteArray_Should_Convert_Empty_String_To_Empty_Array()
        {
            Assert.AreEqual(0, ByteUtil.HexStringToByteArray("").Length);
        }

        [TestMethod]
        public void HexStringToByteArray_Should_Handle_Uneven_Number_Of_Digits()
        {
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 1 }, ByteUtil.HexStringToByteArray("1")));
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 1, 0 }, ByteUtil.HexStringToByteArray("100")));
        }

        [TestMethod]
        public void LogicalShiftLeft_should_shift_a_single_bit_through_a_byte()
        {
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0x02 }, ByteUtil.LogicalShiftLeft(new byte[] { 0x01 })));
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0x04 }, ByteUtil.LogicalShiftLeft(new byte[] { 0x02 })));
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0x08 }, ByteUtil.LogicalShiftLeft(new byte[] { 0x04 })));
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0x10 }, ByteUtil.LogicalShiftLeft(new byte[] { 0x08 })));
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0x20 }, ByteUtil.LogicalShiftLeft(new byte[] { 0x10 })));
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0x40 }, ByteUtil.LogicalShiftLeft(new byte[] { 0x20 })));
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0x80 }, ByteUtil.LogicalShiftLeft(new byte[] { 0x40 })));
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0x00 }, ByteUtil.LogicalShiftLeft(new byte[] { 0x80 })));
        }

        [TestMethod]
        public void LogicalShiftLeft_should_carry_bits_between_bytes()
        {
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0x01, 0x00 }, ByteUtil.LogicalShiftLeft(new byte[] { 0x00, 0x80 })));
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0x02, 0x02 }, ByteUtil.LogicalShiftLeft(new byte[] { 0x01, 0x01 })));
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0x03, 0x02 }, ByteUtil.LogicalShiftLeft(new byte[] { 0x01, 0x81 })));
        }

        [TestMethod]
        public void LogicalShiftLeft_should_leave_source_array_unchanged()
        {
            var source = new byte[] { 0x01 };
            var target = ByteUtil.LogicalShiftLeft(source);
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0x01 }, source));
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0x02 }, target));
        }

        [TestMethod]
        public void Xor_should_perform_xor_on_arrays_of_equals_size()
        {
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0x01 }, ByteUtil.Xor(new byte[] { 0x01 }, new byte[] { 0x00 })));
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0x00 }, ByteUtil.Xor(new byte[] { 0xFF }, new byte[] { 0xFF })));
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0x00, 0x55 }, ByteUtil.Xor(new byte[] { 0xAA, 0xFF }, new byte[] { 0xAA, 0xAA })));
        }

        [TestMethod]
        public void Xor_should_perform_xor_on_the_rigthmost_bytes_in_case_arrays_are_not_equal_size()
        {
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0xFF, 0x00 }, ByteUtil.Xor(new byte[] { 0xFF, 0xFF }, new byte[] { 0xFF })));
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0xFF, 0x00 }, ByteUtil.Xor(new byte[] { 0xFF }, new byte[] { 0xFF, 0xFF })));
        }

        [TestMethod]
        public void Xor_should_leave_bout_source_arrays_unchanged()
        {
            var arr1 = new byte[] { 0xFF };
            var arr2 = new byte[] { 0xFF };
            var target = ByteUtil.Xor(arr1, arr2);
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0xFF }, arr1));
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0xFF }, arr2));
            Assert.IsTrue(Enumerable.SequenceEqual(new byte[] { 0x00 }, target));
        }
    }
    */
}
