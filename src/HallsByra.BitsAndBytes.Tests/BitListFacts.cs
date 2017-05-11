using System;
using System.Linq;
using HallsByra.BitsAndBytes;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;

namespace Areff.Swapar.Core.Tests.BitsAndBytes
{
    public class BitListFacts
    {
        [Theory]
        [InlineData(new byte[] { 0xF0, 0x01 }, "00001111" + "10000000")]
        public void reports_all_bits_of_an_array_correctly(byte[] bytes, string expectedBits)
        {
            // When
            var bits = bytes.ToBits();

            // Then
            bits.Should().Equal(expectedBits.BinaryStringToBits());
        }

        [Fact]
        public void set_bits_in_a_two_byte_array()
        {
            // Given
            var bytes = new byte[] { 0x00, 0x00 };
            var bits = bytes.ToBitList();

            // When
            bits[0] = true;
            bits[15] = true;

            // Then
            bytes[0].Should().Be(0x01);
            bytes[1].Should().Be(0x80);
        }

        [Fact]
        public void report_the_length_of_a_two_byte_array()
        {
            // Given
            var bytes = new byte[] { 0x00, 0x00 };

            // When
            var bits = bytes.ToBitList();

            // Then
            bits.Should().HaveCount(16);
        }

        [Fact]
        public void apply_a_byte_to_a_bitlist()
        {
            // Given
            var bytes = new byte[] { 0x00, 0x00 };
            var bits = bytes.ToBitList();

            // When
            bits.Apply(((byte)0xF0).ToBits());

            // Then
            bytes[0].Should().Be(0xF0);
        }

        [Fact]
        public void apply_a_nibble_to_a_bitlist()
        {
            // Given
            var bytes = new byte[] { 0x00, 0x00 };
            var bits = bytes.ToBitList();

            // When
            bits.Offset(4).Apply(0xF.ToBits().Take(4));

            // Then
            bytes[0].Should().Be(0xF0);
        }
    }
}
