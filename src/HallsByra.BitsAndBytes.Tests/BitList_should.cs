using System;
using System.Linq;
using HallsByra.BitsAndBytes;

namespace Areff.Swapar.Core.Tests.BitsAndBytes
{
/*
    [TestClass]
    public class BitList_should
    {
        [TestMethod]
        public void report_all_bits_of_a_two_byte_array_correctly()
        {
            // Given
            var bytes = new byte[] { 0xF0, 0x01 };

            // When
            var bits = bytes.ToBitList();

            // Then
            Assert.AreEqual(false, bits[0]);
            Assert.AreEqual(false, bits[1]);
            Assert.AreEqual(false, bits[2]);
            Assert.AreEqual(false, bits[3]);
            Assert.AreEqual(true, bits[4]);
            Assert.AreEqual(true, bits[5]);
            Assert.AreEqual(true, bits[6]);
            Assert.AreEqual(true, bits[7]);

            Assert.AreEqual(true, bits[8]);
            Assert.AreEqual(false, bits[9]);
            Assert.AreEqual(false, bits[10]);
            Assert.AreEqual(false, bits[11]);
            Assert.AreEqual(false, bits[12]);
            Assert.AreEqual(false, bits[13]);
            Assert.AreEqual(false, bits[14]);
            Assert.AreEqual(false, bits[15]);
        }

        [TestMethod]
        public void set_bits_in_a_two_byte_array()
        {
            // Given
            var bytes = new byte[] { 0x00, 0x00 };
            var bits = bytes.ToBitList();

            // When
            bits[0] = true;
            bits[15] = true;

            // Then
            Assert.AreEqual(0x01, bytes[0]);
            Assert.AreEqual(0x80, bytes[1]);
        }

        [TestMethod]
        public void report_the_length_of_a_two_byte_array()
        {
            // Given
            var bytes = new byte[] { 0x00, 0x00 };

            // When
            var bits = bytes.ToBitList();

            // Then
            Assert.AreEqual(16, bits.Count);
        }

        [TestMethod]
        public void apply_a_byte_to_a_bitlist()
        {
            // Given
            var bytes = new byte[] { 0x00, 0x00 };
            var bits = bytes.ToBitList();

            // When
            bits.Apply(0xF0.ToBits(8));

            // Then
            Assert.AreEqual(false, bits[0]);
            Assert.AreEqual(false, bits[1]);
            Assert.AreEqual(false, bits[2]);
            Assert.AreEqual(false, bits[3]);
            Assert.AreEqual(true, bits[4]);
            Assert.AreEqual(true, bits[5]);
            Assert.AreEqual(true, bits[6]);
            Assert.AreEqual(true, bits[7]);
        }

        [TestMethod]
        public void apply_a_nibble_to_a_bitlist()
        {
            // Given
            var bytes = new byte[] { 0x00, 0x00 };
            var bits = bytes.ToBitList();

            // When
            bits.Offset(4).Apply(0xF.ToBits(8));

            // Then
            Assert.AreEqual(0xF0, bytes[0]);
        }
    

    }
    */
}
