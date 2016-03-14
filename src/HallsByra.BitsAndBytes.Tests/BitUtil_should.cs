using System;
using System.Linq;
using HallsByra.BitsAndBytes;

namespace Areff.Swapar.Core.Tests.BitsAndBytes
{
    /*
    [TestClass]
    public class BitUtil_should
    {
        [TestMethod]
        public void convert_int32_to_bits()
        {
            Assert.AreEqual("1", 1.ToBits(1).ToBinaryString());
            Assert.AreEqual("10", 1.ToBits(2).ToBinaryString());
            Assert.AreEqual("100", 1.ToBits(3).ToBinaryString());
            Assert.AreEqual("01", 2.ToBits(2).ToBinaryString());
            Assert.AreEqual("11", 3.ToBits(2).ToBinaryString());
        }

        [TestMethod]
        public void convert_byte_array_to_bits()
        {
            Assert.AreEqual("10000000" + "01000000", new byte[] {1, 2}.ToBits(16).ToBinaryString());
            Assert.AreEqual("10000000", new byte[] { 1, 2 }.ToBits(8).ToBinaryString());
            Assert.AreEqual("10000000" + "01", new byte[] { 1, 2 }.ToBits(10).ToBinaryString());
            Assert.AreEqual("10000000" + "01000000" + "00", new byte[] { 1, 2 }.ToBits(18).ToBinaryString());
        }

        [TestMethod]
        public void convert_bits_to_binary_string()
        {
            Assert.AreEqual("1", new[] { true }.ToBinaryString());
            Assert.AreEqual("0", new[] { false }.ToBinaryString());
            Assert.AreEqual("10", new[] { true, false }.ToBinaryString());
            Assert.AreEqual("101", new[] { true, false, true }.ToBinaryString());
            Assert.AreEqual("1010", new[] { true, false, true, false }.ToBinaryString());
        }

        [TestMethod]
        public void convert_binary_string_to_bits()
        {
            Assert.IsTrue(new[] { true }.SequenceEqual("1".BinaryStringToBits(1)));
            Assert.IsTrue(new[] { false }.SequenceEqual("0".BinaryStringToBits(1)));
            Assert.IsTrue(new[] { false, false }.SequenceEqual("0".BinaryStringToBits(2)));
            Assert.IsTrue(new[] { true, false }.SequenceEqual("10".BinaryStringToBits(2)));
            Assert.IsTrue(new[] { true }.SequenceEqual("10".BinaryStringToBits(1)));
            Assert.IsTrue(new[] { true, false, true, false }.SequenceEqual("101".BinaryStringToBits(4)));
        }

        [TestMethod]
        public void convert_bits_to_int32()
        {
            Assert.AreEqual(1, "1".BinaryStringToBits().ToInt32());
            Assert.AreEqual(3, "11".BinaryStringToBits().ToInt32());
            Assert.AreEqual(1, "10".BinaryStringToBits().ToInt32());
            Assert.AreEqual(2, "01".BinaryStringToBits().ToInt32());
            Assert.AreEqual(4, "001".BinaryStringToBits().ToInt32());
        }

        [TestMethod]
        public void convert_bits_to_bool()
        {
            Assert.IsTrue("1".BinaryStringToBits().ToBool());
            Assert.IsFalse("0".BinaryStringToBits().ToBool());
            Assert.IsFalse("00".BinaryStringToBits().ToBool());
            Assert.IsTrue("10".BinaryStringToBits().ToBool());
        }

        [TestMethod]
        public void convert_bits_to_bytearray()
        {
            Assert.IsTrue(new byte[] { 0x01 }.SequenceEqual("10000000".BinaryStringToBits().ToBytes()));
            Assert.IsTrue(new byte[] { 0x01 }.SequenceEqual("1".BinaryStringToBits().ToBytes()));
            Assert.IsTrue(new byte[] { 0x01, 0x80 }.SequenceEqual("1000000000000001".BinaryStringToBits().ToBytes()));
            Assert.IsTrue(new byte[] { 0x80, 0x01 }.SequenceEqual("000000011".BinaryStringToBits().ToBytes()));
        }
    }
*/
}
