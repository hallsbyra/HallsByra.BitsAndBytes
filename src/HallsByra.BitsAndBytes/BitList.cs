using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HallsByra.BitsAndBytes
{
    /// Provides bit level access to an existing list of bytes.
    class BitList : IList<bool>
    {
        private readonly IList<byte> backingList = null;

        public BitList(IList<byte> byteList)
        {
            this.backingList = byteList;
        }

        public int IndexOf(bool item)
        {
            for (int index = 0; index <= Count; index++)
                if (this[index] == item)
                    return index;
            return -1;
        }

        public void Insert(int index, bool item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public bool this[int index]
        {
            get
            {
                int byteNo = index / 8;
                int bitNo = index % 8;
                byte mask = (byte)(1 << bitNo);
                return (backingList[byteNo] & mask) == mask;
            }
            set
            {
                int byteNo = index / 8;
                int bitNo = index % 8;
                byte mask = (byte)(1 << bitNo);
                if(value)
                    backingList[byteNo] |= mask;
                else
                    backingList[byteNo] &= (byte)~mask;
            }
        }

        public void Add(bool item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(bool item)
        {
            return ((IEnumerable<bool>)this).Contains(item);
        }

        public void CopyTo(bool[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return backingList.Count * 8; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(bool item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<bool> GetEnumerator()
        {
            for(int index = 0; index < Count; index++)
            {
                yield return this[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
