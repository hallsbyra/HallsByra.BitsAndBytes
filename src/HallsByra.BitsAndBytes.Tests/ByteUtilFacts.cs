using System;
using System.Linq;
using HallsByra.BitsAndBytes;
using Xunit;
using FluentAssertions;

namespace Areff.Swapar.Core.Tests.BitsAndBytes
{
    public class ByteUtilFacts
    {
        [Theory]
        [InlineData("00010AFF", new byte[] { 0, 1, 10, 255 })]
        [InlineData("", new byte[] { })]
        [InlineData("1", new byte[] { 1 })]
        [InlineData("100", new byte[] { 1, 0 })]
        public void HexStringToByteArray_Should_Convert_Hex_String_To_Byte_Array(string hexString, byte[] byteArray)
        {
            ByteUtil.HexStringToByteArray(hexString).Should().Equal(byteArray);
        }

        [Theory]
        [InlineData(new byte[] { 0x01 }, new byte[] { 0x02 })]
        [InlineData(new byte[] { 0x02 }, new byte[] { 0x04 })]
        [InlineData(new byte[] { 0x04 }, new byte[] { 0x08 })]
        [InlineData(new byte[] { 0x08 }, new byte[] { 0x10 })]
        [InlineData(new byte[] { 0x10 }, new byte[] { 0x20 })]
        [InlineData(new byte[] { 0x20 }, new byte[] { 0x40 })]
        [InlineData(new byte[] { 0x40 }, new byte[] { 0x80 })]
        [InlineData(new byte[] { 0x80 }, new byte[] { 0x00 })]
        public void LogicalShiftLeft_should_shift_a_single_bit_through_a_byte(byte[] input, byte[] expectedOutput)
        {
            ByteUtil.LogicalShiftLeft(input).Should().Equal(expectedOutput);
        }

        [Theory]
        [InlineData(new byte[] { 0x00, 0x80 }, new byte[] { 0x01, 0x00 })]
        [InlineData(new byte[] { 0x01, 0x01 }, new byte[] { 0x02, 0x02 })]
        [InlineData(new byte[] { 0x01, 0x81 }, new byte[] { 0x03, 0x02 })]
        public void LogicalShiftLeft_should_carry_bits_between_bytes(byte[] input, byte[] expectedOutput)
        {
            ByteUtil.LogicalShiftLeft(input).Should().Equal(expectedOutput);
        }

        [Fact]
        public void LogicalShiftLeft_should_leave_source_array_unchanged()
        {
            var source = new byte[] { 0x01 };
            var target = ByteUtil.LogicalShiftLeft(source);
            source.Should().Equal(new byte[] { 0x01 });
            target.Should().Equal(new byte[] { 0x02 });
        }

        [Theory]
        [InlineData(new byte[] { 0x01 }, new byte[] { 0x00 }, new byte[] { 0x01 })]
        [InlineData(new byte[] { 0xFF }, new byte[] { 0xFF }, new byte[] { 0x00 })]
        [InlineData(new byte[] { 0xAA, 0xFF }, new byte[] { 0xAA, 0xAA }, new byte[] { 0x00, 0x55 })]
        public void Xor_should_perform_xor_on_arrays_of_equals_size(byte[] input1, byte[] input2, byte[] expectedOutput)
        {
            ByteUtil.Xor(input1, input2).Should().Equal(expectedOutput);
        }

        [Theory]
        [InlineData(new byte[] { 0xFF, 0xFF }, new byte[] { 0xFF }, new byte[] { 0xFF, 0x00 })]
        [InlineData(new byte[] { 0xFF }, new byte[] { 0xFF, 0xFF }, new byte[] { 0xFF, 0x00 })]
        public void Xor_should_perform_xor_on_the_rigthmost_bytes_in_case_arrays_are_not_equal_size(byte[] input1, byte[] input2, byte[] expectedOutput)
        {
            ByteUtil.Xor(input1, input2).Should().Equal(expectedOutput);
        }

        [Fact]
        public void Xor_should_leave_both_source_arrays_unchanged()
        {
            var arr1 = new byte[] { 0xFF };
            var arr2 = new byte[] { 0xFF };
            var target = ByteUtil.Xor(arr1, arr2);
            arr1.Should().Equal(new byte[] { 0xFF });
            arr2.Should().Equal(new byte[] { 0xFF });
            target.Should().Equal(new byte[] { 0x00 });
        }
    }
}
