using System;
using System.Linq;
using HallsByra.BitsAndBytes;
using Xunit;
using FluentAssertions;

namespace Areff.Swapar.Core.Tests.BitsAndBytes
{
    public class VirtualListFacts
    {
        [Fact]
        public void read_indexed_correctly_into_two_combined_lists()
        {
            // Given
            var bytes1 = new byte[] { 0x01, 0x02 };
            var bytes2 = new byte[] { 0x03, 0x04 };

            // When
            var combined = bytes1.Combine(bytes2);

            // Then
            combined.Count.Should().Be(4);
            combined[0].Should().Be(0x01);
            combined[1].Should().Be(0x02);
            combined[2].Should().Be(0x03);
            combined[3].Should().Be(0x04);
        }

        [Fact]
        public void write_indexed_correctly_into_two_combined_lists()
        {
            // Given
            var bytes1 = new byte[] { 0x01, 0x02 };
            var bytes2 = new byte[] { 0x03, 0x04 };
            var combined = bytes1.Combine(bytes2);

            // When
            combined[0] = 0x10;
            combined[1] = 0x11;
            combined[2] = 0x12;
            combined[3] = 0x13;

            // Then
            combined[0].Should().Be(0x10);
            combined[1].Should().Be(0x11);
            combined[2].Should().Be(0x12);
            combined[3].Should().Be(0x13);
        }

        [Fact]
        public void index_correctly_into_four_combined_lists()
        {
            // Given
            var bytes1 = new byte[] { 0x01 };
            var bytes2 = new byte[] { 0x02 };
            var bytes3 = new byte[] { };
            var bytes4 = new byte[] { 0x03 };
            var combined = new VirtualList<byte>(bytes1, bytes2, bytes3, bytes4);

            // When
            for(int index = 0; index < combined.Count; index++)
            {
                combined[index]++;
            }

            // Then
            combined.Should().Equal(0x02, 0x03, 0x04);
        }

        [Fact]
        public void report_count_correctly_of_two_combined_lists()
        {
            // Given
            var bytes1 = new byte[] { 0x01, 0x02 };
            var bytes2 = new byte[] { 0x03, 0x04, 0x05 };

            // When
            var combined = bytes1.Combine(bytes2);

            // Then
            combined.Count.Should().Be(5);
        }


        [Fact]
        public void report_indexof_correctly_of_two_combined_lists()
        {
            // Given
            var bytes1 = new byte[] { 0x01, 0x02 };
            var bytes2 = new byte[] { 0x03, 0x04, 0x05 };

            // When
            var combined = bytes1.Combine(bytes2);

            // Then
            combined.IndexOf(0x03).Should().Be(2);
        }

        [Fact]
        public void iterate_over_two_combined_lists()
        {
            // Given
            var bytes1 = new byte[] { 0x01, 0x02 };
            var bytes2 = new byte[] { 0x03, 0x04, 0x05 };

            // When
            var allElements = bytes1.Combine(bytes2).ToArray();

            // Then
            allElements.Should().Equal(0x01, 0x02, 0x03, 0x04, 0x05);
        }
    }
}
