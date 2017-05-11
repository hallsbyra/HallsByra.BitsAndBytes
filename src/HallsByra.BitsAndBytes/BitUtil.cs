using System;
using System.Collections.Generic;
using System.Linq;

namespace HallsByra.BitsAndBytes
{
    public static class BitUtil
    {
        public static IEnumerable<bool> ToBits(this UInt64 value)
        {
            for (int bit = 0; bit < 64; bit++)
            {
                yield return (value & 1) == 1;
                value >>= 1;
            }
        }

        public static IEnumerable<bool> ToBits(this byte value)
        {
            return ((UInt64)value).ToBits().Take(8);
        }

        public static IEnumerable<bool> ToBits(this UInt16 value)
        {
            return ((UInt64)value).ToBits().Take(16);
        }


        public static IEnumerable<bool> ToBits(this UInt32 value)
        {
            return ((UInt64)value).ToBits().Take(32);
        }


        public static IEnumerable<bool> ToBits(this Int32 value)
        {
            return ((UInt64)value).ToBits().Take(32);
        }

        public static IEnumerable<bool> ToBits(this bool value)
        {
            yield return value;
        }

        public static IEnumerable<bool> ToBits(this byte[] value)
        {
            return value.SelectMany(b => b.ToBits());
        }

        public static UInt64 ToUInt64(this IEnumerable<bool> bits)
        {
            UInt64 value = 0;
            foreach (var bit in bits.Reverse())
            {
                value <<= 1;
                value |= bit ? 1UL : 0UL;
            }
            return value;
        }

        public static Int32 ToInt32(this IEnumerable<bool> bits)
        {
            return (Int32)ToUInt64(bits);
        }

        public static UInt32 ToUInt32(this IEnumerable<bool> bits)
        {
            return (UInt32)ToUInt64(bits);
        }

        public static UInt16 ToUInt16(this IEnumerable<bool> bits)
        {
            return (UInt16)ToUInt64(bits);
        }

        public static bool ToBool(this IEnumerable<bool> bits)
        {
            return bits.First();
        }

        public static byte ToByte(this IEnumerable<bool> bits)
        {
            return (byte)ToUInt64(bits);
        }

        public static IEnumerable<byte> ToBytes(this IEnumerable<bool> bits)
        {
            return bits.Split(8).Select(b => b.ToByte());
        }

        public static string ToBinaryString(this IEnumerable<bool> bits)
        {
            return String.Concat(bits.Select(b => b ? "1" : "0"));
        }

        public static IEnumerable<bool> BinaryStringToBits(this string binaryString, int bitCount)
        {
            return binaryString.Select(c => c == '1').Take(Math.Min(bitCount, binaryString.Length)).Concat(Enumerable.Repeat(false, Math.Max(0, bitCount - binaryString.Length)));
        }

        public static IEnumerable<bool> BinaryStringToBits(this string binaryString)
        {
            return BinaryStringToBits(binaryString, binaryString.Length);
        }
    }
}
