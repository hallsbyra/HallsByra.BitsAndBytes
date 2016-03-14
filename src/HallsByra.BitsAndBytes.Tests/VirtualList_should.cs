using System;
using System.Linq;
using HallsByra.BitsAndBytes;

namespace Areff.Swapar.Core.Tests.BitsAndBytes
{
/*
    [TestClass]
    public class VirtualList_should
    {
        [TestMethod]
        public void read_indexed_correctly_into_two_combined_lists()
        {
            // Given
            var bytes1 = new byte[] { 0x01, 0x02 };
            var bytes2 = new byte[] { 0x03, 0x04 };

            // When
            var combined = bytes1.Combine(bytes2);

            // Then
            Assert.AreEqual(0x01, combined[0]);
            Assert.AreEqual(0x02, combined[1]);
            Assert.AreEqual(0x03, combined[2]);
            Assert.AreEqual(0x04, combined[3]);
        }

        [TestMethod]
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
            Assert.AreEqual(0x10, combined[0]);
            Assert.AreEqual(0x11, combined[1]);
            Assert.AreEqual(0x12, combined[2]);
            Assert.AreEqual(0x13, combined[3]);
        }

        [TestMethod]
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
            Assert.IsTrue(combined.ToArray().SequenceEqual(new byte[] { 0x02, 0x03, 0x04 }));

        }

        [TestMethod]
        public void report_count_correctly_of_two_combined_lists()
        {
            // Given
            var bytes1 = new byte[] { 0x01, 0x02 };
            var bytes2 = new byte[] { 0x03, 0x04, 0x05 };

            // When
            var combined = bytes1.Combine(bytes2);

            // Then
            Assert.AreEqual(5, combined.Count);
        }


        [TestMethod]
        public void report_indexof_correctly_of_two_combined_lists()
        {
            // Given
            var bytes1 = new byte[] { 0x01, 0x02 };
            var bytes2 = new byte[] { 0x03, 0x04, 0x05 };

            // When
            var combined = bytes1.Combine(bytes2);

            // Then
            Assert.AreEqual(2, combined.IndexOf(0x03));
        }

        [TestMethod]
        public void iterate_over_two_combined_lists()
        {
            // Given
            var bytes1 = new byte[] { 0x01, 0x02 };
            var bytes2 = new byte[] { 0x03, 0x04, 0x05 };

            // When
            var allElements = bytes1.Combine(bytes2).ToArray();

            // Then
            Assert.IsTrue(allElements.SequenceEqual(new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 }));
        }
    }
    */
}
