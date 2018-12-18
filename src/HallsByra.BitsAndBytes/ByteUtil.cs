using System;
using System.Collections.Generic;
using System.Linq;

namespace HallsByra.BitsAndBytes
{
    public static class ByteUtil
    {
        public static UInt16 ToUInt16(this IEnumerable<byte> bytes)
        {
            return BitConverter.ToUInt16(bytes.PadRight(2).ToArray(), 0);
        }

        public static UInt32 ToUInt32(this IEnumerable<byte> bytes)
        {
            return BitConverter.ToUInt32(bytes.PadRight(4).ToArray(), 0);
        }

        public static UInt64 ToUInt64(this IEnumerable<byte> bytes)
        {
            return BitConverter.ToUInt64(bytes.PadRight(8).ToArray(), 0);
        }

        public static IEnumerable<byte> ToBytes(this UInt16 value)
        {
            return BitConverter.GetBytes(value);
        }

        public static IEnumerable<byte> ToBytes(this UInt32 value)
        {
            return BitConverter.GetBytes(value);
        }

        public static IEnumerable<byte> ToBytes(this UInt64 value)
        {
            return BitConverter.GetBytes(value);
        }


        // TODO: Rework the following to IEnumerable extensions instead.

        /// <summary>
        /// Converts a string of hex bytes to a binary byte array.
        /// </summary>
        /// <param name="hex">
        /// The hex string. Each pair of two characters is treated as a hexadecimal digit.
        /// </param>
        /// <returns>
        /// Array of binary bytes.
        /// </returns>
        public static byte[] HexStringToByteArray(string hex)
        {
            if (hex.Length % 2 != 0)
            {
                hex = "0" + hex;
            }
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static string ByteArrayToHexString(byte[] byteArray)
        {
            return BitConverter.ToString(byteArray).Replace("-", "");
        }

        /// <summary>
        /// Shifts all bits to the left, shifting in zeroes to the right.
        /// </summary>
        /// <remarks>
        /// Does not increase the size of the input, i.e. bits shifted out to the left are "lost".
        /// </remarks>
        public static byte[] LogicalShiftLeft(byte[] byteArray)
        {
            var newBytes = byteArray.Select(b => (byte)(b << 1)).ToArray();
            for (int index = 0; index < byteArray.Length - 1; index++)
            {
                var carry = (byteArray[index + 1] & 0x80) == 0x80;
                if (carry)
                {
                    newBytes[index] |= 0x01;
                }
            }
            return newBytes;
        }

        public static byte[] Xor(byte[] byteArr1, byte[] byteArr2)
        {
            return byteArr1.Length < byteArr2.Length
                ? XorShorterSource1WithLongerSource2(byteArr1, byteArr2)
                : XorShorterSource1WithLongerSource2(byteArr2, byteArr1);
        }

        private static byte[] XorShorterSource1WithLongerSource2(byte[] source1, byte[] source2)
        {
            var result = (byte[])source2.Clone();
            for (int index = 0; index < source1.Length; index++)
            {
                result[result.Length - index - 1] ^= source1[source1.Length - index - 1];
            }
            return result;
        }

    }
}
