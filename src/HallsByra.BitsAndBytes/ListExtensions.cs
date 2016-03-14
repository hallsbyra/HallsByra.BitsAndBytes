using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HallsByra.BitsAndBytes
{
    public static class ListExtensions
    {
        public static void Apply<T>(this IList<T> list, IEnumerable<T> elementsToApply)
        {
            int index = 0;
            elementsToApply.Each(e => list[index++] = e);
        }

        public static IList<bool> ToBitList(this IList<byte> byteList)
        {
            return new BitList(byteList);
        }

        public static IList<T> Offset<T>(this IList<T> list, int offset)
        {
            return new OffsetList<T>(list, offset);
        }


        public static IList<T> Combine<T>(this IList<T> thisList, IList<T> secondList)
        {
            return new VirtualList<T>(thisList, secondList);
        }
    }

    public static class ByteListExtensions
    {
        public static bool GetBool(this IList<byte> list, int startBit, int bitCount) => list.ToBitList().GetBool(startBit, bitCount);
        public static void SetBool(this IList<byte> list, bool value, int startBit, int bitCount) => list.ToBitList().SetBool(value, startBit, bitCount);
        public static byte GetByte(this IList<byte> list, int startBit, int bitCount) => list.ToBitList().GetByte(startBit, bitCount);
        public static void SetByte(this IList<byte> list, byte value, int startBit, int bitCount) => list.ToBitList().SetByte(value, startBit, bitCount);
        public static UInt16 GetUInt16(this IList<byte> list, int startBit, int bitCount) => list.ToBitList().GetUInt16(startBit, bitCount);
        public static void SetUInt16(this IList<byte> list, UInt16 value, int startBit, int bitCount) => list.ToBitList().SetUInt16(value, startBit, bitCount);
        public static UInt32 GetUInt32(this IList<byte> list, int startBit, int bitCount) => list.ToBitList().GetUInt32(startBit, bitCount);
        public static void SetUInt32(this IList<byte> list, UInt32 value, int startBit, int bitCount) => list.ToBitList().SetUInt32(value, startBit, bitCount);
    }

    public static class BitListExtensions
    {
        public static bool GetBool(this IList<bool> list, int startBit, int bitCount)
        {
            Debug.Assert(startBit >= 0, "startBit must be positive");
            Debug.Assert(bitCount == 1, "bitCount must be 1 for bools");
            return list[startBit];
        }

        public static void SetBool(this IList<bool> list, bool value, int startBit, int bitCount)
        {
            Debug.Assert(startBit >= 0, "startBit must be positive");
            Debug.Assert(bitCount == 1, "bitCount must be 1 for bools");
            list[startBit] = value;
        }

        public static byte GetByte(this IList<bool> list, int startBit, int bitCount)
        {
            Debug.Assert(startBit >= 0, "startBit must be positive");
            Debug.Assert(bitCount > 0, "bitCount must be positive");
            Debug.Assert(bitCount <= 8, "a byte must be maximum 8 bits");
            return list.Offset(startBit).Take(bitCount).ToByte();
        }

        public static void SetByte(this IList<bool> list, byte value, int startBit, int bitCount)
        {
            Debug.Assert(startBit >= 0, "startBit must be positive");
            Debug.Assert(bitCount > 0, "bitCount must be positive");
            Debug.Assert(bitCount <= 8, "a byte must be maximum 8 bits");
            list.Offset(startBit).Apply(value.ToBits(bitCount));
        }

        public static UInt16 GetUInt16(this IList<bool> list, int startBit, int bitCount)
        {
            Debug.Assert(startBit >= 0, "startBit must be positive");
            Debug.Assert(bitCount > 0, "bitCount must be positive");
            Debug.Assert(bitCount <= 16, "a UInt16 must be maximum 16 bits");
            return list.Offset(startBit).Take(bitCount).ToUInt16();
        }

        public static void SetUInt16(this IList<bool> list, UInt16 value, int startBit, int bitCount)
        {
            Debug.Assert(startBit >= 0, "startBit must be positive");
            Debug.Assert(bitCount > 0, "bitCount must be positive");
            Debug.Assert(bitCount <= 16, "a UInt16 must be maximum 16 bits");
            list.Offset(startBit).Apply(value.ToBits(bitCount));
        }

        public static UInt32 GetUInt32(this IList<bool> list, int startBit, int bitCount)
        {
            Debug.Assert(startBit >= 0, "startBit must be positive");
            Debug.Assert(bitCount > 0, "bitCount must be positive");
            Debug.Assert(bitCount <= 32, "a UInt32 must be maximum 32 bits");
            return list.Offset(startBit).Take(bitCount).ToUInt32();
        }

        public static void SetUInt32(this IList<bool> list, UInt32 value, int startBit, int bitCount)
        {
            Debug.Assert(startBit >= 0, "startBit must be positive");
            Debug.Assert(bitCount > 0, "bitCount must be positive");
            Debug.Assert(bitCount <= 32, "a UInt32 must be maximum 32 bits");
            list.Offset(startBit).Apply(value.ToBits(bitCount));
        }
    }

}
