using System;
using System.Linq;
using HallsByra.BitsAndBytes;
using Xunit;
using FluentAssertions;

namespace Areff.Swapar.Core.Tests.BitsAndBytes
{
    public class BitUtilFacts
    {
        [Theory]
        [InlineData(1, 1, "1")]
        [InlineData(1, 2, "10")]
        [InlineData(1, 3, "100")]
        [InlineData(2, 2, "01")]
        [InlineData(3, 2, "11")]
        public void convert_int32_to_bits(int value, int bitCount, string expectedBitString)
        {
            value.ToBits(bitCount).ToBinaryString().Should().Be(expectedBitString);
        }

        [Theory]
        [InlineData(new byte[] { 1, 2 }, 16, "10000000" + "01000000")]
        [InlineData(new byte[] { 1, 2 }, 10, "10000000" + "01")]
        [InlineData(new byte[] { 1, 2 },  8, "10000000")]
        [InlineData(new byte[] { 1, 2 }, 18, "10000000" + "01000000" + "00")]
        public void convert_byte_array_to_bits(byte[] bytes, int bitCount, string expectedBitString)
        {
            bytes.ToBits(bitCount).ToBinaryString().Should().Be(expectedBitString);
        }

        [Theory]
        [InlineData(new[] { true }, "1")]
        [InlineData(new[] { false }, "0")]
        [InlineData(new[] { true, false }, "10")]
        [InlineData(new[] { true, false, true }, "101")]
        [InlineData(new[] { true, false, true, false }, "1010")]
        public void convert_bits_to_binary_string(bool[] bits, string expectedBinaryString)
        {
            bits.ToBinaryString().Should().Be(expectedBinaryString);
        }

        [Theory]
        [InlineData("1", 1, new[] { true })]
        [InlineData("0", 1, new[] { false })]
        [InlineData("0", 2, new[] { false, false })]
        [InlineData("10", 2, new[] { true, false })]
        [InlineData("10", 1, new[] { true })]
        [InlineData("101", 4, new[] { true, false, true, false })]
        public void convert_binary_string_to_bits(string binaryString, int bitCount, bool[] expectedBits)
        {
            binaryString.BinaryStringToBits(bitCount).Should().Equal(expectedBits);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("11", 3)]
        [InlineData("10", 1)]
        [InlineData("01", 2)]
        [InlineData("001", 4)]
        public void convert_bits_to_int32(string bitString, int expectedInt32)
        {
            bitString.BinaryStringToBits().ToInt32().Should().Be(expectedInt32);
        }

        [Theory]
        [InlineData("1", true)]
        [InlineData("0", false)]
        [InlineData("00", false)]
        [InlineData("10", true)]
        public void convert_bits_to_bool(string bitString, bool expectedBool)
        {
            bitString.BinaryStringToBits().ToBool().Should().Be(expectedBool);
        }

        [Theory]
        [InlineData("10000000", new byte[] { 0x01 })]
        [InlineData("1", new byte[] { 0x01 })]
        [InlineData("1000000000000001", new byte[] { 0x01, 0x80 })]
        [InlineData("000000011", new byte[] { 0x80, 0x01 })]
        public void convert_bits_to_bytearray(string bitString, byte[] expectedBytes)
        {
            bitString.BinaryStringToBits().ToBytes().Should().Equal(expectedBytes);
        }
    }

}
