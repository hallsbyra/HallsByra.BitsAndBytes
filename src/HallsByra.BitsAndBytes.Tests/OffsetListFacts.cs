using System;
using System.Linq;
using HallsByra.BitsAndBytes;
using Xunit;

namespace Areff.Swapar.Core.Tests.BitsAndBytes
{
    public class OffsetListFacts
    {
        public class Count
        {
            [Theory]
            [InlineData(0, 4)]
            [InlineData(1, 3)]
            [InlineData(2, 2)]
            [InlineData(3, 1)]
            [InlineData(4, 0)]
            public void reflects_the_offset(int offset, int expectedCount)
            {
                // Given
                var bytes = new byte[] { 0x01, 0x02, 0x03, 0x04 };

                // When
                var offsetList = bytes.Offset(offset);

                // Then
                Assert.Equal(expectedCount, offsetList.Count);
            }
        }

        public class Index
        {
            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            public void sets_the_correct_byte_in_the_underlying_array_based_on_the_offset(int offset)
            {
                // Given
                var bytes = new byte[] { 0x01, 0x02, 0x03 };
                var offsetList = bytes.Offset(offset);

                // When
                offsetList[0] = 0xFF;

                // Then
                Assert.Equal(0xFF, bytes[offset]);
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            public void gets_the_correct_byte_in_the_underlying_array_based_on_the_offset(int offset)
            {
                // Given
                var bytes = new byte[] { 0x00, 0x01, 0x02 };
                var offsetList = bytes.Offset(offset);

                // Then
                Assert.Equal(offset, offsetList[0]);
            }
        }

        [Fact]
        public void set_keys_and_access_bits_in_a_mifare_block()
        {
            // Given
            var mifareBlock = new byte[16];
            var aKey = "010203040506";
            var bKey = "112233445566";
            var accessBits = "FF078000";

            // When
            mifareBlock.Apply(ByteUtil.HexStringToByteArray(aKey));
            mifareBlock.Offset(6).Apply(ByteUtil.HexStringToByteArray(accessBits));
            mifareBlock.Offset(10).Apply(ByteUtil.HexStringToByteArray(bKey));

            // Then
            Assert.True(mifareBlock.SequenceEqual(new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0xFF, 0x07, 0x80, 0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66 }));
        }
   
    }
}
