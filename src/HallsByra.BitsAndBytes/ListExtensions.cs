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
        public static UInt16 GetUInt16(this IList<byte> list, int startByte) => list.Offset(startByte).ToUInt16();        
        public static void SetUInt16(this IList<byte> list, ushort value, int startByte) => list.Offset(startByte).Apply(value.ToBytes());
        public static UInt32 GetUInt32(this IList<byte> list, int startByte, int byteCount = 4) => list.Offset(startByte).Take(byteCount).ToUInt32();
        public static void SetUInt32(this IList<byte> list, uint value, int startByte, int byteCount = 4) => list.Offset(startByte).Apply(value.ToBytes().Take<byte>(byteCount));
    }

    public static class BitListExtensions
    {
        public static bool GetBool(this IList<bool> list, int startBit, int bitCount = 1)
        {
            Debug.Assert(startBit >= 0, "startBit must be positive");
            Debug.Assert(bitCount == 1, "bitCount must be 1 for bools");
            return list[startBit];
        }

        public static void SetBool(this IList<bool> list, bool value, int startBit, int bitCount = 1)
        {
            Debug.Assert(startBit >= 0, "startBit must be positive");
            Debug.Assert(bitCount == 1, "bitCount must be 1 for bools");
            list[startBit] = value;
        }

        public static byte GetByte(this IList<bool> list, int startBit, int bitCount = 8)
        {
            Debug.Assert(startBit >= 0, "startBit must be positive");
            Debug.Assert(bitCount > 0, "bitCount must be positive");
            Debug.Assert(bitCount <= 8, "a byte must be maximum 8 bits");
            return list.Offset(startBit).Take(bitCount).ToByte();
        }

        public static void SetByte(this IList<bool> list, byte value, int startBit, int bitCount = 8)
        {
            Debug.Assert(startBit >= 0, "startBit must be positive");
            Debug.Assert(bitCount > 0, "bitCount must be positive");
            Debug.Assert(bitCount <= 8, "a byte must be maximum 8 bits");
            list.Offset(startBit).Apply(value.ToBits().Take(bitCount));
        }

        public static UInt16 GetUInt16(this IList<bool> list, int startBit, int bitCount = 16)
        {
            Debug.Assert(startBit >= 0, "startBit must be positive");
            Debug.Assert(bitCount > 0, "bitCount must be positive");
            Debug.Assert(bitCount <= 16, "a UInt16 must be maximum 16 bits");
            return list.Offset(startBit).Take(bitCount).ToUInt16();
        }

        public static void SetUInt16(this IList<bool> list, UInt16 value, int startBit, int bitCount = 16)
        {
            Debug.Assert(startBit >= 0, "startBit must be positive");
            Debug.Assert(bitCount > 0, "bitCount must be positive");
            Debug.Assert(bitCount <= 16, "a UInt16 must be maximum 16 bits");
            list.Offset(startBit).Apply(value.ToBits().Take(bitCount));
        }

        public static UInt32 GetUInt32(this IList<bool> list, int startBit, int bitCount = 32)
        {
            Debug.Assert(startBit >= 0, "startBit must be positive");
            Debug.Assert(bitCount > 0, "bitCount must be positive");
            Debug.Assert(bitCount <= 32, "a UInt32 must be maximum 32 bits");
            return list.Offset(startBit).Take(bitCount).ToUInt32();
        }

        public static void SetUInt32(this IList<bool> list, UInt32 value, int startBit, int bitCount = 32)
        {
            Debug.Assert(startBit >= 0, "startBit must be positive");
            Debug.Assert(bitCount > 0, "bitCount must be positive");
            Debug.Assert(bitCount <= 32, "a UInt32 must be maximum 32 bits");
            list.Offset(startBit).Apply(value.ToBits().Take(bitCount));
        }
    }

}
